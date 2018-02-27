using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SSJT.Crm.Common
{
    public class FileHelper
    {
        /// <summary>
        /// 读取文件的字节数组
        /// </summary>
        /// <param name="fileFullPath">文件的全路径</param>
        /// <returns></returns>
        public static byte[] GetFile(string fileFullPath)
        {
            if (!File.Exists(fileFullPath))
                throw new DirectoryNotFoundException("找不到文件!");
            using (FileStream fileStream = new FileStream(fileFullPath, FileMode.Open))
            {
                byte[] buffer = new byte[fileStream.Length];
                fileStream.Read(buffer, 0, (int)fileStream.Length);
                return buffer;
            }
        }
        //文件信息
        public static FileInfo GetFileInfo(string fileName)
        {
            FileInfo file = new FileInfo(fileName);
            return file;
        }
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="fullFilePath">文件全路径</param>
        public static void RemoveFile(string fullFilePath)
        {
            try
            {
                File.Delete(fullFilePath);
            }
            catch (DirectoryNotFoundException ex)
            {
                return;
            }
            catch (IOException ex)
            {
                throw new IOException("文件正在使用中,无法删除文件!");
            }
        }
        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="path"></param>
        public static void TryCreateDirectory(string path)
        {
            if (ExistDirectory(path))
                return;
            Directory.CreateDirectory(path);
        }
        /// <summary>
        /// 判断是否存在文件夹
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool ExistDirectory(string path)
        {
            return Directory.Exists(path);
        }
        /// <summary>
        /// 判断是否存在文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool ExistFile(string path)
        {
            return File.Exists(path);
        }
        public void TryDelete(string path)
        {
            if (ExistFile(path))
            {
                File.Delete(path);
            }
        }

        /// <summary>
        /// 创建一个新文件，在其中写入指定的字节数组，然后关闭该文件。 如果目标文件已存在，则覆盖该文件
        /// </summary>
        /// <param name="path">要写入的文件。</param>
        /// <param name="bytes">要写入的字节数组</param>
        public static void WriteAllBytes(string path, byte[] bytes)
        {
            File.WriteAllBytes(path, bytes);
        }
        /// <summary>
        /// 拷贝文件
        /// </summary>
        /// <param name="sourceFileName">源文件全路径</param>
        /// <param name="destFileName">目标文件全路径</param>
        public static void TryCopy(string sourceFileName, string destFileName)
        {
            if (File.Exists(destFileName) || !File.Exists(sourceFileName))
                return;
            File.Copy(sourceFileName, destFileName);
        }

        /// <summary>
        /// 分块上传
        /// </summary>
        /// <param name="chunkData"></param>
        /// <param name="chunk">第几块</param>
        /// <param name="chunks">总块数</param>
        /// <param name="uploadedFilename">文件名</param>
        /// <returns></returns>
        public static bool OnUploadChunk(byte[] chunkData, int chunk, int chunks, string uploadedFilename)
        {
            String path = Config.AvatarPath;

            // try to create the path
            if (!ExistDirectory(path))
            {
                try
                {
                    //Directory.CreateDirectory(path);
                    TryCreateDirectory(path);
                }
                catch
                {
                    throw new Exception("存储目录不存在或无法创建");
                }
            }

            // ensure that the filename is normalized and doesn't contain
            // any path traversal hacks
            uploadedFilename = Path.GetFileName(uploadedFilename);

            string uploadFilePath = Path.Combine(path, uploadedFilename);
            if (chunk == 0)
            {
                if (ExistFile(uploadFilePath))
                    RemoveFile(uploadFilePath);

                // time out files after 15 minutes - temporary upload files
                ThreadPool.QueueUserWorkItem(delegate
                {
                    DeleteTimedoutFiles(path, "*.*", 900);
                });
            }

            Stream stream = null;
            try
            {
                stream = new FileStream(uploadFilePath, (chunk == 0) ? FileMode.CreateNew : FileMode.Append);
                stream.Write(chunkData, 0, chunkData.Length);
            }
            catch
            {
                throw new Exception("无法写入文件");
            }
            finally
            {
                if (stream != null)
                    stream.Dispose();
            }

            return true;
        }
        
        /// <summary>
        /// Deletes files based on a file spec and a given timeout.
        /// This routine is useful for cleaning up temp files in 
        /// Web applications.
        /// </summary>
        /// <param name="directory">path</param>
        /// <param name="filePattern">wildcards</param>
        /// <param name="seconds">The timeout - if files are older than this timeout they are deleted</param>
        private static void DeleteTimedoutFiles(string directory, string filePattern, int seconds)
        {
            string[] files = Directory.GetFiles(directory, filePattern, SearchOption.AllDirectories);
            foreach (string file in files)
            {
                try
                {
                    if (GetFileInfo(file).LastWriteTime < DateTime.UtcNow.AddSeconds(seconds * -1))
                        RemoveFile(file);
                }
                catch { }  // ignore locked files
            }
        }

    }
}

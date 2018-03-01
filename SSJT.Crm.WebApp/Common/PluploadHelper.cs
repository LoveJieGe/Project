using SSJT.Crm.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;

namespace SSJT.Crm.WebApp.Common
{
    public class PluploadHelper
    {
        /// <summary>
        /// 分块上传
        /// </summary>
        /// <param name="chunkData"></param>
        /// <param name="chunk">第几块</param>
        /// <param name="chunks">总块数</param>
        /// <param name="uploadedFilename">文件名</param>
        /// <returns></returns>
        public static bool OnUploadChunk(PluploadFile pfile)
        {
            String path = Config.AvatarPath, uploadedFilename;
            int chunk = pfile.Chunk, chunks = pfile.Chunks;

            Stream chunkStream = pfile.FileUpload.InputStream;
            byte[] chunkData = new byte[chunkStream.Length];
            chunkStream.Read(chunkData, 0, chunkData.Length);
            chunkStream.Seek(0, SeekOrigin.Begin);
            if (pfile.IsScreenFile|| pfile.ScreenFileName.Contains("_screen"))
            {
                path += "screen/";
                uploadedFilename = pfile.ScreenFileName;
            }
            else
            {
                path += "source/";
                uploadedFilename = pfile.SourceFileName;
            }
           // 从创建文件夹
           if (!FileHelper.ExistDirectory(path))
            {
                try
                {
                    FileHelper.TryCreateDirectory(path);
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
                if (FileHelper.ExistFile(uploadFilePath))
                    FileHelper.RemoveFile(uploadFilePath);

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
                    if (FileHelper.GetFileInfo(file).LastWriteTime < DateTime.UtcNow.AddSeconds(seconds * -1))
                        FileHelper.RemoveFile(file);
                }
                catch { }  // ignore locked files
            }
        }
    }
}
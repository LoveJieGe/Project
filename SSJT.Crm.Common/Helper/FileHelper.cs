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

    }
}

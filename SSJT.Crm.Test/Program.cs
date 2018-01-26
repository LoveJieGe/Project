using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SSJT.Crm.DBUtility;
using Spring.Context;
using Spring.Context.Support;

namespace SSJT.Crm.Test
{
    class Program
    {

        static void Main(string[] args)
        {
            //string key = "Admin";

            //string source = "123456";

            //Console.WriteLine("Source  string: " + source);

            //string encryptStr = EncryptDES(source, key);
            //Console.WriteLine("Encrypt string: " + encryptStr);

            //string decryptStr = DecryptDES(encryptStr, key);
            //Console.WriteLine("Decrypt string: " + decryptStr);
            //IApplicationContext ctx = ContextRegistry.GetContext();
            //DbFactory t = ctx.GetObject("DbFactory") as DbFactory;
            //string message = t.Msg;
            //Console.WriteLine(message);
            //Console.WriteLine("静态：" + DbFactory.Message);
            Console.WriteLine("Main方法中线程：" + Thread.CurrentThread.ManagedThreadId + "主线程：" + Thread.CurrentThread.IsBackground);
            Type type = Type.GetType("SSJT.Crm.Test.Test");
            CallContext.SetData("Data", "123456");
            CallContext.LogicalSetData("Data2", "789");
            MethodInfo info = type.GetMethod("GetData");
            info.Invoke(Activator.CreateInstance(type), null);
            Console.ReadKey();
        }
        
        /// <summary>
        /// 进行DES加密
        /// </summary>
        /// <param name="pToEncrypt">要加密的字符串</param>
        /// <param name="key">密钥，必须为8位</param>
        /// <returns>以Base64格式返回的加密字符串</returns>
        static string EncryptDES(string pToEncrypt, string sKey)
        {
            if (sKey.Length > 8)
                sKey = sKey.Substring(0, 8);
            else if (sKey.Length < 8)
                sKey = sKey.PadRight(8, ' ');
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                byte[] inputByteArray = Encoding.UTF8.GetBytes(pToEncrypt);
                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    cs.Close();
                }
                string str = Convert.ToBase64String(ms.ToArray());
                ms.Close();
                return str;
            }
        }

        static string DecryptDES(string pToDecrypt, string sKey)
        {
            if (sKey.Length > 8)
                sKey = sKey.Substring(0, 8);
            else if (sKey.Length < 8)
                sKey = sKey.PadRight(8, ' ');
            byte[] inputByteArray = Convert.FromBase64String(pToDecrypt);
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                MemoryStream ms = new MemoryStream();
                using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    cs.Close();
                }
                string str = Encoding.UTF8.GetString(ms.ToArray());
                ms.Close();
                return str;
            }
        }
        

    }
}

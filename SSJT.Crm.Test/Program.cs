using System;
using System.Collections.Generic;
using System.Data;
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
using SSJT.Crm.Core.AjaxRequest;
using System.Collections;
using SSJT.Crm.Core.Exceptions;
using SSJT.Crm.Model;
using SSJT.Crm.BLL;
using SSJT.Crm.IBLL;

namespace SSJT.Crm.Test
{
    class Program
    {

        static void Main(string[] args)
        {
            string key = "Admin"; //324测试

            string source = "123456";

            Console.WriteLine("Source  string: " + source);

            string encryptStr = EncryptDES(source, key);
            Console.WriteLine("Encrypt string: " + encryptStr);

            string decryptStr = DecryptDES(encryptStr, key);
            Console.WriteLine("Decrypt string: " + decryptStr);
            //IApplicationContext ctx = ContextRegistry.GetContext();
            //DbFactory t = ctx.GetObject("DbFactory") as DbFactory;
            //string message = t.Msg;
            //Console.WriteLine(message);
            //Console.WriteLine("静态：" + DbFactory.Message);
            //Console.WriteLine("Main方法中线程：" + Thread.CurrentThread.ManagedThreadId + "主线程：" + Thread.CurrentThread.IsBackground);
            //Type type = Type.GetType("SSJT.Crm.Test.Test");
            //CallContext.SetData("Data", "123456");
            //CallContext.LogicalSetData("Data2", "789");
            //MethodInfo info = type.GetMethod("GetData");
            //info.Invoke(Activator.CreateInstance(type), null);

            //HrEmploy e = new HrEmploy();
            //e.UserID = "123456";
            //e.UserName = "管理员";
            //DataTable table = e.ToAjaxResult();
            //table.Columns.Add(new DataColumn("Expires", typeof(string)));
            //table.Rows[0]["Expires"] = DateTime.Now;
            //string js =Core.JsonHelper.ToJson(table, Core.DateTimeMode.JS);
            //Console.WriteLine(js);

            //int v = GetEnumValue(typeof(ErrorCode), Enum.GetName(typeof(ErrorCode), ErrorCode.VErrorCode));
            //int v2 = (int)Enum.ToObject(typeof(ErrorCode), ErrorCode.VErrorCode);
            //Type type = Type.GetType("SSJT.Crm.IBLL.IUserAuthServer,SSJT.Crm.IBLL");
            //MethodInfo[] items = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            //foreach (MethodInfo item in items)
            //{
            //    if(item.Name.Equals("GetMessage"))
            //    {
            //        object o = item.Invoke(GetInstance("SSJT.Crm.BLL.UserAuthServer,SSJT.Crm.BLL"), null);
            //        Console.Write(o);
            //    }
            //}
            //Console.Write("22");
            //测试EF更新功能
            //Crm.Model.CrmEntities context = new Model.CrmEntities();
            //var context
            //    = new XmlApplicationContext(Directory.GetCurrentDirectory() + @"\services.xml");
            //var test = context.GetObject("ContextFactory") as ContextFactory;
            //IHrEmployService service = ContextFactory.HrEmployService;
            //string message = test.Message;
            //HrEmploy user = service.LoadEntity(u => u.UserID == "Admin");
            //if (user != null)
            //{
            //    user.AvatarName = "测试s3";
            //    service.Update(user);
            //}
            Console.ReadKey();
        }
        public static object GetInstance(string fullClassName)
        {
            Type type = Type.GetType(fullClassName);
            object instance = Activator.CreateInstance(type);
            return instance;
        }
        public static int GetEnumValue(Type enumType, string enumName)
        {
            try
            {
                if (!enumType.IsEnum)
                    throw new ArgumentException("enumType必须是枚举类型");
                var values = Enum.GetValues(enumType);
                var ht = new Hashtable();
                foreach (var val in values)
                {
                    ht.Add(Enum.GetName(enumType, val), val);
                }
                return (int)ht[enumName];
            }
            catch (Exception e)
            {
                throw e;
            }
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

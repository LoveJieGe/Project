using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSJT.Crm.Core.AjaxRequest;
using System.Reflection;
using System.ComponentModel;
using System.Collections;
using SSJT.Crm.Core.Exceptions;

namespace SSJT.Crm.Core
{
    public class AjaxServer
    {
        private static Hashtable methodList = Hashtable.Synchronized(new Hashtable());
        private static object lockObject = new object();
        /// <summary>
        /// 获取请求的Ajax 的方法的信息
        /// </summary>
        /// <param name="className"></param>
        /// <param name="methodName"></param>
        /// <returns></returns>
        public static AjaxMethod GetAjaxMethod(string className,string methodName)
        {
            string key = string.Format("{0}.{1}", className, methodName);
            if (!methodList.Contains(key))
            {
                lock (lockObject)
                {
                    AjaxMethod method = new AjaxMethod();
                    Type type = Type.GetType(className);
                    if (type == null)
                        throw AjaxException.ToException(ErrorCode.PErrorCode, "无效的类方法[{0}]", className);
                    method.MethodInfo = Ajaxhelper.GetMethodInfo(type, methodName);
                    SetAjaxMethod(method, method.MethodInfo);
                    methodList.Add(key, method);
                }
            }
            return (AjaxMethod)methodList[key];
        }
        private static void SetAjaxMethod(AjaxMethod method, MethodInfo methodInfo)
        {
            if (!methodInfo.DeclaringType.IsDefined(typeof(AjaxClassAttribute)))
                throw new Exception(string.Format("无效的类[{0}]", methodInfo.DeclaringType));
            if (!methodInfo.IsDefined(typeof(AjaxMethodAttribute), true))
                throw new Exception(string.Format("方法[{0}]不是AjaxMethod标记方法", methodInfo.Name));
            method.DeclaringType = methodInfo.DeclaringType;
            method.MethodInfo = methodInfo;
            method.ReturnType = methodInfo.ReturnType;
            AjaxClassAttribute attr = methodInfo.DeclaringType.GetCustomAttribute<AjaxClassAttribute>(true);
            method.FullClassName = attr.DeclaringType;
            if (methodInfo.IsDefined(typeof(DescriptionAttribute), true))
                method.Description = methodInfo.GetCustomAttribute<DescriptionAttribute>(true).Description;
        }
        /// <summary>
        /// 获取类的实例
        /// </summary>
        /// <param name="fullClassName">类的完全限定名称</param>
        public static object GetInstance(string fullClassName)
        {
            Type type = Type.GetType(fullClassName);
            if(type==null)
                throw AjaxException.ToException(ErrorCode.PErrorCode, "无效的类方法[{0}]", fullClassName);
            object instance = Activator.CreateInstance(type);
            return instance;
        }
    }
}

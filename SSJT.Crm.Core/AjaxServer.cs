using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSJT.Crm.Core.AjaxRequest;
using System.Reflection;
using System.ComponentModel;

namespace SSJT.Crm.Core
{
    public class AjaxServer
    {
        public AjaxMethod GetAjaxMethod(string className,string methodName)
        {
            string 
        }
        public void SetAjaxMethod(AjaxMethod method, MethodInfo methodInfo)
        {
            if (!methodInfo.IsDefined(typeof(AjaxMethodAttribute), true))
                throw new Exception(string.Format("方法[{0}]不是AjaxMethod标记方法", methodInfo.Name));
            method.MethodInfo = methodInfo;
            method.ReturnType = methodInfo.ReturnType;
            if (methodInfo.IsDefined(typeof(DescriptionAttribute), true))
                method.Description = methodInfo.GetCustomAttribute<DescriptionAttribute>(true).Description;
            method.DeclaringType = methodInfo.DeclaringType;
        }
    }
}

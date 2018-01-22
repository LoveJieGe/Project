using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SSJT.Crm.Core.AjaxRequest;

namespace SSJT.Crm.Core.AjaxResponse
{
    public class AjaxProcess : IAjaxProcess
    {
        public AjaxResult DoProcess(AjaxReceive receive)
        {
            AjaxResult result = new AjaxResult {ErrorMsg="ok" };
            if (string.IsNullOrEmpty(receive.ClassName) || string.IsNullOrEmpty(receive.MethodName))
                throw new Exception("参数信息不正确");
            if() 
        }
    }
}

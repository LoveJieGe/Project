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
            AjaxResult result = new AjaxResult { ErrorMsg = "ok" };
            try
            {
                if (string.IsNullOrEmpty(receive.ClassName) || string.IsNullOrEmpty(receive.MethodName))
                    throw new Exception("参数信息不正确");
                AjaxMethod method = AjaxServer.GetAjaxMethod(receive.FullClassName, receive.MethodName);
                result.Method = method;
                ParameterInfo[] parameters = method.MethodInfo.GetParameters();
                object[] objArray = Ajaxhelper.ParseParams(receive.Data, parameters);
                object r = method.MethodInfo.Invoke(AjaxServer.GetInstance(receive.FullClassName), objArray);
                if (r != null)
                {
                    result.Result = Ajaxhelper.ToJson(r);
                }
            }
            catch (Exception ex)
            {
                result.ErrorMsg = ex.Message;
            }
            finally
            {
                receive.Clear();
            }
            result.FillResponseText();
            return result;
        }
    }
}

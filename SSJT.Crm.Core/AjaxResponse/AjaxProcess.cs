using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SSJT.Crm.Core.AjaxRequest;
using SSJT.Crm.Core.Exceptions;

namespace SSJT.Crm.Core.AjaxResponse
{
    public class AjaxProcess : IAjaxProcess
    {
        public AjaxResult DoProcess(AjaxReceive receive)
        {
            AjaxResult result = new AjaxResult {IsSuccess = true };
            try
            {
                if (string.IsNullOrEmpty(receive.ClassName) || string.IsNullOrEmpty(receive.MethodName))
                    throw new Exception("参数不能解析");
                AjaxMethod method = AjaxServer.GetAjaxMethod(receive.FullClassName, receive.MethodName);
                result.Method = method;
                ParameterInfo[] parameters = method.MethodInfo.GetParameters();
                object[] objArray = Ajaxhelper.ParseParams(receive.Data, parameters);
                object r = method.MethodInfo.Invoke(AjaxServer.GetInstance(receive.FullClassName), objArray);
                if (r != null)
                {
                    result.Data = r;
                    result.Result = Ajaxhelper.ToJson(r);
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                HandleException(ex, result);
            }
            finally
            {
                receive.Clear();
            }
            result.FillResponseText();
            return result;
        }
        private void HandleException(Exception ex, AjaxResult result)
        {
            while(ex!=null)
            {
                if(ex is AjaxException)
                {
                    result.ErrorCode = ((AjaxException)ex).ErrorCode;
                    result.ErrorMsg = ((AjaxException)ex).Message;
                }
                else
                {
                    result.ErrorCode = ErrorCode.Default;
                    result.ErrorMsg = ex.Message;
                }
                ex = ex.InnerException;
            }
        }
    }
}

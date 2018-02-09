using SSJT.Crm.Common;
using SSJT.Crm.Core.AjaxRequest;
using System;
using System.Web;
using System.Web.SessionState;
using SSJT.Crm.Core.Exceptions;

namespace SSJT.Crm.WebApp.AjaxHandler
{
    /// <summary>
    /// AjaxRequest 的摘要说明
    /// </summary>
    public class AjaxRequest : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                AjaxReceive receive = new AjaxReceive();
                receive.Fill(context);
                if (Helper.Equals(receive.MethodName, "login"))
                {
                    string validate = context.Request["Validate"];
                    string vCode = context.Session["VCode"] == null ? "" : context.Session["VCode"].ToString();
                    if (!Helper.Equals(validate, vCode))
                    {
                        context.Response.ContentType = "application/json";
                        context.Response.Write(Core.Ajaxhelper.ToJson(new
                        {
                            ErrorCode = ErrorCode.VErrorCode,
                            Success = false,
                            Message = "验证码错误"
                        }));
                        return;
                    }
                }
                AjaxResult result = ContextFactory.AjaxProcess.DoProcess(receive);
                if (result.IsSuccess)
                {
                    context.Response.ContentType = "application/json";
                    context.Response.Write(Core.JsonHelper.ToJson(result.Data, Core.DateTimeMode.JS));
                }
                else
                {
                    ErrorResponse(context, result);
                }
            }
            catch (Exception e)
            {
                string msg = e.InnerException == null ? e.Message : e.InnerException.Message;
                context.Response.Clear();
                context.Response.ContentType = "text/plain";
                context.Response.TrySkipIisCustomErrors = true;
                context.Response.StatusCode = 400;
                context.Response.Write(msg);
            }
        }
        private void ErrorResponse(HttpContext context, AjaxResult result)
        {
            context.Response.Clear();
            context.Response.ContentType = "application/json";
            if (Enum.IsDefined(typeof(ErrorCode),result.ErrorCode))
            {
                context.Response.Write(Core.Ajaxhelper.ToJson(new
                {
                    ErrorCode = result.ErrorCode,
                    Success = false,
                    Message = result.ErrorMsg
                }));
            }
            else
            {
                context.Response.Write(Core.Ajaxhelper.ToJson(new
                {
                    Success = false,
                    Message = result.ErrorMsg
                }));
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
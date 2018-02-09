using SSJT.Crm.Core.AjaxRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSJT.Crm.WebApp.AjaxHandler
{
    /// <summary>
    /// UserRequest 的摘要说明
    /// </summary>
    public class UserRequest : BaseRequest
    {
        public override void ProcessRequest(HttpContext context)
        {
            try
            {
                base.ProcessRequest(context);
                AjaxReceive receive = new AjaxReceive();
                receive.Fill(context);
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
    }
}
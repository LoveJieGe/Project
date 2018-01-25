using SSJT.Crm.Core.AjaxRequest;
using SSJT.Crm.DBUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace SSJT.Crm.WebApp.ApiHandler
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
                AjaxResult result = ContextFactory.AjaxProcess.DoProcess(receive);
                WriteResponse(context, result);
            }
            catch (Exception e)
            {
                string msg = e.InnerException == null ? e.Message : e.InnerException.Message;
                context.Response.Clear();
                context.Response.ContentType = "application/json";
                //context.Response.TrySkipIisCustomErrors = true;
                context.Response.Write(Core.Ajaxhelper.ToJson(new
                {
                    Success = false,
                    Message = msg
                }));
            }
        }
        private void WriteResponse(HttpContext context, AjaxResult result)
        {
            context.Response.Clear();
            context.Response.ContentType = "application/json";
            //context.Response.TrySkipIisCustomErrors = true;
            if (result.IsSuccess)
            {
                context.Response.Write(Core.Ajaxhelper.ToJson(new
                {
                    Success = true,
                    Data = result.ResponseText
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
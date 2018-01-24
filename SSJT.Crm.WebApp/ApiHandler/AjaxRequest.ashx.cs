using SSJT.Crm.Core.AjaxRequest;
using SSJT.Crm.DBUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSJT.Crm.WebApp.ApiHandler
{
    /// <summary>
    /// AjaxRequest 的摘要说明
    /// </summary>
    public class AjaxRequest : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                AjaxReceive receive = new AjaxReceive();
                receive.Fill(context);
                AjaxResult result = ContextFactory.AjaxProcess.DoProcess(receive);
                //string message = DbFactory.Message;
                //string data = context.Request["data"];
                if (!string.IsNullOrEmpty(result.ErrorMsg))
                {
                    WriteResponse(context, result.ErrorMsg);
                }else
                {
                    context.Response.ContentType = "application/json";
                    context.Response.Write(result.ResponseText);
                }
            }
            catch (Exception e)
            {
                WriteResponse(context, e.Message);
            }
        }
        private void WriteResponse(HttpContext context, string msg)
        {
            context.Response.Clear();
            context.Response.ContentType = "text/plain";
            context.Response.TrySkipIisCustomErrors = true;
            context.Response.Write(msg);
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSJT.Crm.WebApp.AngularJs
{
    /// <summary>
    /// BaseCORSHandler 的摘要说明
    /// </summary>
    public class BaseCORSHandler : IHttpHandler
    {

        public virtual void ProcessRequest(HttpContext context)
        {
            if (context.Request.Headers["Orign"] != null)
                context.Response.AddHeader("Access-Control-Allow-Origin", context.Request.Headers["Orign"]);
            else
                context.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            context.Response.AppendHeader("Access-Control-Allow-Headers", "Origin, No-Cache, X-Requested-With, If-Modified-Since, Pragma, Last-Modified, Cache-Control, Expires, Content-Type, X-E4M-With");
        }

        public virtual bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSJT.Crm.Web.Common
{
    /// <summary>
    /// 支持跨域的请求
    /// </summary>
    public class BaseCORSHandler : IHttpHandler
    {
        public virtual bool IsReusable => false;

        public virtual void ProcessRequest(HttpContext context)
        {
            #region 支持跨域请求
            if (context.Request.Headers["Origin"] != null)
                context.Response.AppendHeader("Access-Control-Allow-Origin", context.Request.Headers["Origin"]);
            else
                context.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            context.Response.AppendHeader("Access-Control-Allow-Credentials", "true"); //如果前端请求有withCredentials: true, 则加上这句，表示允许请求带有Cookies信息，  
            context.Response.AppendHeader("Access-Control-Allow-Headers", "Origin, No-Cache, X-Requested-With, If-Modified-Since, Pragma, Last-Modified, Cache-Control, Expires, Content-Type, X-E4M-With");
            context.Response.AppendHeader("Access-Control-Allow-Methods", "GET, POST, OPTIONS");
            #endregion
        }
    }
}
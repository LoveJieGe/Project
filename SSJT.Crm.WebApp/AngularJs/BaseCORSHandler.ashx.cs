using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSJT.Crm.WebApp
{
    /// <summary>
    /// BaseCORSHandler 的摘要说明
    /// </summary>
    public class BaseCORSHandler : IHttpHandler
    {

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

        public virtual bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSJT.Crm.Core;
using SSJT.Crm.IBLL;

namespace SSJT.Crm.WebApp.AjaxHandler
{
    /// <summary>
    /// BaseRequest 的摘要说明
    /// </summary>
    public class BaseRequest : IHttpHandler
    {
        public virtual void ProcessRequest(HttpContext context)
        {
            #region 判断用户是否登录
            IStoreServer storeServer = HelperManager.GetInstance(typeof(IStoreServer)) as IStoreServer;
            //storeServer
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
            #endregion
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSJT.Crm.Core;
using SSJT.Crm.IBLL;
using SSJT.Crm.Core.Exceptions;
using SSJT.Crm.Core.AjaxRequest;

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
            #endregion
        }
        protected void ErrorResponse(HttpContext context, AjaxResult result)
        {
            context.Response.Clear();
            context.Response.ContentType = "application/json";
            if (Enum.IsDefined(typeof(ErrorCode), result.ErrorCode))
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
        protected void ErrorResponse(HttpContext context, string code, string message)
        {
            context.Response.Clear();
            context.Response.ContentType = "application/json";
            context.Response.Write(Core.Ajaxhelper.ToJson(new
            {
                Success = false,
                ErrorCode = code,
                Message = message
            }));
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
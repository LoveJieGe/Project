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
    public class BaseRequest : BaseCORSHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);

            #region 判断用户是否登录
            try
            {
                Core.Server.ISessionServer sessionserver = SessionFactory.GetSessionServer();
                if (sessionserver.HasLogin())
                {
                    sessionserver.SetTimeOut(sessionserver.GetTimeout());
                }
                else
                {
                    Model.HrEmploy model = sessionserver.CurrentUser;
                    if (model != null)
                    {
                        sessionserver.SetTimeOut(sessionserver.GetTimeout());
                    }
                    else
                    {
                        context.Response.Clear();
                        context.Response.ContentType = "application/json";
                        context.Response.StatusCode = 400;
                        context.Response.Write(Core.Ajaxhelper.ToJson(new
                        {
                            ErrorCode = ErrorCode.SErrorCode,
                            Success = false,
                            Message = "您的会话已超时, 请重新登录本系统."
                        }));
                        return;
                    }
                }
            }
            catch (Exception e)
            {
                while (e.InnerException != null)
                {
                    e = e.InnerException;
                }
                ErrorResponse(context, 400, e.Message);
            }
            #endregion
        }
        protected void ErrorResponse(HttpContext context, AjaxResult result)
        {
            context.Response.Clear();
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 400;
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
        protected void ErrorResponse(HttpContext context, int code, string message)
        {
            context.Response.Clear();
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = code;
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
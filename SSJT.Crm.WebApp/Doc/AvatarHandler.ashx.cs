using SSJT.Crm.Common;
using SSJT.Crm.Model;
using SSJT.Crm.WebApp.AjaxHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSJT.Crm.WebApp.Doc
{
    /// <summary>
    /// AvatarHandler 的摘要说明
    /// </summary>
    public class AvatarHandler : BaseRequest
    {
        public override void ProcessRequest(HttpContext context)
        {
            try
            {
                string userID = context.Request["UserID"];
                if (string.IsNullOrEmpty(userID))
                {
                    context.Response.StatusCode = 400;
                    context.Response.Write("参数不正确, 文件加载失败.");
                }
                else
                {
                    context.Response.ContentType = "image/png";
                    userID = Crm.Common.Helper.FromHex(userID);
                    HrEmploy item = ContextFactory.HrEmployService.LoadEntity(U => U.UserID == userID);
                    string avatarPath = string.Empty;
                    if (item != null)
                    {
                        avatarPath = Config.AvatarPath+"screen/" + item.AvatarName;
                    }
                    byte[] bytes = FileHelper.GetFile(avatarPath);
                    if (bytes != null)
                        context.Response.BinaryWrite(bytes);
                    else
                        context.Response.StatusCode = 404;
                }
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 404;
            }
        }
    }
}
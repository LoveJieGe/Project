using SSJT.Crm.Common;
using SSJT.Crm.Model;
using SSJT.Crm.WebApp.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace SSJT.Crm.WebApp.Doc
{
    /// <summary>
    /// ImageUpload 的摘要说明
    /// </summary>
    public class ImageUpload : PlUploadFileHandler, IRequiresSessionState
    {

        public ImageUpload()
        {
            // Normally you'd set these values from config values
            MaxUploadSize = 4 * 1024 * 1024; // 4 MB
            AllowedExtensions = ".jpg,.jpeg,.png,.gif,.bmp";
        }

        protected override void OnUploadCompleted(PluploadFile pfile)
        {
            object result = null;
            try
            {
                if (!pfile.IsScreenFile || pfile.ScreenFileName.Contains("_source")) return;
                string userId = Helper.FromHex(pfile.Context.Request["UserID"]);
                HrEmploy user = ContextFactory.HrEmployService.LoadEntity(u => u.UserID == userId);
                if (user != null)
                {
                    user.AvatarName = pfile.ScreenFileName;
                    ContextFactory.HrEmployService.Update(user);
                   
                }
            }
            catch (Exception e)
            {
                WriteErrorResponse(GetExceptMsg(e), 100, false);
            }
            // return just a string that contains the url path to the file
            WriteUploadCompletedMessage("{\"success\" : true, \"result\" : " + JsonEncode(result) + "}");
        }
    }
}
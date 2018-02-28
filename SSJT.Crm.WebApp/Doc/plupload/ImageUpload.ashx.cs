using SSJT.Crm.Common;
using SSJT.Crm.Model;
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

        protected override void OnUploadCompleted(HttpContext context,string fileName)
        {
            object result = null;

            try
            {
                if (fileName.Contains("screen")) return;
                string userId = Helper.FromHex(context.Request["UserID"]);
                if (context.Request.Files.Count > 0)
                {
                    string name = context.Request.Files[0].FileName;
                    if (string.IsNullOrEmpty(name) || string.Equals(name, "blob"))
                        fileName = Request["name"] ?? string.Empty;
                    // normalize file name to avoid directory traversal attacks            
                    name = Path.GetFileName(name);
                    HrEmploy user = ContextFactory.HrEmployService.LoadEntity(u => u.UserID == userId);
                    if (user != null)
                    {
                        user.AvatarName = name;
                        ContextFactory.HrEmployService.Update(user);
                    }
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
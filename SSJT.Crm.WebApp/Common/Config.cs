using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSJT.Crm.WebApp
{
    /// <summary>
    /// 系统配置
    /// </summary>
    public class Config
    {
        public string AvatarPath
        {
            get
            {
                string avatarPath = @"F:\MyProject\Git\Document\avatar\";
                string path = System.Configuration.ConfigurationManager.AppSettings["AvatarPath"];
                if (!string.IsNullOrEmpty(path))
                {
                    if (path.EndsWith("\\"))
                        avatarPath = path;
                    else
                        avatarPath =  path + "\\";
                }
                if (HttpContext.Current != null && HttpContext.Current.Server != null)
                    avatarPath = HttpContext.Current.Server.MapPath("~/iamges/avatar/");
                return avatarPath;
            }
        }
        
    }
}
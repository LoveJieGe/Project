using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SSJT.Crm.Core.Server
{
    internal class ServerConfig
    {
        public static string AppName
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["AppName"]; }
        }

        public static int? Timeout
        {
            get
            {
                int? time = 0;
                string timeout = System.Configuration.ConfigurationManager.AppSettings["Timeout"];
                try
                {
                    time = int.Parse(timeout);
                }
                catch (Exception e)
                {
                    time = null;
                }
                if (time==null&&HttpContext.Current != null && HttpContext.Current.Session != null)
                {
                    time = HttpContext.Current.Session.Timeout;
                }
                return time;
            }
        }
    }
}

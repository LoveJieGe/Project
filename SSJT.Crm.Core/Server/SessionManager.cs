using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SSJT.Crm.Core.Server
{
    internal class SessionManager
    {
        private Hashtable sessions;
        private object lockObject = new object();
        internal SessionManager()
        {
            if (sessions == null)
                sessions = Hashtable.Synchronized(new Hashtable());
        }
        public static bool LoginOk
        {
            get
            {
                if (HttpContext.Current != null && HttpContext.Current.Session != null)
                {
                    object login = HttpContext.Current.Session["LoginOk"];
                    return login != null && (bool)login;
                }
                return false;
            }
            set
            {
                if (HttpContext.Current != null && HttpContext.Current.Session != null)
                {
                    if (ServerConfig.Timeout.HasValue)
                        HttpContext.Current.Session.Timeout = ServerConfig.Timeout.Value;
                    HttpContext.Current.Session["LoginOk"] = value;
                }
            }
        }
        public static void SetTimeout(int time)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session != null)
            {
                HttpContext.Current.Session.Timeout = time;
            }
        }

        //存储登录验证成功之后的SessionMode
        public static SessionMode SessionMode
        {
            get
            {
                if (HttpContext.Current != null && HttpContext.Current.Session != null)
                {
                    object account = HttpContext.Current.Session["SSJT.Crm.Account"];
                    if (account != null)
                    {
                        return account as SessionMode;
                    }
                }
                return null;
            }
            set
            {
                if (HttpContext.Current != null && HttpContext.Current.Session != null)
                {
                    if (ServerConfig.Timeout.HasValue)
                        HttpContext.Current.Session.Timeout = ServerConfig.Timeout.Value;
                    HttpContext.Current.Session["SSJT.Crm.Account"] = value;
                }
            }
        }
        public static string GetCurrentSessionID()
        {
            string sessionId = string.Empty;
            try
            {
                if (HttpContext.Current != null)
                {
                    sessionId = HttpContext.Current.Request.Cookies["ASP.NET_SessionId"].Value;
                    if (string.IsNullOrEmpty(sessionId)&& HttpContext.Current.Session!=null)
                    {
                        sessionId = HttpContext.Current.Session.SessionID;
                    }
                }
                if (!string.IsNullOrEmpty(sessionId))
                    sessionId = string.Format("{0}.{1}", ServerConfig.AppName, sessionId);
            }
            catch (Exception e) {}
            return sessionId;
        }

        public static void RemoveSession()
        {
            if (HttpContext.Current != null && HttpContext.Current.Session != null)
            {
                HttpContext.Current.Session.Remove("SSJT.Crm.Account");
            }
        }
    }
}

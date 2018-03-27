using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using SSJT.Crm.Core.Exceptions;
using SSJT.Crm.DBUtility;
using SSJT.Crm.Model;
using System.Collections;

namespace SSJT.Crm.Core.Server
{
    public class SessionServer:ISessionServer
    {
        private Hashtable sessions;
        private object lockObject = new object();
        public SessionServer()
        {
            if(sessions==null)
                sessions = Hashtable.Synchronized(new Hashtable());
        }
        /// <summary>
        /// 注册Session
        /// </summary>
        /// <param name="userID">用户名</param>
        /// <param name="password">密码</param>
        public void RegSession(string userID,string password)
        {
            string pwd = SafeHelper.EncryptDES(password, userID);
            string sessionId = SessionManager.GetCurrentSessionID();
            if (!SqlHelper.Exists<HrEmploy>(H => H.UserID == userID && H.PassWord == pwd))
                throw new Exception(string.Format("注册SessionID[{0}]失败", sessionId));
            HrEmploy info = DbFactory.DbSession.DbContext.Set<HrEmploy>().FirstOrDefault(H => H.UserID == userID && H.PassWord == pwd);
            SessionMode mode = new SessionMode
            {
                SessionID = sessionId,
                HrEmployee = info
            };
            if (!this.sessions.ContainsKey(sessionId))
            {
                lock(lockObject)
                {
                    
                    this.sessions.Add(sessionId, mode);
                }
            }
            SessionManager.LoginOk = true;
            SessionManager.SessionMode = mode;
            CookieManager.LoginOk = true;
            CookieManager.UserID = userID;
        }
        /// <summary>
        /// 根据sessionID移除session和Cookie中的数据
        /// </summary>
        /// <param name="sessionID"></param>
        public void RemoveCache(string sessionID)
        {
            lock (lockObject)
            {
                if(this.sessions.ContainsKey(sessionID))
                    this.sessions.Remove(sessionID);
                SessionManager.RemoveSession();
                SessionManager.LoginOk = false;
                CookieManager.RemoveCookie();
                CookieManager.LoginOk = false;
            }
        }
        /// <summary>
        /// 根据SessionID获取session中存储的数据
        /// </summary>
        /// <param name="sessionID"></param>
        /// <returns></returns>
        public SessionMode GetSessionMode(string sessionID)
        {
            SessionMode mode = null;
            if (this.sessions.ContainsKey(sessionID))
            {
                mode = this.sessions[sessionID] as SessionMode;
            }
            else if (HttpContext.Current != null && HttpContext.Current.Session != null)
            {
                var r = SessionManager.SessionMode;
                if (r != null)
                    mode = (r as SessionMode);
            }
            if (mode == null){
                string userID = CookieManager.UserID;
                HrEmploy info = DbFactory.DbSession.DbContext.Set<HrEmploy>().FirstOrDefault(H => H.UserID == userID );
                if (info != null)
                {
                    mode = new SessionMode { HrEmployee = info };
                }
                else
                {
                    throw AjaxException.ToException(ErrorCode.SErrorCode, "您的会话已超时, 请重新登录本系统.");
                }
            }
            return mode;
        }
       
        /// <summary>
        /// 获取Session的过期时间
        /// </summary>
        public int GetTimeout()
        {
            if (ServerConfig.Timeout.HasValue)
                return ServerConfig.Timeout.Value;
            return 0;
        }
        public void SetTimeOut(int time)
        {
            SessionManager.SetTimeout(time);
            CookieManager.SetTimeout(time);
        }
        public string GetCurrentSessionID()
        {
            return SessionManager.GetCurrentSessionID();
        }
        public HrEmploy CurrentUser
        {
            get
            {
                SessionMode mode = this.GetSessionMode(this.GetCurrentSessionID());
                return mode.HrEmployee;
            }
        }
        public bool HasLogin()
        {
            return SessionManager.LoginOk || CookieManager.LoginOk;
        }
    }
}

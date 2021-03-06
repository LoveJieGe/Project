﻿using System;
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
            string sessionId = string.Format("{0}.{1}", this.AppName, this.GetSessionID());
            if (!SqlHelper.Exists<HrEmploy>(H => H.UserID == userID && H.PassWord == pwd))
                throw new Exception(string.Format("注册SessionID[{0}]失败", sessionId));
            if(!this.sessions.ContainsKey(sessionId))
            {
                lock(lockObject)
                {
                    
                    HrEmploy info = DbFactory.DbSession.DbContext.Set<HrEmploy>().FirstOrDefault(H => H.UserID == userID &&H.PassWord == pwd);
                    SessionMode mode = new SessionMode
                    {
                        SessionID = sessionId,
                        HrEmployee = info
                    };
                    if (HttpContext.Current != null && HttpContext.Current.Session != null)
                    {
                        HttpContext.Current.Session[sessionId] = mode;
                    }
                    this.sessions.Add(sessionId, mode);
                }
            }
        }
        /// <summary>
        /// 根据sessionID移除session中的数据
        /// </summary>
        /// <param name="sessionID"></param>
        public void RemoveSession(string sessionID)
        {
            lock (lockObject)
            {
                if(this.sessions.ContainsKey(sessionID))
                    this.sessions.Remove(sessionID);
                HttpContext.Current.Session.Remove(sessionID);
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
            }else if (HttpContext.Current != null && HttpContext.Current.Session != null)
            {
                var r = HttpContext.Current.Session[sessionID];
                if (r != null)
                    mode = (r as SessionMode);
            }
            if(mode==null)
                throw AjaxException.ToException(ErrorCode.SErrorCode, "您的会话已超时, 请重新登录本系统.");
            return mode;
        }
        /// <summary>
        /// 应用的名字
        /// </summary>
        public string AppName
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["AppName"]; }
        }
        /// <summary>
        /// 获取Session的过期时间
        /// </summary>
        public int Timeout
        {
            get
            {
                int time = 0;
                string timeout =  System.Configuration.ConfigurationManager.AppSettings["Timeout"];
                try
                {
                    time = int.Parse(timeout);
                }
                catch (Exception e)
                {
                    if (HttpContext.Current != null && HttpContext.Current.Session != null)
                        time = HttpContext.Current.Session.Timeout;
                }
                return time;
            }
        }
        public string GetSessionID()
        {
            if (HttpContext.Current != null && HttpContext.Current.Session != null)
            {
                if (this.Timeout != 0)
                    HttpContext.Current.Session.Timeout = this.Timeout;
                return HttpContext.Current.Session.SessionID;
            }
            return string.Empty;
        }
        public string GetCurrentSessionID()
        {
            string session = string.Empty;
            try
            {
                string sessionID = HttpContext.Current.Request.Cookies["ASP.NET_SessionId"].Value;
                if (!string.IsNullOrEmpty(sessionID))
                    session = string.Format("{0}.{1}", this.AppName, sessionID);
            }
            catch (Exception e){ }
            return session;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using SSJT.Crm.DBUtility;
using SSJT.Crm.Model;
using SSJT.Crm.Core;

namespace SSJT.Crm.Core.Client
{
    [AjaxClass]
    public class UserAuthentication
    {
        [AjaxMethod]
        [Description("用户登录")]
        public UserResult Login(string userID,string password)
        {
            UserResult result = null;
            string pwd = SafeHelper.EncryptDES(password, userID);
            bool isExist = SqlHelper.Exists<HrEmploy>(H => H.UserID == userID && H.PassWord == pwd);
            if(!isExist)
                throw new Exception("用户名或密码错误!");
            Core.Server.ISessionServer sessionServer = SessionFactory.GetSessionServer();
            sessionServer.RegSession(userID, password);
            HrEmploy userInfo = (DbFactory.DbSession.DbContext as CrmEntities).HrEmploy.FirstOrDefault(H => H.UserID == userID && H.PassWord == pwd);
            int timeOut = sessionServer.Timeout;
            DateTime expires = DateTime.Now;
            expires = expires.AddMinutes(timeOut);
            if (userInfo!=null)
            {
                result = new UserResult
                {
                    UserID = userInfo.UserID,
                    UserName = userInfo.UserName,
                    Expires = expires
                };
            }
            
            return result;
        }

        [AjaxMethod]
        [Description("获取当前用户的信息")]
        public UserResult GetCurrentUser()
        {
            UserResult result = null;
            Core.Server.ISessionServer sessionServer = SessionFactory.GetSessionServer();
            string sessionID = sessionServer.GetCurrentSessionID();
            if (string.IsNullOrEmpty(sessionID)) return null;
            Core.Server.SessionMode mode = sessionServer.GetSessionMode(sessionID);
            HrEmploy userInfo = mode.HrEmployee;
            //string sessionId = string.Format("{0}.{2}", this.AppName, this.GetSessionID());
            if (SqlHelper.Exists<HrEmploy>(H => H.UserID == userInfo.UserID))
            {
                int timeOut = sessionServer.Timeout;
                DateTime expires = DateTime.Now;
                expires = expires.AddMinutes(timeOut);
                result = new UserResult
                {
                    UserID = userInfo.UserID,
                    UserName = userInfo.UserName,
                    Expires = expires
                };
                return result;
            }
            return null;
        }
        [AjaxMethod]
        [Description("注销")]
        public void Logout()
        {
            Core.Server.ISessionServer sessionServer = SessionFactory.GetSessionServer();
            string sessionID = sessionServer.GetCurrentSessionID();
            sessionServer.RemoveSession(sessionID);
        }
    }
    
}

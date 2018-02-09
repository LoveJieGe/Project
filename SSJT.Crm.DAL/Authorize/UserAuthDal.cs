using System;
using System.Linq;
using SSJT.Crm.DBUtility;
using SSJT.Crm.Model;
using SSJT.Crm.Core.Exceptions;
using SSJT.Crm.IDAL;
using SSJT.Crm.Core.AjaxResponse;
using SSJT.Crm.Core;

namespace SSJT.Crm.DAL
{

    public class UserAuthDal: IUserAuthDal
    {
        public UserResult Login(string userID,string password)
        {
            UserResult result = null;
            string pwd = SafeHelper.EncryptDES(password, userID);
            bool isExist = SqlHelper.Exists<HrEmploy>(H => H.UserID == userID && H.PassWord == pwd);
            if(!isExist)
                throw AjaxException.ToException(ErrorCode.VErrorCode, "用户名或密码错误!");
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
                    id= userInfo.UserID,
                    User = userInfo.ToAjaxResult(),
                    Expires = expires
                };
            }
            
            return result;
        }

       
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
                    id = userInfo.UserID,
                    User = userInfo.ToAjaxResult(),
                    Expires = expires
                };
                return result;
            }
            return null;
        }
        
        public void Logout()
        {
            Core.Server.ISessionServer sessionServer = SessionFactory.GetSessionServer();
            string sessionID = sessionServer.GetCurrentSessionID();
            sessionServer.RemoveSession(sessionID);
        }
    }
    
}

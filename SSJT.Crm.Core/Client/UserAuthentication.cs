﻿using System;
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
            string pwd = SafeHelper.EncryptDES(password, userID);
            Model.CrmEntities entities = new CrmEntities();
            HrEmploy user = entities.HrEmployee.FirstOrDefault();
            bool isExist = SqlHelper.Exists<HrEmploy>(H => H.UserID == userID && H.PassWord == pwd);
            if(!isExist)
                throw new Exception("用户名或密码错误!");
            SessionFactory.GetSessionServer().RegSession(userID, password);
            return null;
        }

        [AjaxMethod]
        [Description("获取当前用户的信息")]
        public UserResult GetCurrentUser()
        {
            UserResult result = null;
            Core.Server.ISessionServer sessionServer = SessionFactory.GetSessionServer();
            string sessionID = sessionServer.GetCurrentSessionID();
            Core.Server.SessionMode mode = sessionServer.GetSessionMode(sessionID);
            HrEmploy userInfo = mode.HrEmployee;
            //string sessionId = string.Format("{0}.{2}", this.AppName, this.GetSessionID());
            if (SqlHelper.Exists<HrEmploy>(H => H.UserID == userInfo.UserID))
            {
                result = new UserResult
                {
                    UserID = userInfo.UserID,
                    UserName = userInfo.UserName
                };
                return result;
            }
            return null;
        }
    }
    
}

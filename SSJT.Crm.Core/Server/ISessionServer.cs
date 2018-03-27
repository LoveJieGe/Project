using SSJT.Crm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSJT.Crm.Core.Server
{
    public interface ISessionServer
    {
        void RegSession(string userID, string password);
        void RemoveCache(string sessionID);
        SessionMode GetSessionMode(string sessionID);
        string GetCurrentSessionID();
        int GetTimeout();
        void SetTimeOut(int time);
        HrEmploy CurrentUser { get; }
        /// <summary>
        /// 判断用户是否登录
        /// </summary>
        /// <returns>true代表已经登录</returns>
        bool HasLogin();
    }
}

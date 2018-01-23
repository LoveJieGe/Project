using SSJT.Crm.Core.Client;
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

namespace SSJT.Crm.Core
{
    [AjaxClass]
    public class UserAuthentication
    {
        public IDbSession DbSession { get;}
        public UserResult Login(string userid,string password)
        {
            bool isExist = SqlHelper.Exists<HrEmployee>(H => H.Uid == userid && SafeHelper.DecryptDES(H.Pwd, H.Uid) == password);
            if(!isExist)
                throw new Exception("用户名或密码错误!");
            SessionFactory.GetSessionServer().RegSession(userid, password);
            return null;
        }

        [AjaxMethod]
        [Description("获取当前用户的信息")]
        public UserResult GetCurrentUser()
        {
            Server.ISessionServer sessionServer = SessionFactory.GetSessionServer();
            //string sessionId = string.Format("{0}.{2}", this.AppName, this.GetSessionID());
            return null;
        }
    }
    
}

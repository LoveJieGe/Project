using SSJT.Crm.Core.AjaxResponse;
using SSJT.Crm.IBLL;
using SSJT.Crm.Core;
using System.ComponentModel;
using SSJT.Crm.IDAL;
using SSJT.Crm.DAL;

namespace SSJT.Crm.BLL
{
    public class UserAuthServer : IUserAuthServer
    {
        private IUserAuthDal instance;
        public IUserAuthDal Instance
        {
            get
            {
                if (instance == null)
                    instance = new UserAuthDal();
                return instance;
            }
        }
        public UserResult GetCurrentUser()
        {
            return this.Instance.GetCurrentUser();
        }
        public UserResult Login(string userID, string password)
        {
            return this.Instance.Login(userID,password);
        }

       
        public void Logout()
        {
            this.Instance.Logout();
        }
        public string  GetMessage()
        {
            return "测试";
        }
    }
}

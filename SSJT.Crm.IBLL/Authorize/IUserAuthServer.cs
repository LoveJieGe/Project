using SSJT.Crm.Core;
using System.ComponentModel;

namespace SSJT.Crm.IBLL
{
    [AjaxClass("SSJT.Crm.BLL.UserAuthServer,SSJT.Crm.BLL")]
    public interface IUserAuthServer
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userID">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        [AjaxMethod]
        [Description("获取当前用户的信息")]
        Core.AjaxResponse.UserResult Login(string userID, string password);
        /// <summary>
        /// 获取当前用户
        /// </summary>
        /// <returns></returns>
        [AjaxMethod]
        [Description("用户登录")]
        Core.AjaxResponse.UserResult GetCurrentUser();
        /// <summary>
        /// 用户退出
        /// </summary>
        [AjaxMethod]
        [Description("注销")]
        void Logout();

        string GetMessage();
    }
}

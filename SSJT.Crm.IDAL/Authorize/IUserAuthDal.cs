namespace SSJT.Crm.IDAL
{
    public interface IUserAuthDal
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userID">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        Core.AjaxResponse.UserResult Login(string userID, string password);
        /// <summary>
        /// 获取当前用户
        /// </summary>
        /// <returns></returns>
        Core.AjaxResponse.UserResult GetCurrentUser();
        /// <summary>
        /// 用户退出
        /// </summary>
        void Logout();
    }
}

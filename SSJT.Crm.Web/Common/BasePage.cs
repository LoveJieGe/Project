using System;
using Spring.Web.UI;
using SSJT.Crm.Model;

namespace SSJT.Crm.Web.Common
{
    public class BasePage:Page
    {
        protected virtual string JqueryVersion
        {
            get { return "1.7.2"; }
        }
        protected virtual bool UseSystemStyle
        {
            get { return true; }
        }
        protected override void OnPreInit(EventArgs e)
        {
            this.CheckSession();
            //设置主题
            try
            {
                if (this.UseSystemStyle)
                {
                     this.Page.Theme = "redmond";
                }
            }
            catch (Exception) { this.Page.Theme = "redmond"; }
            //SessionProvider.Active(UserType.User); 默认为用户类别，不需要处理
            base.OnPreInit(e);
        }
        public HrEmploy UserInfo
        {
            get;set;
        }
        protected virtual void CheckSession()
        {
            //Pushsoft.Framework.UserInformation user = null;
            //try
            //{
            //    user = CommonServices.Get<ISessionState>().User;
            //    Thread.CurrentThread.CurrentCulture = user.CultureInfo;
            //    Thread.CurrentThread.CurrentUICulture = user.CultureInfo;
            //}
            //catch (Exception)
            //{
            //    if (SessionFactory.LoginAgain())
            //        throw WarningException.Parse(R.G("5013618:您的用户已在别处登录，请检查。"));
            //    else
            //    {
            //        if (Helper.AreEqual(ConfigManager.RunState, "Design"))
            //        {
            //            SiteApplication.RegisterSession(ConfigManager.UserSign, ConfigManager.Password, string.Empty, ConfigManager.UserType, LoginState.Password);
            //            user = CommonServices.Get<ISessionState>().User;
            //        }
            //        else
            //            this.Response.Redirect(this.Page.ResolveUrl("~/Login.aspx?ReturnUrl=" + Helper.ToHex(this.Request.AppRelativeCurrentExecutionFilePath + this.Request.Url.Query)));
            //    }
            //}
            //if (user != null && !Helper.AreEqual(user.UserType, UserType.User) && !Helper.AreEqual(user.UserType, UserType.Proxy))
            //    throw WarningException.Parse("非系统内部用户, 不允许使用本页面 {0}.", this.Request.AppRelativeCurrentExecutionFilePath);
        }
    }
}
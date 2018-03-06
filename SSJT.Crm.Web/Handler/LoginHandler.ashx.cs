using SSJT.Crm.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using SSJT.Crm.IBLL;
using SSJT.Crm.Model;

namespace SSJT.Crm.Web.Data
{
    /// <summary>
    /// Login 的摘要说明
    /// </summary>
    public class LoginHandler : IHttpHandler, IRequiresSessionState
    {
        public IHrEmployeeService HrEmployeeService { get; set; }
        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            string action = context.Request["Action"];
            if (string.IsNullOrEmpty(action))
                return;
            if (Crm.Common.Helper.Equals("login", action))
            {
                LoginHandle(context);
            }
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="context"></param>
        private void LoginHandle(HttpContext context)
        {
            HttpRequest request = context.Request;
            string validateCodeString = context.Session["VCode"].ToString();
            string valudateInput = PageHelper.ValidateInputText(request["validateCode"]);
            if (!Crm.Common.Helper.Equals(valudateInput, validateCodeString))
            {
                context.Response.Write("no:验证码输入有误!");
                return;
            }
            string userName = request["userID"];
            string pwd = request["passWord"];
            HrEmploy entities = HrEmployeeService.LoadEntity(H => H.UserID == userName && H.PassWord == pwd);
            
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
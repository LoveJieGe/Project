using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace SSJT.Crm.Web
{
    /// <summary>
    /// ValidateCode 的摘要说明
    /// </summary>
    public class ValidateCode : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            Crm.Common.ValidateCode validate = new Crm.Common.ValidateCode();
            string validateCodeString = validate.GetRandomNumberString(4);
            context.Session["VCode"] = validateCodeString;
            validate.CreateImage(validateCodeString, context);
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
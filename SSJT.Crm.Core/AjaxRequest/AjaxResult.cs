using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SSJT.Crm.Core.AjaxRequest
{
    public class AjaxResult
    {
        public string ResponseText { get; set; }
        public string Result { get; set; }
        public AjaxMethod Method { get; set; }
        public string ErrorMsg { get; set; }
        public void FillResponseText()
        {
            if (string.IsNullOrEmpty(this.Result))
            {
                this.ResponseText = string.Format("{{\"ErrMsg\":{0}}}", Ajaxhelper.ToJson(this.ErrorMsg));
            }
            else
            {
                this.ResponseText = string.Format("{{\"Result\":{0},\"ErrMsg\":{1}}}",this.Result, Ajaxhelper.ToJson(this.ErrorMsg));
            }
        }
    }
}

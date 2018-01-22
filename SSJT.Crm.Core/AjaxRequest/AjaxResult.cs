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
        public object Result { get; set; }
        public AjaxMethod Method { get; set; }
        public string ErrorMsg { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SSJT.Crm.Core.AjaxRequest
{
    public class AjaxMethod
    {
        public Type DeclaringType { get; set; }
        public MethodInfo MethodInfo { get; set; }
        public Type ReturnType { get; set; }
        public string Description { get; set; }
        public string FullClassName { get; set; }
    }
}

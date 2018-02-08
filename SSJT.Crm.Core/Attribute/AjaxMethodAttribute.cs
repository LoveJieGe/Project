using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSJT.Crm.Core
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AjaxMethodAttribute:Attribute
    {
    }
}

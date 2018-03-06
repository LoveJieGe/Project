using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SSJT.Crm.Model
{
    public class Helper
    {
        public static bool IsDefined<T>(MemberInfo property) where T : Attribute
        {
            return ((property != null) && property.IsDefined(typeof(T), true));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSJT.Crm.Common
{
    public class Helper
    {
        public static bool Equals(string value1,string value2)
        {
            return string.Equals(value1, value2, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}

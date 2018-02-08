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

        #region 16进制转化
        public static string ToHex(object value)
        {
            StringBuilder builder = new StringBuilder();
            byte[] byteList = Encoding.Unicode.GetBytes(string.Format("{0}", value));
            foreach (byte b in byteList)
            {
                builder.Append(string.Format("{0:X2}", b));
            }
            return builder.ToString();
        }
        public static string FromHex(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                value = value.ToUpper();
                List<byte> arrayList = new List<byte>();
                for (int index = 0; index < value.Length - 1; index += 2)
                {
                    arrayList.Add(Convert.ToByte(ToInt(value[index]) * 16 + ToInt(value[index + 1])));
                }
                return Encoding.Unicode.GetString(arrayList.ToArray());
            }
            return value;
        }
        protected static int ToInt(char ch)
        {
            if (ch >= 'A') return ch - 'A' + 10;
            return ch - '0';
        }

        #endregion
    }
}

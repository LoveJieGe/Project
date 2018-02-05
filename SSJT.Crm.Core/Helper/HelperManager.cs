using SSJT.Crm.Core.Exceptions;
using System;
using System.Collections;

namespace SSJT.Crm.Core
{
    public class HelperManager
    {
        public static int GetEnumValue(ErrorCode enumName)
        {
            Type enumType = typeof(ErrorCode);
            if (!enumType.IsEnum)
                throw new ArgumentException("T必须是枚举类型");
            return (int)Enum.ToObject(enumType, enumName);

        }
        public static object GetEnumValue<T>(string enumName)
        {
            try
            {
                Type enumType = typeof(T);
                if (!enumType.IsEnum)
                    throw new ArgumentException("enumType必须是枚举类型");
                var values = Enum.GetValues(enumType);
                var ht = new Hashtable();
                foreach (var val in values)
                {
                    ht.Add(Enum.GetName(enumType, val), val);
                }
                return (object)ht[enumName];
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

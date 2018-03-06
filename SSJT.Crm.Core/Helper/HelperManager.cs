using Newtonsoft.Json.Linq;
using SSJT.Crm.Core.Exceptions;
using SSJT.Crm.Model;
using System;
using System.Collections;
using System.Reflection;

namespace SSJT.Crm.Core
{
    public class HelperManager
    {
        /// <summary>
        /// 获取错误代码中枚举的值
        /// </summary>
        /// <param name="enumName"></param>
        /// <returns></returns>
        public static int GetEnumValue(ErrorCode enumName)
        {
            Type enumType = typeof(ErrorCode);
            if (!enumType.IsEnum)
                throw new ArgumentException("T必须是枚举类型");
            return (int)Enum.ToObject(enumType, enumName);

        }
        /// <summary>
        /// 根据名字获取枚举的值
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="enumName">要获取的某个枚举的名字</param>
        /// <returns></returns>
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
        /// <summary>
        /// 根据类型获取类的实例
        /// </summary>
        /// <param name="type">可以是接口类型(带有AjaxClassAttribute标记)，或者是一个类的类型</param>
        /// <returns></returns>
        public static object GetInstance(Type type)
        {
            if (type == null)
                return null;
            if(type.IsInterface)
            {
                if(type.IsDefined(typeof(AjaxClassAttribute),true))
                {
                    object[] attrs = type.GetCustomAttributes(typeof(AjaxClassAttribute), true);
                    if(attrs.Length>0&& (attrs[0] is AjaxClassAttribute))
                    {
                        AjaxClassAttribute attribute = attrs[0] as AjaxClassAttribute;
                        Type classType = Type.GetType(attribute.DeclaringType);
                        if (classType != null)
                            return Activator.CreateInstance(classType);
                    }
                }
            }
            else if(type.IsClass)
            {
                return Activator.CreateInstance(type);
            }
            return null;
        }
        /// <summary>
        /// 根据类或借口的完全限定名称获取实例
        /// </summary>
        /// <param name="declaringType"></param>
        /// <returns></returns>
        public static object GetInstance(string declaringType)
        {
            Type type = Type.GetType(declaringType);
            return GetInstance(type);
        }

        public static bool SetFieldValue(BaseModel model, string field, JToken value)
        {
            object newValue = null;
            object oldValue = null;
            bool flag = false;
            if (model != null)
            {
                Type type = model.GetType();
                PropertyInfo prop = null;
                PropertyInfo prop2 = type.GetProperty(field, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
                if (prop2 != null && prop2.CanWrite)
                {
                    prop = prop2;
                    newValue = JsonHelper.JTokenToObejct(value, prop.PropertyType);
                    oldValue = prop.GetValue(model, null);
                    prop.SetValue(model, newValue, null);
                    flag = true;
                }
                else
                {
                    newValue = value.ToObject<string>();
                    oldValue = model[field];
                    model[field] = newValue;
                    flag = true;
                }
            }
            return flag;
        }
    }
}

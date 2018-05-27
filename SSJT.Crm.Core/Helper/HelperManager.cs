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
        /// <summary>
        /// 把一个模型中的值赋值到另一个模型中
        /// </summary>
        /// <param name="sourceModel">源模型</param>
        /// <param name="destModel">目标模型</param>
        /// <param name="sourceNames">要复制的源模型中的字段，如果为null则赋值所有的</param>
        /// <param name="destNames">目的模型中的字段</param>
        public static void CopyToModel(BaseModel sourceModel, BaseModel destModel, string[] sourceNames = null, string[] destNames = null)
        {
            if (sourceModel == null || destModel == null) return;
            Type sourceType = sourceModel.GetType();
            Type destType = destModel.GetType();
            if (sourceNames == null || destNames == null || sourceNames.Length <= 0 || destNames.Length <= 0)
            {
                PropertyInfo[] sourceInfos = sourceType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                foreach (PropertyInfo info in sourceInfos)
                {
                    string name = info.Name;
                    object value = info.GetValue(sourceModel);
                    PropertyInfo destInfo = destType.GetProperty(name);
                    if (destInfo != null)
                    {
                        destInfo.SetValue(destModel, value, null);
                    }
                }
            }
            else
            {
                if (sourceNames.Length == destNames.Length)
                {
                    for (int i = 0, len = sourceNames.Length; i < len; i++)
                    {
                        string sourceName = sourceNames[i],
                            destName = destNames[i];
                        PropertyInfo sourceInfo = sourceType.GetProperty(sourceName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                        PropertyInfo destInfo = destType.GetProperty(destName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                        if (sourceInfo != null && destInfo != null)
                        {
                            destModel[destName] = sourceModel[sourceName];
                        }
                    }
                }
            }
            
            
        }
    }
}

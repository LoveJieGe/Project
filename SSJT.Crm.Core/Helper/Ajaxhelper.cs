using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SSJT.Crm.Core.AjaxRequest;
using System.ComponentModel;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Converters;

namespace SSJT.Crm.Core
{
    public class Ajaxhelper
    {
        private static JsonConverter[] converters = new JsonConverter[1]
        {
            (JsonConverter) new IsoDateTimeConverter()
            {
                DateTimeFormat = "yyyy-MM-dd HH:mm:ss"
            }
        };
        /// <summary>
        /// 用指定类方法名，搜索其参数与指定参数类型及修饰符匹配的指定方法。
        /// </summary>
        /// <param name="type">类的全路径</param>
        /// <param name="methodNmae">方法名称</param>
        /// <param name="types">方法的参数类型数组，如参数是int[] a，String b，则填写new Type[]{typeof(int[]),typeof(string)},
        /// 空的 Type 对象数组，将获取不采用参数的方法</param>
        /// <returns></returns>
        public static MethodInfo GetMethodInfo(Type type,string methodNmae,Type[] types)
        {
            MethodInfo item = type.GetMethod(methodNmae, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase, null, types, null);
            if(item==null)
                throw new Exception(string.Format("类[{0}]中没有方法[{1}]的实现", type, methodNmae));
            return item;
        }
        /// <summary>
        /// 使用指定的类型和方法名称获取方法，如果有多个则获取第一个
        /// </summary>
        /// <param name="type">类的类型</param>
        /// <param name="methodNmae">方法名字</param>
        /// <returns></returns>
        public static MethodInfo GetMethodInfo(Type type, string methodNmae)
        {
            MethodInfo[] items = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            foreach (MethodInfo item in items)
            {
                if (item.Name.Equals(methodNmae, StringComparison.CurrentCultureIgnoreCase))
                    return item;
            }
            throw new Exception(string.Format("类[{0}]中没有方法[{1}]的实现",type,methodNmae));
        }
        /// <summary>
        /// 解析参数
        /// </summary>
        /// <param name="jsonStr"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static object[] ParseParams(string jsonStr, ParameterInfo[] parameters)
        {
            if (parameters != null && parameters.Length > 0)
            {
                JsonSerializerSettings settings = new JsonSerializerSettings();
                foreach (JsonConverter converter in Ajaxhelper.converters)
                    settings.Converters.Add(converter);
                JsonSerializer serializer = JsonSerializer.Create(settings);
                int index = 0;
                object[] obj = new object[parameters.Length];
                JsonReader reader = new JsonTextReader(new StringReader(jsonStr));
                if (reader.Read() && (reader.TokenType == JsonToken.StartObject))
                {
                    while (reader.Read() && reader.TokenType == JsonToken.PropertyName)
                    {
                        reader.Read();
                        obj[index] = serializer.Deserialize(reader, parameters[index].ParameterType);
                        index++;
                    }
                }
                return obj;
            }
            return null;
        }
        /// <summary>
        /// 把json对象类型转换成json字符串
        /// </summary>
        /// <param name="obj">要转换成json字符串的对象</param>
        /// <returns></returns>
        public static string ToJson(object obj)
        {
            //IsoDateTimeConverter timeConverter = new IsoDateTimeConverter();
            ////这里使用自定义日期格式，如果不使用的话，默认是ISO8601格式  
            //timeConverter.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            return JsonConvert.SerializeObject(obj, Formatting.None, converters);
        }
       

    }
}

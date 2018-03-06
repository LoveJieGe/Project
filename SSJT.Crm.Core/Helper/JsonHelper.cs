using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using SSJT.Crm.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSJT.Crm.Core
{
    public class JsonHelper
    {
        public static string ToJson(object obj, DateTimeMode dateFormat, params string[] fields)
        {
            JsonSerializerSettings setting = new JsonSerializerSettings();
            setting.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
           
            List<JsonConverter> converters = new List<JsonConverter>();
            if (dateFormat == DateTimeMode.ISO)
            {
                IsoDateTimeConverter converter = new IsoDateTimeConverter()
                {
                    DateTimeFormat = "yyyy-MM-dd'T'HH:mm:ss"
                };
                converters.Add(converter);
            }
            else if (dateFormat == DateTimeMode.JS)
            {
                converters.Add(new JavaScriptDateTimeConverter());
            }
            setting.Converters = converters;
            if (fields.Length > 0)
                setting.ContractResolver = new ExcludePropertiesContractResolver(fields);
            return JsonConvert.SerializeObject(obj, Formatting.None, setting);
        }
        public static object JTokenToObejct(JToken token, Type type)
        {
            bool flag = IsJTokenNull(token);
            if ((flag && type.IsValueType) && (Nullable.GetUnderlyingType(type) == null))
            {
                throw AjaxException.ToException("Null 无法转换为非空类型 " + type);
            }
            if (flag)
            {
                return null;
            }
            return typeof(JToken).GetMethod("ToObject", new Type[0]).MakeGenericMethod(new Type[] { type }).Invoke(token, null);
        }
        public static bool IsJTokenNull(JToken token)
        {
            return ((token == null) || (token.Type == JTokenType.Null));
        }
    }
    public enum DateTimeMode
    {
        ISO,
        JS
    }
    internal class ExcludePropertiesContractResolver : DefaultContractResolver
    {
        List<string> lstExclude;
        public ExcludePropertiesContractResolver(IEnumerable<string> excludedProperties)
        {
            lstExclude = new List<string>(excludedProperties);
        }
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            return new List<JsonProperty>(base.CreateProperties(type, memberSerialization)).FindAll(delegate (JsonProperty p)
            {
                return !lstExclude.Contains(p.PropertyName);
            });
        }
    }
}

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
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
                IsoDateTimeConverter converter = new IsoDateTimeConverter();
                converter.DateTimeFormat = "yyyy-MM-dd'T'HH:mm:ss";
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

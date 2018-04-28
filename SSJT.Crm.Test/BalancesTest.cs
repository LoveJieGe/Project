using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSJT.Crm.Test
{
    public class BalancesTest
    {
        public static void  Convert()
        {
            JsonSerializer serizer = new JsonSerializer();
            string jsonStr = "[{ \"Header\":\"\u57fa\u672c\u4fe1\u606f\",\"ColSpan\":2},{ \"Header\":\"\u671f\u521d\u4f59\u989d\",\"ColSpan\":2},{ \"Header\":\"\u672c\u671f\u53d1\u751f\",\"ColSpan\":2},{ \"Header\":\"\u671f\u672b\u4f59\u989d\",\"ColSpan\":2}]";
            JsonReader reader = new JsonTextReader(new StringReader(jsonStr));
            object value = serizer.Deserialize(reader, typeof(List<Query>));
        }
        
    }
    public class Query
    {
        public string Header { get; set; }
        public string ColSpan { get; set; }
    }
}

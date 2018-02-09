using Spring.Objects.Factory.Attributes;
using Spring.Stereotype;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SSJT.Crm.Test
{
    //[Component]
    public class Test
    {
        public static string Message { get; set; }
        public void  GetData()
        {
            string result = null;
            object data = CallContext.GetData("Data");
            object data2 = CallContext.LogicalGetData("Data2");
            object data3 = CallContext.LogicalGetData("Data");
            if (data != null) result = data.ToString();
            Console.WriteLine("方法线程：" + Thread.CurrentThread.ManagedThreadId + "，主线程+"+Thread.CurrentThread.IsBackground+"data："+ result
                              +"Data2:"+data2+"Data3:"+data3);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SSJT.Crm.Core.AjaxRequest
{
    public class AjaxReceive
    {
        private string className;
        private string methodName;
        private string data;
        private string version;
        private string nameSpace;
        public string ClassName { get; set; }
        public string MethodName { get; set; }
        public string Data { get; set; }
        public string Version { get; set; }
        public string NameSpace { get; set; }
        public void Fill(HttpContext context)
        {
            this.ClassName = context.Request["class"];
            this.MethodName = context.Request["method"];
            this.Data = context.Request["data"];
            this.Version = context.Request["version"];
        }
        public void Copy(AjaxReceive receive)
        {
            this.ClassName = receive.ClassName;
            this.MethodName = receive.MethodName;
            this.Data = receive.Data;
            this.Version = receive.Version;
        }
        public void Clear()
        {
            this.ClassName = string.Empty;
            this.MethodName = string.Empty;
            this.Data = string.Empty;
            this.Version = string.Empty;
        }
    }
}

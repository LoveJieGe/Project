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
        private string nameSpace="SSJT.Crm.Core";
        private string fullClassName;
        public string ClassName
        {
            get { return this.className; }
            set { this.className = value; }
        }
        public string MethodName
        {
            get { return this.methodName; }
            set { this.methodName = value; }
        }
        public string Data
        {
            get { return this.data; }
            set { this.data = value; }
        }
        public string Version
        {
            get { return this.version; }
            set { this.version = value; }
        }
        public string NameSpace
        {
            get { return this.nameSpace; }
            set { this.nameSpace = value; }
        }
        public string FullClassName
        {
            get { return this.NameSpace+"."+this.className;}
        }
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

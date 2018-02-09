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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nameSpace">所操作类的命名空间，默认是SSJT.Crm.BLL</param>
        /// <param name="assemblyName">要操作的类的程序集，默认是SSJT.Crm.BLL</param>
        public AjaxReceive(string nameSpace,string assemblyName)
        {
            this.nameSpace = nameSpace;
            this.assemblyName = assemblyName;
        }
        public AjaxReceive()
        {
        }
        private string className;
        private string methodName;
        private string data;
        private string version;
        private string nameSpace= "SSJT.Crm.IBLL";
        private string assemblyName = "SSJT.Crm.IBLL";
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
        internal string NameSpace
        {
            get { return this.nameSpace; }
            private set { this.nameSpace = value; }
        }
        internal string AssemblyName
        {
            get { return this.assemblyName; }
            private set { this.assemblyName = value; }
        }
        internal string FullClassName
        {
            get { return this.NameSpace+"."+this.ClassName + ","+this.AssemblyName;}
        }
        /// <summary>
        /// 使用客户端返回的数据填充当前对象
        /// </summary>
        /// <param name="context"></param>
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

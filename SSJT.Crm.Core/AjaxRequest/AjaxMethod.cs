using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SSJT.Crm.Core.AjaxRequest
{
    public class AjaxMethod
    {
        /// <summary>
        /// 请求的方法的类的类型
        /// </summary>
        public Type DeclaringType { get; set; }
        /// <summary>
        /// 方法的元数据访问参数
        /// </summary>
        public MethodInfo MethodInfo { get; set; }
        /// <summary>
        /// 方法的返回值类型
        /// </summary>
        public Type ReturnType { get; set; }
        /// <summary>
        /// 方法的描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 方法实现的名称，带命名空间和程序籍
        /// </summary>
        public string FullClassName { get; set; }
    }
}

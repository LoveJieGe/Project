using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSJT.Crm.Core
{
    [AttributeUsage(AttributeTargets.Interface, AllowMultiple = false)]
    public class AjaxClassAttribute:Attribute
    {
        /// <summary>
        /// 需要请求的Ajax类的标记
        /// </summary>
        /// <param name="declaringType">此接口的实现类的完全限定名称
        /// 详情请参阅<see cref="P:System.Type.AssemblyQualifiedName" />。 
        /// 如果该类型位于当前正在执行的程序集中或者 Mscorlib.dll 中，则提供由命名空间限定的类型名称就足够了。</param>
        public AjaxClassAttribute(string declaringType)
        {
            this.declaringType = declaringType;
        }
        private string declaringType;
        public string DeclaringType
        {
            get { return this.declaringType; }
            private set { this.declaringType = value; }
        }
    }
}

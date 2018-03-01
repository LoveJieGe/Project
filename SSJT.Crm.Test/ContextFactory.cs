using SSJT.Crm.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSJT.Crm.Test
{
    public class ContextFactory
    {
        private IHrEmployeeService _hrEmployeeService;
        public string Message { get; set; }
        /// <summary>
        /// Ajax操作
        /// </summary>
        public static IHrEmployeeService HrEmployService { get; private set; }
        public void Init()
        {
            ContextFactory.HrEmployService = this._hrEmployeeService;
        }
    }
}

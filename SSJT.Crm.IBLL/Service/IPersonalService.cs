using SSJT.Crm.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSJT.Crm.IBLL
{
    [AjaxClass("SSJT.Crm.BLL.PersonalService,SSJT.Crm.BLL")]
    public interface IPersonalService
    {
        /// <summary>
        /// 添加便签
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AjaxMethod]
        [Description("添加便签")]
        Model.PersonalNote InsertData(Model.PersonalNote model);
    }
}

using SSJT.Crm.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSJT.Crm.IBLL.Service
{
    [AjaxClass("SSJT.Crm.BLL.PersonalService,SSJT.Crm.BLL")]
    public interface IPersonalService
    {
        Model.PersonalNote InsertData(Model.PersonalNote model);
    }
}

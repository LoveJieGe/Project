using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSJT.Crm.Core.AjaxRequest;

namespace SSJT.Crm.Core.Server
{
    public interface IAjaxProcess
    {
        AjaxResult DoProcess(AjaxReceive receive);
    }
}

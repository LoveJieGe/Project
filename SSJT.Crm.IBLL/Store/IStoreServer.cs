using SSJT.Crm.Core.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSJT.Crm.Core;
using System.ComponentModel;

namespace SSJT.Crm.IBLL
{
    [AjaxClass("SSJT.Crm.BLL.StoreServer,SSJT.Crm.BLL")]
    public interface IStoreServer
    {
        [AjaxMethod]
        [Description("获取用户的信息")]
        StoreResult QueryPerson(StoreParams storeParams);
    }
}

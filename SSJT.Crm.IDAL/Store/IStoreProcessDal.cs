using SSJT.Crm.Core.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSJT.Crm.IDAL
{
    public interface IStoreProcessDal
    {
        StoreResult QueryPersons(StoreParams storeParams);
        StoreResult QueryPerson(string userID);
    }
}

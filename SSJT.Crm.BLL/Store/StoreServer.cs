using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSJT.Crm.Core;
using SSJT.Crm.Core.Store;
using SSJT.Crm.IDAL;
using SSJT.Crm.DAL;
using SSJT.Crm.IBLL;

namespace SSJT.Crm.BLL
{
    public class StoreServer: IStoreServer
    {
        public StoreResult QueryPersons(StoreParams storeParams)
        {
            IStoreProcessDal storeProcess = new StoreProcessDal();
            StoreResult result = storeProcess.QueryPersons(storeParams);
            return result;
        }

        public StoreResult QueryPerson(string userID)
        {
            IStoreProcessDal storeDal = new StoreProcessDal();
            //StoreResult result = storeProcess.QueryPerson(storeParams);
            return storeDal.QueryPerson(userID);
        }
    }
}

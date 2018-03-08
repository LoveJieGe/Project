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
using System.Data;
using Newtonsoft.Json.Linq;

namespace SSJT.Crm.BLL
{
    public class StoreServer: IStoreServer
    {
        private IStoreProcessDal storeDal = null;
        public IStoreProcessDal StoreDal
        {
            get {
                if (this.storeDal == null)
                    this.storeDal = new StoreProcessDal();
                return this.storeDal;
            }
        }
        public StoreResult QueryPersons(StoreParams storeParams)
        {
            StoreResult result = StoreDal.QueryPersons(storeParams);
            return result;
        }

        public StoreResult QueryPerson(string userID)
        {
            
            //StoreResult result = storeProcess.QueryPerson(storeParams);
            return StoreDal.QueryPerson(userID);
        }

        public DataTable UpdateEmployee(string userID,JObject values, string[] fieldNames)
        {
            return this.StoreDal.UpdateEmployee(userID, values, fieldNames);
        }

        public StoreResult QueryPersonNotes(StoreParams storeParams)
        {
            return this.StoreDal.QueryPersonNotes(storeParams);
        }
    }
}

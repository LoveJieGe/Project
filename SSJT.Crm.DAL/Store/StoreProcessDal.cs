using SSJT.Crm.Core.Store;
using SSJT.Crm.DBUtility;
using SSJT.Crm.IDAL;
using SSJT.Crm.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSJT.Crm.DAL
{
    public class StoreProcessDal: IStoreProcessDal
    {
        public StoreResult QueryPersons(StoreParams storeParams)
        {
            HrEmploy item = new HrEmployeeDal().LoadEntity(H => H.UserID == storeParams.query);
            if (item!=null)
            {
                StoreResult result = new StoreResult();
                result.root = item.ToAjaxResult();
                result.total = 1;
                return result;
            }
            return null;
        }
        public StoreResult QueryPerson(string userID)
        {
            HrEmploy item = new HrEmployeeDal().LoadEntity(H => H.UserID == userID);
            if(item!=null)
            {
                StoreResult result = new StoreResult();
                result.root = item.ToAjaxResult();
                result.total = 1;
                return result;
            }
            return null;
        }
    }
}

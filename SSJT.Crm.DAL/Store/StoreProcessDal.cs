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
            IEnumerable<HrEmploy> item = new HrEmployeeDal().LoadEntity(H => H.UserID == storeParams.query);
            if (item!=null&&item.Count() == 1)
            {
                StoreResult result = new StoreResult();
                result.root = item.First().ToAjaxResult();
                result.total = item.Count();
                return result;
            }
            return null;
        }
        public StoreResult QueryPerson(string userID)
        {
            IEnumerable<HrEmploy> item = new HrEmployeeDal().LoadEntity(H => H.UserID == userID);
            if(item!=null&&item.Count()>0)
            {
                StoreResult result = new StoreResult();
                result.root = item.First().ToAjaxResult();
                result.total = item.Count();
                return result;
            }
            return null;
        }
    }
}

using Newtonsoft.Json.Linq;
using SSJT.Crm.Core;
using SSJT.Crm.Core.Store;
using SSJT.Crm.DBUtility;
using SSJT.Crm.IDAL;
using SSJT.Crm.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSJT.Crm.DAL
{
    public class StoreProcessDal: IStoreProcessDal
    {
        private IHrEmployeeDal _employeeDal;
        public IHrEmployeeDal EmployeeDal
        {
            get {
                if (this._employeeDal == null)
                    this._employeeDal = new HrEmployeeDal();
                return this._employeeDal;
            }
        }
        public DbContext Context
        {
            get { return DbSessionFactory.GetDbSession().DbContext; }
        }
        public StoreResult QueryPersons(StoreParams storeParams)
        {
            HrEmploy item = EmployeeDal.LoadEntity(H => H.UserID == storeParams.query);
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
            HrEmploy item = EmployeeDal.LoadEntity(H => H.UserID == userID);
            if(item!=null)
            {
                StoreResult result = new StoreResult();
                result.root = item.ToAjaxResult();
                result.total = 1;
                return result;
            }
            return null;
        }

        public DataTable UpdateEmployee(string userID,JObject values, string[] fieldNames)
        {
            HrEmploy info = EmployeeDal.LoadEntity(H => H.UserID == userID);
            if (info != null)
            {
                foreach (JProperty jProp in values.Properties())
                {
                    string name = jProp.Name;
                    JToken value = jProp.Value;
                    if (name == "UserID")
                        continue;
                    if(!JsonHelper.IsJTokenNull(value))
                        HelperManager.SetFieldValue(info, name, value);
                }
                EmployeeDal.Update(info);
                Context.SaveChanges();
                return info.ToAjaxResult();
            }
            return null;
        }

        public StoreResult QueryPersonNotes(StoreParams storeParams)
        {
            IPersonalNoteDal noteDal = new PersonalNoteDal();
            Core.Server.ISessionServer sessionServer = SessionFactory.GetSessionServer();
            HrEmploy model = sessionServer.CurrentUser;
            IEnumerable<PersonalNote> notes = noteDal.LoadPageEntities(storeParams.page, storeParams.limit, out int total, false, p => p.CreateDate, p => p.CreatorId == model.UserID);
            if (notes.Count() > 0)
            {
                StoreResult result = new StoreResult()
                {
                    root = notes.ToList(),
                    total = total
                };
                return result;
            }
            return new StoreResult { total=0,root=""};
        }
    }
}

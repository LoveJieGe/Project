using Newtonsoft.Json.Linq;
using SSJT.Crm.Core.Store;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSJT.Crm.IDAL
{
    public interface IStoreProcessDal
    {
        StoreResult QueryPersons(StoreParams storeParams);
        StoreResult QueryPerson(string userID);
        /// <summary>
        /// 更新用户的信息
        /// </summary>
        /// <param name="values">用户信息的值</param>
        /// <param name="fieldNames">用户信息字段名称</param>
        /// <returns></returns>
        DataTable UpdateEmployee(string userID,JObject values, string[] fieldNames);
        /// <summary>
        /// 获取便签
        /// </summary>
        /// <param name="storeParams"></param>
        /// <returns></returns>
        StoreResult QueryPersonNotes(StoreParams storeParams);
    }
}

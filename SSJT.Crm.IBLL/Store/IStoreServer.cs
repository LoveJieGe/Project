using SSJT.Crm.Core.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSJT.Crm.Core;
using System.ComponentModel;
using System.Data;
using Newtonsoft.Json.Linq;

namespace SSJT.Crm.IBLL
{
    [AjaxClass("SSJT.Crm.BLL.StoreServer,SSJT.Crm.BLL")]
    public interface IStoreServer
    {
        [AjaxMethod]
        [Description("获取用户的信息")]
        StoreResult QueryPersons(StoreParams storeParams);
        /// <summary>
        /// 根据用户名获取用户信息
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        [AjaxMethod]
        [Description("获取用户的信息")]
        StoreResult QueryPerson(string userID);
        /// <summary>
        /// 更新用户的信息
        /// </summary>
        /// <param name="values">用户信息的值</param>
        /// <param name="fieldNames">用户信息的字段名称</param>
        /// <returns></returns>
        [AjaxMethod]
        [Description("更新用户的信息")]
        DataTable UpdateEmployee(string userID,JObject values, string[] fieldNames);
        /// <summary>
        /// 获取便签
        /// </summary>
        /// <param name="storeParams"></param>
        /// <returns></returns>
        [AjaxMethod]
        [Description("获取用户便签")]
        StoreResult QueryPersonNotes(StoreParams storeParams);

        [AjaxMethod]
        [Description("导出功能")]
        void OnExport(object[] list);
    }
}

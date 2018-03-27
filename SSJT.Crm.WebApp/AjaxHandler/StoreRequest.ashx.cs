using Newtonsoft.Json;
using SSJT.Crm.Core.AjaxRequest;
using SSJT.Crm.Core.Store;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace SSJT.Crm.WebApp.AjaxHandler
{
    /// <summary>
    /// StoreRequest 的摘要说明
    /// </summary>
    public class StoreRequest : BaseRequest
    {

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            AjaxReceive receive = new AjaxReceive();
            receive.Fill(context);
            NameValueCollection cc = context.Request.Form;
            StoreParams storeParams = new StoreParams();
            if (!string.IsNullOrEmpty(cc["page"]))
                storeParams.page = int.Parse(cc["page"]);
            if (!string.IsNullOrEmpty(cc["start"]))
                storeParams.start = int.Parse(cc["start"]);
            if (!string.IsNullOrEmpty(cc["limit"]))
                storeParams.limit = int.Parse(cc["limit"]);
            if (!string.IsNullOrEmpty(cc["query"]))
                storeParams.query = cc["query"];
            if (!string.IsNullOrEmpty(cc["group"]))
            {
                GroupParam grouper = JsonConvert.DeserializeObject<GroupParam>(cc["group"]);
                if (grouper != null)
                    storeParams.group = new List<GroupParam>(new GroupParam[] { grouper });
            }
            if (!string.IsNullOrEmpty(cc["sort"]))
                storeParams.sort = JsonConvert.DeserializeObject<List<SortParam>>(cc["sort"]);
            if (!string.IsNullOrEmpty(cc["filter"]))
                storeParams.filter = JsonConvert.DeserializeObject<List<FilterParam>>(cc["filter"]);
            if (string.IsNullOrEmpty(receive.Data))
            {
                receive.Data = JsonConvert.SerializeObject(new
                {
                    StoreParams = storeParams
                });
            }
            else if (receive.Data.StartsWith("{") && receive.Data.EndsWith("}"))
            {
                string restJsonStr = receive.Data.Substring(1);
                if (restJsonStr != "}") restJsonStr = "," + restJsonStr;

                receive.Data = string.Format("{{\"StoreParams\":{0}{1}", JsonConvert.SerializeObject(storeParams), restJsonStr);
            }
            AjaxResult result = ContextFactory.AjaxProcess.DoProcess(receive);
            if (result.IsSuccess)
            {
                context.Response.ContentType = "application/json";
                context.Response.Write(Core.JsonHelper.ToJson(result.Data, Core.DateTimeMode.JS));
            }
            else
            {
                ErrorResponse(context, result);
            }
        }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSJT.Crm.WebApp.AngularJs
{
    /// <summary>
    /// Sites 的摘要说明
    /// </summary>
    public class Sites : BaseCORSHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string result = JsonConvert.SerializeObject(new ArrayList() {
                new
                {
                    Name = "菜鸟教程",
                    Url="www.runoob.com",
                    Country="CN"
                },
                new
                {
                    Name="Google",
                    Url="www.google.com",
                    Country="USA"
                },
                new
                {
                    Name="微博",
                    Url="www.weibo.com",
                    Country="CN"
                }
            });
            context.Response.ContentType = "text/plain";
            context.Response.Write(result);
        }

    }
}
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SSJT.Crm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace SSJT.Crm.WebApp.AjaxHandler
{
    /// <summary>
    /// WeatherHandler 的摘要说明
    /// </summary>
    public class WeatherHandler : BaseRequest
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string city = context.Request["city"];
            if (!string.IsNullOrEmpty(city))
            {
                try
                {
                    cn.com.webxml.www.WeatherWebService w = new cn.com.webxml.www.WeatherWebService();
                    string[] result = w.getWeatherbyCityName(city);
                    WeatherInfo info = FillData(result);
                    context.Response.ContentType = "application/json";
                    context.Response.Write(Core.JsonHelper.ToJson(info, Core.DateTimeMode.JS));
                }
                catch (Exception e)
                {
                    string msg = e.Message;
                    while (e != null)
                    {
                        msg = e.Message;
                        e = e.InnerException;
                    }
                    ErrorResponse(context, 400, msg);
                }
                
            }
            //string city = GetCity(GetIP(context));
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
        }
        #region 根据ip地址获取城市名称
        public static bool HasChinese(string str)
        {
            return Regex.IsMatch(str, @"[\u4e00-\u9fa5]");
        }
        private static string GetIP(HttpContext context)
        {
            string ip = string.Empty;
            if (!string.IsNullOrEmpty(context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]))
                ip = Convert.ToString(context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].Split(',')[0]);
            if (string.IsNullOrEmpty(ip))
                ip = Convert.ToString(System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]);
            if (string.IsNullOrEmpty(ip))
                ip = context.Request.UserHostAddress;
            return ip;
        }

        public static string GetCity(string ip)
        {
            try
            {
                string cs = "";
                string url = "http://api.map.baidu.com/location/ip?ak=LgCyrxYu71mpCNsHawuXIhLAvGpfcTUp&ip=" + ip;
                WebClient client = new WebClient();
                var buffer = client.DownloadData(url);
                string jsonText = Encoding.UTF8.GetString(buffer);
                JObject jo = JObject.Parse(jsonText);
                var txt = jo["content"]["address_detail"]["city"];
                JToken st = txt;
                string str = st.ToString();
                if (str == "")
                {
                    cs = GetCS(ip);
                    return cs;

                }
                int s = str.IndexOf('市');
                string css = str.Substring(0, s);
                bool bl = HasChinese(css);

                if (bl)
                {
                    cs = css;
                }
                else
                {
                    cs = GetCS(ip);
                }

                return cs;
            }
            catch
            {
                return GetIPCitys(ip);
            }

        }
        /// <summary>
        /// 新浪api
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static string GetCS(string ip)
        {
            try
            {
                string url = "http://int.dpool.sina.com.cn/iplookup/iplookup.php?ip=" + ip;
                WebClient MyWebClient = new WebClient();
                MyWebClient.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据
                Byte[] pageData = MyWebClient.DownloadData(url); //从指定网站下载数据
                string stt = Encoding.GetEncoding("GBK").GetString(pageData).Trim();
                return stt.Substring(stt.Length - 2, 2);
            }
            catch
            {
                return "未知";
            }

        }
        // <summary>
        /// 淘宝api
        /// </summary>
        /// <param name="strIP"></param>
        /// <returns></returns>
        public static string GetIPCitys(string strIP)
        {
            try
            {
                string Url = "http://ip.taobao.com/service/getIpInfo.php?ip=" + strIP + "";

                System.Net.WebRequest wReq = System.Net.WebRequest.Create(Url);
                wReq.Timeout = 2000;
                System.Net.WebResponse wResp = wReq.GetResponse();
                System.IO.Stream respStream = wResp.GetResponseStream();
                using (System.IO.StreamReader reader = new System.IO.StreamReader(respStream))
                {
                    string jsonText = reader.ReadToEnd();
                    JObject ja = (JObject)JsonConvert.DeserializeObject(jsonText);
                    if (ja["code"].ToString() == "0")
                    {
                        string c = ja["data"]["city"].ToString();
                        int ci = c.IndexOf('市');
                        if (ci != -1)
                        {
                            c = c.Remove(ci, 1);
                        }
                        return c;
                    }
                    else
                    {
                        return "未知";
                    }
                }
            }
            catch (Exception)
            {
                return ("未知");
            }
        }
        #endregion
        public WeatherInfo FillData(string[] result)
        {
            WeatherInfo info = null;
            if (result != null && result.Length > 0)
            {
                info = new WeatherInfo();
                info.Province = result[0];
                info.City = result[1];
                info.CityCode = result[2];
                info.CityImage = result[3];
                info.LastModifyDate = string.IsNullOrEmpty(result[4])?DateTime.Now:Convert.ToDateTime(result[4]);
                info.TempC1 = result[5];
                info.WeatherDesc1 = result[6].Split(' ')[1];
                info.Wind1 = result[7];
                info.ImageFrom1 = result[8];
                info.ImageTo1 = result[9];
                info.WeatherLive = result[10];
                info.WeatherIndex = result[11];
                //第二天信息
                info.TempC2 = result[12];
                info.WeatherDesc2 = result[13].Split(' ')[1];
                info.Wind2 = result[14];
                info.ImageFrom2 = result[15];
                info.ImageTo2 = result[16];
                //第三天
                info.TempC3 = result[17];
                info.WeatherDesc3 = result[18].Split(' ')[1];
                info.Wind3 = result[19];
                info.ImageFrom3 = result[20];
                info.ImageTo3 = result[21];
                info.CityDesc = result[22];
            }
            return info;
        }
    }
}
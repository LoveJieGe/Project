using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            string city = GetCity(GetIP(context));
            cn.com.webxml.www.WeatherWebService w = new cn.com.webxml.www.WeatherWebService();
            string[] result = w.getWeatherbyCityName(city);
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
        }
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
    }
}
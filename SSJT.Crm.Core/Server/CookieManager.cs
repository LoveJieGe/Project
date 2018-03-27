using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SSJT.Crm.Core.Server
{
    internal class CookieManager
    {
        private static HttpResponse Response
        {
            get
            {
                return HttpContext.Current.Response;
            }
        }

        private static HttpRequest Request
        {
            get
            {
                return HttpContext.Current.Request;
            }
        }
        //定义一个Cookie集合
        private static HttpCookie Cookie
        {
            get
            {
                return Request.Cookies["SSJT.Crm.Cookie"] as HttpCookie;
            }
            set
            {
                if (Request.Cookies["SSJT.Crm.Cookie"] != null)
                {
                    Request.Cookies.Remove("SSJT.Crm.Cookie");
                }
                Response.Cookies.Add(value);
            }
        }
        //New Cookie集合
        private static HttpCookie NewCookie
        {
            get
            {
                HttpCookie httpCookie = new HttpCookie("SSJT.Crm.Cookie");
                return httpCookie;
            }
        }
        public static void SetTimeout(int time)
        {
            HttpCookie httpCookie = Cookie ?? NewCookie;
            httpCookie.Expires.AddMinutes(time);
        }
        //Remove Cookie集合
        public static void RemoveCookie()
        {
            if (Cookie == null)
                Response.Cookies.Remove("SSJT.Crm.Cookie");
            else
                Response.Cookies["SSJT.Crm.Cookie"].Expires = DateTime.Now.AddDays(-1);
        }

        //创建一个Cookie，判断用户登录状态
        public static bool LoginOk
        {
            get
            {
                return Cookie == null ? false : bool.Parse(Cookie.Values["LoginOk"]);
            }
            set
            {
                if (Cookie == null)
                    Cookie = NewCookie;
                HttpCookie httpCookie = Cookie ;
                if (ServerConfig.Timeout.HasValue)
                {
                    httpCookie.Expires.AddMinutes(ServerConfig.Timeout.Value);
                }
                httpCookie.Values["LoginOk"] = value.ToString();
            }
        }

        //创建登录用户的帐号,整站使用
        public static string UserID
        {
            get
            {
                return Cookie == null ? string.Empty : Cookie.Values["UserID"];
            }
            set
            {
                if(Cookie==null)
                    Cookie = NewCookie;
                HttpCookie httpCookie = Cookie ;
                if (ServerConfig.Timeout.HasValue)
                {
                    httpCookie.Expires.AddMinutes(ServerConfig.Timeout.Value);
                }
                httpCookie.Values["UserID"] = value;
            }
        }

    }
}

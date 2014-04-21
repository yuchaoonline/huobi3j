using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using ADeeWu.HuoBi3J.Libary;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace ADeeWu.HuoBi3J.Web.Class
{
    public class AccountHelper
    {
        #region Location
        public static string City
        {
            get
            {
                return "";// LocationSession["city"];
            }
        }

        public static string Province
        {
            get
            {
                return "";// LocationSession.Keys.Contains("province") ? LocationSession["province"] : "";
            }
        }

        public static Dictionary<string, string> LocationSession
        {
            get
            {
                var location = new Dictionary<string, string>();
                var locationCookie = HttpContext.Current.Request.Cookies["location"];
                if (locationCookie == null)
                {
                    location = new BaiduAPIHelper().GetLocationByIP(HttpContext.Current.Request.UserHostAddress);

                    //TODO 固定城市
                    location["city"] = "佛山市";
                    location["province"] = "广东省";

                    locationCookie = new HttpCookie("location");
                    locationCookie.Value = JsonConvert.SerializeObject(new { city = HttpUtility.UrlEncode(location["city"]), province = HttpUtility.UrlEncode(location["province"]) });
                    locationCookie.Expires = DateTime.Now.AddDays(7);
                    HttpContext.Current.Response.Cookies.Add(locationCookie);
                    return location;
                }

                var locationObj = JObject.Parse(locationCookie.Value);
                location.Add("city", HttpUtility.UrlDecode(locationObj["city"].ToString()));
                if (locationObj["province"] != null)
                    location.Add("province", HttpUtility.UrlDecode(locationObj["province"].ToString()));

                return location;
            }
        }
        #endregion
    }
}

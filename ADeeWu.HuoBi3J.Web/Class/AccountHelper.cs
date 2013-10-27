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

namespace ADeeWu.HuoBi3J.Web.Class
{
    public class AccountHelper
    {
        #region Location
        public static string City
        {
            get
            {
                return LocationSession["city"];
            }
        }

        public static string Province
        {
            get
            {
                return LocationSession["province"];
            }
        }

        public static Dictionary<string, string> LocationSession
        {
            get
            {
                var locationSession = HttpContext.Current.Session["location"];
                if (locationSession == null)
                {
                    var city = new BaiduAPIHelper().GetLocationByIP();
                    HttpContext.Current.Session["location"] = city;
                    return city;
                }

                return locationSession as Dictionary<string, string>;
            }
        }

        public static void ChangeLocation(string cityname, string provinename = "")
        {
            var sessionDic = new Dictionary<string, string>();
            sessionDic["city"] = cityname;
            sessionDic["province"] = provinename;

            HttpContext.Current.Session["location"] = sessionDic;
        } 
        #endregion
    }
}

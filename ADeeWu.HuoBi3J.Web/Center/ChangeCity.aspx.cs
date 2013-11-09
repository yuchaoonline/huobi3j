using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Web.Class;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web.Center
{
    public partial class ChangeCity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var cname = WebUtility.GetRequestStr("city", "佛山市");
                var location = DataBase.Create().Select("vw_location", "city='" + cname + "'", "");
                if (location.Rows.Count > 0)
                {
                    var locationCookie = new HttpCookie("location");
                    locationCookie.Value = JsonConvert.SerializeObject(new { city = HttpUtility.UrlEncode(location.Rows[0]["city"].ToString()), province = HttpUtility.UrlEncode(location.Rows[0]["province"].ToString()) });
                    locationCookie.Expires = DateTime.Now.AddDays(7);
                    Response.Cookies.Add(locationCookie);
                    WebUtility.ShowMsg(this, "切换成功！", "/");
                    return;
                }


                Response.Redirect("/");
            }
        }
    }
}
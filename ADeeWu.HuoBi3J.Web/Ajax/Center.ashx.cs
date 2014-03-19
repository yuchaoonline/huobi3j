using System;
using System.Collections.Generic;
using System.Web;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using System.Data;
using System.Web.SessionState;
using ADeeWu.HuoBi3J.Web.Class;
using ADeeWu.HuoBi3J.DAL;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace ADeeWu.HuoBi3J.Web.Ajax
{
    /// <summary>
    /// Center 的摘要说明
    /// </summary>
    public class Center : IHttpHandler, IRequiresSessionState, IReadOnlySessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            var method = WebUtility.GetRequestStr("method", "");
            var result = "";
            try
            {
                switch (method.ToLower())
                {
                    case "addkey": { result = AddKey(); }; break;
                    case "addbusinesscircle": { result = AddBusinessCircle(); }; break;
                    case "getlocationpoint": { result = GetLocationPoint(); }; break;
                    case "addfav": { result = AddFav(); }; break;
                    default: { result = "something is error!"; }; break;
                }
            }
            catch (Exception e)
            {
                result = JsonConvert.SerializeObject(new { statue = false, msg = e.Message });
            }

            context.Response.ContentType = "text/plain";
            context.Response.Write(result);
        }

        private string AddFav()
        {
            var uid = UserSession.GetSession() == null ? 0 : UserSession.GetSession().UserID;
            if (uid <= 0) return JsonConvert.SerializeObject(new { statue = false, msg = "请登录再收藏！" });

            var userid = WebUtility.GetRequestInt("userid", 0);
            var fav = new Model.Common_Favourite
            {
                CreateDate = DateTime.Now,
                DataID = userid,
                DataType = "center_saleman",
                Memo = "",
                UserID = (int)uid,
            };
            if (new DAL.Common_Favourite().Add(fav) > 0)
            {
                return JsonConvert.SerializeObject(new { statue = true });
            }

            return JsonConvert.SerializeObject(new { statue = false, msg = "收藏失败，请重试！" });
        }

        private string GetLocationPoint()
        {
            var address = WebUtility.GetRequestStr("address", "");

            if (string.IsNullOrWhiteSpace(address))
            {
                return JsonConvert.SerializeObject(new { statue = false, msg = "参数有误" });
            }

            return new BaiduAPIHelper().GetLocationPoint(address, AccountHelper.City);
        }

        private string AddKey()
        {
            var name = WebUtility.GetRequestStr("name", "");
            if (string.IsNullOrWhiteSpace(name)) return "";

            DAL.Key keyDAL = new DAL.Key();

            if (keyDAL.Exist(string.Format(" name='{0}'", name)))
            {
                return JsonConvert.SerializeObject(new { statue = false, msg = "关键字已存在！" });
            }

            var key = new Model.Key
            {
                CreateTime = DateTime.Now,
                Name = name,
                IsDefault =false,
            };
            var keyid = keyDAL.Add(key);
            if (keyid > 0)
            {
                return JsonConvert.SerializeObject(new { statue = true });
            }
            else
            {
                return JsonConvert.SerializeObject(new { statue = false });
            }
        }

        private string AddBusinessCircle()
        {
            var lng = WebUtility.GetRequestFloat("lng", -1);
            var lat = WebUtility.GetRequestFloat("lat", -1);
            var name = WebUtility.GetRequestStr("name", "");

            if (lng == -1 || lat == -1) return "";

            DAL.Key_BusinessCircle businessCircleDAL = new DAL.Key_BusinessCircle();

            if (businessCircleDAL.Exist(string.Format("bname='{0}' and lng={1} and lat={2}", name, lng, lat)))
            {
                return JsonConvert.SerializeObject(new { statue = false, msg = "商圈已存在！" });
            }

            var key = new Model.Key_BusinessCircle
            {
                CreateTime = DateTime.Now,
                Lng = lng,
                Lat = lat,
                BName = name,
            };
            var bid = businessCircleDAL.Add(key);
            if (bid > 0)
            {
                return JsonConvert.SerializeObject(new { statue = true, bid = bid });
            }
            else
            {
                return JsonConvert.SerializeObject(new { statue = false });
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
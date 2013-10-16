using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using LitJson;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ADeeWu.HuoBi3J.Web.Ajax
{
    /// <summary>
    /// GroupBuy 的摘要说明
    /// </summary>
    public class GroupBuy : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var method = WebUtility.GetRequestStr("method", "");
            var result = "";
            switch (method.ToLower())
            {
                case "getcity": { result = GetCity(); }; break;
            }

            context.Response.ContentType = "text/plain";
            context.Response.Write(result);
        }

        private string GetCity()
        {
            var citys = new List<object>();

            var db = DataBase.Create();
            var dtCitys = db.Select("select cid,cname from vw_GroupBuy_Product group by cname,cid");
            if (dtCitys != null && dtCitys.Rows.Count > 0)
            {
                foreach (DataRow item in dtCitys.Rows)
                {
                    citys.Add(new {id=item["cid"],name=item["cname"]});
                }
            }

            return JsonMapper.ToJson(citys);
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
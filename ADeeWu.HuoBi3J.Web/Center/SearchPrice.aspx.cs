using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using System.Data;
using ADeeWu.HuoBi3J.Web.Class;
using System.Linq;
using Newtonsoft.Json;

namespace ADeeWu.HuoBi3J.Web.Center
{
    public partial class SearchPrice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strKeyword = WebUtility.GetRequestStr("keyword", "");
                if (string.IsNullOrWhiteSpace(strKeyword)) return;
                Search(strKeyword);
            }
        }

        private void Search(string Keyword)
        {
            //var pageIndex = WebUtility.GetRequestLong("page", 1);
            //var pageSize = Utility.GetLong(Request["pagesize"], 20, 5, 40);

            //var db = DataBase.Create();
            //db.EnableRecordCount = true;
            //db.Parameters.Append("pname", AccountHelper.Province);
            //db.Parameters.Append("cname", AccountHelper.City);
            //var products = db.Select(pageSize, pageIndex, "vw_Key_Product", "ID", string.Format("cname=@cname and pname=@pname and kname like '%{0}%'", Keyword), "price asc");
            //rpResult.DataSource = products;
            //rpResult.DataBind();

            //this.Pager1.AppendUrlParam("keyword", Keyword);
            //this.Pager1.PageSize = (int)pageSize;
            //this.Pager1.PageIndex = (int)pageIndex;
            //this.Pager1.TotalRecords = (int)db.RecordCount;

            //var datas = new List<product>();
            //foreach (DataRow product in products.Rows)
            //{
            //    datas.Add(new product
            //    {
            //        id = product["id"].ToString(),
            //        companyname = product["companyname"].ToString(),
            //        pointX = product["positionX"].ToString(),
            //        pointY = product["positionY"].ToString(),
            //        price = GetMoney(product["price"]),
            //        simpledesc = product["simpledesc"].ToString()
            //    });
            //}

            //hfData.Value = JsonConvert.SerializeObject(datas.GroupBy(p => p.point).Select(p => new { pointX = p.Key.Split(',').FirstOrDefault(), pointY = p.Key.Split(',').LastOrDefault(), data = p.Select(p1 => p1) }));
        }

        class product
        {
            public string id { get; set; }
            public string companyname { get; set; }
            public string price { get; set; }
            public string pointX { get; set; }
            public string pointY { get; set; }
            public string simpledesc { get; set; }
            public string point
            {
                get
                {
                    return pointX + "," + pointY;
                }
            }
        }

        public string GetMoney(object mon)
        {
            return Utility.GetDecimal(mon, 0).ToString("F2");
        }
    }
}
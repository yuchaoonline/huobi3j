using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web.GroupBuy
{
    public partial class Default : System.Web.UI.Page
    {
        KeyValuePair<string, string> currentCity = new KeyValuePair<string, string>("205", "佛山市");
        DataBase db = DataBase.Create();
        DAL.Areas areaDAL = new DAL.Areas();
        string category = "";
        int selectaid = 0;
        string keyword = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                BindData();
            }
        }

        private void BindData()
        {
            category = WebUtility.GetRequestStr("category", "");
            selectaid = WebUtility.GetRequestInt("aid", 0);
            var sort = WebUtility.GetRequestStr("sort", "passdate");
            keyword = WebUtility.GetRequestStr("keyword", "");

            var search = "";
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                search = string.Format("and (title like '%{0}%' or hotplace like '%{0}%')", keyword);
                txtSearch.Text = keyword;
            }

            var cityCookie = Request.Cookies["city"];
            if (cityCookie!=null && !string.IsNullOrWhiteSpace(cityCookie.Value))
            {
                var city = cityCookie.Value.Split(new char[] { ',' });
                currentCity = new KeyValuePair<string, string>(city.FirstOrDefault(), city.LastOrDefault());
            }
            var aid = WebUtility.GetRequestInt("area", -1);

            var pageIndex = WebUtility.GetRequestLong("page", 1);
            var pageSize = Utility.GetLong(Request["pagesize"], 20, 5, 40);

            var areaInCity = areaDAL.GetEntityList("",new string[]{"cid"},new string[]{currentCity.Key});
            var strAreaIDInCity = string.Join(",", areaInCity.Select(p => p.ID));

            var sql = string.Format("SELECT Category AS name, COUNT(*) AS categorycount FROM vw_GroupBuy_Product_Selling where aid in ({0}) {1} GROUP BY Category", strAreaIDInCity, search);
            var categorys = db.Select(sql);
            rpCategory.DataSource = categorys;
            rpCategory.DataBind();

            var areas = db.Select(string.Format("SELECT ID, Name, CID, Sort,(SELECT COUNT(*) FROM dbo.vw_GroupBuy_Product_Selling WHERE (aid = a.ID {1})) AS AreaCount FROM dbo.Areas AS a where id in ({0})", strAreaIDInCity, search));
            rpArea.DataSource = areas;
            rpArea.DataBind();

            var strProductWhere = "1 = 1" + search;
            var strOrder = "";
            if (selectaid != 0)
            {
                strAreaIDInCity = selectaid.ToString();
            }
            if (!string.IsNullOrWhiteSpace(strAreaIDInCity))
            {
                strProductWhere += string.Format("and aid in ({0})", strAreaIDInCity);
                this.Pager1.AppendUrlParam("aid", strAreaIDInCity);
            }
            if (!string.IsNullOrWhiteSpace(category))
            {
                strProductWhere += string.Format("and Category = '{0}'", category);
                this.Pager1.AppendUrlParam("category", category);
            }
            if (!string.IsNullOrWhiteSpace(sort))
            {
                strOrder = sort + " desc";
                this.Pager1.AppendUrlParam("sort", sort);
            }

            db.AutoClearParameters = true;
            db.EnableRecordCount = true;
            var products = db.Select(pageSize, pageIndex, "vw_GroupBuy_Product_Selling", "id", strProductWhere, strOrder);
            var newProducts = new List<DataRow>();
            foreach (DataRow item in products.Rows)
            {
                var saleday = Utility.GetInt(item["saleday"], 0);
                var passDate = Utility.GetDateTime(item["passdate"], DateTime.Now);
                if (passDate.HasValue && passDate.Value.AddDays(saleday) > DateTime.Now)
                {
                    newProducts.Add(item);
                }
            }
            rpProducts.DataSource = products;
            rpProducts.DataBind();

            this.Pager1.AppendUrlParam("keyword", keyword);

            this.Pager1.PageSize = (int)pageSize;
            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.TotalRecords = (int)db.RecordCount;
        }

        public List<string> GetPhoto(object photo)
        {
            return new List<string>{
                photo.ToString()
            };
        }

        public string GetDecimal(object obj, int length)
        {
            return decimal.Round(ADeeWu.HuoBi3J.Libary.Utility.GetDecimal(obj, 0), length).ToString();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                Response.Redirect("default.aspx?keyword=" + txtSearch.Text);
        }

        public string getUrl(string sort)
        {
            return string.Format("default.aspx?{0}{1}{2}{3}",
                string.IsNullOrWhiteSpace(keyword)?"":"&keyword="+keyword, 
                selectaid > 0 ? "&aid=" + selectaid : "", 
                string.IsNullOrWhiteSpace(category) ? "" : "&category=" + category, 
                string.IsNullOrWhiteSpace(sort) ? "" : "&sort=" + sort);
        }
    }
}
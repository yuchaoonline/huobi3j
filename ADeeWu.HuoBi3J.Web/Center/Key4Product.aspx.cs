using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Web.Class;
using System.Data;
using System.Linq;
using ADee.Project.LBS.BLL;

namespace ADeeWu.HuoBi3J.Web.Center
{
    public partial class Key4Product : System.Web.UI.Page
    {
        public int kid = 0;
        DataBase db = DataBase.Create();
        DAL.Key_Attribute attrDAL = new DAL.Key_Attribute();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                kid = WebUtility.GetRequestInt("kid", -1);
                if (kid == -1)
                {
                    WebUtility.ShowAndGoBack(this, "参数有误！");
                    return;
                }
                Search();
            }
        }

        private void Search()
        {
            var pageIndex = WebUtility.GetRequestInt("page", 1);
            var pageSize = Utility.GetInt(Request["pagesize"], 10, 5, 40);

            var selectType = WebUtility.GetRequestStr("selectType", "");
            var selectSize = WebUtility.GetRequestStr("selectSize", "");
            var selectPrice = WebUtility.GetRequestStr("selectPrice", "");
            var keyword = WebUtility.GetRequestStr("keyword", "");

            rpKey.DataSource = new DAL.Key().GetEntityList("", new string[] { "kid" }, new object[] { kid });
            rpKey.DataBind();

            litType.Text = "<li class='item'><a href='key4product.aspx?kid=" + kid + "&selectType=&selectSize=" + selectSize + "&selectPrice=" + selectPrice + "' class='selectPrice'>全部</a></li>";
            litSize.Text = "<li class='item'><a href='key4product.aspx?kid=" + kid + "&selectType=" + selectType + "&selectSize=&selectPrice=" + selectPrice + "' class='selectPrice'>全部</a></li>";
            litPrice.Text = "<li class='item'><a href='key4product.aspx?kid=" + kid + "&selectType=" + selectSize + "&selectSize=" + selectSize + "&selectPrice=' class='selectPrice'>全部</a></li>";

            var attributes = new DAL.Key_Attribute().GetEntityList("", new string[] { "kid" }, new object[] { kid });
            if (attributes != null)
            {
                litType.Text += string.Join("", attributes.Where(p => p.DataType == "SelectType").Select(p => string.Format("<li class='item'><a href='key4product.aspx?kid={0}&selectType={4}-{1}&selectSize={2}&selectPrice={3}' class='selectPrice' title='{1}'>{1}</a></li>", kid, p.DataValue, selectSize, selectPrice, p.ID)));
                litSize.Text += string.Join("", attributes.Where(p => p.DataType == "SelectSize").Select(p => string.Format("<li class='item'><a href='key4product.aspx?kid={0}&selectType={1}&selectSize={4}-{2}&selectPrice={3}' class='selectPrice' title='{2}'>{2}</a></li>", kid, selectType, p.DataValue, selectPrice, p.ID)));
                litPrice.Text += string.Join("", attributes.Where(p => p.DataType == "SelectPrice").Select(p => string.Format("<li class='item'><a href='key4product.aspx?kid={0}&selectType={1}&selectSize={2}&selectPrice={4}-{3}' class='selectPrice' title='{3}'>{3}</a></li>", kid, selectType, selectSize, p.DataValue, p.ID)));
            }

            var filter = string.Format("KID:{0},{0}", kid);
            if (!string.IsNullOrWhiteSpace(selectType))
            {
                var id = Utility.GetInt(selectType.Split(new char[] { '-' }).FirstOrDefault(), 0);
                if (id > 0)
                    filter += string.Format("|SelectTypeID:{0},{0}", id);
            }
            if (!string.IsNullOrWhiteSpace(selectPrice))
            {
                var id = Utility.GetInt(selectPrice.Split(new char[] { '-' }).FirstOrDefault(), 0);
                if (id > 0)
                    filter += string.Format("|SelectPriceID:{0},{0}", id);
            }
            if (!string.IsNullOrWhiteSpace(selectSize))
            {
                var id = Utility.GetInt(selectSize.Split(new char[] { '-' }).FirstOrDefault(), 0);
                if (id > 0)
                    filter += string.Format("|SelectSizeID:{0},{0}", id);
            }

            var geoSearchBLL = new GeoSearchBLL();
            var productContents = geoSearchBLL.Local<LBSHelper.ProductContent>(ADee.Project.LBS.Common.ConfigHelper.GeoProductTableID, keyword, AccountHelper.City, pageIndex - 1, pageSize, keyword, "Price:1", filter);
            rpProduct.DataSource = productContents.contents;
            rpProduct.DataBind();

            this.Pager1.AppendUrlParam("kid", kid.ToString());
            this.Pager1.AppendUrlParam("selectType", selectType);
            this.Pager1.AppendUrlParam("selectSize", selectSize);
            this.Pager1.AppendUrlParam("selectPrice", selectPrice);
            this.Pager1.AppendUrlParam("keyword", keyword);
            this.Pager1.PageSize = (int)pageSize;
            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.TotalRecords = productContents.total;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var id = WebUtility.GetRequestInt("kid", -1);
            var selectType = WebUtility.GetRequestStr("selectType", "");
            var selectSize = WebUtility.GetRequestStr("selectSize", "");
            var selectPrice = WebUtility.GetRequestStr("selectPrice", "");

            Response.Redirect(string.Format("/center/key4product.aspx?kid={0}&selectType={1}&selectSize={2}&selectPrice={3}&keyword={4}", id, selectType, selectSize, selectPrice, ""), true);
        }

        public string GetMoney(object mon)
        {
            return Utility.GetDecimal(mon, 0).ToString("F2");
        }
    }
}
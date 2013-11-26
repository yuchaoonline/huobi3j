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

namespace ADeeWu.HuoBi3J.Web.Center
{
    public partial class Key4Product : System.Web.UI.Page
    {
        public int kid = 0;
        DataBase db = DataBase.Create();
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
            var pageIndex = WebUtility.GetRequestLong("page", 1);
            var pageSize = Utility.GetLong(Request["pagesize"], 10, 5, 40);

            var selectType = WebUtility.GetRequestStr("selectType", "");
            var selectSize = WebUtility.GetRequestStr("selectSize", "");
            var selectPrice = WebUtility.GetRequestStr("selectPrice", "");
            var keyword = WebUtility.GetRequestStr("keyword", "");

            db.Parameters.Append("kid", kid);
            var keys = db.Select("vw_Keys", "kid=@kid", "");
            rpKey.DataSource = keys;
            rpKey.DataBind();

            litType.Text = "<li class='item'><a href='key4product.aspx?kid=" + kid + "&selectType=&selectSize=" + selectSize + "&selectPrice=" + selectPrice + "' class='selectPrice'>全部</a></li>";
            litSize.Text = "<li class='item'><a href='key4product.aspx?kid=" + kid + "&selectType=" + selectType + "&selectSize=&selectPrice=" + selectPrice + "' class='selectPrice'>全部</a></li>";
            litPrice.Text = "<li class='item'><a href='key4product.aspx?kid=" + kid + "&selectType=" + selectSize + "&selectSize=" + selectSize + "&selectPrice=' class='selectPrice'>全部</a></li>";
            
            var attribute = new DAL.Key_Attribute().GetEntity("kid=" + kid);
            if (attribute != null)
            {
                litType.Text += string.Join("", attribute.KeyType.Split(new char[] { ';' }).Select(p => "<li class='item'><a href='key4product.aspx?kid=" + kid + "&selectType=" + p + "&selectSize=" + selectSize + "&selectPrice=" + selectPrice + "' class='selectPrice'>" + p + "</a></li>"));
                litSize.Text += string.Join("", attribute.KeySize.Split(new char[] { ';' }).Select(p => "<li class='item'><a href='key4product.aspx?kid=" + kid + "&selectType=" + selectType + "&selectSize=" + p + "&selectPrice=" + selectPrice + "' class='selectPrice'>" + p + "</a></li>"));
                litPrice.Text += string.Join("", attribute.KeyPrice.Split(new char[] { ';' }).Select(p => "<li class='item'><a href='key4product.aspx?kid=" + kid + "&selectType=" + selectType + "&selectSize=" + selectSize + "&selectPrice=" + p + "' class='selectPrice'>" + p + "</a></li>"));
            }
                        
            var strWhere = "kid=@kid";
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                txtSearch.Text = keyword;
                strWhere += string.Format(" and (companyname like '%{0}%' or companyaddress like '%{0}%' or simpledesc like '%{0}%')",keyword);
            }

            if (!string.IsNullOrWhiteSpace(selectType))
            {
                strWhere += string.Format(" and selecttype='{0}'", selectType);
            }
            if (!string.IsNullOrWhiteSpace(selectPrice))
            {
                strWhere += string.Format(" and selectPrice='{0}'", selectPrice);
            }
            if (!string.IsNullOrWhiteSpace(selectSize))
            {
                strWhere += string.Format(" and selectSize='{0}'", selectSize);
            }

            db.EnableRecordCount = true;
            db.Parameters.Append("kid", kid);
            rpProduct.DataSource = db.Select(pageSize, pageIndex, "vw_Key_Product", "id", strWhere, "price asc"); ;
            rpProduct.DataBind();

            this.Pager1.AppendUrlParam("kid", kid.ToString());
            this.Pager1.AppendUrlParam("selectType", selectType);
            this.Pager1.AppendUrlParam("selectSize", selectSize);
            this.Pager1.AppendUrlParam("selectPrice", selectPrice);
            this.Pager1.AppendUrlParam("keyword", keyword);
            this.Pager1.PageSize = (int)pageSize;
            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.TotalRecords = (int)db.RecordCount;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var id = WebUtility.GetRequestInt("kid", -1);
            var selectType = WebUtility.GetRequestStr("selectType", "");
            var selectSize = WebUtility.GetRequestStr("selectSize", "");
            var selectPrice = WebUtility.GetRequestStr("selectPrice", "");

            Response.Redirect(string.Format("/center/key4product.aspx?kid={0}&selectType={1}&selectSize={2}&selectPrice={3}&keyword={4}", id, selectType, selectSize, selectPrice, txtSearch.Text), true);
        }

        public string GetMoney(object mon)
        {
            return Utility.GetDecimal(mon, 0).ToString("F2");
        }
    }
}
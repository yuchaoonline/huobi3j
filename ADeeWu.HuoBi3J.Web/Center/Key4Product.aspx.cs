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

            DataBase db = DataBase.Create();

            db.Parameters.Append("kid", kid);
            var keys = db.Select("vw_Keys", "kid=@kid", "");
            rpKey.DataSource = keys;
            rpKey.DataBind();

            db.Parameters.Append("kid", kid);
            var dtAttributes = db.Select("Key_Attribute", "kid=@kid", "");
            var KeyType = new List<string>();
            var KeySize = new List<string>();
            var KeyPrice = new List<string>();
            foreach (DataRow item in dtAttributes.Rows)
            {
                KeyType.Add(item["KeyType"].ToString());
                KeySize.Add(item["KeySize"].ToString());
                KeyPrice.Add(item["KeyPrice"].ToString());
            }

            litType.Text = "<li class='item'><a href='key4product.aspx?kid=" + kid + "&selectType=&selectSize=" + selectSize + "&selectPrice=" + selectPrice + "' class='selectPrice'>全部</a></li>";
            litSize.Text = "<li class='item'><a href='key4product.aspx?kid=" + kid + "&selectType=" + selectType + "&selectSize=&selectPrice=" + selectPrice + "' class='selectPrice'>全部</a></li>";
            litPrice.Text = "<li class='item'><a href='key4product.aspx?kid=" + kid + "&selectType=" + selectSize + "&selectSize=" + selectSize + "&selectPrice=' class='selectPrice'>全部</a></li>";
            
            litType.Text += string.Join("", KeyType.Select(p => "<li class='item'><a href='key4product.aspx?kid=" + kid + "&selectType=" + p + "&selectSize=" + selectSize + "&selectPrice=" + selectPrice + "' class='selectPrice'>" + p + "</a></li>"));
            litSize.Text += string.Join("", KeySize.Select(p => "<li class='item'><a href='key4product.aspx?kid=" + kid + "&selectType=" + selectType + "&selectSize=" + p + "&selectPrice=" + selectPrice + "' class='selectPrice'>" + p + "</a></li>"));
            litPrice.Text += string.Join("", KeyPrice.Select(p => "<li class='item'><a href='key4product.aspx?kid=" + kid + "&selectType=" + selectType + "&selectSize=" + selectSize + "&selectPrice=" + p + "' class='selectPrice'>" + p + "</a></li>"));

            db.EnableRecordCount = true;
            db.Parameters.Append("kid", kid);
            var strWhere = "kid=@kid";
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                txtSearch.Text = keyword;
                strWhere += string.Format(" and (companyname like '%{0}%' or companyaddress like '%{0}%' or simpledesc like '%{0}%')",keyword);
            }
            var dt = db.Select(pageSize, pageIndex, "vw_Key_Product", "id", strWhere, "");
            var rows = new List<DataRow>();

            var finallpass = (string.IsNullOrWhiteSpace(selectType) ? 0 : 1) + (string.IsNullOrWhiteSpace(selectSize) ? 0 : 1) + (string.IsNullOrWhiteSpace(selectPrice) ? 0 : 1);
            foreach (DataRow item in dt.Rows)
            {
                if (finallpass == 0)
                {
                    rows.Add(item);
                    continue;
                }

                var pass = 0;

                var selectAttribute = item["selectattribute"].ToString();
                var attrbutes = selectAttribute.Split(new char[] { ';', '：' });
                if (!string.IsNullOrWhiteSpace(selectType))
                {
                    if (attrbutes[1].Contains(selectType)) pass++; else pass--;
                }
                if (!string.IsNullOrWhiteSpace(selectSize))
                {
                    if (attrbutes[3].Contains(selectSize)) pass++; else pass--;
                }
                if (!string.IsNullOrWhiteSpace(selectPrice))
                {
                    if (attrbutes[5].Contains(selectPrice)) pass++; else pass--;
                }

                if (finallpass == pass)
                    rows.Add(item);
            }
            rpProduct.DataSource = rows;
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
    }
}
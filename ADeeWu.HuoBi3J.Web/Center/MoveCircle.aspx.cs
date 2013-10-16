using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web.Center
{
    public partial class MoveCircle : System.Web.UI.Page
    {
        DAL.Key keyDAL = new DAL.Key();
        DAL.BusinessCircle businessCircle = new DAL.BusinessCircle();
        DataBase db = DataBase.Create();

        public static int kid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                kid = WebUtility.GetRequestInt("kid", 0);
                var bid = WebUtility.GetRequestInt("bid", 0);

                var key = keyDAL.GetEntity(kid);
                litKeyName.Text = key.Name;

                if (bid > 0 && kid > 0)
                    Move(bid, kid);
            }
        }

        private void Move(int bid, int kid)
        {
            var key = keyDAL.GetEntity(kid);
            if (keyDAL.Exist(new string[] { "name", "bid" }, new object[] { key.Name, bid }))
            {
                WebUtility.ShowMsg("该关键字已存在于该商圈，无须进行复制操作！");
                return;
            }

            var newKey = new Model.Key
            {
                BID = bid,
                IsDefault = false,
                CreateTime = DateTime.Now,
                Name = key.Name,
            };
            keyDAL.Add(newKey);

            Response.Redirect("BusinessCircle.aspx?bid=" + bid);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            var sql = "1=1 ";

            var syncs = syncSelectorLocation.Values;            
            if (syncs[2] != "-1")
            {
                sql += "and areaid=" + syncs[2];
            }
            else if (syncs[1] != "-1")
            {
                sql += "and cityid=" + syncs[1];
            }
            else if (syncs[0] != "-1")
            {
                sql += "and provinceid=" + syncs[0];
            }
            if (!string.IsNullOrWhiteSpace(txtBName.Text))
            {
                sql += string.Format("and bname like '%{0}%'", txtBName.Text);
            }

            rpResult.DataSource = db.Select("vw_BusinessCircle", sql, "");
            rpResult.DataBind();
        }
    }
}
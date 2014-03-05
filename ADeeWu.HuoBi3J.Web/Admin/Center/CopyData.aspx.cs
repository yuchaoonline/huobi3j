using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using System.Text;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;

namespace ADeeWu.HuoBi3J.Web.Admin.Center
{
    public partial class CopyData : PageBase
    {
        public override string PageID
        {
            get
            {
                return "010002";
            }
        }

        
        DAL.Shop_ProductCategories productCategoryDAL = new DAL.Shop_ProductCategories();
        DAL.Callings callingDAL = new DAL.Callings();
        DAL.Key keyDAL = new DAL.Key();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void rpResult_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "copy")
            {
                var bid = Utility.GetInt(e.CommandArgument, 0);

                Copy(bid);
            }
        }

        protected void btnCopy_Click(object sender, EventArgs e)
        {
            int bid =Utility.GetInt(System.Configuration.ConfigurationManager.AppSettings["movebid"], 0);
            if (bid == 0)
            {
                WebUtility.ShowAndGoBack(this, "请设置movebid值！");
                return;
            }
            Copy(bid);
        }

        private void Copy(int bid)
        {
            if (bid == 0)
            {
                WebUtility.ShowMsg("商圈ID不合法！");
                return;
            }

            #region 删除原有数据
            var keys = keyDAL.GetEntityList("", new string[] { "isdefault", "bid" }, new string[] { "1", bid.ToString() });
            foreach (var item in keys)
            {
                keyDAL.Delete(item.KID);
            }
            #endregion
            #region 复制商品分类
            var productCates = productCategoryDAL.GetEntityList("", new string[] { }, new string[] { });
            foreach (var product in productCates)
            {
                keyDAL.Add(new Model.Key
                {
                    CreateTime = DateTime.Now,
                    Name = product.Name,
                    IsDefault = true,
                });
            }
            #endregion
            #region 复制行业分类
            var callings = callingDAL.GetEntityList("", new string[] { }, new string[] { });
            foreach (var calling in callings)
            {
                keyDAL.Add(new Model.Key
                {
                    CreateTime = DateTime.Now,
                    IsDefault = true,
                    Name = calling.Name
                });
            }
            #endregion

            WebUtility.ShowAndGoBack(this, string.Format("共复制{0}条商品分类，{1}条行业分类", productCates.Length, callings.Length));
            return;
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

            rpResult.DataSource =DataBase.Create().Select("vw_BusinessCircle", sql, "");
            rpResult.DataBind();
        }
    }
}

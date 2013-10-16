using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web.Admin.GroupBuy
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BandData();
            }
        }

        private void BandData()
        {
            var pageIndex = WebUtility.GetRequestLong("page", 1);
            var pageSize = Utility.GetLong(Request["pagesize"], 20, 5, 40);

            var db = DataBase.Create();
            db.EnableRecordCount = true;
            rpResult.DataSource = db.Select(pageSize, pageIndex, "vw_GroupBuy_Product", "id", "", "");
            rpResult.DataBind();

            this.Pager1.PageSize = (int)pageSize;
            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.TotalRecords = (int)db.RecordCount;
        }

        protected void rpResult_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "pass":
                    {
                        var pid = Utility.GetInt(e.CommandArgument, 0);
                        if (pid == 0)
                        {
                            WebUtility.ShowMsg("参数有误，请刷新页面！");
                            return;
                        }
                        PassProduct(pid);
                    }; break;
                case "drop":
                    {
                        var pid = Utility.GetInt(e.CommandArgument, 0);
                        if (pid == 0)
                        {
                            WebUtility.ShowMsg("参数有误，请刷新页面！");
                            return;
                        }
                        DropProduct(pid);
                    };break;
            }
        }

        private void PassProduct(int pid)
        {
            var productDAL = new DAL.GroupBuy_Product();
            var product = productDAL.GetEntity(pid);

            product.IsPass = true;
            product.IsExpire = false;
            if (!product.PassDate.HasValue)
                product.PassDate = DateTime.Now;

            if (productDAL.Update(product) > 0)
            {
                WebUtility.ShowMsg(this, "审核通过！", "default.aspx");
                return;
            }
            else
            {
                WebUtility.ShowMsg("审核失败，请重试！");
                return;
            }
        }

        private void DropProduct(int pid)
        {
            var productDAL = new DAL.GroupBuy_Product();
            var product = productDAL.GetEntity(pid);

            product.IsPass = false;

            if (productDAL.Update(product) > 0)
            {
                WebUtility.ShowMsg(this, "下架成功！", "default.aspx");
                return;
            }
            else
            {
                WebUtility.ShowMsg("下架失败，请重试！");
                return;
            }
        }

        public string IsPass(object obj)
        {
            if (obj == null) return "未知";
            return Utility.GetBool(obj, false) ? "通过" : "未通过";
        }

        public string IsExpire(object obj)
        {
            if (obj == null) return "未知";
            return Utility.GetBool(obj, false) ? "过期" : "未过期";
        }
    }
}
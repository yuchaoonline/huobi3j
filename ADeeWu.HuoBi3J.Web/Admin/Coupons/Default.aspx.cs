using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web.Admin.Coupons
{
    public partial class Default : System.Web.UI.Page
    {
        DataBase db = DataBase.Create();

        protected void Page_Load(object sender, EventArgs e)
        {
            var method = WebUtility.GetRequestStr("method","").ToLower();
            var id = WebUtility.GetRequestInt("id", -1);
            if (!string.IsNullOrWhiteSpace(method))
            {
                if (method == "del")
                    Delete(id);
            }
            else
            {
                BandData();
            }
        }

        private void BandData()
        {
            var pageSize = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("pagesize", PageBase.DataList_PageSize);
            var pageIndex = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("page", 1); 

            rpResult.DataSource = db.Select(pageSize, pageIndex, "vw_Coupons_Subject", "ID", "", "");
            rpResult.DataBind();
        }

        private void Delete(int id)
        {
            var dal = new DAL.Coupons_Subject();
            var subject = dal.GetEntity(id);
            if (subject == null)
            {
                WebUtility.ShowAndGoBack(this, "活动不存在！");
                return;
            }

            subject.Inactive = true;
            if (dal.Update(subject) > 0)
            {
                WebUtility.ShowMsg(this, "删除成功！","Default.aspx");
                return;
            }
            else
            {
                WebUtility.ShowAndGoBack(this, "删除失败！");
                return;
            }
        }
    }
}
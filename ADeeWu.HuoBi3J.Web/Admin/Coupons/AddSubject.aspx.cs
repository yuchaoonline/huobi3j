using ADeeWu.HuoBi3J.Libary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web.Admin.Coupons
{
    public partial class AddSubject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dtStartDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                dtEndDate.Text = DateTime.Now.AddDays(7).ToString("yyyy/MM/dd");
            }
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                WebUtility.ShowMsg("活动名称不能为空！");
                return;
            }
            if (!Utility.IsDateTime(dtStartDate.Text) || !Utility.IsDateTime(dtEndDate.Text))
            {
                WebUtility.ShowMsg("日期格式不正确！");
                return;
            }

            var subject = new Model.Coupons_Subject
            {
                Inactive = false,
                Name = txtName.Text,
                StartDate = Utility.GetDateTime(dtStartDate.Text, DateTime.Now),
                EndDate = Utility.GetDateTime(dtEndDate.Text, DateTime.Now.AddDays(7))
            };

            if (new DAL.Coupons_Subject().Add(subject) > 0)
            {
                WebUtility.ShowMsg(this, "添加成功！", "Default.aspx");
                return;
            }
            else
            {
                WebUtility.ShowMsg("添加失败！");
                return;
            }
        }
    }
}
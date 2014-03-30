using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web.Admin.Coupons
{
    public partial class EditSubject : System.Web.UI.Page
    {
        DAL.Coupons_Subject subjectDAL = new DAL.Coupons_Subject();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var id = WebUtility.GetRequestInt("id", -1);
                BandData(id);
            }
        }

        private void BandData(int id)
        {
            var subject = subjectDAL.GetEntity(id);
            if (subject == null) return;

            hfID.Value = subject.ID.ToString();
            txtName.Text = subject.Name;
            dtEndDate.Text = subject.EndDate.Value.ToString("yyyy/MM/dd");
            dtStartDate.Text = subject.StartDate.Value.ToString("yyyy/MM/dd");
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
                ID = Utility.GetInt(hfID.Value,0),
                Inactive = false,
                Name = txtName.Text,
                StartDate = Utility.GetDateTime(dtStartDate.Text, DateTime.Now),
                EndDate = Utility.GetDateTime(dtEndDate.Text, DateTime.Now.AddDays(7))
            };

            if (new DAL.Coupons_Subject().Update(subject) > 0)
            {
                WebUtility.ShowMsg(this, "修改成功！", "Default.aspx");
                return;
            }
            else
            {
                WebUtility.ShowMsg("修改失败！");
                return;
            }
        }
    }
}
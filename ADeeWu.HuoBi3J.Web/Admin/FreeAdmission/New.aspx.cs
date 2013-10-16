using ADeeWu.HuoBi3J.Libary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web.Admin.FreeAdmission
{
    public partial class New : System.Web.UI.Page
    {
        DAL.FreeAdmission freeAdmissionDAL = new DAL.FreeAdmission();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSeqNO.Text))
            {
                WebUtility.ShowMsg("序列号不能为空！");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtSeqPwd.Text))
            {
                WebUtility.ShowMsg("密码不能为空！");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtStartDate.Text))
            {
                WebUtility.ShowMsg("开始时间不能为空！");
                return;
            }
            if (!Utility.IsDateTime(txtStartDate.Text))
            {
                WebUtility.ShowMsg("开始时间格式不正确！");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtEndDate.Text))
            {
                WebUtility.ShowMsg("结束时间不能为空！");
                return;
            }
            if (!Utility.IsDateTime(txtEndDate.Text))
            {
                WebUtility.ShowMsg("结束时间格式不正确！");
                return;
            }
            if (Utility.GetDateTime(txtStartDate.Text, DateTime.Now) > Utility.GetDateTime(txtEndDate.Text, DateTime.Now))
            {
                WebUtility.ShowMsg("开始时间不能大于结束时间！");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtMoney.Text))
            {
                WebUtility.ShowMsg("金额不能为空！");
                return;
            }
            if (!Utility.IsFloat(txtMoney.Text))
            {
                WebUtility.ShowMsg("金额应为数字！");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTotalCount.Text))
            {
                WebUtility.ShowMsg("总申请次数不能为空！");
                return;
            }
            if (!Utility.IsInt(txtTotalCount.Text))
            {
                WebUtility.ShowMsg("总申请次数应为数字！");
                return;
            }
            if (freeAdmissionDAL.Exist("SeqNo", txtSeqNO.Text))
            {
                WebUtility.ShowMsg("序列号已存在！");
                return;
            }

            var freeAdmission = new Model.FreeAdmission
            {
                ApplyCount = 1,
                EndDate = (DateTime)Utility.GetDateTime(txtEndDate.Text,DateTime.Now),
                StartDate = (DateTime)Utility.GetDateTime(txtStartDate.Text, DateTime.Now),
                Money = Utility.GetDecimal(txtMoney.Text,0),
                SeqNo = txtSeqNO.Text,
                SeqPwd = txtSeqPwd.Text,
                TotalCount = Utility.GetInt(txtTotalCount.Text,0),
            };

            if (freeAdmissionDAL.Add(freeAdmission) > 0)
            {
                WebUtility.ShowMsg(this, "操作成功！", "New.aspx");
                return;
            }

            WebUtility.ShowMsg("操作失败！");
            return;
        }
    }
}
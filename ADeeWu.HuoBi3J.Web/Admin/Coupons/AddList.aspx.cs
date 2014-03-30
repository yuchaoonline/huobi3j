using ADeeWu.HuoBi3J.Libary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web.Admin.Coupons
{
    public partial class AddList : System.Web.UI.Page
    {
        DAL.Coupons_List listDAL = new DAL.Coupons_List();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var subjectid = WebUtility.GetRequestInt("subjectid", -1);
                var subject = new DAL.Coupons_Subject().GetEntity(subjectid);

                dtStartDate.Text = subject.StartDate.Value.ToString("yyyy/MM/dd");
                dtEndDate.Text = subject.EndDate.Value.ToString("yyyy/MM/dd");
            }
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            if (!Utility.IsFloat(txtMoney.Text))
            {
                WebUtility.ShowMsg("金额格式有问题！");
                return;
            }
            if (!Utility.IsInt(txtCount.Text))
            {
                WebUtility.ShowMsg("数量为整数！");
                return;
            }

            var count = Utility.GetInt(txtCount.Text, -1);
            var money = Utility.GetDecimal(txtMoney.Text, 0);
            var subjectid = WebUtility.GetRequestInt("subjectid", -1);
            var subject = new DAL.Coupons_Subject().GetEntity(subjectid);
            var startDate = Utility.GetDateTime(dtStartDate.Text, DateTime.MinValue);
            var endDate = Utility.GetDateTime(dtEndDate.Text, DateTime.MinValue);
            if (subject == null)
            {
                WebUtility.ShowMsg("参数有问题！");
                return;
            }
            if (subject.Inactive.HasValue && subject.Inactive.Value)
            {
                WebUtility.ShowMsg("活动已删除或已结束，无需再生成码！");
                return;
            }
            if (subject.EndDate.HasValue && subject.EndDate.Value < DateTime.Now)
            {
                WebUtility.ShowMsg("活动已结束，无需再生成码！");
                return;
            }
            if (startDate < subject.StartDate || endDate > subject.EndDate)
            {
                WebUtility.ShowMsg("有效期不在活动范围内！");
                return;
            }

            var successCount = 0;
            var isMoney = false;
            if (ddlIsMoney.SelectedValue == "1") isMoney = true;

            foreach (var code in GeneralCode(count))
            {
                var list = new Model.Coupons_List
                {
                    EndDate = endDate,
                    IsMoney = isMoney,
                    IsUse = false,
                    Money = money,
                    StartDate = startDate,
                    SubjectID = subject.ID,
                    Password = code,
                    Memo = "",
                    Inactive = false,
                };
                try
                {
                    listDAL.Add(list);
                    successCount++;
                }
                catch
                {

                }
            }

            WebUtility.ShowMsg(this, string.Format("成功生成{0}张券", successCount), "lists.aspx?subjectid=" + subject.ID);
        }

        private List<string> GeneralCode(int count)
        {
            var codes = new List<string>();

            var r = new Random(DateTime.Now.Millisecond);
            while (codes.Count < count)
            {
                var code = r.Next(10000000, 99999999).ToString();
                if (listDAL.Exist("password", code)) continue;

                codes.Add(code);
            }

            return codes;
        }
    }
}
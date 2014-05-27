using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.Web.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web.My.User.Coupons
{
    public partial class CashWhenFee : PageBase_MyUser
    {
        DAL.Coupons_Subject subjectDAL = new DAL.Coupons_Subject();
        DAL.Coupons_CashWhenFee cashWhenFeeDAL = new DAL.Coupons_CashWhenFee();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BandData();
            }
        }

        private void BandData()
        {
            var subject = subjectDAL.GetEntity(new string[] { "CreateUserID", "SubjectType" }, new object[] { this.LoginUser.UserID, "CashWhenFee" });
            if (subject == null) return;
            hfSubjectID.Value = subject.ID.ToString();

            var casewhenfees = cashWhenFeeDAL.GetEntityList("CreateDate desc", new string[] { "CouponsSubjectID" }, new object[] { subject.ID });
            if(casewhenfees==null || !casewhenfees.Any()) return;

            var casewhenfee = casewhenfees.FirstOrDefault();
            txtMoney.Text = casewhenfee.Money.Value.ToString("0.00");
            txtFee.Text = casewhenfee.Fee.Value.ToString("0.00");
            dtStartDate.Text = subject.StartDate.Value.ToString("yyyy/MM/dd");
            dtEndDate.Text = subject.EndDate.Value.ToString("yyyy/MM/dd");

            rpLog.DataSource = cashWhenFeeDAL.Select("CouponsSubjectID=" + subject.ID, "createdate desc");
            rpLog.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var money = Utility.GetDecimal(txtMoney.Text, 0);
            var fee = Utility.GetDecimal(txtFee.Text, 0);
            var startDate = Utility.GetDateTime(dtStartDate.Text, DateTime.MinValue);
            var endDate = Utility.GetDateTime(dtEndDate.Text, DateTime.MinValue);
            var subjectID = Utility.GetInt(hfSubjectID.Value, 0);

            if (fee == 0)
            {
                WebUtility.ShowMsg("消费金额应该大于0");
                return;
            }
            if (money == 0)
            {
                WebUtility.ShowMsg("消费金额应该大于0");
                return;
            }

            if (subjectID <= 0)
            {
                subjectID = AddSubject(string.Format("{0}商家的现金抵扣活动",this.LoginUser.LoginName),startDate.Value,endDate.Value);
            }
            else
            {
                var subject = subjectDAL.GetEntity(subjectID);
                subject.StartDate = startDate;
                subject.EndDate = endDate;
                subjectDAL.Update(subject);
            }
            var cashWhenFee = new Model.Coupons_CashWhenFee
            {
                CouponsSubjectID = subjectID,
                CreateDate = DateTime.Now,
                EndDate = endDate,
                StartDate = startDate,
                Money = money,
                Fee=fee
            };
            if (cashWhenFeeDAL.Add(cashWhenFee) > 0)
            {
                WebUtility.ShowMsg(this,"处理成功！","CashWhenFee.aspx");
                return;
            }

            WebUtility.ShowMsg("处理失败，请重试！");
        }

        private int AddSubject(string name,DateTime startDate,DateTime endDate)
        {
            var subject = new Model.Coupons_Subject
            {
                Inactive = false,
                Name = name,
                StartDate = startDate,
                EndDate = endDate,
                CreateUserID  = (int)this.LoginUser.UserID,
                SubjectType = "CashWhenFee",
            };

            return subjectDAL.Add(subject);
        }

        public string GetQRURL(int count)
        {
            return "/QR.aspx?s=" + HttpUtility.UrlEncode("/coupons/cashwhenfeegeneralticket.aspx?salemanuserid=" + this.LoginUser.UserID + "&count=1");
        }
    }
}
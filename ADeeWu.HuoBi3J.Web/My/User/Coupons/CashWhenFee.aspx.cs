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
        DAL.Coupons_CashWhenFee feeDAL = new DAL.Coupons_CashWhenFee();
        DAL.Coupons_CashWhenFee_Condition conditionDAL = new DAL.Coupons_CashWhenFee_Condition();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BandData();
            }
        }

        private void BandData()
        {
            var fees = GetFees();
            if (!fees.IsNotNullAndAny()) return;

            var fee = fees.FirstOrDefault();

            txtMoney.Text = fee.Money.Value.ToString("0.00");
            txtFee.Text = fee.Fee.Value.ToString("0.00");
            dtStartDate.Text = fee.StartDate.Value.ToString("yyyy/MM/dd");
            dtEndDate.Text = fee.EndDate.Value.ToString("yyyy/MM/dd");

            var conditions = conditionDAL.GetEntityList("CreateTime desc", new string[] { "salemanuserid" }, new object[] { this.LoginUser.UserID });
            if (conditions.IsNotNullAndAny())
            {
                var condition = conditions.FirstOrDefault();
                txtConditionMoney.Text = condition.Money.Value.ToString("0.00");
                txtMemo.Text = condition.Memo;

                btnShow.Text = condition.IsShow.Value ? "隐藏" : "显示";
            }

            rpLog.DataSource = fees;
            rpLog.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var money = Utility.GetDecimal(txtMoney.Text, 0);
            var fee = Utility.GetDecimal(txtFee.Text, 0);
            var startDate = Utility.GetDateTime(dtStartDate.Text, DateTime.MinValue);
            var endDate = Utility.GetDateTime(dtEndDate.Text, DateTime.MinValue);

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

            var cashWhenFee = new Model.Coupons_CashWhenFee
            {
                CreateDate = DateTime.Now,
                EndDate = endDate,
                StartDate = startDate,
                Money = money,
                Fee = fee,
                CreateUserID = (int)this.LoginUser.UserID,
            };

            if (feeDAL.Add(cashWhenFee) > 0)
            {
                WebUtility.ShowMsg(this, "处理成功！", "CashWhenFee.aspx");
                return;
            }

            WebUtility.ShowMsg("处理失败，请重试！");
        }

        public string GetQRURL(int count)
        {
            return "/QR.aspx?s=" + HttpUtility.UrlEncode("/coupons/cashwhenfeegeneralticket.aspx?salemanuserid=" + this.LoginUser.UserID + "&count=" + count);
        }

        protected void btnCondition_Click(object sender, EventArgs e)
        {
            var money = txtConditionMoney.Text.GetDecimal(0);
            var memo = txtMemo.Text;

            if (money == 0)
            {
                WebUtility.ShowMsg("获取现金抵扣券的消费金额应该大于0！");
                return;
            }

            var condition = new Model.Coupons_CashWhenFee_Condition
             {
                 SaleManUserID = (int)this.LoginUser.UserID,
                 Money = money,
                 Memo = memo,
                 IsShow = true,
                 CreateTime = DateTime.Now,
             };

            conditionDAL.Add(condition);
            WebUtility.ShowMsg("修改成功！");
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            var conditions = conditionDAL.GetEntityList("CreateTime desc", new string[] { "salemanuserid" }, new object[] { this.LoginUser.UserID });
            if (!conditions.IsNotNullAndAny())
            {
                WebUtility.ShowMsg("还没有设置获赠条件，请先设置！");
                return;
            }

            var condition = conditions.FirstOrDefault();
            condition.IsShow = !condition.IsShow.Value;
            conditionDAL.Update(condition);

            WebUtility.ShowMsg(this, "设置成功！", "CashWhenFee.aspx");
        }

        public List<Model.Coupons_CashWhenFee> GetFees()
        {
            return feeDAL.GetEntityList("CreateDate desc", new string[] { "CreateUserID" }, new object[] { this.LoginUser.UserID }).ToList();
        }

        public Model.Coupons_CashWhenFee GetFeeObject()
        {
            var fees = GetFees();
            return fees.IsNotNullAndAny() ? fees.FirstOrDefault() : null;
        }
    }
}
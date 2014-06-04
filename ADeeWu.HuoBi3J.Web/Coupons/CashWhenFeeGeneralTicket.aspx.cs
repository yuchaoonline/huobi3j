using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Web.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web.Coupons
{
    public partial class CashWhenFeeGeneralTicket : PageBase
    {
        DataBase db = DataBase.Create();
        DAL.Coupons_CashWhenFee feeDAL = new DAL.Coupons_CashWhenFee();
        DAL.Coupons_CashWhenFee_Condition conditionDAL = new DAL.Coupons_CashWhenFee_Condition();

        public string ConditionAlert = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var count = WebUtility.GetRequestInt("count", 0);
                var userid = WebUtility.GetRequestInt("salemanuserid", 0);

                SaleManInfo(userid);
                TicketInfo(userid, count);
                Condition(userid);
            }
        }

        private void SaleManInfo(int userid)
        {
            rpSaleManInfo.DataSource = db.Select("vw_Key_CircleSaleMan", "userid = " + userid, "");
            rpSaleManInfo.DataBind();
        }

        private void Condition(int userid)
        {
            var conditions = conditionDAL.GetEntityList("CreateTime desc", new string[] { "salemanuserid" }, new object[] { userid });
            if (conditions.IsNotNullAndAny())
            {
                var condition = conditions.FirstOrDefault();
                if (condition.IsShow.HasValue && condition.IsShow.Value)
                    ConditionAlert = string.Format("alert('温馨提示：本次消费满{0}元，结账时即可获得商家代金券，请向服务员索取。');", condition.Money.Value.ToString("0.00"));
            }
        }

        private void TicketInfo(int userid, int count)
        {
            var cashWhenFees = feeDAL.GetEntityList("CreateDate desc", new string[] { "CreateUserID" }, new object[] { userid }).ToList();
            if (cashWhenFees == null || !cashWhenFees.Any()) return;
            var cashWhenFee = cashWhenFees.FirstOrDefault();

            rpTicket.DataSource = new List<object> { new { money = cashWhenFee.Money.Value.ToString("0.00"), fee = cashWhenFee.Fee.Value.ToString("0.00"), count = count } };
            rpTicket.DataBind();

            TotalInfo(cashWhenFee.Money.Value, cashWhenFee.Fee.Value, count, cashWhenFee.EndDate.Value);
        }

        private void TotalInfo(decimal money, decimal fee, int count, DateTime endDate)
        {
            rpTotal.DataSource = new List<object> { new { totalmoney = (money * count).ToString("0.00"), totalfee = (fee * count).ToString("0.00"), nowdate = DateTime.Now, invaildate = endDate } };
            rpTotal.DataBind();
        }
    }
}
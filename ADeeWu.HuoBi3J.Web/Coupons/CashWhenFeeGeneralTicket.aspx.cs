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
        DAL.Coupons_List listDAL = new DAL.Coupons_List();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var confirm = WebUtility.GetRequestStr("confirm", "");
                var count = WebUtility.GetRequestInt("count", 0);
                var userid = WebUtility.GetRequestInt("salemanuserid", 0);

                if (!string.IsNullOrWhiteSpace(confirm))
                {
                    SaveData(count,userid);
                }
                else
                {
                    SaleManInfo(userid);
                    TicketInfo(userid, count);
                }
            }
        }

        private void SaveData(int count, int userid)
        {
            var subject = new DAL.Coupons_Subject().GetEntity(new string[] { "CreateUserID", "SubjectType" }, new object[] { userid, "CashWhenFee" });
            if (subject == null) return;

            var cashWhenFees = new DAL.Coupons_CashWhenFee().GetEntityList("createdate desc", new string[] { "CouponsSubjectID" }, new object[] { subject.ID });
            if (cashWhenFees == null || !cashWhenFees.Any()) return;
            var cashWhenFee = cashWhenFees.FirstOrDefault();

            var list = new Model.Coupons_List
            {
                EndDate = cashWhenFee.EndDate,
                IsMoney = true,
                IsUse = false,
                Money = cashWhenFee.Money,
                StartDate = cashWhenFee.StartDate,
                SubjectID = subject.ID,
                Password = GetCode(),
                Memo = cashWhenFee.Fee.Value.ToString("0.00"),
                Inactive = false,
                UserID = (int)LoginUser.UserID
            };

            if (listDAL.Add(list) > 0)
            {
                WebUtility.ShowMsg(this, "领取成功！", "/");
            }
            else
            {
                WebUtility.ShowMsg("领取失败！");
            }
        }

        private string GetCode()
        {
            var code = "";
            var r = new Random(DateTime.Now.Millisecond);
            while (true)
            {
                code = r.Next(10000000, 99999999).ToString();
                if (!listDAL.Exist("password", code)) break;
            }

            return code;
        }

        private void SaleManInfo(int userid)
        {
            rpSaleManInfo.DataSource = db.Select("vw_Key_CircleSaleMan", "userid = " + userid, "");
            rpSaleManInfo.DataBind();
        }

        private void TicketInfo(int userid, int count)
        {
            var subject = new DAL.Coupons_Subject().GetEntity(new string[] { "CreateUserID", "SubjectType" }, new object[] { userid, "CashWhenFee" });
            if (subject == null) return;

            var cashWhenFees = new DAL.Coupons_CashWhenFee().GetEntityList("createdate desc", new string[] { "CouponsSubjectID" }, new object[] { subject.ID });
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
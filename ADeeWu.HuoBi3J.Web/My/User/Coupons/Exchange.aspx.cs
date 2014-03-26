using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Web.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web.My.User.Coupons
{
    public partial class Exchange : PageBase_CircleSaleMan
    {
        DataBase db = DataBase.Create();
        DAL.Coupons_List listDAL = new DAL.Coupons_List();
        DAL.Coupons_Subject subjectDAL = new DAL.Coupons_Subject();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var code = WebUtility.GetRequestStr("code", "");
                if (!string.IsNullOrWhiteSpace(code)) BandData(code);
            }
        }

        private void BandData(string code)
        {
            var list = db.Select("vw_Coupons_List", string.Format("password= '{0}'", code), "");
            if (list == null || list.Rows.Count <= 0) return;

            rpResult.DataSource = list;
            rpResult.DataBind();
        }

        protected void rpResult_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "use")
            {
                Use(Utility.GetInt(e.CommandArgument, -1));
            }
        }

        private void Use(int id)
        {
            var list = listDAL.GetEntity(id);            
            if (list == null)
            {
                WebUtility.ShowMsg("消费券不存在");
                return;
            }
            if (list.IsUse.HasValue && list.IsUse.Value)
            {
                WebUtility.ShowMsg("消费券已使用");
                return;
            }
            if (!list.UserID.HasValue)
            {
                WebUtility.ShowMsg("消费券未派送！");
                return;
            }
            if (list.StartDate>DateTime.Now||list.EndDate<DateTime.Now)
            {
                WebUtility.ShowMsg("消费券已过期！");
                return;
            }

            var subject = subjectDAL.GetEntity(list.SubjectID.Value);
            if (subject == null)
            {
                WebUtility.ShowMsg("活动不存在");
                return;
            }

            if (listDAL.Update(new string[] { "IsUse", "usedate" }, new object[] { 1, DateTime.Now }, "id=" + id) < 0)
            {
                WebUtility.ShowMsg("使用失败，请重试！");
                return;
            }

            if (list.IsMoney.HasValue && list.IsMoney.Value)
            {
                db.Parameters.Append("UserID", list.UserID);
                db.Parameters.Append("Money", list.Money);
                db.Parameters.Append("IsPayment", false);
                db.Parameters.Append("Notes", string.Format("参加{1}活动获得 {0} 元", list.Money, subject.Name));
                db.Parameters.Append("ErrorMessage", "", ParameterDirection.Output, DbType.String).Size = 1000;
                db.AutoClearParameters = false;
                if (ADeeWu.HuoBi3J.Libary.Utility.GetInt(db.RunProc("SP_User_DoDeal"), -1) != 0)
                {
                    WebUtility.ShowMsg(db.Parameters["ErrorMessage"].Value.ToString());
                    return;
                }
                db.Parameters.Clear();
                db.AutoClearParameters = true;
            }
            else
            {
                db.Parameters.Append("UserID", list.UserID);
                db.Parameters.Append("Coins", list.Money);
                db.Parameters.Append("IsUseCoin", false);
                db.Parameters.Append("Notes", string.Format("参加{1}活动获得金币 {0} 个", list.Money, subject.Name));
                db.Parameters.Append("ErrorMessage", "", ParameterDirection.Output, DbType.String).Size = 1000;
                db.AutoClearParameters = false;
                if (ADeeWu.HuoBi3J.Libary.Utility.GetInt(db.RunProc("SP_User_DoCoinsTrans"), -1) != 0)
                {
                    WebUtility.ShowMsg(db.Parameters["ErrorMessage"].Value.ToString());
                    return;
                }
                db.Parameters.Clear();
                db.AutoClearParameters = true;
            }

            WebUtility.ShowMsg(this, "兑换成功！", "exchange.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("exchange.aspx?code=" + HttpUtility.UrlEncode(txtCode.Text), true);
        }
    }
}
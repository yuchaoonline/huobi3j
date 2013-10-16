using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.Web.Class;
using ADeeWu.HuoBi3J.SQL;

namespace ADeeWu.HuoBi3J.Web.My.User.CashTickets
{
    public partial class Application : PageBase_MyUser
    {
        //public override string FunctionCode
        //{
        //    get
        //    {
        //        return "My-User-CashTickets-Application";
        //    }
        //}

        ADeeWu.HuoBi3J.DAL.CT_CashTicketApplications dalApplications = new ADeeWu.HuoBi3J.DAL.CT_CashTicketApplications();
        ADeeWu.HuoBi3J.DAL.CT_CashTickets dalCashTickets = new ADeeWu.HuoBi3J.DAL.CT_CashTickets();
        ADeeWu.HuoBi3J.DAL.Corporations corporationDAL = new DAL.Corporations();
        DataBase db = DataBase.Create();

        protected void Page_Load(object sender, System.EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //string corpName = this.txtCorpName.Text.Trim();
            //string strCostMoney = this.txtCostMoney.Text.Trim();
            //string strCostMoney2 = this.txtCostMoney2.Text.Trim();

            //DateTime? dateCostDate = Utility.GetDateTime(this.txtCostDate.Text, null);
            string ticketSerialNum = this.txtCashTicketSerialNum.Text.Trim();
            string ticketValidCode = this.txtCashTicketValidCode.Text.Trim();
            //string summary = WebUtility.GetTextAreaContent(this.txtSummary.Text);

            //if (corpName == "")
            //{
            //    WebUtility.ShowMsg("请填写现金券所属商家!");
            //    return;
            //}
            //if (strCostMoney == "")
            //{
            //    WebUtility.ShowMsg("请填写消费金额!");
            //    return;
            //}
            //if (strCostMoney2 == "")
            //{
            //    WebUtility.ShowMsg("请填写确认消费金额!");
            //    return;
            //}

            //if (strCostMoney != strCostMoney2)
            //{
            //    WebUtility.ShowMsg("两次输入消费金额不一致!");
            //    return;
            //}

            //decimal costMoney = ADeeWu.HuoBi3J.Libary.Utility.GetDecimal(strCostMoney, 0);
            //if (costMoney <= 0)
            //{
            //    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写正确的消费金额!");
            //    return;
            //}


            //if (!dateCostDate.HasValue)
            //{
            //    WebUtility.ShowMsg("请填写消费日期!");
            //    return;
            //}

            if (ticketSerialNum == "")
            {
                WebUtility.ShowMsg("请填写现金券序列号!");
                return;
            }
            if (ticketValidCode == "")
            {
                WebUtility.ShowMsg("请填写现金券序验证码(密码)!");
                return;
            }

            //if (summary == "")
            //{
            //    WebUtility.ShowMsg("请填写具体消费商品及金额!");
            //    return;
            //}

            ADeeWu.HuoBi3J.Model.CT_CashTickets entCashTicket = dalCashTickets.GetEntity(
                 new string[] { "SerialNum", "ValidCode" },
                 new object[] { ticketSerialNum, ticketValidCode }
            );

            //if (!dalCashTickets.Exist(
            //     new string[] { "SerialNum", "ValidCode" },
            //     new object[] { ticketSerialNum, ticketValidCode }
            //    ))
            //{
            //    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("现金券序号或验证码不正确!");
            //    return;
            //}


            if (entCashTicket == null)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("现金券序号或验证码不正确!");
                return;
            }

            //判断现金券是否有效
            if (entCashTicket.CheckState != 0)
            {
                WebUtility.ShowMsg("该现金券已无效!");
                return;
            }


            //检测该现金券是否重复申请兑现
            dalApplications.Parameters.Append("@SerialNum", ticketSerialNum);
            dalApplications.Parameters.Append("@ValidCode", ticketValidCode);
            if (dalApplications.Exist("SerialNum=@SerialNum and ValidCode=@ValidCode"))
            {
                WebUtility.ShowMsg("该现金券已被使用,如需帮助请致电与我们联系!");
                return;
            }

            var corp = corporationDAL.GetEntity(entCashTicket.CorpID);
            if (corp == null)
            {
                WebUtility.ShowMsg("商家不存在！");
                return;
            }

            entCashTicket.CheckState = 1;
            dalCashTickets.Update(entCashTicket);


            ADeeWu.HuoBi3J.Model.CT_CashTicketApplications entityApplication = new ADeeWu.HuoBi3J.Model.CT_CashTicketApplications();

            long realBusinessUserID = this.GetRealBusinessUserID();

            entityApplication.UserID = realBusinessUserID;
            entityApplication.ModifyTime = DateTime.Now;
            entityApplication.CreateTime = DateTime.Now;
            entityApplication.CorpName = corp.CorpName;
            entityApplication.CostDate = DateTime.Now;
            entityApplication.SerialNum = ticketSerialNum;
            entityApplication.ValidCode = ticketValidCode;
            entityApplication.CheckState = 1;
            entityApplication.ReturnMoney = Utility.GetDecimal(entCashTicket.Money, 0);
            entityApplication.Summary = string.Format("于{0}兑换现金券，消费商家：{1}，金额为：{2}", DateTime.Now, entityApplication.CorpName, entityApplication.ReturnMoney);


            entityApplication.CorpID = entCashTicket.CorpID;
            entityApplication.CashTicketID = entCashTicket.ID;

            if (dalApplications.Add(entityApplication) > 0)
            {
                //ADeeWu.HuoBi3J.Libary.WebUtility.ShowPageSelector(this,"已提交申请,管理员将尽快为你处理!继续申请现金券兑现请选择\"是\"","Application.aspx","Default.aspx");

                db.Parameters.Append("@UserID", entityApplication.UserID);
                db.Parameters.Append("@Money", ADeeWu.HuoBi3J.Libary.Utility.GetDecimal(entityApplication.ReturnMoney, 0));
                db.Parameters.Append("@IsPayment", false);
                db.Parameters.Append("@Notes", "现金券兑现申请通过审核返还金额");
                db.Parameters.Append("@ErrorMessage", "", ParameterDirection.Output, DbType.String).Size = 1000;

                db.AutoClearParameters = false;

                if (ADeeWu.HuoBi3J.Libary.Utility.GetInt(db.RunProc("SP_User_DoDeal"), -1) != 0)
                {
                    WebUtility.ShowMsg("自动充值失败,请到用户帐户管理进行相应的操作!\\r\\n" + db.Parameters["@ErrorMessage"].Value.ToString());
                    return;
                }

                WebUtility.ShowMsg(this, "兑换成功！", Request.RawUrl);
                return;
            }
        }
    }
}

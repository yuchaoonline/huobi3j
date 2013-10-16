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
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.Web.Cashtickets
{
    public partial class Default : ADeeWu.HuoBi3J.Web.Class.PageBase
    {
        ADeeWu.HuoBi3J.DAL.CT_CashTicketApplications dalApplications = new ADeeWu.HuoBi3J.DAL.CT_CashTicketApplications();
        ADeeWu.HuoBi3J.DAL.CT_CashTickets dalCashTickets = new ADeeWu.HuoBi3J.DAL.CT_CashTickets();

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                if (this.LoginUser == null)
                {
                    this.btnSubmit.Visible = false;
                    this.linkTips.Visible = true;
                }
                else
                {
                    this.btnSubmit.Visible = true;
                    this.linkTips.Visible = false;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (this.LoginUser == null)
            {
                Class.Tips tips = new ADeeWu.HuoBi3J.Web.Class.Tips("登陆超时", "请重新登陆继续操作", "", "");
                Class.Tips.SetTips(tips);
                Class.Tips.Show();
                return;
            }

            string corpName = this.txtCorpName.Text.Trim();
            string strCostMoney = this.txtCostMoney.Text.Trim();
            string strCostMoney2 = this.txtCostMoney2.Text.Trim();

            string costDate = this.txtCostDate.Text.Trim();
            string ticketSerialNum = this.txtCashTicketSerialNum.Text.Trim();
            string ticketValidCode = this.txtCashTicketValidCode.Text.Trim();
            string summary = WebUtility.GetTextAreaContent(this.txtSummary.Text);

            //if (corpName == "")
            //{
            //    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写现金券所属商家!");
            //    return;
            //}

            if (strCostMoney == "")
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写消费金额!");
                return;
            }
            if (strCostMoney2 == "")
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写确认消费金额!");
                return;
            }

            if (strCostMoney != strCostMoney2)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("两次输入消费金额不一致!");
                return;
            }

            decimal costMoney = ADeeWu.HuoBi3J.Libary.Utility.GetDecimal(strCostMoney, 0);
            if (costMoney <= 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写正确的消费金额!");
                return;
            }


            if (costDate == "")
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写消费日期!");
                return;
            }
            if (ticketSerialNum == "")
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写现金券序列号!");
                return;
            }
            if (ticketValidCode == "")
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写现金券序验证码(密码)!");
                return;
            }

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
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("该现金券已无效!");
                return;
            }


            //检测该现金券是否重复申请兑现
            if (dalApplications.Exist(new string[] { "SerialNum", "ValidCode" }, ticketSerialNum, ticketValidCode))
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("该现金券已被使用,如需帮助请致电与我们联系!");
                return;
            }


            ADeeWu.HuoBi3J.Model.CT_CashTicketApplications entityApplication = new ADeeWu.HuoBi3J.Model.CT_CashTicketApplications();

            entityApplication.UserID = LoginUser.UserID;
            entityApplication.ModifyTime = DateTime.Now;
            entityApplication.CreateTime = DateTime.Now;
            entityApplication.CorpName = corpName;
            entityApplication.CostDate = DateTime.Parse(costDate);
            entityApplication.SerialNum = ticketSerialNum;
            entityApplication.ValidCode = ticketValidCode;
            entityApplication.Summary = summary;

            entityApplication.CorpID = entCashTicket.CorpID;
            entityApplication.CashTicketID = entCashTicket.ID;

            if (dalApplications.Add(entityApplication) > 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "已提交申请,管理员将尽快为你处理!");
            }
        }
    }

}

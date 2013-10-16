using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.Web.Admin.CashTicketApplications
{
    public partial class Edit : PageBase
    {

        public override string PageID
        {
            get
            {
                return "004002";
            }
        }

        DataBase db = DataBase.Create();
        ADeeWu.HuoBi3J.DAL.Corporations dalCorp = new ADeeWu.HuoBi3J.DAL.Corporations();
        ADeeWu.HuoBi3J.DAL.CT_CashTicketApplications dalApplication = new ADeeWu.HuoBi3J.DAL.CT_CashTicketApplications();
        ADeeWu.HuoBi3J.DAL.CT_CashTickets dalCashTicket = new ADeeWu.HuoBi3J.DAL.CT_CashTickets();

        long id = 0;
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            id = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("id", 0);
            if (id < 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("错误参数传递!");
                return;
            }

            if (!IsPostBack)
            {
                DataTable dtData = db.Select("select * from vw_CT_CashTicketApplications3 where ID={0}", id);
                


                if (dtData.Rows.Count == 0)
                {
                    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "没有找到数据");
                    return;
                }


                DataRow drData = dtData.Rows[0];
                long userId = Utility.GetLong(drData["UserID"], 0);

                this.hrefViewCashTicket.NavigateUrl = "../CashTickets/Edit.aspx?id=" + drData["CashTicketID"].ToString();


                ADeeWu.HuoBi3J.Model.Users entUser = new ADeeWu.HuoBi3J.DAL.Users().GetEntity(userId);
                if (entUser != null)
                {
                    this.litUserName.Text = entUser.LoginName;
                }


                this.litCorpName.Text = drData["RealCorpName"].ToString();
                this.litOfferPercent.Text = drData["OfferPercent"].ToString();




                this.litCashTicketSerialNum.Text = drData["SerialNum"].ToString();
                this.litCashTicketValidCode.Text = drData["ValidCode"].ToString();
                this.litCostDate.Text = string.Format("{0:yyyy-MM-dd}",drData["CostDate"]);
                this.litCreateTime.Text = drData["CreateTime"].ToString();
                this.litModifyTime.Text = drData["ModifyTime"].ToString();
                this.ddlCheckState.SelectedValue = drData["CheckState"].ToString();

                this.txtReturnMoney.Text = drData["ReturnMoney"].ToString();
                this.txtSummary.Text = ADeeWu.HuoBi3J.Libary.WebUtility.ToTextAreaContent(drData["Summary"].ToString());
                this.txtNotes.Text = ADeeWu.HuoBi3J.Libary.WebUtility.ToTextAreaContent(drData["Notes"].ToString());
            }
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {

            string msg = string.Empty;

            int ret = dalApplication.Update(
                  new string[] { "CheckState", "ReturnMoney", "Notes" },
                  new object[] { 
                     this.ddlCheckState.SelectedValue,
                     ADeeWu.HuoBi3J.Libary.Utility.GetDecimal(this.txtReturnMoney.Text,0),
                     ADeeWu.HuoBi3J.Libary.WebUtility.GetTextAreaContent(this.txtNotes.Text)
                 },
                 "ID=" + id
                  );

            if (ret > 0)
            {
                msg = "修改成功!";
            }


            ADeeWu.HuoBi3J.Model.CT_CashTicketApplications entApplication = dalApplication.GetEntity(id);
            
            if (entApplication != null)
            {
                //更新对应现金券状态为通过审核
                if (dalCashTicket.Update("CheckState", 1, "ID = " + entApplication.CashTicketID) <= 0)
                {
                    msg += "修改对应现金券失败,请到现金券管理进行相应的操作!";
                }


               

                
                //虚拟帐号充值
                if (this.ddlCheckState.SelectedValue == "1" && this.chkDoVirtualTransfer.Checked)
                {

                    db.Parameters.Append("@UserID", entApplication.UserID);
                    db.Parameters.Append("@Money", ADeeWu.HuoBi3J.Libary.Utility.GetDecimal(this.txtReturnMoney.Text, 0));
                    db.Parameters.Append("@IsPayment", false);
                    db.Parameters.Append("@Notes", "现金券兑现申请通过审核返还金额");
                    db.Parameters.Append("@ErrorMessage", "", ParameterDirection.Output, DbType.String).Size = 1000;

                    db.AutoClearParameters = false;

                    if (ADeeWu.HuoBi3J.Libary.Utility.GetInt(db.RunProc("SP_User_DoDeal"), -1) != 0)
                    {
                        msg += "自动充值失败,请到用户帐户管理进行相应的操作!\\r\\n" + db.Parameters["@ErrorMessage"].Value.ToString();
                    }
                }

            }
            else
            {
                msg += "该对应的现金券已不存在!";
            }

            ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, msg, "List.aspx");

        }
    }
}

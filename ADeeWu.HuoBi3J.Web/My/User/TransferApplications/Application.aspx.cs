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

namespace ADeeWu.HuoBi3J.Web.My.User.TransferApplications
{
    public partial class _Application : ADeeWu.HuoBi3J.Web.Class.PageBase_MyUser
    {
        public override string FunctionCode
        {
            get
            {
                return "My-User-TransferApplication-Application";
            }
        }

        ADeeWu.HuoBi3J.DAL.Users dalUser = new ADeeWu.HuoBi3J.DAL.Users();
        ADeeWu.HuoBi3J.DAL.User_TransferApplications dalApplication = new ADeeWu.HuoBi3J.DAL.User_TransferApplications();
        ADeeWu.HuoBi3J.Model.Users entUser = null;
        
        protected void Page_Load(object sender, System.EventArgs e)
        {
            long realBusinessUserID = this.GetRealBusinessUserID();

            entUser = dalUser.GetEntity(realBusinessUserID);
            if (entUser == null)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("当前用户数据已被删除!");
                return;
            }
            if (!IsPostBack)
            {
                //检测是否已提交申请转帐
                if (dalApplication.Exist(
                    string.Format("UserID={0} and CheckState <> 1", entUser.ID)
                    ))
                {
                    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("不能重复提交申请,您已提交的申请还没有处理!");
                    this.litMsg.Text = "不能重复提交申请,您已提交的申请还没有处理!";
                    this.btnSubmit.Enabled = false;
                }

                this.litSpareMoney.Text = entUser.Money.ToString() + "元";
                if (entUser.Money >= GlobalParameter.MinTransferMoney)
                {
                    this.litTransferMoney.Visible = false;
                    this.phTxtTransferMoney.Visible = true;
                }
                else
                {
                    this.litTransferMoney.Visible = true;
                    this.phTxtTransferMoney.Visible = false;
                    
                    this.litTransferMoney.Text = string.Format("当前余额不足转帐最低金额:<span style='color:#f00'>{0} </span>元", GlobalParameter.MinTransferMoney);
                    this.btnSubmit.Enabled = false;
                }

                this.txtAlipayAccount.Text = entUser.AlipayAccount;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            decimal num = ADeeWu.HuoBi3J.Libary.Utility.GetDecimal(this.txtTransferMoney.Text, 0m);
            if (num <= 0m)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写正确转帐金额的倍数!");
                return;
            }



            if (entUser.Money < ADeeWu.HuoBi3J.Web.GlobalParameter.MinTransferMoney)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(string.Format("当前余额不足转帐最低金额:{0} 元", GlobalParameter.MinTransferMoney));
                return;
            }

            decimal transferMoney = num * ADeeWu.HuoBi3J.Web.GlobalParameter.MinTransferMoney;

            if (transferMoney > entUser.Money)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(string.Format("转帐金额({0}元)超出当前帐户余额 ({1}元)", transferMoney, entUser.Money));
                return;
            }


            


            string aplipayAccount = this.txtAlipayAccount.Text.Trim();
            string aplipayAccount2 = this.txtAlipayAccount2.Text.Trim();

            if (aplipayAccount == "")
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请输入需要入帐的支付宝帐号!");
                return;
            }

            if (aplipayAccount2 == "")
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请再次输入确认支付宝帐号!");
                return;
            }

            if (aplipayAccount != aplipayAccount2)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("两次支付宝帐号输入不一致!");
                return;
            }




            //检测是否已提交申请转帐
            if (dalApplication.Exist(
                string.Format("UserID={0} and CheckState <> 1", entUser.ID)
                )
                )
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("不能重复提交申请,您已提交的申请还没有处理!");
                this.litMsg.Text = "不能重复提交申请,您已提交的申请还没有处理!";
                return;
            }

            ADeeWu.HuoBi3J.Model.User_TransferApplications entApplication = new ADeeWu.HuoBi3J.Model.User_TransferApplications();
            entApplication.CheckState = 0;
            entApplication.CreateTime = DateTime.Now;
            entApplication.ModifyTime = DateTime.Now;
            entApplication.TransferMoney = transferMoney;
            entApplication.AlipayAccount = aplipayAccount;
            entApplication.UserID = entUser.ID;

            if (dalApplication.Add(entApplication) > 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this,"提交成功,我们将尽快为您处理!如有需要请致电给我们!", "Default.aspx");
            }
            else
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "操作失败,请与我们联系!", "Default.aspx");
            }
        }

    }
}
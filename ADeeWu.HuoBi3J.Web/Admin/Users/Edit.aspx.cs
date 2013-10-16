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

namespace ADeeWu.HuoBi3J.Web.Admin.Users
{
    public partial class Edit : PageBase
    {

        public override string PageID
        {
            get
            {
                return "001002";
            }
        }

        long userID = 0;
        ADeeWu.HuoBi3J.DAL.Users dal = new ADeeWu.HuoBi3J.DAL.Users();

        protected void Page_Load(object sender, EventArgs e)
        {
            userID = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("id", 0);
            if (userID < 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("错误参数传递!");
                return;
            }

            if (!IsPostBack)
            {

                ADeeWu.HuoBi3J.Model.Users ent = dal.GetEntity(userID);
                if (ent == null)
                {
                    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("没有找到数据!");
                    return;
                }

                this.liteUIN.Text = ent.UIN;
                this.liteLoginName.Text = ent.LoginName;
                this.txtAlipayAccount.Text = ent.AlipayAccount;
                this.txtName.Text = ent.Name;
                this.txtTel.Text = ent.Tel;
                this.txtEmail.Text = ent.Email;
                this.liteMoney.Text = ent.Money.ToString();
                this.litLastLogin.Text = ent.LastLogin.ToString();
                this.litLoginTimes.Text = ent.LoginTimes.ToString();
                this.ddlCheckState.SelectedValue = ent.CheckState.ToString();

            }
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {         
            string loginPwd = this.txtLoginPwd.Text.Trim();
            string alipayAccount = this.txtAlipayAccount.Text.Trim();
            string name = this.txtName.Text.Trim();
            string tel = this.txtTel.Text.Trim();
            string email = this.txtEmail.Text.Trim();
           
            int checkState = int.Parse(this.ddlCheckState.SelectedValue);



            ADeeWu.HuoBi3J.Model.Users user = dal.GetEntity(userID);
            user.Name = name;
            user.Tel = tel;
            user.Email = email;
            user.CheckState = checkState;
            user.AlipayAccount = alipayAccount;
            if (loginPwd != "")
            {
                user.LoginPwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(loginPwd, "md5");
            }
           
            if (dal.Update(user) > 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowPageSelector(this, "修改成功!选择\"是\"继续操作!", "#", "list.aspx");
            }
            else
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "修改失败!");
            }
        }
    }
}

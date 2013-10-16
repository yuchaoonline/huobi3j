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

namespace ADeeWu.HuoBi3J.Web.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string validateCode = Session["CheckCode"] as string;
            if (validateCode == null)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("验证码丢失,请重新点击验证码图片!");
                return;
            }

            if (txtValidCode.Text.ToLower() != validateCode.ToLower())
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("验证码输入错误!");
                return;
            }

            string pwdMd5 = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(this.txtPwd.Text.Trim(), "md5");

            ADeeWu.HuoBi3J.DAL.Admin_Users dal = new ADeeWu.HuoBi3J.DAL.Admin_Users();

            ADeeWu.HuoBi3J.Model.Admin_Users user = dal.GetEntity(new string[] { "LoginName"}, txtLoginName.Text.Trim());
            if (user == null)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "用户名或密码错误!", "Login.aspx");
                return;
            }

            UserSession.SaveSession(new UserSession(user.ID, user.LoginName));


            user.LoginTimes++;
            user.LastLogin = DateTime.Now;

            dal.Update(user);//更新用户登陆次数,上一次登陆时间

            Session["IsAdmin"] = true;

            string returnUrl = ADeeWu.HuoBi3J.Libary.Utility.GetStr(Request.QueryString["url"]);
            if (returnUrl != "")
            {
                Response.Redirect("Default.aspx?url=" + Server.UrlDecode(returnUrl));
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
}

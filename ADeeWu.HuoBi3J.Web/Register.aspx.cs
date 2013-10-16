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
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Libary;
using System.Text.RegularExpressions;


namespace ADeeWu.HuoBi3J.Web
{
    public partial class Register : ADeeWu.HuoBi3J.Web.Class.PageBase
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                this.revEmail.ValidationExpression = ADeeWu.HuoBi3J.Libary.Validator.EmailPattern;

                string agentLoginName = WebUtility.GetRequestStr("agent", "");//营销代理商推广链接
                if (!string.IsNullOrWhiteSpace(agentLoginName))
                {
                    var cookie = new HttpCookie("agent", agentLoginName);
                    Response.Cookies.Add(cookie);
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ADeeWu.HuoBi3J.DAL.Users dal = new ADeeWu.HuoBi3J.DAL.Users();
            DataBase db = DataBase.Create();

            string loginName = this.txtLoginName.Text.Trim();
            string pwd = this.txtLoginPwd.Text.Trim();
            string pwd2 = this.txtLoginPwd2.Text.Trim();
            string alipayAccount = string.Empty;
            string name = this.txtName.Text.Trim();
            string email = this.txtEmail.Text.Trim();
            string tel = this.txtTel.Text.Trim();

            if (radSelMySelf.Checked)
            {
                if (fhUIN.Value.Trim().Length == 0)
                {
                    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请选择通讯号码!");
                    return;
                }
            }

            if (loginName.Length > 0)
            {
                if (!Regex.IsMatch(loginName, @"^[\d\w_]{6,12}$"))
                {
                    WebUtility.ShowMsg(this, "登陆帐号输入不正确,应由大小写字母、数字或下划线组成，长度不能少于6个字符长度且不能大于12个字符");
                    return;
                }

                if (Regex.IsMatch(loginName, @"^\d+$"))
                {
                    WebUtility.ShowMsg(this, "登陆帐号不能全为数字");
                    return;
                }

                if (ADeeWu.HuoBi3J.Libary.Validator.Validate(Validator.ValidationType.Email, loginName))
                {
                    WebUtility.ShowMsg(this, "登陆帐号不能使用Email地址!");
                    return;
                }

                //帐号验证由存储过程实现
                if (dal.Exist("LoginName", loginName))
                {
                    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("该用户帐号已存在!");
                    return;
                }
            }
            else
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("用户帐号不能为空!");
                return;
            }

            if (pwd == "")
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请输入登陆密码!");
                return;
            }

            if (pwd2 == "")
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请输入登陆确认密码!");
                return;
            }

            if (pwd != pwd2)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("两次输入密码不一致!");
                return;
            }

            if (email.Length > 0)
            {
                if (!ADeeWu.HuoBi3J.Libary.Validator.Validate(Validator.ValidationType.Email, email))
                {
                    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请输入有效的Email地址!");
                    return;
                }

                if (dal.Exist("Email", email))
                {
                    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("该Email已被注册使用,请重新填写!");
                    return;
                }
            }

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

            //if (alipayAccount == "")
            //{
            //    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请输入支付宝帐号!");
            //    return;
            //}

            //if (name == "")
            //{
            //    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请输入姓名!");
            //    return;
            //}

            string pwdMd5 = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(pwd, "md5");

            db.Parameters.Append("@LoginName", loginName);
            db.Parameters.Append("@LoginPwd", pwdMd5);
            db.Parameters.Append("@AlipayAccount", alipayAccount);
            db.Parameters.Append("@Name", name);
            db.Parameters.Append("@Tel", tel);
            db.Parameters.Append("@Email", email);
            db.Parameters.Append("@LastLogin", DateTime.Now);
            db.Parameters.Append("@RegTime", DateTime.Now);
            db.Parameters.Append("@UIN", this.fhUIN.Value);
            db.Parameters.Append("@AutoUIN", this.radSelMySelf.Checked ? 0 : 1);
            db.Parameters.Append("@ReturnUIN", "", ParameterDirection.Output, DbType.String).Size = 20;
            db.Parameters.Append("@ErrorMessage", "", ParameterDirection.Output, DbType.String).Size = 1000;

            db.AutoClearParameters = false;
            if (ADeeWu.HuoBi3J.Libary.Utility.GetInt(db.RunProc("SP_User_Register"), -1) == 0)
            {

                Class.UserSession.Logout();

                this.LoginUser = Class.UserSession.Login(db.Parameters["@ReturnUIN"].Value.ToString(), pwd, DateTime.Now);

                //登记代理商推广痕迹
                var cookie = Request.Cookies["agent"];
                if (cookie != null)
                {
                    string agentUIN = cookie.Value;
                    if (agentUIN.Length > 0)
                    {
                        //检测用户是否存在
                        Model.Users entAgent = dal.GetEntity(new string[] { "UIN" }, agentUIN);
                        if (entAgent != null)
                        {
                            //判断是否存在该代理商，或该代理是否已通过审核
                            if (db.Exist("select ID from CA_QualifiedAgents where UserID={0} and CheckState=1", entAgent.ID))
                            {
                                DAL.CA_QualifiedAgentBusiness dalAgentBus = new ADeeWu.HuoBi3J.DAL.CA_QualifiedAgentBusiness();
                                Model.CA_QualifiedAgentBusiness entAgentBus = new ADeeWu.HuoBi3J.Model.CA_QualifiedAgentBusiness();
                                entAgentBus.CustomerCorpID = 0;
                                entAgentBus.CustomerUserID = this.LoginUser.UserID;//当前应该已自动登陆新注册帐户
                                entAgentBus.AgentUserID = entAgent.ID;
                                entAgentBus.CreateTime = DateTime.Now;
                                dalAgentBus.Add(entAgentBus);

                                cookie.Expires = DateTime.Now.AddDays(-1);
                                Response.Cookies.Add(cookie);
                            }
                        }
                    }
                }

                if (this.chkRegCorp.Checked)
                {
                    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "注册成功!", "/RegCorporations.aspx?agent=" + Server.UrlEncode(Request["agent"] + ""));
                }
                else
                {
                    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "注册成功!", "/My/User");
                }
            }
            else
            {
                this.fhUIN.Value = "";
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("操作失败!");
                db.Logger.Log(
                    string.Format(@"执行存储过程时发生错误 {0}
URL:{1}
错误信息:{2}
", DateTime.Now, Request.Url.ToString(), db.Parameters["@ErrorMessage"].Value)
 );
                //ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("操作失败!错误原因:\r\n" + db.Parameters["@ErrorMessage"].Value.ToString());
            }
            db.Parameters.Clear();
            db.AutoClearParameters = true;



        }


    }
}

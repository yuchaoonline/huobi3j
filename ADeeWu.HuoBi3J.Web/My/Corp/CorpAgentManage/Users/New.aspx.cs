using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADeeWu.HuoBi3J.SQL;
using System.Data;
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.Web.My.Corp.CorpAgentManage.Users
{
    /// <summary>
    /// 商家代表添加页,在注册新的商家代表的同时设置用户所属的角色
    /// </summary>
    public partial class New : Class.PageBase_MyCorp
    {

        DataBase db = DataBase.Create();
        DAL.Users dalUser = new ADeeWu.HuoBi3J.DAL.Users();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.revEmail.ValidationExpression = ADeeWu.HuoBi3J.Libary.Validator.EmailPattern;
               
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string loginName = this.txtLoginName.Text.Trim();
            string pwd = this.txtLoginPwd.Text.Trim();
            string pwd2 = this.txtLoginPwd2.Text.Trim();
            string alipayAccount = string.Empty;
            string name = this.txtName.Text.Trim();
            string email = this.txtEmail.Text.Trim();
            string tel = this.txtTel.Text.Trim();
            string[] location = this.syncSelectorLocation.Values;
            long provinceID = Utility.GetLong(location[0], 0);
            long cityID = Utility.GetLong(location[1], 0);
            long areaID = Utility.GetLong(location[2], 0);

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


            if (email == "")
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请输入有效的Email地址!");
                return;
            }

            //if (tel == "")
            //{
            //    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请输入联系电话!");
            //    return;
            //}

            if (radSelMySelf.Checked)
            {
                if (this.txtUIN.Text.Trim().Length == 0)
                {
                    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请选择通讯号码!");
                    return;
                }
            }


            //帐号验证由存储过程实现
            if (loginName.Length >= 6 && loginName.Length <= 12)
            {
                if (dalUser.Exist("LoginName", loginName))
                {
                    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("该用户帐号已存在!");
                    return;
                }
            }


            if (email == "")
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请输入有效的Email地址!");
                return;
            }
            if (dalUser.Exist("Email", email))
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("该Email已被注册使用,请重新填写!");
                return;
            }

            string pwdMd5 = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(pwd, "md5");


            db.Parameters.Append("@LoginName", loginName);
            db.Parameters.Append("@LoginPwd", pwdMd5);
            db.Parameters.Append("@AlipayAccount", alipayAccount);
            db.Parameters.Append("@Name", name);
            db.Parameters.Append("@Tel", tel);
            db.Parameters.Append("@Email", email);
            db.Parameters.Append("@LastLogin", DateTime.Now);
            db.Parameters.Append("@RegTime", DateTime.Now);
            db.Parameters.Append("@UIN", this.txtUIN.Text);
            db.Parameters.Append("@AutoUIN", this.radSelMySelf.Checked ? 0 : 1);
            db.Parameters.Append("@AgentCorpID", this.LoginUser.CorpID);
            db.Parameters.Append("@ManageProvinceID", provinceID);
            db.Parameters.Append("@ManageCityID", cityID);
            db.Parameters.Append("@ManageAreaID", areaID);
            db.Parameters.Append("@ErrorMessage", "", ParameterDirection.Output, DbType.String).Size = 1000;

            db.AutoClearParameters = false;
            if (ADeeWu.HuoBi3J.Libary.Utility.GetInt(db.RunProc("SP_CorpAgent_Register"), -1) == 0)
            {
                WebUtility.ShowMsg(this, "操作成功!", "default.aspx");
            }
            else
            {
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

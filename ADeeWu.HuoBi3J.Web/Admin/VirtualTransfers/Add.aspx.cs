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
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using ADeeWu.HuoBi3J.SQL;

namespace ADeeWu.HuoBi3J.Web.Admin.VirtualTransfers
{
    public partial class Add : PageBase
    {

        public override string PageID
        {
            get
            {
                return "007001";
            }
        }

        ADeeWu.HuoBi3J.DAL.Users dalUsers = new ADeeWu.HuoBi3J.DAL.Users();
        DataBase db = DataBase.Create();

        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                //this.ddlUsers.DataSource = dalUsers.Select(-1, -1);
                //this.ddlUsers.DataTextField = "LoginName";
                //this.ddlUsers.DataValueField = "ID";
                //this.ddlUsers.DataBind();
            }

          
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            //long userID = ADeeWu.HuoBi3J.Libary.Utility.GetInt(this.ddlUsers.SelectedValue, 0);
            string uin = ADeeWu.HuoBi3J.Libary.Utility.GetStr(this.txtUIN.Text.Trim());

            string notes = ADeeWu.HuoBi3J.Libary.WebUtility.GetTextAreaContent(this.txtNotes.Text).Trim();
            decimal money = ADeeWu.HuoBi3J.Libary.Utility.GetDecimal(this.txtMoney.Text, 0);



            if (uin.Length <= 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请选择需要充值的会员!");
                return;
            }

            DAL.IM_Users dalIM_Users = new ADeeWu.HuoBi3J.DAL.IM_Users();
            dalIM_Users.Parameters.Append("@UIN", uin);
            Model.IM_Users entIMUser = dalIM_Users.GetEntity("UIN=@UIN");
            if (entIMUser == null)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("IM帐号不存在!");
                return;
            }


            if (money <= 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写正确充值金额!");
                return;
            }

            db.Parameters.Append("@UserID", entIMUser.UserID);
            db.Parameters.Append("@Money", money);
            db.Parameters.Append("@IsPayment",false);
            db.Parameters.Append("@Notes", notes);
            db.Parameters.Append("@ErrorMessage", "", ParameterDirection.Output, DbType.String).Size = 1000;

            db.AutoClearParameters = false;

            if (ADeeWu.HuoBi3J.Libary.Utility.GetInt(db.RunProc("SP_User_DoDeal"), -1) == 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowPageSelector(this, "操作成功!选择\"是\"继续操作", "add.aspx", "list.aspx");
            }
            else
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("操作失败!错误原因:\r\n" + db.Parameters["@ErrorMessage"].Value.ToString());
            }
            db.Parameters.Clear();
            db.AutoClearParameters = true;

        }

    }
}

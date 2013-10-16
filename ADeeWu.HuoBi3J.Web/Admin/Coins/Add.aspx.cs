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
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.Web.Admin.Coins
{
    public partial class Add : PageBase
    {

        public override string PageID
        {
            get
            {
                return "009001";
            }
        }

        DataBase db = DataBase.Create();
        ADeeWu.HuoBi3J.DAL.Users dalUsers = new ADeeWu.HuoBi3J.DAL.Users();


        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {

            }

          
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            long uin = ADeeWu.HuoBi3J.Libary.Utility.GetInt(this.txtUIN.Text, 0);
            string notes = ADeeWu.HuoBi3J.Libary.WebUtility.GetTextAreaContent(this.txtNotes.Text).Trim();
            int coins = ADeeWu.HuoBi3J.Libary.Utility.GetInt(this.txtMoney.Text, 0);



            if (uin <= 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("UIN号码必须为纯数字！");
                return;
            }


            if (coins <= 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写正确货币数量!");
                return;
            }

            Model.Users user = new DAL.Users().GetEntity(string.Format("uin = '{0}'", uin));
            if (user == null || user.ID == 0)
            {
                WebUtility.ShowMsg("不存在此UIN号码！");
                return;
            }

            db.Parameters.Append("@UserID", user.ID);
            db.Parameters.Append("@Coins", coins);
            db.Parameters.Append("@IsUseCoin", false);
            db.Parameters.Append("@Notes", notes);
            db.Parameters.Append("@ErrorMessage", "", ParameterDirection.Output, DbType.String).Size = 1000;

            db.AutoClearParameters = false;
            if (ADeeWu.HuoBi3J.Libary.Utility.GetInt(db.RunProc("SP_User_DoCoinsTrans"), -1) == 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowPageSelector(this, "操作成功!选择\"是\"继续操作", "Add.aspx", "list.aspx");
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

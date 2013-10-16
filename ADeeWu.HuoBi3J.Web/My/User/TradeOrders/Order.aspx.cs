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
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;

namespace ADeeWu.HuoBi3J.Web.My.User.TradeOrders
{
    public partial class Order : Class.PageBase_MyUser
    {

        public override string FunctionCode
        {
            get
            {
                return "My-User-TradeOrders-Order";
            }
        }

        DataBase db = DataBase.Create();

        protected void Page_Load(object sender, EventArgs e)
        {
             
        }
      
       
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            decimal totalFee = Utility.GetDecimal(this.txtMoney.Text, 0);
            if (totalFee <= 0)
            {
                WebUtility.ShowMsg(this, "请填写正确的充值金额！");
                return;
            }
          
            
    //            @UserID bigint , 
    //@TotalFee decimal(6,1),
    //@Notes nvarchar(500) = N'',
    //@NewOrderCode nvarchar(20) output

            string notes = string.Format("通过支付宝在线充值帐户金额,金额:{0}元",totalFee);

            db.Parameters.Append("@UserID", this.LoginUser.UserID);
            db.Parameters.Append("@TotalFee", totalFee);
            db.Parameters.Append("@Notes", notes);
            db.Parameters.Append("@NewOrderCode", "", ParameterDirection.Output, DbType.String).Size = 20;
            db.Parameters.Append("@ReturnValue", 1).Direction = ParameterDirection.ReturnValue;

            db.AutoClearParameters = false;
            db.RunProc("SP_TradeSystem_DoAlipayTrade");
            int returnValue = Utility.GetInt(db.Parameters["@ReturnValue"].Value, 0);
            if (returnValue == 0)
            {
                string orderCode = Utility.GetStr(db.Parameters["@NewOrderCode"].Value, "");
                this.liteOrderCode.Text = orderCode;
                this.liteTotalFee.Text = string.Format("{0:0.00}", totalFee);
                this.phResult.Visible = true;
                this.phForm.Visible = false;
            }
            else
            {
                this.phResult.Visible = false;
                this.phForm.Visible = true;
                WebUtility.ShowMsg(this, "操作失败，请稍后再试或直接与我们联系！");
            }

            db.AutoClearParameters = true;
            db.Parameters.Clear();
        }

    }
}


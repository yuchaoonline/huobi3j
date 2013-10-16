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
using ADeeWu.HuoBi3J.SQL;

namespace ADeeWu.HuoBi3J.Web.My.User.Coins
{
    public partial class Purchase : Class.PageBase_MyUser
    {
        public override string FunctionCode
        {
            get
            {
                return "My-User-Coins-Purchase";
            }
        }
        
        private DataBase db = DataBase.Create();
        private ADeeWu.HuoBi3J.DAL.Users dalUser = new ADeeWu.HuoBi3J.DAL.Users();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ADeeWu.HuoBi3J.Model.Users ent = dalUser.GetEntity(this.GetRealBusinessUserID());
                this.liteBalance.Text = ent.Money.ToString();
                this.liteNumOfCoins.Text = ent.Coins.ToString();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int timesOfCoins = ADeeWu.HuoBi3J.Libary.Utility.GetInt(this.txtTimesOfCoins.Text, 0);
            if (timesOfCoins <= 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "购买货币数量倍数输入错误,请填写正确的正整数");
                return;
            }

            long realBusinessUserID = this.GetRealBusinessUserID();

            decimal money = (decimal)timesOfCoins;
            int coins = timesOfCoins * ADeeWu.HuoBi3J.Web.GlobalParameter.MoneyToCoinsRate;
            string notesForCoins = string.Format("以 1:{0}的金额兑换货币率购买货币 {1} 个", ADeeWu.HuoBi3J.Web.GlobalParameter.MoneyToCoinsRate, coins);
            string notesForMoney = notesForCoins;

            db.Parameters.Append("@UserID", realBusinessUserID);
            db.Parameters.Append("@Money",money);
            db.Parameters.Append("@Coins", coins);
            db.Parameters.Append("@NotesForCoins", notesForCoins);
            db.Parameters.Append("@NotesForMoney", notesForMoney);
            db.Parameters.Append("@ErrorMessage", "", ParameterDirection.Output);
            int ret = ADeeWu.HuoBi3J.Libary.Utility.GetInt(db.RunProc("SP_User_MoneyToCoins"), 0);
            if (ret == 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "操作成功!",".");
            }
            else
            {
                db.Logger.Log(
                    string.Format("用户:{0} 通过比率: 1元={1}个货币 购买{2}x{1}个货币操作失败,原因:\r\n{3}", this.LoginUser.UIN, GlobalParameter.MoneyToCoinsRate, timesOfCoins, db.Parameters["ErrorMessage"])
                    );
            }

            //[dbo].[SP_User_MoneyToCoins]
            //@UserID bigint,             -- 操作的用户帐号ID
            //@Money decimal(6,1),        -- 扣费的金额
            //@Coins int,                 -- 购买货币的数量
            //@NotesForCoins nvarchar(1000),      -- 购买货币备注信息
            //@NotesForMoney nvarchar(1000),      -- 帐户金额交易备注信息
            //@ErrorMessage nvarchar(100) output -- 返回错误消息
        }
    }
}

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

namespace ADeeWu.HuoBi3J.Web.My.Corp.Promotions.Keywords
{
    public partial class Edit : Class.PageBase_MyCorp_Promotions
    {

        public override string FunctionCode
        {
            get
            {
                return "Corp-Promotions-Keywords-Edit";
            }
        }

        DAL.CP_Keywords dal = new ADeeWu.HuoBi3J.DAL.CP_Keywords();
        DataBase db = DataBase.Create();
        long id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("id", 0);
            if (!IsPostBack)
            {
                Model.CP_Keywords mod = dal.GetEntity(new string[] { "ID", "PromotionID" }, id, this.LoginUser.PromotionID);
                if (mod == null) Response.Redirect(".");

                this.txtCoins.Text = mod.Coins.ToString();
                this.txtKeyword.Text = mod.Keyword;
                this.liteVisitCount.Text = mod.VisitCount.ToString();
                db.Parameters.Append("@keyword", mod.Keyword);
                this.liteTopCoins.Text = ADeeWu.HuoBi3J.Libary.Utility.GetInt(db.ExecuteScalar("select top 1 coins from CP_Keywords where keyword=@keyword order by coins desc"), 0).ToString();
                
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string keyword = this.txtKeyword.Text.Trim();
            int coins = ADeeWu.HuoBi3J.Libary.Utility.GetInt(this.txtCoins.Text, 0);
            if (keyword.Length == 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "请填写关键字!");
                return;
            }
            if (coins < 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "请填写正确的竞价货币数值!");
                return;
            }


            Model.CP_Keywords mod = dal.GetEntity(id);
            //mod.Keyword = this.txtKeyword.Text.Trim();
            mod.Coins = coins;
            //mod.CorpID = this.LoginUser.CorpID;
            //mod.UserID = this.LoginUser.UserID;
            //mod.CreateTime = DateTime.Now;
            mod.ModifyTime = DateTime.Now;
            mod.CheckState = 0;//修改后需要重新审核
            //mod.VisitCount = 0;
            if (dal.Update(mod) > 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "添加成功");
            }
            else
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "操作失败!请与我们联系!");
            }

        }
    }
}

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

namespace ADeeWu.HuoBi3J.Web.Admin.CP_Keywords
{
    public partial class Edit : PageBase
    {


        public override string PageID
        {
            get
            {
                return "011002";
            }
        }

        ADeeWu.HuoBi3J.DAL.Admin_Users dalAdminUser = new ADeeWu.HuoBi3J.DAL.Admin_Users();
        ADeeWu.HuoBi3J.DAL.Corporations dalCorp = new ADeeWu.HuoBi3J.DAL.Corporations();
        ADeeWu.HuoBi3J.DAL.CP_Keywords dalKeyword = new ADeeWu.HuoBi3J.DAL.CP_Keywords();
        ADeeWu.HuoBi3J.DAL.CP_Promotions dalPromotion = new ADeeWu.HuoBi3J.DAL.CP_Promotions();

        protected long id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("id", 0);
            if (id <= 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "错误参数传递", "list.aspx");
                return;
            }
            
            if (!IsPostBack)
            {

                ADeeWu.HuoBi3J.Model.CP_Keywords entity = dalKeyword.GetEntity(id);
                if (entity == null)
                {
                    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "没有找到相关记录", "list.aspx");
                    return;
                }

                this.liteKeyword.Text = entity.Keyword;
                this.liteCoins.Text = entity.Coins.ToString();
                this.liteVisitCount.Text = entity.VisitCount.ToString();
                this.litCrateTime.Text = entity.CreateTime.ToString();
                this.litModifyTime.Text = entity.ModifyTime.ToString();


                ADeeWu.HuoBi3J.Model.CP_Promotions entityPromotion = dalPromotion.GetEntity(entity.PromotionID);
                this.liteTitle.Text = entityPromotion.Title;
                this.liteSummary.Text = ADeeWu.HuoBi3J.Libary.WebUtility.ToTextAreaContent(entityPromotion.Summary);
                this.liteURL.Text = entityPromotion.Url;
                this.ddlCheckState.SelectedValue = entity.CheckState.ToString();



                ADeeWu.HuoBi3J.Model.Corporations corp = dalCorp.GetEntity(entityPromotion.CorpID);
                if (corp != null)
                {
                    this.liteCorpCalling.Text = corp.Calling;
                    this.liteCorpName.Text = corp.CorpName;
                }
                


               
            }

        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {

            if (dalKeyword.Update("CheckState", this.ddlCheckState.SelectedValue, "ID=" + id) > 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "操作成功!", "Edit.aspx?id=" + id);
            }
        }

    }
}

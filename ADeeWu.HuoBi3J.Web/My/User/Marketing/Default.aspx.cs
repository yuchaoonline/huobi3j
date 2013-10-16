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

namespace ADeeWu.HuoBi3J.Web.My.User.Marketing
{
    public partial class Default : ADeeWu.HuoBi3J.Web.Class.PageBase_MyUser
    {

        public override string FunctionCode
        {
            get
            {
                return "My-User-Marketing-Default";
            }
        }

        ADeeWu.HuoBi3J.DAL.Market_Infos dal = new ADeeWu.HuoBi3J.DAL.Market_Infos();
        ADeeWu.HuoBi3J.Model.Market_Infos entity;
         
        protected void Page_Load(object sender, EventArgs e)
        {
            
            bool flag = false;
            if(!IsPostBack)
            {
                long realBusinessUserID = this.GetRealBusinessUserID();
                entity = dal.GetEntity(new string[] { "UserID" }, realBusinessUserID);
                if (entity != null)
                {
                    flag = true;

                    this.txtContent.Text = WebUtility.ToTextAreaContent(entity.Content);
                    this.txtSummary.Text = entity.Summary;
                    this.txtTitle.Text = entity.Title;
                    this.syncSelectorMarketCategories.SelectedValue = entity.MarketCategoryID.ToString();
                    this.ddlBusinessType.SelectedValue = entity.BusinessType.ToString();

                    lblUpdateTime.Text =entity.ModifyTime.ToString("yyyy-MM-dd HH:mm:ss").Trim();
                    lblCreateTime.Text =entity.CreateTime.ToString("yyyy-MM-dd HH:mm:ss").Trim();
                    lblReTime.Text =entity.RefreshTime.ToString("yyyy-MM-dd HH:mm:ss").Trim();
                   
                }
                tr_createtime.Visible = flag;
                tr_creftime.Visible = flag;
                tr_updatatime.Visible = flag;
                
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string summary = WebUtility.GetTextAreaContent(this.txtSummary.Text);
            string content = WebUtility.GetTextAreaContent(this.txtContent.Text);
            if (title == "")
            {
               WebUtility.ShowMsg("请填写标题！");
                return;
            }
            if (summary == "")
            {
                WebUtility.ShowMsg("请填写简述！");
                return;
            }
            if (content == "")
            {
                WebUtility.ShowMsg("请填写详细内容！");
                return;
            }


            long realBusinessUserID = this.GetRealBusinessUserID();

            long count = 0;
            entity = dal.GetEntity(new string[] { "UserID" }, realBusinessUserID);
            if (entity == null)
            {
                entity = new ADeeWu.HuoBi3J.Model.Market_Infos();
                entity.CreateTime = DateTime.Now;
                entity.IsHidden = false;
                entity.IsRecommend = false;
                entity.CheckState = 1;//默认通过审核
                entity.UserID = realBusinessUserID;
                entity.VisitCount = 0;
                entity.Content = content;
                entity.MarketCategoryID = Utility.GetLong(this.syncSelectorMarketCategories.SelectedValue, 0);
                entity.ModifyTime = DateTime.Now;
                entity.RefreshTime = DateTime.Now;
                entity.Summary = summary;
                entity.Title = title;
                entity.BusinessType = Utility.GetInt(ddlBusinessType.SelectedValue, 0);
                count = dal.Add(entity);
            }
            else
            {
                
                entity.Content = content;
                entity.MarketCategoryID = Utility.GetLong(this.syncSelectorMarketCategories.SelectedValue, 0);
                entity.ModifyTime = DateTime.Now;
                entity.RefreshTime = DateTime.Now;
                entity.Summary = summary;
                entity.Title = title;
                entity.BusinessType = Utility.GetInt(ddlBusinessType.SelectedValue, 0);
                count = dal.Update(entity);
            }
            if (count > 0)
            {
                WebUtility.ShowMsg("保存成功！");
                
            }
            else
            {
               WebUtility.ShowMsg("保存失败！");

            }
        }
    }
}

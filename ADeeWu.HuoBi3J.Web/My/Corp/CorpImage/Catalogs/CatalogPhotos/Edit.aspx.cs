using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.Web.My.Corp.CorpImage.Catalogs.CatalogPhotos
{
    public partial class Edit : ADeeWu.HuoBi3J.Web.Class.PageBase_MyCorp
    {

        ADeeWu.HuoBi3J.DAL.CI_CatalogPhotos dal = new ADeeWu.HuoBi3J.DAL.CI_CatalogPhotos();
        long id = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("id", 0);
        
        //创建画册对象
        DAL.CI_Catalogs dalAlbums = new ADeeWu.HuoBi3J.DAL.CI_Catalogs();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDDLCatalogsName();

                //获取指定id画册图片信息
                ADeeWu.HuoBi3J.Model.CI_CatalogPhotos entity = dal.GetEntity(new string[] { "ID", "CorpID" }, id, this.LoginUser.CorpID);
                if (entity != null)
                {
                    txtPhotosName.Text = entity.Title;                 
                    txtSequence.Text = entity.Sequence.ToString();
                    IsHidden.Checked = entity.IsHidden;
                    IsRecommend.Checked = entity.IsRecommend;
                    txtSummary.Text = entity.Summary;
                    txtContent.Text = entity.Content;
                    txtURL.Text = entity.URL;
                }

            }
        }

        /// <summary>
        /// 绑定下拉列表所属画册
        /// </summary>
        private void BindDDLCatalogsName()
        {
            this.ddlCatalogsName.DataSource = dalAlbums.Select(-1, -1, "CorpID=" + this.LoginUser.CorpID, "");
            this.ddlCatalogsName.DataTextField = "Title";
            this.ddlCatalogsName.DataValueField = "ID";
            this.ddlCatalogsName.DataBind();
        }

        /// <summary>
        /// 更新画册图片事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>      

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        /// <summary>
        /// 保存画册图片数据
        /// </summary>
        private void SaveData()
        {
            string title = txtPhotosName.Text;
            int sequence = Utility.GetInt(txtSequence.Text.Trim(), 0);
            long catalogsId = Utility.GetLong(ddlCatalogsName.SelectedValue, 0);
            if (string.IsNullOrEmpty(title))
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写图片信息标题!");
                return;
            }
          
            ADeeWu.HuoBi3J.Model.CI_CatalogPhotos photo = dal.GetEntity(new string[] { "ID", "CorpID" }, id, this.LoginUser.CorpID);
            photo.Title = title;           
            photo.Sequence = sequence;
            photo.IsHidden = IsHidden.Checked;
            photo.CatalogsID = catalogsId;
            photo.IsRecommend = IsRecommend.Checked;
            photo.Summary = txtSummary.Text;
            photo.Content = txtContent.Text;
            photo.ModifyTime = DateTime.Now;

            if (IsFace.Checked)/*设置封面*/
            {
                DAL.CI_Catalogs dalCatalog = new ADeeWu.HuoBi3J.DAL.CI_Catalogs();
                Model.CI_Catalogs catalog = dalCatalog.GetEntity(photo.CatalogsID);
                if (catalog != null)
                {
                    catalog.FaceID = photo.ID;
                    dalCatalog.Update(catalog);
                }
            }

            if (dal.Update(photo) > 0)
            {

                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "更新画册图片成功!", "Default.aspx?id="+ catalogsId);
                return;
            }
            else
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "更新画册图片失败!");
            }

        }

    }
}

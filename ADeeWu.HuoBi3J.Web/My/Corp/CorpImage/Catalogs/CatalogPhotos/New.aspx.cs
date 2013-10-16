using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;

namespace ADeeWu.HuoBi3J.Web.My.Corp.CorpImage.Catalogs.CatalogPhotos
{
    public partial class New : ADeeWu.HuoBi3J.Web.Class.PageBase_MyCorp
    {
        DataBase db = DataBase.Create();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDDLCatalogsName();

                this.txtSequence.Text = (Utility.GetInt(db.ExecuteScalar("select count(id) from CI_CatalogPhotos where CorpID=" + this.LoginUser.CorpID), 0) + 1).ToString();

            }
        }

        /// <summary>
        /// 绑定下拉列表所属画册
        /// </summary>
        private void BindDDLCatalogsName()
        {
            DAL.CI_Catalogs catalog = new ADeeWu.HuoBi3J.DAL.CI_Catalogs();
            this.ddlCatalogsName.DataSource = catalog.Select(-1, -1, "CorpID=" + this.LoginUser.CorpID, "");
            this.ddlCatalogsName.DataTextField = "Title";
            this.ddlCatalogsName.DataValueField = "ID";
            this.ddlCatalogsName.DataBind();

        }
        /// <summary>
        /// 新增相册图片事件
        /// </summary>
        /// <param title="sender"></param>
        /// <param title="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SaveData();
        }


        /// <summary>
        /// 发布画册图片信息
        /// </summary>
        private void SaveData()
        {
            string title = this.txtCatalogPhotosName.Text.Trim();
            long catalogsID =Utility.GetLong(ddlCatalogsName.SelectedValue,0);
            int sequence = Utility.GetInt(this.txtSequence.Text.Trim(), 0);
            if (string.IsNullOrEmpty(title))
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写图片信息标题!");
                return;
            }
          
            DAL.CI_CatalogPhotos dalPhoto = new ADeeWu.HuoBi3J.DAL.CI_CatalogPhotos();
            Model.CI_CatalogPhotos photo = new Model.CI_CatalogPhotos();
            photo.CorpID = this.LoginUser.CorpID;
            photo.Title = title;
            photo.Sequence = sequence;
            photo.IsHidden = IsHidden.Checked;
            photo.IsRecommend = IsRecommend.Checked;
            photo.Summary = txtSummary.Text;
            photo.CatalogsID =catalogsID;
            photo.URL = FileUploadEx1.GetUploadedFilePath();

            photo.Content = txtContent.Text;

            photo.CreateTime = DateTime.Now;
            photo.ModifyTime = DateTime.Now;

            if (this.IsFace.Checked)/*设置封面*/
            {
                DAL.CI_Catalogs dalCatalog = new ADeeWu.HuoBi3J.DAL.CI_Catalogs();
                Model.CI_Catalogs entCatalog = dalCatalog.GetEntity(photo.CatalogsID);
                if (entCatalog != null)
                {
                    entCatalog.FaceID = photo.ID;
                    dalCatalog.Update(entCatalog);
                }
            }

            if (dalPhoto.Add(photo) > 0)
            {

                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "发布画册图片成功!", "Default.aspx?id="+catalogsID);
                FileUploadEx1.Save();
                return;
            }
            else
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "发布画册图片失败!");
            }

        }

        

    }
}

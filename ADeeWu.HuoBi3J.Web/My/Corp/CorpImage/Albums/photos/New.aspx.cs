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
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.Web.My.Corp.CorpImage.Albums.Photos
{
    public partial class New : ADeeWu.HuoBi3J.Web.Class.PageBase_MyCorp
    {

        DataBase db = DataBase.Create();

      
        /// <summary>
        /// 加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDDLAlbumsName();

                this.txtSequence.Text = (Utility.GetInt(db.ExecuteScalar("select count(id) from CI_Photos where CorpID=" + this.LoginUser.CorpID), 0) + 1).ToString();
                
            }
        }

        /// <summary>
        /// 绑定下拉列表所属相册
        /// </summary>
        private void BindDDLAlbumsName()
        {
            DAL.CI_Albums dalAlbums = new ADeeWu.HuoBi3J.DAL.CI_Albums();
            this.ddlAlbumsName.DataSource = dalAlbums.Select(-1, -1, "CorpID=" + this.LoginUser.CorpID, "");
                this.ddlAlbumsName.DataTextField = "Title";
                this.ddlAlbumsName.DataValueField = "ID";
                this.ddlAlbumsName.DataBind();

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
        /// 发布相册图片信息
        /// </summary>
        private void SaveData()
        {
            string title = this.txtPhotosName.Text.Trim();
            int sequence = Utility.GetInt(this.txtSequence.Text.Trim(), 0);
            long albumID = Utility.GetLong(this.ddlAlbumsName.SelectedValue, 0);
            if (string.IsNullOrEmpty(title))
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写图片信息标题!");
                return;
            }
            

            
            DAL.CI_Photos dal = new ADeeWu.HuoBi3J.DAL.CI_Photos();
            Model.CI_Photos photo = new Model.CI_Photos();
            photo.CorpID = this.LoginUser.CorpID;
            photo.Title  = title;
            photo.AlbumID = albumID;
            photo.Sequence = sequence;
            photo.IsHidden = IsHidden.Checked;
            photo.IsRecommend = IsRecommend.Checked;
            photo.Summary = txtSummary.Text;
            photo.CreateTime = DateTime.Now;
            photo.ModifyTime = DateTime.Now;
            photo.CheckState = 1;

            photo.URL = FileUploadEx1.GetUploadedFilePath();
           
            photo.Content = txtContent.Text;

            if (this.IsFace.Checked)/*设置封面*/
            {
                DAL.CI_Albums dalAlbum = new ADeeWu.HuoBi3J.DAL.CI_Albums();
                Model.CI_Albums entAlbum = dalAlbum.GetEntity(photo.AlbumID);
                if (entAlbum != null)
                {
                    entAlbum.FaceID = photo.ID;
                    dalAlbum.Update(entAlbum);
                }
            }

            if (dal.Add(photo) > 0)
            {

                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "添加图片成功!", "Default.aspx?id=" + albumID);
                FileUploadEx1.Save();
                return;
            }
            else
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "添加图片失败!");
            }

        }

        

    }
}

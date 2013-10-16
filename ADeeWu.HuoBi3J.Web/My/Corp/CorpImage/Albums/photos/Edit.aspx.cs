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

namespace ADeeWu.HuoBi3J.Web.My.Corp.CorpImage.Albums.Photos
{
    public partial class Edit :ADeeWu.HuoBi3J.Web.Class.PageBase_MyCorp
    {
       ADeeWu.HuoBi3J.DAL.CI_Photos dal = new ADeeWu.HuoBi3J.DAL.CI_Photos();
       long id = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("id", 0);

        //创建相册对象
        DAL.CI_Albums dalAlbums = new ADeeWu.HuoBi3J.DAL.CI_Albums();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDDLAlbumsName();

                ADeeWu.HuoBi3J.Model.CI_Photos entity = dal.GetEntity(new string[] { "ID", "CorpID" }, id, this.LoginUser.CorpID);
                if (entity != null)
                {
                    txtPhotosName.Text = entity.Title;
                    liteCreateTime.Text = entity.CreateTime.ToShortDateString();
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
        /// 绑定下拉列表所属相册
        /// </summary>
        private void BindDDLAlbumsName()
        {
            this.ddlAlbumsName.DataSource = dalAlbums.Select(-1, -1, "CorpID=" + this.LoginUser.CorpID, "");
            this.ddlAlbumsName.DataTextField = "Title";
            this.ddlAlbumsName.DataValueField = "ID";
            this.ddlAlbumsName.DataBind();
        }

        /// <summary>
        /// 更新相册图片事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        /// <summary>
        /// 保存相册图片数据
        /// </summary>
        private void SaveData()
        {
            string title = txtPhotosName.Text;
            int sequence = Utility.GetInt(txtSequence.Text.Trim(), 0);
            long albumID = Utility.GetLong(this.ddlAlbumsName.SelectedValue, 0);

            if (string.IsNullOrEmpty(title))
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写图片信息标题!");
                return;
            }

            ADeeWu.HuoBi3J.Model.CI_Photos photo = dal.GetEntity(new string[] { "ID", "CorpID" }, id, this.LoginUser.CorpID);
            photo.Title = title;
           
            photo.Sequence = sequence;
            photo.IsHidden = IsHidden.Checked;
            photo.IsRecommend = IsRecommend.Checked;
            photo.Summary = txtSummary.Text;
            photo.AlbumID = albumID;
            photo.Content = txtContent.Text;
            photo.ModifyTime = DateTime.Now;

            if(IsFace.Checked)/*设置封面*/
            {
                DAL.CI_Albums dalAlbum = new ADeeWu.HuoBi3J.DAL.CI_Albums();
                Model.CI_Albums entAlbum = dalAlbum.GetEntity(photo.AlbumID);
                if (entAlbum != null )
                {
                    entAlbum.FaceID = photo.ID;
                    dalAlbum.Update(entAlbum);
                }
            }

            if (dal.Update(photo) > 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "更新图片成功!", "Default.aspx?id="+ albumID);
                return;
            }
            else
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "更新图片失败!");
            }
            
        }

    }
}

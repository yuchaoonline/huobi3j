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

namespace ADeeWu.HuoBi3J.Web.My.Corp.CorpImage.Videos
{
    public partial class New :ADeeWu.HuoBi3J.Web.Class.PageBase_MyCorp
    {

        DataBase db = DataBase.Create();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.txtSequence.Text = (Utility.GetInt(db.ExecuteScalar("select count(id) from CI_Videos where CorpID=" + this.LoginUser.CorpID), 0) + 1).ToString();

            }
        }

        /// <summary>
        /// 提交相册事件
        /// </summary>
        /// <param title="sender"></param>
        /// <param title="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        /// <summary>
        /// 发布相册
        /// </summary>
        private void SaveData()
        {
            string title = this.txtTitle.Text.Trim();
           
            int sequence = Utility.GetInt(this.txtSequence.Text.Trim(), 0);
            if (string.IsNullOrEmpty(title))
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写视频标题!");
                return;
            }
           
           
            string videoUrl = string.Empty;
            string previewUrl = string.Empty;

            if (this.rbtnUpload.Checked)//上传视频
            {
                if(!fileVideo.HasFile){
                    WebUtility.ShowMsg(this,"请选择视频！");
                    return;
                }
                if (!fileVideo.ValidFileSize())
                {
                    WebUtility.ShowMsg(this, "上传视频超出限制的文件大小,请重新上传！");
                    return;
                }

                if (!fileVideo.ValidFileExt())
                {
                    WebUtility.ShowMsg(this, "上传视频类型不匹配,只允许上传文件:" + fileVideo.AllowFileExt);
                    return;
                }
                videoUrl = fileVideo.GetUploadedFilePath();
            }
            else if (this.rbtnExternalURL.Checked)//选择网络上的视频
            {
                videoUrl = this.txtExternalURL.Text.Trim();
            }


            if (videoUrl.Length == 0)
            {
                WebUtility.ShowMsg(this, "请选择要发布的视频！");
                return;
            }

            if (!fileVideoPreview.HasFile)
            {
                WebUtility.ShowMsg(this, "请上传视频预览图！");
                return;
            }

            if (!fileVideoPreview.ValidFileExt())
            {
                WebUtility.ShowMsg(this, "上传视频预览图片类型不匹配,只允许上传文件:" + fileVideoPreview.AllowFileExt);
                return;
            }

            if (!fileVideoPreview.ValidFileSize())
            {
                WebUtility.ShowMsg(this, "上传视频预览图片超出限制的文件大小,请重新上传！");
                return;
            }

            previewUrl = fileVideoPreview.GetUploadedFilePath();



            DAL.CI_Videos dal = new ADeeWu.HuoBi3J.DAL.CI_Videos();
            Model.CI_Videos video = new Model.CI_Videos();
            video.CorpID = this.LoginUser.CorpID;
            video.Title = title;
            video.Sequence = sequence;
            video.IsHidden = IsHidden.Checked;
            video.IsRecommend = IsRecommend.Checked;

            video.URL = videoUrl;
            video.PreviewURL = previewUrl;
            video.Summary = WebUtility.GetTextAreaContent(this.txtSummary.Text);
            video.CheckState = 1;
            video.CreateTime = DateTime.Now;
            video.ModifyTime = DateTime.Now;

            if (dal.Add(video) > 0)
            {

                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "发布视频成功!", "Default.aspx");
                
                fileVideo.Save();
                fileVideoPreview.Save();
                return;
            }
            else
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "发布视频失败!");
            }

        }
    }
}

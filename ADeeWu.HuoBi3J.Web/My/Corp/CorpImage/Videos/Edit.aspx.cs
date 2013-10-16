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

namespace ADeeWu.HuoBi3J.Web.My.Corp.CorpImage.Videos
{
    public partial class Edit :ADeeWu.HuoBi3J.Web.Class.PageBase_MyCorp
    {

        ADeeWu.HuoBi3J.DAL.CI_Videos dal = new ADeeWu.HuoBi3J.DAL.CI_Videos();
        long id = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("id", 0);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ADeeWu.HuoBi3J.Model.CI_Videos entity = dal.GetEntity(new string[] { "ID", "CorpID" }, id, this.LoginUser.CorpID);
                if (entity != null)
                {
                    this.txtTitle.Text = entity.Title;
                    this.fileVideo.DefaultValue = entity.URL;
                    this.txtExternalURL.Text = entity.URL;

                    this.fileVideoPreview.DefaultValue = entity.PreviewURL;

                    this.txtSequence.Text = entity.Sequence.ToString();
                    this.IsHidden.Checked = entity.IsHidden;
                    this.IsRecommend.Checked = entity.IsRecommend;
                    this.txtSummary.Text = WebUtility.ToTextAreaContent(entity.Summary);
                    this.liteCheckState.Text = WebUtility.Switch(
                        entity.CheckState.ToString(),
                        new string[][]{
                            new string[]{"0","待审核"},
                            new string[]{"1","已审核"},
                            new string[]{"2","无效"},
                            new string[]{"3","过期"}
                        }
                        );
                    this.liteCreateTime.Text = entity.CreateTime.ToString();
                }
                else
                {
                    WebUtility.ShowMsg(this, "没有找到记录!", ".");
                }
            }
        }


        /// <summary>
        /// 更新视频信息事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        /// <summary>
        /// 更新视频信息方法
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
                if (!fileVideo.HasFile)
                {
                    WebUtility.ShowMsg(this, "请选择视频！");
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

            if (fileVideoPreview.DefaultValue.Length == 0)
            {
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
            }

          

            previewUrl = fileVideoPreview.GetUploadedFilePath();




            Model.CI_Videos video = dal.GetEntity(new string[] { "ID", "CorpID" }, id, this.LoginUser.CorpID);
            video.CorpID = this.LoginUser.CorpID;
            video.Title = title;
            video.Sequence = sequence;
            video.IsHidden = IsHidden.Checked;
            video.IsRecommend = IsRecommend.Checked;

            video.URL = videoUrl;
            video.PreviewURL = previewUrl;
            video.Summary = WebUtility.GetTextAreaContent(this.txtSummary.Text);
            video.ModifyTime = DateTime.Now;

            if (dal.Update(video) > 0)
            {

                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "修改成功!");

                fileVideo.Save();
                fileVideoPreview.Save();
                return;
            }
            else
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "修改失败!");
            }


        }
       
    }
}

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
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;

namespace ADeeWu.HuoBi3J.Web.Admin.CorpImage.Videos
{
    public partial class Edit : PageBase
    {

        ADeeWu.HuoBi3J.DAL.CI_Videos dalVideos = new ADeeWu.HuoBi3J.DAL.CI_Videos();

        long id = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("id", 0);
        long corpID = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("corpid", 0);
        DataBase db = DataBase.Create();

        public override string PageID
        {
            get
            {
                return "022002";
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            //首次加载
            if (!IsPostBack)
            {

                DataTable dt = db.Select("select * from vw_CI_Videos_Admin where ID=" + id);
               

                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    txtVideosName.Text = dr["Title"].ToString();
                    liteCorpName.Text = dr["CorpName"].ToString();
                    liteCreateTime.Text = dr["CreateTime"].ToString();
                    txtSequence.Text = dr["Sequence"].ToString();
                    IsHidden.Checked = bool.Parse(dr["IsHidden"].ToString());
                    IsRecommend.Checked = bool.Parse(dr["IsRecommend"].ToString());
                    txtSummary.Text = WebUtility.ToTextAreaContent(dr["Summary"].ToString());
                    txtURL.Text = dr["URL"].ToString();
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
            string title = txtVideosName.Text;
          
            int sequence = Utility.GetInt(txtSequence.Text.Trim(), 0);

            if (string.IsNullOrEmpty(title))
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写视频信息标题!");
                return;
            }
           
            
            ADeeWu.HuoBi3J.Model.CI_Videos videos = dalVideos.GetEntity(ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("id", 0));
            videos.Title = title;
           
            videos.Sequence = sequence;
            videos.IsHidden = IsHidden.Checked;
            videos.IsRecommend = IsRecommend.Checked;
            videos.Summary = WebUtility.GetTextAreaContent(txtSummary.Text);

            if (dalVideos.Update(videos) > 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "更新视频成功!", "List.aspx");
                return;
            }
            else
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "更新视频失败!");
            }


        }

    }
}

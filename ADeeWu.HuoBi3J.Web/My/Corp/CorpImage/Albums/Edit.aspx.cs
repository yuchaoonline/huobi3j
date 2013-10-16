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

namespace ADeeWu.HuoBi3J.Web.My.Corp.CorpImage.Albums
{
    public partial class Edit :ADeeWu.HuoBi3J.Web.Class.PageBase_MyCorp
    {
        ADeeWu.HuoBi3J.DAL.CI_Albums dal = new ADeeWu.HuoBi3J.DAL.CI_Albums();
        long id = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("id", 0);

        /// <summary>
        /// 加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //首次加载
               if(!IsPostBack)
               {
                   ADeeWu.HuoBi3J.Model.CI_Albums entity = dal.GetEntity(new string[] { "ID", "CorpID" }, id, this.LoginUser.CorpID);
                   if (entity != null)
                   {

                       txtAlbumsName.Text = entity.Title;
                       txtSequence.Text = entity.Sequence.ToString();
                       IsHidden.Checked = entity.IsHidden;
                       IsRecommend.Checked = entity.IsRecommend;
                       
                   }
               }
        }


        /// <summary>
        /// 保存相册信息事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SaveData();
        }


        /// <summary>
        /// 保存相册信息方法
        /// </summary>
        private void SaveData()
        {
            string name = txtAlbumsName.Text;
            int sequence = Utility.GetInt(txtSequence.Text.Trim(), 0);

            if (string.IsNullOrEmpty(name))
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写相册信息标题!");
                return;
            }

            ADeeWu.HuoBi3J.Model.CI_Albums albums = dal.GetEntity(new string[] { "ID", "CorpID" }, id, this.LoginUser.CorpID);
            albums.Title  = name;
            
            albums.Sequence = sequence;
            albums.IsHidden = IsHidden.Checked;
            albums.IsRecommend = IsRecommend.Checked;
            albums.ModifyTime = DateTime.Now;

            if (dal.Update(albums) > 0) 
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "更新相册成功!", "Default.aspx");
                return;
            }
            else
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "更新相册失败!");
            }  


        }
       
    }
}

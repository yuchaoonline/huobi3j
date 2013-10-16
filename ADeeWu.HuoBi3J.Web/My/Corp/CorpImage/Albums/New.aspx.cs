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

namespace ADeeWu.HuoBi3J.Web.My.Corp.CorpImage.Albums
{
    public partial class New :ADeeWu.HuoBi3J.Web.Class.PageBase_MyCorp
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
                this.txtSequence.Text = (Utility.GetInt(db.ExecuteScalar("select count(id) from CI_Albums where CorpID=" + this.LoginUser.CorpID), 0) + 1).ToString();
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
            string title= txtAlbumsName.Text.Trim();
            int sequence= Utility.GetInt(txtSequence.Text.Trim(),0);
            if (string.IsNullOrEmpty(title))
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写相册信息标题!");
                return;
            }
           
            DAL.CI_Albums dal = new ADeeWu.HuoBi3J.DAL.CI_Albums();
            Model.CI_Albums albums = new Model.CI_Albums();
            albums.CorpID = this.LoginUser.CorpID;
            albums.Title  = title;
           
            albums.Sequence = sequence;
            albums.IsHidden = IsHidden.Checked;
            albums.IsRecommend = IsRecommend.Checked;
            albums.CreateTime = DateTime.Now;
            albums.ModifyTime = DateTime.Now;

            if (dal.Add(albums) > 0)
            {

                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "发布相册成功!", "Default.aspx");
                return;
            }
            else {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "发布相册失败!");
            }

        }

    
    }
}

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

namespace ADeeWu.HuoBi3J.Web.Admin.CorpImage.Albums.Photos
{
    public partial class Edit : PageBase
    {
        DataBase db = DataBase.Create();

        ADeeWu.HuoBi3J.DAL.CI_Photos dalPhoto = new ADeeWu.HuoBi3J.DAL.CI_Photos();

        long id = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("id", 0);
        long corpID = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("corpid", 0);


        
        public override string PageID
        {
            get
            {
                return "020002";
            }
        }


        /// <summary>
        /// 加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

            
            //首次加载
            if (!IsPostBack)
            {

               

                BindDDLAlbumsName();

                DataTable dt = db.Select("select * from vw_CI_Photos_Admin where ID=" + id);

                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    txtPhotosName.Text = dr["Title"].ToString();
                    txtCorpName.Text = dr["CorpName"].ToString();
                    txtCreateTime.Text = dr["CreateTime"].ToString();
                    txtSequence.Text = dr["Sequence"].ToString();
                    IsHidden.Checked = bool.Parse(dr["IsHidden"].ToString());
                    IsRecommend.Checked = bool.Parse(dr["IsRecommend"].ToString());
                    txtSummary.Text = dr["Summary"].ToString();
                    txtContent.Text = dr["Content"].ToString();
                    txtURL.Text = dr["URL"].ToString();
                    ddlAlbumsName.SelectedValue = dr["AlbumID"].ToString();
                    this.IsFace.Checked = dr["FaceID"].ToString() == dr["ID"].ToString();
                }
            }
        }

        /// <summary>
        /// 绑定下拉列表所属相册
        /// </summary>
        private void BindDDLAlbumsName()
        {
            //创建相册对象
            DAL.CI_Albums dalAlbums = new ADeeWu.HuoBi3J.DAL.CI_Albums();

            this.ddlAlbumsName.DataSource = dalAlbums.Select(-1, -1, "CorpID=" + corpID, "");
            this.ddlAlbumsName.DataTextField = "Title";
            this.ddlAlbumsName.DataValueField = "ID";
            this.ddlAlbumsName.DataBind();
            this.ddlAlbumsName.Items.Insert(0, new ListItem("请选择", "0"));
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
            string name = txtPhotosName.Text;
            string corpName = txtCorpName.Text;

            DateTime? createTime = Utility.GetDateTime(txtCreateTime.Text.Trim(), null);
            int sequence = Utility.GetInt(txtSequence.Text.Trim(), 0);
            long  albumsID=Utility.GetLong(ddlAlbumsName.SelectedValue, 0);
            if (string.IsNullOrEmpty(name))
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写相册信息标题!");
                return;
            }
            if (!createTime.HasValue)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写相册发布时间!");
                return;
            }
            ADeeWu.HuoBi3J.Model.CI_Photos photo = dalPhoto.GetEntity(ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("id", 0));
            photo.Title = name;
            photo.CreateTime = createTime.Value;
            photo.AlbumID =albumsID; 
            photo.Sequence = sequence;
            photo.IsHidden = IsHidden.Checked;
            photo.IsRecommend = IsRecommend.Checked;
            photo.Summary= txtSummary.Text;
            photo.Content=txtContent.Text;
            photo.URL=txtURL.Text ;

            if (IsFace.Checked)/*设置封面*/
            {
                DAL.CI_Albums dalAlbum = new ADeeWu.HuoBi3J.DAL.CI_Albums();
                Model.CI_Albums entAlbum = dalAlbum.GetEntity(photo.AlbumID);
                if (entAlbum != null)
                {
                    entAlbum.FaceID = photo.ID;
                    dalAlbum.Update(entAlbum);
                }
            }


            if (dalPhoto.Update(photo) > 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "更新相册图片成功!", "List.aspx?id=" + albumsID);
                return;
            }
            else
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "更新相册图片失败!");
            }


        }
       

    }
}

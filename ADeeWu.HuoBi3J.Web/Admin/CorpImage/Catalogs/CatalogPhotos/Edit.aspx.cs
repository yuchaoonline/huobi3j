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

namespace ADeeWu.HuoBi3J.Web.Admin.CorpImage.Catalogs.CatalogPhotos
{
    public partial class Edit : PageBase
    {

        ADeeWu.HuoBi3J.DAL.CI_CatalogPhotos dalPhoto = new ADeeWu.HuoBi3J.DAL.CI_CatalogPhotos();

        long id = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("id", 0);
        long corpID = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("corpid", 0);

        DataBase db = DataBase.Create();

        public override string  PageID
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

                DataTable dt = db.Select("select * from vw_CI_CatalogPhotos_Admin where ID=" + id);
                BindDDLAlbumsName();

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
                }
                
            }
        }

        /// <summary>
        /// 绑定下拉列表所属画册
        /// </summary>
        private void BindDDLAlbumsName()
        {
            //创建画册对象
            DAL.CI_Catalogs dalAlbums = new ADeeWu.HuoBi3J.DAL.CI_Catalogs();

            this.ddlCatalogsName.DataSource = dalAlbums.Select(-1, -1, "CorpID=" + corpID, "");
            this.ddlCatalogsName.DataTextField = "Title";
            this.ddlCatalogsName.DataValueField = "ID";
            this.ddlCatalogsName.DataBind();
            this.ddlCatalogsName.Items.Insert(0, new ListItem("请选择", "0"));
        }


        /// <summary>
        /// 保存画册信息事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SaveData();
        }


        /// <summary>
        /// 保存画册信息方法
        /// </summary>
        private void SaveData()
        {
            string name = txtPhotosName.Text;
            string corpName = txtCorpName.Text;

            DateTime? createTime = Utility.GetDateTime(txtCreateTime.Text.Trim(), null);
            int sequence = Utility.GetInt(txtSequence.Text.Trim(), 0);

            long catalogsID =Utility.GetLong(this.ddlCatalogsName .SelectedValue, 0);
            if (string.IsNullOrEmpty(name))
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写画册信息标题!");
                return;
            }
            if (!createTime.HasValue)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写画册发布时间!");
                return;
            }
            ADeeWu.HuoBi3J.Model.CI_CatalogPhotos photo = dalPhoto.GetEntity(ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("id", 0));
            photo.Title = name;
            photo.CreateTime = createTime.Value;
            photo.Sequence = sequence;
            photo.IsHidden = IsHidden.Checked;
            photo.CatalogsID = catalogsID;
            photo.IsRecommend = IsRecommend.Checked;
            photo.Summary= txtSummary.Text;
            photo.Content=txtContent.Text;
            photo.URL=txtURL.Text ;

            if (dalPhoto.Update(photo) > 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "更新画册图片成功!", "List.aspx?id="+catalogsID);
                return;
            }
            else
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "更新画册图片失败!");
            }


        }
       

    }
}

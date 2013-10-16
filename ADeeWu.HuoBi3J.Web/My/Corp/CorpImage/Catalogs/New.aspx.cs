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

namespace ADeeWu.HuoBi3J.Web.My.Corp.CorpImage.Catalogs
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
                this.txtSequence.Text = (Utility.GetInt(db.ExecuteScalar("select count(id) from CI_Catalogs where CorpID=" + this.LoginUser.CorpID), 0) + 1).ToString();
            }
        }

        /// <summary>
        /// 提交画册事件
        /// </summary>
        /// <param title="sender"></param>
        /// <param title="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        /// <summary>
        /// 发布画册
        /// </summary>
        private void SaveData()
        {
            string title = txtCatalogsName.Text.Trim();
            int sequence = Utility.GetInt(txtSequence.Text.Trim(), 0);
            if (string.IsNullOrEmpty(title))
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写画册信息标题!");
                return;
            }
           
            DAL.CI_Catalogs  dalCatalog = new ADeeWu.HuoBi3J.DAL.CI_Catalogs();
            Model.CI_Catalogs catalog = new Model.CI_Catalogs();
            catalog.CorpID = this.LoginUser.CorpID;
            catalog.Title = title;
            catalog.Sequence = sequence;
            catalog.IsHidden = IsHidden.Checked;
            catalog.IsRecommend = IsRecommend.Checked;
            catalog.CreateTime = DateTime.Now;

            if (dalCatalog.Add(catalog) > 0)
            {

                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "发布画册成功!", "Default.aspx");
                return;
            }
            else
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "发布画册失败!");
            }

        }

    
     
    }
}

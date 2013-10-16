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
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.Web.Admin.CP_Keyword_AD
{

    /// <summary>
    /// 
    /// </summary>
    public partial class Edit : PageBase
    {
        public override string PageID
        {
            get
            {
                return "012003";
            }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                long id = WebUtility.GetRequestLong("id", 0);
                if (id == 0)
                {
                    WebUtility.ShowMsg(this, "参数错误！","List.aspx");
                    return;
                }
                hfID.Value = id.ToString();
                DAL.CP_Keyword_AD adDAL = new DAL.CP_Keyword_AD();
                Model.CP_Keyword_AD ad = adDAL.GetEntity(id);
                txtName.Text = ad.Name;
                txtLink.Text = ad.Link;
                txtContent.Text = ad.Content;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtContent.Text))
            {
                WebUtility.ShowMsg("描述不能为空！");
                return;
            }
            if (string.IsNullOrEmpty(txtLink.Text))
            {
                WebUtility.ShowMsg("链接不能为空！");
                return;
            }
            DAL.CP_Keyword_AD adDAL = new DAL.CP_Keyword_AD();
            long id = Utility.GetLong(hfID.Value, 0);
            Model.CP_Keyword_AD ad = adDAL.GetEntity(id);
            if (ad == null || ad.ID == 0)
            {
                WebUtility.ShowMsg(this, ("无此广告"), "List.aspx");
                return;
            }
            ad.Content = txtContent.Text;
            ad.Link = txtLink.Text;
            ad.Name = txtName.Text;
            ad.IsPass = ddIsPass.SelectedValue == "1" ? true : false;
            if (adDAL.Update(ad) > 0)
            {
                WebUtility.ShowMsg(this, ("编辑成功！"), "List.aspx");
                return;
            }
            else
            {
                WebUtility.ShowMsg("编辑失败！");
                return;
            }
        }
    }
}

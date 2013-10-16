using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADeeWu.HuoBi3J.SQL;
using System.Data;
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.Web.My.Corp.Promotions.Keywords.AD
{
    public partial class Edit : Class.PageBase_MyCorp
    {
        public override string FunctionCode
        {
            get
            {
                return "Corp-Promotions-Keywords-AD-Edit";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                long id = WebUtility.GetRequestLong("id", 0);
                if (id == 0)
                {
                    WebUtility.ShowAndGoBack(this, "参数错误！");
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
                WebUtility.ShowMsg(this, ("无此广告"), Request.RawUrl);
                return;
            }
            ad.Content = txtContent.Text;
            ad.Link = txtLink.Text;
            ad.Name = txtName.Text;
            ad.IsPass = false;
            if (adDAL.Update(ad) > 0)
            {
                WebUtility.ShowAndTopRedirect(this, ("编辑成功！请等待管理员审核"), Request.RawUrl);
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
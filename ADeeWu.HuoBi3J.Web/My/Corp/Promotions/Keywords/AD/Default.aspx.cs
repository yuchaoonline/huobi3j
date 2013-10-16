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
    public partial class Default : Class.PageBase_MyCorp
    {
        public override string FunctionCode
        {
            get
            {
                return "Corp-Promotions-Keywords-AD-Default";
            }
        }

        DAL.CP_Keyword_AD adDAL = new DAL.CP_Keyword_AD();

        protected void Page_Load(object sender, EventArgs e)
        {
            long pageSize = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("pagesize", GlobalParameter.DataList_PageSize);
            long pageIndex = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("page", 1);
            if (!IsPostBack)
            {
                adDAL.EnableRecordCount = true;
                adDAL.Parameters.Append("UserID", LoginUser.UserID);
                rpADList.DataSource = adDAL.Select(pageSize, pageIndex, "UserID=@UserID", "");
                rpADList.DataBind();

                this.Pager1.PageIndex = (int)pageIndex;
                this.Pager1.PageSize = (int)pageSize;
                this.Pager1.TotalRecords = (int)adDAL.RecordCount;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                WebUtility.ShowMsg("标题不能为空！");
                return;
            }
            if (txtName.Text.Length>30)
            {
                WebUtility.ShowMsg("标题长度超过30！");
                return;
            }
            if (string.IsNullOrEmpty(txtContent.Text))
            {
                WebUtility.ShowMsg("描述不能为空！");
                return;
            }
            if (txtContent.Text.Length > 100)
            {
                WebUtility.ShowMsg("描述长度超过100！");
                return;
            }
            if (string.IsNullOrEmpty(txtLink.Text))
            {
                WebUtility.ShowMsg("链接不能为空！");
                return;
            }
            Model.CP_Keyword_AD ad = new Model.CP_Keyword_AD
            {
                Content = txtContent.Text,
                Link = txtLink.Text,
                Name = txtName.Text,
                UserID = LoginUser.UserID,
                IsPass = false,
            };
            if (adDAL.Add(ad) > 0)
            {
                WebUtility.ShowAndTopRedirect(this, ("添加成功！"), Request.RawUrl);
                return;
            }
            else
            {
                WebUtility.ShowMsg("添加失败！");
                return;
            }
        }
    }
}
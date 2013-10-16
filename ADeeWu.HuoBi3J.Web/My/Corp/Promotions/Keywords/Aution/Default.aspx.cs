using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADeeWu.HuoBi3J.Web.Class;
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.Web.My.Corp.Promotions.Keywords.Aution
{
    public partial class Default : PageBase_MyCorp
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                long pageSize = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("pagesize", GlobalParameter.DataList_PageSize);
                long pageIndex = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("page", 1);
                string keyword = txtKeyword.Text;

                if (!IsPostBack)
                {
                    FillData((int)pageSize, (int)pageIndex, keyword);
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            FillData((int)GlobalParameter.DataList_PageSize, 1, txtKeyword.Text);
        }

        private void FillData(int pageSize, int pageIndex, string keyword)
        {
            DAL.CP_Keyword_Search keywordDAL = new DAL.CP_Keyword_Search();
            keywordDAL.EnableRecordCount = true;
            if (string.IsNullOrEmpty(keyword))
                this.rpADList.DataSource = keywordDAL.Select(pageSize, pageIndex);
            else
                this.rpADList.DataSource = keywordDAL.Select(pageSize, pageIndex, string.Format("keyword like '%{0}%'", keyword), "");
            this.rpADList.DataBind();
            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.PageSize = (int)pageSize;
            this.Pager1.TotalRecords = (int)keywordDAL.RecordCount;
            this.Pager1.AppendUrlParam("keyword", keyword);
        }

        DAL.Users userDAL = new DAL.Users();
        public string GetUsername(object _value)
        {
            long id = Utility.GetLong(_value, 0);
            if (id == 0) return "";
            Model.Users user = userDAL.GetEntity(id);
            if (user == null || user.ID == 0)
                return "";
            return user.LoginName;
        }
    }
}
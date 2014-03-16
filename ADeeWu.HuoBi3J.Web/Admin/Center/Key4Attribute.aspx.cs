using ADeeWu.HuoBi3J.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web.Admin.Center
{
    public partial class Key4Attribute : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BandData("");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            BandData(txtKey.Text);
        }

        private void BandData(string keyword)
        {
            long pageSize = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("pagesize", PageBase.DataList_PageSize);
            long pageIndex = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("page", 1);

            var strWhere = "";
            var db = DataBase.Create();
            db.EnableRecordCount = true;

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                strWhere = string.Format("kname like '%{0}%'", keyword);
                rpResultList.DataSource = db.Select("vw_keys", strWhere, "");
            }
            else
            {
                rpResultList.DataSource = db.Select(pageSize, pageIndex, "vw_keys", "kid");
            }
            rpResultList.DataBind();

            this.Pager1.PageSize = ADeeWu.HuoBi3J.Libary.Utility.GetInt(pageSize, 0);
            this.Pager1.PageIndex = ADeeWu.HuoBi3J.Libary.Utility.GetInt(pageIndex, 0);
            this.Pager1.TotalRecords = ADeeWu.HuoBi3J.Libary.Utility.GetInt(db.RecordCount, 0);
        }
    }
}
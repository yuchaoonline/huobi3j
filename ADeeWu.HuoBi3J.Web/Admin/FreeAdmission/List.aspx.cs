using ADeeWu.HuoBi3J.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web.Admin.FreeAdmission
{
    public partial class List : System.Web.UI.Page
    {
        DataBase db = DataBase.Create();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BandDate();
            }
        }

        private void BandDate()
        {
            int pageSize = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlInt("pagesize", PageBase.DataList_PageSize);
            int pageIndex = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlInt("page", 1);

            db.EnableRecordCount = true;
            var ds = db.Select(pageSize, pageIndex, "vw_FreeAdmission", "ID");

            gvData.DataSource = ds;
            gvData.DataBind();

            this.Pager1.PageSize = pageSize;
            this.Pager1.PageIndex = pageIndex;
            this.Pager1.TotalRecords = Convert.ToInt32(db.RecordCount);
        }
    }
}
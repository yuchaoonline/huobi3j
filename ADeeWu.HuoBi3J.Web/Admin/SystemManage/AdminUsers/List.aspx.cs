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

namespace ADeeWu.HuoBi3J.Web.Admin.SystemManage.AdminUsers
{
    public partial class List : PageBase
    {
        ADeeWu.HuoBi3J.DAL.Admin_Users dal = new ADeeWu.HuoBi3J.DAL.Admin_Users();
        

        public override string PageID
        {
            get
            {
                return "0103";
            }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            int pageSize = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlInt("pagesize", PageBase.DataList_PageSize);
            int pageIndex = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlInt("page", 1);

            if (!IsPostBack)
            {
                dal.EnableRecordCount = true;
                this.gvData.DataSource = dal.Select(pageSize, pageIndex);
                this.gvData.DataBind();
                this.Pager1.PageSize = pageSize;
                this.Pager1.PageIndex = pageIndex;
                this.Pager1.TotalRecords = (int)dal.RecordCount;
                dal.EnableRecordCount = false;
            }
        }
    }
}

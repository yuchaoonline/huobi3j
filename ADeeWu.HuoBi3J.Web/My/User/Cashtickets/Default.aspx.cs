using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


namespace ADeeWu.HuoBi3J.Web.My.User.Cashtickets
{
    public partial class Default : ADeeWu.HuoBi3J.Web.Class.PageBase_MyUser
    {
        public override string FunctionCode
        {
            get
            {
                return "My-User-CashTicket-Default";
            }
        }

        ADeeWu.HuoBi3J.DAL.CT_CashTicketApplications dal = new ADeeWu.HuoBi3J.DAL.CT_CashTicketApplications();
        protected void Page_Load(object sender, System.EventArgs e)
        {
            
            long pageIndex = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("page", 1);
            long pageSize = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("pagesize", 20);

            if (pageIndex <= 0)
            {
                pageIndex = 1;
            }

            if (pageSize < 1 || pageSize > 50)
            {
                pageSize = 20;
            }


            long realBusinessUserID = this.GetRealBusinessUserID();

            dal.EnableRecordCount = true;
            this.gvDataList.DataSource = dal.Select(pageSize, pageIndex, "UserID=" + realBusinessUserID, "CreateTime desc");
            this.gvDataList.DataBind();

            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.PageSize = (int)pageSize;
            this.Pager1.TotalRecords = (int)dal.RecordCount;
            dal.EnableRecordCount = false;
        }
    }
}


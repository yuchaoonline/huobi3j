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
using System.Text;
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.Web.My.User.TransferApplications
{
    public partial class Default : ADeeWu.HuoBi3J.Web.Class.PageBase_MyUser
    {

        public override string FunctionCode
        {
            get
            {
                return "My-User-TransferApplication-Default";
            }
        }
        
        ADeeWu.HuoBi3J.DAL.User_TransferApplications dalTransferApplication = new ADeeWu.HuoBi3J.DAL.User_TransferApplications();
        
        protected long pageIndex = 0;
        protected long pageSize = 20;
        int checkState = -1;
        
        protected void Page_Load(object sender, System.EventArgs e)
        {
            pageSize = Utility.GetLong(Request["pagesize"], 20, 5, 20);

            if (!IsPostBack)
            {
                pageIndex = WebUtility.GetRequestInt("page", 1);
                checkState = WebUtility.GetRequestInt("state", -1);
                bindData();
            }            
        }

        void bindData()
        {
            long realBusinessUserID = this.GetRealBusinessUserID();

            StringBuilder whereBuilder = new StringBuilder();
            whereBuilder.AppendFormat("UserID = {0}", realBusinessUserID);
            if (checkState >= 0 && checkState <= 3)
            {
                this.Pager1.AppendUrlParam("state", checkState.ToString());
                whereBuilder.AppendFormat(" and checkstate = {0}", checkState);
                this.ddlState.SelectedValue = checkState.ToString();
            }

           

            dalTransferApplication.EnableRecordCount = true;
            this.gvData.DataSource = dalTransferApplication.Select(pageSize, pageIndex, whereBuilder.ToString(), "CreateTime desc,ModifyTime desc");
            this.gvData.DataBind();

            this.Pager1.TotalRecords = (int)dalTransferApplication.RecordCount;
            this.Pager1.PageIndex =(int)pageIndex;
            this.Pager1.PageSize = (int)pageSize;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            pageIndex = 1;
            checkState = Utility.GetInt(Request.QueryString["state"], this.ddlState.SelectedValue, -1);
            bindData();
        }
    }
}
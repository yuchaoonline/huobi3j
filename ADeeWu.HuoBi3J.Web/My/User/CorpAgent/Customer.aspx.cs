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
using System.Collections.Generic;
using System.Text;
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.Web.My.User.CorpAgent
{
    public partial class Customer : ADeeWu.HuoBi3J.Web.Class.PageBase_MyUser
    {

        public override string FunctionCode
        {
            get
            {
                return "My-User-CorpAgent-Customer";
            }
        }



        DataBase db = DataBase.Create();
        long pageSize = 20;
        long pageIndex = 1;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pageSize = Utility.GetInt(Request["pagesize"], 20, 5, 20);
                pageIndex = WebUtility.GetRequestInt("page", 1);

                if (!IsPostBack)//获取外部参数
                {
                    bindData();
                }
            }
        }


        private void bindData()
        {
            db.EnableRecordCount = true;
            this.rpDataList.DataSource = db.Select(pageSize, pageIndex, "vw_CA_QualifiedAgentBusiness", "id", "AgentUserID=" + this.LoginUser.UserID, "");
            this.rpDataList.DataBind();


            this.Pager1.PageSize = (int)pageSize;
            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.TotalRecords = (int)db.RecordCount;
        }

        protected void rpDataList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Repeater rp = e.Item.FindControl("rpSub") as Repeater;
            TextBox txtCustomerUserId = e.Item.FindControl("txtCustomerUserId") as TextBox;
            long agentUserID = Utility.GetLong(txtCustomerUserId.Text, 0);


            rp.DataSource = db.Select("vw_CA_QualifiedAgentBusiness", "AgentUserID=" + agentUserID, "");
            rp.DataBind();
        }

      

    }
}

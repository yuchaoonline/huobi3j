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

namespace ADeeWu.HuoBi3J.Web.My.User.TradeOrders
{
    public partial class Default : ADeeWu.HuoBi3J.Web.Class.PageBase_MyUser
    {

        public override string FunctionCode
        {
            get
            {
                return "My-User-TradeOrders-Default";
            }
        }

        ADeeWu.HuoBi3J.DAL.TradeSystem_AlipayTrades dal = new ADeeWu.HuoBi3J.DAL.TradeSystem_AlipayTrades();

        protected long pageSize = 20;
        protected long pageIndex = 1;
        int state = -1;
        string orderCode = string.Empty;


        protected void Page_Load(object sender, System.EventArgs e)
        {

            pageSize = Utility.GetLong(Request["pagesize"], 20, 5, 20);
            pageIndex = WebUtility.GetRequestLong("page", 1);

            if (!IsPostBack)//获取外部参数
            {
                state = WebUtility.GetRequestInt("state", -1);
                orderCode = WebUtility.GetRequestStr("order", "");
                bindData();
            }

        }

        void bindData()
        {

            long realBusinessUserID = this.GetRealBusinessUserID();
            StringBuilder whereBuilder = new StringBuilder();
            whereBuilder.AppendFormat("UserID = {0}", realBusinessUserID);

            if (this.state > 0)
            {
                whereBuilder.AppendFormat(" and OrderState={0}", state);
                this.ddlOrderState.SelectedValue = this.state.ToString();
                this.Pager1.AppendUrlParam("state", this.state.ToString());
            }

            if (this.orderCode.Length > 0)
            {
                whereBuilder.Append(" and OrderCode=@OrderCode");
                dal.Parameters.Append("@OrderCode", this.orderCode);
                this.txtOrderCode.Text = this.orderCode;
                this.Pager1.AppendUrlParam("order", this.orderCode);
            }

            dal.EnableRecordCount = true;
            this.gvData.DataSource = dal.Select(pageSize, pageIndex, whereBuilder.ToString(), "CreateTime desc");
            this.gvData.DataBind();

            this.Pager1.TotalRecords = (int)dal.RecordCount;
            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.PageSize = (int)pageSize;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            pageIndex = 1;
            state = Utility.GetInt(Request["state"], this.ddlOrderState.SelectedValue, -1);
            orderCode = Utility.GetStr(Request["order"], this.txtOrderCode.Text, "", true);
            bindData();
        }
    }
}
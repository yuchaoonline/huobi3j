using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADeeWu.HuoBi3J.Libary;
using System.Text;
using ADeeWu.HuoBi3J.SQL;

namespace ADeeWu.HuoBi3J.Web.My.Corp.CashTickets
{
    public partial class Default : Class.PageBase_MyCorp
    {
        DataBase db = DataBase.Create();
        
        protected string serialNum = string.Empty;
        protected int state = -1;
        protected long pageSize = 20;
        protected long pageIndex = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            pageSize = Utility.GetInt(Request["pagesize"], 20, 5, 20);
            pageIndex = WebUtility.GetRequestInt("page", 1);

            if (!IsPostBack)//获取外部参数
            {
                this.serialNum = WebUtility.GetRequestStr("sn", "");
                this.state = WebUtility.GetRequestInt("s", -1);
                bindData();
            }
        }

        private void bindData()
        {
            StringBuilder whereBuilder = new StringBuilder();
            whereBuilder.AppendFormat(" CorpID={0} ", this.LoginUser.CorpID);
            if (this.serialNum.Length > 0)
            {
                whereBuilder.AppendFormat(" and SerialNum=@SerialNum");
                db.Parameters.Append("@SerialNum", this.serialNum);
                this.Pager1.AppendUrlParam("sn", this.serialNum);
            }

            switch(this.state)
            {
                case 0:
                    whereBuilder.AppendFormat(" and (AppCheckState is null or AppCheckState<>1)");
                    this.ddlFilter.SelectedValue = this.state.ToString();
                    this.Pager1.AppendUrlParam("s", this.state.ToString());
                    break;
                case 1:
                    whereBuilder.AppendFormat(" and AppCheckState=1");
                    this.ddlFilter.SelectedValue = this.state.ToString();
                    this.Pager1.AppendUrlParam("s", this.state.ToString());
                    break;
            }

            db.EnableRecordCount = true;
            this.gvData.DataSource = db.Select(pageSize, pageIndex, "vw_CT_CashTickets3", "ID", whereBuilder.ToString(), "");
            this.gvData.DataBind();

            this.Pager1.PageSize = (int)this.pageSize;
            this.Pager1.PageIndex = (int)this.pageIndex;
            this.Pager1.TotalRecords = (int)db.RecordCount;
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            this.pageIndex = 1;
            this.serialNum = Utility.GetStr(Request["sn"], this.txtName.Text, "", true);
            this.state = Utility.GetInt(Request["s"], this.ddlFilter.SelectedValue, -1);
            bindData();
        }

    }
}

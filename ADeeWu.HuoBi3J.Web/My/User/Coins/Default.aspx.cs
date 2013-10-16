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

namespace ADeeWu.HuoBi3J.Web.My.User.Coins
{
    public partial class Default : ADeeWu.HuoBi3J.Web.Class.PageBase_MyUser
    {
        public override string FunctionCode
        {
            get
            {
                return "My-User-Coins-Default";
            }
        }
        
        ADeeWu.HuoBi3J.DAL.User_CoinUseHistories dal = new ADeeWu.HuoBi3J.DAL.User_CoinUseHistories();

        protected long pageSize = 20;
        protected long pageIndex = 1;
        protected int state = -1;


        protected void Page_Load(object sender, System.EventArgs e)
        {

            pageSize = Utility.GetLong(Request["pagesize"], 20, 5, 20);
            pageIndex = WebUtility.GetRequestLong("page", 1);

            if (!IsPostBack)//获取外部参数
            {
                state = WebUtility.GetRequestInt("state", -1);
                bindData();
            }
           
        }

        void bindData()
        {

            long realBusinessUserID = this.GetRealBusinessUserID();
            
            StringBuilder whereBuilder = new StringBuilder();
            whereBuilder.AppendFormat("UserID = {0}", realBusinessUserID);

            if (state == 0 || state == 1)
            {
                if (state == 0)//添加
                {
                    whereBuilder.AppendFormat(" and OutCoin = 0");
                }
                else if (state == 1)
                {
                    whereBuilder.AppendFormat(" and InCoin = 0");
                }

                this.Pager1.AppendUrlParam("state", state.ToString());
                this.ddlState.SelectedValue = state.ToString();
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
            state = Utility.GetInt(Request.QueryString["state"], this.ddlState.SelectedValue, -1);
            bindData();
        }
    }
}
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
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using ADeeWu.HuoBi3J.SQL;

namespace ADeeWu.HuoBi3J.Web.Admin.Coins
{
    public partial class List : PageBase
    {

        public override string PageID
        {
            get
            {
                return "009003";
            }
        }

        int pageSize = 0;
        int pageIndex = 1;
        DataBase db = DataBase.Create();
       

        protected void Page_Load(object sender, EventArgs e)
        {
            
            pageSize = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlInt("pagesize", PageBase.DataList_PageSize);
            pageIndex = ADeeWu.HuoBi3J.Libary.WebUtility.UpdateRequestInt("page", 1, true);

            if (!IsPostBack)
            {
                BindData();
            }
            
        }

        private void BindData()
        {
           
            StringBuilder whereBuilder = new StringBuilder();
            whereBuilder.AppendFormat(" 1=1 ");
            List<SqlParameter> parameters = new List<SqlParameter>();
            string loginName = this.txtLoginName.Text.Trim();
            if (loginName == "")
            {
                loginName = ADeeWu.HuoBi3J.Libary.Utility.GetStr(Request["loginName"]).Trim();
            }

            if (loginName != "")
            {
                whereBuilder.AppendFormat(" and LoginName like @LoginName");
                db.Parameters.Append("@LoginName", string.Format("%{0}%", loginName));
                this.Pager1.AppendUrlParam("loginName", loginName);
                this.txtLoginName.Text = loginName;//分页转跳时传递的参数
            }

            int state = ADeeWu.HuoBi3J.Libary.Utility.GetInt(this.ddlFilter.SelectedValue, -1);
            if (!IsPostBack)
            {
                state = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestInt("state", -1);
            }
            if (state == 0 || state == 1)
            {
                if (state == 0)//添加货币操作筛选
                {
                    whereBuilder.AppendFormat(" and OutCoin = 0");
                }
                else if(state==1)
                {
                    whereBuilder.AppendFormat(" and InCoin = 0");
                }

                this.Pager1.AppendUrlParam("state", state.ToString());
                this.ddlFilter.SelectedValue = state.ToString();//分页转跳时传递的参数
            }

          
            db.EnableRecordCount = true;
            this.gvData.DataSource = db.Select(pageSize, pageIndex, "vw_User_CoinUseHistories", "id", whereBuilder.ToString(), "CreateTime desc");
            this.gvData.DataBind();
            this.Pager1.PageSize = pageSize;
            this.Pager1.PageIndex = pageIndex;
            this.Pager1.TotalRecords = (int)db.RecordCount;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            pageIndex = 1;
            BindData();
        }
    }
}

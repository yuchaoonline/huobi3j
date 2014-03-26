using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Web.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web.My.User.Coupons
{
    public partial class Default : PageBase_MyUser
    {
        DataBase db = DataBase.Create();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BandData();
            }
        }

        private void BandData()
        {
            var pageIndex = WebUtility.GetRequestInt("page", 1);
            var pageSize = Utility.GetInt(Request["pagesize"], 10, 5, 40);

            rpQuestions.DataSource = db.Select(pageSize, pageIndex, "vw_Coupons_List", "id", "userid=" + LoginUser.UserID, "isuse desc, money desc, enddate desc");
            rpQuestions.DataBind();

            this.Pager1.PageSize = (int)pageSize;
            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.TotalRecords = (int)db.RecordCount;
        }
    }
}
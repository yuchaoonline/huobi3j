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
    public partial class ObtainLog : PageBase_MyUser
    {
        DataBase db = DataBase.Create();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BandMonth();
                BandWeak();
            }
        }

        private void BandWeak()
        {
            var sql = string.Format(@"SELECT code.CreateDate ,SUM(code.Count) AS TotalUseCount ,COUNT(code.Count) AS TotalCount FROM ( SELECT CONVERT(VARCHAR(12), c.CreateTime, 112) AS CreateDate , c.[Count] FROM dbo.Coupons_CashWhenFee_Code c WHERE SaleManUserID = {0} AND DATEDIFF(DD, c.CreateTime, GETDATE()) <= 7) AS code GROUP BY code.CreateDate", this.LoginUser.UserID);
            rpDate.DataSource = db.Select(sql);
            rpDate.DataBind();
        }

        private void BandMonth()
        {
            var sql = string.Format(@"SELECT code.CreateMonth , SUM(code.Count) AS TotalUseCount , COUNT(code.Count) AS TotalCount FROM ( SELECT SUBSTRING(CONVERT(VARCHAR(12), c.CreateTime, 112), 0, 7) AS CreateMonth ,c.[Count] FROM dbo.Coupons_CashWhenFee_Code c WHERE SaleManUserID = {0} AND DATEDIFF(MM, c.CreateTime, GETDATE()) <= 6 ) AS code GROUP BY code.CreateMonth", this.LoginUser.UserID);
            rpMonth.DataSource = db.Select(sql);
            rpMonth.DataBind();
        }
    }
}
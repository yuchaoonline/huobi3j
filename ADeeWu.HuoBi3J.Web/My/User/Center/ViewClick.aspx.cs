using ADee.Project.LBS.BLL;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Web.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web.My.User.Center
{
    public partial class ViewClick : PageBase_CircleSaleMan
    {
        DataBase db = DataBase.Create();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var kids = new List<string>();
                var index = 0;
                var totalIndex = 0;
                var geoSearchBLL = new GeoSearchBLL();
                while (true)
                {
                    var productContents = geoSearchBLL.Local<LBSHelper.ProductContent>(ADee.Project.LBS.Common.ConfigHelper.GeoProductTableID, "", "", index, 50, "", "", string.Format("CreateUserID:{0},{0}", LoginUser.UserID));
                    kids.AddRange(productContents.contents.Select(p => p.uid).ToList());

                    if (index == 0 && productContents.total > 0)
                    {
                        totalIndex = productContents.total / 50;
                        if (productContents.total % 50 != 0) totalIndex++;
                    }

                    if (index + 1 >= totalIndex) break;
                    index++;
                }

                if (kids.Any())
                {
                    BandWeak(kids);
                    BandMonth(kids);
                }
            }
        }

        private void BandWeak(List<string> kids)
        {
            var sql = string.Format(@"SELECT FeeLog.[Date] , SUM(FeeLog.Fee) AS Fee , COUNT(FeeLog.ID) AS ViewCount FROM ( SELECT CONVERT(VARCHAR(12), c.CreateDate, 112) AS [Date], ISNULL(vplog.Price, 0) AS Fee ,c.ID FROM dbo.Common_Count_Click c LEFT JOIN dbo.Key_ViewPrice_Log vplog ON c.ID = vplog.CountClickID WHERE c.DataType = 'center_product' AND DATEDIFF(DD, c.CreateDate, GETDATE()) <= 7 AND c.DataID IN ( {0} ) ) AS FeeLog GROUP BY FeeLog.[Date]", string.Join(",", kids));
            rpDate.DataSource = db.Select(sql);
            rpDate.DataBind();
        }

        private void BandMonth(List<string> kids)
        {
            var sql = string.Format(@"SELECT FeeLog.[Month] , SUM(FeeLog.Fee) AS Fee , COUNT(FeeLog.ID) AS ViewCount FROM ( SELECT SUBSTRING(CONVERT(VARCHAR(12), c.CreateDate, 112),0,7) AS [Month] ,ISNULL(vplog.Price, 0) AS Fee ,c.ID FROM dbo.Common_Count_Click c LEFT JOIN dbo.Key_ViewPrice_Log vplog ON c.ID = vplog.CountClickID WHERE c.DataType = 'center_product' AND DATEDIFF(MM, c.CreateDate, GETDATE()) <= 6 AND c.DataID IN ( {0} ) ) AS FeeLog GROUP BY FeeLog.[Month]", string.Join(",", kids));
            rpMonth.DataSource = db.Select(sql);
            rpMonth.DataBind();
        }
    }
}
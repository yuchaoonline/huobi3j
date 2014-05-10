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
    public partial class ViewPriceLog : PageBase_CircleSaleMan
    {
        DataBase db = DataBase.Create();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var date = WebUtility.GetRequestStr("date", "");
                var month = WebUtility.GetRequestStr("month", "");

                var geoSearchBLL = new GeoSearchBLL();
                var kids = new List<string>();
                var index = 0;
                var totalIndex = 0;
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
                    if (!string.IsNullOrWhiteSpace(date))
                        BandWeak(kids, date);
                    if (!string.IsNullOrWhiteSpace(month))
                        BandMonth(kids, month);
                }
            }
        }

        private void BandMonth(List<string> kids,string month)
        {
            var sql = string.Format(@"WITH temp AS (SELECT c.DataID AS ProductID , CONVERT(VARCHAR(12), c.CreateDate, 112) AS [Date], IP , vl.Price as Fee FROM dbo.Common_Count_Click AS c LEFT JOIN dbo.Key_ViewPrice_Log AS vl ON c.ID = vl.CountClickID WHERE c.DataType = 'center_product' AND Price IS NOT NULL) SELECT * FROM temp WHERE temp.Date LIKE '{0}%' AND temp.ProductID IN ({1})",month, string.Join(",", kids));
            rpDate.DataSource = db.Select(sql);
            rpDate.DataBind();
        }

        private void BandWeak(List<string> kids,string date)
        {
            var sql = string.Format(@"WITH temp AS (SELECT c.DataID AS ProductID , CONVERT(VARCHAR(12), c.CreateDate, 112) AS [Date], IP , vl.Price as Fee FROM dbo.Common_Count_Click AS c LEFT JOIN dbo.Key_ViewPrice_Log AS vl ON c.ID = vl.CountClickID WHERE c.DataType = 'center_product' AND Price IS NOT NULL) SELECT * FROM temp WHERE temp.Date in ({0}) AND temp.ProductID IN ({1})", date, string.Join(",", kids));
            rpDate.DataSource = db.Select(sql);
            rpDate.DataBind();
        }
    }
}
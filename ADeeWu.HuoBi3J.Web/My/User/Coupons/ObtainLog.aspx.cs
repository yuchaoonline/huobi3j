using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.Web.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

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
            var sql = string.Format(@"SELECT code.CreateDate as Title ,SUM(code.Count) AS TotalUseCount ,COUNT(code.Count) AS TotalCount FROM ( SELECT CONVERT(VARCHAR(12), c.CreateTime, 112) AS CreateDate , c.[Count] FROM dbo.Coupons_CashWhenFee_Code c WHERE SaleManUserID = {0} AND DATEDIFF(DD, c.CreateTime, GETDATE()) <= 7) AS code GROUP BY code.CreateDate", this.LoginUser.UserID);
            var GetDT = db.Select(sql);
            var sql2 = string.Format("SELECT  CreateDate as Title , SUM(UseCount) AS TotalExchangeCount FROM ( SELECT CONVERT(VARCHAR(12), l.CreateTime, 112) AS CreateDate , l.UseCount FROM dbo.Coupons_CashWhenFee_CodeLog l LEFT JOIN dbo.Coupons_CashWhenFee_Code code ON l.CodeID = code.ID WHERE code.SaleManUserID = {0}) AS newTable GROUP BY CreateDate", this.LoginUser.UserID);
            var GetDT2 = db.Select(sql2);

            var result = new List<TotalModel>();
            foreach (DataRow item in GetDT.Rows)
            {
                result.Add(new TotalModel
                {
                    Title = item["Title"].GetStr(),
                    TotalCount = item["TotalCount"].GetInt(),
                    TotalUseCount = item["TotalUseCount"].GetInt(),
                });
            }
            foreach (DataRow item in GetDT2.Rows)
            {
                var model = result.FirstOrDefault(p => p.Title == item["Title"].GetStr());
                if (model!=null)
                {
                    model.TotalExchangeCount = item["TotalExchangeCount"].GetInt();
                    continue;
                }

                result.Add(new TotalModel
                {
                    Title = item["Title"].GetStr(),
                    TotalExchangeCount = item["TotalExchangeCount"].GetInt(),
                });
            }

            rpDate.DataSource = result;
            rpDate.DataBind();
        }

        private void BandMonth()
        {
            var sql = string.Format(@"SELECT code.CreateMonth as Title , SUM(code.Count) AS TotalUseCount , COUNT(code.Count) AS TotalCount FROM ( SELECT SUBSTRING(CONVERT(VARCHAR(12), c.CreateTime, 112), 0, 7) AS CreateMonth ,c.[Count] FROM dbo.Coupons_CashWhenFee_Code c WHERE SaleManUserID = {0} AND DATEDIFF(MM, c.CreateTime, GETDATE()) <= 6 ) AS code GROUP BY code.CreateMonth", this.LoginUser.UserID);
            var GetDT = db.Select(sql);
            var sql2 = string.Format("SELECT  CreateDate as Title , SUM(UseCount) AS TotalExchangeCount FROM ( SELECT SUBSTRING(CONVERT(VARCHAR(12), l.CreateTime, 112), 0, 7) AS CreateDate , l.UseCount FROM dbo.Coupons_CashWhenFee_CodeLog l LEFT JOIN dbo.Coupons_CashWhenFee_Code code ON l.CodeID = code.ID WHERE code.SaleManUserID = {0}) AS newTable GROUP BY CreateDate", this.LoginUser.UserID);
            var GetDT2 = db.Select(sql2);

            var result = new List<TotalModel>();
            foreach (DataRow item in GetDT.Rows)
            {
                result.Add(new TotalModel
                {
                    Title = item["Title"].GetStr(),
                    TotalCount = item["TotalCount"].GetInt(),
                    TotalUseCount = item["TotalUseCount"].GetInt(),
                });
            }
            foreach (DataRow item in GetDT2.Rows)
            {
                var model = result.FirstOrDefault(p => p.Title == item["Title"].GetStr());
                if (model != null)
                {
                    model.TotalExchangeCount = item["TotalExchangeCount"].GetInt();
                    continue;
                }

                result.Add(new TotalModel
                {
                    Title = item["Title"].GetStr(),
                    TotalExchangeCount = item["TotalExchangeCount"].GetInt(),
                });
            }

            rpMonth.DataSource = result;
            rpMonth.DataBind();
        }

        public class TotalModel
        {
            public string Title { get; set; }
            public int TotalUseCount { get; set; }
            public int TotalCount { get; set; }
            public int TotalExchangeCount { get; set; }
        }
    }
}
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web.Admin.Coupons
{
    public partial class CashWhenFeeLog : System.Web.UI.Page
    {
        DataBase db = DataBase.Create();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BandData();
            }
        }

        private void BandData(int salemanuseid = 0)
        {
            BandMonth(salemanuseid);
            BandWeak(salemanuseid);
            BandTotal(salemanuseid);
        }

        private void BandWeak(int salemanuseid = 0)
        {
            var sql = string.Format(@"SELECT code.CreateDate as Title ,SUM(code.Count) AS TotalUseCount ,COUNT(code.Count) AS TotalCount FROM ( SELECT CONVERT(VARCHAR(12), c.CreateTime, 112) AS CreateDate , c.[Count] FROM dbo.Coupons_CashWhenFee_Code c WHERE DATEDIFF(DD, c.CreateTime, GETDATE()) <= 7 {0}) AS code GROUP BY code.CreateDate", salemanuseid > 0 ? "AND SaleManUserID=" + salemanuseid : "");
            var GetDT = db.Select(sql);
            var sql2 = string.Format("SELECT  CreateDate as Title , SUM(UseCount) AS TotalExchangeCount, SUM(UseCount * Fee) AS TotalFee FROM ( SELECT CONVERT(VARCHAR(12), l.CreateTime, 112) AS CreateDate , l.UseCount, code.Fee FROM dbo.Coupons_CashWhenFee_CodeLog l LEFT JOIN dbo.Coupons_CashWhenFee_Code code ON l.CodeID = code.ID {0}) AS newTable GROUP BY CreateDate", salemanuseid > 0 ? "WHERE code.SaleManUserID = " + salemanuseid : "");
            var GetDT2 = db.Select(sql2);

            var result = new List<ADeeWu.HuoBi3J.Web.My.User.Coupons.ObtainLog.TotalModel>();
            foreach (DataRow item in GetDT.Rows)
            {
                result.Add(new ADeeWu.HuoBi3J.Web.My.User.Coupons.ObtainLog.TotalModel
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
                    model.TotalFee = item["TotalFee"].GetDecimal();
                    continue;
                }

                result.Add(new ADeeWu.HuoBi3J.Web.My.User.Coupons.ObtainLog.TotalModel
                {
                    Title = item["Title"].GetStr(),
                    TotalExchangeCount = item["TotalExchangeCount"].GetInt(),
                    TotalFee = item["TotalFee"].GetDecimal(),
                });
            }

            rpWeek.DataSource = result;
            rpWeek.DataBind();
        }

        private void BandMonth(int salemanuseid = 0)
        {
            var sql = string.Format(@"SELECT code.CreateMonth as Title , SUM(code.Count) AS TotalUseCount , COUNT(code.Count) AS TotalCount FROM ( SELECT SUBSTRING(CONVERT(VARCHAR(12), c.CreateTime, 112), 0, 7) AS CreateMonth ,c.[Count] FROM dbo.Coupons_CashWhenFee_Code c WHERE DATEDIFF(MM, c.CreateTime, GETDATE()) <= 6 {0}) AS code GROUP BY code.CreateMonth", salemanuseid > 0 ? "AND SaleManUserID=" + salemanuseid : "");
            var GetDT = db.Select(sql);
            var sql2 = string.Format("SELECT  CreateDate as Title , SUM(UseCount) AS TotalExchangeCount, SUM(UseCount * Fee) AS TotalFee FROM ( SELECT SUBSTRING(CONVERT(VARCHAR(12), l.CreateTime, 112), 0, 7) AS CreateDate , l.UseCount, code.Fee FROM dbo.Coupons_CashWhenFee_CodeLog l LEFT JOIN dbo.Coupons_CashWhenFee_Code code ON l.CodeID = code.ID {0}) AS newTable GROUP BY CreateDate", salemanuseid > 0 ? "WHERE code.SaleManUserID = " + salemanuseid : "");
            var GetDT2 = db.Select(sql2);

            var result = new List<ADeeWu.HuoBi3J.Web.My.User.Coupons.ObtainLog.TotalModel>();
            foreach (DataRow item in GetDT.Rows)
            {
                result.Add(new ADeeWu.HuoBi3J.Web.My.User.Coupons.ObtainLog.TotalModel
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
                    model.TotalFee = item["TotalFee"].GetDecimal();
                    continue;
                }

                result.Add(new ADeeWu.HuoBi3J.Web.My.User.Coupons.ObtainLog.TotalModel
                {
                    Title = item["Title"].GetStr(),
                    TotalExchangeCount = item["TotalExchangeCount"].GetInt(),
                    TotalFee = item["TotalFee"].GetDecimal()
                });
            }

            rpMonth.DataSource = result;
            rpMonth.DataBind();
        }

        private void BandTotal(int salemanuseid = 0)
        {
            rpTotal.DataSource = db.Select("SELECT count(code.ID) AS TotalCount,SUM(code.Count) AS TotalUseCount,SUM(code.UseCount) AS TotalExchangeCount , SUM(code.UseCount * code.Fee) AS TotalFee FROM dbo.Coupons_CashWhenFee_Code code " + (salemanuseid > 0 ? "WHERE SaleManUserID=" + salemanuseid : ""));
            rpTotal.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var salemanuserid = 0;
            if (!string.IsNullOrWhiteSpace(txtName.Text))
            {
                var strWhere = string.Format(" WHERE LoginName LIKE '%{0}%' OR CompanyName LIKE '%{0}%'", txtName.Text);
                var sql = string.Format("SELECT * FROM dbo.vw_Key_CircleSaleMan " + strWhere);
                var a = db.Select(sql);
                if (a != null && a.Rows.Count > 0)
                {
                    salemanuserid = a.Rows[0]["UserID"].GetInt();
                    litSaleman.Text = string.Format("<h2>以下是商家名称：{0}，公司名称：{1} 的统计数据：</h2>", a.Rows[0]["LoginName"].GetStr(), a.Rows[0]["CompanyName"]);
                }
                else
                {
                    WebUtility.ShowMsg("未找到记录！");
                    litSaleman.Text = "";
                }
            }

            BandData(salemanuserid);
        }
    }
}
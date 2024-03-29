﻿using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Web.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web.My.User.Coupons
{
    public partial class CashWhenFeeValidate : PageBase_MyUser
    {
        DataBase db = DataBase.Create();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var code = WebUtility.GetRequestStr("code", "");
                if (!string.IsNullOrWhiteSpace(code)) BandData(code);
            }
        }

        private void BandData(string code)
        {
            var list = db.Select("vw_Coupons_CashWhenFee_UseLog", string.Format("UseCode= '{0}' and SaleManUserID={1}", code, this.LoginUser.UserID), "UseCount desc");
            if (list == null || list.Rows.Count <= 0) return;

            rpResult.DataSource = list;
            rpResult.DataBind();

            decimal totalFee = 0;
            decimal totalMoney = 0;
            foreach (DataRow item in list.Rows)
            {
                totalFee += item["fee"].GetDecimal() * item["usecount"].GetInt();
                totalMoney += item["money"].GetDecimal() * item["usecount"].GetInt();
            }

            rpTotal.DataSource = new List<object> { new {
                totalfee=totalFee.ToString("0.00"),
                totalmoney=totalMoney.ToString("0.00"),
                createtime=list.Rows[0]["createtime"].GetDateTime(),
                usecode=list.Rows[0]["usecode"].GetStr()} 
            };
            rpTotal.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("CashWhenFeeValidate.aspx?code=" + HttpUtility.UrlEncode(txtCode.Text), true);
        }
    }
}
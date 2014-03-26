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
    public partial class Lists : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BandData();
            }
        }

        private void BandData()
        {
            var db = DataBase.Create();

            var subjectid = WebUtility.GetRequestInt("subjectid",-1);
            var pageSize = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("pagesize", PageBase.DataList_PageSize);
            var pageIndex = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("page", 1);

            db.EnableRecordCount = true;
            rpResult.DataSource = db.Select(pageSize, pageIndex,"vw_coupons_list","id", "subjectid = " + subjectid, "isuse, userid desc, money desc");
            rpResult.DataBind();

            this.Pager1.AppendUrlParam("subjectid", subjectid.ToString());
            this.Pager1.PageSize = ADeeWu.HuoBi3J.Libary.Utility.GetInt(pageSize, 0);
            this.Pager1.PageIndex = ADeeWu.HuoBi3J.Libary.Utility.GetInt(pageIndex, 0);
            this.Pager1.TotalRecords = ADeeWu.HuoBi3J.Libary.Utility.GetInt(db.RecordCount, 0);

            var Counts = new List<string>();
            var count = 0;
            var dtMoneyCounts = DataBase.Create().Select(string.Format("select [money],COUNT([money]) as money_count from dbo.Coupons_List where subjectid = {0} group by [money]", subjectid));
            foreach (DataRow item in dtMoneyCounts.Rows)
            {
                Counts.Add(string.Format("金额：{0}，数量：{1}", item["money"], item["money_count"]));
                count += Utility.GetInt(item["money_count"], 0);
            }
            Counts.Add(string.Format("共{0}张券", count));
            litSpecial.Text = string.Join("<br />", Counts);
        }
    }
}
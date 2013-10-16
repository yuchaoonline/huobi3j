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
using ADeeWu.HuoBi3J.Web.Class;
using System.Text;
using System.Collections.Generic;
using ADeeWu.HuoBi3J.SQL;

namespace ADeeWu.HuoBi3J.Web.My.User.SupplyDemand
{

    public partial class Show : PageBase_MyUser
    {

        protected ADeeWu.HuoBi3J.DAL.SD_SupplyDemands dal = new ADeeWu.HuoBi3J.DAL.SD_SupplyDemands();
        protected DataBase db = DataBase.Create();

        long id = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("id", 0);
        long pageSize = 20;
        long pageIndex = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            pageSize = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlInt("pagesize", ADeeWu.HuoBi3J.Web.Admin.PageBase.DataList_PageSize);
            pageIndex = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlInt("page", 1);

            if (!IsPostBack)
            {

                ADeeWu.HuoBi3J.Model.SD_SupplyDemands entity = dal.GetEntity(id);
                if (entity != null)
                {
                    litTitle.Text = entity.Title;
                    litCreateTime.Text = entity.CreateTime.ToString("yyyy/MM/dd HH:mm");
                    litSummary.Text = entity.Summary;
                    litContent.Text = entity.Content;
                    // litVisitCount.Text = entity.VisitCount + "次";
                }
                else
                {
                    ADeeWu.HuoBi3J.Libary.WebUtility.ShowAndGoBack(this, "没有找到您要修改的信息！");
                }

            }

            StringBuilder builderWhere = new StringBuilder();
            builderWhere.Append(" SupplyDemandID=@SupplyDemandID ");
            db.Parameters.Append("@SupplyDemandID", id);

            db.EnableRecordCount = true;
            this.rptData.DataSource = db.Select(pageSize, pageIndex, "vw_SD_Bidders", "ID", builderWhere.ToString(), "ModifyTime desc");
            this.rptData.DataBind();
            this.Pager1.PageSize = ADeeWu.HuoBi3J.Libary.Utility.GetInt(pageSize, 0);
            this.Pager1.PageIndex = ADeeWu.HuoBi3J.Libary.Utility.GetInt(pageIndex, 0);
            this.Pager1.TotalRecords = ADeeWu.HuoBi3J.Libary.Utility.GetInt(db.RecordCount, 0);
            db.EnableRecordCount = false;

        }

        public void aa(Object Sender, RepeaterCommandEventArgs e)
        {
            Response.Write("slfjsljf;slkdjfl;");

        }

        protected void rptData_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Bidder")
            {
                string sdbid = e.CommandArgument.ToString();
                long sdid = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("id", 0);
                db.Parameters.Clear();
                db.Parameters.Append("@SDBID", sdbid);
                db.Parameters.Append("@SDID", sdid);
                db.Parameters.Append("@ErrorMessage", "", ParameterDirection.Output, DbType.String).Size = 1000;
                db.AutoClearParameters = false;
                if (ADeeWu.HuoBi3J.Libary.Utility.GetInt(db.RunProc("SP_SD_UpdataStatus"), -1) == 0)
                {
                    ADeeWu.HuoBi3J.Libary.WebUtility.ShowPageSelector(this, "操作成功!选择\"是\"继续操作", "DeFault.aspx", "Show.aspx?id=" + sdid);
                }
                else
                {
                    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("操作失败!错误原因:\r\n" + db.Parameters["@ErrorMessage"].Value.ToString());
                }
                db.Parameters.Clear();
                db.AutoClearParameters = true;

            }
        }

    }
}
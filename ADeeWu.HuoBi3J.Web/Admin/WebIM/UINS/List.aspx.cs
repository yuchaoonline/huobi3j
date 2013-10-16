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

namespace ADeeWu.HuoBi3J.Web.Admin.WebIM.UINS
{
    public partial class List : PageBase
    {

        public override string PageID
        {
            get
            {
                return "018003";
            }
        }

        DAL.IM_UINS dal = new ADeeWu.HuoBi3J.DAL.IM_UINS();
        protected void Page_Load(object sender, EventArgs e)
        {
            int pageSize = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlInt("pagesize", PageBase.DataList_PageSize);
            int pageIndex = ADeeWu.HuoBi3J.Libary.WebUtility.UpdateRequestInt("page", 1, true);

            string uin = ADeeWu.HuoBi3J.Libary.WebUtility.UpdateRequestStr("uin", "", true);
            

            string begintime = ADeeWu.HuoBi3J.Libary.WebUtility.UpdateRequestStr("time", "", true);
            string endtime = ADeeWu.HuoBi3J.Libary.WebUtility.UpdateRequestStr("time2", "", true);


            StringBuilder whereBuilder = new StringBuilder();

            if (uin != "")
            {
                whereBuilder.Append(" and UIN like @uin  ");
                dal.Parameters.Append("@uin", string.Format("%{0}%", uin));
                this.Pager1.AppendUrlParam("uin", uin);
            }
            
            if (begintime.Length > 0 && endtime.Length > 0)
            {
                whereBuilder.Append(" and CreateTime between @begintime and @endtime");
                dal.Parameters.Append("@begintime", string.Format("{0}", begintime + " 0:00"));
                dal.Parameters.Append("@endtime", string.Format("{0}", DateTime.Parse(endtime).AddDays(1).ToString("yyyy-MM-dd") + " 0:00"));
                this.Pager1.AppendUrlParam("time", begintime);
                this.Pager1.AppendUrlParam("time2", endtime);
            }
            else
            {
                if (begintime.Length > 0)
                {
                    whereBuilder.Append(" and CreateTime >= @begintime ");
                    dal.Parameters.Append("@begintime", string.Format("{0}", begintime + " 0:00"));
                    this.Pager1.AppendUrlParam("time", begintime);

                }
                if (endtime.Length > 0)
                {
                    whereBuilder.Append(" and CreateTime <= @endtime ");
                    dal.Parameters.Append("@endtime", string.Format("{0}", DateTime.Parse(endtime).AddDays(1).ToString("yyyy-MM-dd") + " 0:00"));
                    this.Pager1.AppendUrlParam("time", endtime);
                }

            }
            dal.EnableRecordCount = true;
            string where = whereBuilder.Length > 0 ? whereBuilder.ToString().Substring(4) : string.Empty;
            this.gvData.DataSource = dal.Select(pageSize, pageIndex, where, "");
            this.gvData.DataBind();
            this.Pager1.PageSize = pageSize;
            this.Pager1.PageIndex = pageIndex;
            this.Pager1.TotalRecords = (int)dal.RecordCount;
        }
    }
}

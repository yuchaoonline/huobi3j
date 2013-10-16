using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Libary;
using System.Text;

namespace ADeeWu.HuoBi3J.Web.My.Corp.CorpAgentManage.SearchCorpAgents
{
    
    public partial class Default : Class.PageBase_MyCorp
    {
        DataBase db = DataBase.Create();
        long pageSize = 20;
        long pageIndex = 1;
        long provinceId = -1;
        long cityId = -1;
        long areaId = -1;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            pageIndex = WebUtility.GetRequestInt("page", 1);
            pageSize = Utility.GetLong(Request["pagesize"], 20, 5, 20);
            provinceId = Utility.GetLong(Request["pid"], -1);
            cityId = Utility.GetLong(Request["cid"], -1);
            areaId = Utility.GetLong(Request["aid"], -1);
            if (!IsPostBack)
            {
                bindData();
            }
        }

        private void bindData()
        {
            StringBuilder whereBuilder = new StringBuilder();
            whereBuilder.Append(" IsHidden=0 and CheckState=1 ");

            this.syncSelectorLocation.Values = new string[]{
                "-1","-1","-1"
            };

            if (this.provinceId > 0)
            {
                whereBuilder.AppendFormat(" and ProvinceID={0}", this.provinceId);
                this.Pager1.AppendUrlParam("pid", this.provinceId.ToString());
                this.syncSelectorLocation.Values[0] = this.provinceId.ToString();
            }

            if (this.cityId > 0)
            {
                whereBuilder.AppendFormat(" and CityID={0}", this.cityId);
                this.Pager1.AppendUrlParam("cid", this.cityId.ToString());
                this.syncSelectorLocation.Values[1] = this.cityId.ToString();
            }

            if (this.areaId > 0)
            {
                whereBuilder.AppendFormat(" and AreaID={0}", this.areaId);
                this.Pager1.AppendUrlParam("aid", this.areaId.ToString());
                this.syncSelectorLocation.Values[2] = this.areaId.ToString();
            }

            db.EnableRecordCount = true;
            this.gvData.DataSource = db.Select(pageSize, pageIndex, "vw_CA_QualifiedAgents", "id", whereBuilder.ToString(), "");
            this.gvData.DataBind();

            this.Pager1.PageSize = (int)pageSize;
            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.TotalRecords = (int)db.RecordCount;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.pageIndex = 1;
            string[] location = this.syncSelectorLocation.Values;
            this.provinceId = Utility.GetLong(location[0], -1);
            this.cityId = Utility.GetLong(location[1], -1);
            this.areaId = Utility.GetLong(location[2], -1);
            bindData();
        }
    }
}

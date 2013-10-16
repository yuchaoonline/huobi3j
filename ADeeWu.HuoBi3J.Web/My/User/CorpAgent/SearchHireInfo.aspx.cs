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
using System.Collections.Generic;
using System.Text;
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.Web.My.User.CorpAgent
{
    public partial class SearchHireInfo : ADeeWu.HuoBi3J.Web.Class.PageBase_MyUser
    {

        public override string FunctionCode
        {
            get
            {
                return "My-User-CorpAgent-SearchCorps";
            }
        }




        DataBase db = DataBase.Create();
        long pageSize = 20;
        long pageIndex = 1;
        string corpName = string.Empty;
        long provinceID = -1;
        long cityID = -1;
        long areaID = -1;


        protected void Page_Load(object sender, EventArgs e)
        {

            pageSize = Utility.GetLong(Request["pagesize"], 20, 5, 20);
            pageIndex = WebUtility.GetRequestLong("page", 1);

            if (!IsPostBack)//获取外部参数
            {
                corpName = WebUtility.GetRequestStr("corpName", "");
                provinceID = WebUtility.GetRequestLong("provinceID", -1);
                cityID = WebUtility.GetRequestLong("cityID", -1);
                areaID = WebUtility.GetRequestLong("areaID", -1);
                bindData();
            }

        }

        void bindData()
        {

            string[] locationValues = new string[] { "-1","-1", "-1" };


            StringBuilder builderWhere = new StringBuilder();
            builderWhere.Append(" CheckState=1 ");
            

            if (corpName.Length > 0)
            {
                builderWhere.Append(" and CorpName like @CorpName");
                db.Parameters.Append("@CorpName", string.Format("%{0}%", corpName));
                this.Pager1.AppendUrlParam("corpName", corpName);
                this.txtCorpName.Text = corpName;
            }

            if (provinceID > 0)
            {
                builderWhere.Append(" and ProvinceID=" + provinceID);
                this.Pager1.AppendUrlParam("provinceID", provinceID.ToString());
                locationValues[0] = provinceID.ToString();
            }

            if (cityID > 0)
            {
                builderWhere.Append(" and CityID=" + cityID);
                this.Pager1.AppendUrlParam("CityID", cityID.ToString());
                locationValues[1] = cityID.ToString();
            }

            if (areaID > 0)
            {
                builderWhere.Append(" and AreaID=" + areaID);
                this.Pager1.AppendUrlParam("AreaID", areaID.ToString());
                locationValues[2] = areaID.ToString();
            }

            this.syncSelectorLocation.Values = locationValues;

            db.EnableRecordCount = true;
            this.rpData.DataSource = db.Select(pageSize, pageIndex, "vw_CA_HireInfos", "id", builderWhere.ToString(), "CreateTime desc");
            this.rpData.DataBind();
            this.Pager1.PageSize = (int)pageSize;
            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.TotalRecords = (int)db.RecordCount;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            pageIndex = 1;
            corpName = Utility.GetStr(Request.QueryString["corpName"], this.txtCorpName.Text, "", true);
            string[] values = this.syncSelectorLocation.Values;
            provinceID = Utility.GetLong(Request.QueryString["provinceID"], values[0], -1);
            cityID = Utility.GetLong(Request.QueryString["cityID"], values[1], -1);
            areaID = Utility.GetLong(Request.QueryString["areaID"], values[2], -1);
            bindData();
        }

      

    }
}

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
using System.Collections.Generic;
using System.Data.SqlClient;
using ADeeWu.HuoBi3J.SQL;

namespace ADeeWu.HuoBi3J.Web.Admin.CP_Promotions
{

    /// <summary>
    /// 
    /// </summary>
    public partial class List : PageBase
    {
        ADeeWu.HuoBi3J.DAL.Corporations dal = new ADeeWu.HuoBi3J.DAL.Corporations();


        public override string PageID
        {
            get
            {
                return "010003";
            }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {

            DataBase db = DataBase.Create();
            
            long pageSize = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("pagesize", PageBase.DataList_PageSize);
            long pageIndex = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("page", 1);


            string corpName = ADeeWu.HuoBi3J.Libary.Utility.GetStr(Request.QueryString["corp"], Request.Form["corp"], "", true);
            long calling01 = ADeeWu.HuoBi3J.Libary.Utility.GetLong(Request.QueryString["calling01"], Request.Form["calling01"], -1);
            long calling02 = ADeeWu.HuoBi3J.Libary.Utility.GetLong(Request.QueryString["calling02"], Request.Form["calling01"], -1);
            long province = ADeeWu.HuoBi3J.Libary.Utility.GetLong(Request.QueryString["province"], Request.Form["province"], -1);
            long city = ADeeWu.HuoBi3J.Libary.Utility.GetLong(Request.QueryString["city"], Request.Form["city"], -1);
            long area = ADeeWu.HuoBi3J.Libary.Utility.GetLong(Request.QueryString["area"], Request.Form["area"], -1);
            int stateValue = ADeeWu.HuoBi3J.Libary.Utility.GetInt(Request.QueryString["state"], Request.Form["state"], -1); 



            StringBuilder builderWhere = new StringBuilder();
            
            if (corpName != "")
            {
                builderWhere.Append(" and CorpName like @CorpName");
                db.Parameters.Append("@CorpName", string.Format("%{0}%", corpName));
                this.Pager1.AppendUrlParam("corp", corpName);
                this.corp.Value = corpName;
            }

            if (calling01 > 0 || calling02 > 0)
            {
                builderWhere.Append(" and CallingID=@CallingID");
                if (calling02 > 0)
                {
                    db.Parameters.Append("@CallingID", calling02);
                    this.Pager1.AppendUrlParam("calling02", calling02.ToString());
                }
                else
                {
                    db.Parameters.Append("@CallingID", calling01);
                    this.Pager1.AppendUrlParam("calling01", calling01.ToString());
                }
                
            }

            if (province > 0)
            {
                builderWhere.Append(" and ProvinceID=@ProvinceID");
                db.Parameters.Append("@ProvinceID", province);
                this.Pager1.AppendUrlParam("province", province.ToString());
            }
            if (city > 0)
            {
                builderWhere.Append(" and CityID=@CityID");
                db.Parameters.Append("@CityID", city);
                this.Pager1.AppendUrlParam("city", city.ToString());
            }
            if (area > 0)
            {
                builderWhere.Append(" and AreaID=@AreaID");
                db.Parameters.Append("@AreaID", area);
                this.Pager1.AppendUrlParam("area", area.ToString());
            }

            if (stateValue >= 0)
            {
                builderWhere.Append(" and CheckState=@CheckState");
                db.Parameters.Append("@CheckState", stateValue);
                this.Pager1.AppendUrlParam("state", stateValue.ToString());
                this.state.Value = stateValue.ToString();
            }

            //string where = string.Format(" AdminUserID = {0}", base.LoginUser.UserID) + (
            //        (builderWhere.Length > 0) ? builderWhere.ToString().Substring(1) : string.Empty
            //);

            string where = "" + (
                   (builderWhere.Length > 0) ? builderWhere.ToString().Substring(4) : string.Empty
           );


            this.syncSelectorCalling.Values = new string[]
            {
                calling01.ToString(),calling02.ToString()
            };
            this.syncSelectorLocation.Values = new string[]
            {
                province.ToString(),city.ToString(),area.ToString()
            };
            this.state.Value = stateValue.ToString();
            this.corp.Value = corpName;

            db.EnableRecordCount = true;
            this.gvData.DataSource = db.Select(pageSize, pageIndex, "vw_CP_Promotions", "id", where, "CreateTime desc");
            this.gvData.DataBind();
            this.Pager1.PageSize = ADeeWu.HuoBi3J.Libary.Utility.GetInt(pageSize, 0);
            this.Pager1.PageIndex = ADeeWu.HuoBi3J.Libary.Utility.GetInt(pageIndex, 0);
            this.Pager1.TotalRecords = ADeeWu.HuoBi3J.Libary.Utility.GetInt(db.RecordCount, 0);
            db.EnableRecordCount = false;
            

        }
    }
}

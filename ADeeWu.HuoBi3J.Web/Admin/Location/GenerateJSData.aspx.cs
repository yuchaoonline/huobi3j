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
using ADeeWu.HuoBi3J.SQL;
using System.Text;

namespace ADeeWu.HuoBi3J.Web.Admin.Location
{
    public partial class GenerateJSData : System.Web.UI.Page
    {
        DataBase db = DataBase.Create();

        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            string splitor = ",";


            DataTable dtProvince = db.Select("select * from Provinces order by id");
            foreach (DataRow dr in dtProvince.Rows)
            {
                builder.AppendFormat(",['{0}','{1}','{2}',{3},'{4}']",
                    "0",dr["ID"],dr["Name"],0,"0"
                    );
            }
            long provinceID = ADeeWu.HuoBi3J.Libary.Utility.GetLong(dtProvince.Rows[0]["id"], 0);


            DataTable dtCity = db.Select("select * from Citys order by id");
            foreach (DataRow dr in dtCity.Rows)
            {
                builder.AppendFormat(",['{0}','{1}','{2}',{3},'{4}']",
                    dr["Pid"], dr["ID"], dr["Name"], 1, "0" + splitor + dr["PID"].ToString()
                    );
            }


            DataTable dtArea = db.Select("select A.id,A.Name,C.ID as CityID,C.PID as ProvinceID from Areas as A left join Citys as C on A.cid = C.ID order by A.id");
            foreach (DataRow dr in dtArea.Rows)
            {
                builder.AppendFormat(",['{0}','{1}','{2}',{3},'{4}']",
                    dr["CityID"], dr["ID"], dr["Name"], 2, "0" + splitor + dr["ProvinceID"].ToString() + splitor + dr["CityID"].ToString() 
                    );
            }
            string content = (builder.Length > 0) ? builder.ToString().Substring(1) : string.Empty;
            content = string.Format("var aryLocation=[{0}];", content);

            ADeeWu.HuoBi3J.SQL.Logger.TextLogger logger = new ADeeWu.HuoBi3J.SQL.Logger.TextLogger(Server.MapPath("/js/data/") + "Location.js");
            logger.LogOverWrite(content);
            logger.Dispose();
        }
    }
}

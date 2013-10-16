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

namespace ADeeWu.HuoBi3J.Web.Admin.Job_Categories
{
    public partial class GenerateJSData : PageBase
    {

        public override string PageID
        {
            get
            {
                return "016011";
            }
        }

        DataBase db = DataBase.Create();

        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder builder = new StringBuilder();


            DataTable dtProvince = db.Select("select * from Job_Categories order by depth,id asc");
            foreach (DataRow dr in dtProvince.Rows)
            {
                builder.AppendFormat(",['{0}','{1}','{2}',{3},'{4}']",
                    dr["ParentID"], dr["ID"], dr["Name"], dr["Depth"], ResolveParentPath(dr["ParentPath"].ToString())
                    );
            }
            
            string content = (builder.Length > 0) ? builder.ToString().Substring(1) : string.Empty;
            content = string.Format("var aryJobCategories=[{0}];", content);

            ADeeWu.HuoBi3J.SQL.Logger.TextLogger logger = new ADeeWu.HuoBi3J.SQL.Logger.TextLogger(Server.MapPath("/js/data/") + "JobCategories.js");
            logger.LogOverWrite(content);
            logger.Dispose();

            if (!db.HasError)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "操作成功!已生成缓冲数据文件,地址:/Js/data/JobCategories.js", "List.aspx");
            }
            else
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "操作失败!");
            }
        }

        string ResolveParentPath(string parentPath)
        {
            if (parentPath.Length == 0) return string.Empty;
            if (parentPath.EndsWith(","))
            {
                return parentPath.Substring(0, parentPath.Length - 1);
            }
            return parentPath;
        }
    }
}

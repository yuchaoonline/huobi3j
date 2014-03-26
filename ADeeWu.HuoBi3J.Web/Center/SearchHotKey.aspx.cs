using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web.Center
{
    public partial class SearchHotKey : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        DAL.Key_HotKey hotkeyDAL = new DAL.Key_HotKey();
        private void BindData()
        {
            var hotkeys = hotkeyDAL.GetEntityList("", new string[] { }, new object[] { });
            var types = hotkeys.Select(p => p.DataType).Distinct();

            StringBuilder sb = new StringBuilder();
            foreach (var datatype in types)
            {
                sb.AppendFormat("<div class='filter-label-list filter-section category-filter-wrapper'><div class='label has-icon'><i></i>{0}：</div><ul class='inline-block-list'>", datatype);
                foreach (var key in hotkeys.Where(p => p.DataType == datatype))
                {
                    sb.AppendFormat("<li class='item'><a href='{0}' target='_blank' title='{1}'>{1}</a></li>", key.DataLink, key.Name);
                }
                sb.Append("</ul></div>");
            }

            litResult.Text = sb.ToString();
        }
    }
}
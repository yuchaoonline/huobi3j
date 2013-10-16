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

namespace ADeeWu.HuoBi3J.Web.Controls
{
    public partial class FavControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 搜藏类型：0是房源信息收藏，1是职位收藏,2是竞投报价，3是在线营销
        /// </summary>
        public int FavType { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public long UserID { get; set; }
        /// <summary>
        /// 信息编号
        /// </summary>
        public long ObjectID
        {
            get;
            set;
        }
        
    }
}
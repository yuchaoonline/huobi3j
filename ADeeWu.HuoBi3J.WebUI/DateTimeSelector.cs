using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.WebUI
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:DateTimeSelector runat=server></{0}:DateTimeSelector>")]
    public class DateTimeSelector : System.Web.UI.WebControls.TextBox
    {

        public DateTimeSelector()
        {

        }



        [Category("Settings")]
        [Description(@"设置或获取是否显示时间")]
        [DefaultValue(false)]
        [Localizable(true)]
        public bool ShowTime
        {
            get
            {
                String s = (String)ViewState[string.Format("Selector_{0}_ShowTime", this.ID)];
                return string.Compare(s, "true", true) == 0 ? true : false;
            }
            set
            {
                ViewState[string.Format("Selector_{0}_ShowTime", this.ID)] = value;
            }
        }

        //[Category("Settings")]
        //[Description("获取或设置默认日期/时间")]
        //[DefaultValue("默认为当前日期/时间")]
        //public DateTime DefaultDateTime
        //{
        //    get {
        //        object o = ViewState[string.Format("Selector_{0}_DefaultDateTime", this.ID)];
        //        if (o == null) return DateTime.Now;
        //        return (DateTime)o;
        //    }
        //    set {
        //        ViewState[string.Format("Selector_{0}_DefaultDateTime", this.ID)] = value;

        //    }
        //}
        

       


        protected override void OnPreRender(EventArgs e)
        {
            if (this.Page != null)
            {
                this.Page.ClientScript.RegisterClientScriptResource(typeof(DateTimeSelector), "ADeeWu.HuoBi3J.WebUI.Client.jquery.js");
                this.Page.ClientScript.RegisterClientScriptResource(typeof(DateTimeSelector), "ADeeWu.HuoBi3J.WebUI.DateTimeSelectorClient.jquery.dynDateTime.js");
                this.Page.ClientScript.RegisterClientScriptResource(typeof(DateTimeSelector), "ADeeWu.HuoBi3J.WebUI.DateTimeSelectorClient.lang.calendar-zh.js");
            }
            base.OnPreRender(e);
        }

        public override void RenderControl(HtmlTextWriter writer)
        {
            base.RenderControl(writer);
            StringBuilder html =  new StringBuilder();

            html.AppendFormat(@"<link rel=""stylesheet"" type=""text/css"" media=""all"" href=""{0}""  />", this.Page.ClientScript.GetWebResourceUrl(typeof(DateTimeSelector), "ADeeWu.HuoBi3J.WebUI.DateTimeSelectorClient.css.calendar-blue.css"));
            
            
            html.AppendFormat(@"
<script type=""text/javascript"">
$(document).ready(function(){{
   $('#{0}').dynDateTime(
     {{
        {1}
        daFormat : '%Y-%m-%d',
        timeFormat : '24'
      }}
   );
}});
</script>",
          this.ClientID,
          (this.ShowTime)?"showsTime : true,":string.Empty
);
            writer.Write(html.ToString().Replace("$1","{").Replace("$2","}"));

              

        }
    }
}

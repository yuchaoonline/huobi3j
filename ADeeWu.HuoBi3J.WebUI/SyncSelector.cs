using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ADeeWu.HuoBi3J.WebUI
{

    /// <summary>
    /// 同步选择器,适用于递归模型结构的数据集合,要使用多个数据库源关联的数据集请使用SyncSelector
    /// </summary>
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:SyncSelector runat=server></{0}:SyncSelector>")]
    public class SyncSelector: WebControl,IPostBackDataHandler
    {

        private string selectedValueKey = "_value";
        private string selectedTextKey = "_text";
        //临时值,用于输出和获取
        private string selectedValue = string.Empty;
        private string[] values = null;
        private string[] texts = null;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (this.Page != null)
            {
                this.Page.RegisterRequiresPostBack(this);
            }
        }

        private bool hasSelected = false;
        /// <summary>
        /// 获取客户端是否有选择其中一个下拉菜单,该属性只有在IsPostBack为True 时判断有效<para></para>
        /// 当有数据提交时,遍历<paramref name="Values"/>集合是否存在<paramref name="DefaultValue" />属性以外的值
        /// </summary>
        public bool HasSelected
        {
            get { return hasSelected; }
        }


        /// <summary>
        /// 设置或获取是否自动初始化客户端依赖资源,主要指JS库(默认:True)
        /// </summary>
        /// <remarks>
        /// 由于有些情况下,页面已经包含了Jquery 库,并且安装了插件,
        /// 这时如果调用该控件再输出一次jquery 库的话,将会使原来的插件失效
        /// </remarks>
        public bool InitClientDependency
        {
            get
            {
                bool? temp = ViewState[this.ID + "_InitClientDependency"] as bool?;
                if (temp != null) return temp.Value;
                ViewState[this.ID + "_InitClientDependency"] = true;
                return true;
            }
            set
            {
                ViewState[this.ID + "_InitClientDependency"] = value;
            }
        }

        
        
        /// <summary>
        /// 设置或获取是否刷新客户端所使用的数据(默认:False)
        /// </summary>
        public bool RefreshClientData
        {
            get {
                bool? temp = ViewState[this.ID + "_RefreshClientData"] as bool?;
                if (temp != null) return temp.Value;
                ViewState[this.ID + "_RefreshClientData"] = false;
                return false;
            }
            set {
                ViewState[this.ID + "_RefreshClientData"] = value;
            }
        }

        /// <summary>
        /// 设置控制件容器,默认为id_container,多个容器用逗号分开
        /// </summary>
        public string ContainerClientID
        {
            get
            {
                object o = ViewState[this.ID + "_Container"];
                if (o != null) return o.ToString();
                return this.ID + "_container";
            }
            set
            {
                
                ViewState[this.ID + "_Container"] = value;
            }
        }

        /// <summary>
        /// 客户端提交数据的表单名称,各级下拉菜单的name 属性,多个name 用逗号分开
        /// </summary>
        public string ClientPostNames
        {
            get
            {
                object o = ViewState[this.ID + "_ClientPostNames"];
                if (o != null) return o.ToString().Trim();
                return this.ID + "_ClientPostNames";
            }
            set
            {
                ViewState[this.ID + "_ClientPostNames"] = value;
            }
        }

        /// <summary>
        /// 数据源URL(JS文件URL)
        /// </summary>
        [DefaultValue("")]
        [Description("数据源URL(JS文件URL)")]
        public string DataSourceURL
        {
            get
            {
                object o = ViewState[this.ID + "_DataSource"];
                return o == null ? string.Empty : o.ToString();
            }
            set { ViewState[this.ID + "_DataSource"] = value; }
        }

        /// <summary>
        /// 数据源名称
        /// </summary>
        [DefaultValue("")]
        [Description("数据源名称")]
        public string DataSourceName
        {
            get
            {
                object o = ViewState[this.ID + "_DataSourceName"];
                return o == null ? string.Empty : o.ToString();
            }
            set { ViewState[this.ID + "_DataSourceName"] = value; }
        }




        /// <summary>
        /// 设置或获取最后一选择的值,详细使用请查看Remarks
        /// </summary>
        /// <remarks>
        /// 对于递归模型的数据结构,可使用该属性来直接设置菜单选择项
        /// 对于多数据源关联的数据结构请使用Values 来设置菜单选择项
        /// </remarks>
        [Description("获取最后一选择的值")]
        public string SelectedValue
        {
            get
            {
                return this.selectedValue;
            }
            set { this.selectedValue = value; }
        }


        /// <summary>
        /// 设置或获取各个选择器的值,当与SelectedValue 同时使用设置菜单的选择值，SelectedValue 将会被忽略
        /// </summary>
        public string[] Values
        {
            get
            {
                return values;
            }
            set
            {
                values = value;
            }
        }

        /// <summary>
        /// 获取各个选择器的文本
        /// </summary>
        public string[] Texts
        {
            get { return this.texts; }
        }


        /// <summary>
        /// 客户端渲染后的回调脚本
        /// </summary>
        public string ClientOnRenederedCallback
        {
            get
            {
                object o = ViewState[this.ID + "_ClientOnRenederedCallback"];
                return o == null ? this.ID + "_onRendered" : o.ToString();
            }
            set { ViewState[this.ID + "_ClientOnRenederedCallback"] = value; }
        }

        /// <summary>
        /// 设置或获取各级下拉菜单的默认值(默认:-1)
        /// </summary>
        public string DefaultValue
        {
            get
            {
                object o = ViewState[this.ID + "_DefaultValue"];
                return o == null ? "-1" : o.ToString();
            }
            set { ViewState[this.ID + "_DefaultValue"] = value; }
        }

        /// <summary>
        /// 设置或获取各级下拉菜单的默认文本(默认:请选择)
        /// </summary>
        public string DefaultText
        {
            get
            {
                object o = ViewState[this.ID + "_DefaultText"];
                return o == null ? "请选择" : o.ToString();
            }
            set { ViewState[this.ID + "_DefaultText"] = value; }
        }


        /// <summary>
        /// 解释客户端SyncSelector构造函数里的op参数
        /// </summary>
        /// <returns></returns>
        private string ResolveSyncSelectorOption()
        {
            string resolveContainer = string.Empty;
            StringBuilder builder = new StringBuilder();
            if (this.ContainerClientID.IndexOf(',') > -1)
            {
                foreach (string c in this.ContainerClientID.Split(','))
                {
                    builder.AppendFormat(",'#{0}'", c);
                }
            }

            resolveContainer = (builder.Length > 0) ?
                string.Format("[{0}]", builder.ToString().Substring(1))
                :
                string.Format("['#{0}']", this.ContainerClientID);

            return string.Format("$1 defaultValue : {0},defaultText : '{1}', containers : {2} $2",
                this.DefaultValue, this.DefaultText, resolveContainer).Replace("$1", "{").Replace("$2", "}");
        }

        /// <summary>
        /// 解释客户端SyncSelector各级下拉菜单的name属性
        /// </summary>
        /// <returns></returns>
        private string ResolveSyncSelectorNames()
        {
            if (this.ClientPostNames.Length == 0)
            {
                throw new Exception("没有初始化ClientPostNames属性");
            }
            if (this.ClientPostNames.IndexOf(',') < 0) return string.Format("['{0}']", this.ClientPostNames);

            StringBuilder builder = new StringBuilder();
            foreach (string name in this.ClientPostNames.Split(','))
            {
                builder.AppendFormat(",'{0}'", name);
            }
            if (builder.Length > 0)
            {
                return string.Format("[{0}]", builder.ToString().Substring(1));
            }
            return this.ID;
        }

        private string ResolveSyncSelectorSelectItemScript()
        {
            if (this.Values != null && this.Values.Length > 0)
            {
                StringBuilder builder = new StringBuilder();
                foreach (string value in this.Values)
                {
                    if (value.Trim() != "")
                    {
                        builder.AppendFormat(">{0}", value);
                    }
                }
                if (builder.Length > 0)
                {
                    return string.Format("\r\n{0}.selectItem('orderkeys:{1}');", this.ID, builder.ToString().Substring(1));
                }
            }

            if (this.SelectedValue.Length > 0)
            {
                return string.Format("\r\n{0}.selectItem('{1}');", this.ID, this.SelectedValue);
            }
            return string.Empty;
        }



        protected override void OnPreRender(EventArgs e)
        {
            if (this.Page != null && this.InitClientDependency)
            {
                this.Page.ClientScript.RegisterClientScriptResource(typeof(SyncSelector), "ADeeWu.HuoBi3J.WebUI.Client.jquery.js");
                this.Page.ClientScript.RegisterClientScriptResource(typeof(SyncSelector), "ADeeWu.HuoBi3J.WebUI.Client.isc.js");
                this.Page.ClientScript.RegisterClientScriptResource(typeof(SyncSelector), "ADeeWu.HuoBi3J.WebUI.Client.isc.ui.control.syncSelector.js");
            }
            base.OnPreRender(e);
        }


        public override void RenderControl(HtmlTextWriter writer)
        {
            if (this.DataSourceURL.Length == 0)
            {
                throw new Exception("未初始化数据源URL,属性:DataSourceURL");
            }

            if (this.DataSourceName.Length == 0)
            {
                throw new Exception("未初始化数据源客户端标识名称,属性:DataSourceName");
            }

            StringBuilder html = new StringBuilder();
            if (this.RefreshClientData)
            {
                html.AppendFormat("<script type='text/javascript'src='{0}?{1}'></script>", this.DataSourceURL, DateTime.Now);
            }
            else
            {
                html.AppendFormat("<script type='text/javascript'src='{0}'></script>", this.DataSourceURL);
            }
            html.AppendFormat("<span id='{0}_container'></span>", this.ID);

            string js = string.Format(@"
$(document).ready(function()
$1
if (typeof {0} == 'undefined' ) return;
var cascadeData = new isc.data.cascade.CascadeData({0});
window.{1} = new isc.ui.control.SyncSelector(cascadeData,'{1}',{2},{3});
if(typeof {5} == 'function')$1
  {1}.bindEvent('onRendered',{5},null);
$2
{1}.render();{4}
$2);", this.DataSourceName, this.ID, this.ResolveSyncSelectorNames(), this.ResolveSyncSelectorOption(), this.ResolveSyncSelectorSelectItemScript(),this.ClientOnRenederedCallback
                      ).Replace("$1", "{").Replace("$2", "}");

            html.AppendFormat("<script  type='text/javascript'>{0}\r\n</script>", js);

           // this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), this.ID + "_script", html.ToString());
            writer.Write(html.ToString());

        }

        protected override void RenderContents(HtmlTextWriter output)
        {
            output.Write(string.Format("<span style='color:red;'>{0}</span>", this.ID));

        }



        #region IPostBackDataHandler Members

       public bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        {

            if (this.Page.IsPostBack)
            {
                //更新客户端提交过来的SelectedValue值，Values值,Texts值

                //Values 值更新
                //if (this.ClientPostNames.IndexOf(',') > 0)
                //{
                //    string[] names = this.ClientPostNames.Split(',');
                //    this.values = new string[names.Length];
                //    for (int i = 0; i < names.Length; i++)
                //    {
                //        this.values[i] = this.Page.Request.Form[names[i]] + "";
                //    }
                //}

                //设置Values 长度为ClientPostNames 所指定的个数
                this.values = new string[this.ClientPostNames.Split(',').Length];
                for (int i = 0; i < this.values.Length; i++)
                {
                    this.values[i] = this.DefaultValue;
                }
                string[] postValues = (postCollection[this.ID + selectedValueKey] + "").Split(',');
                //赋予有效值
                for (int i = 0; i < postValues.Length && i < this.values.Length; i++)
                {
                    this.values[i] = postValues[i];
                }
           

                //Texts 值更新
                this.texts = new string[this.values.Length];
                for (int i = 0; i < this.texts.Length; i++)
                {
                    this.texts[i] = this.DefaultText;
                }
                //赋予有效值
                string[] postTexts = (postCollection[this.ID + selectedTextKey] + "").Split(',');
                for (int i = 0; i < postTexts.Length && i < this.texts.Length; i++)
                {
                    this.texts[i] = postTexts[i];
                }
                        
                //SelectedValue 值更新 与 HasSelected 值更新
                this.selectedValue = string.Empty;
                if (this.values.Length > 0)
                {
                    for (int i = this.values.Length - 1; i >= 0; i--)
                    {
                        string s = this.values[i];
                        if (s == this.DefaultValue) continue;
                        this.selectedValue = s;
                        this.hasSelected=true;
                        break;
                    }
                }
                if (!this.hasSelected)
                {
                    this.selectedValue = this.DefaultValue;
                }
            }
            return true;
        }

        public void RaisePostDataChangedEvent()
        {
           
        }

        #endregion
    }
}

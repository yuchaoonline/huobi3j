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
    [ToolboxData("<{0}:Pager runat=server></{0}:Pager>")]
    public class Pager : WebControl
    {
        #region 枚举值
        /// <summary>
        /// Pager控件Url参数检测模式
        /// </summary>
        public enum UrlParamCheckMode
        {
            /// <summary>
            /// 默认,手动设置URL参数的值
            /// </summary>
            Manual = 0,
            /// <summary>
            /// 自动从表单更新当前所有URL参数的值
            /// </summary>
            AutoUpdateFromFrom = 1,
            /// <summary>
            /// 自动从Query更新当前所有URL参数的值
            /// </summary>
            AutoUpdateFromQuery = 2

        }
        #endregion

        #region 属性
        List<string[]> _urlManualSettingKeyValue = null;//url参数集合


        //private UrlParamCheckMode _urlParamCheckMode = UrlParamCheckMode.Manual;
        ///// <summary>
        ///// 设置
        ///// </summary>
        //public UrlParamCheckMode UrlSettingMode
        //{
        //    get { return _urlParamCheckMode; }
        //    set { _urlParamCheckMode = value; }
        //}

        private int _pageSize = 20;
        [Category("PagingParams")]
        [DefaultValue(20)]
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }

        private int _pageIndex = 1;
        [Category("PagingParams")]
        [DefaultValue(20)]
        public int PageIndex
        {
            get { return _pageIndex; }
            set
            {
                //int totalPages = (int)Math.Ceiling(((float)this.TotalRecords / (float)this.PageSize));
                //if (value > totalPages || value <= 0)
                //{
                //    _pageIndex = 1;
                //}
                //else
                //{
                //    _pageIndex = value;
                //}
                _pageIndex = value;
            }
        }

        private int _totalRecords = 0;
        [Category("PagingParams")]
        [DefaultValue(0)]
        [Description("要分页的总记录数")]
        public int TotalRecords
        {
            get { return _totalRecords; }
            set { _totalRecords = value; }
        }

        private string _showTextOnError = "当前没有数据";
        [Category("PagingParams")]
        [DefaultValue("当前没有数据")]
        [Description("设置或获取当发生错误 或 没有数据时显示的文本")]
        public string ShowTextOnError
        {
            get { return _showTextOnError; }
            set { _showTextOnError = value; }
        }

        private int _numOfShowPage = 10;
        [Category("PagingParams")]
        [DefaultValue(10)]
        [Description("显示页码的数量")]
        public int NumOfShowPage
        {
            get { return _numOfShowPage; }
            set { _numOfShowPage = value; }
        }

        private string _pagerFormatString = @"<div class=""pager"">
<span style=""margin-right:10px;"">总记录数:{totalrecords}</span><span style=""color:#f00;"">{pageindex}</span>/{totalpages}  
<a href='{first}' class='first-page'>首页</a><a href='{previous}' class='prev-page'>上一页</a>
{linklist}
<a href='{next}' class='next-page'>下一页</a><a href='{last}' class='last-page'>末页</a>
{selector}
{other}
</div>";

        /// <summary>
        /// 分页器格式化字符串
        /// </summary>
        [Category("PagingFormatString")]
        [DefaultValue(@"<div class=""pager"">
<span style=""margin-right:10px;"">总记录数:{totalrecords}</span><span style=""color:#f00;"">{pageindex}</span>/{totalpages}  
<a href='{first}' class='first-page'>首页</a><a href='{previous}' class='prev-page'>上一页</a>
{linklist}
<a href='{next}' class='next-page'>下一页</a><a href='{last}' class='last-page'>末页</a>
{selector}
{other}
</div>")]
        [Description(@"设置分页输出表格式化字符串
{totalpages} -- 总页数
{totalrecords} -- 总页数
{pageindex} -- 当前页码
{pagesize} -- 当前分页大小
{fullurl} -- 完整带额外参数的链接URL
{exturl} -- 额外附加参数的链接URL,带&符号
{first} -- 第一页链接url
{previous} -- 上一页链接url
{linklist} -- 分页列表区域 
{next} -- 下一页链接url
{last} -- 最后一页链接url
{selector} -- 页码选择控件,通过设置SelectorFormatString属性来设置输出格式
{other} -- 自定义输出,通过设置OrderFormatString属性来设置输出格式")]
        public string PagerFormatString
        {
            get { return _pagerFormatString; }
            set { _pagerFormatString = value; }
        }

        private string _urlFormatString = "?page={pagenum}&pagesize={pagesize}";
        /// <summary>
        /// 链接URL格式化字符串,一般情况不会设置该属性,而用AppendUrlFormat方法
        /// </summary>
        /// <![CDATA[
        /// ?page={pagenum}&pagesize={pagesize}
        /// ]]>
        [Category("PagingFormatString")]
        [DefaultValue("?page={pagenum}&pagesize={pagesize}")]
        [Description(@"设置链接URL格式化字符串
{pagesize} -- 当前每页大小
{pagenum} -- 循环输出的页码,页码从1开始
{totalrecords} -- 总记录数
{totalpages} -- 总记页数
")]
        public string UrlFormatString
        {
            get { return _urlFormatString; }
            set { _urlFormatString = value; }
        }

        //        private string _selectorUrlFormatString = "?page={pagenum}&pagesize={pagesize}";
        //        [Category("PagingFormatString")]
        //        [DefaultValue("?page={pagenum}&pagesize={pagesize}")]
        //        [Description(@"设置页码选择器URL格式化字符串
        //\r\n{pagesize} -- 当前每页大小
        //\r\n{pagenum} -- 循环输出的页码
        //\r\n{totalrecords} -- 总记录数
        //\r\n{totalpages} -- 总记页数
        //")]
        //        public string SelectorUrlFormatString
        //        {
        //            get { return _selectorUrlFormatString; }
        //            set { _selectorUrlFormatString = value; }
        //        }

        private string _otherFormatString = @" 
页码:<input type=""text"" id=""txtJumper"" style=""width:30px;"" value=""{pageindex}"" /> <input type=""button"" value=""转跳"" onclick=""location.href='?pagesize={pagesize}&page=' + document.getElementById('txtJumper').value + '{exturl}'"" />
每页大小:<input type=""text"" id=""txtPagesize"" style=""width:30px;"" value=""{pagesize}"" /> <input type=""button"" value=""设置"" onclick=""location.href='?page=1&pagesize=' + document.getElementById('txtPagesize').value + '{exturl}'"" />";

        /// <summary>
        /// 设置附加HTML格式化字符串
        /// </summary>
        [Category("PagingFormatString")]
        [DefaultValue(@" 
页码:<input type=""text"" id=""txtJumper"" style=""width:30px;"" /> <input type=""button"" value=""转跳"" onclick=""location.href='?pagesize={pagesize}&page=' + document.getElementById('txtJumper').value"" />
每页大小:<input type=""text"" id=""txtPagesize"" style=""width:30px;"" value=""{pagesize}"" /> <input type=""button"" value=""设置"" onclick=""location.href='?page=1&pagesize=' + document.getElementById('txtPagesize').value"" />")]
        [Description(@"自定义输出
{fullurl} -- 完整带额外参数的链接URL
{exturl} -- 额外参数的链接URL,带&符号
{pagesize} -- 当前每页大小
{pagenum} -- 循环输出的页码,页码从1开始
{totalrecords} -- 总记录数
{totalpages} -- 总记页数
")]
        public string OtherFormatString
        {
            get { return _otherFormatString; }
            set { _otherFormatString = value; }
        }

        private string _curPageCSS = "curPage";

        /// <summary>
        /// 设置或获取当前页码的CSS样式名称
        /// </summary>
        [Category("PagingFormatString")]
        [DefaultValue("curPage")]
        [Description(@"设置或获取当前页码的")]
        public string CurPageCSS
        {
            get { return _curPageCSS; }
            set { _curPageCSS = value; }
        }
        #endregion

        #region 方法
        protected override void RenderContents(HtmlTextWriter output)
        {
            if (/*PageIndex<1 || PageSize <1 ||*/ TotalRecords < 1)
            {
                output.Write(this.ShowTextOnError);
                return;
            }

            if (PageSize < 1)
            {
                PageSize = 20;
            }

            //计算总页数
            int totalPages = (int)Math.Ceiling(((float)this.TotalRecords / (float)this.PageSize));

            if (PageIndex < 1)
            {
                PageIndex = 1;
            }

            string resolveUrlformat = ResolveUrlFormat();
            string resolveExtUrlformat = ResolveExtUrlFormat();


            //构造选择控件html
            StringBuilder builderSelector = new StringBuilder();

            for (int i = 0; i < totalPages; i++)
            {
                string pagenum = (i + 1).ToString();
                if ((i + 1) == this.PageIndex)
                {
                    builderSelector.AppendFormat("<option value=\"{0}\" selected>{1}</option>\r\n",
                    resolveUrlformat.Replace("{pagenum}", pagenum),
                    pagenum
                    );
                }
                else
                {
                    builderSelector.AppendFormat("<option value=\"{0}\">{1}</option>\r\n",
                    resolveUrlformat.Replace("{pagenum}", pagenum),
                    pagenum
                    );

                }
            }

            //构造链接列表
            StringBuilder builderLinkList = new StringBuilder();

            if (totalPages > 2 && this.NumOfShowPage >= 2)
            {
                int numOfLeftLinks = (int)(this.NumOfShowPage / 2);//当前页面左边显示页码链接数量
                int numOfRightLinks = this.NumOfShowPage - numOfLeftLinks;//当前页面右边显示页码链接数量
                int startNum = this.PageIndex - numOfLeftLinks;
                if (startNum <= 0) startNum = 1;
                int endNum = this.PageIndex + numOfRightLinks;
                if (endNum > totalPages) endNum = totalPages;

                for (int i = startNum; i <= endNum; i++)
                {
                    if (i == this.PageIndex)
                    {
                        builderLinkList.AppendFormat("<a href=\"{0}\" class=\"{1}\">{2}</a>",
                           resolveUrlformat.Replace("{pagenum}", i.ToString()), this.CurPageCSS, i
                           );

                    }
                    else
                    {
                        builderLinkList.AppendFormat("<a href=\"{0}\" class=\"page-item\">{1}</a>",
                          resolveUrlformat.Replace("{pagenum}", i.ToString()),
                          i
                          );
                    }
                }
            }
            else//少于两页
            {
                for (int i = 0; i < totalPages; i++)
                {
                    string pagenum = (i + 1).ToString();
                    if ((i + 1) == this.PageIndex)
                    {
                        builderLinkList.AppendFormat("<a href=\"{0}\" class=\"{1}\">{2}</a>",
                          resolveUrlformat.Replace("{pagenum}", pagenum), this.CurPageCSS, pagenum
                          );
                    }
                    else
                    {
                        builderLinkList.AppendFormat("<a href=\"{0}\" class=\"page-item\">{1}</a>",
                          resolveUrlformat.Replace("{pagenum}", pagenum),
                          pagenum
                          );
                    }
                }
            }

            builderSelector.Insert(0, "<select onchange=\"location.href=this.options[this.selectedIndex].value\"; >\r\n");
            builderSelector.Insert(builderSelector.Length, "</select>");

            string htmlSelector = BasicFormat(builderSelector.ToString(), totalPages, resolveUrlformat, resolveExtUrlformat);

            string htmlLinkList = BasicFormat(builderLinkList.ToString(), totalPages, resolveUrlformat, resolveExtUrlformat);

            string htmlOther = BasicFormat(this.OtherFormatString, totalPages, resolveUrlformat, resolveExtUrlformat);

            int previous = this.PageIndex >= 2 ? this.PageIndex - 1 : this.PageIndex;
            int next = this.PageIndex < totalPages ? this.PageIndex + 1 : this.PageIndex;

            string pager = BasicFormat(
                this.PagerFormatString
                .Replace("{first}", resolveUrlformat.Replace("{pagenum}", "1"))
                .Replace("{previous}", resolveUrlformat.Replace("{pagenum}", previous.ToString()))
                .Replace("{linklist}", htmlLinkList)
                .Replace("{next}", resolveUrlformat.Replace("{pagenum}", next.ToString()))
                .Replace("{last}", resolveUrlformat.Replace("{pagenum}", totalPages.ToString()))
                .Replace("{selector}", htmlSelector)
                .Replace("{other}", htmlOther)
                ,
                totalPages
                ,
                resolveUrlformat
                ,
                resolveExtUrlformat
                );


            output.Write(pager);
        }

        /// <summary>
        /// 解析完整Url格式化字符串
        /// </summary>
        /// <returns>返回一个链接所需要完整的URL</returns>
        public string ResolveUrlFormat()
        {
            StringBuilder builder = new StringBuilder();
            if (this._urlManualSettingKeyValue != null)
            {
                foreach (string[] keyValue in this._urlManualSettingKeyValue)
                {
                    builder.AppendFormat("&{0}={1}", keyValue[0], HttpUtility.UrlEncode(keyValue[1]));
                }
            }

            string ret = UrlFormatString; //UrlFormatString.StartsWith("?") ? UrlFormatString : "?" + UrlFormatString;
            if (ret.EndsWith("&"))
            {
                ret = ret.Substring(0, ret.Length - 1);
            }

            return (builder.Length == 0) ? ret : ret + builder.ToString();
        }

        /// <summary>
        /// 解析额外Url格式化字符串
        /// </summary>
        /// <returns>返回一个额外提供参数的URL,该URL首字符为&</returns>
        public string ResolveExtUrlFormat()
        {
            if (this._urlManualSettingKeyValue == null) return string.Empty;

            StringBuilder builder = new StringBuilder();
            foreach (string[] keyValue in this._urlManualSettingKeyValue)
            {
                builder.AppendFormat("&{0}={1}", keyValue[0], HttpUtility.UrlEncode(keyValue[1]));
            }

            return (builder.Length == 0) ? string.Empty : builder.ToString();
        }

        ///// <summary>
        ///// 添加自动更新URL的参数,该函数只在设置UrlSettingMode 为AutoUpdateFromFrom , AutoUpdateFromQuery 有作用
        ///// </summary>
        ///// <param name="key"></param>
        //public void AppendUrlParam(string key)
        //{
        //    if (string.IsNullOrEmpty(key)) return;
        //    key = key.Trim();
        //    this._urlAutoUpdateKeys.Add(key);
        //}


        //添加手动设置的URL参数,该函数只在设置UrlSettingMode 为Manual 有作用
        /// <summary>
        /// 添加URL参数
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void AppendUrlParam(string key, string value)
        {
            if (_urlManualSettingKeyValue == null) _urlManualSettingKeyValue = new List<string[]>();
            _urlManualSettingKeyValue.Add(new string[] { key, value });
        }

        private string BasicFormat(string s, int totalpages, string fullUrl, string extendUrl)
        {
            return s.Replace("{pagesize}", this.PageSize.ToString())
                .Replace("{pageindex}", this.PageIndex.ToString())
                .Replace("{totalpages}", totalpages.ToString())
                .Replace("{totalrecords}", this.TotalRecords.ToString())
                .Replace("{fullurl}", fullUrl)
                .Replace("{exturl}", extendUrl);
        }
        #endregion
    }

    [DefaultProperty("Text")]
    [ToolboxData("<{0}:Pager2 runat=server></{0}:Pager>")]
    public class Pager2 : WebControl
    {
        #region 枚举值
        /// <summary>
        /// Pager控件Url参数检测模式
        /// </summary>
        public enum UrlParamCheckMode
        {
            /// <summary>
            /// 默认,手动设置URL参数的值
            /// </summary>
            Manual = 0,
            /// <summary>
            /// 自动从表单更新当前所有URL参数的值
            /// </summary>
            AutoUpdateFromFrom = 1,
            /// <summary>
            /// 自动从Query更新当前所有URL参数的值
            /// </summary>
            AutoUpdateFromQuery = 2

        }
        #endregion

        #region 属性
        List<string[]> _urlManualSettingKeyValue = null;//url参数集合
        
        private int _pageSize = 20;
        [Category("PagingParams")]
        [DefaultValue(20)]
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }

        private int _pageIndex = 1;
        [Category("PagingParams")]
        [DefaultValue(20)]
        public int PageIndex
        {
            get { return _pageIndex; }
            set
            {
                //int totalPages = (int)Math.Ceiling(((float)this.TotalRecords / (float)this.PageSize));
                //if (value > totalPages || value <= 0)
                //{
                //    _pageIndex = 1;
                //}
                //else
                //{
                //    _pageIndex = value;
                //}
                _pageIndex = value;
            }
        }

        private int _totalRecords = 0;
        [Category("PagingParams")]
        [DefaultValue(0)]
        [Description("要分页的总记录数")]
        public int TotalRecords
        {
            get { return _totalRecords; }
            set { _totalRecords = value; }
        }

        private string _showTextOnError = "当前没有数据";
        [Category("PagingParams")]
        [DefaultValue("当前没有数据")]
        [Description("设置或获取当发生错误 或 没有数据时显示的文本")]
        public string ShowTextOnError
        {
            get { return _showTextOnError; }
            set { _showTextOnError = value; }
        }

        private int _numOfShowPage = 10;
        [Category("PagingParams")]
        [DefaultValue(10)]
        [Description("显示页码的数量")]
        public int NumOfShowPage
        {
            get { return _numOfShowPage; }
            set { _numOfShowPage = value; }
        }

        private string _pagerFormatString = @"<div class=""pager""><span style=""margin-right:10px;"">总记录数:{totalrecords}</span><span style=""color:#f00;"">{pageindex}</span>/{totalpages}<a href='{first}' class='first-page'>首页</a><a href='{previous}' class='prev-page'>上一页</a>{linklist}<a href='{next}' class='next-page'>下一页</a><a href='{last}' class='last-page'>末页</a>{selector}{other}</div>";

        /// <summary>
        /// 分页器格式化字符串
        /// </summary>
        [Category("PagingFormatString")]
        [DefaultValue(@"<div class=""pager""><span style=""margin-right:10px;"">总记录数:{totalrecords}</span><span style=""color:#f00;"">{pageindex}</span>/{totalpages}<a href='{first}' class='first-page'>首页</a><a href='{previous}' class='prev-page'>上一页</a>{linklist}<a href='{next}' class='next-page'>下一页</a><a href='{last}' class='last-page'>末页</a>{selector}{other}</div>")]
        [Description(@"设置分页输出表格式化字符串
            {totalpages} -- 总页数
            {totalrecords} -- 总页数
            {pageindex} -- 当前页码
            {pagesize} -- 当前分页大小
            {fullurl} -- 完整带额外参数的链接URL
            {exturl} -- 额外附加参数的链接URL,带&符号
            {first} -- 第一页链接url
            {previous} -- 上一页链接url
            {linklist} -- 分页列表区域 
            {next} -- 下一页链接url
            {last} -- 最后一页链接url
            {selector} -- 页码选择控件,通过设置SelectorFormatString属性来设置输出格式
            {other} -- 自定义输出,通过设置OrderFormatString属性来设置输出格式")]
        public string PagerFormatString
        {
            get { return _pagerFormatString; }
            set { _pagerFormatString = value; }
        }

        private string _urlFormatString = "?page={pagenum}&pagesize={pagesize}";
        /// <summary>
        /// 链接URL格式化字符串,一般情况不会设置该属性,而用AppendUrlFormat方法
        /// </summary>
        /// <![CDATA[
        /// ?page={pagenum}&pagesize={pagesize}
        /// ]]>
        [Category("PagingFormatString")]
        [DefaultValue("?page={pagenum}&pagesize={pagesize}")]
        [Description(@"设置链接URL格式化字符串
            {pagesize} -- 当前每页大小
            {pagenum} -- 循环输出的页码,页码从1开始
            {totalrecords} -- 总记录数
            {totalpages} -- 总记页数
            ")]
        public string UrlFormatString
        {
            get { return _urlFormatString; }
            set { _urlFormatString = value; }
        }

        private string _otherFormatString = @"页码:<input type=""text"" id=""txtJumper"" style=""width:30px;"" value=""{pageindex}"" /> <input type=""button"" value=""转跳"" onclick=""location.href='?pagesize={pagesize}&page=' + document.getElementById('txtJumper').value + '{exturl}'"" />每页大小:<input type=""text"" id=""txtPagesize"" style=""width:30px;"" value=""{pagesize}"" /> <input type=""button"" value=""设置"" onclick=""location.href='?page=1&pagesize=' + document.getElementById('txtPagesize').value + '{exturl}'"" />";

        /// <summary>
        /// 设置附加HTML格式化字符串
        /// </summary>
        [Category("PagingFormatString")]
        [DefaultValue(@"页码:<input type=""text"" id=""txtJumper"" style=""width:30px;"" /> <input type=""button"" value=""转跳"" onclick=""location.href='?pagesize={pagesize}&page=' + document.getElementById('txtJumper').value"" />每页大小:<input type=""text"" id=""txtPagesize"" style=""width:30px;"" value=""{pagesize}"" /> <input type=""button"" value=""设置"" onclick=""location.href='?page=1&pagesize=' + document.getElementById('txtPagesize').value"" />")]
        [Description(@"自定义输出
            {fullurl} -- 完整带额外参数的链接URL
            {exturl} -- 额外参数的链接URL,带&符号
            {pagesize} -- 当前每页大小
            {pagenum} -- 循环输出的页码,页码从1开始
            {totalrecords} -- 总记录数
            {totalpages} -- 总记页数
            ")]
        public string OtherFormatString
        {
            get { return _otherFormatString; }
            set { _otherFormatString = value; }
        }

        private string _curPageCSS = "curPage";

        /// <summary>
        /// 设置或获取当前页码的CSS样式名称
        /// </summary>
        [Category("PagingFormatString")]
        [DefaultValue("curPage")]
        [Description(@"设置或获取当前页码的")]
        public string CurPageCSS
        {
            get { return _curPageCSS; }
            set { _curPageCSS = value; }
        }
        #endregion

        #region 方法
        protected override void RenderContents(HtmlTextWriter output)
        {
            if (/*PageIndex<1 || PageSize <1 ||*/ TotalRecords < 1)
            {
                output.Write(this.ShowTextOnError);
                return;
            }

            if (PageSize < 1)
            {
                PageSize = 20;
            }

            //计算总页数
            int totalPages = (int)Math.Ceiling(((float)this.TotalRecords / (float)this.PageSize));

            if (PageIndex < 1)
            {
                PageIndex = 1;
            }

            string resolveUrlformat = ResolveUrlFormat();
            string resolveExtUrlformat = ResolveExtUrlFormat();


            //构造选择控件html
            StringBuilder builderSelector = new StringBuilder();

            for (int i = 0; i < totalPages; i++)
            {
                string pagenum = (i + 1).ToString();
                if ((i + 1) == this.PageIndex)
                {
                    builderSelector.AppendFormat("<option value=\"{0}\" selected>{1}</option>\r\n",
                    resolveUrlformat.Replace("{pagenum}", pagenum),
                    pagenum
                    );
                }
                else
                {
                    builderSelector.AppendFormat("<option value=\"{0}\">{1}</option>\r\n",
                    resolveUrlformat.Replace("{pagenum}", pagenum),
                    pagenum
                    );

                }
            }

            //构造链接列表
            StringBuilder builderLinkList = new StringBuilder();

            if (totalPages > 2 && this.NumOfShowPage >= 2)
            {
                int numOfLeftLinks = (int)(this.NumOfShowPage / 2);//当前页面左边显示页码链接数量
                int numOfRightLinks = this.NumOfShowPage - numOfLeftLinks;//当前页面右边显示页码链接数量
                int startNum = this.PageIndex - numOfLeftLinks;
                if (startNum <= 0) startNum = 1;
                int endNum = this.PageIndex + numOfRightLinks;
                if (endNum > totalPages) endNum = totalPages;

                for (int i = startNum; i <= endNum; i++)
                {
                    if (i == this.PageIndex)
                    {
                        builderLinkList.AppendFormat("<a href=\"{0}\" class=\"{1}\">{2}</a>",
                           resolveUrlformat.Replace("{pagenum}", i.ToString()), this.CurPageCSS, i
                           );

                    }
                    else
                    {
                        builderLinkList.AppendFormat("<a href=\"{0}\" class=\"page-item\">{1}</a>",
                          resolveUrlformat.Replace("{pagenum}", i.ToString()),
                          i
                          );
                    }
                }
            }
            else//少于两页
            {
                for (int i = 0; i < totalPages; i++)
                {
                    string pagenum = (i + 1).ToString();
                    if ((i + 1) == this.PageIndex)
                    {
                        builderLinkList.AppendFormat("<a href=\"{0}\" class=\"{1}\">{2}</a>",
                          resolveUrlformat.Replace("{pagenum}", pagenum), this.CurPageCSS, pagenum
                          );
                    }
                    else
                    {
                        builderLinkList.AppendFormat("<a href=\"{0}\" class=\"page-item\">{1}</a>",
                          resolveUrlformat.Replace("{pagenum}", pagenum),
                          pagenum
                          );
                    }
                }
            }

            builderSelector.Insert(0, "<select onchange=\"location.href=this.options[this.selectedIndex].value\"; >\r\n");
            builderSelector.Insert(builderSelector.Length, "</select>");

            string htmlSelector = BasicFormat(builderSelector.ToString(), totalPages, resolveUrlformat, resolveExtUrlformat);

            string htmlLinkList = BasicFormat(builderLinkList.ToString(), totalPages, resolveUrlformat, resolveExtUrlformat);

            string htmlOther = BasicFormat(this.OtherFormatString, totalPages, resolveUrlformat, resolveExtUrlformat);

            int previous = this.PageIndex >= 2 ? this.PageIndex - 1 : this.PageIndex;
            int next = this.PageIndex < totalPages ? this.PageIndex + 1 : this.PageIndex;

            string pager = BasicFormat(
                this.PagerFormatString
                .Replace("{first}", resolveUrlformat.Replace("{pagenum}", "1"))
                .Replace("{previous}", resolveUrlformat.Replace("{pagenum}", previous.ToString()))
                .Replace("{linklist}", htmlLinkList)
                .Replace("{next}", resolveUrlformat.Replace("{pagenum}", next.ToString()))
                .Replace("{last}", resolveUrlformat.Replace("{pagenum}", totalPages.ToString()))
                .Replace("{selector}", htmlSelector)
                .Replace("{other}", htmlOther)
                ,
                totalPages
                ,
                resolveUrlformat
                ,
                resolveExtUrlformat
                );


            output.Write(pager);
        }

        /// <summary>
        /// 解析完整Url格式化字符串
        /// </summary>
        /// <returns>返回一个链接所需要完整的URL</returns>
        public string ResolveUrlFormat()
        {
            StringBuilder builder = new StringBuilder();
            if (this._urlManualSettingKeyValue != null)
            {
                foreach (string[] keyValue in this._urlManualSettingKeyValue)
                {
                    builder.AppendFormat("&{0}={1}", keyValue[0], HttpUtility.UrlEncode(keyValue[1]));
                }
            }

            string ret = UrlFormatString; //UrlFormatString.StartsWith("?") ? UrlFormatString : "?" + UrlFormatString;
            if (ret.EndsWith("&"))
            {
                ret = ret.Substring(0, ret.Length - 1);
            }

            return (builder.Length == 0) ? ret : ret + builder.ToString();
        }

        /// <summary>
        /// 解析额外Url格式化字符串
        /// </summary>
        /// <returns>返回一个额外提供参数的URL,该URL首字符为&</returns>
        public string ResolveExtUrlFormat()
        {
            if (this._urlManualSettingKeyValue == null) return string.Empty;

            StringBuilder builder = new StringBuilder();
            foreach (string[] keyValue in this._urlManualSettingKeyValue)
            {
                builder.AppendFormat("&{0}={1}", keyValue[0], HttpUtility.UrlEncode(keyValue[1]));
            }

            return (builder.Length == 0) ? string.Empty : builder.ToString();
        }

        ///// <summary>
        ///// 添加自动更新URL的参数,该函数只在设置UrlSettingMode 为AutoUpdateFromFrom , AutoUpdateFromQuery 有作用
        ///// </summary>
        ///// <param name="key"></param>
        //public void AppendUrlParam(string key)
        //{
        //    if (string.IsNullOrEmpty(key)) return;
        //    key = key.Trim();
        //    this._urlAutoUpdateKeys.Add(key);
        //}


        //添加手动设置的URL参数,该函数只在设置UrlSettingMode 为Manual 有作用
        /// <summary>
        /// 添加URL参数
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void AppendUrlParam(string key, string value)
        {
            if (_urlManualSettingKeyValue == null) _urlManualSettingKeyValue = new List<string[]>();
            _urlManualSettingKeyValue.Add(new string[] { key, value });
        }

        private string BasicFormat(string s, int totalpages, string fullUrl, string extendUrl)
        {
            return s.Replace("{pagesize}", this.PageSize.ToString())
                .Replace("{pageindex}", this.PageIndex.ToString())
                .Replace("{totalpages}", totalpages.ToString())
                .Replace("{totalrecords}", this.TotalRecords.ToString())
                .Replace("{fullurl}", fullUrl)
                .Replace("{exturl}", extendUrl);
        }
        #endregion
    }

    [DefaultProperty("Text")]
    [ToolboxData("<{0}:Pager3 runat=server></{0}:Pager>")]
    public class Pager3 : WebControl
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public int PageTotal
        {
            get
            {
                return TotalRecords % PageSize == 0 ? TotalRecords / PageSize : TotalRecords / PageSize + 1;
            }
        }
        public string PageIndexName { get; set; }
        public string CurrentUrl
        {
            get
            {
                return HttpContext.Current.Request.FilePath;
            }
        }
        public string PageLink { get; set; }
        public Dictionary<string, object> Parameters { get; set; }

        public string classCurrentPage { get; set; }
        public string classPage { get; set; }
        public string classNextPage { get; set; }
        public string classPrevPage { get; set; }

        public int PrevPage
        {
            get
            {
                return PageIndex - 1 == 0 ? 1 : PageIndex - 1;
            }
        }
        public int NextPage
        {
            get
            {
                return PageIndex < PageTotal ? PageIndex + 1 : PageTotal;
            }
        }
        
        public Pager3()
        {
            PageIndex = 1;
            PageSize = 20;
            PageIndexName = "p";
            Parameters = new Dictionary<string, object>();

            //当前页数小于1时
            PageIndex = PageIndex <= 0 ? 1 : PageIndex;

            //当前页数超过总页数时
            if (PageIndex > PageTotal)
            {
                PageIndex = PageTotal;
            }

            PageLink = "<a class=\"{class}\" href=\"{url}\" title=\"{title}\">{content}</a>";
            classCurrentPage = "current";
            classNextPage = "next";
            classPrevPage = "pre";
            classPage = "db l";
        }

        public void AppendUrlParam(string key, string value)
        {
            Parameters.Add(key, value);
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            StringBuilder sbPager = new StringBuilder();

            sbPager.AppendFormat("<div id=\"turnPages\" class=\"zoom\">");

            if (TotalRecords > 0)
            {
                sbPager.AppendFormat("<span class=\"{2}\" title=\"当前第{0}页,共{1}页\">当前第{0}页,共{1}页</span>", PageIndex, PageTotal, classPage);

                sbPager.Append(FormatLink(PageLink, MegerFullUrlQuery(CurrentUrl, PrevPage, PageIndexName, Parameters), "上一页", "上一页", classPrevPage + " " + classPage));

                #region 预先输出最多3页
                for (int i = 1; i <= (PageTotal < 3 ? PageTotal : 3); i++)
                {
                    sbPager.Append(FormatLink(PageLink, MegerFullUrlQuery(CurrentUrl, i, PageIndexName, Parameters), i.ToString(), i.ToString(), GetClass(i)));
                }
                #endregion

                #region 总页数少于10条
                if (PageTotal < 10)
                {
                    for (int i = 4; i <= PageTotal; i++)
                    {
                        sbPager.Append(FormatLink(PageLink, MegerFullUrlQuery(CurrentUrl, i, PageIndexName, Parameters), i.ToString(), i.ToString(), GetClass(i)));
                    }
                }
                #endregion

                #region 总页数大于10条
                else
                {

                    #region 当前页小于5
                    if (PageIndex <= 5)
                    {
                        sbPager.Append(FormatLink(PageLink, MegerFullUrlQuery(CurrentUrl, 4, PageIndexName, Parameters), "4", "4", GetClass(4)));
                        sbPager.Append(FormatLink(PageLink, MegerFullUrlQuery(CurrentUrl, 5, PageIndexName, Parameters), "5", "5", GetClass(5)));
                    }
                    #endregion

                    sbPager.AppendFormat("<span class=\"{0}\">...</span>", classPage);

                    #region 当前页>5且<=(总页数-3)时
                    if (PageIndex > 5 && PageIndex <= PageTotal - 3)
                    {
                        for (int i = PageIndex - 1; i <= PageIndex + 1; i++)
                        {
                            sbPager.Append(FormatLink(PageLink, MegerFullUrlQuery(CurrentUrl, i, PageIndexName, Parameters), i.ToString(), i.ToString(), GetClass(i)));
                        }
                        sbPager.AppendFormat("<a href=\"#\">...</a>");
                    }
                    #endregion

                    #region 当前页>(总页数-3)时
                    if (PageIndex > PageTotal - 3)
                    {
                        for (int i = PageTotal - 2; i < PageTotal; i++)
                        {
                            sbPager.Append(FormatLink(PageLink, MegerFullUrlQuery(CurrentUrl, i, PageIndexName, Parameters), i.ToString(), i.ToString(), GetClass(i)));
                        }
                    }
                    #endregion

                    sbPager.Append(FormatLink(PageLink, MegerFullUrlQuery(CurrentUrl, PageTotal, PageIndexName, Parameters), PageTotal.ToString(), PageTotal.ToString(), GetClass(PageTotal)));
                }
                #endregion

                sbPager.Append(FormatLink(PageLink, MegerFullUrlQuery(CurrentUrl, NextPage, PageIndexName, Parameters), "下一页", "下一页", classNextPage + " " + classPage));
            }
            else
            {
                //sbPager.AppendFormat("<span class=\"{0} no-record\" title=\"无数据\">无数据</span>", classPage);
            }

            sbPager.AppendFormat("</div>");

            writer.Write(sbPager.ToString());
        }

        /// <summary>
        /// 合并所有参数
        /// </summary>
        /// <param name="url"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageTotal"></param>
        /// <param name="pageIndexName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private string MegerFullUrlQuery(string url, int pageIndex, string pageIndexName, Dictionary<string, object> parameters)
        {
            if (string.IsNullOrWhiteSpace(pageIndexName) || pageIndexName == "p")
                url += string.Format("?page={0}&", pageIndex);
            else
                url += string.Format("?p={0}&page={1}&", pageIndexName, pageIndex);

            url += MegerParameter(parameters);

            return url;
        }

        /// <summary>
        /// 合并额外参数
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private string MegerParameter(Dictionary<string, object> parameters)
        {
            var paramstr = string.Empty;
            foreach (KeyValuePair<string, object> item in Parameters)
            {
                paramstr += string.Format("&{0}={1}", item.Key, item.Value);
            }
            if (paramstr.StartsWith("&")) paramstr = paramstr.Substring(1);

            return paramstr;
        }

        /// <summary>
        /// 格式化A标签
        /// </summary>
        /// <param name="patent"></param>
        /// <param name="url"></param>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <param name="classStyle"></param>
        /// <returns></returns>
        private string FormatLink(string patent,string url, string title, string content, string classStyle)
        {
            return patent.Replace("{url}", url)
                .Replace("{title}", title)
                .Replace("{content}", content)
                .Replace("{class}", classStyle);
        }

        private string GetClass(int currentIndex)
        {
            return classPage + (PageIndex == currentIndex ? " " + classCurrentPage : string.Empty);
        }
    }
}

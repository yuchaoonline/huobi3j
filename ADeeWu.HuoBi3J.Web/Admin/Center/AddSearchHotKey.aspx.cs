﻿using ADeeWu.HuoBi3J.Libary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web.Admin.Center
{
    public partial class AddSearchHotKey : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            var link = txtLink.Text;
            var name = txtName.Text;
            var type = txtDataType.Text;
            if (string.IsNullOrWhiteSpace(name))
            {
                WebUtility.ShowMsg("名称不能为空！");
                return;
            }
            if (string.IsNullOrWhiteSpace(type))
            {
                WebUtility.ShowMsg("类型不能为空！");
                return;
            }
            if (string.IsNullOrWhiteSpace(link))
            {
                WebUtility.ShowMsg("链接不能为空！");
                return;
            }
            if (new DAL.Key_HotKey().Add(new Model.Key_HotKey { Name = name, DataLink = link, DataType = type }) > 0)
            {
                WebUtility.ShowMsg(this, "操作成功！", "searchhotkey.aspx");
                return;
            }

            WebUtility.ShowMsg("操作失败！");
            return;
        }
    }
}
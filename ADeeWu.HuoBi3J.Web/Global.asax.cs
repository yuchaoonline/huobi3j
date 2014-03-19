using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net;
using System.Timers;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using ADeeWu.HuoBi3J.Web.Class;
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.Web
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            BaseDataHelper.RefreshData();
        }
    }
}
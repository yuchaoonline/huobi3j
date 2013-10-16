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

            var timeInterval = Utility.GetInt(System.Configuration.ConfigurationManager.AppSettings["TaskInterval"],1000 * 60 *60 * 24);
            System.Timers.Timer everyDayTimer = new Timer();
            everyDayTimer.Interval = timeInterval; //这个时间单位毫秒,比如10秒，就写10000 
            everyDayTimer.Enabled = true;
            everyDayTimer.Elapsed += everyDayTimer_Elapsed;
        }

        protected void Application_End(object sender, EventArgs e)
        {
            try
            {
                string url = Utility.GetStr(System.Configuration.ConfigurationManager.AppSettings["TaskUrl"], "http://www.ADeeWu.HuoBi3J.com/refresh.aspx");

                HttpWebRequest httpWebRequest = WebRequest.Create(url) as HttpWebRequest;
                HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
                Stream stream = httpWebResponse.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                string html = reader.ReadToEnd();
                reader.Close();
                stream.Close();
                httpWebResponse.Close();
            }
            catch
            {

            }
        }

        private void everyDayTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                string url = Utility.GetStr(System.Configuration.ConfigurationManager.AppSettings["TaskUrl"], "http://www.ADeeWu.HuoBi3J.com/refresh.aspx");

                HttpWebRequest httpWebRequest = WebRequest.Create(url) as HttpWebRequest;
                HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
                Stream stream = httpWebResponse.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                string html = reader.ReadToEnd();
                reader.Close();
                stream.Close();
                httpWebResponse.Close();
            }
            catch
            {

            }
        }        
    }
}
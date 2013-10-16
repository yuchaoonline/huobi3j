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
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using System.IO;

namespace ADeeWu.HuoBi3J.Web.My.Corp.CorpImage.Videos
{
    public partial class Del : Class.PageBase_MyCorp 
    {
        ADeeWu.HuoBi3J.DAL.CI_Videos dal = new ADeeWu.HuoBi3J.DAL.CI_Videos();

        DataBase db = DataBase.Create();

        /// <summary>
        /// 加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
            protected void Page_Load(object sender, EventArgs e)
            {
                string IDString = ADeeWu.HuoBi3J.Libary.Utility.GetStr(Request["id"]);

                if (IDString.IndexOf(",") > -1)
                {
                    foreach (string s in IDString.Split(','))
                    {
                        long id = ADeeWu.HuoBi3J.Libary.Utility.GetLong(s, 0);

                        if (id > 0)
                        {
                            //删除视频附件
                            string url = Utility.GetStr(
                                db.ExecuteScalar("select URL from CI_Videos where ID=" + id + " and CorpID="+ this.LoginUser.CorpID)
                                ).Trim();
                            if (url.Length > 0)
                            {
                                string filePath = Server.MapPath(url);

                                if (File.Exists(filePath))
                                {
                                    File.Delete(filePath);
                                }
                            }
                            //删除指定ID视频信息
                            dal.Delete("id=" + id + " and CorpID=" + this.LoginUser.CorpID);
                            
                        }
                    }
                }
                else
                {
                    long id = ADeeWu.HuoBi3J.Libary.Utility.GetLong(IDString, 0);
                    if (id > 0)
                    {
                        dal.Delete("id=" + id + " and CorpID=" + this.LoginUser.CorpID);
                    }
                }

                WebUtility.ShowMsg(this, "操作成功!", ".");

            }
        }
    
}

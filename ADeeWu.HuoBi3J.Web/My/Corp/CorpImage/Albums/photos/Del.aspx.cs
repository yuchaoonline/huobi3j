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

namespace ADeeWu.HuoBi3J.Web.My.Corp.CorpImage.Albums.Photos
{
       public partial class Del : Class.PageBase_MyCorp
        {

           DataBase db = DataBase.Create();
           ADeeWu.HuoBi3J.DAL.CI_Photos dal = new ADeeWu.HuoBi3J.DAL.CI_Photos();

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
                            //删除附件信息
                            string url = Utility.GetStr(
                                db.ExecuteScalar("select URL from CI_Photos where ID=" + id + " and CorpID=" + this.LoginUser.CorpID)
                                ).Trim();
                            if (url.Length > 0)
                            {
                                string filePath = Server.MapPath(url);

                                if (File.Exists(filePath))
                                {
                                    File.Delete(filePath);
                                }
                            }
                            //删除商家发布视频的图片信息
                            dal.Delete("id=" + id + " and CorpID=" + this.LoginUser.CorpID);
                        }
                    }
                }
                else
                {
                    long id = ADeeWu.HuoBi3J.Libary.Utility.GetLong(IDString, 0);
                    if (id > 0)
                    {
                        dal.Delete("id=" + id + " and CorpID=" + this.LoginUser.CorpUserID);
                    }
                }
                WebUtility.ShowMsg(this, "操作成功!", ".");

            }
        }
        
}

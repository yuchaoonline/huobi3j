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
using System.Collections.Generic;
using System.Text;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;

namespace ADeeWu.HuoBi3J.Web.Admin.CorpImage.Albums
{
    public partial class Edit : PageBase
    {
        DataBase db = DataBase.Create();

        ADeeWu.HuoBi3J.DAL.CI_Albums dal = new ADeeWu.HuoBi3J.DAL.CI_Albums();
        long id = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("id", 0);
        long corpID = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("corpid", 0);

        public override string PageID
        {
            get
            {
                return "020002";
            }
        }

       
        /// <summary>
        /// 加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
               

            //首次加载
            if (!IsPostBack)
            {


                DataTable dt = db.Select("select * from vw_CI_Albums_Admin where ID=" + id);
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    txtAlbumsName.Text = dr["Title"].ToString();
                    txtCorpName.Text = dr["CorpName"].ToString();
                    txtCreateTime.Text = dr["CreateTime"].ToString();
                    txtSequence.Text = dr["Sequence"].ToString();
                    IsHidden.Checked = bool.Parse(dr["IsHidden"].ToString());
                    IsRecommend.Checked = bool.Parse(dr["IsRecommend"].ToString());
                    
                }
            
                
            }
        }


        /// <summary>
        /// 保存相册信息事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SaveData();
        }


        /// <summary>
        /// 保存相册信息方法
        /// </summary>
        private void SaveData()
        {
            string name = txtAlbumsName.Text;
            string corpName = txtCorpName.Text;

            DateTime? createTime = Utility.GetDateTime(txtCreateTime.Text.Trim(), null);
            int sequence = Utility.GetInt(txtSequence.Text.Trim(), 0);

            if (string.IsNullOrEmpty(name))
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写相册信息标题!");
                return;
            }
            if (!createTime.HasValue)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写相册发布时间!");
                return;
            }
            ADeeWu.HuoBi3J.Model.CI_Albums albums = dal.GetEntity(ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("id", 0));
            albums.Title = name;           
            albums.CreateTime = createTime.Value;
            albums.Sequence = sequence;
            albums.IsHidden = IsHidden.Checked;
            albums.IsRecommend = IsRecommend.Checked;

            if (dal.Update(albums) > 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "更新相册成功!", "List.aspx");
                return;
            }
            else
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "更新相册失败!");
            }


        }
       
    }
}

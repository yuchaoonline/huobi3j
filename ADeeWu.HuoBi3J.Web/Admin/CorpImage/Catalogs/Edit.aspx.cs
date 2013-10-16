using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using System.Data;

namespace ADeeWu.HuoBi3J.Web.Admin.CorpImage.Catalogs
{
	public partial class Edit : PageBase
	{
        ADeeWu.HuoBi3J.DAL.CI_Catalogs dal = new ADeeWu.HuoBi3J.DAL.CI_Catalogs();
        long id = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("id", 0);
        long corpID = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("corpid", 0);

        DataBase db = DataBase.Create();

        public override string PageID
        {
            get
            {
                return "022002";
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
                DataTable dt = db.Select("select * from vw_CI_Catalogs_Admin where ID=" + id);
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
        /// 保存画册信息事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SaveData();
        }


        /// <summary>
        /// 保存画册信息方法
        /// </summary>
        private void SaveData()
        {
            string name = txtAlbumsName.Text;
            string corpName = txtCorpName.Text;

            DateTime? createTime = Utility.GetDateTime(txtCreateTime.Text.Trim(), null);
            int sequence = Utility.GetInt(txtSequence.Text.Trim(), 0);

            if (string.IsNullOrEmpty(name))
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写画册信息标题!");
                return;
            }
            if (!createTime.HasValue)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写画册发布时间!");
                return;
            }
            ADeeWu.HuoBi3J.Model.CI_Catalogs catalog = dal.GetEntity(ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("id", 0));

            catalog.Title = name;            
            catalog.CreateTime = createTime.Value;
            catalog.Sequence = sequence;
            catalog.IsHidden = IsHidden.Checked;
            catalog.IsRecommend = IsRecommend.Checked;

            if (dal.Update(catalog) > 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "更新画册成功!", "List.aspx");
                return;
            }
            else
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "更新画册失败!");
            }


        }
	}
}

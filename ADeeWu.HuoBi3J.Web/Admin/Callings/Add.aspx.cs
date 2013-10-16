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
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.Web.Admin.Callings
{
    public partial class Add : PageBase
    {

        public override string PageID
        {
            get
            {
                return "026001";
            }
        }

        DataBase db = DataBase.Create();
        ADeeWu.HuoBi3J.DAL.Callings dalCategories = new ADeeWu.HuoBi3J.DAL.Callings();

        protected long corpID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                this.txtSequence.Text = Utility.GetStr(db.ExecuteScalar("select count(id)+1 from Callings"));
            }
            
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {

            string name = this.txtName.Text.Trim();
            int sequence = ADeeWu.HuoBi3J.Libary.Utility.GetInt(this.txtSequence.Text, 0);
            int itemCount = ADeeWu.HuoBi3J.Libary.Utility.GetInt(this.txtItemCount.Text, 0);
            long parentID = ADeeWu.HuoBi3J.Libary.Utility.GetLong(this.syncSelectorCalling.SelectedValue, 0, long.MaxValue);

            if (name=="")
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "分类名称不能为空!");
                return;
            }



            ADeeWu.HuoBi3J.Model.Callings entity = new ADeeWu.HuoBi3J.Model.Callings();
            entity.Name = name;
            entity.IsHidden = false;
            entity.IsRecommend = this.chhRecommend.Checked;
            entity.ItemCount = itemCount;
            entity.Sequence = sequence;
            entity.CreateTime = DateTime.Now;
            entity.ModifyTime = DateTime.Now;
            //entity.RefreshTime = DateTime.Now;

            if (parentID > 0) //选择上级分类
            {
                entity.ParentID = parentID;
                ADeeWu.HuoBi3J.Model.Callings entParent = dalCategories.GetEntity(parentID);

                if (entParent != null)
                {
                    entity.ParentPath = entParent.ParentPath;
                    if (!entity.ParentPath.EndsWith(","))
                    {
                        entity.ParentPath += ",";
                    }
                    entity.ParentPath += entParent.ID;
                    entity.Depth = entParent.Depth + 1;
                }
            }
            else
            {
                entity.ParentID = 0;
                entity.ParentPath = "0";
                entity.Depth = 0;
            }

            if (!entity.ParentPath.EndsWith(","))
            {
                entity.ParentPath += ",";
            }


            long newid = dalCategories.Add(entity);
            if (newid > 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowPageSelector(this, "操作成功!是否立即生成缓冲数据?","GenerateJSData.aspx", "Edit.aspx?id=" + newid);
            }
        }

    }
}

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
using System.Text;

namespace ADeeWu.HuoBi3J.Web.My.Corp.Orders.AfterSaleRecords
{
    public partial class New : ADeeWu.HuoBi3J.Web.Class.PageBase_MyCorp_Shop
    {
        
        DataBase db = DataBase.Create();
        long orderDetailId = 0;
        

        /// <summary>
        /// 加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            orderDetailId = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("orderDetailID", 0);

            if (!IsPostBack)
            {

                DataTable dt = db.Select("select * from vw_Shop_OrderDetails where  ID={0} and SellerCorpID={1}", orderDetailId, this.LoginUser.CorpID);

                if (dt.Rows.Count == 0)
                {
                    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "该记录已不存在");
                    return;
                }

                DataRow dr = dt.Rows[0];

                this.lblOrderCode.Text = Utility.GetStr(dr["OrderCode"]);

                this.lblProductName.Text = Utility.GetStr(dr["ProductName"]);

                this.txtCreateTime.Text = Utility.GetStr(DateTime.Now.Date.ToShortDateString());
            }
        }
       

        /// <summary>
        /// 保存售后服务事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SaveData();
        }


        /// <summary>
        /// 保存售后服务方法
        /// </summary>
        private void SaveData()
        {
            
           
            ADeeWu.HuoBi3J.DAL.Shop_AfterSaleRecords dal = new ADeeWu.HuoBi3J.DAL.Shop_AfterSaleRecords();
            ADeeWu.HuoBi3J.Model.Shop_AfterSaleRecords entity = new ADeeWu.HuoBi3J.Model.Shop_AfterSaleRecords();

            DateTime? createTime;
            createTime = Utility.GetDateTime(this.txtCreateTime.Text, null);
            if (!createTime.HasValue)
            {
                WebUtility.ShowMsg(this, "请填写正确的处理时间！");
                return;
            }


            entity.ServerCorpID = this.LoginUser.CorpID;
            
            Class.CorpAgentSession corpAgent = this.LoginUser as Class.CorpAgentSession;
            entity.ServerCorpAgentID = corpAgent == null ? 0 : corpAgent.UserID;
            entity.OrderDetailID = orderDetailId;
            entity.Note = ADeeWu.HuoBi3J.Libary.WebUtility.GetTextAreaContent(this.txtNote.Text);
            entity.Result = getCheckResult();
            entity.CreateTime = createTime.Value;
            entity.ModifyTime = DateTime.Now;
              
            
           
          
            if (dal.Add(entity) > 0) 
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "操作成功！", "Default.aspx?orderDetailID=" + entity.OrderDetailID);
                return;
            }
            else
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "操作失败！请与我们联系！");
            }  


        }
        /// <summary>
        /// 获取处理结果
        /// </summary>
        /// <returns></returns>
        int getCheckResult()
        {
            if (this.cboExit.Checked)
            {
                return 1; //退货
            }
            else if (this.cboSwap .Checked)
            {
                return 2;//换货
            }
            else if (this.cboRepail.Checked)
            {
                return 3;//维修
            }
            else
            {
                return -1;
            }
        }
        /// <summary>
        /// 设置处理结果
        /// </summary>
        /// <param name="state"></param>
        void setCheckResult(int result)
        {
            if (result == 1)
            {
                this.cboExit.Checked = true;
            }
            else if (result == 2)
            {
                this.cboSwap.Checked = true;
            }
            else if (result == 3)
            {
                this.cboRepail.Checked = true;
            }
            
        }
       
    }
}

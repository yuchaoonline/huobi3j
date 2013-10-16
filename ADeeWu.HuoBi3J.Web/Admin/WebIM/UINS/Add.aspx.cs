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
using System.Text;
using System.Collections.Generic;

namespace ADeeWu.HuoBi3J.Web.Admin.WebIM.UINS
{
    public partial class Add : PageBase
    {
        public override string PageID
        {
            get
            {
                return "018001";
            }
        }

        DAL.IM_UINS dal = new ADeeWu.HuoBi3J.DAL.IM_UINS();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
               DataTable dt=  dal.Select(1, 0);
                if(dt!=null&&dt.Rows.Count>0)
                {
                    string uin=  dt.Rows[0]["UIN"].ToString();
                    txtStartNum.Text = (int.Parse(uin) + 1).ToString();
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int numLength = ADeeWu.HuoBi3J.Libary.Utility.GetInt(this.txtNumLength.Text, 0);
            int startNum = ADeeWu.HuoBi3J.Libary.Utility.GetInt(this.txtStartNum.Text, 0);


            if (numLength < 1)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("通讯号码长度输入不正确!");
                return;
            }

            if (startNum < 1)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("通讯号码起始数输入不正确!");
                return;
            }


            List<ADeeWu.HuoBi3J.Model.IM_UINS> dataSource = new List<ADeeWu.HuoBi3J.Model.IM_UINS>();

            for (int i = 0; i < numLength; i++)
            {
                ADeeWu.HuoBi3J.Model.IM_UINS model = new ADeeWu.HuoBi3J.Model.IM_UINS();
                model.CreateTime = DateTime.Now;
                model.HasUsed = false;
                model.IsRecommend = false;
                model.Sequence = 0;
                model.UIN = GetSerialNum(ref startNum).ToString();
                dal.Add(model);
                dataSource.Add(model);
            }

            ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("生成成功,请查看结果!");
            this.gvData.DataSource = (IList<ADeeWu.HuoBi3J.Model.IM_UINS>)dataSource;
            this.gvData.DataBind();
        }
        private int GetSerialNum(ref int num)
        {
            bool isExist = dal.Exist("UIN", num);
            while (isExist)
            {
                num =num+1;
                isExist = dal.Exist("UIN", num);
            }
            return num;
        }

    }
}

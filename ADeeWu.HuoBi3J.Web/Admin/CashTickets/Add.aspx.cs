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

namespace ADeeWu.HuoBi3J.Web.Admin.CashTickets
{
    public partial class Add : PageBase
    {

        public override string PageID
        {
            get
            {
                return "003001";
            }
        }

        DataBase db = DataBase.Create();
        DAL.CT_CashTickets dalCashTicket = new ADeeWu.HuoBi3J.DAL.CT_CashTickets();
       
        ADeeWu.HuoBi3J.Libary.PasswordGenerator passwordGenerator = new ADeeWu.HuoBi3J.Libary.PasswordGenerator();

        

        protected void Page_Load(object sender, EventArgs e)
        {
            passwordGenerator.Minimum = 6;
            passwordGenerator.Maximum = 6;
            passwordGenerator.Exclusions = "`~!@#$^*()-_=+[]{}\\;:'\",./";

            if (!IsPostBack)
            {
                //this.ddlCorp.DataSource = db.Select("vw_CT_PartnerCorps", "CheckState=1", "CreateTime desc");
                //this.ddlCorp.DataTextField = "CorpName";
                //this.ddlCorp.DataValueField = "CorpID";
                //this.ddlCorp.DataBind();
            }

          
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            //long corpID = ADeeWu.HuoBi3J.Libary.Utility.GetLong(this.ddlCorp.SelectedValue, -1);
            int quantity = ADeeWu.HuoBi3J.Libary.Utility.GetInt(this.txtQuantity.Text, 0);
            //int checkState = ADeeWu.HuoBi3J.Libary.Utility.GetInt(this.ddlCheckState.Text,0);
            int checkState = 0;
            string prefix = this.txtPrefix.Text.Trim();
            int numLength = ADeeWu.HuoBi3J.Libary.Utility.GetInt(this.txtNumLength.Text, 0);
            int startNum = ADeeWu.HuoBi3J.Libary.Utility.GetInt(this.txtStartNum.Text, 0);
            float money = ADeeWu.HuoBi3J.Libary.Utility.GetFloat(txtMoney.Text,0);

            //if (corpID <= 0)
            //{
            //    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请选择商家!");
            //    return;
            //}

            //if (corpID <= 0)
            //{
            //    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写生成数量!");
            //    return;
            //}

            if (prefix == "")
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写生成现金券的前缀!");
                return;
            }

            if (numLength < 1)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("流水号号码长度输入不正确!");
                return;
            }

            if (startNum < 1)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("流水号号码起始数输入不正确!");
                return;
            }

            if (startNum.ToString().Length > numLength)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("流水号号码起始数不能大于流水号号码长度!");
                return;
            }

            if (money <= 0)
            {
                WebUtility.ShowMsg("金额应为大于0！");
                return;
            }

            StringBuilder format = new StringBuilder();
            for (int i = 0; i < numLength; i++)
            {
                format.Append("0");
            }
            format.Insert(0, "{0:");
            format.Insert(format.Length, "}");

            List<ADeeWu.HuoBi3J.Model.CT_CashTickets> dataSource = new List<ADeeWu.HuoBi3J.Model.CT_CashTickets>();

            for (int i = 0; i < quantity; i++)
            {
                ADeeWu.HuoBi3J.Model.CT_CashTickets model = new ADeeWu.HuoBi3J.Model.CT_CashTickets();
                model.CheckState = (short)checkState;
                //model.CorpID = corpID;
                model.CreateTime = DateTime.Now;
                model.ModifyTime = DateTime.Now;
                model.SerialNum = GetSerialNum(prefix + format.ToString(), ref startNum);
                model.ValidCode = GetValidCode();
                model.Money = money;
                dalCashTicket.Add(model);
                dataSource.Add(model);
            }

            ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("生成成功,请查看结果!");
            this.gvData.DataSource = (IList<ADeeWu.HuoBi3J.Model.CT_CashTickets>)dataSource;
            this.gvData.DataBind();

        }

        private string GetSerialNum(string format,ref int num)
        {
            string serialNum = string.Format(format, num);
            bool isExist = dalCashTicket.Exist("SerialNum", serialNum);
            while (isExist)
            {
                serialNum = string.Format(format, ++num);
                isExist = dalCashTicket.Exist("SerialNum", serialNum);
            }
            return serialNum;
        }

        private string GetValidCode()
        {
            
            return passwordGenerator.Generate();

        }
    }
}

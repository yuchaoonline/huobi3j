using ADeeWu.HuoBi3J.Libary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web.Admin.Coupons
{
    public partial class AddList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            if (!Utility.IsFloat(txtMoney.Text))
            {
                WebUtility.ShowMsg("金额格式有问题！");
                return;
            }
            if (!Utility.IsInt(txtCount.Text))
            {
                WebUtility.ShowMsg("数量为整数！");
                return;
            }

            var count = Utility.GetInt(txtCount.Text, -1);
            var money = Utility.GetDecimal(txtMoney.Text, 0);
            var subjectid = WebUtility.GetRequestInt("subjectid", -1);
            var subject = new DAL.Coupons_Subject().GetEntity(subjectid);
            if (subject == null)
            {
                WebUtility.ShowMsg("参数有问题！");
                return;
            }
            if (subject.Inactive.HasValue && subject.Inactive.Value)
            {
                WebUtility.ShowMsg("活动已删除或已结束，无需再生成码！");
                return;
            }
            if (subject.EndDate.HasValue && subject.EndDate.Value < DateTime.Now)
            {
                WebUtility.ShowMsg("活动已结束，无需再生成码！");
                return;
            }

            var successCount = 0;
            var listDAL = new DAL.Coupons_List();
            for (int i = 0; i < count; i++)
            {
                var list = new Model.Coupons_List
                {
                    EndDate = subject.EndDate,
                    IsMoney = subject.IsMoney,
                    IsUse = false,
                    Money = money,
                    StartDate = subject.StartDate,
                    SubjectID = subject.ID,
                    Password = GeneralCode(),
                    Memo="",
                };
                try
                {
                    listDAL.Add(list);
                    successCount++;
                }
                catch
                {

                }
            }

            WebUtility.ShowMsg(this, string.Format("成功生成{0}张券", successCount), "lists.aspx?subjectid=" + subject.ID);
        }

        private string GeneralCode()
        {
            return Guid.NewGuid().ToString();
            //throw new Exception("生成码未完成！");
            //return "123456";
        }
    }
}
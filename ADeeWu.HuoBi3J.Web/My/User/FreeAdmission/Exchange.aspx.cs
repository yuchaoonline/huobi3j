using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web.My.User.FreeAdmission
{
    public partial class Exchange : ADeeWu.HuoBi3J.Web.Class.PageBase_MyUser
    {
        DAL.FreeAdmission freeAdmissionDAL = new DAL.FreeAdmission();
        DAL.FreeAdmission_Log freeAdmissionLogDAL = new DAL.FreeAdmission_Log();
        DataBase db = DataBase.Create();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var seqNo = txtSeqNO.Text;
            var seqPwd = txtSeqPwd.Text;
            var loginuserid = Utility.GetInt(LoginUser.UserID, 0);

            if (string.IsNullOrWhiteSpace(seqNo))
            {
                WebUtility.ShowMsg("序列号不能为空！");
                return;
            }
            if (string.IsNullOrWhiteSpace(seqPwd))
            {
                WebUtility.ShowMsg("密码不能为空！");
                return;
            }

            var freeAdmission = freeAdmissionDAL.GetEntity(new string[] { "SeqNo", "SeqPwd" }, new string[] { seqNo, seqPwd });
            if (freeAdmission == null)
            {
                WebUtility.ShowMsg("赠送券无效！");
                return;
            }
            if (freeAdmission.StartDate > DateTime.Now || freeAdmission.EndDate < DateTime.Now)
            {
                WebUtility.ShowMsg("赠送券已过期！");
                return;
            }

            var freeAdmissionLogs = freeAdmissionLogDAL.GetEntityList("", new string[] { "FreeAdmissionID" }, new string[] { freeAdmission.ID.ToString() });
            if (freeAdmissionLogs != null)
            {
                if (freeAdmissionLogs.Count() >= freeAdmission.TotalCount)
                {
                    WebUtility.ShowMsg("你来晚了，今天的现金赠送申请名额已满，下次请早！");
                    return;
                }

                if (freeAdmissionLogs.Count(p => p.UserID == loginuserid) >= freeAdmission.ApplyCount)
                {
                    WebUtility.ShowMsg(string.Format("你太贪心了！只能领取{0}次！", freeAdmission.ApplyCount));
                    return;
                }
            }

            var freeAdmissionLog = new Model.FreeAdmission_Log
            {
                CreateTime = DateTime.Now,
                FreeAdmissionID = freeAdmission.ID,
                UserID = Utility.GetInt(this.LoginUser.UserID, 0),
            };
            if (freeAdmissionLogDAL.Add(freeAdmissionLog) > 0)
            {
                db.Parameters.Append("@UserID", loginuserid);
                db.Parameters.Append("@Money", ADeeWu.HuoBi3J.Libary.Utility.GetDecimal(freeAdmission.Money, 0));
                db.Parameters.Append("@IsPayment", false);
                db.Parameters.Append("@Notes", "申请现金赠送通过审核返还金额");
                db.Parameters.Append("@ErrorMessage", "", ParameterDirection.Output, DbType.String).Size = 1000;

                db.AutoClearParameters = false;

                if (ADeeWu.HuoBi3J.Libary.Utility.GetInt(db.RunProc("SP_User_DoDeal"), -1) != 0)
                {
                    WebUtility.ShowMsg("自动充值失败,请到用户帐户管理进行相应的操作!\\r\\n" + db.Parameters["@ErrorMessage"].Value.ToString());
                    return;
                }

                WebUtility.ShowMsg(this, "兑换成功！", Request.RawUrl);
                return;
            }
        }
    }
}
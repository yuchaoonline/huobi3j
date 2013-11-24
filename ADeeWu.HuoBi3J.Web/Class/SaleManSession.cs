using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.Web.Class
{
    /// <summary>
    /// 商家代表用户登陆保持的会话状态
    /// </summary>
    public class SaleManSession
    {
        public static Model.CA_CircleSaleMan SaleMan
        {
            get
            {
                if (HttpContext.Current.Session["SaleMan"] == null)
                    return null;

                return HttpContext.Current.Session["SaleMan"] as Model.CA_CircleSaleMan;
            }
        }

        public static bool IsSaleMan
        {
            get
            {
                return CheckState == UserSessionCheckState.Audited;
            }
        }

        public static UserSessionCheckState CheckState
        {
            get
            {
                if (SaleMan == null) return UserSessionCheckState.Unavailable;
                return (UserSessionCheckState)SaleMan.CheckState;
            }
        }

        public static void SaveCircleSaleMan(long UserID)
        {
            DataBase db = DataBase.Create();
            db.Parameters.Append("@UserID", UserID);
            var SaleMans = db.Select("vw_CircleSaleMan", "userid = @userid", "");
            if (SaleMans != null && SaleMans.Rows.Count > 0)
            {
                var saleMan = SaleMans.Rows[0];
                var circleMan = new Model.CA_CircleSaleMan
                {
                    ID = Utility.GetLong(saleMan["id"], -1),
                    UserID = Utility.GetLong(saleMan["userid"], -1),
                    CheckState = Utility.GetInt(saleMan["checkstate"], 3),
                    Phone = Utility.GetStr(saleMan["phone"], ""),
                    CreateTime = Utility.GetDateTime(saleMan["createtime"], DateTime.MinValue),
                    ModifyTime = Utility.GetDateTime(saleMan["modifytime"], DateTime.MinValue),
                    CompanyAddress = Utility.GetStr(saleMan["companyaddress"], ""),
                    CompanyName = Utility.GetStr(saleMan["companyname"], ""),
                    QQ = Utility.GetStr(saleMan["qq"], ""),
                    Job = Utility.GetStr(saleMan["Job"], ""),
                    Memo = Utility.GetStr(saleMan["Memo"], ""),
                    Name = Utility.GetStr(saleMan["Name"], ""),
                    PositionX = Utility.GetFloat(saleMan["PositionX"], 0),
                    PositionY = Utility.GetFloat(saleMan["PositionY"], 0),
                };
                HttpContext.Current.Session["SaleMan"] = circleMan;
            }
        }
    }
}

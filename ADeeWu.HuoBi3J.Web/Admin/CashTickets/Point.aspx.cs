using ADeeWu.HuoBi3J.Libary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web.Admin.CashTickets
{
    public partial class Point : System.Web.UI.Page
    {
        DAL.CT_CashTickets cashTicketDAL = new ADeeWu.HuoBi3J.DAL.CT_CashTickets();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var selectValues = WebUtility.GetRequestStr("selectValues", string.Empty);
                if (string.IsNullOrWhiteSpace(selectValues))
                {
                    Response.Write("未选择现金券！");
                    Response.End();
                    return;
                }
                var selectCashTicketIDs = selectValues.Split(new char[] { ',' }).Select(p => Utility.GetInt(p, 0));
                var corpid = WebUtility.GetRequestInt("corpid", -1);
                if (corpid <= 0)
                {
                    Response.Write("商家ID不存在！");
                    Response.End();
                    return;
                }

                foreach (var cashTicketID in selectCashTicketIDs)
                {
                    var cashTicket = cashTicketDAL.GetEntity(cashTicketID);
                    if (cashTicket == null) continue;

                    if (cashTicket.CorpID <= 0)
                    {
                        cashTicket.CorpID = corpid;
                        cashTicket.CheckState = 0;
                        cashTicketDAL.Update(cashTicket);
                    }
                }

                Response.Write("ok");
                Response.End();
                return;
            }
        }
    }
}
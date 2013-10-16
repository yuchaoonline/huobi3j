using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;

namespace ADeeWu.HuoBi3J.Web.Admin
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class SystemSetup : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
            SetPages();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// 插入所有页面的PageID,开发时使用
        /// </summary>
        private void SetPages()
        {

            List<object[]> pages = new List<object[]>();

            pages.Add(new object[] { new Default(), "后台默认页" });

            //001
            pages.Add(new object[] { new Users.Edit(), "注册用户管理 - 修改" });
            pages.Add(new object[] { new Users.List(), "注册用户管理 - 查询" });

            //002
            //pages.Add(new object[] { new Corps.Add(), "商家管理 - 添加" });
            //pages.Add(new object[] { new Corps.Edit(), "商家管理 - 修改" });
            pages.Add(new object[] { new Corps.List(), "商家管理 - 查询" });
            pages.Add(new object[] { new Corps.ListByAdmin(), "业务统计 - 商家统计" });

            //003
            pages.Add(new object[] { new CashTickets.Add(), "现金券管理 - 系统生成" });
            pages.Add(new object[] { new CashTickets.Edit(), "现金券管理 - 修改" });
            pages.Add(new object[] { new CashTickets.List(), "现金券管理 - 查询" });
            pages.Add(new object[] { new CashTickets.ListByAdmin(), "业务统计 - 现金券统计" });

            //004
            pages.Add(new object[] { new CashTicketApplications.List(), "现金券兑现申请管理 - 查询" });
            //pages.Add(new object[] { new CashTicketApplications.Edit(), "现金券兑现申请管理 - 修改" });
            pages.Add(new object[] { new CashTicketApplications.ListByAdmin(), "业务统计 - 现金券兑换统计" });

            //005
            //pages.Add(new object[] { new TransferApplications.Edit(), "用户转帐申请管理 - 添加" });
            //pages.Add(new object[] { new TransferApplications.List(), "用户转帐申请管理 - 查询" });
            ////pages.Add(new object[] { new TransferApplications.Del(), "用户转帐申请管理 - 删除" });

            ////006
            //pages.Add(new object[] { new AlipayTransfers.Add(), "支付宝转帐管理 - 添加转帐记录" });
            //pages.Add(new object[] { new AlipayTransfers.List(), "支付宝转帐管理 - 历史记录" });

            //007
            pages.Add(new object[] { new VirtualTransfers.Add(), "会员帐号费用管理 - 帐号充值" });
            pages.Add(new object[] { new VirtualTransfers.Sub(), "会员帐号费用管理 - 帐号扣费" });
            pages.Add(new object[] { new VirtualTransfers.List(), "会员帐号费用管理 - 费用明细记录" });

            //008
            //pages.Add(new object[] { new CT_PartnerCorps.Add(), "现金券合作商家管理 - 添加" });
            pages.Add(new object[] { new CT_PartnerCorps.Edit(), "现金券合作商家管理 - 修改" });
            //pages.Add(new object[] { new CT_PartnerCorps.Add(), "现金券合作商家管理 - 列表" });

            //009
            pages.Add(new object[] { new Coins.List(), "会员货币管理 - 明细记录" });
            pages.Add(new object[] { new Coins.Sub(), "会员货币管理 - 扣除货币" });


            //010
            pages.Add(new object[] { new CP_Promotions.List(), "商家推广管理 - 推广商家列表" });
            pages.Add(new object[] { new CP_Promotions.Edit(), "商家推广管理 - 修改" });

            //011
            pages.Add(new object[] { new CP_Keywords.Edit(), "商家推广管理 - 推广关键字(商家设置) - 修改" });
            pages.Add(new object[] { new CP_Keywords.List(), "商家推广管理 - 推广关键字(商家设置) - 列表" });

            //012
            pages.Add(new object[] { new CP_KeywordIndex.List(), "商家推广 - 关键字索引缓存列区" });
            pages.Add(new object[] { new CP_KeywordIndex.Refresh(), "商家推广 - 关键字索引缓存列区 - 刷新" });

            //013
            pages.Add(new object[] { new Houses.List(), "在线出租管理 - 列表" });
            pages.Add(new object[] { new Houses.Edit(), "在线出租管理 - 修改" });

            //014
            pages.Add(new object[] { new Jobs.List(), "在线出租管理 - 列表" });
            pages.Add(new object[] { new Jobs.Edit(), "在线出租管理 - 修改" });

            //015
            pages.Add(new object[] { new Marketing.List(), "在线出营销 - 列表" });
            pages.Add(new object[] { new Marketing.Edit(), "在线出营销 - 修改" });

            //016
            //pages.Add(new object[] { new Market_Categories.Add(), "在线出营销分类 - 添加" });
            //pages.Add(new object[] { new Market_Categories.Edit(), "在线出营销分类 - 修改" });
            //pages.Add(new object[] { new Market_Categories.List(), "在线出营销分类 - 列表" });
            //pages.Add(new object[] { new Market_Categories.GenerateJSData(), "在线出营销分类 - 生成文件" });

            //017
            //pages.Add(new object[] { new SupplyDemand.List(), "竞投报价 - 列表" });
            //pages.Add(new object[] { new SupplyDemand.Edit(), "竞投报价 - 修改" });

            //018
            pages.Add(new object[] { new WebIM.UINS.List(), "通讯号码管理 - 列表" });
            pages.Add(new object[] { new WebIM.UINS.Edit(), "通讯号码管理 - 修改" });
            pages.Add(new object[] { new WebIM.UINS.Add(), "通讯号码管理 - 生成" });




            pages.Add(new object[] { new SystemManage.AdminRoles.Add(), "后台用户角色管理 - 添加" });
            pages.Add(new object[] { new SystemManage.AdminRoles.Edit(), "后台用户角色管理 - 修改" });
            pages.Add(new object[] { new SystemManage.AdminRoles.List(), "后台用户角色管理 - 查询" });
            pages.Add(new object[] { new SystemManage.AdminRoles.Del(), "后台用户角色管理 - 删除" });

            pages.Add(new object[] { new SystemManage.AdminUsers.Add(), "后台用户管理 - 添加" });
            pages.Add(new object[] { new SystemManage.AdminUsers.Edit(), "后台用户管理 - 修改" });
            pages.Add(new object[] { new SystemManage.AdminUsers.List(), "后台用户管理 - 查询" });
            pages.Add(new object[] { new SystemManage.AdminUsers.Del(), "后台用户管理 - 删除" });



            ADeeWu.HuoBi3J.DAL.Admin_Pages dal = new ADeeWu.HuoBi3J.DAL.Admin_Pages();
            dal.Delete("", null);//清除所有
            foreach (object[] o in pages)
            {
                PageBase page = (PageBase)o[0];
                string s = o[1].ToString();
                ADeeWu.HuoBi3J.Model.Admin_Pages entPage = new ADeeWu.HuoBi3J.Model.Admin_Pages();
                entPage.Description = s;
                entPage.PageCode = page.PageID;
                entPage.PageName = s;
                entPage.URL = "";
                dal.Add(entPage);
            }

        }
    }
}

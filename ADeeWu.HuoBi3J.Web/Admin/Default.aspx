<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.Default" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理系统 -- Power by Email:sam65718@hotmail.com</title>

    <script type="text/javascript" src="js/admin.js"></script>

    <link href="skins/css/style.css" rel="stylesheet" type="text/css" />
    <style>
        .main_left
        {
            table-layout: auto;
            background: url(skins/images/left_bg.gif);
        }
        .main_left_top
        {
            background: url(skins/images/left_menu_bg.gif);
            padding-top: 2px !important;
            padding-top: 5px;
        }
        .main_left_title
        {
            text-align: left;
            padding-left: 15px;
            font-size: 14px;
            font-weight: bold;
            color: #fff;
        }
        .left_iframe
        {
            height: 92%;
            visibility: inherit;
            width: 180px;
            background: transparent;
        }
        .main_iframe
        {
            width: 100%;
            z-index: 1;
        }
        table
        {
            font-size: 12px;
            font-family: tahoma, 宋体, fantasy;
        }
        td
        {
            font-size: 12px;
            font-family: tahoma, 宋体, fantasy;
        }
    </style>

    <script>
var status = 1;
var Menus = new DvMenuCls;
document.onclick=Menus.Clear;
function switchSysBar(){
     if (1 == window.status){
		  window.status = 0;
          switchPoint.innerHTML = '<img src="skins/images/left.gif">';
          document.all("frmTitle").style.display="none"
     }
     else{
		  window.status = 1;
          switchPoint.innerHTML = '<img src="skins/images/right.gif">';
          document.all("frmTitle").style.display=""
     }
}
    </script>

</head>
<body style="margin: 0px">
    <!--导航部分-->
    <div class="top_table">
        <div class="top_table_leftbg">
            <div class="system_logo">
                管理系统</div>
            <div class="menu">
                <ul>
                    <li id="menu_100" onmouseover="Menus.Show(this,0)" onclick="getleftbar(this);"><a
                        href="default.html" target='frmright'>系统帮助</a>
                        <div class="menu_childs" onmouseout="Menus.Hide(100);">
                            <ul>
                                <li><a href="default.html" target='frmright'>默认</a></li>
                                <li><a href="default.html" target='frmright'>用户角色</a></li>
                                <li><a href="default.html" target='frmright'>用户权限</a></li>
                                <li><a href="default.html" target='frmright'>密码设置</a></li>
                                <li><a href="/refreshbasedata.aspx" target='frmright'>刷新数据</a></li>
                            </ul>
                        </div>
                        <div class="menu_div">
                            <img src="skins/images/menu01_right.gif" style="vertical-align: bottom;"></div>
                    </li>
                    <li id="menu_0" onmouseover="Menus.Show(this,0)" onclick="getleftbar(this);"><a href="javascript:void(0);"
                        target='frmright'>系统管理</a>
                        <div class="menu_childs" onmouseout="Menus.Hide(0);">
                            <ul>
                                <li><a href="SystemManage/AdminUsers/Add.aspx" target='frmright'>添加用户</a></li>
                                <li><a href="SystemManage/AdminUsers/List.aspx" target='frmright'>用户列表</a></li>
                                <li><a href="SystemManage/AdminRoles/Add.aspx" target='frmright'>添加角色</a></li>
                                <li><a href="SystemManage/AdminRoles/List.aspx" target='frmright'>角色列表</a></li>
                            </ul>
                        </div>
                        <div class="menu_div">
                            <img src="skins/images/menu01_right.gif" style="vertical-align: bottom;"></div>
                    </li>
                    <li id="menu_1" onmouseover="Menus.Show(this,0)" onclick="getleftbar(this);"><a href="Corps/list.aspx"
                        target='frmright'>商家管理</a>
                        <div class="menu_childs" onmouseout="Menus.Hide(0);">
                            <ul>
                                <li><a href="Corps/list.aspx" target='frmright'>商家列表</a></li>
                                <li><a href="Corps/listByAdmin.aspx" target='frmright'>商家列表[管理员]</a></li>
                            </ul>
                        </div>
                        <div class="menu_div">
                            <img src="skins/images/menu01_right.gif" style="vertical-align: bottom;"></div>
                    </li>
                    <li id="menu_2" onmouseover="Menus.Show(this,0)" onclick="getleftbar(this);"><a href="Users/list.aspx"
                        target='frmright'>注册用户管理</a>
                        <div class="menu_childs" onmouseout="Menus.Hide(0);">
                            <ul>
                                <li><a href="Users/list.aspx" target='frmright'>用户列表</a></li>
                                <li><a href="VirtualTransfers/Add.aspx" target='frmright'>充值</a></li>
                                <li><a href="VirtualTransfers/Sub.aspx" target='frmright'>扣费</a></li>
                                <li><a href="VirtualTransfers/List.aspx" target='frmright'>帐户交易记录</a></li>
                                <li><a href="Coins/Add.aspx" target='frmright'>添加货币</a></li>
                                <li><a href="Coins/Sub.aspx" target='frmright'>扣除货币</a></li>
                                <li><a href="Coins/List.aspx" target='frmright'>货币明细记录</a></li>
                                <li><a href="TransferApplications/List.aspx" target='frmright'>用户转帐申请管理</a></li>
                                <li><a href="AlipayTransfers/List.aspx" target='frmright'>支付宝转帐历史记录</a></li>
                                <li><a href="AlipayTransfers/Add.aspx" target='frmright'>添加支付宝转帐记录</a></li>
                            </ul>
                        </div>
                        <div class="menu_div">
                            <img src="skins/images/menu01_right.gif" style="vertical-align: bottom;"></div>
                    </li>
                    <li id="menu_3" onmouseover="Menus.Show(this,0)" onclick="getleftbar(this);"><a href="CashTicket.html"
                        target='frmright'><strong>现金赠送</strong></a>
                        <div class="menu_childs" onmouseout="Menus.Hide(0);">
                            <ul>
                                <li><a href="CashTicketApplications/List.aspx" target='frmright'>现金券兑现申请管理</a></li>
                                <li><a href="CashTickets/add.aspx" target='frmright'>现金券生成</a></li>
                                <li><a href="CashTickets/list.aspx" target='frmright'>现金券列表</a></li>
                                <li><a href="CT_PartnerCorps/List.aspx" target='frmright'>合作商家[业务员]</a></li>
                                <li><a href="CT_PartnerCorps/ListByAdmin.aspx" target='frmright'>合作商家[统计]</a></li>
                                <li><a href="CashTickets/ListByAdmin.aspx" target='frmright'>现金券统计</a></li>
                                <li><a href="CashTicketApplications/ListByAdmin.aspx" target='frmright'>现金券兑换统计</a></li>
                            </ul>
                        </div>
                        <div class="menu_div">
                            <img src="skins/images/menu01_right.gif" style="vertical-align: bottom;"></div>
                    </li>
                    <li id="menu_4" onmouseover="Menus.Show(this,0)" onclick="getleftbar(this);"><a href="CorpPromitions.html"
                        target='frmright'><strong>商家推广</strong></a>
                        <div class="menu_childs" onmouseout="Menus.Hide(0);">
                            <ul>
                                <li><a href="CP_Promotions/List.aspx" target='frmright'>推广信息管理</a></li>
                                <li><a href="CP_Keywords/List.aspx" target='frmright'>推广关键字(商家设置)</a></li>
                                <li><a href="CP_KeywordIndex/List.aspx" target='frmright'>关键字索引缓存区</a></li>
                                <li><a href="CP_KeywordIndex/Refresh.aspx" target='frmright'>更新索引缓存区</a></li>
                            </ul>
                        </div>
                        <div class="menu_div">
                            <img src="skins/images/menu01_right.gif" style="vertical-align: bottom;"></div>
                    </li>
                    <%--<li id="Li1"><a href="SupplyDemand/DeFault.aspx" target='frmright'><strong>竞投报价</strong></a>
          <div class="menu_div"><img src="skins/images/menu01_right.gif" style="vertical-align:bottom;"></div>
        </li>--%>
                    <li id="menu_5" onmouseover="Menus.Show(this,0)" onclick="getleftbar(this);"><a href="javascript:void(0);"
                        target='frmright'><strong>在线营销</strong></a>
                        <div class="menu_childs" onmouseout="Menus.Hide(0);">
                            <ul>
                                <li><a href="Shops/Products/ProductCategories/GenerateJSData.aspx" target='frmright'>
                                    生成分类</a></li>
                                <li><a href="CorpAgent/Applications/List.aspx" target='frmright'>营销代理商申请简历</a></li>
                                <li><a href="CorpAgent/UserInCorps/List.aspx" target='frmright'>商家邀请代理商</a></li>
                                <li><a href="Shops/List.aspx" target='frmright'>营销商铺</a></li>
                                <li><a href="Shops/Products/ProductCategories/List.aspx" target='frmright'>营销商品分类</a></li>
                                <li><a href="Shops/Products/List.aspx" target='frmright'>商品管理</a></li>
                                <li><a href="Shops/Orders/List.aspx" target='frmright'>订单管理</a></li>
                                <li><a href="Shops/Orders/AfterSaleRecords/List.aspx" target='frmright'>售后服务</a></li>
                            </ul>
                        </div>
                        <div class="menu_div">
                            <img src="skins/images/menu01_right.gif" style="vertical-align: bottom;"></div>
                    </li>
                    <li id="menu_5" onmouseover="Menus.Show(this,0)" onclick="getleftbar(this);"><a href="javascript:void(0);"
                        target='frmright'><strong>企业形象展示</strong></a>
                        <div class="menu_childs" onmouseout="Menus.Hide(0);">
                            <ul>
                                <li><a href="CorpImage/Albums/List.aspx" target='frmright'>企业相册</a></li>
                                <li><a href="CorpImage/Albums/Photos/List.aspx" target='frmright'>企业图片</a></li>
                                <li><a href="CorpImage/Catalogs/List.aspx" target='frmright'>电子画册</a></li>
                                <li><a href="CorpImage/Videos/List.aspx" target='frmright'>企业视频</a></li>
                            </ul>
                        </div>
                        <div class="menu_div">
                            <img src="skins/images/menu01_right.gif" style="vertical-align: bottom;"></div>
                    </li>
                    <li id="menu_6" onmouseover="Menus.Show(this,0)" onclick="getleftbar(this);"><a href="Jobs/List.aspx"
                        target='frmright'><strong>在线招聘</strong></a>
                        <div class="menu_childs" onmouseout="Menus.Hide(0);">
                            <ul>
                                <li><a href="Job/List.aspx" target='frmright'>职位列表</a></li>
                                <li><a href="Job_Categories/List.aspx" target='frmright'>职位分类列表</a></li>
                                <li><a href="Job_Categories/Add.aspx" target='frmright'>添加职位分类</a></li>
                                <li><a href="Job_Categories/GenerateJSData.aspx" target='frmright'>生成职位分类缓冲数据</a></li>
                                <li><a href="Job_Callings/List.aspx" target='frmright'>行业分类列表</a></li>
                                <li><a href="Job_Callings/Add.aspx" target='frmright'>添加行业分类</a></li>
                                <li><a href="Job_Callings/GenerateJSData.aspx" target='frmright'>生成行业分类缓冲数据</a></li>
                            </ul>
                        </div>
                        <div class="menu_div">
                            <img src="skins/images/menu01_right.gif" style="vertical-align: bottom;"></div>
                    </li>
                    <li id="menu_7"><a href="Houses/List.aspx" target='frmright'><strong>在线出租</strong></a>
                        <div class="menu_div">
                            <img src="skins/images/menu01_right.gif" style="vertical-align: bottom;"></div>
                    </li>
                    <li id="menu_8" onmouseover="Menus.Show(this,0)" onclick="getleftbar(this);"><a href="javascript:void(0);"
                        target='frmright'><strong>通讯号码管理</strong></a>
                        <div class="menu_childs" onmouseout="Menus.Hide(0);">
                            <ul>
                                <li><a href="WebIM/UINS/List.aspx" target='frmright'>管理通讯号码</a></li>
                                <li><a href="WebIM/UINS/Add.aspx" target='frmright'>生成通讯号码</a></li>
                            </ul>
                        </div>
                        <div class="menu_div">
                            <img src="skins/images/menu01_right.gif" style="vertical-align: bottom;"></div>
                    </li>
                    <li id="menu_9" onmouseover="Menus.Show(this,0)" onclick="getleftbar(this);"><a href="javascript:void(0);"
                        target='frmright'><strong>行业分类</strong></a>
                        <div class="menu_childs" onmouseout="Menus.Hide(0);">
                            <ul>
                                <li><a href="Callings/List.aspx" target='frmright'>分类列表</a></li>
                                <li><a href="Callings/Add.aspx" target='frmright'>添加分类</a></li>
                                <li><a href="Callings/GenerateJSData.aspx" target='frmright'>生成静态文件</a></li>
                            </ul>
                        </div>
                        <div class="menu_div">
                            <img src="skins/images/menu01_right.gif" style="vertical-align: bottom;"></div>
                    </li>
                    <li id="menu_10" onmouseover="Menus.Show(this,0)" onclick="getleftbar(this);"><a href="javascript:void(0);"
                        target='frmright'><strong>论坛管理</strong></a>
                        <div class="menu_childs" onmouseout="Menus.Hide(0);">
                            <ul>
                                <li><a href="Forum/PageManager.aspx" target='frmright'>版块管理</a></li>
                                <li><a href="Forum/Default.aspx" target='frmright'>发布帖子</a></li>
                                <li><a href="Forum/Manager.aspx" target='frmright'>管理帖子</a></li>
                                <li><a href="Forum/ApplyCash.aspx" target='frmright'>发布申请</a></li>
                                <li><a href="Forum/ApplyCashManager.aspx" target='frmright'>管理申请</a></li>
                                <li><a href="Forum/AllselsUser.aspx" target='frmright'>营销会员</a></li>
                                <li><a href="Forum/AutoReply.aspx" target='frmright'>自动回复</a></li>
                            </ul>
                        </div>
                        <div class="menu_div">
                            <img src="skins/images/menu01_right.gif" style="vertical-align: bottom;"></div>
                    </li>
                    <li id="menu_11" onmouseover="Menus.Show(this,0)" onclick="getleftbar(this);"><a href="javascript:void(0);"
                        target='frmright'><strong>精准搜索</strong></a>
                        <div class="menu_childs" onmouseout="Menus.Hide(0);">
                            <ul>
                                <li><a href="CP_Keyword_AD/List.aspx" target='frmright'>广告管理</a></li>
                                <li><a href="CP_Keyword_Search/List.aspx" target='frmright'>关键字管理</a></li>
                            </ul>
                        </div>
                        <div class="menu_div">
                            <img src="skins/images/menu01_right.gif" style="vertical-align: bottom;"></div>
                    </li>
                    <li id="menu_12" onmouseover="Menus.Show(this,0)" onclick="getleftbar(this);"><a href="javascript:void(0);"
                        target='frmright'><strong>即时报价</strong></a>
                        <div class="menu_childs" onmouseout="Menus.Hide(0);">
                            <ul>
                                <li><a href="Center/SaleMan.aspx" target='frmright'>业务员管理</a></li>
                                <li><a href="Center/InformList.aspx" target='frmright'>举报管理</a></li>
                                <li><a href="Center/QuestionList.aspx" target='frmright'>提问列表</a></li>
                                <li><a href="Center/ProductList.aspx" target='frmright'>商品列表</a></li>
                                <li><a href="Center/CopyData.aspx" target='frmright'>复制分类</a></li>
                                <li><a href="Center/HotKeys.aspx" target='frmright'>有券热门关键字</a></li>
                                <li><a href="Center/key4attribute.aspx" target='frmright'>关键字属性管理</a></li>
                            </ul>
                        </div>
                        <div class="menu_div">
                            <img src="skins/images/menu01_right.gif" style="vertical-align: bottom;"></div>
                    </li>
                    <li id="menu_13" onmouseover="Menus.Show(this,0)" onclick="getleftbar(this);"><a href="javascript:void(0);"
                        target='frmright'><strong>密码现金券</strong></a>
                        <div class="menu_childs" onmouseout="Menus.Hide(0);">
                            <ul>
                                <li><a href="FreeAdmission/New.aspx" target='frmright'>生成密码现金券</a></li>
                                <li><a href="FreeAdmission/List.aspx" target='frmright'>密码现金券管理</a></li>
                            </ul>
                        </div>
                        <div class="menu_div">
                            <img src="skins/images/menu01_right.gif" style="vertical-align: bottom;"></div>
                    </li>
                    <li id="menu_14" onmouseover="Menus.Show(this,0)" onclick="getleftbar(this);"><a href="javascript:void(0);"
                        target='frmright'><strong>返现管理</strong></a>
                        <div class="menu_childs" onmouseout="Menus.Hide(0);">
                            <ul>
                                <li><a href="groupbuy/default.aspx" target='frmright'>返现列表</a></li>
                                <li><a href="groupbuy/category.aspx" target='frmright'>返现分类</a></li>
                            </ul>
                        </div>
                        <div class="menu_div">
                            <img src="skins/images/menu01_right.gif" style="vertical-align: bottom;"></div>
                    </li>
                </ul>
            </div>
        </div>
    </div>
    </div>
    <div style="height: 24px; background: #337ABB;">
    </div>
    <!--导航部分结束-->
    <table border="0" cellpadding="0" cellspacing="0" height="100%" width="100%" style="background: #337ABB;">
        <tbody>
            <tr>
                <td align="middle" id="frmTitle" valign="top" name="fmTitle" class="main_left">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="main_left_top">
                        <tr height="32">
                            <td valign="top">
                            </td>
                            <td class="main_left_title" id="leftmenu_title">
                                常用快捷功能
                            </td>
                            <td valign="top" align="right">
                            </td>
                        </tr>
                    </table>
                    <iframe frameborder="0" id="frmleft" name="frmleft" src="left.htm" class="left_iframe"
                        allowtransparency="true"></iframe>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr height="32">
                            <td valign="top">
                            </td>
                            <td valign="bottom" align="center">
                            </td>
                            <td valign="top" align="right">
                            </td>
                        </tr>
                    </table>
                </td>
                <td bgcolor="#337ABB" style="width: 10px">
                    <table border="0" cellpadding="0" cellspacing="0" height="100%">
                        <tbody>
                            <tr>
                                <td onclick="switchSysBar()" style="height: 100%">
                                    <span class="navPoint" id="switchPoint" title="关闭/打开左栏">
                                        <img src="skins/images/right.gif"></span>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
                <td bgcolor="#337ABB" width="100%" valign="top">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#C4D8ED">
                        <tr height="32">
                            <td valign="top" width="10" background="skins/images/bg2.gif">
                                <img src="skins/images/teble_top_left.gif" alt="" />
                            </td>
                            <td background="skins/images/bg2.gif" width="28">
                                <img src="skins/images/arrow.gif" alt="" align="absmiddle" />
                            </td>
                            <td background="skins/images/bg2.gif">
                                <span style="color: #c00; font-weight: bold; width: 300px;">当前用户名称</span>
                            </td>
                            <td background="skins/images/bg2.gif" style="text-align: right; color: #135294;">
                                <a href="logout.aspx" target="_top">退出</a>
                            </td>
                            <td align="right" valign="top" background="skins/images/bg2.gif" width="28">
                                <img src="skins/images/teble_top_right.gif" alt="" />
                            </td>
                            <td align="right" width="16" bgcolor="#337ABB">
                            </td>
                        </tr>
                    </table>
                    <div style="padding-right: 16px">
                        <iframe frameborder="0" id="frmright" name="frmright" scrolling="yes" src="<%=defaultUrl %>"
                            width="100%" style="overflow-x: hidden; height: 680px;" class="main_iframe">
                        </iframe>
                    </div>
                </td>
            </tr>
        </tbody>
    </table>
</body>
</html>

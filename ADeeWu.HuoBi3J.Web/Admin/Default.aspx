<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.Default" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理系统 -- Power by Email:sam65718@hotmail.com</title>

    <script type="text/javascript" src="js/admin.js"></script>

    <link href="skins/css/style.css" rel="stylesheet" type="text/css" />
    <style>
        .main_left {
            table-layout: auto;
            background: url(skins/images/left_bg.gif);
        }

        .main_left_top {
            background: url(skins/images/left_menu_bg.gif);
            padding-top: 2px !important;
            padding-top: 5px;
        }

        .main_left_title {
            text-align: left;
            padding-left: 15px;
            font-size: 14px;
            font-weight: bold;
            color: #fff;
        }

        .left_iframe {
            height: 92%;
            visibility: inherit;
            width: 180px;
            background: transparent;
        }

        .main_iframe {
            width: 100%;
            z-index: 1;
        }

        table {
            font-size: 12px;
            font-family: tahoma, 宋体, fantasy;
        }

        td {
            font-size: 12px;
            font-family: tahoma, 宋体, fantasy;
        }
    </style>

    <script>
        var status = 1;
        var Menus = new DvMenuCls;
        document.onclick = Menus.Clear;
        function switchSysBar() {
            if (1 == window.status) {
                window.status = 0;
                switchPoint.innerHTML = '<img src="skins/images/left.gif">';
                document.all("frmTitle").style.display = "none"
            }
            else {
                window.status = 1;
                switchPoint.innerHTML = '<img src="skins/images/right.gif">';
                document.all("frmTitle").style.display = ""
            }
        }
    </script>

</head>
<body style="margin: 0px">
    <!--导航部分-->
    <div class="top_table">
        <div class="top_table_leftbg">
            <div class="system_logo">
                管理系统
            </div>
            <div class="menu">
                <ul>
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
                            <img src="skins/images/menu01_right.gif" style="vertical-align: bottom;">
                        </div>
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
                            <img src="skins/images/menu01_right.gif" style="vertical-align: bottom;">
                        </div>
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
                            <img src="skins/images/menu01_right.gif" style="vertical-align: bottom;">
                        </div>
                    </li>
                    <li id="menu_12" onmouseover="Menus.Show(this,0)" onclick="getleftbar(this);"><a href="javascript:void(0);"
                        target='frmright'><strong>货比三家</strong></a>
                        <div class="menu_childs" onmouseout="Menus.Hide(0);">
                            <ul>
                                <li><a href="Center/SaleMan.aspx" target='frmright'>业务员管理</a></li>
                                <li><a href="Center/ProductList.aspx" target='frmright'>商品列表</a></li>
                                <li><a href="Center/SearchHotKey.aspx" target='frmright'>首页热门关键字</a></li>
                                <li><a href="Center/key4attribute.aspx" target='frmright'>关键字属性管理</a></li>
                            </ul>
                        </div>
                        <div class="menu_div">
                            <img src="skins/images/menu01_right.gif" style="vertical-align: bottom;">
                        </div>
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <div style="height: 24px; background: #337ABB;"></div>
    <!--导航部分结束-->
    <table border="0" cellpadding="0" cellspacing="0" height="90%" width="100%" style="background: #337ABB;">
        <tbody>
            <tr>
                <td align="middle" id="frmTitle" valign="top" name="fmTitle" class="main_left">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="main_left_top">
                        <tr height="32">
                            <td valign="top"></td>
                            <td class="main_left_title" id="leftmenu_title">常用快捷功能
                            </td>
                            <td valign="top" align="right"></td>
                        </tr>
                    </table>
                    <iframe frameborder="0" id="frmleft" name="frmleft" src="left.htm" class="left_iframe"
                        allowtransparency="true"></iframe>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr height="32">
                            <td valign="top"></td>
                            <td valign="bottom" align="center"></td>
                            <td valign="top" align="right"></td>
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
                            <td align="right" width="16" bgcolor="#337ABB"></td>
                        </tr>
                    </table>
                    <div style="padding-right: 16px">
                        <iframe frameborder="0" id="frmright" name="frmright" scrolling="yes" src="<%=defaultUrl %>"
                            width="100%" style="overflow-x: hidden; height: 680px;" class="main_iframe"></iframe>
                    </div>
                </td>
            </tr>
        </tbody>
    </table>
</body>
</html>

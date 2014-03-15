<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Prices.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Center.Prices" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="ADeeWuControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    货比三家 - 个人管理中心 - 我的关键字列表
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="/CSS/forum_common.css" rel="stylesheet" type="text/css" />
    <link href="/CSS/forum_forumdisplay.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <a href="/My/User/Center/MyQuestionList.aspx">货比三家</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <div class="box">
        <div class="box_head1">
            <label class="fb font14 black70">基本信息</label>
        </div>
        <div class="box_body">
            <span style="color: blue;">手机扫描二维码次数：<font color="#ff9933"><asp:Literal ID="litQRCount" runat="server"></asp:Literal></font> 次，已经送出金币：<font color="#ff9933"><asp:Literal ID="litCoin" runat="server"></asp:Literal></font>个</span>
            <a href="AddPrice.aspx" title="添加价格" class="btn_blue" style="float: right;">添加价格</a>
        </div>
    </div>

    <div class="mn">
        <div class="tl bm bmw" id="threadlist">
            <div class="th">
                <table cellspacing="0" cellpadding="0">
                    <tbody>
                        <tr>
                            <td class="num">价格
                            </td>
                            <td class="common">简单描述
                            </td>
                            <%--<td class="common">选中属性
                            </td>--%>
                            <td class="num">点击数
                            </td>
                            <td class="common">操作
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="bm_c">
                <table cellspacing="0" cellpadding="0" summary="forum_2">
                    <tbody>
                        <asp:Repeater ID="rpQuestions" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td class="num">
                                        <a href="/Center/details.aspx?id=<%# Eval("id") %>" title="查看"><%# GetMoney(Eval("price")) %></a>
                                    </td>
                                    <td class="common">
                                        <%# Eval("title")%>
                                    </td>
                                    <%--<td class="common">
                                           类型：<%# Eval("selecttype")%>;价格：<%# Eval("selectprice")%>;其他：<%# Eval("selectsize")%>
                                    </td>--%>
                                    <td class="num">
                                        <a href="PriceCount4Key.aspx?id=<%# Eval("id") %>"><%# GetCount(Eval("id")) %></a>
                                    </td>
                                    <td class="common">
                                        <a href="EditPrice.aspx?id=<%# Eval("id") %>" title="修改" class="btn_blue">修改</a>
                                        <a href="Prices.aspx?method=delete&id=<%# Eval("id") %>" title="删除" class="btn_blue">删除</a>
                                        <a href="SearchKey.aspx?id=<%# Eval("id") %>" title="指定关键字" class="btn_blue">关键字</a>
                                        <%--<a href="AddBusinessCircleToPrice.aspx?id=<%# Eval("id") %>" title="指定商圈" class="btn_blue">商圈</a>--%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
    </div>

    <div class="pager" align="center">
        <ADeeWuControl:Pager ID="Pager1" runat="server" />
    </div>
</asp:Content>

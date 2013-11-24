<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="PriceList4Key.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Center.PriceList4Key" %>

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
    <a href="AddPrice4Key.aspx?kid=<%=Request["kid"] %>" title="添加价格" class="btn_blue">添加价格</a>
    <div class="mn">
        <div class="tl bm bmw" id="threadlist">
            <div class="th">
                <table cellspacing="0" cellpadding="0">
                    <tbody>
                        <tr>
                            <td class="common">价格
                            </td>
                            <td class="common">简单描述
                            </td>
                            <td class="common">选中属性
                            </td>
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
                                    <td class="common">
                                        <a href="/Center/details.aspx?id=<%# Eval("id") %>" title="查看"><%# GetMoney(Eval("price")) %></a>
                                    </td>
                                    <td class="common">
                                            <%# Eval("simpledesc")%>
                                    </td>
                                    <td class="common">
                                           类型：<%# Eval("selecttype")%>;价格：<%# Eval("selectprice")%>;其他：<%# Eval("selectsize")%>
                                    </td>
                                    <td class="num">
                                            <a href="PriceCount4Key.aspx?id=<%# Eval("id") %>"><%# Eval("ClickCount") %></a>
                                    </td>
                                    <td class="common">
                                        <a href="EditPrice4Key.aspx?id=<%# Eval("id") %>" title="修改" class="btn_blue">修改</a>
                                        <a href="PriceList4Key.aspx?method=delete&id=<%# Eval("id") %>&kid=<%# Eval("kid") %>" title="删除" class="btn_blue">删除</a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>

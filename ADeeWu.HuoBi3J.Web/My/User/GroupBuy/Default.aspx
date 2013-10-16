<%@ Page Title="" Language="C#" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.GroupBuy.Default" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    返现订单
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="/CSS/forum_common.css" rel="stylesheet" type="text/css" />
    <link href="/CSS/forum_forumdisplay.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    全民营销 - 个人管理中心 - 返现订单
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <div class="mn">
        <div class="tl bm bmw" id="threadlist">
            <div class="th">
                <table cellspacing="0" cellpadding="0">
                    <tbody>
                        <tr>
                            <td class="common">标题
                            </td>                            
                            <td class="by2">预订时间
                            </td>
                            <td class="by2">价格
                            </td>
                            <td class="by2">商家名称
                            </td>
                            <td class="by2">商家电话
                            </td>
                            <td class="by2">消费密码
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="bm_c">
                <table cellspacing="0" cellpadding="0" summary="forum_2">
                    <tbody>
                        <asp:Repeater ID="rpResult" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td class="common">
                                        <a class="xst question" href="/groupbuy/details.aspx?productID=<%# Eval("orderproductid") %>"><%# Eval("Title") %></a>
                                    </td>
                                    <td class="by2">
                                       <%# Eval("orderdate") %>
                                    </td>
                                    <td class="by2">
                                        <%# Eval("price") %>
                                    </td>
                                    <td class="by2">
                                        <%# Eval("sellername") %>
                                    </td>
                                    <td class="by2">
                                            <%# Eval("sellertel")%>
                                    </td>
                                    <td class="by2" style="text-align: right;">
                                        <%# Eval("code") %>
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
        <IscControl:Pager ID="Pager1" runat="server" />
    </div>
</asp:Content>

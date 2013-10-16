<%@ Page Title="" Language="C#" MasterPageFile="~/MMyCorp.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.GroupBuy.Default" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    商家后台
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="/CSS/forum_common.css" rel="stylesheet" type="text/css" />
    <link href="/CSS/forum_forumdisplay.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
     - 返现列表
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
                            <td class="by2">价格
                            </td>
                            <td class="by2">审核日期
                            </td>
                            <td class="by2">预订天数
                            </td>
                            <td class="by2">审核通过
                            </td>
                            <td class="by2">活动过期
                            </td>
                            <td class="by2">操作
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
                                        <a class="xst question" href="/groupbuy/details.aspx?productID=<%# Eval("id") %>"><%# Eval("Title") %></a>
                                    </td>
                                    <td class="by2">
                                       <%# Eval("price") %>
                                    </td>
                                    <td class="by2">
                                        <%# Eval("passdate") %>
                                    </td>
                                    <td class="by2">
                                        <%# Eval("saleday")%>
                                    </td>
                                    <td class="by2">
                                        <%# IsPass(Eval("ispass")) %>
                                    </td>
                                    <td class="by2">
                                        <%# IsExpire(Eval("isexpire")) %>
                                    </td>
                                    <td class="by2">
                                        <a href="Order.aspx?productid=<%# Eval("id") %>">相关订单</a>
                                        <%# Edit(Eval("ispass"),Eval("id")) %>
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
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">
</asp:Content>

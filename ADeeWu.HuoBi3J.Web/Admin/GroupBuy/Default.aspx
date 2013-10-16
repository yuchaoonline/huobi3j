<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MAdmin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.GroupBuy.Default" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="/CSS/forum_common.css" rel="stylesheet" type="text/css" />
    <link href="/CSS/forum_forumdisplay.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
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
                            <td class="by2">消费|预定|总数
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
                        <asp:Repeater ID="rpResult" runat="server" OnItemCommand="rpResult_ItemCommand">
                            <ItemTemplate>
                                <tr>
                                    <td class="common">
                                        <a class="xst question" target="_blank" href="/groupbuy/details.aspx?productID=<%# Eval("id") %>"><%# Eval("Title") %></a>
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
                                        <%# Eval("salecount") %>|<%# Eval("ordercount") %>|<%# Eval("summary") %>
                                    </td>
                                    <td class="by2">
                                        <asp:LinkButton runat="server" CommandArgument='<%# Eval("id") %>' CommandName="pass">通过</asp:LinkButton>
                                        <asp:LinkButton runat="server" CommandArgument='<%# Eval("id") %>' CommandName="drop">下架</asp:LinkButton>
                                        <br />
                                        <a href="editordercount.aspx?id=<%# Eval("id") %>">修改订购数</a>
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

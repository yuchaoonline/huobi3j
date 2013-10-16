<%@ Page Title="" Language="C#" MasterPageFile="~/MMyCorp.master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.GroupBuy.Order" %>
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
                            <td class="by2">预订人
                            </td>
                            <td class="by2">预订时间
                            </td>
                            <td class="by2">已消费
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
                                    <td class="by2">
                                       <%# Eval("orderusername") %>
                                    </td>
                                    <td class="by2">
                                        <%# Eval("orderdate") %>
                                    </td>
                                    <td class="by2">
                                        <%# IsUse(Eval("isuse")) %>
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

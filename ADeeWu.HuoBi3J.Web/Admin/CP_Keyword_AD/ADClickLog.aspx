<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="ADClickLog.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.CP_Keyword_AD.ADClickLog"  %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="CashTicketControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
Admin - Corps - List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
.searchTable .key{ width:auto; }
.searchTable .input{ width:auto; }
</style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>商家推广</span> &gt; 关键字索引缓存列区 | <a href="Refresh.aspx">更新缓存区</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
<input type="hidden" name="page"  value="1" />
<table id="resultList" class="dataGrid">
        <asp:Repeater ID="rpADList" runat="server">
            <HeaderTemplate>
                <tr>
                    <th>广告</th>
                    <th>关键字</th>
                    <th>点击单价</th>
                    <th>点击IP</th>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#GetADName( Eval("adid")) %></td>
                    <td><%#GetKeyword(Eval("keywordid"))%></td>
                    <td><%#Eval("clickprice")%></a></td>
                    <td><%#Eval("clickip") %></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
<table width="100%" class="dataGrid_Footer">
    <tr>
        <td class="pagerBox">
            <CashTicketControl:Pager ID="Pager1" runat="server"  />
        </td>
    </tr>
</table>
</asp:Content>


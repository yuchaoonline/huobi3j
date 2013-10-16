<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="List.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.CP_Keyword_AD.List"  %>

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
                    <th>标题</th>
                    <th>描述</th>
                    <th>链接</th>
                    <th>所属用户</th>
                    <th>审核</th>
                    <th>操作</th>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#ADeeWu.HuoBi3J.Libary.Utility.SubString(Eval("Name"),20,"...") %></td>
                    <td><%#ADeeWu.HuoBi3J.Libary.Utility.SubString(Eval("Content"),20,"...") %></td>
                    <td><a href="<%#ADeeWu.HuoBi3J.Libary.WebUtility.FormatURL(Eval("Link")) %>" title="点击查看"><%#ADeeWu.HuoBi3J.Libary.WebUtility.FormatURL(Eval("Link"))%></a></td>
                    <td><%#GetUserName(Eval("UserID")) %></td>
                    <td><%#Convert.ToBoolean(Eval("IsPass"))?"通过":"<font color='red'>未通过</font>" %></td>
                    <td>
                        <a href="Edit.aspx?id=<%#Eval("id")%>" title="编辑">编辑</a>
                        <%--<a href="AuctionLog.aspx?id=<%#Eval("id")%>" title="竞价记录">竞价记录</a>--%>
                        <a href="ADClickLog.aspx?id=<%#Eval("id")%>&name=<%# HttpUtility.UrlEncode(Eval("Name").ToString()) %>" title="点击记录">点击记录</a>
                    </td>
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


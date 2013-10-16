<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="Result.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.CP_Keyword_Search.Result"  %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>
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
    <table id="resultList" class="dataGrid">
        <asp:Repeater ID="rpResultList" runat="server">
            <HeaderTemplate>
                <tr>
                    <th>标题</th>
                    <th>描述</th>
                    <th>链接</th>
                    <th>点击数</th>
                    <th>操作</th>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#Eval("Title") %></td>
                    <td><%#Eval("Content") %></td>
                    <td><a href="<%#ADeeWu.HuoBi3J.Libary.WebUtility.FormatURL(Eval("Link")) %>" title="点击查看"><%#ADeeWu.HuoBi3J.Libary.WebUtility.FormatURL(Eval("Link"))%></a></td>
                    <td><%#Eval("Count") %></td>
                    <td>
                        <a href="DelResult.aspx?id=<%#Eval("id")%>&keywordid=<%# id %>" onclick="return confirm('确认要删除该记录吗?同时将删除有关该记录的统计！');" title="删除">删除</a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
	<div class="pager">
        <IscControl:Pager ID="Pager1" runat="server"  />
    </div>
</asp:Content>


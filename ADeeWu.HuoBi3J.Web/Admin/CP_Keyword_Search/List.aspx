<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="List.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.CP_Keyword_Search.List"  %>
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
<table class="formTable" class="dataGrid">
        <tr>
            <th colspan="2">
                搜索关键字
            </th>
        </tr>
        <tr>
	        <td class="tdLeft">精准关键字：</td>
	        <td class="tdRight"><asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox><asp:Button ID="btnSubmit" runat="server" Text="搜索" onclick="btnSubmit_Click" /></td>
        </tr>
    </table>

    <table id="resultList" class="dataGrid">
        <asp:Repeater ID="rpADList" runat="server">
            <HeaderTemplate>
                <tr>
                    <th>拥有者</th>
                    <th>精准关键字</th>
                    <th>添加时间</th>
                    <th>操作</th>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#Eval("UserID") %></td>
                    <td><%#Eval("Keyword") %></td>
                    <td><%#Eval("CreateTime") %></td>
                    <td>
                        <a href="Del.aspx?id=<%#Eval("id")%>" title="删除">删除</a>
                        <a href="Result.aspx?id=<%#Eval("id")%>" title="删除">搜索结果</a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <div class="pager">
        <IscControl:Pager ID="Pager1" runat="server"  />
    </div>
</asp:Content>


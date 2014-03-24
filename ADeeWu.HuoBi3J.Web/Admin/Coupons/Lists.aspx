<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MAdmin.Master" AutoEventWireup="true" CodeBehind="Lists.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.Coupons.Lists" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <table class="searchTable">
        <tr>
            <td><a href="AddList.aspx?subjectid=<%=Request["subjectid"] %>">新建券</a></td>
        </tr>
        <tr>
            <td><asp:Literal ID="litSpecial" runat="server"></asp:Literal></td>
        </tr>
    </table>
    <table class="gridView" width="100%">
        <asp:Repeater ID="rpResult" runat="server">
            <HeaderTemplate>
                <tr>
                    <th>金额</th>
                    <th>金钱类型</th>
                    <th>有效期</th>
                    <th>使用者</th>
                    <th>使用时间</th>
                    <th>状态</th>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("money")%></td>
                    <td><%# Eval("ismoney").ToString().ToLower()=="true"?"金钱":"金币"%></td>
                    <td><%# Eval("startdate") %> - <%# Eval("enddate") %></td>
                    <td><%# Eval("loginname") %></td>
                    <td><%# Eval("usedate") %></td>
                    <td><%# Eval("isuse").ToString().ToLower()=="true"?"已使用":"未使用"%></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>

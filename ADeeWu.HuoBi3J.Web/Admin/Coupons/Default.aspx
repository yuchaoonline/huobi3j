<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MAdmin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.Coupons.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    消费券主题
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <table class="searchTable">
        <tr>
            <td><a href="AddSubject.aspx">新建</a></td>
        </tr>
    </table>
    <table class="gridView" width="100%">
        <asp:Repeater ID="rpResult" runat="server">
            <HeaderTemplate>
                <tr>
                    <th>名称</th>
                    <th>开始时间</th>
                    <th>结束时间</th>
                    <th>金额</th>
                    <th>金钱类型</th>
                    <th>数量</th>
                    <th>状态</th>
                    <th>操作</th>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("name")%></td>
                    <td><%# Eval("startdate")%></td>
                    <td><%# Eval("enddate") %></td>
                    <td><%# Eval("money")%></td>
                    <td><%# Eval("ismoney").ToString().ToLower()=="true"?"金钱":"金币"%></td>
                    <td><%# Eval("money_count") %></td>
                    <td><%# Eval("inactive").ToString().ToLower()=="true"?"过期":"正常"%></td>
                    <td>
                        <a href="EditSubject.aspx?id=<%#Eval("ID") %>">编辑</a>
                        <a href="Default.aspx?id=<%#Eval("ID") %>&method=del">删除</a>
                        <a href="Lists.aspx?subjectid=<%# Eval("ID") %>">查看券</a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>

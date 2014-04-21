<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MAdmin.Master" AutoEventWireup="true" CodeBehind="ViewClickCount.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.Center.ViewClickCount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <h3>最近一周点击量</h3>
    <table class="gridView" width="100%">
        <tr>
            <th>日期</th>
            <th>点击量</th>
            <th>花费</th>
        </tr>
        <asp:Repeater ID="rpDate" runat="server">
            <ItemTemplate>
                <tr>
                    <td><%# Eval("Date") %></td>
                    <td><%# Eval("ViewCount") %></td>
                    <td><%# ADeeWu.HuoBi3J.Libary.Utility.GetFloat(Eval("Fee"),0).ToString("0.00") %></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <h3>最近6个月点击量</h3>
    <table class="gridView" width="100%">
        <tr>
            <th>月份</th>
            <th>点击量</th>
            <th>花费</th>
        </tr>
        <asp:Repeater ID="rpMonth" runat="server">
            <ItemTemplate>
                <tr>
                    <td><%# Eval("Month") %></td>
                    <td><%# Eval("ViewCount") %></td>
                    <td><%# ADeeWu.HuoBi3J.Libary.Utility.GetFloat(Eval("Fee"),0).ToString("0.00") %></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>

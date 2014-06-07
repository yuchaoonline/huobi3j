<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MAdmin.Master" AutoEventWireup="true" CodeBehind="CashWhenFeeLog.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.Coupons.CashWhenFeeLog" %>

<%@ Import Namespace="ADeeWu.HuoBi3J.Libary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <table class="gridView" width="100%">
        <asp:Repeater ID="rpWeek" runat="server">
            <HeaderTemplate>
                <tr>
                    <th class="common">日期</th>
                    <th class="common">领取次数</th>
                    <th class="common">领取使用次数</th>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <tr>
                        <td><%# Eval("CreateDate") %></td>
                        <td><%# Eval("TotalCount") %></td>
                        <td><%# Eval("TotalUseCount") %></td>
                    </tr>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>

    <table class="gridView" width="100%">
        <asp:Repeater ID="rpMonth" runat="server">
            <HeaderTemplate>
                <tr>
                    <th class="common">月份</th>
                    <th class="common">领取次数</th>
                    <th class="common">领取使用次数</th>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <tr>
                        <td><%# Eval("CreateMonth") %></td>
                        <td><%# Eval("TotalCount") %></td>
                        <td><%# Eval("TotalUseCount") %></td>
                    </tr>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>

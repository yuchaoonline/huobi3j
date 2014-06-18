<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MAdmin.Master" AutoEventWireup="true" CodeBehind="CashWhenFeeLog.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.Coupons.CashWhenFeeLog" %>

<%@ Import Namespace="ADeeWu.HuoBi3J.Libary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <table class="searchTable">
        <tr>
            <td class="key">商家名称:</td>
            <td class="input">
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
            <td class="key">商家公司名称:</td>
            <td class="input">
                <asp:TextBox ID="txtCompanyName" runat="server"></asp:TextBox></td>
            <td class="key">
                <asp:Button ID="btnSubmit" runat="server" Text="搜索" OnClick="btnSubmit_Click" /></td>
        </tr>
    </table>
    <h3>最近一周</h3>
    <table class="gridView" width="100%">
        <asp:Repeater ID="rpWeek" runat="server">
            <HeaderTemplate>
                <tr>
                    <th class="common">日期</th>
                    <th class="common">领取次数</th>
                    <th class="common">领取使用次数</th>
                    <th class="common">消费次数</th>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <tr>
                        <td><%# Eval("Title") %></td>
                        <td><%# Eval("TotalCount") %></td>
                        <td><%# Eval("TotalUseCount") %></td>
                        <td><%# Eval("TotalExchangeCount") %></td>
                    </tr>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <h3>最近半年</h3>
    <table class="gridView" width="100%">
        <asp:Repeater ID="rpMonth" runat="server">
            <HeaderTemplate>
                <tr>
                    <th class="common">月份</th>
                    <th class="common">领取次数</th>
                    <th class="common">领取使用次数</th>
                    <th class="common">消费次数</th>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <tr>
                        <td><%# Eval("Title") %></td>
                        <td><%# Eval("TotalCount") %></td>
                        <td><%# Eval("TotalUseCount") %></td>
                        <td><%# Eval("TotalExchangeCount") %></td>
                    </tr>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <h3>汇总</h3>
    <table class="gridView" width="100%">
        <asp:Repeater ID="rpTotal" runat="server">
            <HeaderTemplate>
                <tr>
                    <th class="common">领取次数</th>
                    <th class="common">领取使用次数</th>
                    <th class="common">消费次数</th>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <tr>
                        <td><%# Eval("TotalCount") %></td>
                        <td><%# Eval("TotalUseCount") %></td>
                        <td><%# Eval("TotalExchangeCount") %></td>
                    </tr>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="ViewClick.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Center.ViewClick" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="/CSS/forum_common.css" rel="stylesheet" type="text/css" />
    <link href="/CSS/forum_forumdisplay.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <h3>最近一周</h3>
    <div class="mn">
        <div class="tl bm bmw">
            <div class="th">
                <table cellspacing="0" cellpadding="0">
                    <tbody>
                        <tr>
                            <td class="common">日期</td>
                            <td class="common">点击量</td>
                            <td class="common">花费</td>
                            <td class="common">扣费详情</td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="bm_c">
                <table cellspacing="0" cellpadding="0" summary="forum_2">
                    <tbody>
                        <asp:Repeater ID="rpDate" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("Date") %></td>
                                    <td><%# Eval("ViewCount") %></td>
                                    <td><%# ADeeWu.HuoBi3J.Libary.Utility.GetFloat(Eval("Fee"),0).ToString("0.00") %></td>
                                    <td><a href="ViewPriceLog.aspx?month=<%# Eval("Date") %>" class="btn_blue">详情</a></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
    </div>

    <h3>最近6个月</h3>
    <div class="mn">
        <div class="tl bm bmw">
            <div class="th">
                <table cellspacing="0" cellpadding="0">
                    <tbody>
                        <tr>
                            <td class="common">月份</td>
                            <td class="common">点击量</td>
                            <td class="common">花费</td>
                            <td class="common">扣费详情</td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="bm_c">
                <table cellspacing="0" cellpadding="0" summary="forum_2">
                    <tbody>
                        <asp:Repeater ID="rpMonth" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("Month") %></td>
                                    <td><%# Eval("ViewCount") %></td>
                                    <td><%# ADeeWu.HuoBi3J.Libary.Utility.GetFloat(Eval("Fee"),0).ToString("0.00") %></td>
                                    <td><a href="ViewPriceLog.aspx?month=<%# Eval("Month") %>" class="btn_blue">详情</a></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>

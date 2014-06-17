<%@ Page Title="" Language="C#" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="ObtainLog.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Coupons.ObtainLog" %>

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
                            <td class="common">领取次数</td>
                            <td class="common">领取券数</td>
                            <td class="common">消费券数</td>
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
                                    <td><%# Eval("Title") %></td>
                                    <td><%# Eval("TotalCount") %></td>
                                    <td><%# Eval("TotalUseCount") %></td>
                                    <td><%# Eval("TotalExchangeCount") %></td>
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
                            <td class="common">领取次数</td>
                            <td class="common">领取使用次数</td>
                            <td class="common">消费次数</td>
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
                                    <td><%# Eval("Title") %></td>
                                    <td><%# Eval("TotalCount") %></td>
                                    <td><%# Eval("TotalUseCount") %></td>
                                    <td><%# Eval("TotalExchangeCount") %></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>

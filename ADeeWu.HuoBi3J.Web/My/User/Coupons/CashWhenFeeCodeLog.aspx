﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="CashWhenFeeCodeLog.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Coupons.CashWhenFeeCodeLog" %>

<%@ Import Namespace="ADeeWu.HuoBi3J.Libary" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="ADeeWuControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="/CSS/forum_common.css" rel="stylesheet" type="text/css" />
    <link href="/CSS/forum_forumdisplay.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <div class="mn">
        <div class="tl bm bmw" id="threadlist">
            <div class="th">
                <table cellspacing="0" cellpadding="0">
                    <tbody>
                        <tr>
                            <td class="common">消费金额
                            </td>
                            <td class="common">抵扣金额
                            </td>
                            <td class="common">商家
                            </td>
                            <td class="common">领取时间
                            </td>
                            <td class="num">券数
                            </td>
                            <td class="num">消费码
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="bm_c">
                <table cellspacing="0" cellpadding="0" summary="forum_2">
                    <tbody>
                        <asp:Repeater ID="rpGet" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td class="common">
                                        <%# Eval("fee").GetDecimal().ToString("0.00") %>
                                    </td>
                                    <td class="common">
                                        <%# Eval("money").GetDecimal().ToString("0.00") %>
                                    </td>
                                    <td class="common">
                                        <%# Eval("saleman") %>
                                    </td>
                                    <td class="common">
                                        <%# Eval("createtime") %>
                                    </td>
                                    <td class="num">
                                        <%# Eval("usecount") %>
                                    </td>
                                    <td class="num">
                                        <%# Eval("usecode") %>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
    </div>

    <div class="pager" align="center">
        <ADeeWuControl:Pager3 ID="Pager1" runat="server" />
    </div>
</asp:Content>

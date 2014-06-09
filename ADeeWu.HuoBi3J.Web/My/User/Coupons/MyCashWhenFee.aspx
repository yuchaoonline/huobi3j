<%@ Page Title="" Language="C#" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="MyCashWhenFee.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Coupons.MyCashWhenFee" %>

<%@ Import Namespace="ADeeWu.HuoBi3J.Libary" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="ADeeWuControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    货比三家 - 个人管理中心 - 我的代金券
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
                            <td class="common">有效期
                            </td>
                            <td class="common">券数/已使用
                            </td>
                            <td class="common">操作时间
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="bm_c">
                <table cellspacing="0" cellpadding="0" summary="forum_2">
                    <tbody>
                        <asp:Repeater ID="rpQuestions" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td class="common">
                                        <%# Eval("fee").GetDecimal().ToString("0.00") %>
                                    </td>
                                    <td class="common">
                                        <%# Eval("money").GetDecimal().ToString("0.00") %>
                                    </td>
                                    <td class="common">
                                        <%# Eval("companyname") %>
                                    </td>
                                    <td class="common">
                                        <%# Eval("startdate").GetDateTime().ToString("yyyy/MM/dd")%> - <%#Eval("enddate").GetDateTime().ToString("yyyy/MM/dd") %>
                                    </td>
                                    <td class="common">
                                        <%# Eval("count") %>/<%# Eval("usecount") %>
                                    </td>
                                    <td class="common">
                                        <%# Eval("createtime").GetDateTime().ToString("yyyy/MM/dd HH:mm") %>
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

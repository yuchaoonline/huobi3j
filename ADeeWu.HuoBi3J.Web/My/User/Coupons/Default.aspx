<%@ Page Title="" Language="C#" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Coupons.Default" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="ADeeWuControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    货比三家 - 个人管理中心 - 我的优惠券
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="/CSS/forum_common.css" rel="stylesheet" type="text/css" />
    <link href="/CSS/forum_forumdisplay.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <a href="/My/User/Center/MyQuestionList.aspx">货比三家</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <div class="mn">
        <div class="tl bm bmw" id="threadlist">
            <div class="th">
                <table cellspacing="0" cellpadding="0">
                    <tbody>
                        <tr>
                            <td class="common">活动名称
                            </td>
                            <td class="common">金额
                            </td>
                            <td class="common">有效期
                            </td>
                            <td class="common">使用
                            </td>
                            <td class="common">密码
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
                                        <%# Eval("subjectname") %>
                                    </td>
                                    <td class="common">
                                        <%# Eval("money") %>(<%# Eval("ismoney").ToString().ToLower()=="true"?"金钱":"虚拟币" %>)
                                    </td>
                                    <td class="common">
                                        <%# Eval("startdate")%> - <%#Eval("enddate") %>
                                    </td>
                                    <td class="common">
                                        <%# Eval("isuse").ToString().ToLower()=="true"?"已使用("+Eval("usedate")+")":"未使用" %>
                                    </td>
                                    <td class="common">
                                        <%# Eval("password") %>
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

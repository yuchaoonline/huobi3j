<%@ Page Title="" Language="C#" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="SearchKey.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Center.SearchKey" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="ADeeWuControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    全民营销 - 个人管理中心 - 关注关键字
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="/CSS/forum_common.css" rel="stylesheet" type="text/css" />
    <link href="/CSS/forum_forumdisplay.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $('.question img').ReduceImage();
        })
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    货比三家 - 关注关键字
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <table class="searchTable">
        <tr>
            <td class="key">关键字：</td>
            <td class="input">
                <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="搜索" CssClass="btn_blue" OnClick="btnSearch_Click" />
            </td>
        </tr>
    </table>
    <div class="mn">
        <div class="tl bm bmw" id="threadlist">
            <div class="th">
                <table cellspacing="0" cellpadding="0">
                    <tbody>
                        <tr>
                            <td class="common">关键字
                            </td>
                            <td class="common">所属区域
                            </td>
                            <td class="by2">所属商圈
                            </td>
                            <td class="by2">操作
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="bm_c">
                <table cellspacing="0" cellpadding="0" summary="forum_2">
                    <tbody>
                        <asp:Repeater ID="rpResult" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td class="common">
                                        <a class="xst question" href="/Center/key4product.aspx?kid=<%# Eval("KID") %>" title="<%# Eval("KName") %>"><%# Eval("KName") %></a>
                                    </td>
                                    <td class="common">
                                        <%# ADeeWu.HuoBi3J.Web.Class.Helper.GetLocation(Eval("aid"), Eval("aname"), Eval("cid"), Eval("cname"), Eval("pid"), Eval("pname"), "-") %>
                                    </td>
                                    <td class="by2">
                                        <%# ADeeWu.HuoBi3J.Web.Class.Helper.GetBusinessCircle(Eval("bid"),Eval("BName")) %>
                                    </td>
                                    <td class="by2">
                                        <a href="AttentionKey.aspx?kid=<%# Eval("kid") %>" title="关注关键字" class="btn_blue">关注</a>
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


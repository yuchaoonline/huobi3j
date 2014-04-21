<%@ Page Title="" Language="C#" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="SearchKey.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Center.SearchKey" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="ADeeWuControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    货比三家 - 个人管理中心 - 关注关键字
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="/CSS/forum_common.css" rel="stylesheet" type="text/css" />
    <link href="/CSS/forum_forumdisplay.css" rel="stylesheet" type="text/css" />
    <style>
        .tl table{
            width: 600px !important;
        }
        .side_content .box_body table .btn_blue {
            border: none;
            padding: 0;
        }
    </style>
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
    <asp:Repeater runat="server" ID="rpKey">
        <ItemTemplate>
            <div class="box">
                <div class="box_head1">
                    <label class="fb font14 black70">已绑定关键字信息</label>
                </div>
                <div class="box_body">
                    <table>
                        <tbody>
                            <tr height="35px">
                                <td class="tr">关键字：</td>
                                <td class="font14 black4B"><%# Eval("KName") %></td>
                            </tr>
                            <tr height="35px">
                                <td class="tr">类型：</td>
                                <td class="font14 black4B"><%# Eval("SelectType") %></td>
                            </tr>
                            <tr height="35px">
                                <td class="tr">价格：</td>
                                <td class="font14 black4B"><%# Eval("SelectPrice") %></td>
                            </tr>
                            <tr height="35px">
                                <td class="tr">其他：</td>
                                <td class="font14 black4B"><%# Eval("SelectSize") %></td>
                            </tr>
                            <tr height="35px">
                                <td class="tr">点击单价：</td>
                                <td class="font14 black4B"><%# ADeeWu.HuoBi3J.Libary.Utility.GetFloat(Eval("Price"),0).ToString("0.00") %></td>
                            </tr>
                            <tr height="35px">
                                <td class="tr">日点击数：</td>
                                <td class="font14 black4B"><%# Eval("Count") %></td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>

    <div class="box">
        <div class="box_head1">
            <label class="fb font14 black70">搜索关键字</label>
        </div>
        <div class="box_body">
            <table>
                <tbody>
                    <tr height="35px">
                        <td class="tr">关键字：</td>
                        <td class="font14 black4B">
                            <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
                            <asp:Button ID="btnSearch" runat="server" Text="搜索" CssClass="btn_blue" OnClick="btnSearch_Click" />
                        </td>
                    </tr>
                    <tr height="35px">
                        <td class="tr"></td>
                        <td class="font14 black4B">
                            <div class="mn">
                                <div class="tl bm bmw" id="threadlist">
                                    <div class="th">
                                        <table cellspacing="0" cellpadding="0">
                                            <tbody>
                                                <tr>
                                                    <td class="common">关键字</td>
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
                                                                <a class="xst question" href="/Center/key4product.aspx?kid=<%# Eval("KID") %>" title="<%# Eval("Name") %>"><%# Eval("Name") %></a>
                                                            </td>
                                                            <td class="by2">
                                                                <a href="AddKey4Price.aspx?kid=<%# Eval("kid") %>&id=<%=Request["id"] %>" title="绑定关键字" class="btn_blue">绑定</a>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>

    <div class="pager" align="center">
        <ADeeWuControl:Pager3 ID="Pager1" runat="server" />
    </div>
</asp:Content>


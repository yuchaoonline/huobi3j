<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="MyAttentionList.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Center.MyKeyList" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="ADeeWuControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    全民营销 - 个人管理中心 - 我的关键字列表
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="/CSS/forum_common.css" rel="stylesheet" type="text/css" />
    <link href="/CSS/forum_forumdisplay.css" rel="stylesheet" type="text/css" />
    <script>
        $(function () {
            $('#btnSearch').click(function () {
                var url = $(this).attr('href') + "?keyword=" + $('#txtKeyword').val();
                $(this).attr('href', url);
                return true;
            })
        })
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <a href="/My/User/Center/MyQuestionList.aspx">货比三家</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <table class="searchTable">
        <tr>
            <td class="key">关键字：</td>
            <td class="input">
                <input type="text" id="txtKeyword" />
                <a href="SearchKey.aspx" title="搜索" id="btnSearch" class="btn_blue">搜索</a>
            </td>
            <td>
                <span style="color: blue;">已经送出金币：<font color="#ff9933"><asp:Literal ID="litCoin" runat="server"></asp:Literal></font>个</span>
            </td>
        </tr>
    </table>
    <div class="mn">
        <div class="tl bm bmw" id="threadlist">
            <!--列名_Start-->
            <div class="th">
                <table cellspacing="0" cellpadding="0">
                    <tbody>
                        <tr>
                            <th class="by2">关键字
                            </th>
                            <th class="common">所属区域
                            </th>
                            <th class="by2">所属商圈
                            </th>
                            <th class="num">提问数
                            </th>
                            <th class="by2">关注时间
                            </th>
                            <th class="common">操作
                            </th>
                        </tr>
                    </tbody>
                </table>
            </div>
            <!--列名_End-->
            <!--帖子列表_Start-->
            <div class="bm_c">
                <table cellspacing="0" cellpadding="0" summary="forum_2">
                    <tbody>
                        <asp:Repeater ID="rpQuestions" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td class="by2">
                                        <a class="xst question" href="/Center/key4product.aspx?kid=<%# Eval("KID") %>" title="<%# Eval("KName") %>"><%# Eval("KName") %></a>
                                    </td>
                                    <td class="common">
                                        <%# ADeeWu.HuoBi3J.Web.Class.Helper.GetLocation(Eval("aid"), Eval("aname"), Eval("cid"), Eval("cname"), Eval("pid"), Eval("pname"), "-") %>
                                    </td>
                                    <td class="by2">
                                        <a href="/Center/businesscircle.aspx?bid=<%# Eval("bid") %>" title="<%# Eval("BName") %>"><%# Eval("BName") %></a>
                                    </td>
                                    <td class="num">
                                        <em class="xi2">
                                            <%# Eval("QuestionCount") %></em>
                                    </td>
                                    <td class="by2">
                                        <em>
                                            <%# Eval("CreateTime")%></em>
                                    </td>
                                    <td class="common">
                                        <%# IsGoOn(Eval("IsGoOn"), Eval("kid"))%>
                                        <a href="PriceList4Key.aspx?kid=<%# Eval("kid") %>" title="管理价格" class="btn_blue">管理价格</a>
                                        <a href="AddPrice4Key.aspx?kid=<%# Eval("kid") %>" title="添加价格" class="btn_blue">添加价格</a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
            <!--帖子列表_End-->
        </div>
    </div>
    <div class="pager" align="center">
        <ADeeWuControl:Pager ID="Pager1" runat="server" />
    </div>
</asp:Content>

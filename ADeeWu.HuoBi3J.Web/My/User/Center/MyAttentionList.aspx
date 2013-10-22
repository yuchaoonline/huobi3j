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
            $('.question img').ReduceImage();
        })
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <a href="/My/User/Center/MyQuestionList.aspx">即时报价</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <div class="mn">
        <div class="tl bm bmw" id="threadlist">
            <!--列名_Start-->
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
                            <td class="num">提问数
                            </td>
                            <td class="by2">关注时间
                            </td>
                            <td class="common">操作
                            </td>
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
                                    <td class="common">
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

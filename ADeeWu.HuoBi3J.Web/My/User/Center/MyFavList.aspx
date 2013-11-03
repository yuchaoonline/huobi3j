<%@ Page Title="" Language="C#" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="MyFavList.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Center.MyFavList" %>

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
            <!--列名_Start-->
            <div class="th">
                <table cellspacing="0" cellpadding="0">
                    <tbody>
                        <tr>
                            <th class="by2">商家
                            </th>
                            <th class="common">地址
                            </th>
                            <th class="by2">联系方式
                            </th>
                            <th class="by2">操作
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
                                        <%# Eval("companyname")%>
                                    </td>
                                    <td class="common">
                                        <%# Eval("companyaddress")%>
                                    </td>
                                    <td class="by2">
                                        <%# Eval("phone")%>
                                    </td>
                                    <td class="by2">
                                        <a href="/center/SaleMan4Product.aspx?userid=<%# Eval("saleman_userid") %>" title="查看" class="btn_blue">查看</a>
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

<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MAdmin.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.GroupBuy.Category" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="/CSS/forum_common.css" rel="stylesheet" type="text/css" />
    <link href="/CSS/forum_forumdisplay.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <table class="searchTable">
    <tr>
        <td class="key">分类名称:</td>
        <td class="input"><asp:TextBox runat="server" ID="txtName"></asp:TextBox></td>
        <td class="key"><asp:Button runat="server" ID="btnSubmit" Text="添加" OnClick="btnSubmit_Click" /></td>
    </tr>
</table>
    <div class="mn">
        <div class="tl bm bmw" id="threadlist">
            <div class="th">
                <table cellspacing="0" cellpadding="0">
                    <tbody>
                        <tr>
                            <td class="common">分类
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
                        <asp:Repeater ID="rpResult" runat="server" OnItemCommand="rpResult_ItemCommand">
                            <ItemTemplate>
                                <tr>
                                    <td class="common">
                                        <%# Eval("Name") %>
                                    </td>
                                    <td class="by2">
                                        <asp:LinkButton runat="server" CommandArgument='<%# Eval("id") %>' CommandName="delete">删除</asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>

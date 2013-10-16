<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Shops.Vouchers.View" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    个人控制面板 -　查看购物电子凭证
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <span class="spl"></span><a href="/My/User/Shops/Vouchers/">购物电子凭证</a><span class="spl">　</span><span class="curPos">查看</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

    <table class="formTable">

        <tr>
            <td class="tdLeft">标　　题：
            </td>
            <td class="tdRight">
                <asp:Label ID="lblTitle" runat="server" CssClass="txtBox" />
            </td>
        </tr>
        <tr>
            <td class="tdLeft">商　　家：
            </td>
            <td class="tdRight">
                <asp:Label ID="lblCorpName" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="tdLeft">发布时间：
            </td>
            <td class="tdRight">
                <asp:Label ID="lblCreateTime" runat="server" CssClass="txtBox" />
            </td>
        </tr>
        <tr>
            <td class="tdLeft">内　　容：
            </td>
            <td class="tdRight">
                <asp:Label ID="lblContent" runat="server" CssClass="txtBox" />
            </td>
        </tr>

    </table>


</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MAdmin.Master" AutoEventWireup="true" CodeBehind="ViewClick.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.Center.ViewClick" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <table border="0" cellspacing="0" cellpadding="0" class="formTable">
        <tr>
            <td class="tdLeft">次数:</td>
            <td class="tdRight">
                <asp:TextBox ID="txtCount" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">点击钱:</td>
            <td class="tdRight">
                <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">&nbsp;</td>
            <td class="tdRight">
                <asp:Button ID="btnSubmit" runat="server" Text="提交" OnClick="btnSubmit_OnClick" />
            </td>
        </tr>
    </table>
</asp:Content>

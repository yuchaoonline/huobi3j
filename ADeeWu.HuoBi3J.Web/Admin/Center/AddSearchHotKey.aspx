<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MAdmin.Master" AutoEventWireup="true" CodeBehind="AddSearchHotKey.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.Center.AddSearchHotKey" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <table border="0" cellspacing="0" cellpadding="0" class="formTable">
        <tr>
            <td class="tdLeft">名称:</td>
            <td class="tdRight">
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">类型:</td>
            <td class="tdRight">
                <asp:TextBox ID="txtDataType" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">链接:</td>
            <td class="tdRight">
                <asp:TextBox ID="txtLink" runat="server"></asp:TextBox>
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

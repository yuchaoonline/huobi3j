<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MAdmin.Master" AutoEventWireup="true" CodeBehind="AddAttribute.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.Center.AddAttribute" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <asp:HiddenField ID="hfID" runat="server" />
    <font color="red">多值用;分开，例如1;2;3</font>
    <table border="0" cellspacing="0" cellpadding="0" class="formTable">
        <tr>
            <td class="tdLeft">关键字：</td>
            <td class="tdRight">
                <asp:Literal ID="litKeyname" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">类型:</td>
            <td class="tdRight">
                <asp:TextBox ID="txtType" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">尺寸:</td>
            <td class="tdRight">
                <asp:TextBox ID="txtSize" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">价格:</td>
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
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
</asp:Content>

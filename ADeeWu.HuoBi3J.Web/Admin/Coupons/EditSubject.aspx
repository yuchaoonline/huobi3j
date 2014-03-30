<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MAdmin.Master" AutoEventWireup="true" CodeBehind="EditSubject.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.Coupons.EditSubject" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="UserControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <asp:HiddenField ID="hfID" runat="server" />
    <table border="0" cellspacing="0" cellpadding="0" class="formTable">
        <tr>
            <td class="tdLeft">活动名称:</td>
            <td class="tdRight">
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                <span class="require">*</span>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">活动时间:</td>
            <td class="tdRight">
                <UserControl:DateTimeSelector ID="dtStartDate" runat="server"></UserControl:DateTimeSelector>
                -
                <UserControl:DateTimeSelector ID="dtEndDate" runat="server"></UserControl:DateTimeSelector>
                <span class="require">*</span>
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

<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MAdmin.Master" AutoEventWireup="true" CodeBehind="EditOrderCount.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.GroupBuy.EditOrderCount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <table class="searchTable">
        <tr>
            <td class="key">订购数:</td>
            <td class="input">
                <asp:TextBox runat="server" ID="txtOrderCount"></asp:TextBox>最后订购总数=当前输入数+已订购数</td>
            <td class="key">
                <asp:Button runat="server" ID="btnSubmit" Text="修改" OnClick="btnSubmit_Click" /></td>
        </tr>
    </table>
</asp:Content>

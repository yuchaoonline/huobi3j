<%@ Page Title="" Language="C#" MasterPageFile="~/MMyCorp.master" AutoEventWireup="true" CodeBehind="ValCode.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.GroupBuy.ValCode" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    商家后台
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    - 验证消费码
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <table class="searchTable">
        <tr>
            <td class="key" width="80">消费码：
            </td>
            <td class="input">
                <asp:TextBox ID="txtCode" runat="server" Width="120px" />
                <asp:Button ID="btnSubmit" runat="server" Text="验证" OnClick="btnSubmit_Click" />
            </td>
        </tr>
        <tr>
            <td class="key" width="80">返现标题：
            </td>
            <td class="input">
                <asp:Literal ID="litTitle" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="key" width="80">消费情况：
            </td>
            <td class="input">
                <asp:Literal ID="litIsUse" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="key" width="80">操作：
            </td>
            <td class="input">
                <asp:HiddenField ID="hfOrderID" runat="server" />
                <asp:Button ID="btnYes" runat="server"  Text="消费" OnClick="btnYes_Click" Visible ="false"/>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">
</asp:Content>

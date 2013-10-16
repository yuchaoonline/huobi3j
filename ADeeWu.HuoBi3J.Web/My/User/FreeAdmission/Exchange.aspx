<%@ Page Title="" Language="C#" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Exchange.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.FreeAdmission.Exchange" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    个人控制面板 - 密码现金券兑换
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <span class="spl"></span><span class="curPos">兑换密码现金券</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <table class="formTable">
        <tr>
            <td class="tdLeft">序列号：</td>
            <td class="tdRight">
                <asp:TextBox ID="txtSeqNO" runat="server"></asp:TextBox><span class="require">*</span></td>
        </tr>
        <tr>
            <td class="tdLeft">密码：</td>
            <td class="tdRight">
                <asp:TextBox ID="txtSeqPwd" runat="server"></asp:TextBox><span class="require">*</span></td>
        </tr>
        <tr>
            <td class="tdLeft">&nbsp;</td>
            <td class="tdRight">
                <asp:Button ID="btnSubmit" runat="server" Text="提交" OnClick="btnSubmit_Click" /></td>
        </tr>
    </table>
</asp:Content>

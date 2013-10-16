<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Password.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Password" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    个人控制面板 - 密码修改
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <span class="spl"></span><span class="curPos">密码修改</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <table class="formTable">
        <tr>
            <td class="tdLeft">原 密 码：</td>
            <td class="tdRight">
                <asp:TextBox ID="txtPwdNative" runat="server" TextMode="Password"></asp:TextBox><span class="require">*</span>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">新 密 码：</td>
            <td class="tdRight">
                <asp:TextBox ID="txtNewPwd" runat="server" TextMode="Password"></asp:TextBox><span class="require">*</span>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">新密码确认：</td>
            <td class="tdRight">
                <asp:TextBox ID="txtNewPwd2" runat="server" TextMode="Password"></asp:TextBox><span class="require">*</span>
            </td>
        </tr>

        <tr>
            <td class="tdLeft"></td>
            <td class="tdRight">
                <asp:Button ID="btnSubmit" runat="server" Text="修改" OnClick="btnSubmit_Click" />
            </td>
        </tr>
    </table>

</asp:Content>




<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Password.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Password" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    ���˿������ - �����޸�
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <span class="spl"></span><span class="curPos">�����޸�</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <table class="formTable">
        <tr>
            <td class="tdLeft">ԭ �� �룺</td>
            <td class="tdRight">
                <asp:TextBox ID="txtPwdNative" runat="server" TextMode="Password"></asp:TextBox><span class="require">*</span>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">�� �� �룺</td>
            <td class="tdRight">
                <asp:TextBox ID="txtNewPwd" runat="server" TextMode="Password"></asp:TextBox><span class="require">*</span>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">������ȷ�ϣ�</td>
            <td class="tdRight">
                <asp:TextBox ID="txtNewPwd2" runat="server" TextMode="Password"></asp:TextBox><span class="require">*</span>
            </td>
        </tr>

        <tr>
            <td class="tdLeft"></td>
            <td class="tdRight">
                <asp:Button ID="btnSubmit" runat="server" Text="�޸�" OnClick="btnSubmit_Click" />
            </td>
        </tr>
    </table>

</asp:Content>




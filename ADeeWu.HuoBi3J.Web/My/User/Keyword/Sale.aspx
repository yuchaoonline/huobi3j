<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Sale.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Keyword.Sale" %>




<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    ȫ��Ӫ�� - ���˹������� - ��׼����
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

    <table class="formTable">
        <tr>
            <td class="tdLeft">ת�ùؼ���:</td>
            <td class="tdRight">
                <asp:Label ID="lbKeyword" runat="server"></asp:Label><asp:HiddenField ID="hfKeywordID" runat="server" />
            </td>
        </tr>

        <tr>
            <td class="tdLeft">�û���:</td>
            <td class="tdRight">
                <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                <span class="require">*</span></td>
        </tr>

        <tr>
            <td class="tdLeft"></td>
            <td class="tdRight">
                <asp:Button ID="btnSubmit" runat="server" Text="�趨" OnClick="btnSubmit_Click" />
            </td>
        </tr>
    </table>

</asp:Content>


<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="New.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Keyword.New" %>




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
            <td class="tdLeft">�ؼ���:</td>
            <td class="tdRight">
                <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
                <span class="require">*</span>
                <asp:RequiredFieldValidator ID="rfvKeyword" runat="server" ErrorMessage="�ؼ��ֲ���Ϊ��!" ControlToValidate="txtKeyword"></asp:RequiredFieldValidator><br />
                <span class="tips">(����д�����ؼ���,���Ȳ�����10���ַ�)</span>
                <div id="TopKeywordCoins"></div>
            </td>
        </tr>

        <tr>
            <td class="tdLeft"></td>
            <td class="tdRight">
                <asp:Button ID="btnSubmit" runat="server" Text="�趨" OnClick="btnSubmit_Click" />
            </td>
        </tr>
    </table>
</asp:Content>


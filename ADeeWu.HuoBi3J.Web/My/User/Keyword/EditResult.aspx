<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="EditResult.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Keyword.EditResult" %>




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
            <th colspan="2">�༭�������
            <asp:HiddenField ID="hfID" runat="server" />
            </th>
        </tr>
        <tr>
            <td class="tdLeft">���⣺</td>
            <td class="tdRight">
                <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                <span class="require">*</span></td>
        </tr>
        <tr>
            <td class="tdLeft">������</td>
            <td class="tdRight">
                <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine"></asp:TextBox>
                <span class="require">*</span></td>
        </tr>
        <tr>
            <td class="tdLeft">���ӣ�</td>
            <td class="tdRight">
                <asp:TextBox ID="txtLink" runat="server"></asp:TextBox>
                <span class="require">*</span></td>
        </tr>
        <tr>
            <td class="tdLeft"></td>
            <td class="tdRight">
                <asp:Button ID="btnSubmit" runat="server" Text="�༭" OnClick="btnSubmit_Click" />
            </td>
        </tr>
    </table>
</asp:Content>


<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Application.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.TransferApplications._Application" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    ���˿������ -��ת������
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <span class="spl"></span><a href="/My/User/TransferApplications/">�ҵ�ת��������ʷ��¼</a><span class="spl">��</span><span class="curPos">ת������</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

    <table class="formTable">
        <tr>
            <td class="tdLeft">֧�����ʺţ�</td>
            <td class="tdRight">
                <asp:TextBox ID="txtAlipayAccount" runat="server"></asp:TextBox><span class="require">*</span></td>
        </tr>
        <tr>
            <td class="tdLeft">֧�����ʺ�ȷ�ϣ�</td>
            <td class="tdRight">
                <asp:TextBox ID="txtAlipayAccount2" runat="server"></asp:TextBox><span class="require">*</span></td>
        </tr>
        <tr>
            <td class="tdLeft">��ǰ��</td>
            <td class="tdRight">
                <asp:Literal ID="litSpareMoney" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">ת�ʽ�</td>
            <td class="tdRight">
                <asp:PlaceHolder ID="phTxtTransferMoney" runat="server">
                    <asp:TextBox ID="txtTransferMoney" runat="server" Width="20px"></asp:TextBox><span class="require">������<%=ADeeWu.HuoBi3J.Web.GlobalParameter.MinTransferMoney %> �ı���</span>
                </asp:PlaceHolder>
                <asp:Literal ID="litTransferMoney" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">&nbsp;</td>
            <td class="tdRight">
                <asp:Button ID="btnSubmit" runat="server" Text="�ύ"
                    OnClick="btnSubmit_Click" />
                <span class="require">
                    <asp:Literal ID="litMsg" runat="server"></asp:Literal></span>
            </td>
        </tr>
    </table>


</asp:Content>




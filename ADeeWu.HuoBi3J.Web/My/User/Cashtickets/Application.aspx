<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Application.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.CashTickets.Application" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="CashTicketControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    ���˿������ - �ֽ�����ȯ�һ�
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <span class="spl"></span><span class="curPos">�ֽ�����ȯ�һ�</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <table class="formTable">
        <%--<tr>
            <td class="tdLeft">�̼����ƣ�</td>
            <td class="tdRight">
                <asp:TextBox ID="txtCorpName" runat="server"></asp:TextBox><span class="require">*</span></td>
        </tr>
        <tr>
            <td class="tdLeft">���ѽ�</td>
            <td class="tdRight">
                <asp:TextBox ID="txtCostMoney" runat="server" CssClass="txtNum"></asp:TextBox><span class="tips">Ԫ</span><span class="require">*</span></td>
        </tr>
        <tr>
            <td class="tdLeft">���ѽ��ȷ�ϣ�</td>
            <td class="tdRight">
                <asp:TextBox ID="txtCostMoney2" runat="server" CssClass="txtNum"></asp:TextBox><span class="require">* ��ȷ��ʵ�����ѽ��ύ�󽫲����޸�</span></td>
        </tr>
        <tr>
            <td class="tdLeft">�������ڣ�</td>
            <td class="tdRight">
                <CashTicketControl:DateTimeSelector ID="txtCostDate" runat="server" CssClass="txtDate"></CashTicketControl:DateTimeSelector><span class="require">*</span>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">������Ʒ����</td>
            <td class="tdRight">

                <asp:TextBox ID="txtSummary" runat="server" Height="100px" TextMode="MultiLine"
                    Width="280px"></asp:TextBox><span class="require">*</span>

            </td>
        </tr>--%>
        <tr>
            <td class="tdLeft">�ֽ�ȯ���кţ�</td>
            <td class="tdRight">
                <asp:TextBox ID="txtCashTicketSerialNum" runat="server"></asp:TextBox><span class="require">*</span></td>
        </tr>
        <tr>
            <td class="tdLeft">�ֽ�ȯ��֤�룺</td>
            <td class="tdRight">
                <asp:TextBox ID="txtCashTicketValidCode" runat="server"></asp:TextBox><span class="require">*</span></td>
        </tr>
        <tr>
            <td class="tdLeft">&nbsp;</td>
            <td class="tdRight">
                <asp:Button ID="btnSubmit" runat="server" Text="�ύ" OnClick="btnSubmit_Click" /></td>
        </tr>
    </table>

</asp:Content>




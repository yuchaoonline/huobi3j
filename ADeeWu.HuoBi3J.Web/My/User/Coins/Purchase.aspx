<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Purchase.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Coins.Purchase" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="CashTicketControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    ���˿������ - ����������
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <span class="spl"></span><span class="curPos">����������</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <table border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td class="tdLeft">��ǰ��ҳ�������</td>
            <td class="tdRight">
                <asp:Literal ID="liteNumOfCoins" runat="server"></asp:Literal>
                ��
            </td>
        </tr>
        <tr>
            <td class="tdLeft">�ʻ���</td>
            <td class="tdRight">
                <asp:Literal ID="liteBalance" runat="server"></asp:Literal>
                Ԫ
            </td>
        </tr>
        <tr>
            <td class="tdLeft">��Ҷһ��ʣ�</td>
            <td class="tdRight">1 Ԫ = <%=ADeeWu.HuoBi3J.Web.GlobalParameter.MoneyToCoinsRate%>�����
            </td>
        </tr>
        <tr>
            <td class="tdLeft">����������</td>
            <td class="tdRight">
                <asp:TextBox ID="txtTimesOfCoins" runat="server" Width="62px"></asp:TextBox><asp:RequiredFieldValidator
                    ID="rfvTimesOfCoins" runat="server" Display="Dynamic" ControlToValidate="txtTimesOfCoins" ErrorMessage="����д��ȷ��������"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                        ID="revTimesOfCoins" runat="server" Display="Dynamic" ControlToValidate="txtTimesOfCoins" ValidationExpression="\d+" ErrorMessage="����д��ȷ��������"></asp:RegularExpressionValidator><span class="require">*</span><span class="tips">������10�ı���</span>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">&nbsp;</td>
            <td class="tdRight">
                <asp:Button ID="btnSubmit" runat="server" Text="�ύ" OnClick="btnSubmit_Click" OnClientClick="return confirm('ȷ�Ϲ�����?')" /></td>
        </tr>
    </table>

</asp:Content>

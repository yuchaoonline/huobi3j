<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.SupplyDemand.Bidders.Edit" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="CashTicketControl" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    �ֽ�ȯ������ - �ҵ��ʻ�
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <a href="/Account/Default.aspx">�ҵ��ʻ���ҳ</a> &gt;   
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

    <div>
        <table width="100%" border="0" cellspacing="1" cellpadding="5">
            <tr>
                <td valign="top" width="100">���⣺</td>
                <td valign="top">
                    <asp:Literal ID="littitle" runat="server"></asp:Literal>
                </td>
                <td valign="top">&nbsp;
                </td>
            </tr>
            <tr>
                <td valign="top">����ʱ�䣺</td>
                <td valign="top">
                    <asp:Literal ID="litCreateTime" runat="server"></asp:Literal>
                </td>
                <td valign="top">&nbsp;</td>
            </tr>
            <tr>
                <td valign="top">����޸�ʱ�䣺</td>
                <td valign="top">
                    <asp:Literal ID="litModifyTime" runat="server"></asp:Literal></td>
                <td valign="top">&nbsp;</td>
            </tr>
            <tr>
                <td valign="top" width="100">��ֹʱ�䣺</td>
                <td valign="top">
                    <asp:Literal ID="litendtime" runat="server"></asp:Literal>
                </td>
                <td valign="top">&nbsp;</td>
            </tr>
            <tr>
                <td valign="top">��ϸ��</td>
                <td valign="top">
                    <asp:Literal ID="litcontent" runat="server"></asp:Literal>

                </td>
                <td valign="bottom" width="3">&nbsp;</td>
            </tr>
            <tr>
                <td valign="top">�ҵ�Ͷ�����ݣ�</td>
                <td valign="top">
                    <asp:TextBox ID="txtBidders" runat="server" Height="204px" TextMode="MultiLine"
                        Width="554px" Font-Size="12pt"></asp:TextBox>

                </td>
                <td valign="bottom" width="3">&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;
    &nbsp;
                </td>
                <td colspan="2">
                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="����" />

                </td>
            </tr>
            <asp:HiddenField ID="hfsdbid" runat="server" />
        </table>
    </div>

</asp:Content>




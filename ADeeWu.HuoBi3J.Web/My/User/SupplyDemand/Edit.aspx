<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.SupplyDemand.Edit" %>

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
                    <asp:TextBox ID="txtTitle" runat="server" Width="50%" CssClass="txtBox"></asp:TextBox>
                    <span class="require">*</span></td>
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
                <td valign="top">���ˢ��ʱ�䣺</td>
                <td valign="top">
                    <asp:Literal ID="litRefreshTime" runat="server"></asp:Literal></td>
                <td valign="top">&nbsp;</td>
            </tr>
            <tr>
                <td valign="top" width="100">��ֹʱ�䣺</td>
                <td valign="top">
                    <CashTicketControl:DateTimeSelector ID="txtEndTime" runat="server"></CashTicketControl:DateTimeSelector><span class="require">*</span>
                </td>
                <td valign="top">&nbsp;</td>
            </tr>
            <tr>
                <td valign="top">���ʴ�����</td>
                <td valign="top">
                    <asp:Literal ID="litVisitCount" runat="server"></asp:Literal></td>
                <td valign="top">&nbsp;</td>
            </tr>
            <tr>
                <td valign="top">������</td>
                <td valign="top">
                    <asp:TextBox ID="txtSummary" runat="server" TextMode="MultiLine" Width="99%"
                        Height="72px"></asp:TextBox>
                </td>
                <td valign="bottom" width="5">
                    <span class="require">*</span></td>
            </tr>
            <tr>
                <td valign="top">��ϸ��</td>
                <td valign="top">
                    <FCKeditorV2:FCKeditor ID="txtContent" ToolbarSet="Basic" runat="server" Width="100%" Height="200" LinkBrowserURL="false"></FCKeditorV2:FCKeditor>

                </td>
                <td valign="bottom" width="3">
                    <span class="require">*</span></td>
            </tr>
            <tr>
                <td>&nbsp;
    &nbsp;
                </td>
                <td colspan="2">
                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="����" />

                </td>
            </tr>
        </table>
    </div>

</asp:Content>




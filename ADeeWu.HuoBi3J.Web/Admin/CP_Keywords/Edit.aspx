<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="Edit.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.CP_Keywords.Edit"  %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="CashTicketControl" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
Admin - CT_PartnerCorps - Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>�̼��ƹ����</span> &gt; <a href="List.aspx">�ƹ�ؼ���(�̼�����)</a> &gt; �޸�
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

<table border="0" cellspacing="0" cellpadding="0" class="formTable">
  <tr>
    <td class="tdLeft">�ؼ���:</td>
    <td class="tdRight">
        <asp:Literal ID="liteKeyword" runat="server"></asp:Literal>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">���ۻ�������:</td>
    <td class="tdRight">
        <asp:Literal ID="liteCoins" runat="server"></asp:Literal> ��
    </td>
  </tr>
   <tr>
    <td class="tdLeft">�������:</td>
    <td class="tdRight">
        <asp:Literal ID="liteVisitCount" runat="server"></asp:Literal>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">�̼�������ҵ:</td>
    <td class="tdRight">
        <asp:Literal ID="liteCorpCalling" runat="server"></asp:Literal>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">�ƹ����:</td>
    <td class="tdRight">
        <asp:Literal ID="liteTitle" runat="server"></asp:Literal>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">�ƹ���Ϣ:</td>
    <td class="tdRight">
        <asp:Literal ID="liteSummary" runat="server"></asp:Literal>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">�ٷ���վ:</td>
    <td class="tdRight">
       <asp:Literal ID="liteURL" runat="server"></asp:Literal>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">�̼�����:</td>
    <td class="tdRight">
        <asp:Literal ID="liteCorpName" runat="server"></asp:Literal>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">״̬:</td>
    <td class="tdRight">
        <asp:DropDownList ID="ddlCheckState" runat="server">
            <asp:ListItem Value="0">�����</asp:ListItem>
            <asp:ListItem Value="1">ͨ�����</asp:ListItem>
            <asp:ListItem Value="2">��Ч</asp:ListItem>
            <asp:ListItem Value="3">����</asp:ListItem>
        </asp:DropDownList>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">����ʱ��:</td>
    <td class="tdRight">
        <asp:Literal ID="litCrateTime" runat="server"></asp:Literal>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">�޸�ʱ��:</td>
    <td class="tdRight">
        <asp:Literal ID="litModifyTime" runat="server"></asp:Literal>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">&nbsp;</td>
    <td class="tdRight">
        <asp:Button ID="btnSubmit" runat="server" Text="�ύ" OnClick="btnSubmit_OnClick" />
    </td>
  </tr>
</table>


</asp:Content>


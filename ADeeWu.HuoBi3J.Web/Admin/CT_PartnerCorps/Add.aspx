<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="Edit.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.CT_PartnerCorps.Add"  %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="CashTicketControl" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
Admin - CT_PartnerCorps - Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>�ֽ�ȯ�����̼ҹ���</span> &gt; <a href="List.aspx">�����̼��б�</a> &gt; �޸� | <a href="Add.aspx">���(��ͨ�ֽ�ȯ����)</a> 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

<table border="0" cellspacing="0" cellpadding="0" class="formTable">
  <tr>
    <td class="tdLeft">�̼�����:</td>
    <td class="tdRight">
        <asp:DropDownList ID="ddlCorp" runat="server">
        </asp:DropDownList>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">�̼�������ҵ:</td>
    <td class="tdRight">
        <asp:Literal ID="liteCorpCalling" runat="server"></asp:Literal>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">�ṩ����ɰٷֱ�:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtOfferPercent" runat="server" CssClass="txtNum" ></asp:TextBox> (��λ:�ٷֱ�)<span class="require">
        *</span> 
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
    <td class="tdLeft">����Ա:</td>
    <td class="tdRight">
        <asp:Literal ID="litAdminUser" runat="server"></asp:Literal>
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


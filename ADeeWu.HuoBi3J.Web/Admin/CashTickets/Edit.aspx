<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="Edit.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.CashTickets.Edit"  %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
Admin - CashTickets - Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>�ֽ�ȯ����</span> &gt; <a href="List.aspx">�ֽ�ȯ�б�</a> &gt; �޸�  | <a href="Add.aspx">���(ϵͳ����)</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

<table border="0" cellspacing="0" cellpadding="0" class="formTable">
  <tr>
    <td class="tdLeft">���к�:</td>
    <td class="tdRight">
        <asp:Literal ID="litSerialNum" runat="server"></asp:Literal>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">��֤��:</td>
    <td class="tdRight">
        <asp:Literal ID="litValidCode" runat="server"></asp:Literal>
    </td>
  </tr>
    <tr>
    <td class="tdLeft">���:</td>
    <td class="tdRight">
        <asp:Literal ID="litMoney" runat="server"></asp:Literal>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">�����̼�:</td>
    <td class="tdRight">
        <asp:Literal ID="litCorpName" runat="server"></asp:Literal>
    </td>
  </tr>
   <tr>
    <td class="tdLeft">״̬:</td>
    <td class="tdRight">
        <asp:DropDownList ID="ddlCheckState" runat="server">
            <asp:ListItem Value="0">�����(δʹ��)</asp:ListItem>
            <asp:ListItem Value="1">ͨ�����(��ʹ��)</asp:ListItem>
            <asp:ListItem Value="2">��Ч</asp:ListItem>
            <asp:ListItem Value="3">����</asp:ListItem>
        </asp:DropDownList>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">����ʱ��:</td>
    <td class="tdRight">
        <asp:Literal ID="litCreateTime" runat="server"></asp:Literal>
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


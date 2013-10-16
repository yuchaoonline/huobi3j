<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="Refresh.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.CP_KeywordIndex.Refresh"  %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="CashTicketControl" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
Admin - CT_PartnerCorps - Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>�̼��ƹ�</span> &gt; <a href="Refresh.aspx">�ؼ���������������</a> &gt; ���»�����
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

<table border="0" cellspacing="0" cellpadding="0" class="formTable">
  <tr>
    <td class="tdLeft">�����ؼ���:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtKeyword" runat="server" CssClass="txtBox" ></asp:TextBox> <span class="require">*</span> <span class="tips">��������Ҫ���������������Ĺؼ���</span> 
    </td>
  </tr>
  <tr>
    <td class="tdLeft">���йؼ���:</td>
    <td class="tdRight">
        <asp:CheckBox ID="chkIsRefreshAll" runat="server" /> �������йؼ��ֵ�����������
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


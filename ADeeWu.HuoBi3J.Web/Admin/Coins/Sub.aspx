<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="Sub.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.Coins.Sub"  %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
�ޱ����ĵ�
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>��Ա���ҹ���</span> &gt; <a href="List.aspx">��ϸ��¼</a> &gt; �۳����� | <a href="Add.aspx">��ӻ���</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    
<table border="0" cellspacing="0" cellpadding="0" class="formTable">
  <tr>
    <td class="tdLeft">�ʺ�:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtUIN" runat="server"></asp:TextBox>
        <span class="require">*</span> <span class="tips">ѡ��Ҫ�۳����ҵĻ�Ա</span>
    </td>
  </tr>
   <tr>
    <td class="tdLeft">��������:</td>
    <td class="tdRight">
    <asp:TextBox ID="txtCoins" runat="server" CssClass="txtBox" ></asp:TextBox> <span class="require">*</span>
    <span class="tips">��λ:��</span>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">��ע��Ϣ:</td>
    <td class="tdRight">
    <asp:TextBox ID="txtNotes" runat="server" CssClass="txtnotes" TextMode="MultiLine" Rows="4" Columns="50" >ϵͳ����۳�����</asp:TextBox> <span class="tips">һ����д�۳����ҵ�ԭ��</span>    
    </td>
  </tr>
  <tr>
    <td class="tdLeft">&nbsp;</td>
    <td class="tdRight">
        <asp:Button ID="btnSubmit" runat="server" Text="�ύ" OnClick="btnSubmit_OnClick" /> <span class="strewColor">�����ť�ύ��ϵͳ����Ϊ��Ա�۳���Ӧ�Ļ���,ͬʱ��¼��ص���ʷ����</span>
    </td>
  </tr>
</table>


</asp:Content>


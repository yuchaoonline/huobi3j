<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="Add.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.VirtualTransfers.Add"  %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
�ޱ����ĵ�
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>��Ա�ʺŷ��ù���</span> &gt; <a href="List.aspx">������ϸ��¼</a> &gt; �ʻ���ֵ | <a href="Sub.aspx">�ʻ��۷�</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    
<table border="0" cellspacing="0" cellpadding="0" class="formTable">
  <tr>
    <td class="tdLeft">IM�ʺ�:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtUIN" runat="server"></asp:TextBox> <span class="require">*</span> <span class="tips">ѡ��Ҫ�ʺų�ֵ�Ļ�Ա</span>
    </td>
  </tr>
   <tr>
    <td class="tdLeft">��ֵ���:</td>
    <td class="tdRight">
    <asp:TextBox ID="txtMoney" runat="server" CssClass="txtBox" ></asp:TextBox> <span class="require">*</span>
    <span class="tips">��λ:Ԫ</span>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">��ע��Ϣ:</td>
    <td class="tdRight">
    <asp:TextBox ID="txtNotes" runat="server" CssClass="txtnotes" TextMode="MultiLine" Rows="4" Columns="50" >����</asp:TextBox> <span class="tips">һ����д��ֵ��ԭ��,���ֽ�ȯ����ͨ����˷��ؽ��</span>    
    </td>
  </tr>
  <tr>
    <td class="tdLeft">&nbsp;</td>
    <td class="tdRight">
        <asp:Button ID="btnSubmit" runat="server" Text="�ύ" OnClick="btnSubmit_OnClick" /> <span class="strewColor">�����ť�ύ��ϵͳ����Ϊ��Ա�����ʺ����ֵ,ͬʱ��¼��ص���ʷ����</span>
    </td>
  </tr>
</table>


</asp:Content>


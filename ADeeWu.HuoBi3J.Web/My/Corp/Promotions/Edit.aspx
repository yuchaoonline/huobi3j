<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Edit.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.Promotions.Edit" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
�̼ҿ������ - �༭�ƹ���Ϣ
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">��</span><span class="curPos">�̼��ƹ�ؼ��ֹ���</span>  
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

<table border="0" cellspacing="0" cellpadding="0" class="formTable">
  <tr>
    <td class="tdLeft">�̼�����:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtTitle" runat="server" Width="320px"></asp:TextBox><span class="require">*</span><asp:RequiredFieldValidator ID="rfvTitle" runat="server" ErrorMessage="����д!" 
            ControlToValidate="txtTitle"></asp:RequiredFieldValidator>
    </td>
  </tr>
   <tr>
    <td class="tdLeft">�ƹ���Ϣ:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtSummary" runat="server" Columns="50" Rows="2" 
            TextMode="MultiLine"></asp:TextBox><span class="require">*</span><br /><span class="tips">����д��˾����/��Ʒ�Ľ�����Ϣ,������100���ַ��ĳ���</span><asp:RequiredFieldValidator ID="rfvSummary"
                runat="server" ErrorMessage="����д!" ControlToValidate="txtUrl"></asp:RequiredFieldValidator>
    </td>
  </tr>
   <tr>
    <td class="tdLeft">�ٷ���վ:</td>
    <td class="tdRight">
    http://<asp:TextBox ID="txtUrl" runat="server"></asp:TextBox><span class="require">*</span><span class="tips">����д��˾����վURL</span>
    <asp:RequiredFieldValidator ID="rfvUrl" runat="server" ErrorMessage="����д!" 
            ControlToValidate="txtUrl"></asp:RequiredFieldValidator>
    </td>
  </tr>
   <tr>
    <td class="tdLeft"></td>
    <td class="tdRight">
        <asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" OnClientClick="return confirm('ȷ��Ҫ�޸���Ϣ��?�޸���Ϣ����Ҫ����ͨ�����!')" Text="�ύ" />
       </td>
  </tr>
</table>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>

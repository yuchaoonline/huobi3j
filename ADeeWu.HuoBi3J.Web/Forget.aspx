<%@ Page Language="C#" Title="" MasterPageFile="~/MIndex.master"  AutoEventWireup="true" CodeBehind="Forget.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Forget" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
��������
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">

<asp:PlaceHolder ID="phInfoValidation" runat="server">
<table border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td class="tdLeft">��&nbsp;&nbsp;&nbsp;&nbsp;�ţ�</td>
    <td class="tdRight">
        <asp:TextBox ID="txtLoginName" runat="server"></asp:TextBox><span class="require orange">*</span></td>
  </tr>
  <tr>
    <td class="tdLeft">��&nbsp;&nbsp;&nbsp;&nbsp;����</td>
    <td class="tdRight">
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox><span class="require orange">*</span></td>
  </tr>
  <tr>
    <td class="tdLeft">��ϵ�绰��</td>
    <td class="tdRight">
        <asp:TextBox ID="txtTel" runat="server"></asp:TextBox>
        <span class="require orange">*</span><span class="tips orange">��д�����ʺŶ�Ӧ����ϵ�绰</span></td>
  </tr>
  <tr>
    <td class="tdLeft">Email��</td>
    <td class="tdRight">
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
		<asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="����д��ȷ��Email��ַ"></asp:RegularExpressionValidator>
        <span class="require orange">*</span><span class="tips orange">��д�����ʺŶ�Ӧ������</span>   
	 </td>
  </tr>
  <tr>
    <td class="tdLeft">&nbsp;</td>
    <td class="tdRight">
        <asp:Button ID="btnSubmit" runat="server" Text="�ύ" onclick="btnSubmit_Click" /></td>
  </tr>
</table>
</asp:PlaceHolder>


<asp:PlaceHolder ID="phChangePwd" runat="server">
<table border="0" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="tdLeft">��&nbsp;��&nbsp;�룺</td>
        <td class="tdRight">
             <asp:TextBox ID="txtNewPwd" runat="server" TextMode="Password"></asp:TextBox>        </td>
    </tr>
     <tr>
        <td class="tdLeft">������ȷ�ϣ�</td>
        <td class="tdRight">
             <asp:TextBox ID="txtNewPwd2" runat="server" TextMode="Password"></asp:TextBox>        </td>
    </tr>
    
     <tr>
        <td class="tdLeft"></td>
        <td class="tdRight">
            <asp:Button ID="btnSubmit2" runat="server" Text="�޸�" onclick="btnSubmit2_Click" />        </td>
    </tr>
</table>
</asp:PlaceHolder>


</asp:Content>
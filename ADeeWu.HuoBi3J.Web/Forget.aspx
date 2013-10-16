<%@ Page Language="C#" Title="" MasterPageFile="~/MIndex.master"  AutoEventWireup="true" CodeBehind="Forget.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Forget" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
忘记密码
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">

<asp:PlaceHolder ID="phInfoValidation" runat="server">
<table border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td class="tdLeft">帐&nbsp;&nbsp;&nbsp;&nbsp;号：</td>
    <td class="tdRight">
        <asp:TextBox ID="txtLoginName" runat="server"></asp:TextBox><span class="require orange">*</span></td>
  </tr>
  <tr>
    <td class="tdLeft">姓&nbsp;&nbsp;&nbsp;&nbsp;名：</td>
    <td class="tdRight">
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox><span class="require orange">*</span></td>
  </tr>
  <tr>
    <td class="tdLeft">联系电话：</td>
    <td class="tdRight">
        <asp:TextBox ID="txtTel" runat="server"></asp:TextBox>
        <span class="require orange">*</span><span class="tips orange">填写您的帐号对应的联系电话</span></td>
  </tr>
  <tr>
    <td class="tdLeft">Email：</td>
    <td class="tdRight">
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
		<asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="请填写正确的Email地址"></asp:RegularExpressionValidator>
        <span class="require orange">*</span><span class="tips orange">填写您的帐号对应的邮箱</span>   
	 </td>
  </tr>
  <tr>
    <td class="tdLeft">&nbsp;</td>
    <td class="tdRight">
        <asp:Button ID="btnSubmit" runat="server" Text="提交" onclick="btnSubmit_Click" /></td>
  </tr>
</table>
</asp:PlaceHolder>


<asp:PlaceHolder ID="phChangePwd" runat="server">
<table border="0" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="tdLeft">新&nbsp;密&nbsp;码：</td>
        <td class="tdRight">
             <asp:TextBox ID="txtNewPwd" runat="server" TextMode="Password"></asp:TextBox>        </td>
    </tr>
     <tr>
        <td class="tdLeft">新密码确认：</td>
        <td class="tdRight">
             <asp:TextBox ID="txtNewPwd2" runat="server" TextMode="Password"></asp:TextBox>        </td>
    </tr>
    
     <tr>
        <td class="tdLeft"></td>
        <td class="tdRight">
            <asp:Button ID="btnSubmit2" runat="server" Text="修改" onclick="btnSubmit2_Click" />        </td>
    </tr>
</table>
</asp:PlaceHolder>


</asp:Content>
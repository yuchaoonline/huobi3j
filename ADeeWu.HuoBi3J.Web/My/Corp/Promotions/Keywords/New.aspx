<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="New.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.Promotions.Keywords.New" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
�̼ҿ������ - ����̼��ƹ�ؼ���
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" type="text/css" href="../../CSS/default.css">
<script type="text/javascript" src="js/keywords.js"></script>
<style type="text/css">
#TopKeywordCoins{ color:#f00; }
</style>
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">��</span><a href="/My/Corp/Promotions/Keywords/">�̼��ƹ�ؼ��ֹ���</a><span class="spl">��</span><span class="curPos">��ӹؼ���</span> 
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

<table class="formTable">
<tr>
	<td class="tdLeft">�ؼ���:</td>
	<td class="tdRight"><asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox> <span class="require">*</span> <a href="javascript:keywords.search( $('#<%=txtKeyword.ClientID%>').val() , '#TopKeywordCoins' ); void(0);">�鿴���õĹؼ�����߾��ۻ�������</a> <asp:RequiredFieldValidator ID="rfvKeyword" runat="server" ErrorMessage="�ؼ��ֲ���Ϊ��!" ControlToValidate="txtKeyword"></asp:RequiredFieldValidator><br />
<span class="tips">(����д�����ؼ���,���Ȳ��ܳ���10���ַ�)</span>  <div id="TopKeywordCoins"></div>
	</td>
</tr>

<tr>
	<td class="tdLeft">���ۻ�������:</td>
	<td class="tdRight"><asp:TextBox ID="txtCoins" runat="server" Width="40"></asp:TextBox> <span class="require">*</span> 
    <asp:RequiredFieldValidator ID="rfvCoins" runat="server" ErrorMessage="����д��ȷ,��СֵΪ0" Display="Dynamic" ControlToValidate="txtCoins"></asp:RequiredFieldValidator> 
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="����д��ȷ,��СֵΪ0" Display="Dynamic" ValidationExpression="\d+" ControlToValidate="txtCoins"></asp:RegularExpressionValidator>
	<div class="tips">(���ۻ�������Խ��,�ùؼ��ֵ���������Խ��ǰ,ÿ�ΰ��չؼ���������,���۳���Ӧ����ֵ�Ļ�������)</div> 
	</td>
</tr>

<tr>
	<td class="tdLeft"></td>
	<td class="tdRight">
	  <asp:Button ID="btnSubmit" runat="server" Text="�趨" onclick="btnSubmit_Click" />
	</td>
</tr>
</table>
    
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>

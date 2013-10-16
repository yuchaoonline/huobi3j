<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Edit.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.Orders.AfterSaleRecords.Edit" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
�̼ҿ������ - �ۺ�����¼�޸�
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="/js/isc.js"></script>
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">��</span><a href="/My/Corp/Shop/">����Ӫ��</a><span class="spl">��</span><a href="/My/Corp/Shop/Orders/AfterSaleRecords/">�ۺ����</a><span class="spl">��</span><span class="curPos">�޸ļ�¼</span>
 </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

<table border="0" cellspacing="0" cellpadding="0" class="formTable">
<tr>
	<td class="tdLeft">
		��&nbsp;��&nbsp;�ţ�
	</td>
	<td class="tdRight">
		<asp:Label ID="lblOrderCode" runat="server" CssClass="txtBox" ReadOnly="true" />
	</td>
</tr>
<tr>
	<td class="tdLeft">
		��Ʒ���ƣ�
	</td>
	<td class="tdRight">
		<asp:Label ID="lblProductName" runat="server" CssClass="txtBox" ReadOnly="true" />
	</td>
</tr>
<tr>
	<td class="tdLeft">
		����ʱ�䣺
	</td>
	<td class="tdRight">
		<IscControl:DateTimeSelector ID="txtCreateTime" runat="server"></IscControl:DateTimeSelector>
	</td>
</tr>
<tr>
	<td class="tdLeft">
		�޸�ʱ�䣺
	</td>
	<td class="tdRight">
		<asp:Label ID ="lblModifyTime" runat ="server" />
	</td>
</tr>
<tr>
	<td class="tdLeft" >
		��������
	</td>
	<td>
		&nbsp;<asp:RadioButton ID="cboExit" GroupName="state" runat="server" Checked="true"
			Text="��  ��" />
		<asp:RadioButton ID="cboSwap" GroupName="state" runat="server" Text="��  ��" />
		&nbsp;<asp:RadioButton ID="cboRepail" GroupName="state" runat="server" Text="ά  ��" />
		<%--&nbsp;<asp:RadioButton ID="cboStateEnd" GroupName="state" runat="server" Text="���" />--%>
	</td>
</tr>

<tr>
	<td class="tdLeft">
		��&nbsp;&nbsp;&nbsp;&nbsp;ע��
	</td>
	<td class="tdRight">
		<asp:TextBox ID="txtNote" runat="server" TextMode="MultiLine" CssClass="txtNotes" Columns="60" Rows="5"></asp:TextBox>
	</td>
</tr>
<tr>
	<td class="tdLeft">
		<asp:Button ID="btnSubmit" runat="server" Text="�޸�" OnClick="btnSubmit_Click" />
			<%--<a href="javascript:history.back()" >����</a>--%>
	</td>
	<td class="tdRight">
	</td>
</tr>
</table>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>

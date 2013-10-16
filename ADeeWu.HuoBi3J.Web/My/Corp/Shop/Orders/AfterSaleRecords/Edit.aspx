<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Edit.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.Orders.AfterSaleRecords.Edit" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
商家控制面板 - 售后服务记录修改
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="/js/isc.js"></script>
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">　</span><a href="/My/Corp/Shop/">在线营销</a><span class="spl">　</span><a href="/My/Corp/Shop/Orders/AfterSaleRecords/">售后服务</a><span class="spl">　</span><span class="curPos">修改记录</span>
 </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

<table border="0" cellspacing="0" cellpadding="0" class="formTable">
<tr>
	<td class="tdLeft">
		订&nbsp;单&nbsp;号：
	</td>
	<td class="tdRight">
		<asp:Label ID="lblOrderCode" runat="server" CssClass="txtBox" ReadOnly="true" />
	</td>
</tr>
<tr>
	<td class="tdLeft">
		产品名称：
	</td>
	<td class="tdRight">
		<asp:Label ID="lblProductName" runat="server" CssClass="txtBox" ReadOnly="true" />
	</td>
</tr>
<tr>
	<td class="tdLeft">
		处理时间：
	</td>
	<td class="tdRight">
		<IscControl:DateTimeSelector ID="txtCreateTime" runat="server"></IscControl:DateTimeSelector>
	</td>
</tr>
<tr>
	<td class="tdLeft">
		修改时间：
	</td>
	<td class="tdRight">
		<asp:Label ID ="lblModifyTime" runat ="server" />
	</td>
</tr>
<tr>
	<td class="tdLeft" >
		处理结果：
	</td>
	<td>
		&nbsp;<asp:RadioButton ID="cboExit" GroupName="state" runat="server" Checked="true"
			Text="退  货" />
		<asp:RadioButton ID="cboSwap" GroupName="state" runat="server" Text="换  货" />
		&nbsp;<asp:RadioButton ID="cboRepail" GroupName="state" runat="server" Text="维  修" />
		<%--&nbsp;<asp:RadioButton ID="cboStateEnd" GroupName="state" runat="server" Text="完成" />--%>
	</td>
</tr>

<tr>
	<td class="tdLeft">
		备&nbsp;&nbsp;&nbsp;&nbsp;注：
	</td>
	<td class="tdRight">
		<asp:TextBox ID="txtNote" runat="server" TextMode="MultiLine" CssClass="txtNotes" Columns="60" Rows="5"></asp:TextBox>
	</td>
</tr>
<tr>
	<td class="tdLeft">
		<asp:Button ID="btnSubmit" runat="server" Text="修改" OnClick="btnSubmit_Click" />
			<%--<a href="javascript:history.back()" >返回</a>--%>
	</td>
	<td class="tdRight">
	</td>
</tr>
</table>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>

<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Edit.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.Promotions.Keywords.Edit" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
商家控制面板 - 编辑商家推广关键字
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">　</span><a href="/My/Corp/Promotions/Keywords/">商家推广关键字管理</a><span class="spl">　</span><span class="curPos">编辑关键字</span>  
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
<table class="formTable">
<tr>
	<td class="tdLeft">关键字:</td>
	<td class="tdRight">
	<asp:TextBox ID="txtKeyword" runat="server" ReadOnly="True"></asp:TextBox>
	</td>
</tr>
<tr>
	<td class="tdLeft">最高竞价货币数量:</td>
	<td class="tdRight">
	    <asp:Literal ID="liteTopCoins" runat="server"></asp:Literal>个
	</td>
</tr>

<tr>
	<td class="tdLeft">点击次数:</td>
	<td class="tdRight">
	<asp:Literal ID="liteVisitCount" runat="server"></asp:Literal>
	</td>
</tr>
<tr>
	<td class="tdLeft">竞价货币数量:</td>
	<td class="tdRight"><asp:TextBox ID="txtCoins" runat="server" Width="40"></asp:TextBox> <span class="require">*</span> 
    <asp:RequiredFieldValidator ID="rfvCoins" runat="server" ErrorMessage="请填写正确,最小值为0" Display="Dynamic" ControlToValidate="txtCoins"></asp:RequiredFieldValidator> 
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="请填写正确,最小值为0" Display="Dynamic" ValidationExpression="\d+" ControlToValidate="txtCoins"></asp:RegularExpressionValidator>
	<div class="tips">(竞价货币数量越多,该关键字的搜索排名越靠前,每次按照关键字搜索后,将扣除对应该数值的货币数量)</div> 
	</td>
</tr>

<tr>
	<td class="tdLeft"></td>
	<td class="tdRight">
	  <asp:Button ID="btnSubmit" runat="server" Text="设定" onclick="btnSubmit_Click" />
	</td>
</tr>
</table>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>

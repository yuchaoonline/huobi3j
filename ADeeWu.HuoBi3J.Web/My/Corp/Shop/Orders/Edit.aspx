<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Edit.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.Orders.Edit" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
商家控制面板 - 客户订单处理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
.item{ margin-bottom:20px; }
.item-title{ font-weight:bold; border-bottom:1px dotted #ccc; margin-bottom:10px; height:24px; line-height:24px;  }
</style>
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">　</span><a href="/My/Corp/Shop/">在线营销</a><span class="spl">　</span><a href="/My/Corp/Shop/Orders/">客户订单管理</a><span class="spl">　</span><span class="curPos">订单处理</span> 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
<div class="item">
	<div class="item-title">订单信息</div>
	<table class="formTable">
		<tr>
			<td class="tdLeft">
				订 单 号：
			</td>
			<td class="tdRight">
				<asp:Label ID="lblOrderCode" runat="server" />
			</td>
		</tr>
		<tr>
			<td class="tdLeft">
				下单时间：
			</td>
			<td class="tdRight">
				<asp:Label ID="lblOrderTime" runat="server" />
			</td>
		</tr>
		<tr>
			<td class="tdLeft">
				消 费 者：
			</td>
			<td class="tdRight">
				(UIN)<asp:Label ID="lblBuyerUIN" runat="server" /> (帐号)<asp:Label ID="lblBuyerLoginName" runat="server" /> 
			</td>
		</tr>
		<tr>
			<td class="tdLeft">
				小　　计：
			</td>
			<td class="tdRight">
				<asp:Label ID="lblSubTotal" runat="server"></asp:Label>元
			</td>
		</tr>
		<tr>
			<td class="tdLeft">
				运　　费：
			</td>
			<td class="tdRight">
				<asp:Label ID="lblFreight" runat="server"></asp:Label>元
			</td>
		</tr>
		<tr>
			<td class="tdLeft">
				共　　计：
			</td>
			<td class="tdRight">
				<asp:Label ID="lblTotal" runat="server"></asp:Label>元
			</td>
		</tr>
		<tr>
			<td class="tdLeft">
				已 付 款：
			</td>
			<td class="tdRight">
				<asp:Literal ID="liteHasPaid" runat="server"></asp:Literal>
				<div class="tips">
				注意：<br />
				<strong>等待消费者确认收货后</strong> 或 <strong>在发货后并且消费者还没有确认收货的半个月后</strong>
				<br />
				系统将会自动将购物付款划款到您的帐户上
				</div>
			</td>
		</tr>
		<tr>
			<td class="tdLeft">
				订单状态：
			</td>
			<td class="tdRight">
				<asp:Literal ID="liteOrderState" runat="server"></asp:Literal>
				<asp:Button ID="btnProcess" runat="server" Text="现在开始处理(发货处理)" 
					onclick="btnProcess_Click" />
					
					<asp:PlaceHolder ID="ph01" runat="server" Visible="false">
					
					<div>
					发货日期：<IscControl:DateTimeSelector ID="txtDeliveryTime" runat="server" width="80"></IscControl:DateTimeSelector><span class="require">*</span>
						<asp:RequiredFieldValidator ID="rfvDeliveryTime" runat="server" Display="Dynamic" ControlToValidate="txtDeliveryTime" ErrorMessage="请填写发货日期！"></asp:RequiredFieldValidator>
					<asp:Button ID="btnDelivery" runat="server" Text="已发货" OnClick="btnDelivery_Click" />
					</div>
					
					</asp:PlaceHolder>
					
					 <asp:PlaceHolder ID="ph02" runat="server" Visible="false">
					[<a href="../Vouchers/New.aspx?UIN=<%=this.lblBuyerUIN.Text %>&orderCode=<%=this.lblOrderCode.Text %>">为该消费者填写电子凭证</a>]
					</asp:PlaceHolder>
				
			</td>
		</tr>
	</table>
</div>

<div class="item">
	<div class="item-title">送货信息</div>
	<table class="formTable">
	<tr>
		<td class="tdLeft">
			收 货 人：
		</td>
		<td class="tdRight">
			<asp:Label ID="lblReceiver" runat="server" CssClass="txtBox" ReadOnly="true" />
		</td>
	</tr>
	
	<tr>
		<td class="tdLeft">
			送货方式：
		</td>
		<td class="tdRight">
			<asp:Label ID="lblDeliveryType" runat="server"  />
		</td>
	</tr>
	<tr>
		<td class="tdLeft">
			详细地址：
		</td>
		<td class="tdRight">
			<asp:Label ID="lblDeilveryAddress" runat="server"  />
		</td>
	</tr>
	<tr>
		<td class="tdLeft">
			邮　　编：
		</td>
		<td class="tdRight">
			<asp:Label ID="lblZip" runat="server"  />
		</td>
	</tr>
	<tr>
		<td class="tdLeft">
			备　　注：
		</td>
		<td class="tdRight">
			<asp:Label ID="lblNote" runat="server" />
		</td>
	</tr>
</table>
</div>

<div class="item">
	<div class="item-title">送货信息</div>
	
<asp:GridView ID="gvData" runat="server" CssClass="gridView" 
        SkinID="userGridViewSkin" AutoGenerateColumns="False">
	<Columns>
	    <asp:TemplateField HeaderText="图片" >
			<ItemTemplate>
				<a href="/Shop/Products/View.aspx?id=<%#Eval("ProductID") %>" target="_blank">
				<img src="<%#Eval("Picture0") %>" onload="isc.util.zoomImg(this,120,120);" border="0" />
				</a> 
			</ItemTemplate>
		</asp:TemplateField>
		<asp:TemplateField HeaderText="产品名称" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" >
			<ItemTemplate>
				<a href="/Shop/Products/View.aspx?id=<%#Eval("ProductID") %>"  target="_blank"><%# Eval("ProductName") %></a> 
			</ItemTemplate>
		</asp:TemplateField>
		
		<asp:BoundField DataField="Quantity" HeaderText="数量"  HeaderStyle-CssClass="col_money" ItemStyle-CssClass="col_money" />
		<asp:BoundField DataField="NowPrice" HeaderText="时价(元)" HeaderStyle-CssClass="col_money" ItemStyle-CssClass="col_money" />
		<asp:TemplateField HeaderText="售后处理" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option" >
			<ItemTemplate>			
				<a href="AfterSaleRecords/?orderDetailID=<%#Eval("ID") %>">查看</a> | <a href="AfterSaleRecords/New.aspx?orderDetailID=<%#Eval("ID") %>">添加</a>
			</ItemTemplate>
		</asp:TemplateField>
	</Columns>
</asp:GridView>

</div>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>

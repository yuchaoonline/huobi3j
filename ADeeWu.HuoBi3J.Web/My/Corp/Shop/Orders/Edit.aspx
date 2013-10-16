<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Edit.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.Orders.Edit" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
�̼ҿ������ - �ͻ���������
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
.item{ margin-bottom:20px; }
.item-title{ font-weight:bold; border-bottom:1px dotted #ccc; margin-bottom:10px; height:24px; line-height:24px;  }
</style>
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">��</span><a href="/My/Corp/Shop/">����Ӫ��</a><span class="spl">��</span><a href="/My/Corp/Shop/Orders/">�ͻ���������</a><span class="spl">��</span><span class="curPos">��������</span> 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
<div class="item">
	<div class="item-title">������Ϣ</div>
	<table class="formTable">
		<tr>
			<td class="tdLeft">
				�� �� �ţ�
			</td>
			<td class="tdRight">
				<asp:Label ID="lblOrderCode" runat="server" />
			</td>
		</tr>
		<tr>
			<td class="tdLeft">
				�µ�ʱ�䣺
			</td>
			<td class="tdRight">
				<asp:Label ID="lblOrderTime" runat="server" />
			</td>
		</tr>
		<tr>
			<td class="tdLeft">
				�� �� �ߣ�
			</td>
			<td class="tdRight">
				(UIN)<asp:Label ID="lblBuyerUIN" runat="server" /> (�ʺ�)<asp:Label ID="lblBuyerLoginName" runat="server" /> 
			</td>
		</tr>
		<tr>
			<td class="tdLeft">
				С�����ƣ�
			</td>
			<td class="tdRight">
				<asp:Label ID="lblSubTotal" runat="server"></asp:Label>Ԫ
			</td>
		</tr>
		<tr>
			<td class="tdLeft">
				�ˡ����ѣ�
			</td>
			<td class="tdRight">
				<asp:Label ID="lblFreight" runat="server"></asp:Label>Ԫ
			</td>
		</tr>
		<tr>
			<td class="tdLeft">
				�������ƣ�
			</td>
			<td class="tdRight">
				<asp:Label ID="lblTotal" runat="server"></asp:Label>Ԫ
			</td>
		</tr>
		<tr>
			<td class="tdLeft">
				�� �� �
			</td>
			<td class="tdRight">
				<asp:Literal ID="liteHasPaid" runat="server"></asp:Literal>
				<div class="tips">
				ע�⣺<br />
				<strong>�ȴ�������ȷ���ջ���</strong> �� <strong>�ڷ������������߻�û��ȷ���ջ��İ���º�</strong>
				<br />
				ϵͳ�����Զ������︶�������ʻ���
				</div>
			</td>
		</tr>
		<tr>
			<td class="tdLeft">
				����״̬��
			</td>
			<td class="tdRight">
				<asp:Literal ID="liteOrderState" runat="server"></asp:Literal>
				<asp:Button ID="btnProcess" runat="server" Text="���ڿ�ʼ����(��������)" 
					onclick="btnProcess_Click" />
					
					<asp:PlaceHolder ID="ph01" runat="server" Visible="false">
					
					<div>
					�������ڣ�<IscControl:DateTimeSelector ID="txtDeliveryTime" runat="server" width="80"></IscControl:DateTimeSelector><span class="require">*</span>
						<asp:RequiredFieldValidator ID="rfvDeliveryTime" runat="server" Display="Dynamic" ControlToValidate="txtDeliveryTime" ErrorMessage="����д�������ڣ�"></asp:RequiredFieldValidator>
					<asp:Button ID="btnDelivery" runat="server" Text="�ѷ���" OnClick="btnDelivery_Click" />
					</div>
					
					</asp:PlaceHolder>
					
					 <asp:PlaceHolder ID="ph02" runat="server" Visible="false">
					[<a href="../Vouchers/New.aspx?UIN=<%=this.lblBuyerUIN.Text %>&orderCode=<%=this.lblOrderCode.Text %>">Ϊ����������д����ƾ֤</a>]
					</asp:PlaceHolder>
				
			</td>
		</tr>
	</table>
</div>

<div class="item">
	<div class="item-title">�ͻ���Ϣ</div>
	<table class="formTable">
	<tr>
		<td class="tdLeft">
			�� �� �ˣ�
		</td>
		<td class="tdRight">
			<asp:Label ID="lblReceiver" runat="server" CssClass="txtBox" ReadOnly="true" />
		</td>
	</tr>
	
	<tr>
		<td class="tdLeft">
			�ͻ���ʽ��
		</td>
		<td class="tdRight">
			<asp:Label ID="lblDeliveryType" runat="server"  />
		</td>
	</tr>
	<tr>
		<td class="tdLeft">
			��ϸ��ַ��
		</td>
		<td class="tdRight">
			<asp:Label ID="lblDeilveryAddress" runat="server"  />
		</td>
	</tr>
	<tr>
		<td class="tdLeft">
			�ʡ����ࣺ
		</td>
		<td class="tdRight">
			<asp:Label ID="lblZip" runat="server"  />
		</td>
	</tr>
	<tr>
		<td class="tdLeft">
			������ע��
		</td>
		<td class="tdRight">
			<asp:Label ID="lblNote" runat="server" />
		</td>
	</tr>
</table>
</div>

<div class="item">
	<div class="item-title">�ͻ���Ϣ</div>
	
<asp:GridView ID="gvData" runat="server" CssClass="gridView" 
        SkinID="userGridViewSkin" AutoGenerateColumns="False">
	<Columns>
	    <asp:TemplateField HeaderText="ͼƬ" >
			<ItemTemplate>
				<a href="/Shop/Products/View.aspx?id=<%#Eval("ProductID") %>" target="_blank">
				<img src="<%#Eval("Picture0") %>" onload="isc.util.zoomImg(this,120,120);" border="0" />
				</a> 
			</ItemTemplate>
		</asp:TemplateField>
		<asp:TemplateField HeaderText="��Ʒ����" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" >
			<ItemTemplate>
				<a href="/Shop/Products/View.aspx?id=<%#Eval("ProductID") %>"  target="_blank"><%# Eval("ProductName") %></a> 
			</ItemTemplate>
		</asp:TemplateField>
		
		<asp:BoundField DataField="Quantity" HeaderText="����"  HeaderStyle-CssClass="col_money" ItemStyle-CssClass="col_money" />
		<asp:BoundField DataField="NowPrice" HeaderText="ʱ��(Ԫ)" HeaderStyle-CssClass="col_money" ItemStyle-CssClass="col_money" />
		<asp:TemplateField HeaderText="�ۺ���" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option" >
			<ItemTemplate>			
				<a href="AfterSaleRecords/?orderDetailID=<%#Eval("ID") %>">�鿴</a> | <a href="AfterSaleRecords/New.aspx?orderDetailID=<%#Eval("ID") %>">���</a>
			</ItemTemplate>
		</asp:TemplateField>
	</Columns>
</asp:GridView>

</div>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>

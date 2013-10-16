<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.Orders.AfterSaleRecords.Default" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
商家控制面板 - 售后服务
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

    </asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">　</span><a href="/My/Corp/Shop/">在线营销</a><span class="spl">　</span><span class="curPos">售后服务</span> 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

<table class="searchTable">
	<tr>
	<td class="key" style="width: 80px">
		  订单号：
		</td>
		<td>
			<asp:TextBox ID="txtOrderCode" runat="server" Width="120px"/>
			
		</td>
		<td>
			 <asp:Button ID="btnSubmit" runat="server" Text="搜索" onclick="btnSubmit_Click" /> 
		</td>
	</tr>
</table>


                                    
<asp:GridView ID="gvData" runat="server" CssClass="gridView" SkinID="userGridViewSkin" AutoGenerateColumns="False">
<Columns>
<asp:TemplateField HeaderText="订单号">
<ItemTemplate>
    <a href="../Edit.aspx?orderid=<%#Eval("OrderID") %>"><%#Eval("OrderCode")%></a>
</ItemTemplate>
</asp:TemplateField> 

<asp:BoundField DataField="ProductName" HeaderText="产品名称" />
<asp:BoundField DataField="CreateTime" HeaderText="发布日期" />
<%--<asp:BoundField DataField="ModifyTime" HeaderText="更新日期" />--%>
<asp:TemplateField HeaderText="处理结果">
<ItemTemplate>
    <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
    Eval("ReSult").ToString(),
    new string[][]{
        new string[]{"0","无处理"},
        new string[]{"1","退货"},
        new string[]{"2","换货"},
        new string[]{"3","维修"}
    }               
    )
    %>
</ItemTemplate>
</asp:TemplateField> 

<asp:TemplateField HeaderText ="操作">
<ItemTemplate>

<a href='Edit.aspx?id=<%# Eval("id") %>'>修改</a>

<%--<a href='View.aspx?orderDetailID=<%# Eval("OrderDetailID") %>'>查看详细</a>--%>

</ItemTemplate>

</asp:TemplateField>
</Columns>
</asp:GridView>

 <div class="pager">
    <IscControl:Pager ID="Pager1" runat="server"  />
</div>

<%if (orderDetailID > 0)
      { %>
 <a href="New.aspx?orderDetailID=<%=orderDetailID %>"><b>添加处理结果</b></a>               
 <%}
      else
      { %>
     添加售后服务记录，请按照以下顺序操作:<b>1.<a href="../" target="_blank">查找订单</a></b> &gt; <b>2.查看明细</b> &gt; <b>3.找到对应商品的明细记录</b> &gt; <b>4.添加</b>
 <%} %>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>


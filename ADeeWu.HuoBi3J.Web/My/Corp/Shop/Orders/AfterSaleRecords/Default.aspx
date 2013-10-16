<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.Orders.AfterSaleRecords.Default" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
�̼ҿ������ - �ۺ����
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

    </asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">��</span><a href="/My/Corp/Shop/">����Ӫ��</a><span class="spl">��</span><span class="curPos">�ۺ����</span> 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

<table class="searchTable">
	<tr>
	<td class="key" style="width: 80px">
		  �����ţ�
		</td>
		<td>
			<asp:TextBox ID="txtOrderCode" runat="server" Width="120px"/>
			
		</td>
		<td>
			 <asp:Button ID="btnSubmit" runat="server" Text="����" onclick="btnSubmit_Click" /> 
		</td>
	</tr>
</table>


                                    
<asp:GridView ID="gvData" runat="server" CssClass="gridView" SkinID="userGridViewSkin" AutoGenerateColumns="False">
<Columns>
<asp:TemplateField HeaderText="������">
<ItemTemplate>
    <a href="../Edit.aspx?orderid=<%#Eval("OrderID") %>"><%#Eval("OrderCode")%></a>
</ItemTemplate>
</asp:TemplateField> 

<asp:BoundField DataField="ProductName" HeaderText="��Ʒ����" />
<asp:BoundField DataField="CreateTime" HeaderText="��������" />
<%--<asp:BoundField DataField="ModifyTime" HeaderText="��������" />--%>
<asp:TemplateField HeaderText="������">
<ItemTemplate>
    <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
    Eval("ReSult").ToString(),
    new string[][]{
        new string[]{"0","�޴���"},
        new string[]{"1","�˻�"},
        new string[]{"2","����"},
        new string[]{"3","ά��"}
    }               
    )
    %>
</ItemTemplate>
</asp:TemplateField> 

<asp:TemplateField HeaderText ="����">
<ItemTemplate>

<a href='Edit.aspx?id=<%# Eval("id") %>'>�޸�</a>

<%--<a href='View.aspx?orderDetailID=<%# Eval("OrderDetailID") %>'>�鿴��ϸ</a>--%>

</ItemTemplate>

</asp:TemplateField>
</Columns>
</asp:GridView>

 <div class="pager">
    <IscControl:Pager ID="Pager1" runat="server"  />
</div>

<%if (orderDetailID > 0)
      { %>
 <a href="New.aspx?orderDetailID=<%=orderDetailID %>"><b>��Ӵ�����</b></a>               
 <%}
      else
      { %>
     ����ۺ�����¼���밴������˳�����:<b>1.<a href="../" target="_blank">���Ҷ���</a></b> &gt; <b>2.�鿴��ϸ</b> &gt; <b>3.�ҵ���Ӧ��Ʒ����ϸ��¼</b> &gt; <b>4.���</b>
 <%} %>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>


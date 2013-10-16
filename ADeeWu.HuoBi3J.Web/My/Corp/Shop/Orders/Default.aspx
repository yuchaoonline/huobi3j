<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.Orders.Default" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
�̼ҿ������ - �ͻ�����
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

    </asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">��</span><a href="/My/Corp/Shop/">����Ӫ��</a><span class="spl">��</span><span class="curPos">�ͻ���������</span> 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

<table class="searchTable">
    <tr>
    <td class="key">
           �����ţ�
        </td>
        <td>
            <asp:TextBox ID="txtOrderCode" runat="server" Width="120px"/>
            
        </td>
        <td class="key">
            ����״̬��
        </td>
        <td  class="input">
            <asp:DropDownList ID="ddlOrderState" runat="server">
                <asp:ListItem Value="-1" Text="ȫ��" Selected="True"></asp:ListItem>
                <asp:ListItem Value="0" Text="δ����"></asp:ListItem>
                <asp:ListItem Value="1" Text="������"></asp:ListItem>
                <asp:ListItem Value="2" Text="�ѷ���"></asp:ListItem>
                <asp:ListItem Value="3" Text="���"></asp:ListItem>
            </asp:DropDownList>
        </td>
        <td  class="input"><asp:Button ID="btnSubmit" runat="server" Text="����" 
                onclick="btnSubmit_Click" /></td>
    </tr>
</table>
                
                                    
<asp:GridView ID="gvData" runat="server" CssClass="gridView" SkinID="userGridViewSkin" AutoGenerateColumns="False">
<Columns>
<asp:BoundField DataField="OrderCode" HeaderText="������" />
<asp:TemplateField HeaderText="������UIN">
<ItemTemplate>
    <div><%#Eval("BuyerUIN") %></div>
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="CreateTime" HeaderText="�µ�ʱ��" />
<asp:TemplateField HeaderText="����">
<ItemTemplate>
    <%#Eval("ProvinceName") %> <%#Eval("CityName") %> <%#Eval("AreaName") %>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="�ܽ��(���˷�)">
<ItemTemplate>
    <%# string.Format("{0:0.00}", (decimal)Eval("SubTotal") + (decimal)Eval("Freight"))%>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="�Ѹ���">
<ItemTemplate>
    <%#(bool)Eval("HasPaid") ? "<span style='color:red'>��</span>" : "��"%>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="����״̬">
<ItemTemplate>
    <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
    Eval("OrderState").ToString(),
    new string[][]{
        new string[]{"0","<font color='red'>δ����</font>"},
        new string[]{"1","������"},
        new string[]{"2","�ѷ���"},
        new string[]{"3","���"}
    }               
    )
    %>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="����">
<ItemTemplate>
<a href='Edit.aspx?orderid=<%# Eval("Id") %>'>�鿴</a>
</ItemTemplate>
</asp:TemplateField>
</Columns>
</asp:GridView>



<div class="pager">
    <IscControl:Pager ID="Pager1" runat="server" />
</div>
                    </asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>


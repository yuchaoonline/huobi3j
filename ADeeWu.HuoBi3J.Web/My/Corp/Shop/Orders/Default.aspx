<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.Orders.Default" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
商家控制面板 - 客户订单
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

    </asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">　</span><a href="/My/Corp/Shop/">在线营销</a><span class="spl">　</span><span class="curPos">客户订单管理</span> 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

<table class="searchTable">
    <tr>
    <td class="key">
           订单号：
        </td>
        <td>
            <asp:TextBox ID="txtOrderCode" runat="server" Width="120px"/>
            
        </td>
        <td class="key">
            订单状态：
        </td>
        <td  class="input">
            <asp:DropDownList ID="ddlOrderState" runat="server">
                <asp:ListItem Value="-1" Text="全部" Selected="True"></asp:ListItem>
                <asp:ListItem Value="0" Text="未处理"></asp:ListItem>
                <asp:ListItem Value="1" Text="处理中"></asp:ListItem>
                <asp:ListItem Value="2" Text="已发货"></asp:ListItem>
                <asp:ListItem Value="3" Text="完成"></asp:ListItem>
            </asp:DropDownList>
        </td>
        <td  class="input"><asp:Button ID="btnSubmit" runat="server" Text="搜索" 
                onclick="btnSubmit_Click" /></td>
    </tr>
</table>
                
                                    
<asp:GridView ID="gvData" runat="server" CssClass="gridView" SkinID="userGridViewSkin" AutoGenerateColumns="False">
<Columns>
<asp:BoundField DataField="OrderCode" HeaderText="订单号" />
<asp:TemplateField HeaderText="消费者UIN">
<ItemTemplate>
    <div><%#Eval("BuyerUIN") %></div>
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="CreateTime" HeaderText="下单时间" />
<asp:TemplateField HeaderText="地区">
<ItemTemplate>
    <%#Eval("ProvinceName") %> <%#Eval("CityName") %> <%#Eval("AreaName") %>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="总金额(含运费)">
<ItemTemplate>
    <%# string.Format("{0:0.00}", (decimal)Eval("SubTotal") + (decimal)Eval("Freight"))%>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="已付款">
<ItemTemplate>
    <%#(bool)Eval("HasPaid") ? "<span style='color:red'>是</span>" : "否"%>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="订单状态">
<ItemTemplate>
    <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
    Eval("OrderState").ToString(),
    new string[][]{
        new string[]{"0","<font color='red'>未处理</font>"},
        new string[]{"1","处理中"},
        new string[]{"2","已发货"},
        new string[]{"3","完成"}
    }               
    )
    %>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="操作">
<ItemTemplate>
<a href='Edit.aspx?orderid=<%# Eval("Id") %>'>查看</a>
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


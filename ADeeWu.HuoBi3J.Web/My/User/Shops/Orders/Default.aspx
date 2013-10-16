<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Shops.Orders.Default" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    个人控制面板 - 我的购物订单
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <span class="spl"></span><span class="curPos">我的购物订单</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <table class="searchTable">
        <tr>
            <td class="key" style="width: 80px">订单号：
            </td>
            <td>
                <asp:TextBox ID="txtOrderCode" runat="server" Width="120px" />

            </td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" Text="搜索"
                    OnClick="btnSubmit_Click" />
            </td>
        </tr>
    </table>


    <asp:GridView ID="gvData" runat="server" CssClass="gridView" SkinID="userGridViewSkin" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="OrderCode" HeaderText="订单号" />


            <asp:TemplateField HeaderText="小计(元) ">
                <ItemTemplate>
                    <strong><%# string.Format("{0:0.00}", (decimal)Eval("SubTotal"))%></strong>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="运费(元) ">
                <ItemTemplate>
                    (<%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
		Eval("DeliveryType").ToString(),
		new string[][]{
			new string[]{"0","到代理店取货"},
			new string[]{"1","平邮"},
			new string[]{"2","快递"},
			new string[]{"3","EMS"}
		}               
		)			
                    %>)<strong><%# string.Format("{0:0.00}", (decimal)Eval("Freight"))%>元</strong>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="共计(元) ">
                <ItemTemplate>
                    <strong><%# string.Format("{0:0.00}", (decimal)Eval("SubTotal") + (decimal)Eval("Freight"))%></strong>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="已付款">
                <ItemTemplate>
                    <%#(bool)Eval("HasPaid") ? "是" : "否" %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="订单状态">
                <ItemTemplate>
                    <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
Eval("OrderState").ToString(),
new string[][]{
	new string[]{"0","未处理"},
	new string[]{"1","<span style='color:red;'>处理中</span>"},
	new string[]{"2","<span style='color:red;'>已发货</span>"},
	new string[]{"3","完成"}
}               
)
                    %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="CreateTime" HeaderText="日期" />
            <asp:TemplateField HeaderText="操作">
                <ItemTemplate>
                    <a href='View.aspx?id=<%# Eval("Id") %>'>查看详细</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>


    <div class="pager">
        <IscControl:Pager ID="Pager1" runat="server" />
    </div>

</asp:Content>

<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Shops.Orders.View" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    个人控制面板 - 查看购物订单
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .item {
            margin-bottom: 20px;
        }

        .item-title {
            font-weight: bold;
            border-bottom: 1px dotted #ccc;
            margin-bottom: 10px;
            height: 24px;
            line-height: 24px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <span class="spl"></span><a href="/My/User/Shops/Orders/">我的购物订单</a><span class="spl">　</span><span class="curPos">查看订单</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <%if (this.drData != null)
      { %>
    <div class="item">
        <div class="item-title">订单信息</div>
        <table class="formTable">
            <tr>
                <td class="tdLeft">订 单 号：
                </td>
                <td class="tdRight">
                    <asp:Label ID="lblOrderCode" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tdLeft">商　　家：
                </td>
                <td class="tdRight">
                    <asp:Label ID="lblCorpName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tdLeft">下单时间：
                </td>
                <td class="tdRight">
                    <asp:Label ID="lblOrderTime" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tdLeft">计　　算：
                </td>
                <td class="tdRight">(小计)<asp:Label ID="lblSubTotal" runat="server"></asp:Label>元 + (运费)<asp:Label ID="lblFreight" runat="server"></asp:Label>元 =
                    <asp:Label ID="lblTotal" runat="server" Font-Bold="true"></asp:Label>元
                </td>
            </tr>
            <tr>
                <td class="tdLeft">已 付 款：
                </td>
                <td class="tdRight">
                    <%if ((bool)this.drData["HasPaid"])
                      { %>
                    是
				<%}
                      else
                      { %>
                    <a href="Pay.aspx?ID=<%=this.drData["ID"] %>">现在去付款</a>
                    <%} %>
                </td>
            </tr>
            <tr>
                <td class="tdLeft">当前状态：
                </td>
                <td class="tdRight">
                    <%
      int orderState = ADeeWu.HuoBi3J.Libary.Utility.GetInt(this.drData["OrderState"], 0);
                    %>
                    <%if (orderState == 2)
                      {%>
	        商家已在 <b><%=string.Format("{0:yyyy-MM-dd dddd}", this.drData["DeliveryTime"])%></b> 发货
                <asp:Button ID="btnConfirmReceiveGoods" runat="server" Text="确认收货,完成本次的购物"
                    OnClick="btnConfirmReceiveGoods_Click" />

                    <%}
                      else
                      { %>

                    <%= ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                   this.drData["OrderState"].ToString(),
                   new string[,]{
                        {"0"," 未处理"},
                        {"1","处理中"},
                        {"2","已发货"}, 
                        {"3","完成"}
                    }
                   )
                    %>

                    <%} %>
			
			    
                </td>
            </tr>
        </table>
    </div>

    <div class="item">
        <div class="item-title">送货信息</div>
        <table class="formTable">
            <tr>
                <td class="tdLeft">收 货 人：
                </td>
                <td class="tdRight">
                    <asp:Label ID="lblReceiver" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tdLeft">送货地址：
                </td>
                <td class="tdRight">
                    <asp:Label ID="lblAddress" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="tdLeft">邮政编码：
                </td>
                <td class="tdRight">
                    <asp:Label ID="lblZip" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tdLeft">送货方式：
                </td>
                <td class="tdRight">
                    <asp:Label ID="lblDeliveryType" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="tdLeft">联系电话：
                </td>
                <td class="tdRight">
                    <asp:Label ID="lblTelephone" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tdLeft">备　　注：
                </td>
                <td class="tdRight">
                    <asp:Label ID="lblNote" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>

    <div class="item">

        <div class="item-title">订单明细</div>

        <asp:GridView ID="gvData" runat="server" CssClass="gridView" SkinID="userGridViewSkin" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderText="图片">
                    <ItemTemplate>
                        <a href="/Shop/Products/View.aspx?id = <%#Eval("ProductID") %>">
                            <img src="<%# Eval("Picture0") %>" onload="isc.util.zoomImg(this,120,120);" border="0" /></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="CorpName" HeaderText="商家名称" />
                <asp:TemplateField HeaderText="产品名称">
                    <ItemTemplate>
                        <a href="/Shop/Products/View.aspx?id=<%#Eval("ProductID") %>">
                            <%# Eval("ProductName") %></a>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="Quantity" HeaderText="数量" />
                <asp:BoundField DataField="NowPrice" HeaderText="时价(元)" />
                <asp:TemplateField HeaderText="售后服务" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option">
                    <ItemTemplate>
                        <a href="AfterSaleRecords/?orderDetailID=<%#Eval("ID") %>">查看</a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>


    <%} %>
</asp:Content>

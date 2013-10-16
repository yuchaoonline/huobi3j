<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Shops.Orders.View" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    ���˿������ - �鿴���ﶩ��
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
    <span class="spl"></span><a href="/My/User/Shops/Orders/">�ҵĹ��ﶩ��</a><span class="spl">��</span><span class="curPos">�鿴����</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <%if (this.drData != null)
      { %>
    <div class="item">
        <div class="item-title">������Ϣ</div>
        <table class="formTable">
            <tr>
                <td class="tdLeft">�� �� �ţ�
                </td>
                <td class="tdRight">
                    <asp:Label ID="lblOrderCode" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tdLeft">�̡����ң�
                </td>
                <td class="tdRight">
                    <asp:Label ID="lblCorpName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tdLeft">�µ�ʱ�䣺
                </td>
                <td class="tdRight">
                    <asp:Label ID="lblOrderTime" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tdLeft">�ơ����㣺
                </td>
                <td class="tdRight">(С��)<asp:Label ID="lblSubTotal" runat="server"></asp:Label>Ԫ + (�˷�)<asp:Label ID="lblFreight" runat="server"></asp:Label>Ԫ =
                    <asp:Label ID="lblTotal" runat="server" Font-Bold="true"></asp:Label>Ԫ
                </td>
            </tr>
            <tr>
                <td class="tdLeft">�� �� �
                </td>
                <td class="tdRight">
                    <%if ((bool)this.drData["HasPaid"])
                      { %>
                    ��
				<%}
                      else
                      { %>
                    <a href="Pay.aspx?ID=<%=this.drData["ID"] %>">����ȥ����</a>
                    <%} %>
                </td>
            </tr>
            <tr>
                <td class="tdLeft">��ǰ״̬��
                </td>
                <td class="tdRight">
                    <%
      int orderState = ADeeWu.HuoBi3J.Libary.Utility.GetInt(this.drData["OrderState"], 0);
                    %>
                    <%if (orderState == 2)
                      {%>
	        �̼����� <b><%=string.Format("{0:yyyy-MM-dd dddd}", this.drData["DeliveryTime"])%></b> ����
                <asp:Button ID="btnConfirmReceiveGoods" runat="server" Text="ȷ���ջ�,��ɱ��εĹ���"
                    OnClick="btnConfirmReceiveGoods_Click" />

                    <%}
                      else
                      { %>

                    <%= ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                   this.drData["OrderState"].ToString(),
                   new string[,]{
                        {"0"," δ����"},
                        {"1","������"},
                        {"2","�ѷ���"}, 
                        {"3","���"}
                    }
                   )
                    %>

                    <%} %>
			
			    
                </td>
            </tr>
        </table>
    </div>

    <div class="item">
        <div class="item-title">�ͻ���Ϣ</div>
        <table class="formTable">
            <tr>
                <td class="tdLeft">�� �� �ˣ�
                </td>
                <td class="tdRight">
                    <asp:Label ID="lblReceiver" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tdLeft">�ͻ���ַ��
                </td>
                <td class="tdRight">
                    <asp:Label ID="lblAddress" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="tdLeft">�������룺
                </td>
                <td class="tdRight">
                    <asp:Label ID="lblZip" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tdLeft">�ͻ���ʽ��
                </td>
                <td class="tdRight">
                    <asp:Label ID="lblDeliveryType" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="tdLeft">��ϵ�绰��
                </td>
                <td class="tdRight">
                    <asp:Label ID="lblTelephone" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tdLeft">������ע��
                </td>
                <td class="tdRight">
                    <asp:Label ID="lblNote" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>

    <div class="item">

        <div class="item-title">������ϸ</div>

        <asp:GridView ID="gvData" runat="server" CssClass="gridView" SkinID="userGridViewSkin" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderText="ͼƬ">
                    <ItemTemplate>
                        <a href="/Shop/Products/View.aspx?id = <%#Eval("ProductID") %>">
                            <img src="<%# Eval("Picture0") %>" onload="isc.util.zoomImg(this,120,120);" border="0" /></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="CorpName" HeaderText="�̼�����" />
                <asp:TemplateField HeaderText="��Ʒ����">
                    <ItemTemplate>
                        <a href="/Shop/Products/View.aspx?id=<%#Eval("ProductID") %>">
                            <%# Eval("ProductName") %></a>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="Quantity" HeaderText="����" />
                <asp:BoundField DataField="NowPrice" HeaderText="ʱ��(Ԫ)" />
                <asp:TemplateField HeaderText="�ۺ����" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option">
                    <ItemTemplate>
                        <a href="AfterSaleRecords/?orderDetailID=<%#Eval("ID") %>">�鿴</a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>


    <%} %>
</asp:Content>

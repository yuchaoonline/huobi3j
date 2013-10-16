<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Shops.Orders.Default" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    ���˿������ - �ҵĹ��ﶩ��
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <span class="spl"></span><span class="curPos">�ҵĹ��ﶩ��</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <table class="searchTable">
        <tr>
            <td class="key" style="width: 80px">�����ţ�
            </td>
            <td>
                <asp:TextBox ID="txtOrderCode" runat="server" Width="120px" />

            </td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" Text="����"
                    OnClick="btnSubmit_Click" />
            </td>
        </tr>
    </table>


    <asp:GridView ID="gvData" runat="server" CssClass="gridView" SkinID="userGridViewSkin" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="OrderCode" HeaderText="������" />


            <asp:TemplateField HeaderText="С��(Ԫ) ">
                <ItemTemplate>
                    <strong><%# string.Format("{0:0.00}", (decimal)Eval("SubTotal"))%></strong>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="�˷�(Ԫ) ">
                <ItemTemplate>
                    (<%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
		Eval("DeliveryType").ToString(),
		new string[][]{
			new string[]{"0","�������ȡ��"},
			new string[]{"1","ƽ��"},
			new string[]{"2","���"},
			new string[]{"3","EMS"}
		}               
		)			
                    %>)<strong><%# string.Format("{0:0.00}", (decimal)Eval("Freight"))%>Ԫ</strong>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="����(Ԫ) ">
                <ItemTemplate>
                    <strong><%# string.Format("{0:0.00}", (decimal)Eval("SubTotal") + (decimal)Eval("Freight"))%></strong>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="�Ѹ���">
                <ItemTemplate>
                    <%#(bool)Eval("HasPaid") ? "��" : "��" %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="����״̬">
                <ItemTemplate>
                    <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
Eval("OrderState").ToString(),
new string[][]{
	new string[]{"0","δ����"},
	new string[]{"1","<span style='color:red;'>������</span>"},
	new string[]{"2","<span style='color:red;'>�ѷ���</span>"},
	new string[]{"3","���"}
}               
)
                    %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="CreateTime" HeaderText="����" />
            <asp:TemplateField HeaderText="����">
                <ItemTemplate>
                    <a href='View.aspx?id=<%# Eval("Id") %>'>�鿴��ϸ</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>


    <div class="pager">
        <IscControl:Pager ID="Pager1" runat="server" />
    </div>

</asp:Content>

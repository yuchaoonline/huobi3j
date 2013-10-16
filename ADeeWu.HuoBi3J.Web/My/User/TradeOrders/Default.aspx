<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.TradeOrders.Default" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    ���˿������ -���ҵĳ�ֵ����
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <span class="spl"></span><span class="curPos">�ҵĳ�ֵ����</span> | <a href="Order.aspx">���߳�ֵ</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <table class="searchTable">
        <tr>
            <td class="key">�����ţ�</td>
            <td class="input">
                <asp:TextBox ID="txtOrderCode" runat="server"></asp:TextBox>
            </td>
            <td class="key">����״̬��</td>
            <td class="input">
                <asp:DropDownList ID="ddlOrderState" runat="server">
                    <asp:ListItem Value="-1" Text="ȫ��"></asp:ListItem>
                    <asp:ListItem Value="0" Text="δ����"></asp:ListItem>
                    <asp:ListItem Value="1" Text="������"></asp:ListItem>
                    <asp:ListItem Value="2" Text="�����"></asp:ListItem>
                    <asp:ListItem Value="3" Text="��Ч"></asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="btnSubmit" runat="server" Text="����" OnClick="btnSubmit_Click" />
            </td>
        </tr>
    </table>



    <asp:GridView ID="gvData" runat="server" CssClass="gridView" SkinID="userGridViewSkin" AutoGenerateColumns="false" ShowFooter="false" ShowHeader="true">
        <Columns>
            <asp:TemplateField HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" HeaderText="������">
                <ItemTemplate>
                    <%#Eval("OrderCode") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="��ֵ���" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title">
                <ItemTemplate>
                    <%#Eval("TotalFee","{0:0.00}Ԫ")%>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField HeaderText="�µ�ʱ��" HeaderStyle-CssClass="col_datetime" ItemStyle-CssClass="col_datetime" DataField="CreateTime" />
            <asp:TemplateField HeaderText="��ǰ״̬" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option">
                <ItemTemplate>
                    <%#ADeeWu.HuoBi3J.Libary.WebUtility.Switch( Eval("OrderState").ToString(),
               new string[,]{
                   {"0",string.Format("<a href=\"PayNow.aspx?order={0}\" target=\"_blank\">��������</a>",Eval("OrderCode"))},
                   {"1","������"},
                   {"2","���"},
                   {"3","��Ч"}
               }
               )               
                    %>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>


    <div class="pager">
        <IscControl:Pager ID="Pager1" runat="server" />
    </div>

</asp:Content>




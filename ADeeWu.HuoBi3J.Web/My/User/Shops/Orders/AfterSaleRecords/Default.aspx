<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Shops.Orders.AfterSaleRecords.Default" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    ���˿������ - �ۺ�����¼
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <span class="spl"></span><span class="curPos">�ۺ�����¼</span>
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
                <asp:Button ID="btnSubmit" runat="server" Text="����" OnClick="btnSubmit_Click" />
            </td>
        </tr>
    </table>

    <asp:GridView ID="gvData" runat="server" CssClass="gridView" SkinID="userGridViewSkin" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="OrderCode" HeaderText="������" />
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
        </Columns>
    </asp:GridView>

    <div class="pager">
        <IscControl:Pager ID="Pager1" runat="server" />
    </div>

</asp:Content>

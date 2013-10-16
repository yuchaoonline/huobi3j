<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.VMoney.Default" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    ���˿������ -���ʻ���ϸ��¼
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <span class="spl"></span><span class="curPos">�ʻ���ϸ��¼</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <table class="searchTable">
        <tr>
            <td class="key">ɸѡ��</td>
            <td class="input">
                <asp:DropDownList ID="ddlState" runat="server">
                    <asp:ListItem Value="-1" Selected="True">ȫ��</asp:ListItem>
                    <asp:ListItem Value="0">��ֵ</asp:ListItem>
                    <asp:ListItem Value="1">�۷�</asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="btnSubmit" runat="server" Text="����" OnClick="btnSubmit_Click" />
            </td>
        </tr>
    </table>

    <asp:GridView ID="gvData" runat="server" CssClass="gridView" SkinID="userGridViewSkin" AutoGenerateColumns="false" ShowFooter="false" ShowHeader="true">
        <Columns>
            <asp:TemplateField HeaderStyle-CssClass="col_id" ItemStyle-CssClass="col_id" HeaderText="�к�">
                <ItemTemplate>
                    <%# (this.pageSize * (this.pageIndex - 1)) + Container.DataItemIndex + 1%>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField HeaderText="��ֵ" HeaderStyle-CssClass="col_money" ItemStyle-CssClass="col_money" DataField="InMoney" />
            <asp:BoundField HeaderText="�۷�" HeaderStyle-CssClass="col_money" ItemStyle-CssClass="col_money" DataField="OutMoney" />
            <asp:BoundField HeaderText="�ʺ����" HeaderStyle-CssClass="col_account" ItemStyle-CssClass="col_account" DataField="Balance" />
            <asp:BoundField HeaderText="��ע" HeaderStyle-CssClass="col_notes" ItemStyle-CssClass="col_notes" ItemStyle-Width="300" DataField="Notes" />
            <asp:BoundField HeaderText="ʱ��" HeaderStyle-CssClass="col_datetime" ItemStyle-CssClass="col_datetime" DataField="CreateTime" />
            <%-- <asp:TemplateField HeaderText="����" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option">
        <ItemTemplate>
            <a href="Edit.aspx?id=<%#Eval("ID") %>">�޸�</a> | <a href="Del.aspx?id=<%#Eval("ID") %>">ɾ��</a>
        </ItemTemplate>
    </asp:TemplateField>--%>
        </Columns>
    </asp:GridView>


    <div class="pager">
        <IscControl:Pager ID="Pager1" runat="server" />
    </div>

</asp:Content>




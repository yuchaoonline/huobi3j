<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="ProductList.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.Center.ProductList"  %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
�ޱ����ĵ�
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>��ʱ���۹���</span> &gt; ��Ʒ�б�
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <table id="resultList" class="gridView" width="100%">
        <asp:Repeater ID="rpResultList" runat="server">
            <HeaderTemplate>
                <tr>
                    <th>ID</th>
                    <th>��Ʒ����</th>
                    <th>���ʱ��</th>
                    <th>��������</th>
                    <th>����</th>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("id") %></td>
                    <td><%# Eval("name") %></td>
                    <td><%# Eval("createtime") %></td>
                    <td><%# bindCategory(Eval("categoryid"))%></td>
                    <td>
                        <a href="productlist.aspx?method=delete&id=<%# Eval("id") %>" title="ɾ��">ɾ��</a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>

    <div class="pager">
        <IscControl:Pager ID="Pager1" runat="server" />
    </div>
</asp:Content>


<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Income.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Center.KeManage.Income" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="ADeeWuControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    ȫ��Ӫ�� - ���˹������� - ��׼����
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <asp:HiddenField ID="hfKeywordID" runat="server" />
    <table id="resultList" class="gridView">
        <asp:Repeater ID="rpResultList" runat="server">
            <HeaderTemplate>
                <tr>
                    <th>�ؼ���</th>
                    <th>����</th>
                    <th>˵��</th>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# keyword %></td>
                    <td><%# Eval("Price") %></td>
                    <td><%# Eval("Remark") %></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <div class="pager">
        <ADeeWuControl:Pager ID="Pager1" runat="server" />
    </div>
</asp:Content>


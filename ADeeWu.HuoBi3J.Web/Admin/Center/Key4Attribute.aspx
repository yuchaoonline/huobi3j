<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MAdmin.Master" AutoEventWireup="true" CodeBehind="Key4Attribute.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.Center.Key4Attribute" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="ADeeWuControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <table class="searchTable">
        <tr>
            <td class="key">关键字：</td>
            <td class="input">
                <asp:TextBox ID="txtKey" runat="server"></asp:TextBox>
            </td>
            <td class="key">
                <asp:Button ID="btnSubmit" Text="搜索" runat="server" OnClick="btnSubmit_Click" />
            </td>
        </tr>
    </table>

    <table id="resultList" class="gridView" width="100%">
        <asp:Repeater ID="rpResultList" runat="server">
            <HeaderTemplate>
                <tr>
                    <th>关键字</th>
                    <th>操作</th>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("name") %></td>
                    <td>
                        <a href="addattribute.aspx?kid=<%#Eval("KID") %>">属性</a>
                        <a href="ViewClick.aspx?kid=<%#Eval("KID") %>">点击</a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>

    <div class="pager">
        <ADeeWuControl:Pager ID="Pager1" runat="server" />
    </div>
</asp:Content>

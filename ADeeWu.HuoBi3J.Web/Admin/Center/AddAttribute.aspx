<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MAdmin.Master" AutoEventWireup="true" CodeBehind="AddAttribute.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.Center.AddAttribute" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <table border="0" cellspacing="0" cellpadding="0" class="formTable">
        <tr>
            <td class="tdLeft">关键字：</td>
            <td class="tdRight">
                <asp:Literal ID="litKeyname" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">类型:</td>
            <td class="tdRight">
                <asp:DropDownList ID="ddlType" runat="server">
                    <asp:ListItem Value="SelectType">类型</asp:ListItem>
                    <asp:ListItem Value="SelectPrice">价格</asp:ListItem>
                    <asp:ListItem Value="SelectSize">其他</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">值:</td>
            <td class="tdRight">
                <asp:TextBox ID="txtValue" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">&nbsp;</td>
            <td class="tdRight">
                <asp:Button ID="btnSubmit" runat="server" Text="提交" OnClick="btnSubmit_OnClick" />
            </td>
        </tr>
    </table>

    <table id="resultList" class="gridView" width="100%">
        <asp:Repeater ID="rpResultList" runat="server">
            <HeaderTemplate>
                <tr>
                    <th>类型</th>
                    <th>值</th>
                    <th>操作</th>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# ConvertType(Eval("DataType")) %></td>
                    <td><%# Eval("DataValue") %></td>
                    <td><a href="addattribute.aspx?method=delete&id=<%#Eval("ID") %>&kid=<%#Eval("kid") %>">删除</a></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
</asp:Content>

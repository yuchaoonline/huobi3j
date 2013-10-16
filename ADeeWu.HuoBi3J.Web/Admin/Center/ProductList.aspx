<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="ProductList.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.Center.ProductList"  %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
无标题文档
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>即时报价管理</span> &gt; 商品列表
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <table id="resultList" class="gridView" width="100%">
        <asp:Repeater ID="rpResultList" runat="server">
            <HeaderTemplate>
                <tr>
                    <th>ID</th>
                    <th>商品名称</th>
                    <th>添加时间</th>
                    <th>所属分类</th>
                    <th>操作</th>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("id") %></td>
                    <td><%# Eval("name") %></td>
                    <td><%# Eval("createtime") %></td>
                    <td><%# bindCategory(Eval("categoryid"))%></td>
                    <td>
                        <a href="productlist.aspx?method=delete&id=<%# Eval("id") %>" title="删除">删除</a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>

    <div class="pager">
        <IscControl:Pager ID="Pager1" runat="server" />
    </div>
</asp:Content>


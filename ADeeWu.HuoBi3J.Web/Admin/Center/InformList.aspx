<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="InformList.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.Center.InformList"  %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="ADeeWuControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
无标题文档
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>货比三家管理</span> &gt; 举报处理
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <table id="resultList" class="gridView" width="100%">
        <asp:Repeater ID="rpResultList" runat="server">
            <HeaderTemplate>
                <tr>
                    <th>ID</th>
                    <th>举报内容</th>
                    <th>举报类型</th>
                    <th>举报时间</th>
                    <th>操作</th>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("ID") %></td>
                    <td><%# this.GetContent(Eval("contentid"),Eval("informtype"))%></td>
                    <td><%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(Eval("informtype").ToString(),new string[][]{new string[]{"0","商圈"},new string[]{"1","关键字"},new string[]{"2","提问"},new string[]{"3","回复内容"}})%></td>
                    <td><%# Eval("CreateTime") %></td>
                    <td><a href="ProcessInform.aspx?id=<%#Eval("ID") %>">通过</a></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>

    <div class="pager">
        <ADeeWuControl:Pager ID="Pager1" runat="server" />
    </div>
</asp:Content>


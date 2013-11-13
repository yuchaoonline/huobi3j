<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Center.KeyManage.Default" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="ADeeWuControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    货比三家 - 个人管理中心 - 精准搜索
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <asp:GridView ID="gvData" runat="server" CssClass="gridView" SkinID="userGridViewSkin"
        AutoGenerateColumns="False" EnableModelValidation="True">
        <Columns>
            <asp:TemplateField HeaderText="关键字">
                <ItemTemplate>
                    <%# ADeeWu.HuoBi3J.Web.Class.Helper.GetKey(Eval("kid"), Eval("kname")) %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Price" HeaderText="价钱(元)" />
            <asp:BoundField DataField="CreatTime" HeaderText="添加时间" />
            <asp:TemplateField HeaderText="操作">
                <ItemTemplate>
                    <a href="Refresh.aspx?id=<%#Eval("kid")%>">刷新</a>|
                                    <a href="RefreshLog.aspx?id=<%#Eval("kid")%>&keyword=<%# Eval("kname") %>">刷新记录</a>
                    <a href="Income.aspx?id=<%#Eval("kid")%>&keyword=<%# Eval("kname") %>">收益</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div class="pager">
        <ADeeWuControl:Pager ID="Pager1" runat="server" />
    </div>

</asp:Content>


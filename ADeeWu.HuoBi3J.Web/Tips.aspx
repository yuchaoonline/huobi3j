<%@ Page Language="C#" Title="" MasterPageFile="~/MIndex.master" AutoEventWireup="true" CodeBehind="Tips.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Tips" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    <%=tips.Topic %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
    <h1><%=tips.Topic %></h1>
    <br />
    <br />
    <br />
    <div><%=tips.Summary %></div>
    <br />
    <br />
    <br />
    <div><a href="<%=tips.Url %>"><%=tips.UrlText %></a></div>
</asp:Content>

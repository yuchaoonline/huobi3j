<%@ Page Title="" Language="C#" MasterPageFile="~/MIndex.master" AutoEventWireup="true" CodeBehind="HotKey.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Center.HotKey" %>

<%@ Register Src="~/Controls/ucNav.ascx" TagPrefix="uc1" TagName="ucNav" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
    <uc1:ucNav runat="server" ID="ucNav" />
</asp:Content>

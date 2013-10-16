<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="GenerateJSData.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.Callings.GenerateJSData" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    无标题页
</head>
<body>
    <form id="form1" runat="server">
    <div>
   <asp:Repeater ID="rpDataLevel01" runat="server">
   <HeaderTemplate>var callingLevel01 = [</HeaderTemplate>
   <FooterTemplate>]</FooterTemplate>
    <ItemTemplate>[0,<%#Eval("ID") %>,"<%#Eval("Name") %>","0"],</ItemTemplate>
    </asp:Repeater>
    
    
    
    <asp:Repeater ID="rpDataLevel02" runat="server">
   <HeaderTemplate>var callingLevel02 = [</HeaderTemplate>
   <FooterTemplate>]</FooterTemplate>
    <ItemTemplate>[<%#Eval("ParentID") %>,<%#Eval("ID") %>,"<%#Eval("Name") %>","<%#Eval("ParentID") %>_<%#Eval("ID") %>"],</ItemTemplate>
    </asp:Repeater>
    
    
    </div>
    </form>
</body>


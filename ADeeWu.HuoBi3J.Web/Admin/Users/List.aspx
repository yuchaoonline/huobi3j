<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="List.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.Users.List"  %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="CashTicketControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
Admin - Users - List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>注册用户管理</span> &gt; 用户列表
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
<input type="hidden" name="page"  value="1" />
<table class="searchTable">
    <tr>
        <td class="key">UIN:</td>
        <td class="input">
            <input type="text" name="uin" id="uin" runat="server" class="txtBox" /> 
        </td>
        <td class="key">帐号:</td>
        <td class="input">
            <input type="text" name="loginName" id="loginName" runat="server" class="txtBox" /> 
        </td>
        <td class="key">姓名:</td>
        <td class="input">
            <input type="text" name="name" id="name" runat="server" class="txtBox" />
        </td>
        <td><input type="submit" value="搜索" /></td>
    </tr>
</table>

<asp:GridView ID="gvData" runat="server" CssClass="dataGrid" SkinID="gridviewSkin" AutoGenerateColumns="false" ShowFooter="false" BorderStyle="None"  ShowHeader="true">
<Columns>
    <asp:TemplateField HeaderStyle-CssClass="col_id"  ItemStyle-CssClass="col_id" HeaderText="ID">
        <ItemTemplate>
            <input type="checkbox" name="id" value="<%#Eval("ID") %>" /> <%#Eval("ID") %>
        </ItemTemplate>    
    </asp:TemplateField>
    <asp:BoundField HeaderText="UIN" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" DataField="UIN" />
    <asp:HyperLinkField HeaderText="帐号" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" DataNavigateUrlFields="id" DataNavigateUrlFormatString="Edit.aspx?id={0}" DataTextField="LoginName" />
    <asp:HyperLinkField HeaderText="姓名" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" DataNavigateUrlFields="id" DataNavigateUrlFormatString="Edit.aspx?id={0}" DataTextField="Name" />
    
    <asp:BoundField HeaderText="Email" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" DataField="Email" />
    <asp:BoundField HeaderText="上一次登陆" HeaderStyle-CssClass="col_datetime" ItemStyle-CssClass="col_datetime" DataField="LastLogin" HtmlEncode="true" DataFormatString="{0:d}" />
    <asp:BoundField HeaderText="注册时间" HeaderStyle-CssClass="col_datetime"  ItemStyle-CssClass="col_datetime" DataField="RegTime" HtmlEncode="true" DataFormatString="{0:d}" />
    <asp:BoundField HeaderText="登陆次数" HeaderStyle-CssClass="col_number"  ItemStyle-CssClass="col_number" DataField="LoginTimes"  />
    <asp:TemplateField HeaderText="操作" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option">
        <ItemTemplate>
            <a href="Edit.aspx?id=<%#Eval("ID") %>">修改</a> <%--| <a href="Del.aspx?id=<%#Eval("ID") %>">删除</a>--%>
        </ItemTemplate>
    </asp:TemplateField>
    
</Columns>
</asp:GridView>


<table width="100%" class="dataGrid_Footer">
    <tr>
        <td class="options">
         <!-- <a href="#" onclick="setCheckGroup('<% = gvData.ClientID %>',true); void(0);">全选</a> <a href="#" onclick="resverSelect('<% = gvData.ClientID %>'); void(0);">反选</a> -->
        </td>
        <td class="pagerBox">
            <CashTicketControl:Pager ID="Pager1" runat="server"  />
        </td>
    </tr>
</table>




</asp:Content>


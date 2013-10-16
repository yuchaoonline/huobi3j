<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="List.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.Coins.List"  %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="CashTicketControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
Admin - Users - List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>会员货币管理</span> &gt; 明细记录 | <a href="Add.aspx">添加货币</a> | <a href="Sub.aspx">扣除货币</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

<table class="searchTable">
    <tr>
        <td class="key">会员帐号:</td>
        <td class="input">
            <asp:TextBox ID="txtLoginName" runat="server" CssClass="txtBox"></asp:TextBox>
        </td>
        <td class="key">筛选:</td>
        <td class="input">
            <asp:DropDownList ID="ddlFilter" runat="server">
                <asp:ListItem Text="全部" Value="-1" Selected="True"></asp:ListItem>
                <asp:ListItem Text="添加货币" Value="0"></asp:ListItem>
                <asp:ListItem Text="扣除货币" Value="1"></asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="搜索" onclick="btnSearch_Click" />
        </td>
    </tr>
</table>

<asp:GridView ID="gvData" runat="server" CssClass="dataGrid" SkinID="gridviewSkin" AutoGenerateColumns="false" ShowFooter="false" BorderStyle="None"  ShowHeader="true">
<Columns>
    <asp:TemplateField HeaderStyle-CssClass="col_id"  ItemStyle-CssClass="col_id" HeaderText="ID">
        <ItemTemplate>
            <input type="checkbox" name="id" value="<%#Eval("ID") %>" /> <%#Eval("ID") %>
        </ItemTemplate>     
    </asp:TemplateField>
    
    <asp:HyperLinkField HeaderText="会员帐号" HeaderStyle-CssClass="col_account" ItemStyle-CssClass="col_account" DataNavigateUrlFields="UserID" DataNavigateUrlFormatString="../Users/Edit.aspx?id={0}" DataTextField="LoginName" />
    <asp:BoundField HeaderText="添加货币" HeaderStyle-CssClass="col_money" ItemStyle-CssClass="col_money" DataField="InCoin" />
    <asp:BoundField HeaderText="扣除货币" HeaderStyle-CssClass="col_money" ItemStyle-CssClass="col_money" DataField="OutCoin" />
    <asp:BoundField HeaderText="剩余货币" HeaderStyle-CssClass="col_account" ItemStyle-CssClass="col_account" DataField="Remain" />
    <asp:BoundField HeaderText="备注" HeaderStyle-CssClass="col_notes" ItemStyle-CssClass="col_notes"  DataField="Notes" />
    <asp:BoundField HeaderText="时间" HeaderStyle-CssClass="col_datetime"  ItemStyle-CssClass="col_datetime" DataField="CreateTime"  />
   <%-- <asp:TemplateField HeaderText="操作" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option">
        <ItemTemplate>
            <a href="Edit.aspx?id=<%#Eval("ID") %>">修改</a> | <a href="Del.aspx?id=<%#Eval("ID") %>">删除</a>
        </ItemTemplate>
    </asp:TemplateField>--%>
    
</Columns>
</asp:GridView>


<table width="100%" class="dataGrid_Footer">
    <tr>
        <td class="options">
         <%--<a href="#" onclick="setCheckGroup('id',true); return false;">全选</a> <a href="#" onclick="resverSelect('id'); return false;">反选</a>--%>
        </td>
        <td class="pagerBox">
            <CashTicketControl:Pager ID="Pager1" runat="server"  />
        </td>
    </tr>
</table>




</asp:Content>


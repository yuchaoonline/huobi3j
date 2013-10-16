<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="List.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.CorpAgent.UserInCorps.List"  %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
Admin - CorpAgent - UserInCorps - List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
.searchTable .key{ width:auto; }
.searchTable .input{ width:auto; }
</style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>商家邀请代理商</span> &gt; 列表
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
<input type="hidden" name="page"  value="1" />
<table class="searchTable">
    <tr>
        <td class="key">代理商名称:</td>
        <td class="input">
            <asp:TextBox ID="txtCorpAgentRealName" runat="server" CssClass="txtBox"></asp:TextBox>
        </td>
        <td class="key">商家名称:</td>
        <td class="input">
            <asp:TextBox ID="txtCorpName" runat="server" CssClass="txtBox"></asp:TextBox>
        </td>
        <td class="key">状态:</td>
        <td class="input">
        <asp:DropDownList ID="ddlCheckState" runat="server">
            <asp:ListItem Value="-1" Selected="True">全部</asp:ListItem>
            <asp:ListItem Value="0">待审核</asp:ListItem>
            <asp:ListItem Value="1">通过审核</asp:ListItem>
            <asp:ListItem Value="2">无效</asp:ListItem>
            <asp:ListItem Value="3">过期</asp:ListItem>
        </asp:DropDownList>
        </td>
        <td class="key">&nbsp;</td>
        <td class="input">
            <asp:Button ID="btnSubmit" runat="server" Text="搜索" onclick="btnSubmit_Click" />
        </td>
    </tr>
</table>


<asp:GridView ID="gvData" runat="server" CssClass="dataGrid" SkinID="gridviewSkin" AutoGenerateColumns="false" ShowFooter="false" BorderStyle="None"  ShowHeader="true">
<Columns>
    <asp:TemplateField HeaderStyle-CssClass="col_id"  ItemStyle-CssClass="col_id" HeaderText="ID">
        <ItemTemplate>
            <%--<input type="checkbox" name="<% = gvData.ClientID %>" value="<%#Eval("ID") %>" />--%> <%#Eval("ID") %>
        </ItemTemplate>    
    </asp:TemplateField>     
    <asp:TemplateField HeaderText="代理商通讯号码">
    <ItemTemplate>
        <a href="../Applications/Edit.aspx?userid=<%#Eval("UserID") %>"><%#Eval("CorpAgentUIN")%></a>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:BoundField HeaderText="代理商名称" DataField="CorpAgentLoginName"  HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" />
    <asp:BoundField HeaderText="商家名称" DataField="CorpName"  HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" />
    <asp:BoundField HeaderText="商家通讯号码" DataField="CorpUIN" />
   
	
    <asp:BoundField HeaderText="申请时间" HeaderStyle-CssClass="col_datetime"  ItemStyle-CssClass="col_datetime" DataField="CreateTime" HtmlEncode="true" DataFormatString="{0:d}" />
    <asp:TemplateField HeaderStyle-CssClass="col_state"  ItemStyle-CssClass="col_state" HeaderText="状态">
        <ItemTemplate>
            <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                Eval("CheckState").ToString(),
                new string[][]{
                    new string[]{"0","待审核"},
                    new string[]{"1","已审核"},
                    new string[]{"2","无效"},
                    new string[]{"3","过期"}
                }               
                )
            %>
        </ItemTemplate>    
    </asp:TemplateField>
    <asp:TemplateField HeaderText="操作" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option">
        <ItemTemplate>
            <a href="Edit.aspx?id=<%#Eval("ID") %>">修改</a>
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
            <IscControl:Pager ID="Pager1" runat="server"  />
        </td>
    </tr>
</table>




</asp:Content>


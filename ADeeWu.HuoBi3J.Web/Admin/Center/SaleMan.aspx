<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="SaleMan.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.Center.SaleMan"  %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
无标题文档
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>即时报价管理</span> &gt; 业务员列表
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
<input type="hidden" name="page"  value="1" />
<table class="searchTable">
    <tr>
        <td class="key">用户名称:</td>
        <td class="input"><input type="text" name="LoginName" class="LoginName" id="LoginName" runat="server" /></td>
        <td class="key">状态:</td>
        <td class="input"><select name="state" runat="server" id="state">
          <option value="-1">全部</option>
          <option value="0">待审核</option>
          <option value="1">已审核</option>
          <option value="2">无效</option>
          <option value="3">已过期</option>
        </select></td>
        <td class="key"><input name="submit" type="submit" value="搜索" /></td>
    </tr>
</table>


<asp:GridView ID="gvData" runat="server" CssClass="dataGrid" 
    SkinID="gridviewSkin" AutoGenerateColumns="False" BorderStyle="None" 
    EnableModelValidation="True">
<Columns>
    <asp:TemplateField HeaderStyle-CssClass="col_id"  ItemStyle-CssClass="col_id" HeaderText="ID">
        <ItemTemplate>
            <input type="checkbox" name="<% = gvData.ClientID %>" value="<%#Eval("ID") %>" /> <%#Eval("ID") %>
        </ItemTemplate>    

<HeaderStyle CssClass="col_id"></HeaderStyle>

<ItemStyle CssClass="col_id"></ItemStyle>
    </asp:TemplateField>
     <asp:HyperLinkField HeaderText="用户名称" HeaderStyle-CssClass="col_title" 
        ItemStyle-CssClass="col_title" DataNavigateUrlFields="id" 
        DataNavigateUrlFormatString="Edit.aspx?id={0}" DataTextField="LoginName" >    
<HeaderStyle CssClass="col_title"></HeaderStyle>

<ItemStyle CssClass="col_title"></ItemStyle>
    </asp:HyperLinkField>
	
    <asp:BoundField HeaderText="申请时间" HeaderStyle-CssClass="col_datetime"  
        ItemStyle-CssClass="col_datetime" DataField="CreateTime" HtmlEncode="true" 
        DataFormatString="{0:d}" >
<HeaderStyle CssClass="col_datetime"></HeaderStyle>

<ItemStyle CssClass="col_datetime"></ItemStyle>
    </asp:BoundField>
    <asp:BoundField DataField="ModifyTime" DataFormatString="{0:d}" 
        HeaderText="修改时间" />
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

<HeaderStyle CssClass="col_state"></HeaderStyle>

<ItemStyle CssClass="col_state"></ItemStyle>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="操作" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option">
        <ItemTemplate>
            <a href="Edit.aspx?id=<%#Eval("ID") %>">修改</a>
        </ItemTemplate>

<HeaderStyle CssClass="col_option"></HeaderStyle>

<ItemStyle CssClass="col_option"></ItemStyle>
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


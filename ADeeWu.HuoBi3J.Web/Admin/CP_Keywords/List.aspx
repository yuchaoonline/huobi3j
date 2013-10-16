<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="List.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.CP_Keywords.List"  %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
Admin - Corps - List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
.searchTable .key{ width:auto; }
.searchTable .input{ width:auto; }
</style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>商家推广</span> &gt; 推广关键字(商家设置)
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
<input type="hidden" name="page"  value="1" />
<table class="searchTable">
    <tr>
        <td width="16%" class="key">商家名称:</td>
        <td width="16%" class="input"><input type="text" name="corp" class="txtBox" id="corp" runat="server" /></td>
        <td width="9%" class="key">关键字:</td>
        <td width="14%" class="input"><input type="text" class="txtBox" id="txtKeyword" runat="server" /></td>
        <td width="11%" class="key">状态:</td>
        <td width="20%" class="input"><select name="state" runat="server" id="state">
          <option value="-1">全部</option>
          <option value="0">待审核</option>
          <option value="1">已审核</option>
          <option value="2">无效</option>
          <option value="3">已过期</option>
        </select></td>
        <td width="14%" class="key">&nbsp;</td>
    </tr>
    <tr>
      <td class="key">行业:</td>
      <td colspan="3" class="input">
	  	<IscControl:SyncSelector ID="syncSelectorCalling" runat="server" 
        DataSourceURL="<%$Resources:SyncSelector,Calling_DataSourceURL %>" 
        DataSourceName="<%$Resources:SyncSelector,Calling_DataSourceName %>" 
        ClientPostNames="<%$Resources:SyncSelector,Calling_ClientPostNames %>"
        />
	   </td>
      <td class="key">地区:</td>
      <td class="input">
	  	<IscControl:SyncSelector ID="syncSelectorLocation" runat="server" DataSourceURL="/js/data/Location.js" DataSourceName="aryLocation" ClientPostNames="province,city,area" />
	 </td>
      <td class="key"><input name="submit" type="submit" value="搜索" /></td>
    </tr>
</table>


<asp:GridView ID="gvData" runat="server" CssClass="dataGrid" SkinID="gridviewSkin" AutoGenerateColumns="false" ShowFooter="false" BorderStyle="None"  ShowHeader="true">
<Columns>
    <asp:TemplateField HeaderStyle-CssClass="col_id"  ItemStyle-CssClass="col_id" HeaderText="ID">
        <ItemTemplate>
            <input type="checkbox" name="<% = gvData.ClientID %>" value="<%#Eval("ID") %>" /> <%#Eval("ID") %>
        </ItemTemplate>    
    </asp:TemplateField>
	<asp:HyperLinkField HeaderText="关键字" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" DataNavigateUrlFields="id" DataNavigateUrlFormatString="Edit.aspx?id={0}" DataTextField="Keyword" />
     <asp:HyperLinkField HeaderText="推广标题" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" DataNavigateUrlFields="id" DataNavigateUrlFormatString="Edit.aspx?id={0}" DataTextField="Title" />
    <asp:BoundField HeaderText="行业" HeaderStyle-CssClass="col_calling" ItemStyle-CssClass="col_calling" DataField="Calling" />
    <asp:TemplateField HeaderStyle-CssClass="col_location"  ItemStyle-CssClass="col_location" HeaderText="所属地区">
        <ItemTemplate>
            <%#string.Format("{0} {1} {2}", Eval("Province"),Eval("City"),Eval("Area")) %>
        </ItemTemplate>    
    </asp:TemplateField>
	
    <asp:BoundField HeaderText="设置时间" HeaderStyle-CssClass="col_datetime"  ItemStyle-CssClass="col_datetime" DataField="CreateTime" HtmlEncode="true" DataFormatString="{0:d}" />
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


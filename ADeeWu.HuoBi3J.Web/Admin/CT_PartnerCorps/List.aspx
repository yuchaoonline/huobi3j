<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="List.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.CT_PartnerCorps.List"  %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
Admin - CT_PartnerCorps - List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
.searchTable .key{ width:auto; }
.searchTable .input{ width:auto; }
</style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>现金券合作商家管理</span> &gt; 合作商家列表[业务员] <%--| <a href="Add.aspx">添加(开通现金券服务)</a>--%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
<input type="hidden" name="page"  value="1" />
<table class="searchTable">
    <tr>
        <td class="key">商家名称:</td>
        <td class="input"><input type="text" name="corp" class="txtBox" id="corp" runat="server" /></td>
        <td class="key">状态:</td>
        <td class="input"><select name="state" runat="server" id="state">
          <option value="-1">全部</option>
          <option value="0">待审核</option>
          <option value="1">已审核</option>
          <option value="2">无效</option>
          <option value="3">已过期</option>
        </select></td>
        <td class="key">&nbsp;</td>
    </tr>
    <tr>
      <td class="key">行业:</td>
      <td class="input">
        <IscControl:SyncSelector ID="syncSelectorCalling" runat="server" 
        DataSourceURL="<%$Resources:SyncSelector,Calling_DataSourceURL %>" 
        DataSourceName="<%$Resources:SyncSelector,Calling_DataSourceName %>" 
        ClientPostNames="<%$Resources:SyncSelector,Calling_ClientPostNames %>"
        />
	  </td>
      <td class="key">地区:</td>
      <td class="input">
	  	    <IscControl:SyncSelector ID="syncSelectorLocation" runat="server" 
                DataSourceURL="<%$Resources:SyncSelector,Location_DataSourceURL %>" 
                DataSourceName="<%$Resources:SyncSelector,Location_DataSourceName %>" 
                ClientPostNames="<%$Resources:SyncSelector,Location_ClientPostNames %>"
                />
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
    
    <asp:HyperLinkField HeaderText="商家名称" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" DataNavigateUrlFields="id" DataNavigateUrlFormatString="Edit.aspx?id={0}" DataTextField="CorpName" />
    <asp:TemplateField HeaderStyle-CssClass="col_number"  ItemStyle-CssClass="col_number" HeaderText="提成百分比">
        <ItemTemplate>
           <%#Eval("OfferPercent") %>%
        </ItemTemplate>    
    </asp:TemplateField>
    
    <asp:BoundField HeaderText="行业" HeaderStyle-CssClass="col_calling" ItemStyle-CssClass="col_calling" DataField="Calling" />
    <asp:TemplateField HeaderStyle-CssClass="col_location"  ItemStyle-CssClass="col_location" HeaderText="所属地区">
        <ItemTemplate>
            <%#string.Format("{0} {1} {2}", Eval("Province"),Eval("City"),Eval("Area")) %>
        </ItemTemplate>    
    </asp:TemplateField>
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


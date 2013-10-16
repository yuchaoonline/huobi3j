<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="List.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.Job_Categories.List" %>
<%@ Register assembly="ADeeWu.HuoBi3J.WebUI" namespace="ADeeWu.HuoBi3J.WebUI" tagprefix="IscControl" %>




<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
营销分类 - 分类管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>职位分类管理</span> &gt; 分类列表 | <a href="Add.aspx">添加</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    
    <div>
    <table class="searchTable">
        <tr>
            <td class="key" style="width:80px">
                标题：            </td>
            <td class="input">
                <asp:TextBox ID="txtTitle" runat="server" Width="100px"></asp:TextBox>
            </td>
            <td class="key">
                隐藏：            
			</td>
            <td class="input">
                <asp:DropDownList ID="ddlIsHidden" runat="server">
                    <asp:ListItem Value="-1">全部</asp:ListItem>
                    <asp:ListItem Value="0">否</asp:ListItem>
                    <asp:ListItem Value="1">是</asp:ListItem>  
                </asp:DropDownList>            
		    </td>
        </tr>
        <tr>
          <td class="key" style="width:80px">所属分类：
          </td>
          <td class="input">
		  	 <IscControl:SyncSelector ID="syncSelectorJobCategory" runat="server" 
                DataSourceURL="<%$Resources:SyncSelector,JobCategories_DataSourceURL %>"
                DataSourceName="<%$Resources:SyncSelector,JobCategories_DataSourceName %>" 
                ClientPostNames="<%$Resources:SyncSelector,JobCategories_ClientPostNames %>"
				InitClientDependency="true"
				RefreshClientData="true"
                />
		  </td>
          <td class="key"><input name="submit" type="submit" value="搜索" /></td>
          <td class="input">&nbsp;</td>
        </tr>
    </table>
    
     
<asp:GridView Width="100%" ID="gvData" runat="server"  CssClass="gridView" SkinID="userGridViewSkin" AutoGenerateColumns="False">
<Columns>
    <asp:BoundField HeaderText="标题" HeaderStyle-CssClass="col_title"  ItemStyle-CssClass="col_title" DataField="name" />
   
   <asp:TemplateField HeaderText="发布时间" HeaderStyle-CssClass="col_datetime" ItemStyle-CssClass="col_datetime">
        <ItemTemplate>
            <%# Eval("CreateTime")%> 
        </ItemTemplate>
    </asp:TemplateField>
   <asp:TemplateField HeaderText="最后修改时间" HeaderStyle-CssClass="col_datetime" ItemStyle-CssClass="col_datetime">
        <ItemTemplate>
            <%# Eval("ModifyTime")%>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:BoundField HeaderText="排序" DataField="Sequence" />
    <asp:BoundField HeaderText="深度" DataField="Depth" />
    <asp:TemplateField HeaderText="隐藏">
        <ItemTemplate>
            <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                Eval("IsHidden").ToString().ToLower(),
                new string[][]{
                    new string[]{"true","是"},
                    new string[]{"false","否"}
                }               
                )
            %>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="操作" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option"> 
        <ItemTemplate>
          <a href="Edit.aspx?id=<%#Eval("ID") %>">修改</a>
         <!--<a onclick="return confirm('您确认要删除这条信息吗？')" href="Del.aspx?id=<%#Eval("ID") %>">删除</a>-->
        </ItemTemplate>
    </asp:TemplateField>
</Columns>
</asp:GridView>
<table width="100%" class="dataGrid_Footer" style="margin-top:-5px;">
    <tr>
        <td class="options">&nbsp;
        
        </td>
        <td class="pagerBox">
            <IscControl:Pager ID="Pager1" runat="server"  />
        </td>
    </tr>
</table>
    
    
    
    </div>
     
</asp:Content>


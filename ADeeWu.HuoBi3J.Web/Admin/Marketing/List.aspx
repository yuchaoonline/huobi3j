<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="List.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.Marketing.List" %>
<%@ Register assembly="ADeeWu.HuoBi3J.WebUI" namespace="ADeeWu.HuoBi3J.WebUI" tagprefix="CashTicketControl" %>




<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
无标题文档
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" type="text/css" href="../skins/css/main.css">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>在线营销</span> &gt; <a href="List.aspx">列表</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    
    <div>
     <input name="page" type="hidden" value="1" />
    <table class="searchTable">
        <tr>
            <td class="key" style="width:80px">
                标题：
            </td>
            <td>
                <asp:TextBox ID="title" runat="server" Width="100px"></asp:TextBox>
            </td>
            <td class="key">
                状态：
            </td>
            <td>
                <asp:DropDownList ID="ddlCheckState" runat="server">
                    <asp:ListItem Value="-1">全部</asp:ListItem>
                    <asp:ListItem Value="0">待审核</asp:ListItem>
                    <asp:ListItem Value="1">已审核</asp:ListItem>
                    <asp:ListItem Value="2">失效</asp:ListItem>
                    <asp:ListItem Value="3">过期</asp:ListItem>     
                </asp:DropDownList>
            </td>
            <td >
                发布时间：
            </td>
            <td>
		        <CashTicketControl:DateTimeSelector ID="beginTimeSelector" Width="90px"  runat="server"></CashTicketControl:DateTimeSelector>
		        至
                <CashTicketControl:DateTimeSelector ID="endTimeSelector" Width="90px" runat="server"></CashTicketControl:DateTimeSelector>
                  &nbsp;</td>
        </tr>
        <tr>
            <td class="key" style="width:80px">
                姓名：</td>
            <td>
                <asp:TextBox ID="UserName" runat="server" Width="100px"></asp:TextBox>
            </td>
            <td class="key">
                  <input name="submit" type="submit" value="搜索" /></td>
            <td>
                &nbsp;</td>
            <td >
                &nbsp;</td>
            <td>
		        &nbsp;</td>
        </tr>
    </table>
    
     
<asp:GridView Width="100%" ID="gvData" runat="server"  CssClass="gridView" SkinID="userGridViewSkin" AutoGenerateColumns="False">
<Columns>
    <asp:BoundField HeaderText="标题" HeaderStyle-CssClass="col_title"  ItemStyle-CssClass="col_title" DataField="Title"  >
<HeaderStyle CssClass="col_money"></HeaderStyle>

<ItemStyle CssClass="col_datetime"></ItemStyle>
    </asp:BoundField>
    <asp:BoundField HeaderText="发布人姓名" HeaderStyle-CssClass="col_account"  ItemStyle-CssClass="col_account" DataField="Name"  >
<HeaderStyle CssClass="col_money"></HeaderStyle>

<ItemStyle CssClass="col_datetime"></ItemStyle>
    </asp:BoundField>
    <asp:TemplateField HeaderText="用户类型">
        <ItemTemplate>
            <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                Eval("UserType").ToString(),
                new string[][]{
                    new string[]{"0","普通用户"},
                    new string[]{"1","商家"}
                }               
                )
            %>
        </ItemTemplate>
    </asp:TemplateField>
   
   <asp:TemplateField HeaderText="发布时间" HeaderStyle-CssClass="col_datetime" ItemStyle-CssClass="col_datetime">
        <ItemTemplate>
            <%# Eval("CreateTime", "{0:yyyy-MM-dd}")%> 
        </ItemTemplate>
    </asp:TemplateField>
   <asp:TemplateField HeaderText="最后修改时间" HeaderStyle-CssClass="col_datetime" ItemStyle-CssClass="col_datetime">
        <ItemTemplate>
            <%# Eval("ModifyTime", "{0:yyyy-MM-dd}")%>
        </ItemTemplate>
    </asp:TemplateField>
  <%--  
   <asp:TemplateField HeaderText="最后刷新时间" HeaderStyle-CssClass="col_notes" ItemStyle-CssClass="col_notes">
        <ItemTemplate>
            <%# Eval("RefreshTime")%>
        </ItemTemplate>
   </asp:TemplateField>
    --%>
    <asp:TemplateField HeaderText="状态">
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
         <!--<a onclick="return confirm('您确认要删除这条信息吗？')" href="Del.aspx?id=<%#Eval("ID") %>">删除</a>-->
        </ItemTemplate>
    </asp:TemplateField>
</Columns>
</asp:GridView>
<table width="100%" class="dataGrid_Footer" style="margin-top:-5px;">
    <tr>
        <td class="options">
        &nbsp;
        </td>
        <td class="pagerBox">
            <CashTicketControl:Pager ID="Pager1" runat="server"  />
        </td>
    </tr>
</table>
    
    
    
    </div>
     
</asp:Content>


<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="List.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.Jobs.List"  %>
<%@ Register assembly="ADeeWu.HuoBi3J.WebUI" namespace="ADeeWu.HuoBi3J.WebUI" tagprefix="CashTicketControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
无标题文档
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" type="text/css" href="../skins/css/main.css">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>在线出租</span> &gt; <a href="List.aspx">列表</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    
    <div>
     <input name="page" type="hidden" value="1" />
    <table class="searchTable">
        <tr>
            <td class="key" style="width:80px">
                职位名称：
            </td>
            <td>
                <asp:TextBox ID="jobName" runat="server" Width="100px"></asp:TextBox>
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
                  <input name="submit" type="submit" value="搜索" />
               </td>
        </tr>
    </table>
    
    <!--公司名称 职位名称  职业分类  工作地区  发布日期  应聘 -->
<asp:GridView Width="100%" ID="gvData" runat="server"  CssClass="gridView" SkinID="userGridViewSkin" AutoGenerateColumns="False">
<Columns>
    <asp:BoundField HeaderText="公司名称" HeaderStyle-CssClass="col_title"  ItemStyle-CssClass="col_title" DataField="CorpName"  >
    </asp:BoundField>
    <asp:BoundField HeaderText="职位名称" HeaderStyle-CssClass="col_title"  ItemStyle-CssClass="col_title" DataField="Title"  >
    </asp:BoundField>
   <asp:BoundField HeaderText="职业分类" HeaderStyle-CssClass="col_calling" ItemStyle-CssClass="col_calling"  DataField="CategoryName" ></asp:BoundField>
   
   <asp:TemplateField HeaderText="工作地区" HeaderStyle-CssClass="col_location" ItemStyle-CssClass="col_location">
        <ItemTemplate>
            <%# Eval("CityName") %>-<%# Eval("AreaName") %>
        </ItemTemplate>
    </asp:TemplateField>
   <asp:TemplateField HeaderText="创建时间" HeaderStyle-CssClass="col_money" ItemStyle-CssClass="col_money">
        <ItemTemplate>
            <%# Eval("CreateTime","{0:yyyy-MM-dd}")%>
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
        <td class="options">&nbsp;
        
        </td>
        <td class="pagerBox">
            <CashTicketControl:Pager ID="Pager1" runat="server"  />
        </td>
    </tr>
</table>
    
    
    
    </div>
     
</asp:Content>


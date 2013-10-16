<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="List.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.Houses.List" ValidateRequest="false" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="CashTicketControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
Admin - SystemManage - AdminUsers - List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<script src="../../JS/jquery.js" type="text/javascript"></script>
<script src="../../JS/DateTimeSelector/jquery.dynDateTime.js" type="text/javascript"></script>
<script src="../../JS/DateTimeSelector/lang/calendar-zh.js" type="text/javascript"></script>
<link href="../../JS/DateTimeSelector/css/calendar-blue.css" rel="stylesheet" type="text/css" />
<style type="text/css">
    #txtbegintime
    {
        width: 103px;
    }
    #txtendtime
    {
        width: 100px;
    }
</style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>后台在线出租管理</span> &gt; 查看出租信息
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

 <input type="hidden" name="page"  value="1" />
<table class="searchTable">
    <tr>
        <td class="key" style="width:50px">标题：</td>
        <td>        
            <asp:TextBox ID="txtTitle" runat="server" Width="120px"></asp:TextBox>
        </td>
        <td  style="width:60px">        
            房屋结构：
        </td>
        <td >        
         <asp:DropDownList ID="ddlhousestrcts" runat="server">
                    <asp:ListItem Value="-1">全部</asp:ListItem>
                    <asp:ListItem Value="0">单间</asp:ListItem>
                    <asp:ListItem Value="1">一室一厅</asp:ListItem>
                    <asp:ListItem Value="2">二室一厅</asp:ListItem>
                    <asp:ListItem Value="3">二室二厅</asp:ListItem>     
                    <asp:ListItem Value="4">三室一厅</asp:ListItem>  
                    <asp:ListItem Value="5">四室一厅</asp:ListItem>     
                    <asp:ListItem Value="6">四室二厅</asp:ListItem>  
                    <asp:ListItem Value="7">其他结构</asp:ListItem>                  
        </asp:DropDownList>
        </td>
        <td>        
            发布时间：
        </td>
        <td >        
              <script type="text/javascript">
					jQuery(document).ready(function() {
						jQuery("#txtbegintime").dynDateTime(); //defaults
						jQuery("#txtendtime").dynDateTime(); 
					});
		 </script>
		 &nbsp;<input type="text" id="txtbegintime" runat="server" readonly=readonly /> 
            至<input type="text" id="txtendtime" runat="server" readonly=readonly />
        </td>
    </tr>
    <tr>
        <td class="key" style="width:50px">状态：</td>
        <td>        
            <asp:DropDownList ID="ddlstate" runat="server">
                <asp:ListItem Value="-1">全部</asp:ListItem>
                <asp:ListItem Value="0">待审核</asp:ListItem>
                <asp:ListItem Value="1">已审核</asp:ListItem>
                <asp:ListItem Value="2">无效</asp:ListItem>
                <asp:ListItem Value="3">过期</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td  style="width:60px">        
              <asp:Button ID="btnQuery" runat="server" Text="搜索" onclick="btnQuery_Click" />
        </td>
        <td >&nbsp;        
            </td>
        <td>&nbsp;        
            </td>
        <td >&nbsp;        
              </td>
    </tr>
    </table>
<asp:GridView Width="100%" ID="gvData" runat="server"  CssClass="gridView" SkinID="userGridViewSkin" AutoGenerateColumns="False">
<Columns>
    <asp:TemplateField HeaderStyle-CssClass="col_id"  ItemStyle-CssClass="col_id" HeaderText="编号">
        <ItemTemplate>
        <%--<input type="checkbox" name="id" value="<%#Eval("homeCode") %>" />--%> <%#Eval("homeCode") %></ItemTemplate>     
    </asp:TemplateField>
    <asp:BoundField HeaderText="标题" HeaderStyle-CssClass="col_title"  ItemStyle-CssClass="col_title" DataField="Title" />
   <asp:BoundField HeaderText="房屋結构" HeaderStyle-CssClass="col_notes" ItemStyle-CssClass="col_notes"  DataField="HouseStructText" />
   
   <asp:TemplateField HeaderText="房屋类型" HeaderStyle-CssClass="col_money" ItemStyle-CssClass="col_money">
        <ItemTemplate>
            <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                Eval("HouseType").ToString(),
                new string[][]{
                    new string[]{"0","住宅"},
                    new string[]{"1","商铺"},
                    new string[]{"2","写字楼"},
                    new string[]{"3","工厂"}
                }               
                )
            %>
        </ItemTemplate>
    </asp:TemplateField>
   <asp:TemplateField HeaderText="房屋性质" HeaderStyle-CssClass="col_money" ItemStyle-CssClass="col_money">
        <ItemTemplate>
            <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                Eval("Properity").ToString(),
                            "其他",
                new string[][]{
                    new string[]{"0","出租"},
                    new string[]{"1","转让"},
                    new string[]{"2","合租"}
                }         
                )
            %>
            
        </ItemTemplate>
    </asp:TemplateField>
    
   
   <asp:TemplateField HeaderText="房屋面积" HeaderStyle-CssClass="col_notes" ItemStyle-CssClass="col_notes">
        <ItemTemplate>
            <%#Eval("AreaSize") %> m<sup>2</sup>
        </ItemTemplate>
   </asp:TemplateField>
    
    <asp:BoundField HeaderText="月租" HeaderStyle-CssClass="col_money"  
        ItemStyle-CssClass="col_money" DataField="Price" Visible="False" >
    </asp:BoundField>
    <asp:BoundField DataField="CreateTime"  HeaderText="发布时间" />
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
          <a href="Edit.aspx?id=<%#Eval("id") %>">修改</a>
        </ItemTemplate>
    </asp:TemplateField>
</Columns>
</asp:GridView>
<table width="100%" class="dataGrid_Footer" style="margin-top:-5px;">
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


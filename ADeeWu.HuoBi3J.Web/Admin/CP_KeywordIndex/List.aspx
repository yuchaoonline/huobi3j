<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="List.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.CP_KeywordIndex.List"  %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="CashTicketControl" %>



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
<span>商家推广</span> &gt; 关键字索引缓存列区 | <a href="Refresh.aspx">更新缓存区</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
<input type="hidden" name="page"  value="1" />
<table class="searchTable">
    <tr>
        <td width="16%" class="key">商家名称:</td>
        <td class="input">
            <asp:TextBox ID="txtCorp" runat="server" class="txtBox"></asp:TextBox>        </td>
        <td width="11%" class="key">关键字:</td>
        <td width="11%" class="key"><asp:TextBox CssClass="input" ID="txtKeywords" runat="server" class="txtBox"></asp:TextBox>        </td>
        <td width="11%" class="key">&nbsp;</td>
        <td width="20%" class="input">
      </td>
        <td width="14%" class="key">&nbsp;</td>
    </tr>
    <tr>
      <td class="key">推广标题</td>
      <td class="input">
          <asp:TextBox ID="txtTitle" runat="server" class="txtBox"></asp:TextBox>	  </td>
      <td class="key">索引隐藏:</td>
      <td class="key"><span class="input">
        <asp:DropDownList id="ddlHidden" runat="server">
          <asp:ListItem Selected="True" Value="-1" Text="全部"></asp:ListItem>
          <asp:ListItem Value="0" Text="否"></asp:ListItem>
          <asp:ListItem Value="1" Text="是"></asp:ListItem>
        </asp:DropDownList>
      </span></td>
      <td class="key">竞价排名:</td>
      <td class="input"><asp:DropDownList id="ddlIsRankIndex" runat="server">
        <asp:ListItem Selected="True" Value="-1" Text="全部"></asp:ListItem>
        <asp:ListItem Value="0" Text="否"></asp:ListItem>
        <asp:ListItem Value="1" Text="是"></asp:ListItem>
      </asp:DropDownList></td>
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
 	<asp:TemplateField HeaderStyle-CssClass="col_title"  ItemStyle-CssClass="col_title" HeaderText="关键字">
        <ItemTemplate>
            <%#Eval("Keyword") %>
        </ItemTemplate>    
    </asp:TemplateField>

    <asp:BoundField HeaderText="推广标题" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" DataField="Title" />    
	
    <asp:BoundField HeaderText="商家名称" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" DataField="CorpName" />    	
    <asp:BoundField HeaderText="缓存时间" HeaderStyle-CssClass="col_datetime"  ItemStyle-CssClass="col_datetime" DataField="CreateTime" />
    <asp:BoundField HeaderText="排名" HeaderStyle-CssClass="col_money"  ItemStyle-CssClass="col_money" DataField="Sequence"  />
	 <asp:TemplateField HeaderStyle-CssClass="col_state"  ItemStyle-CssClass="col_state" HeaderText="推广审核">
        <ItemTemplate>
           <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                Eval("PromotionCheckState").ToString(),
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
    <asp:TemplateField HeaderStyle-CssClass="col_state"  ItemStyle-CssClass="col_state" HeaderText="索引隐藏">
        <ItemTemplate>
            <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                Eval("KeywordIsHidden").ToString(),
                new string[][]{
                    new string[]{"False","否"},
                    new string[]{"True","是"},
                }               
                )
            %>
        </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField HeaderStyle-CssClass="col_state"  ItemStyle-CssClass="col_state" HeaderText="竞价排名">
        <ItemTemplate>
            <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                Eval("IsRankIndex").ToString(),
                new string[][]{
                    new string[]{"False","否"},
                    new string[]{"True","<span style='color:red'>是</span>"},
                }               
                )
            %>
        </ItemTemplate>
    </asp:TemplateField>
    <%--<asp:TemplateField HeaderText="操作" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option">
        <ItemTemplate>
            <a href="Edit.aspx?id=<%#Eval("ID") %>">修改</a>
        </ItemTemplate>
    </asp:TemplateField>--%>
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


<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="List.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.CashTicketApplications.List"  %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="CashTicketControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
Admin - CashTicketApplications - List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>现金券兑现管理</span> &gt; 申请列表
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
<input type="hidden" name="page"  value="1" />
<table class="searchTable">
    <tr>
        <td class="key">用户名称:</td>
        <td class="input">
            <input type="text" name="key" id="key" runat="server" class="txtBox" /> <input type="submit" value="搜索" />
        </td>
    </tr>
</table>


<asp:GridView ID="gvData" runat="server" CssClass="dataGrid" SkinID="gridviewSkin" AutoGenerateColumns="False" BorderStyle="None">
<Columns>
    <asp:TemplateField HeaderStyle-CssClass="col_id"  ItemStyle-CssClass="col_id" HeaderText="ID">
        <ItemTemplate>
            <input type="checkbox" name="<% = gvData.ClientID %>" value="<%#Eval("ID") %>" /> <%#Eval("ID") %>
        </ItemTemplate>    

<HeaderStyle CssClass="col_id"></HeaderStyle>

<ItemStyle CssClass="col_id"></ItemStyle>
    </asp:TemplateField>
    
    <asp:HyperLinkField HeaderText="申请用户" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" DataNavigateUrlFields="UserID" DataNavigateUrlFormatString="../Users/Edit.aspx?id={0}" DataTextField="LoginName" >
<HeaderStyle CssClass="col_title"></HeaderStyle>

<ItemStyle CssClass="col_title"></ItemStyle>
    </asp:HyperLinkField>
    <asp:BoundField HeaderText="现金券序号" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" DataField="SerialNum" >
<HeaderStyle CssClass="col_title"></HeaderStyle>

<ItemStyle CssClass="col_title"></ItemStyle>
    </asp:BoundField>
    <asp:BoundField HeaderText="现金券验证码" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" DataField="ValidCode" >
<HeaderStyle CssClass="col_title"></HeaderStyle>

<ItemStyle CssClass="col_title"></ItemStyle>
    </asp:BoundField>
    <asp:BoundField HeaderText="所属商家" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" DataField="CorpName" >
<HeaderStyle CssClass="col_title"></HeaderStyle>

<ItemStyle CssClass="col_title"></ItemStyle>
    </asp:BoundField>
    <asp:BoundField HeaderText="消费日期" HeaderStyle-CssClass="col_datetime" ItemStyle-CssClass="col_datetime" DataField="CostDate" HtmlEncode="true" DataFormatString="{0:d}" >
<HeaderStyle CssClass="col_datetime"></HeaderStyle>

<ItemStyle CssClass="col_datetime"></ItemStyle>
    </asp:BoundField>
    <asp:BoundField HeaderText="申请日期" HeaderStyle-CssClass="col_datetime" ItemStyle-CssClass="col_datetime" DataField="CreateTime" HtmlEncode="true" DataFormatString="{0:d}" >
<HeaderStyle CssClass="col_datetime"></HeaderStyle>

<ItemStyle CssClass="col_datetime"></ItemStyle>
    </asp:BoundField>
    <asp:BoundField HeaderText="修改日期" HeaderStyle-CssClass="col_datetime"  ItemStyle-CssClass="col_datetime" DataField="ModifyTime" HtmlEncode="true" DataFormatString="{0:d}" >
<HeaderStyle CssClass="col_datetime"></HeaderStyle>

<ItemStyle CssClass="col_datetime"></ItemStyle>
    </asp:BoundField>
    <asp:TemplateField HeaderStyle-CssClass="col_state"  ItemStyle-CssClass="col_state" HeaderText="状态">
        <ItemTemplate>
            <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                Eval("CheckState").ToString(),
                new string[][]{
                    new string[]{"0","<font style='color:#ff0000;'>待审核</font>"},
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
            <CashTicketControl:Pager ID="Pager1" runat="server"  />
        </td>
    </tr>
</table>




</asp:Content>


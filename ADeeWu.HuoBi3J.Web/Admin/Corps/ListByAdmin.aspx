<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="ListByAdmin.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.Corps.ListByAdmin"  %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
Admin - Corps - List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>业务统计</span> &gt; 商家统计
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
<table class="searchTable">
    <tr>
        <td class="key">业务员:</td>
        <td class="input">
            <asp:DropDownList ID="ddlAdminUser" runat="server">
            </asp:DropDownList> 
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
      <td class="key">
          <asp:Button ID="btnSubmit" runat="server" Text="搜索" onclick="btnSubmit_Click" />
      </td>
      <td class="input">&nbsp;</td>
    </tr>
</table>


<asp:GridView ID="gvData" runat="server" CssClass="dataGrid" SkinID="gridviewSkin" AutoGenerateColumns="false" ShowFooter="false" BorderStyle="None"  ShowHeader="true">
<Columns>
    <asp:TemplateField HeaderStyle-CssClass="col_id"  ItemStyle-CssClass="col_id" HeaderText="ID">
        <ItemTemplate>
            <input type="checkbox" name="<% = gvData.ClientID %>" value="<%#Eval("ID") %>" /> <%#Eval("ID") %>
        </ItemTemplate>    
    </asp:TemplateField>
    
    <asp:BoundField HeaderText="商家名称" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" DataField="CorpName" />
    <asp:TemplateField HeaderText="用户" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title">
        <ItemTemplate>
            <a href="../Users/Edit.aspx?id=<%#Eval("UserID") %>"><%#ADeeWu.HuoBi3J.Libary.Utility.GetStr(Eval("UIN"), Eval("LoginName"), "", true)%></a>
        </ItemTemplate>    
    </asp:TemplateField>
    
    <asp:BoundField HeaderText="行业" HeaderStyle-CssClass="col_calling" ItemStyle-CssClass="col_calling" DataField="Calling" />
    <asp:TemplateField HeaderStyle-CssClass="col_location"  ItemStyle-CssClass="col_location" HeaderText="所属地区">
        <ItemTemplate>
            <%#string.Format("{0} {1} {2}", Eval("Province"),Eval("City"),Eval("Area")) %>
        </ItemTemplate>    
    </asp:TemplateField>
    <asp:BoundField HeaderText="注册时间" HeaderStyle-CssClass="col_datetime"  ItemStyle-CssClass="col_datetime" DataField="CreateTime" HtmlEncode="true" DataFormatString="{0:d}" />
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
    <asp:TemplateField HeaderStyle-CssClass="col_option"  ItemStyle-CssClass="col_option" HeaderText="操作">
        <ItemTemplate>
            <a href="Edit.aspx?id=<%#Eval("id") %>">修改</a>
        </ItemTemplate>    
    </asp:TemplateField>
</Columns>
</asp:GridView>


<table width="100%" class="dataGrid_Footer">
    <tr>
        <td class="options">
            商家数量:<asp:Literal ID="litNumOfCorps" runat="server"></asp:Literal>
        </td>
        <td class="pagerBox">
           <IscControl:Pager ID="Pager1" runat="server"  />
        </td>
    </tr>
</table>




</asp:Content>


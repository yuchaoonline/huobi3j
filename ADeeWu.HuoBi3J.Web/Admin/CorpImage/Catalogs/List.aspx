<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.CorpImage.Catalogs.List" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>
<%-- --%>

<html><!-- InstanceBegin template="/Templates/Admin_Default.dwt.aspx" codeOutsideHTMLIsLocked="false" -->
<!-- InstanceBeginEditable name="doctitle" -->
<title>Admin - Corps - List</title>
<!-- InstanceEndEditable -->
<!-- InstanceBeginEditable name="head" -->
<!-- InstanceEndEditable -->
<!-- InstanceBeginEditable name="SitePosition" -->
<span>企业相册管理</span> &gt; 列表
<!-- InstanceEndEditable -->
<!-- InstanceBeginEditable name="Content" -->
<input type="hidden" name="page"  value="1" />
<table class="searchTable">
    <tr>
    <td class="key" style="width:80px"> 标题：</td>
    <td><asp:TextBox ID="txtTitle" runat="server" Width="120px" /></td> 
    <td class="key" style="width:80px">商家名称：</td>
    <td><asp:TextBox ID="txtCorpID" runat="server" Width="120px" /></td> 
        <td class="key">状态:</td>
        <td class="input">
        <select name="state" runat="server" id="state">
          <option value="-1">全部</option>
          <option value="0">待审核</option>
          <option value="1">已审核</option>
          <option value="2">无效</option>
          <option value="3">已过期</option>
        </select></td>
        <td class="key"><input name="submit" type="submit" value="搜索" /></td>
    </tr>
   <%-- <tr>
      <td class="key">行业:</td>
      <td class="input">
      <IscControl:SyncSelector ID="syncSelectorCalling" runat="server" DataSourceURL="/js/data/calling.js" DataSourceName="aryCalling" ClientPostNames="calling" />
	  </td>
      <td class="key">地区:</td>
      <td class="input">
	  	<IscControl:SyncSelector ID="syncSelectorLocation" runat="server" DataSourceURL="/js/data/Location.js" DataSourceName="aryLocation" ClientPostNames="province,city,area" />
	  </td>      
    </tr>--%>
</table>


<asp:GridView ID="gvData" runat="server" CssClass="dataGrid" SkinID="gridviewSkin" AutoGenerateColumns="false" ShowFooter="false" BorderStyle="None"  ShowHeader="true">
<Columns>
   
    <asp:TemplateField   HeaderText="编号">     
          <ItemTemplate>
           <%# Eval("ID")%>
          </ItemTemplate>
    </asp:TemplateField>
    
     <asp:TemplateField HeaderText="标题">
        <ItemTemplate>
            <%# Eval("Title")  %>
        </ItemTemplate>
    </asp:TemplateField>
    
    <asp:TemplateField HeaderText="商家名称">
        <ItemTemplate>
         <a herf="../Edit.aspx?id=<%#Eval("CorpID") %>"><%#Eval("CorpName") %></a>       
         </ItemTemplate>
    </asp:TemplateField>
        
    <asp:TemplateField HeaderText="推荐">
        <ItemTemplate>
           <%# ((bool)Eval("IsRecommend")) ? "是" : "否"%>
        </ItemTemplate>
    </asp:TemplateField>
     <asp:TemplateField HeaderText="隐藏">
        <ItemTemplate>             
            <%# ((bool)Eval("IsHidden")) ? "是" : "否"%>
        </ItemTemplate>
    </asp:TemplateField>
    
    <asp:BoundField HeaderText="发布时间"  DataField="CreateTime" />   
    <asp:TemplateField HeaderText="操作" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option"> <ItemTemplate>
                    <a href='CatalogPhotos/List.aspx?catalogsid=<%#Eval("ID") %>'>查看|</a>  
                    
                    <a href='Edit.aspx?id=<%#Eval("ID") %>&corpid=<%#Eval("corpID") %>',>修改|</a>  
                    <a href='Del.aspx?id=<%#Eval("ID") %>&corpid=<%#Eval("corpID") %>' dir="ltr" onclick="return confirm('您确认要删除这条信息吗？')">
                    删除</a>
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




<!-- InstanceEndEditable -->
<!-- InstanceEnd --></html>


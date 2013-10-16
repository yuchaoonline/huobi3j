<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="List.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.CorpImage.Catalogs.CatalogPhotos.List"  %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>
<%-- --%>

<html><!-- InstanceBegin template="/Templates/Admin_Default.dwt.aspx" codeOutsideHTMLIsLocked="false" -->
<!-- InstanceBeginEditable name="doctitle" -->
<title>Admin - Corps - List</title>
<!-- InstanceEndEditable -->
<!-- InstanceBeginEditable name="head" -->
<!-- InstanceEndEditable -->
<!-- InstanceBeginEditable name="SitePosition" -->
<span>企业图片管理</span> &gt; 列表
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
                <%# Eval("Title") %>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="商家名称">
        <ItemTemplate>
         <a herf="../Edit.aspx?corpID=<%#Eval("CorpID") %>"><%#Eval("CorpName") %></a>       
         </ItemTemplate>
    </asp:TemplateField>
    
        <asp:TemplateField HeaderText="所属画册">
        <ItemTemplate>
         <a herf="../Edit.aspx?corpID=<%#Eval("CatalogsID") %>"><%#Eval("CatalogsName") %></a>       
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
       <%-- <asp:TemplateField HeaderText="是否设为封面">
            <ItemTemplate>
               <%# ADeeWu.HuoBi3J.Libary.Utility.GetLong(Eval("FaceID"), 0) == (long)Eval("ID") ? "是" : "否"%>
            </ItemTemplate>
        </asp:TemplateField>--%>
        
        <asp:TemplateField HeaderText="发布时间">
           <ItemTemplate>
                <%# Eval("CreateTime")%>
            </ItemTemplate>            
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="描述">
            <ItemTemplate>
                <%# Eval("Summary")%>
            </ItemTemplate>   
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="访问次数">
            <ItemTemplate>
                <%# Eval("VisitCount")%>
            </ItemTemplate>   
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="审核状态">
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
         <asp:TemplateField HeaderText="图片链接">
            <ItemTemplate>
                <%# Eval("URL")%>
            </ItemTemplate>   
            </asp:TemplateField>
        <asp:TemplateField HeaderText="备注">
            <ItemTemplate>
                <%# Eval("Content")%>
            </ItemTemplate>   
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="操作" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option"> <ItemTemplate>                       
            <a href='Edit.aspx?id=<%#Eval("ID") %>&corpid=<%#Eval("corpID") %>',>修改|</a>  
            <a href='Del.aspx?id=<%#Eval("ID") %>&corpid=<%#Eval("corpID") %>' dir="ltr" onclick="return confirm('您确认要删除这条信息吗？')">
                    删除</a>
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
            <IscControl:Pager ID="Pager1" runat="server"  />
        </td>
    </tr>
</table>




<!-- InstanceEndEditable -->
<!-- InstanceEnd --></html>

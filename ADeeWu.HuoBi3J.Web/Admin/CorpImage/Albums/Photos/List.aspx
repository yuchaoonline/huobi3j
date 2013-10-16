<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="List.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.CorpImage.Albums.Photos.List"  %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
Admin - Corps - List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="../../../../../Admin/js/image_func.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>企业图片管理</span> &gt; 列表
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

<table class="searchTable">
    <tr>
    <td class="key" style="width:80px"> 标题：</td>
    <td><asp:TextBox ID="txtTitle" runat="server" Width="120px" /></td> 
    <td class="key" style="width:80px">商家名称：</td>
    <td><asp:TextBox ID="txtCorpID" runat="server" Width="120px" /></td> 
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
        <td class="key">
            <asp:Button ID="btnSubmit" runat="server" Text="搜索" 
                onclick="btnSubmit_Click" />
        </td>
    </tr>
</table>

<asp:GridView ID="gvData" runat="server" CssClass="dataGrid" SkinID="gridviewSkin" AutoGenerateColumns="false" ShowFooter="false" BorderStyle="None"  ShowHeader="true"
>
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
    
        <asp:TemplateField HeaderText="所属相册">
        <ItemTemplate>
         <a herf="../Edit.aspx?corpID=<%#Eval("AlbumID") %>"><%#Eval("AlbumName") %></a>       
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
        
      <%--<asp:TemplateField HeaderText="是否设为封面">
            <ItemTemplate>
               <%# ADeeWu.HuoBi3J.Libary.Utility.GetLong(Eval("FaceID"), 0) == (long)Eval("corpID") ? "是" : "否"%>
            </ItemTemplate>
        </asp:TemplateField>
        --%>
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
        
       
        
       
         <asp:TemplateField HeaderText="图片">
            <ItemTemplate>
                <img src="<%# Eval("URL")%>" onload="imgAutoSize(this,80,80);" />
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
		
        <asp:TemplateField HeaderText="备注">
            <ItemTemplate>
                <%# Eval("Content")%>
            </ItemTemplate>   
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="操作" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option"> <ItemTemplate>                       
            <a href='Edit.aspx?id=<%#Eval("ID") %>&corpID=<%#Eval("corpID") %>',>修改|</a>  
            <a href='Del.aspx?id=<%#Eval("ID") %>&corpID=<%#Eval("corpID") %>' dir="ltr" onclick="return confirm('您确认要删除这条信息吗？')">
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




</asp:Content>


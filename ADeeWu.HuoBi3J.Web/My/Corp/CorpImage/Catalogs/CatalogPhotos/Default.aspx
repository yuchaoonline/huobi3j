<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.CorpImage.Catalogs.CatalogPhotos.Default" %>

 <%@ Register assembly="ADeeWu.HuoBi3J.WebUI" namespace="ADeeWu.HuoBi3J.WebUI" tagprefix="IscControl" %>
    
    
    
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    全民营销网 - 我的图片
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
      <a href="/My/Corp/">我的商家服务</a> &gt;发布职位管理   
      </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
         
       
    
    <table class="searchTable">
        <tr>
           <td class="key" style="width:70px">
                标题：</td>
            <td>
                <asp:TextBox ID="txtTitle" runat="server" Width="120px" />
                <asp:Button ID="btnSubmit" runat="server" Text="搜索" onclick="btnSubmit_Click" /> <a href="New.aspx">添加图片</a>
            </td>
        </tr>
    </table>

    <asp:GridView ID="gvData" runat="server" CssClass="gridView" 
            SkinID="userGridViewSkin" AutoGenerateColumns="False">
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
        <asp:TemplateField HeaderText="所属画册">
        <ItemTemplate>
         <a herf="../Edit.aspx?id=<%#Eval("CatalogsID") %>"><%#Eval("CatalogsName")%></a>       
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
        <asp:TemplateField HeaderText="是否设为封面">
            <ItemTemplate>
               <%# ADeeWu.HuoBi3J.Libary.Utility.GetLong(Eval("FaceID"), 0) == (long)Eval("ID") ? "是" : "否"%>
            </ItemTemplate>
        </asp:TemplateField>
        
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
         <asp:TemplateField HeaderText="图片">
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
                        <a href='Edit.aspx?id=<%#Eval("ID") %>'>修改|</a>  
                        <a href="Del.aspx?id=<%#Eval("ID") %>" dir="ltr" onclick="return confirm('您确认要删除这条信息吗？')">删除</a>
                    </ItemTemplate>

    <HeaderStyle CssClass="col_option"></HeaderStyle>

    <ItemStyle CssClass="col_option"></ItemStyle>
                    </asp:TemplateField>
        
    </Columns>
    </asp:GridView>


    <div class="pager">
        <IscControl:Pager ID="Pager1" runat="server"  />
    </div>
       
       
       
      
    </asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>





<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.Shop.Products.Default" %>
<%@ Register assembly="ADeeWu.HuoBi3J.WebUI" namespace="ADeeWu.HuoBi3J.WebUI" tagprefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
商家控制面板 - 商品管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">　</span><a href="/My/Corp/Shop/">在线营销</a><span class="spl">　</span><span class="curPos">商品管理</span> |  <a href="New.aspx">发布商品</a>
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server"> 
   

<table class="searchTable">
    <tr>       
            <td class="key" width="80">
                标　　题：
            </td>
            <td class="input">
                <asp:TextBox ID="txtName" runat="server" Width="120px" />
            </td>
            <td class="key" width="120">
                商铺商品分类：
            </td>
            <td class="input">
                <asp:DropDownList ID="ddlCPCategory" runat="server">
                </asp:DropDownList>
                 <asp:Button ID="btnSubmit" runat="server" Text="搜索" onclick="btnSubmit_Click" /> 
		    </td>
        </tr>
</table>    


<asp:GridView ID="gvData" runat="server" CssClass="gridView" 
        SkinID="userGridViewSkin" AutoGenerateColumns="False">
<Columns>
     
     
    <asp:TemplateField HeaderText="图片">
    <ItemTemplate>
                <a  href="/Shop/Products/View.aspx?id=<%#Eval("ID") %>" target="_blank">
                    <img src="<%#Eval("Picture0") %>" onload="isc.util.zoomImg(this,80,80)" border="0" />
                </a>
            </ItemTemplate>
    </asp:TemplateField>
    
    <asp:TemplateField HeaderText="标题" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title">
        <ItemTemplate>
            <a  href="/Shop/Products/View.aspx?id=<%#Eval("ID") %>" title="<%#Eval("Name") %>" target="_blank">
           <%# ADeeWu.HuoBi3J.Libary.Utility.SubString(Eval("Name"), 20, "...")%>
           </a>
        </ItemTemplate>
    </asp:TemplateField>
  
    <asp:TemplateField HeaderText="商品分类">
       <ItemTemplate>
        <%#Eval("CategoryName")%>
       </ItemTemplate>
    </asp:TemplateField>
                    
    <%--<asp:TemplateField HeaderText="推荐">
        <ItemTemplate>
           <%# ((bool)Eval("IsRecommend")) ? "是" : "否"%>
        </ItemTemplate>
    </asp:TemplateField>
     <asp:TemplateField HeaderText="隐藏">
        <ItemTemplate>             
            <%# ((bool)Eval("IsHidden")) ? "是" : "否"%>
        </ItemTemplate>
    </asp:TemplateField>
    
    <asp:TemplateField HeaderText="价格">
        <ItemTemplate>             
             <%# Eval("Price","{0:c}")%>
        </ItemTemplate>
    </asp:TemplateField>
     
    --%>
     <asp:TemplateField HeaderText="库存">
        <ItemTemplate>             
             <%# Eval("Stock")%>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="已售出">
        <ItemTemplate>             
             <%# Eval("SaleOut")%>
        </ItemTemplate>
    </asp:TemplateField>
   
    <%--<asp:TemplateField HeaderText="发布时间">
        <ItemTemplate>             
            <%# Eval("CreateTime") %>
        </ItemTemplate>
    </asp:TemplateField>--%>
    
    <asp:TemplateField HeaderText="操作" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option"> <ItemTemplate>
                   <%-- <a href='photos/Default.aspx?id=<%#Eval("ID") %>'>查看|</a>--%>  
                    
                    <a href='Edit.aspx?id=<%#Eval("ID") %>'>修改|</a>  
                    <a href="Del.aspx?id=<%#Eval("ID") %>" dir="ltr" onclick="return confirm('您确认要删除这条信息吗？')">
                    删除</a>
                </ItemTemplate>
    </asp:TemplateField>
    
</Columns>
</asp:GridView>


<div class="pager">
    <IscControl:Pager ID="Pager1" runat="server"  />
</div>
   
   
   
  
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>




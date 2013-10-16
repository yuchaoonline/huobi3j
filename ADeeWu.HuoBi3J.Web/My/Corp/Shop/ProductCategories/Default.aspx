<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.ProductCategories.Default" %>
<%@ Register assembly="ADeeWu.HuoBi3J.WebUI" namespace="ADeeWu.HuoBi3J.WebUI" tagprefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
商家控制面板 - 商铺产品分类
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">　</span><a href="/My/Corp/Shop/">在线营销</a><span class="spl">　</span><span class="curPos">商品自定义分类</span>
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
     
   

    


<asp:GridView ID="gvData" runat="server" CssClass="gridView" 
        SkinID="userGridViewSkin" AutoGenerateColumns="False">
<Columns>
   
    
     <asp:TemplateField HeaderText="分类名称">
        <ItemTemplate>
            <%# "".PadLeft((int)Eval("Depth"), '┠') + Eval("Name")%>
        </ItemTemplate>
    </asp:TemplateField>
    
    <asp:TemplateField HeaderText="商品数量">
        <ItemTemplate>
            <%# this.countItems((long)Eval("ID"))%>
        </ItemTemplate>
    </asp:TemplateField>
    
    <%--<asp:TemplateField HeaderText="图片">
        <ItemTemplate>             
        <img src="<%#Eval("ImgUrl") %>" border="0" onload="isc.util.zoomImg(this,120,80);" />
        </ItemTemplate>
    </asp:TemplateField>--%>
    
    <asp:TemplateField HeaderText="排序">
        <ItemTemplate>             
           <%#Eval("Sequence") %>
        </ItemTemplate>
    </asp:TemplateField>
    
    <asp:TemplateField HeaderText="隐藏">
        <ItemTemplate>             
            <%# ((bool)Eval("IsHidden")) ? "是" : "否"%>
        </ItemTemplate>
    </asp:TemplateField>
    
    

    <asp:TemplateField HeaderText="操作" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option" ItemStyle-Width="180px"> <ItemTemplate>
        <a href='../Products/?cid=<%#Eval("ID") %>'>查看该分类商品</a> | <a href='Edit.aspx?id=<%#Eval("ID") %>'>修改</a> | <a href="Del.aspx?id=<%#Eval("ID") %>" onclick="return confirm('您确认要删除这条信息吗？')">删除</a>
    </ItemTemplate>
    </asp:TemplateField>
    
</Columns>
</asp:GridView>



   
   
   
  
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>




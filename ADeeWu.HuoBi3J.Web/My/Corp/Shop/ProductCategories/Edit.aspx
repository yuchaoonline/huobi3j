<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Edit.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.ProductCategories.Edit" %>
<%@ Register assembly="ADeeWu.HuoBi3J.WebUI" namespace="ADeeWu.HuoBi3J.WebUI" tagprefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
商家控制面板 - 编辑商铺产品分类
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">　</span><a href="/My/Corp/Shop/">在线营销</a><span class="spl">　</span><a href="/My/Corp/Shop/ProductCategories/">商铺产品分类</a><span class="spl">　</span><span class="curPos">修改</span>
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
     
<table class="formTable">
    <tr>
        <td class="tdLeft">
           所属分类：
        </td>
        <td class="tdRight">
            <asp:DropDownList ID="ddlCategory" runat="server">
            </asp:DropDownList>
        
            
        </td>
    </tr>
    <tr>
        <td class="tdLeft">
           分类名称：
        </td>
        <td class="tdRight">
            <asp:TextBox ID="txtName" runat="server" CssClass="txtBox"></asp:TextBox><span class="require">*</span>
        </td>
    </tr>
    <%--<tr>
        <td class="tdLeft">
           分类图片：
        </td>
        <td class="tdRight">
            <IscControl:FileUploadEx ID="fileImgUrl" runat="server" AllowFileSize="512000" AllowFileExt="jpg|jpeg|gif|png|bmp" /><span class="require">*</span>
        </td>
    </tr>--%>
    <tr>
        <td class="tdLeft">
           隐　　藏：
        </td>
        <td class="tdRight">
            <asp:CheckBox ID="chkIsHidden" runat="server" Text="是" />
        </td>
    </tr>
    <tr>
        <td class="tdLeft">
           排　　序：
        </td>
        <td class="tdRight">
            <asp:TextBox ID="txtSequence" runat="server" CssClass="txtNum"></asp:TextBox><span class="tips">数值越小排序越前</span>
        </td>
    </tr>
    <tr>
        <td class="tdLeft">
           
        </td>
        <td class="tdRight">
            <asp:Button ID="btnSubmit" runat="server" Text="修改分类" 
                onclick="btnSubmit_Click"  />
        </td>
    </tr>
</table>
   
  
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>




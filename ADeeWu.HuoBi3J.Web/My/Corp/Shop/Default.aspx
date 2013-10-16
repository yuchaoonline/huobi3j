<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.Shop.Default" %>
<%@ Register assembly="ADeeWu.HuoBi3J.WebUI" namespace="ADeeWu.HuoBi3J.WebUI" tagprefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
商家控制面板 - 在线营销 - 商铺基本设置
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">　</span><span class="curPos">商铺基本设置</span> 
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">   
   
<asp:PlaceHolder ID="ph01" runat="server">
   
<table border="0" cellspacing="0" cellpadding="0" class="formTable">
  <tr>
    <td class="tdLeft">商铺名称：</td>
    <td class="tdRight">
        <asp:TextBox ID="txtShopName" runat="server" CssClass="txtBox" Width="300px" ReadOnly="true"></asp:TextBox>
    </td>
  </tr>
  <%--<tr>
    <td class="tdLeft">商铺Logo：</td>
    <td class="tdRight">
        <asp:Label ID="liteShopLogo" runat="server"></asp:Label>
        <img src="<%=this.liteShopLogo %>" onload="isc.util.zoomImg(this,250,250)" />
        <div><IscControl:FileUploadEx ID="fileLogo" runat="server"  AllowFileSize="512000" AllowFileExt="jpg|jpeg|gif|png|bmp" /></div>
    </td>
  </tr>--%>
  <tr>
    <td class="tdLeft">联系方式：</td>
    <td class="tdRight">
        <asp:TextBox ID="txtContact" runat="server" CssClass="txtNotes" TextMode="MultiLine"  Columns="30" Rows="3"></asp:TextBox>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">售后服务：</td>
    <td class="tdRight">
        <asp:TextBox ID="txtAfterSaleService" runat="server" CssClass="txtNotes" TextMode="MultiLine" Columns="60" Rows="3"></asp:TextBox>
        <div class="tips">该内容将会在你的商铺导航栏地方或每一个商品具体描述里出现</div>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">商铺产品分类：</td>
    <td class="tdRight">
       当前已添加 <asp:Label ID="liteNumOfCategories" runat="server" ForeColor="Red"></asp:Label> 分类 [ <a href="ProductCategories/">编辑商铺分类</a> ]
       <div class="tips">通过管理自定义分类，让消费者进入您的商铺以后能够按照分来搜索产品</div>
    </td>
  </tr>
<%--  <tr>
    <td class="tdLeft">送货方式：</td>
    <td class="tdRight">
       <asp:CheckBox ID="chkDeilveryType01" runat="server" Text="到代理店取货" />
       <asp:CheckBox ID="chkDeilveryType02" runat="server" Text="平邮" /> 
       <asp:CheckBox ID="chkDeilveryType03" runat="server" Text="快递" /> 
       <asp:CheckBox ID="chkDeilveryType04" runat="server" Text="EMS" /> 
    </td>
  </tr>--%>
  <tr>
    <td class="tdLeft">代理店地址：</td>
    <td class="tdRight">
        <asp:TextBox ID="txtAgentShopAddress" runat="server" Width="400px" CssClass="txtAddress"></asp:TextBox>
    </td>
  </tr>
  <tr>
    <td class="tdLeft"></td>
    <td class="tdRight">
        <asp:Button ID="btnSubmit" runat="server" Text="修改" 
            onclick="btnSubmit_Click"  />
    </td>
  </tr>
</table>

</asp:PlaceHolder>

<asp:PlaceHolder ID="ph02" runat="server">
<asp:Label ID="lblTips" runat="server" ForeColor="Red"></asp:Label>
<table border="0" cellspacing="0" cellpadding="0" class="formTable">
  <tr>
    <td class="tdLeft">商铺名称：</td>
    <td class="tdRight">
        <asp:TextBox ID="txtShopName_2" runat="server" CssClass="txtBox" Width="300px" ReadOnly="true"></asp:TextBox>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">联系方式：</td>
    <td class="tdRight">
        <asp:TextBox ID="txtContact_2" runat="server" CssClass="txtNotes" TextMode="MultiLine" Columns="30" Rows="3"></asp:TextBox>
        <div class="tips">该内容将会在你的商铺导航栏地方出现</div>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">售后服务：</td>
    <td class="tdRight">
        <asp:TextBox ID="txtAfterSaleService_2" runat="server" CssClass="txtNotes" TextMode="MultiLine" Columns="60" Rows="3"></asp:TextBox>
        <div class="tips">该内容将会在你的商铺导航栏地方或每一个商品具体描述里出现</div>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">送货方式：</td>
    <td class="tdRight">
       <asp:CheckBox ID="chkDeilveryType01_2" runat="server" Text="到代理店取货" />
       <asp:CheckBox ID="chkDeilveryType02_2" runat="server" Text="平邮" /> 
       <asp:CheckBox ID="chkDeilveryType03_2" runat="server" Text="快递" /> 
       <asp:CheckBox ID="chkDeilveryType04_2" runat="server" Text="EMS" /> 
    </td>
  </tr>
  <tr>
    <td class="tdLeft">代理店地址：</td>
    <td class="tdRight">
        <asp:TextBox ID="txtAgentShopAddress_2" runat="server" Width="400px" CssClass="txtAddress"></asp:TextBox>
    </td>
  </tr>
  <tr>
    <td class="tdLeft"></td>
    <td class="tdRight">
        <asp:Button ID="btnSubmit_2" runat="server" Text="修改" 
            onclick="btnSubmit_Click_2"  />
    </td>
  </tr>
</table>
</asp:PlaceHolder>



   
   
   
  
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>




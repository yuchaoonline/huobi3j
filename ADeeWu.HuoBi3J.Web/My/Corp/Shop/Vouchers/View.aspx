<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="View.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.Shop.Vouchers.View" %>
<%@ Register assembly="ADeeWu.HuoBi3J.WebUI" namespace="ADeeWu.HuoBi3J.WebUI" tagprefix="IscControl" %>




<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
商家控制面板 - 查看电子凭证
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">　</span><a href="/My/Corp/Shop/">在线营销</a><span class="spl">　</span><a href="/My/Corp/Shop/Vouchers/">电子凭证</a><span class="spl">　</span><span class="curPos">查看</span>  
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
     
 
<table class="formTable">
    
    <tr>
        <td class="tdLeft">
          标　　题：
        </td>
        <td class="tdRight">
            <asp:Label ID="lblTitle" runat="server" CssClass="txtBox" />
        </td>
    </tr>
    <tr>
        <td class="tdLeft">
          消费者UIN：
        </td>
        <td class="tdRight">
            <asp:Label ID="lblBuyerUIN" runat="server" CssClass="txtBox" />
        </td>
    </tr>
    <tr>
        <td class="tdLeft">
          消费者帐号：
        </td>
        <td class="tdRight">
            <asp:Label ID="lblBuyerLoginName" runat="server" CssClass="txtBox" />
        </td>
    </tr>
     <tr>
        <td class="tdLeft">
          消费者昵称：
        </td>
        <td class="tdRight">
            <asp:Label ID="lblBuyerName" runat="server" CssClass="txtBox" />
        </td>
    </tr>
    <tr>
        <td class="tdLeft">
          发布时间：
        </td>
        <td class="tdRight">
            <asp:Label ID="lblCreateTime" runat="server" CssClass="txtBox" />
        </td>
    </tr>
    <tr>
        <td class="tdLeft">
            内　　容：
        </td>
        <td class="tdRight">
            <asp:Label ID="lblContent" runat="server" CssClass="txtBox" />
        </td>
    </tr>
    <tr>
        <td class="tdLeft">
           
        </td>
        <td class="tdRight">
            <a href="javascript:history.back();void(0);">返回</a>
        </td>
    </tr>
    
</table>
   
   
   
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>




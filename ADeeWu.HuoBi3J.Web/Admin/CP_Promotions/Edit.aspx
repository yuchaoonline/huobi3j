<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="Edit.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.CP_Promotions.Edit"  %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="CashTicketControl" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
Admin - CT_PartnerCorps - Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>商家推广管理</span> &gt; <a href="List.aspx">推广商家列表</a> &gt; 修改
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

<table border="0" cellspacing="0" cellpadding="0" class="formTable">
  
  <tr>
    <td class="tdLeft">商家所属行业:</td>
    <td class="tdRight">
        <asp:Literal ID="liteCorpCalling" runat="server"></asp:Literal>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">标题:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtTitle" runat="server" CssClass="txtBox" ></asp:TextBox> <span class="require">*</span> 
    </td>
  </tr>
  <tr>
    <td class="tdLeft">推广信息:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtSummary" runat="server" TextMode="MultiLine" Columns="40" Rows="2" ></asp:TextBox> <span class="require">*</span> 
    </td>
  </tr>
  <tr>
    <td class="tdLeft">官方网站:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtURL" runat="server" CssClass="txtBox" ></asp:TextBox> <span class="require">*</span> 
    </td>
  </tr>
  <tr>
    <td class="tdLeft">商家名称:</td>
    <td class="tdRight">
        <asp:Literal ID="liteCorpName" runat="server"></asp:Literal>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">状态:</td>
    <td class="tdRight">
        <asp:DropDownList ID="ddlCheckState" runat="server">
            <asp:ListItem Value="0">待审核</asp:ListItem>
            <asp:ListItem Value="1">通过审核</asp:ListItem>
            <asp:ListItem Value="2">无效</asp:ListItem>
            <asp:ListItem Value="3">过期</asp:ListItem>
        </asp:DropDownList>
    </td>
  </tr>
   <tr>
    <td class="tdLeft">业务员绑定:</td>
    <td class="tdRight">
        <asp:DropDownList ID="ddlAminiUser" runat="server"></asp:DropDownList>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">申请时间:</td>
    <td class="tdRight">
        <asp:Literal ID="litCrateTime" runat="server"></asp:Literal>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">修改时间:</td>
    <td class="tdRight">
        <asp:Literal ID="litModifyTime" runat="server"></asp:Literal>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">&nbsp;</td>
    <td class="tdRight">
        <asp:Button ID="btnSubmit" runat="server" Text="提交" OnClick="btnSubmit_OnClick" />
    </td>
  </tr>
</table>


</asp:Content>


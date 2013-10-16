<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="Edit.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.CP_Keywords.Edit"  %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="CashTicketControl" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
Admin - CT_PartnerCorps - Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>商家推广管理</span> &gt; <a href="List.aspx">推广关键字(商家设置)</a> &gt; 修改
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

<table border="0" cellspacing="0" cellpadding="0" class="formTable">
  <tr>
    <td class="tdLeft">关键字:</td>
    <td class="tdRight">
        <asp:Literal ID="liteKeyword" runat="server"></asp:Literal>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">竞价货币数量:</td>
    <td class="tdRight">
        <asp:Literal ID="liteCoins" runat="server"></asp:Literal> 个
    </td>
  </tr>
   <tr>
    <td class="tdLeft">点击次数:</td>
    <td class="tdRight">
        <asp:Literal ID="liteVisitCount" runat="server"></asp:Literal>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">商家所属行业:</td>
    <td class="tdRight">
        <asp:Literal ID="liteCorpCalling" runat="server"></asp:Literal>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">推广标题:</td>
    <td class="tdRight">
        <asp:Literal ID="liteTitle" runat="server"></asp:Literal>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">推广信息:</td>
    <td class="tdRight">
        <asp:Literal ID="liteSummary" runat="server"></asp:Literal>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">官方网站:</td>
    <td class="tdRight">
       <asp:Literal ID="liteURL" runat="server"></asp:Literal>
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
    <td class="tdLeft">设置时间:</td>
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


<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="Edit.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.CT_PartnerCorps.Add"  %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="CashTicketControl" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
Admin - CT_PartnerCorps - Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>现金券合作商家管理</span> &gt; <a href="List.aspx">合作商家列表</a> &gt; 修改 | <a href="Add.aspx">添加(开通现金券服务)</a> 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

<table border="0" cellspacing="0" cellpadding="0" class="formTable">
  <tr>
    <td class="tdLeft">商家名称:</td>
    <td class="tdRight">
        <asp:DropDownList ID="ddlCorp" runat="server">
        </asp:DropDownList>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">商家所属行业:</td>
    <td class="tdRight">
        <asp:Literal ID="liteCorpCalling" runat="server"></asp:Literal>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">提供的提成百分比:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtOfferPercent" runat="server" CssClass="txtNum" ></asp:TextBox> (单位:百分比)<span class="require">
        *</span> 
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
    <td class="tdLeft">管理员:</td>
    <td class="tdRight">
        <asp:Literal ID="litAdminUser" runat="server"></asp:Literal>
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


<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="Add.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.Coins.Add"  %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
无标题文档
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>会员货币管理</span> &gt; <a href="List.aspx">明细记录</a> &gt; 添加货币 | <a href="Sub.aspx">扣除货币</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    
<table border="0" cellspacing="0" cellpadding="0" class="formTable">
  <tr>
    <td class="tdLeft">帐号:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtUIN" runat="server"></asp:TextBox>
        <span class="require">*</span> <span class="tips">选择要添加货币的会员</span>
    </td>
  </tr>
   <tr>
    <td class="tdLeft">货币数量:</td>
    <td class="tdRight">
    <asp:TextBox ID="txtMoney" runat="server" CssClass="txtBox" ></asp:TextBox> <span class="require">*</span>
    <span class="tips">单位:个</span>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">备注信息:</td>
    <td class="tdRight">
    <asp:TextBox ID="txtNotes" runat="server" CssClass="txtnotes" TextMode="MultiLine" Rows="4" Columns="50" >赠送</asp:TextBox> <span class="tips">一般填写操作的原因</span>    
    </td>
  </tr>
  <tr>
    <td class="tdLeft">&nbsp;</td>
    <td class="tdRight">
        <asp:Button ID="btnSubmit" runat="server" Text="提交" OnClick="btnSubmit_OnClick" /> <span class="strewColor">点击按钮提交后，系统将会为会员添加对应的货币,同时记录相关的历史操作</span>
    </td>
  </tr>
</table>


</asp:Content>


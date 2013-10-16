<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="Sub.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.VirtualTransfers.Sub"  %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
无标题文档
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>会员帐号费用管理</span> &gt; <a href="List.aspx">费用明细记录</a> &gt; 帐户扣费 | <a href="Add.aspx">帐户充值</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    
<table border="0" cellspacing="0" cellpadding="0" class="formTable">
  <tr>
    <td class="tdLeft">帐号:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtUIN" runat="server"></asp:TextBox> <span class="require">*</span> <span class="tips">选择要帐号扣费的会员</span>
    </td>
  </tr>
   <tr>
    <td class="tdLeft">扣费金额:</td>
    <td class="tdRight">
    <asp:TextBox ID="txtMoney" runat="server" CssClass="txtBox" ></asp:TextBox> <span class="require">*</span>
    <span class="tips">单位:元</span>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">备注信息:</td>
    <td class="tdRight">
    <asp:TextBox ID="txtNotes" runat="server" CssClass="txtnotes" TextMode="MultiLine" Rows="4" Columns="50" >系统服务扣费</asp:TextBox> <span class="tips">一般填写扣费的原因,如:某某增值服务</span>    
    </td>
  </tr>
  <tr>
    <td class="tdLeft">&nbsp;</td>
    <td class="tdRight">
        <asp:Button ID="btnSubmit" runat="server" Text="提交" OnClick="btnSubmit_OnClick" /> <span class="strewColor">点击按钮提交后，系统将会为会员虚拟帐号里扣费,同时记录相关的历史操作</span>
    </td>
  </tr>
</table>


</asp:Content>


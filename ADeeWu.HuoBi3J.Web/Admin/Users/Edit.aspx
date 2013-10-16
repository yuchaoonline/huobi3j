<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="Edit.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.Users.Edit"  %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
Admin - Users - Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>注册用户管理</span> &gt; <a href="List.aspx">用户列表</a> &gt; 修改  | <a href="Add.aspx">添加</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

<table border="0" cellspacing="0" cellpadding="0" class="formTable">
  <tr>
    <td class="tdLeft">UIN:</td>
    <td class="tdRight">
        <asp:Literal ID="liteUIN" runat="server"></asp:Literal>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">帐号:</td>
    <td class="tdRight">
        <asp:Literal ID="liteLoginName" runat="server"></asp:Literal>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">密码:</td>
    <td class="tdRight"><asp:TextBox ID="txtLoginPwd" runat="server" CssClass="txtBox" TextMode="Password"></asp:TextBox><span class="tips">保持原密码,请清空文本输入框</span></td>
  </tr>
  <tr>
    <td class="tdLeft">姓名:</td>
    <td class="tdRight"><asp:TextBox ID="txtName" runat="server" CssClass="txtBox"></asp:TextBox></td>
  </tr>
  <tr>
    <td class="tdLeft">联系电话:</td>
    <td class="tdRight"><asp:TextBox ID="txtTel" runat="server" CssClass="txtBox"></asp:TextBox></td>
  </tr>
   <tr>
    <td class="tdLeft">Email:</td>
    <td class="tdRight"><asp:TextBox ID="txtEmail" runat="server" CssClass="txtBox"></asp:TextBox></td>
  </tr>
  <tr>
    <td class="tdLeft">帐户金额:</td>
    <td class="tdRight">
        <asp:Literal ID="liteMoney" runat="server"></asp:Literal>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">支付宝帐号:</td>
    <td class="tdRight"><asp:TextBox ID="txtAlipayAccount" runat="server" CssClass="txtBox"></asp:TextBox></td>
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
    <td class="tdLeft">上一次登陆:</td>
    <td class="tdRight"><asp:Literal ID="litLastLogin" runat="server"></asp:Literal></td>
  </tr>
  <tr>
    <td class="tdLeft">登陆次数:</td>
    <td class="tdRight"><asp:Literal ID="litLoginTimes" runat="server"></asp:Literal></td>
  </tr>
  <tr>
    <td class="tdLeft">&nbsp;</td>
    <td class="tdRight">
        <asp:Button ID="btnSubmit" runat="server" Text="提交" OnClick="btnSubmit_OnClick" />
    </td>
  </tr>
</table>





</asp:Content>


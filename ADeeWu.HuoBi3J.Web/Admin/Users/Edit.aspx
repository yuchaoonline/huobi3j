<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="Edit.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.Users.Edit"  %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
Admin - Users - Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>ע���û�����</span> &gt; <a href="List.aspx">�û��б�</a> &gt; �޸�  | <a href="Add.aspx">���</a>
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
    <td class="tdLeft">�ʺ�:</td>
    <td class="tdRight">
        <asp:Literal ID="liteLoginName" runat="server"></asp:Literal>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">����:</td>
    <td class="tdRight"><asp:TextBox ID="txtLoginPwd" runat="server" CssClass="txtBox" TextMode="Password"></asp:TextBox><span class="tips">����ԭ����,������ı������</span></td>
  </tr>
  <tr>
    <td class="tdLeft">����:</td>
    <td class="tdRight"><asp:TextBox ID="txtName" runat="server" CssClass="txtBox"></asp:TextBox></td>
  </tr>
  <tr>
    <td class="tdLeft">��ϵ�绰:</td>
    <td class="tdRight"><asp:TextBox ID="txtTel" runat="server" CssClass="txtBox"></asp:TextBox></td>
  </tr>
   <tr>
    <td class="tdLeft">Email:</td>
    <td class="tdRight"><asp:TextBox ID="txtEmail" runat="server" CssClass="txtBox"></asp:TextBox></td>
  </tr>
  <tr>
    <td class="tdLeft">�ʻ����:</td>
    <td class="tdRight">
        <asp:Literal ID="liteMoney" runat="server"></asp:Literal>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">֧�����ʺ�:</td>
    <td class="tdRight"><asp:TextBox ID="txtAlipayAccount" runat="server" CssClass="txtBox"></asp:TextBox></td>
  </tr>
  <tr>
    <td class="tdLeft">״̬:</td>
    <td class="tdRight">
        <asp:DropDownList ID="ddlCheckState" runat="server">
            <asp:ListItem Value="0">�����</asp:ListItem>
            <asp:ListItem Value="1">ͨ�����</asp:ListItem>
            <asp:ListItem Value="2">��Ч</asp:ListItem>
            <asp:ListItem Value="3">����</asp:ListItem>
        </asp:DropDownList>
    </td>
  </tr>
   <tr>
    <td class="tdLeft">��һ�ε�½:</td>
    <td class="tdRight"><asp:Literal ID="litLastLogin" runat="server"></asp:Literal></td>
  </tr>
  <tr>
    <td class="tdLeft">��½����:</td>
    <td class="tdRight"><asp:Literal ID="litLoginTimes" runat="server"></asp:Literal></td>
  </tr>
  <tr>
    <td class="tdLeft">&nbsp;</td>
    <td class="tdRight">
        <asp:Button ID="btnSubmit" runat="server" Text="�ύ" OnClick="btnSubmit_OnClick" />
    </td>
  </tr>
</table>





</asp:Content>


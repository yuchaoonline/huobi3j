<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Edit.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.Promotions.Edit" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
商家控制面板 - 编辑推广信息
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">　</span><span class="curPos">商家推广关键字管理</span>  
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

<table border="0" cellspacing="0" cellpadding="0" class="formTable">
  <tr>
    <td class="tdLeft">商家名称:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtTitle" runat="server" Width="320px"></asp:TextBox><span class="require">*</span><asp:RequiredFieldValidator ID="rfvTitle" runat="server" ErrorMessage="请填写!" 
            ControlToValidate="txtTitle"></asp:RequiredFieldValidator>
    </td>
  </tr>
   <tr>
    <td class="tdLeft">推广信息:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtSummary" runat="server" Columns="50" Rows="2" 
            TextMode="MultiLine"></asp:TextBox><span class="require">*</span><br /><span class="tips">请填写公司服务/产品的介绍信息,不超过100个字符的长度</span><asp:RequiredFieldValidator ID="rfvSummary"
                runat="server" ErrorMessage="请填写!" ControlToValidate="txtUrl"></asp:RequiredFieldValidator>
    </td>
  </tr>
   <tr>
    <td class="tdLeft">官方网站:</td>
    <td class="tdRight">
    http://<asp:TextBox ID="txtUrl" runat="server"></asp:TextBox><span class="require">*</span><span class="tips">请填写公司的网站URL</span>
    <asp:RequiredFieldValidator ID="rfvUrl" runat="server" ErrorMessage="请填写!" 
            ControlToValidate="txtUrl"></asp:RequiredFieldValidator>
    </td>
  </tr>
   <tr>
    <td class="tdLeft"></td>
    <td class="tdRight">
        <asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" OnClientClick="return confirm('确定要修改信息吗?修改信息后需要重新通过审核!')" Text="提交" />
       </td>
  </tr>
</table>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>

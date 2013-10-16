<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Edit.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.Promotions.Keywords.AD.Edit" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
商家控制面板 - 精准搜索广告管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">　</span><a href="Default.aspx">广告设置管理</a>  <span class="spl">　</span><span class="curPos">编辑广告</span>
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <asp:HiddenField ID="hfID" runat="server" />
	<table class="formTable gridView">
        <tr>
            <th colspan="2">
                编辑广告
            </th>
        </tr>
        <tr>
	        <td class="tdLeft">标题：</td>
	        <td class="tdRight"><asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
	        <td class="tdLeft">描述：</td>
	        <td class="tdRight"><asp:TextBox ID="txtContent" runat="server"></asp:TextBox> <span class="require">*</span></td>
        </tr>
        <tr>
	        <td class="tdLeft">链接：</td>
	        <td class="tdRight"><asp:TextBox ID="txtLink" runat="server"></asp:TextBox> <span class="require">*</span></td>
        </tr>
        <tr>
	        <td class="tdLeft"></td>
	        <td class="tdRight">
	          <asp:Button ID="btnSubmit" runat="server" Text="添加" onclick="btnSubmit_Click" />
	        </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>

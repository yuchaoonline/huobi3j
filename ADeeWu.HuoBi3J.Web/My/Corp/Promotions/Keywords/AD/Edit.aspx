<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Edit.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.Promotions.Keywords.AD.Edit" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
�̼ҿ������ - ��׼����������
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">��</span><a href="Default.aspx">������ù���</a>  <span class="spl">��</span><span class="curPos">�༭���</span>
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <asp:HiddenField ID="hfID" runat="server" />
	<table class="formTable gridView">
        <tr>
            <th colspan="2">
                �༭���
            </th>
        </tr>
        <tr>
	        <td class="tdLeft">���⣺</td>
	        <td class="tdRight"><asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
	        <td class="tdLeft">������</td>
	        <td class="tdRight"><asp:TextBox ID="txtContent" runat="server"></asp:TextBox> <span class="require">*</span></td>
        </tr>
        <tr>
	        <td class="tdLeft">���ӣ�</td>
	        <td class="tdRight"><asp:TextBox ID="txtLink" runat="server"></asp:TextBox> <span class="require">*</span></td>
        </tr>
        <tr>
	        <td class="tdLeft"></td>
	        <td class="tdRight">
	          <asp:Button ID="btnSubmit" runat="server" Text="���" onclick="btnSubmit_Click" />
	        </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>

<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="Edit.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.CP_Keyword_AD.Edit"  %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="CashTicketControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
Admin - Corps - List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
.searchTable .key{ width:auto; }
.searchTable .input{ width:auto; }
</style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>�̼��ƹ�</span> &gt; �ؼ��������������� | <a href="Refresh.aspx">���»�����</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
<asp:HiddenField ID="hfID" runat="server" />
	<table class="formTable">
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
	        <td class="tdLeft">��ˣ�</td>
	        <td class="tdRight">
                <asp:DropDownList ID="ddIsPass" runat="server">
                    <asp:ListItem Value="0">δͨ��</asp:ListItem>
                    <asp:ListItem Value="1">ͨ��</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
	        <td class="tdLeft"></td>
	        <td class="tdRight">
	          <asp:Button ID="btnSubmit" runat="server" Text="���" onclick="btnSubmit_Click" />
	        </td>
        </tr>
    </table>
</asp:Content>


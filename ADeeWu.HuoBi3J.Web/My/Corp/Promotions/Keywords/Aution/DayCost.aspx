<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="DayCost.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.Promotions.Keywords.Aution.DayCost" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
�̼ҿ������ - ��׼�������۹���
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">��</span><a href="Default.aspx">�ؼ��־��۹���</a>  <span class="spl">��</span><span class="curPos">ÿ����������</span>
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <table class="formTable gridView">
        <tr>
            <th colspan="2">
                �޸�ÿ������
                <asp:HiddenField ID="hfID" runat="server" />
            </th>
        </tr>
        <tr>
	        <td class="tdLeft">��ǰ��</td>
	        <td class="tdRight"><asp:Label ID="lbTotalPrice" runat="server"></asp:Label></td>
        </tr>
        <tr>
	        <td class="tdLeft">ÿ���޼ۣ�</td>
	        <td class="tdRight"><asp:TextBox ID="txtTotalPriceDay" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
	        <td class="tdLeft"></td>
	        <td class="tdRight">
	            <asp:Button ID="btnSubmit" runat="server" Text="�޸�" onclick="btnSubmit_Click" />
	        </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>

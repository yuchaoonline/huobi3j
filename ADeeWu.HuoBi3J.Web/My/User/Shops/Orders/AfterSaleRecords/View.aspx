<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Shops.Orders.AfterSaleRecords.View" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    ���˿������ - �鿴�ۺ�����¼
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <span class="spl"></span><a href="/My/User/Shops/Orders/AfterSaleRecords/">�ۺ����</a><span class="spl">��</span><span class="curPos">�鿴</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

    <table class="formTable">
        <tr>
            <td class="tdLeft">�� �� ��:
            </td>
            <td class="tdRight">
                <asp:Label ID="lblOrderCode" runat="server" CssClass="txtBox" ReadOnly="true" />
            </td>
        </tr>
        <%--<tr>
	<td class="tdLeft">
		�̼�����:
	</td>
	<td class="tdRight">
		<asp:Label ID="lblCorpID" runat="server" CssClass="txtBox" ReadOnly="true" />
	</td>
</tr>--%>
        <tr>
            <td class="tdLeft">��Ʒ����:
            </td>
            <td class="tdRight">
                <asp:Label ID="lblProductName" runat="server" CssClass="txtBox" ReadOnly="true" />
            </td>
        </tr>

        <tr>
            <td class="tdLeft">�ա�����:
            </td>
            <td class="tdRight">
                <IscControl:DateTimeSelector ID="txtCreatTime" runat="server"></IscControl:DateTimeSelector>
            </td>
        </tr>


        <tr>
            <td class="tdLeft">�������� 	</td>
            <td>&nbsp;<asp:Label ID="lblResult" runat="server" />
                <%--<asp:RadioButton ID="cboExit" GroupName="state" runat="server" Checked="true"
			Text="�˻�" />
		<asp:RadioButton ID="cboSwap" GroupName="state" runat="server" Text="����" />
		&nbsp;<asp:RadioButton ID="cboRepail" GroupName="state" runat="server" Text="ά��" />--%>
                <%--&nbsp;<asp:RadioButton ID="cboStateEnd" GroupName="state" runat="server" Text="���" />--%>
            </td>
        </tr>

        <tr>
            <td class="tdLeft">������ע:
            </td>
            <td class="tdRight">
                <asp:Label ID="lblNote" runat="server" CssClass="txtBox" />
            </td>
        </tr>
        <tr>
            <td class="tdLeft">
                <a href="javascript:histroy.back();">����</a>
            </td>
            <td class="tdRight"></td>
        </tr>
    </table>

    <div class="pager">
        <IscControl:Pager ID="Pager1" runat="server" />
    </div>



</asp:Content>

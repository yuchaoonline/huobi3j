<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Shops.Vouchers.View" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    ���˿������ -���鿴�������ƾ֤
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <span class="spl"></span><a href="/My/User/Shops/Vouchers/">�������ƾ֤</a><span class="spl">��</span><span class="curPos">�鿴</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

    <table class="formTable">

        <tr>
            <td class="tdLeft">�ꡡ���⣺
            </td>
            <td class="tdRight">
                <asp:Label ID="lblTitle" runat="server" CssClass="txtBox" />
            </td>
        </tr>
        <tr>
            <td class="tdLeft">�̡����ң�
            </td>
            <td class="tdRight">
                <asp:Label ID="lblCorpName" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="tdLeft">����ʱ�䣺
            </td>
            <td class="tdRight">
                <asp:Label ID="lblCreateTime" runat="server" CssClass="txtBox" />
            </td>
        </tr>
        <tr>
            <td class="tdLeft">�ڡ����ݣ�
            </td>
            <td class="tdRight">
                <asp:Label ID="lblContent" runat="server" CssClass="txtBox" />
            </td>
        </tr>

    </table>


</asp:Content>

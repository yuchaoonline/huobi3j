<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Pay.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Shops.Orders.Pay" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    ���˿������ - ��������
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .item {
            margin-bottom: 20px;
        }

        .item-title {
            font-weight: bold;
            border-bottom: 1px dotted #ccc;
            margin-bottom: 10px;
            height: 24px;
            line-height: 24px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <span class="spl"></span><a href="/My/User/Shops/Orders/">�ҵĶ���</a><span class="spl">��</span><span class="curPos">��������</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">


    <table class="formTable">
        <tr>
            <td class="tdLeft">�� �� �ţ�
            </td>
            <td class="tdRight">
                <asp:Label ID="lblOrderCode" runat="server" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">���踶�
            </td>
            <td class="tdRight">
                <asp:Label ID="lblTotal" runat="server" Font-Bold="true"></asp:Label>Ԫ(�Ѱ����˷�)
            </td>
        </tr>
        <tr>
            <td class="tdLeft">��ǰ��
            </td>
            <td class="tdRight">
                <asp:Label ID="lblSpare" runat="server"></asp:Label>Ԫ
            </td>
        </tr>
        <tr>
            <td class="tdLeft"></td>
            <td class="tdRight">
                <asp:Button ID="btnSubmit" runat="server" Text="ȷ�ϸ���"
                    OnClick="btnSubmit_Click" />
            </td>
        </tr>
    </table>





</asp:Content>

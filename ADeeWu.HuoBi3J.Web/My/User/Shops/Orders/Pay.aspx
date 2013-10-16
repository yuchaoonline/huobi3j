<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Pay.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Shops.Orders.Pay" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    个人控制面板 - 订单付款
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
    <span class="spl"></span><a href="/My/User/Shops/Orders/">我的订单</a><span class="spl">　</span><span class="curPos">订单付款</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">


    <table class="formTable">
        <tr>
            <td class="tdLeft">订 单 号：
            </td>
            <td class="tdRight">
                <asp:Label ID="lblOrderCode" runat="server" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">共需付款：
            </td>
            <td class="tdRight">
                <asp:Label ID="lblTotal" runat="server" Font-Bold="true"></asp:Label>元(已包含运费)
            </td>
        </tr>
        <tr>
            <td class="tdLeft">当前余额：
            </td>
            <td class="tdRight">
                <asp:Label ID="lblSpare" runat="server"></asp:Label>元
            </td>
        </tr>
        <tr>
            <td class="tdLeft"></td>
            <td class="tdRight">
                <asp:Button ID="btnSubmit" runat="server" Text="确认付款"
                    OnClick="btnSubmit_Click" />
            </td>
        </tr>
    </table>





</asp:Content>

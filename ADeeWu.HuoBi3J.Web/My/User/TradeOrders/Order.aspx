<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.TradeOrders.Order" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    个人控制面板 - 在线充值
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <span class="spl"></span><a href="/My/User/TradeOrders/">我的充值订单</a><span class="spl">　</span><span class="curPos">在线充值</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <asp:PlaceHolder ID="phForm" runat="server">
        <table class="formTable">
            <tr>
                <td class="tdLeft"></td>
                <td class="tdRight">在线充值操作将会通过支付宝进行支付,支付成功后您的帐户里将得到对应的金额
                </td>
            </tr>
            <tr>
                <td class="tdLeft">充值金额：</td>
                <td class="tdRight">
                    <asp:TextBox ID="txtMoney" runat="server" Width="60px"></asp:TextBox>
                    元<span class="require">*</span><span class="tips">请输入正整数数字</span>
                    <asp:RequiredFieldValidator ID="rfvMoney" runat="server" ErrorMessage="请输入充值金额" ControlToValidate="txtMoney" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revMoney" runat="server" ErrorMessage="请填写正整数金额" ControlToValidate="txtMoney" Display="Dynamic" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="tdLeft"></td>
                <td class="tdRight">
                    <asp:Button ID="btnSubmit" runat="server" Text="下订单"
                        OnClick="btnSubmit_Click" />
                </td>
            </tr>
        </table>
    </asp:PlaceHolder>

    <asp:PlaceHolder ID="phResult" runat="server" Visible="false">
        <div style="font-size: 16px; font-weight: bold;">
            操作成功！您的订单号为：<span style="color: Red;"><asp:Literal ID="liteOrderCode" runat="server"></asp:Literal></span>
        </div>
        <div style="margin-top: 5px;">
            共需支付 <span style="color: Red; font-weight: bold;">
                <asp:Literal ID="liteTotalFee" runat="server"></asp:Literal></span> 元
            <a href="PayNow.aspx?order=<%=this.liteOrderCode.Text %>">立即支付</a>
        </div>
    </asp:PlaceHolder>

</asp:Content>



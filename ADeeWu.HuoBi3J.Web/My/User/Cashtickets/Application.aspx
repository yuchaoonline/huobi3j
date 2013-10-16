<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Application.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.CashTickets.Application" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="CashTicketControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    个人控制面板 - 现金赠送券兑换
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <span class="spl"></span><span class="curPos">现金赠送券兑换</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <table class="formTable">
        <%--<tr>
            <td class="tdLeft">商家名称：</td>
            <td class="tdRight">
                <asp:TextBox ID="txtCorpName" runat="server"></asp:TextBox><span class="require">*</span></td>
        </tr>
        <tr>
            <td class="tdLeft">消费金额：</td>
            <td class="tdRight">
                <asp:TextBox ID="txtCostMoney" runat="server" CssClass="txtNum"></asp:TextBox><span class="tips">元</span><span class="require">*</span></td>
        </tr>
        <tr>
            <td class="tdLeft">消费金额确认：</td>
            <td class="tdRight">
                <asp:TextBox ID="txtCostMoney2" runat="server" CssClass="txtNum"></asp:TextBox><span class="require">* 请确认实际消费金额，提交后将不能修改</span></td>
        </tr>
        <tr>
            <td class="tdLeft">消费日期：</td>
            <td class="tdRight">
                <CashTicketControl:DateTimeSelector ID="txtCostDate" runat="server" CssClass="txtDate"></CashTicketControl:DateTimeSelector><span class="require">*</span>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">具体商品及金额：</td>
            <td class="tdRight">

                <asp:TextBox ID="txtSummary" runat="server" Height="100px" TextMode="MultiLine"
                    Width="280px"></asp:TextBox><span class="require">*</span>

            </td>
        </tr>--%>
        <tr>
            <td class="tdLeft">现金券序列号：</td>
            <td class="tdRight">
                <asp:TextBox ID="txtCashTicketSerialNum" runat="server"></asp:TextBox><span class="require">*</span></td>
        </tr>
        <tr>
            <td class="tdLeft">现金券验证码：</td>
            <td class="tdRight">
                <asp:TextBox ID="txtCashTicketValidCode" runat="server"></asp:TextBox><span class="require">*</span></td>
        </tr>
        <tr>
            <td class="tdLeft">&nbsp;</td>
            <td class="tdRight">
                <asp:Button ID="btnSubmit" runat="server" Text="提交" OnClick="btnSubmit_Click" /></td>
        </tr>
    </table>

</asp:Content>




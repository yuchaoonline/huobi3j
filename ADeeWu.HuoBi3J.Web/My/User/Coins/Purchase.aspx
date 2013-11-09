<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Purchase.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Coins.Purchase" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="CashTicketControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    个人控制面板 - 购买虚拟金币
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <span class="spl"></span><span class="curPos">购买虚拟金币</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <table border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td class="tdLeft">当前金币持有量：</td>
            <td class="tdRight">
                <asp:Literal ID="liteNumOfCoins" runat="server"></asp:Literal>
                个
            </td>
        </tr>
        <tr>
            <td class="tdLeft">帐户余额：</td>
            <td class="tdRight">
                <asp:Literal ID="liteBalance" runat="server"></asp:Literal>
                元
            </td>
        </tr>
        <tr>
            <td class="tdLeft">金币兑换率：</td>
            <td class="tdRight">1 元 = <%=ADeeWu.HuoBi3J.Web.GlobalParameter.MoneyToCoinsRate%>个金币
            </td>
        </tr>
        <tr>
            <td class="tdLeft">购买数量：</td>
            <td class="tdRight">
                <asp:TextBox ID="txtTimesOfCoins" runat="server" Width="62px"></asp:TextBox><asp:RequiredFieldValidator
                    ID="rfvTimesOfCoins" runat="server" Display="Dynamic" ControlToValidate="txtTimesOfCoins" ErrorMessage="请填写正确的正整数"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                        ID="revTimesOfCoins" runat="server" Display="Dynamic" ControlToValidate="txtTimesOfCoins" ValidationExpression="\d+" ErrorMessage="请填写正确的正整数"></asp:RegularExpressionValidator><span class="require">*</span><span class="tips">请输入10的倍数</span>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">&nbsp;</td>
            <td class="tdRight">
                <asp:Button ID="btnSubmit" runat="server" Text="提交" OnClick="btnSubmit_Click" OnClientClick="return confirm('确认购买金币?')" /></td>
        </tr>
    </table>

</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="CashWhenFeeValidate.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Coupons.CashWhenFeeValidate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <table class="formTable">
        <tr>
            <td class="tdLeft">优惠券：</td>
            <td class="tdRight">
                <asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="查找" OnClick="btnSearch_Click" CssClass="btn_blue" />
            </td>
        </tr>
        </table>
    <table class="formTable">
        <tr>
            <th>消费金额</th>
            <th>抵扣金额</th>
            <th>有效期</th>
        </tr>
        <asp:Repeater ID="rpResult" runat="server">
            <ItemTemplate>
                <tr>
                    <td class="tdRight">
                        <%# Eval("fee") %>
                    </td>
                    <td class="tdRight">
                        <%# Eval("money") %>
                    </td>
                    <td class="tdRight">
                        <%# Eval("startdate")%> - <%#Eval("enddate") %>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>

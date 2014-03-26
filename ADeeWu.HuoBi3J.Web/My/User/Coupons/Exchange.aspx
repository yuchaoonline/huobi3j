<%@ Page Title="" Language="C#" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Exchange.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Coupons.Exchange" %>

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
        <asp:Repeater ID="rpResult" runat="server" OnItemCommand="rpResult_ItemCommand">
            <ItemTemplate>
                <tr>
                    <td class="tdLeft">拥有者：</td>
                    <td class="tdRight">
                        <%# Eval("loginname") %>
                    </td>
                </tr>
                <tr>
                    <td class="tdLeft">金额：</td>
                    <td class="tdRight">
                        <%# Eval("money") %>(<%# Eval("ismoney").ToString().ToLower()=="true"?"金钱":"虚拟币" %>)
                    </td>
                </tr>
                <tr>
                    <td class="tdLeft">有效期：</td>
                    <td class="tdRight">
                        <%# Eval("startdate")%> - <%#Eval("enddate") %>
                    </td>
                </tr>
                <tr>
                    <td class="tdLeft">状态：</td>
                    <td class="tdRight">
                        <%# Eval("isuse").ToString().ToLower()=="true"?"已使用("+Eval("usedate")+")":"未使用" %>
                    </td>
                </tr>
                <tr style='display: <%# Eval("isuse").ToString().ToLower()=="true"?"none":"block" %>'>
                    <td class="tdLeft"></td>
                    <td class="tdRight">
                        <asp:Button ID="btnUse" runat="server" CommandName="use" CommandArgument='<%# Eval("id") %>' Text="兑换" CssClass="btn_blue" />
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>

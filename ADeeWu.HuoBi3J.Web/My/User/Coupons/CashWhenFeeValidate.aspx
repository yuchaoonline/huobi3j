<%@ Page Title="" Language="C#" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="CashWhenFeeValidate.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Coupons.CashWhenFeeValidate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="/CSS/default.css" rel="stylesheet" />
    <link href="/CSS/forum_common.css" rel="stylesheet" type="text/css" />
    <link href="/CSS/forum_forumdisplay.css" rel="stylesheet" type="text/css" />
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

    <asp:Repeater ID="rpTotal" runat="server">
        <HeaderTemplate>
            <div class="box">
                <div class="box_head1">
                    <label class="fb font14 black70">兑换信息</label>
                </div>
                <div class="box_body">
        </HeaderTemplate>
        <ItemTemplate>
            <table class="formTable">
                <tr>
                    <td class="tdLeft">合计消费金额</td>
                    <td class="tdRight"><%# Eval("totalfee") %></td>
                </tr>
                <tr>
                    <td class="tdLeft">合计抵扣金额</td>
                    <td class="tdRight"><%# Eval("totalmoney") %></td>
                </tr>
                <tr>
                    <td class="tdLeft">消费时间</td>
                    <td class="tdRight"><%# Eval("createtime") %></td>
                </tr>
                <tr>
                    <td class="tdLeft">消费密码</td>
                    <td class="tdRight"><%# Eval("usecode") %></td>
                </tr>
            </table>
        </ItemTemplate>
        <FooterTemplate>
            </div></div>
        </FooterTemplate>
    </asp:Repeater>

    <asp:Repeater ID="rpResult" runat="server">
        <HeaderTemplate>
            <div class="mn">
                <div class="tl bm bmw" id="threadlist">
                    <div class="th">
                        <table cellspacing="0" cellpadding="0">
                            <tbody>
                                <tr>
                                    <td class="common">消费金额
                                    </td>
                                    <td class="common">抵扣金额
                                    </td>
                                    <td class="num">抵扣券数
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div class="bm_c">
                        <table cellspacing="0" cellpadding="0" summary="forum_2">
                            <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td class="common">
                    <%# Eval("fee") %>
                </td>
                <td class="common">
                    <%# Eval("money") %>
                </td>
                <td class="num">
                    <%# Eval("usecount") %>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </tbody>
                </table>
            </div>
        </div>
    </div>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="CashWhenFee.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Coupons.CashWhenFee" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="UserControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <div class="box">
        <div class="box_head1">
            <label class="fb font14 black70">基本信息</label>
            <asp:HiddenField ID="hfSubjectID" runat="server" />
        </div>
        <div class="box_body">
            <table>
                <tbody>
                    <tr height="35px">
                        <td class="tr">消费金额：</td>
                        <td class="font14 black4B">
                            <asp:TextBox ID="txtFee" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr height="35px">
                        <td class="tr">抵扣金额：</td>
                        <td class="font14 black4B">
                            <asp:TextBox ID="txtMoney" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr height="35px">
                        <td class="tr">开始时间：</td>
                        <td class="font14 black4B">
                            <UserControl:DateTimeSelector ID="dtStartDate" runat="server"></UserControl:DateTimeSelector>
                        </td>
                    </tr>
                    <tr height="35px">
                        <td class="tr">结束时间：</td>
                        <td class="font14 black4B">
                            <UserControl:DateTimeSelector ID="dtEndDate" runat="server"></UserControl:DateTimeSelector>
                        </td>
                    </tr>
                    <tr height="35px">
                        <td colspan="2" align="center">
                            <asp:Button ID="btnSubmit" runat="server" Text="提交" OnClick="btnSubmit_Click" CssClass="btn_blue" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>

    <div class="box">
        <div class="box_head1">
            <label class="fb font14 black70">优惠券二维码</label>
        </div>
        <div class="box_body">
            <table>
                <tbody>
                    <tr height="150px">
                        <td class="tr">一张券</td>
                        <td class="font14 black4B">
                            <img src="<%=GetQRURL(1) %>" alt="" width="150" />
                        </td>
                    </tr>
                    <tr height="150px">
                        <td class="tr">二张券</td>
                        <td class="font14 black4B">
                            <img src="<%=GetQRURL(2) %>" alt="" width="150" />
                        </td>
                    </tr>
                    <tr height="150px">
                        <td class="tr">三张券</td>
                        <td class="font14 black4B">
                            <img src="<%=GetQRURL(3) %>" alt="" width="150" />
                        </td>
                    </tr>
                    <tr height="150px">
                        <td class="tr">四张券</td>
                        <td class="font14 black4B">
                            <img src="<%=GetQRURL(4) %>" alt="" width="150" />
                        </td>
                    </tr>
                    <tr height="150px">
                        <td class="tr">五张券</td>
                        <td class="font14 black4B">
                            <img src="<%=GetQRURL(5) %>" alt="" width="150" />
                        </td>
                    </tr>
                    <tr height="150px">
                        <td class="tr">十张券</td>
                        <td class="font14 black4B">
                            <img src="<%=GetQRURL(10) %>" alt="" width="150" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>

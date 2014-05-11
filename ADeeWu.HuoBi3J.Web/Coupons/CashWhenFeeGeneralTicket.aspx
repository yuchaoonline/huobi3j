<%@ Page Title="" Language="C#" MasterPageFile="~/MMobileIndex.Master" AutoEventWireup="true" CodeBehind="CashWhenFeeGeneralTicket.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Coupons.CashWhenFeeGeneralTicket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    获得现金抵扣券
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <div class="list-group">
        <a href="#" class="list-group-item active">商家信息</a>
        <asp:Repeater ID="rpSaleManInfo" runat="server">
            <ItemTemplate>
                <a href="#" class="list-group-item">商家名称：<%# Eval("companyname") %></a><a href="#" class="list-group-item">商家地址：<%# Eval("companyaddress") %></a><a href="#" class="list-group-item">商家电话：<%# Eval("phone") %></a>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <div class="panel panel-primary">
        <div class="panel-heading">抵扣券信息</div>
        <table class="table">
            <tr>
                <th>消费金额</th>
                <th>金额</th>
                <th>抵扣券数</th>
            </tr>
            <asp:Repeater ID="rpTicket" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("fee") %></td>
                        <td><%# Eval("money") %></td>
                        <td><%# Eval("count") %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>

    <div class="list-group">
        <a href="#" class="list-group-item active">汇总</a>
        <asp:Repeater ID="rpTotal" runat="server">
            <ItemTemplate>
                <a href="#" class="list-group-item">合计消费金额：<%# Eval("totalfee") %></a>
                <a href="#" class="list-group-item">合计抵扣金额：<%# Eval("totalmoney") %></a>
                <a href="#" class="list-group-item">当前时间：<%# Eval("nowdate") %></a>
                <a href="#" class="list-group-item">过期时间：<%# Eval("invaildate") %></a>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <% if (LoginUser != null && LoginUser.UserID > 0)
       { %>
    <button type="button" id="btnConfirm" class="btn btn-primary btn-block btn-lg">领取</button>
    <%}
       else
       { %>
    <button type="button" id="btnLogin" class="btn btn-primary btn-block btn-lg">登陆/注册</button>
    <%} %>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="script" runat="server">
    <script type="text/javascript">
        $(function () {
            $('#btnLogin').click(function () {
                location.href = "/mobilelogin.aspx?url=" + location.href;
                return false;
            })
            $('#btnConfirm').click(function () {
                location.href = location.href + '&confirm=yes';
                return false;
            })
            $('#btnDownload').click(function () {
                location.href = '/hbsj.apk';
                return false;
            })
        })
    </script>
</asp:Content>

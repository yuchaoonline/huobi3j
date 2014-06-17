<%@ Page Title="" Language="C#" MasterPageFile="~/MMobileIndex.Master" AutoEventWireup="true" CodeBehind="CashWhenFeeGeneralTicket.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Coupons.CashWhenFeeGeneralTicket" %>
<%@ Import Namespace="ADeeWu.HuoBi3J.Libary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    获得现金抵扣券
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <h3>您将获得商家代金券</h3>
    <div class="list-group">
        <a href="#" class="list-group-item active">商家信息</a>
        <asp:Repeater ID="rpSaleManInfo" runat="server">
            <ItemTemplate>
                <input type="hidden" name="salemanuserid" value="<%# Eval("userid") %>" />
                <a href="#" class="list-group-item">商家名称：<%# Eval("companyname") %></a>
                <a href="#" class="list-group-item">商家地址：<%# Eval("companyaddress") %></a>
                <a href="#" class="list-group-item">商家电话：<%# Eval("phone") %></a>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <div class="panel panel-primary">
        <div class="panel-heading">抵扣券信息</div>
        <table class="table">
            <tr>
                <th>消费金额</th>
                <th>抵扣金额</th>
                <th>抵扣券数</th>
            </tr>
            <asp:Repeater ID="rpTicket" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("fee") %></td>
                        <td><%# Eval("money") %></td>
                        <td class="count"><%# Eval("count") %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>

    <div class="list-group">
        <a href="#" class="list-group-item active">汇总</a>
        <asp:Repeater ID="rpTotal" runat="server">
            <ItemTemplate>
                <a href="#" class="list-group-item">合计消费金额：<%# Eval("totalfee").GetDecimal().ToString("0.00") %></a>
                <a href="#" class="list-group-item">合计抵扣金额：<%# Eval("totalmoney").GetDecimal().ToString("0.00") %></a>
                <a href="#" class="list-group-item">当前时间：<%# Eval("nowdate").GetDateTime().ToString("yyyy/MM/dd HH:mm:ss") %></a>
                <a href="#" class="list-group-item">过期时间：<%# Eval("invaildate").GetDateTime().ToString("yyyy/MM/dd HH:mm:ss") %></a>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <% if (LoginUser != null && LoginUser.UserID > 0)
       { %>
    <button type="button" id="btnConfirm" class="btn btn-primary btn-block btn-lg">领取</button>
    <div class="alert alert-warning">重要提示：点击确定后，将不能变更，请仔细确认信息</div>
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
                location.href = "/mobilelogin.aspx?url=" + encodeURIComponent(location.href);
                return false;
            })
            $('#btnConfirm').click(function () {
                var salemanuserid = $('input[name=salemanuserid]').val();
                var count = 0;
                $('.count').each(function (index, item) {
                    count += parseInt($(this).text());
                })

                $.ajax({
                    url: '<%=ADeeWu.HuoBi3J.Web.Class.BaseDataHelper.MobileServiceSite%>/api/CashWhenFee?userid=<%=this.LoginUser==null?0:this.LoginUser.UserID %>&salemanuserid=' + salemanuserid + '&count=' + count,
                    //contentType: 'application/json; charset=utf-8',
                    type: 'Post',
                    success: function (data) {
                        location.href = '/mobileresult.aspx?url=/hbsj.apk&msg=您已经获得代金券，请点击确认下载货比三家手机应用查看代金券！';
                    },
                    statusCode: {
                        404: function () {
                            alert('活动不存在或者该商家未参加现金抵扣活动！');
                            return false;
                        },
                        409: function () {
                            alert('你今天已领取该商家的代金券，请不要重复领取！');
                            return false;
                        }
                    }
                });

                return false;
            })
            $('#btnDownload').click(function () {
                location.href = '/hbsj.apk';
                return false;
            })
        })
    </script>
</asp:Content>

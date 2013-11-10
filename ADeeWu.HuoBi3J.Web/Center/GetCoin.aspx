<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="GetCoin.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Center.GetCoin" %>

<!DOCTYPE html>
<html>
<head>
    <title>扫描二维码</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <link href="/css/bootstrap.min.css" rel="stylesheet">
    <link href="/CSS/bootstrap-theme.min.css" rel="stylesheet" />
    <style type="text/css">
        body {
            padding-top: 70px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-default navbar-fixed-top" role="navigation">
            <div class="navbar-header">
                <a class="navbar-brand" href="http://www.huobi3j.com">货比三家</a>
            </div>
        </nav>
        <div class="container">
            <div class="list-group">
                <a href="#" class="list-group-item active">商家信息</a>
                <asp:Repeater ID="rpSaleManInfo" runat="server">
                    <ItemTemplate>
                        <a href="#" class="list-group-item">商家名称：<%# Eval("companyname") %></a>
                        <a href="#" class="list-group-item">商家地址：<%# Eval("companyaddress") %></a>
                        <a href="#" class="list-group-item">商家电话：<%# Eval("phone") %></a>
                        <a href="#" class="list-group-item">商家介绍：<%# Eval("memo") %></a>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

            <div class="panel panel-primary">
                <div class="panel-heading">商家报价</div>
                <table class="table">
                    <tr>
                        <th>价格</th>
                        <th>简单描述</th>
                        <th>关键字</th>
                    </tr>
                    <asp:Repeater ID="rpProduct" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><a href="Details.aspx?id=<%# Eval("id") %>"><%# GetDecimal(Eval("price"),2) %></a></td>
                                <td><%# Eval("simpledesc") %></td>
                                <td><%# Eval("kname") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>

            <% if (LoginUser != null && LoginUser.UserID > 0)
               { %>
            <div class="alert alert-info">
                点击确认，您将获得10个金币            
            </div>
            <button type="button" id="btnConfirm" class="btn btn-primary btn-block btn-lg">确认</button>
            <%}
               else
               { %>
            <div class="alert alert-warning">
                您将获得10个金币，请先登陆            
            </div>
            <button type="button" id="btnLogin" class="btn btn-primary btn-block btn-lg">登录</button>
            <%} %>
        </div>

        <script src="/js/jquery.js"></script>
        <script src="/js/bootstrap.min.js"></script>
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
            })
        </script>
    </form>
</body>
</html>

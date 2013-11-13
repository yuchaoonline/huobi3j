<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MobileLogin.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.MobileLogin" %>

<!DOCTYPE html>
<html>
<head>
    <title>登录 - 货比三家</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <link href="/CSS/bootstrap.css" rel="stylesheet">
    <link href="/CSS/bootstrap-theme.css" rel="stylesheet" />
    <style type="text/css">
        body { padding-top: 70px; }
    </style>
</head>
<body>
    <nav class="navbar navbar-default navbar-fixed-top" role="navigation">
        <div class="navbar-header">
            <h4><span style="color: blue;">货比<span style="color: #f0ad4e">三</span>家</span><small>——身边价格，一目了然</small></h4>
        </div>
    </nav>

    <div class="container">
        <%--<div class="alert alert-danger">超时请重新登录</div>--%>
        <div class="panel panel-primary">
            <div class="panel-heading">登录 - 货比三家</div>
            <div class="panel-body">
                <form role="form">
                    <div class="form-group">
                        <input type="text" class="form-control input-lg" id="username" placeholder="用户名">
                    </div>
                    <div class="form-group">
                        <input type="password" class="form-control input-lg" id="Password" placeholder="密码">
                    </div>
                    <div class="form-group">
                        <button class="btn btn-primary btn-lg" id="btnSubmit">登录</button>
                        <span class="label label-warning">注册请访问http://www.huobi3j.com进行操作</span>
                    </div>
                </form>
            </div>
        </div>
    </div>

    <script src="/js/jquery.js"></script>
    <script src="/js/bootstrap.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#btnSubmit').click(function () {
                var username = $('#username').val();
                var password = $('#Password').val();

                if (username == '') {
                    alert('用户名不能为空！');
                    return false;
                }
                if (password == '') {
                    alert('密码不能为空！');
                    return false;
                }

                $.post(location.href, { method: 'login', username: username, password: password }, function (result) {
                    var data = JSON.parse(result);
                    if (data && data.statue) {
                        var url = '<%=Request["url"]%>';
                        if(url=='') url = '/';
                        location.href = url;
                    } else {
                        alert(data.msg);
                    }
                })

                return false;
            })
        })
    </script>
</body>
</html>

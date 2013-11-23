<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MobileRegister.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.MobileRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>登录 - 货比三家</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <link href="/CSS/bootstrap.css" rel="stylesheet" />
    <link href="/CSS/bootstrap-theme.css" rel="stylesheet" />
    <style type="text/css">
        body {
            padding-top: 70px;
        }
    </style>
</head>
<body>
    <nav class="navbar navbar-default navbar-fixed-top" role="navigation">
        <div class="navbar-header">
            <h4><span style="color: #428bca;">货比<span style="color: #f0ad4e">三</span>家</span><small>——身边价格，一目了然</small></h4>
        </div>
    </nav>

    <div class="container">
        <%--<div class="alert alert-danger">超时请重新登录</div>--%>
        <div class="panel panel-primary">
            <div class="panel-heading">注册 - 货比三家</div>
            <div class="panel-body">
                <form role="form">
                    <div class="form-group">
                        <input type="text" class="form-control input-lg" id="username" placeholder="用户名" />
                    </div>
                    <div class="form-group">
                        <input type="password" class="form-control input-lg" id="Password" placeholder="密码" />
                    </div>
                    <div class="form-group">
                        <input type="password" class="form-control input-lg" id="ConfirmPassword" placeholder="确认密码" />
                    </div>
                    <div class="row">
                        <div class="col-xs-6">
                            <input type="text" class="form-control input-lg" id="ValidCode" placeholder="验证码" />
                        </div>
                        <div class="col-xs-6">
                            <img src="ValidateCode.aspx" class="varify_code" alt="验证码" />
                        </div>
                    </div>
                    <div class="form-group">
                    </div>
                    <div class="form-group">
                        <button class="btn btn-primary btn-lg" id="btnSubmit">注册</button>
                        <button class="btn btn-primary btn-lg" id="btnLogin">登录</button>
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
                var ConfirmPassword = $('#ConfirmPassword').val();
                var ValidCode = $('#ValidCode').val();

                if (username == '') {
                    alert('用户名不能为空！');
                    return false;
                }
                if (password == '') {
                    alert('密码不能为空！');
                    return false;
                }

                if (ConfirmPassword != password) {
                    alert('密码与确认密码不相同！');
                    return false;
                }

                if (ValidCode == '') {
                    alert('验证码不能为空！');
                    return false;
                }

                $.post(location.href, { method: 'register', username: username, password: password, ValidCode: ValidCode }, function (result) {
                    var data = JSON.parse(result);
                    if (data && data.statue) {
                        alert(data.msg);
                        var url = '/mobilelogin.aspx';
                        if ('<%=Request["url"]%>' != '') url += '?url=<%=Request["url"]%>';
                        location.href = url;
                    } else {
                        alert(data.msg);
                    }

                    return false;
                })

                return false;
            })

            $('#btnLogin').click(function () {
                var url = '/mobilelogin.aspx';
                if ('<%=Request["url"]%>' != '') url += '?url=<%=Request["url"]%>';
                location.href = url;
                return false;
            })
        })
    </script>
</body>
</html>

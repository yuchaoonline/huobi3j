<%@ Page Language="C#" MasterPageFile="~/MMobileIndex.Master" AutoEventWireup="true" CodeBehind="MobileRegister.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.MobileRegister" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    注册
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
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
                        <button class="btn btn-primary btn-lg" id="btnLogin">登录</button>
                        <button class="btn btn-primary btn-lg" id="btnSubmit">注册</button>                        
                    </div>
                </form>
            </div>
        </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="script" runat="server">
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
</asp:Content>
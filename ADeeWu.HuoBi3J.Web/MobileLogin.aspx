<%@ Page Language="C#" MasterPageFile="~/MMobileIndex.Master" AutoEventWireup="true" CodeBehind="MobileLogin.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.MobileLogin"%>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    登录
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <div class="panel panel-primary">
            <div class="panel-heading">登录 - 货比三家</div>
            <div class="panel-body">
                <form role="form">
                    <div class="form-group">
                        <input type="text" class="form-control input-lg" id="username" placeholder="用户名" />
                    </div>
                    <div class="form-group">
                        <input type="password" class="form-control input-lg" id="Password" placeholder="密码" />
                    </div>
                    <div class="form-group">                        
                        <button class="btn btn-primary btn-lg" id="btnRegister">注册</button>
                        <button class="btn btn-primary btn-lg" id="btnSubmit">登录</button>
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
                        if (url == '/mobilelogin.aspx') url = '/';
                        location.href = url;
                    } else {
                        alert(data.msg);
                    }
                })

                return false;
            })

            $('#btnRegister').click(function () {
                location.href = "/mobileregister.aspx?url=<%=Request["url"]%>";
                return false;
            })

            $('#btnApp').click(function () {
                location.href = "/hbsj.apk";
                //alert('即将到来...');
                return false;
            })
        })
    </script>
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/MMobileIndex.Master" AutoEventWireup="true" CodeBehind="MobileLogin.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.MobileLogin"%>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    ��¼
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <div class="panel panel-primary">
            <div class="panel-heading">��¼ - ��������</div>
            <div class="panel-body">
                <form role="form">
                    <div class="form-group">
                        <input type="text" class="form-control input-lg" id="username" placeholder="�û���" />
                    </div>
                    <div class="form-group">
                        <input type="password" class="form-control input-lg" id="Password" placeholder="����" />
                    </div>
                    <div class="form-group">                        
                        <button class="btn btn-primary btn-lg" id="btnRegister">ע��</button>
                        <button class="btn btn-primary btn-lg" id="btnSubmit">��¼</button>
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
                    alert('�û�������Ϊ�գ�');
                    return false;
                }
                if (password == '') {
                    alert('���벻��Ϊ�գ�');
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
                //alert('��������...');
                return false;
            })
        })
    </script>
</asp:Content>

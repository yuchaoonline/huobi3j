<%@ Page Language="C#" Title="" MasterPageFile="~/MIndex.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    会员登陆
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script>
        $(function () {
            $('.btn_regist').click(function () {
                location.href = '/register.aspx';
                return false;
            })
        })
    </script>
    <style>
        .TimeoutTips {
            text-align: center;
            color: red;
            font-size: 24px;
            height: 48px;
            line-height: 48px;
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">

    <%if (Request["timeout"] == "true")
      {%>
    <div class="TimeoutTips">
        用户登陆超时,请重新登陆!
    </div>
    <%}%>

    <div id="login" class="l">
        <dl class="zoom">
            <dt class="l font14">账&nbsp;&nbsp;号：</dt>
            <dd class="l">
                <asp:TextBox ID="txtLoginName" runat="server" TabIndex="1" CssClass="input_text black32"></asp:TextBox>
                <span class="black70">
                    <label class="orange">*</label>还没有注册会员？请点击<a href="/Register.aspx">这里</a>申请！</span>
            </dd>
            <dt class="l font14">密&nbsp;&nbsp;码：</dt>
            <dd class="l">
                <asp:TextBox ID="txtLoginPwd" runat="server" TextMode="Password" TabIndex="2" CssClass="input_text black32"></asp:TextBox>
                <span class="black70">
                    <label class="orange">*</label>忘记密码？请点击<a href="/Forget.aspx">这里</a>取回您的密码！</span>
            </dd>
            <dt class="l font14">验证码：</dt>
            <dd class="l">
                <asp:TextBox ID="txtValidCode" runat="server" Width="50" TabIndex="3" CssClass="input_text verify_input black32"></asp:TextBox>
                <img  class="varify_code" width="75ox" height="21px" src="/ValidateCode.aspx" title="点击刷新验证码" alt="点击刷新验证码" style="cursor: pointer;" onclick="this.src=this.src+'?'+new Date()" />
            </dd>
            <dd class="cl">
                <asp:Button ID="btnSubmit" runat="server" Text="登  录" OnClick="btnSubmit_Click" CssClass="btn_blue btn_login" TabIndex="4" /></dd>
        </dl>
    </div>

    <div id="login_register" class="l">
        <div>
            <span class="font14 fb">还没有注册会员？</span>
            <p class="black70">只要通过简单的表单填写就可以成为全民营销网的正式会员</p>
            <input type="button" class="btn_gray114 btn_regist" value="注册新用户" />
        </div>
    </div>
</asp:Content>

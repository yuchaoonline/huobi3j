<%@ Page Language="C#" Title="" MasterPageFile="~/MIndex.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    ��Ա��½
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
        �û���½��ʱ,�����µ�½!
    </div>
    <%}%>

    <div id="login" class="l">
        <dl class="zoom">
            <dt class="l font14">��&nbsp;&nbsp;�ţ�</dt>
            <dd class="l">
                <asp:TextBox ID="txtLoginName" runat="server" TabIndex="1" CssClass="input_text black32"></asp:TextBox>
                <span class="black70">
                    <label class="orange">*</label>��û��ע���Ա������<a href="/Register.aspx">����</a>���룡</span>
            </dd>
            <dt class="l font14">��&nbsp;&nbsp;�룺</dt>
            <dd class="l">
                <asp:TextBox ID="txtLoginPwd" runat="server" TextMode="Password" TabIndex="2" CssClass="input_text black32"></asp:TextBox>
                <span class="black70">
                    <label class="orange">*</label>�������룿����<a href="/Forget.aspx">����</a>ȡ���������룡</span>
            </dd>
            <dt class="l font14">��֤�룺</dt>
            <dd class="l">
                <asp:TextBox ID="txtValidCode" runat="server" Width="50" TabIndex="3" CssClass="input_text verify_input black32"></asp:TextBox>
                <img  class="varify_code" width="75ox" height="21px" src="/ValidateCode.aspx" title="���ˢ����֤��" alt="���ˢ����֤��" style="cursor: pointer;" onclick="this.src=this.src+'?'+new Date()" />
            </dd>
            <dd class="cl">
                <asp:Button ID="btnSubmit" runat="server" Text="��  ¼" OnClick="btnSubmit_Click" CssClass="btn_blue btn_login" TabIndex="4" /></dd>
        </dl>
    </div>

    <div id="login_register" class="l">
        <div>
            <span class="font14 fb">��û��ע���Ա��</span>
            <p class="black70">ֻҪͨ���򵥵ı���д�Ϳ��Գ�Ϊȫ��Ӫ��������ʽ��Ա</p>
            <input type="button" class="btn_gray114 btn_regist" value="ע�����û�" />
        </div>
    </div>
</asp:Content>

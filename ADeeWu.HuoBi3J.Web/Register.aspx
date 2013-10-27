<%@ Page Language="C#" Title="" MasterPageFile="~/MIndex.master"  AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
全民营销网 - 用户注册
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="/js/isc.js"></script>
<script type="text/javascript">
function UINSelector_OnLoad(o)
{
	o.onSelected = function(keyValue)
	{
		document.getElementById("<%=fhUIN.ClientID%>").value = keyValue.uin;
	};
}

function hideUIN() {
    $('#iframeSelectUIN').hide();
}

function showUIN() {
    $('#iframeSelectUIN').show().attr('src', 'selectUIN.aspx');
}

$(function() {
    if ($('#<%=radAuto.ClientID%>').get(0).checked) {
        hideUIN();
    } else if ($('#radSelMySelf').get(0).checked) {
        showUIN();
    }
});
	
</script>

<style type="text/css">
#Main{ color:#1e5ea7; }
#Main a{ color:#1e5ea7; }
.tdLeft{ text-align:right; vertical-align:middle; color:#000; font-size:13px; }
.input{ width:300px; height:24px; border:1px solid #1e5ea7; }
.BtnRegister{ border:none; background:url(images/btnRegister.gif) no-repeat; width:103px; height:32px; cursor:pointer; }
</style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
    <asp:HiddenField ID="fhUIN" runat="server" />
    
    <div id="regist">
        <p class="tip1 black4B font14 fb">新注册用户可使用通讯号码、帐号或Email登陆系统</p>
        <ul class="fill_info">
            <li class="zoom">
                <span class="db l form_title font14">选择通讯号码：</span>
                <span class="db l" style="width: 450px;">
                    <asp:RadioButton ID="radAuto" runat="server" Text="系统自动分配" GroupName="number" Checked="true" onclick="hideUIN();" />
                    <asp:RadioButton ID="radSelMySelf" runat="server" Text="我自己选号码" GroupName="number" onclick="showUIN();" />
                    <label class="orange">*</label>
                    <div>
                        <iframe src="" width="100%" height="130px" frameborder="0" scrolling="no" id="iframeSelectUIN" style="display: none;"></iframe>
                    </div>
                </span>
            </li>
            <li class="zoom">
                <span class="db l form_title font14">账号：</span>
                <span class="db l">
                    <asp:TextBox ID="txtLoginName" runat="server" CssClass="input_text"></asp:TextBox><span class="require">
                    <label class="orange">*注意:账号不能全是数字</label>
                    <p class="tip">帐号由大小写字母、数字或下划线组成，长度不能少于6个字符长度且不能大于12个字符</p>
                    <asp:RegularExpressionValidator ID="revLoginName" runat="server" ErrorMessage="请按照格式填写!" ControlToValidate="txtLoginName" ValidationExpression="^[\d\w_]{6,12}$" Display="Dynamic"></asp:RegularExpressionValidator>
                </span>
            </li>
            <li class="zoom">
                <span class="db l form_title font14">E-mail：</span>
                <span class="db l">
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="input_text"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="请填写正确的Email地址"></asp:RegularExpressionValidator>
                    <label class="orange">&nbsp;</label>
                    <p class="tip">忘记密码时可由系统发送新的密码到指定的邮箱而取回密码,也可以订阅网站相关资讯</p>
                </span>
            </li>
            <li class="zoom">
                <span class="db l form_title font14">密码：</span>
                <span class="db l">
                    <asp:TextBox ID="txtLoginPwd" runat="server" TextMode="Password" CssClass="input_text"></asp:TextBox>
                    <label class="orange">*</label>
                </span>
            </li>
            <li class="zoom">
                <span class="db l form_title font14">密码确认：</span>
                <span class="db l">
                    <asp:TextBox ID="txtLoginPwd2" runat="server" TextMode="Password" CssClass="input_text"></asp:TextBox>
                    <label class="orange">*</label>
                </span>
            </li>
            <li class="zoom">
                <span class="db l form_title font14">姓名：</span>
                <span class="db l">
                    <asp:TextBox ID="txtName" runat="server" CssClass="input_text"></asp:TextBox><label class="orange">&nbsp;</label>
                </span>
            </li>
            <li class="zoom">
                <span class="db l form_title font14">联系电话：</span>
                <span class="db l">
                    <asp:TextBox ID="txtTel" runat="server" CssClass="input_text"></asp:TextBox>
                    <label>填写您的联系电话可方便我们及时为您服务</label>
                </span>
            </li>
            <li class="zoom">
                <span class="db l form_title font14">验证码：</span>
                <asp:TextBox ID="txtValidCode" runat="server" Width="50px" CssClass="input_text"></asp:TextBox>
                <img src="ValidateCode.aspx" class="varify_code" width="75ox" height="21px" alt="验证码" />
            </li>
            <li>
                <asp:Button ID="btnSubmit" runat="server" Text="注册" OnClick="btnSubmit_Click" CssClass="btn_blue btn_regist" />
            </li>
            <li class="zoom">
                <span class="orange db l ">注:带 * 表示必填项。</span>
            </li>

        </ul>
    </div>
</asp:Content>
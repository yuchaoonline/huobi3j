<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucHeader.ascx.cs" Inherits="ADeeWu.HuoBi3J.Web.Controls.ucHeader" %>
<%@ Register Src="~/Controls/UserControlPanel.ascx" TagPrefix="uc1" TagName="UserControlPanel" %>

<!--header-->
<div id="header" class="zoom">
    <div class="r topBar">
        <%--<a href="index.html" class="home">首页</a>
        <a href="login.html">会员登录</a><span class="cutOff">|</span><a href="regist.html">注册</a>--%>
        <uc1:UserControlPanel runat="server" ID="UserControlPanel" />
    </div>
    <a class="l logo1" href="index.html">
        <img src="/images/logo.jpg" width="308px" height="61px" alt="全民营销——即时通讯营销平台"></a>
    <img class="l logo2" src="/images/logo_r.jpg" width="428px" height="30px" alt="有网民和企业，就有全民营销">
</div>

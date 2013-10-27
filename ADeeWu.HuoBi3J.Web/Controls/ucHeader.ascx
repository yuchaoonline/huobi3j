<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucHeader.ascx.cs" Inherits="ADeeWu.HuoBi3J.Web.Controls.ucHeader" %>
<%@ Register Src="~/Controls/UserControlPanel.ascx" TagPrefix="uc1" TagName="UserControlPanel" %>

<script type="text/javascript">
    $(function () {
        $('#txtPageSearch').enter($('#btnPageSearchKey'));
        $('#btnPageSearchPrice').click(function () {
            location.href = "/center/searchprice.aspx?keyword=" + $('#txtPageSearch').val();
        })
        $('#btnPageSearchKey').click(function () {
            location.href = "/center/searchkey.aspx?keyword=" + $('#txtPageSearch').val();
        })
    })
</script>
<div id="header" class="zoom">
    <div class="r topBar">
        <%--<a href="index.html" class="home">首页</a>
        <a href="login.html">会员登录</a><span class="cutOff">|</span><a href="regist.html">注册</a>--%>
        <uc1:UserControlPanel runat="server" ID="UserControlPanel" />
    </div>
    <a class="l logo1" href="/index.html">
        <img src="/images/logo.jpg" width="308" height="61" alt="全民营销——即时通讯营销平台"></a>
    <div style="height: 61px; line-height: 61px;">
        <input type="text" id="txtPageSearch" />
        <a href="#" id="btnPageSearchPrice" title="搜价格" class="btn_blue">搜价格</a>
        <a href="#" id="btnPageSearchKey" title="搜关键字" class="btn_blue">搜关键字</a>
        <a href="#" id="currentcity" title="当前城市" class="btn_blue"><%= ADeeWu.HuoBi3J.Web.Class.AccountHelper.City %></a>
    </div>
</div>

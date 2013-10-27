<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucNav.ascx.cs" Inherits="ADeeWu.HuoBi3J.Web.Controls.ucNav" %>

<%--<div id="nav" class="zoom">
    <div class="nav_l l"></div>
    <div class="nav_main l zoom">
        <a class="db l current" href="/groupbuy">即时比价</a>
        <a class="db l" href="/center">即时报价</a>
        <a class="db l" href="/Forum">全民广告</a>
        <a class="db l" href="/Shop">在线营销</a>
        <a class="db l" href="/CorpPromotions">官网搜索</a>
        <a class="db l" href="/Corporations">商企在线</a>
        <a class="db l" href="/Jobs">在线招聘</a>
        <a class="db l" href="/Houses">在线出租</a>
    </div>
    <div class="nav_r r"></div>
</div>
<script>
    //$(function () {
    //    $('.imA').click(function () {
    //        alert('开通该服务请联系客服!');
    //        return false;
    //    })
    //})
    function tips() {
        alert('开通该服务请联系客服!');
        return false;
    }
</script>--%>

<div id="nav" class="zoom">
    <div class="nav_l l"></div>
    <div class="nav_main l zoom">
        <a class="db l current" href="/center/searchhotkey.aspx">热门关键字</a>
        <a class="db l current" href="/center/searchprice.aspx">搜价格</a>
        <a class="db l current" href="/center/searchkey.aspx">搜关键字和商圈</a>
    </div>
</div>

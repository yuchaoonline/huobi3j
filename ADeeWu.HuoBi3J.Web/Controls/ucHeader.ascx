<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucHeader.ascx.cs" Inherits="ADeeWu.HuoBi3J.Web.Controls.ucHeader" %>
<%@ Register Src="~/Controls/UserControlPanel.ascx" TagPrefix="uc1" TagName="UserControlPanel" %>
<style>
    #changeCity li {
            margin: 4px 10px 4px 0;
            vertical-align: top;
            display: inline-block;
        }
            #changeCity li a {
                display: block;
                padding: 0 4px;
                height: 19px;
                border-radius: 2px;
                color: #399;
                text-decoration: none;
            }
        #changeCity li a:hover {
            background-color: #45abab;
            color: #FFF;
        }
</style>
<script type="text/javascript">
    $(function () {
        $('#txtPageSearch').enter($('#btnPageSearchKey'));
        $('#btnPageSearchPrice').click(function () {
            location.href = "/center/searchprice.aspx?keyword=" + $('#txtPageSearch').val();
        })
        $('#btnPageSearchKey').click(function () {
            location.href = "/center/searchkey.aspx?keyword=" + $('#txtPageSearch').val();
        })
        $('#btnPageChangeCity').click(function () {
            $.getJSON('/ajax/center.ashx', { method: 'getcity' }, function (data) {
                var html = "<ul>";
                $.each(data, function (index, item) {
                    html += "<li><a href='/center/changecity.aspx?city=" + item.cname + "' title='" + item.cname + "'>" + item.cname + "</a></li>";
                })
                html += "</ul>";                $('#changeCity').html(html).dialog({
                    title: '切换城市',
                    width: 750,
                    height: 500,
                    modal: true
                });
            })
        })
    })
</script>
<div id="header" class="zoom">
    <div class="r topBar">
        <uc1:UserControlPanel runat="server" ID="UserControlPanel" />
        <br />
        <a href="/My/User/Center/MyAttentionList.aspx" id="btnPageAddPrice" title="发布价格" class="btn_blue">发布价格</a>        
    </div>
    <a class="l logo1" href="/index.html">
        <img src="/images/logo.jpg" width="308" height="61" alt="全民营销——即时通讯营销平台"></a>
    <div style="height: 61px; line-height: 61px;">
        <a href="#" id="btnPageChangeCity" title="点击切换城市"><span style="color: red;"><%= ADeeWu.HuoBi3J.Web.Class.AccountHelper.City %></span>切换城市</a>
        <input type="text" id="txtPageSearch" />
        <a href="#" id="btnPageSearchPrice" title="搜价格" class="btn_blue">搜价格</a>
        <a href="#" id="btnPageSearchKey" title="搜关键字" class="btn_blue">搜关键字</a>
    </div>
    <div id="changeCity"></div>
</div>

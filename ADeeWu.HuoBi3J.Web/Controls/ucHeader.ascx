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

    .currentSelect {
        background-color: #508acb;
        height: 26px;
    }

        .currentSelect a {
            color: #fff !important;
        }

    #header a {
        cursor: pointer;
        color: #3e4545;
    }
</style>
<script type="text/javascript">
    $(function () {
        $('#txtPageSearch').enter($('#btnPageSearch'), function () {
            PageSearch();
            return false;
        });

        $('#btnPageSearch').click(function () {
            PageSearch();
            return false;
        })

        $('#btnPageSearchKey,#btnPageSearchPrice').click(function () {
            SelectSearch($(this));
            return false;
        })

        function PageSearch() {
            var SelectKey = $('.currentSelect:has(a#btnPageSearchKey)');
            if (SelectKey.length > 0) {
                location.href = "/center/searchkey.aspx?keyword=" + $('#txtPageSearch').val();
            } else {
                location.href = "/center/searchprice.aspx?keyword=" + $('#txtPageSearch').val();
            }
            return false;
        }

        function SelectSearch(obj) {
            $('.currentSelect').removeClass('currentSelect');
            obj.parent().addClass('currentSelect');
            return false;
        }

        $('#btnPageChangeCity').click(function () {
            $.getJSON('/ajax/center.ashx', { method: 'getcity' }, function (data) {
                var html = "<ul>";
                $.each(data, function (index, item) {
                    html += "<li><a href='/center/changecity.aspx?city=" + item.cname + "' title='" + item.cname + "'>" + item.cname + "</a></li>";
                })
                html += "</ul>";

                $('#changeCity').html(html).dialog({
                    title: '切换城市',
                    width: 750,
                    height: 500,
                    modal: true
                });
            })

            return false;
        })
    })

    function MM_swapImage() { //v3.0
        var i, j = 0, x, a = MM_swapImage.arguments; document.MM_sr = new Array; for (i = 0; i < (a.length - 2) ; i += 3)
            if ((x = MM_findObj(a[i])) != null) { document.MM_sr[j++] = x; if (!x.oSrc) x.oSrc = x.src; x.src = a[i + 2]; }
    }

    function MM_swapImgRestore() { //v3.0
        var i, x, a = document.MM_sr; for (i = 0; a && i < a.length && (x = a[i]) && x.oSrc; i++) x.src = x.oSrc;
    }

    function MM_findObj(n, d) { //v4.01
        var p, i, x; if (!d) d = document; if ((p = n.indexOf("?")) > 0 && parent.frames.length) {
            d = parent.frames[n.substring(p + 1)].document; n = n.substring(0, p);
        }
        if (!(x = d[n]) && d.all) x = d.all[n]; for (i = 0; !x && i < d.forms.length; i++) x = d.forms[i][n];
        for (i = 0; !x && d.layers && i < d.layers.length; i++) x = MM_findObj(n, d.layers[i].document);
        if (!x && d.getElementById) x = d.getElementById(n); return x;
    }
</script>
<div id="header">
    <div style="width: 950px;">
        <div style="width: 200px; float: left;">
            <a href="/">
                <img src="/images/logo.jpg" width="200" height="80" alt="货比3家"></a>
        </div>
        <div style="width: 750px; height: 36px; float: left;">
            <div style="width: 100%;">
                <div style=" height: 26px; line-height: 26px; float: left;">
                    <div style="height: 18px; width: 330px"></div>
                    <div style="width: 110px; float: left; text-align: center" class="currentSelect"><a id="btnPageSearchPrice">搜索关键字地图</a></div>
                    <div style="width: 110px; float: left; text-align: center"><a id="btnPageSearchKey">搜索关键字</a></div>
                    <div style="width: 110px; float: left; text-align: center"><a style="color: #508acb" href="/center/searchhotkey.aspx">热门关键字</a></div>
                </div>
                <uc1:UserControlPanel runat="server" ID="UserControlPanel" />
            </div>
            <div style="clear:both;"></div>
            <div style="width: 100%; height: 36px;">
                <div style="background-color: #508acb; float: left; width: 450px; height: 28px; padding: 4px 0; text-align: center">
                    <input id="txtPageSearch" style="width: 442px; height: 28px; border: none; padding: 0; font-size: 18px; line-height: 28px;" value="<%=GetKeyword() %>" />
                </div>
                <div style="width: 100px; float: left; color: #508acb;">
                    <a href="#" id="btnPageSearch" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('ss','','/images/ss_1.gif',1)">
                        <img src="/images/ss.gif" width="100" height="36" border="0" id="ss"></a>
                </div>
                <div style="text-align: center;">
                    <a href="/My/User/Center/AddPrice.aspx" title="发布价格">
                        <img src="/images/news.gif" width="123" height="34"></a>
                </div>
            </div>
            <div style="height: 1px;"></div>
        </div>
    </div>
</div>



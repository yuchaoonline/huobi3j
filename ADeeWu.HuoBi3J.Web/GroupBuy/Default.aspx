<%@ Page Title="" Language="C#" MasterPageFile="~/MIndex.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.GroupBuy.Default" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>
<%@ Register Src="~/Controls/Category.ascx" TagPrefix="UserControl" TagName="Category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    返现首页
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="base.css" rel="stylesheet" />
    <link href="overlay.css" rel="stylesheet" />
    <style>
        .mt-hovermark-container .mt-hovermark-item {
            position: relative;
        }

            .mt-hovermark-container .mt-hovermark-item .mt-hovermark-overlay {
                position: absolute;
                display: block;
                top: 0;
                left: 0;
            }
        #citys li {
            margin: 4px 10px 4px 0;
            vertical-align: top;
            display: inline-block;
        }
            #citys li a {
                display: block;
                padding: 0 4px;
                height: 19px;
                border-radius: 2px;
                color: #399;
                text-decoration: none;
            }
        #citys li a:hover {
            background-color: #45abab;
            color: #FFF;
        }
    </style>

    <script>
        $(function () {
            $('#changeCity').click(function () {
                $.getJSON("/ajax/groupbuy.ashx", { method: 'getcity' }, function (data) {
                    var html = "<ul>";
                    $.each(data, function (index, item) {
                        html += "<li><a href='#"+item.id+"' title='"+item.name+"'>"+item.name+"</a></li>";
                    })
                    html += "</ul>";
                    $('#citys').html(html).dialog({
                        title: '切换城市',
                        width: 750,
                        height: 500,
                        modal: true
                    });
                    $('#citys a').click(function () {
                        var href = $(this).attr('href');
                        var id = href.substring(1,href.length);
                        var name = $(this).attr('title');

                        //30天
                        var cookiestr = 'city=' + id + ',' + name;
                        var date = new Date();
                        var ms = 30 * 24 * 3600 * 1000;
                        date.setTime(date.getTime() + ms);
                        cookiestr += "; expires=" + date.toGMTString();
                        document.cookie = cookiestr;

                        location.reload();
                        return false;
                    })
                })
                
                return false;
            })

            function getCookie(objName) {//获取指定名称的cookie的值
                var arrStr = document.cookie.split("; ");
                for (var i = 0; i < arrStr.length; i++) {
                    var temp = arrStr[i].split("=");
                    if (temp[0] == objName) return unescape(temp[1]);
                }
            }


            var city = getCookie('city');
            if (city) {
                $('#currentcity').text(city.split(',')[1]);
            }
        })
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
    <div id="doc" class="">
        <div id="bdw" class="bdw">
            <div id="bd" class="cf">
                <div id="filter">
                    <div class="filter-sortbar-outer-box">
                        <div class="filter-section-wrapper">
                            <div class="filter-label-list filter-section category-filter-wrapper first-filter">
                                <div class="label has-icon"><i></i>搜索：</div>
                                <ul class="inline-block-list">
                                    <li class="item current">
                                        <asp:TextBox ID="txtSearch" runat="server" CssClass="searchText"></asp:TextBox>
                                        <asp:Button ID="btnSearch" runat="server" CssClass="btn_blue" Text="搜索" OnClick="btnSearch_Click" />
                                        <br />
                                        <%--<a href="1.aspx" target="_blank" class="orange" style="text-decoration: underline; display: inline; background-color: #fff;">先消费后结账团购使用流程</a>--%>
                                        <a href="2.aspx" target="_blank" class="orange" style="text-decoration: underline; display: inline; background-color: #fff;">即时比价使用流程</a>
                                        <a href="3.aspx" target="_blank" class="orange" style="text-decoration: underline; display: inline; background-color: #fff;">免费看电影使用流程</a>
                                        <a href="http://wpa.qq.com/msgrd?v=3&uin=1959831331&site=qq&menu=yes" target="_blank" style="text-decoration: underline; display: inline; background-color: #fff; color: red;">联系客服</a>
                                    </li>
                                </ul>
                                <div id="Div1" style="display:none;"></div>
                            </div>
                            <div class="filter-label-list filter-section category-filter-wrapper">
                                <div class="label has-icon"><i></i>城市：</div>
                                <ul class="inline-block-list">
                                    <li class="item current"><a href="#" id="currentcity">佛山市</a></li>
                                    <li class="item"><a href="#" id="changeCity">切换城市</a></li>
                                </ul>
                                <div id="citys" style="display:none;"></div>
                            </div>
                            <div class="filter-label-list filter-section category-filter-wrapper">
                                <div class="label has-icon"><i></i>分类：</div>
                                <ul class="inline-block-list">
                                    <li class="item current"><a href="default.aspx">全部</a></li>
                                    <asp:Repeater ID="rpCategory" runat="server">
                                        <ItemTemplate>
                                            <li class="item"><a href="default.aspx?category=<%#Eval("name") %>"><%#Eval("name") %><span><%#Eval("categorycount") %></span></a></li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </div>
                            <div class="filter-label-list filter-section geo-filter-wrapper">
                                <div class="label has-icon"><i></i>区域：</div>
                                <ul class="inline-block-list">
                                    <li class="item current"><a href="default.aspx">全部</a></li>
                                    <asp:Repeater ID="rpArea" runat="server">
                                        <ItemTemplate>
                                            <li class="item"><a href="default.aspx?aid=<%#Eval("id") %>"><i></i><%#Eval("name") %><span><%#Eval("areacount") %></span></a></li>
                                        </ItemTemplate>
                                    </asp:Repeater>                                    
                                </ul>
                            </div>
                        </div>
                        <div class="sort-bar">
                            <div class="button-strip inline-block">
                                <a href="<%= getUrl("") %>" title="默认排序" class="button-strip-item inline-block button-strip-item-right button-strip-item-checked">
                                    <span class="inline-block button-outer-box">
                                        <span class="inline-block button-content">默认排序</span>
                                    </span>
                                </a>
                                <a href="<%= getUrl("ordercount") %>" title="预订数从高到低" class="button-strip-item inline-block button-strip-item-left button-strip-item-right button-strip-item-desc">
                                    <span class="inline-block button-outer-box">
                                        <span class="inline-block button-content">数量</span>
                                        <span class="inline-block button-img"></span>
                                    </span>
                                </a>
                                <a href="<%= getUrl("price") %>" title="价格从高到低" class="button-strip-item inline-block button-strip-item-left button-strip-item-right button-strip-item-desc">
                                    <span class="inline-block button-outer-box">
                                        <span class="inline-block button-content">价格</span>
                                        <span class="inline-block button-img"></span>
                                    </span>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="content" class="normal-deal-list cf">
                    <asp:Repeater ID="rpProducts" runat="server">
                        <ItemTemplate>
                            <div class="item">
                                <div class="cover">
                                    <a target="_blank" href="details.aspx?productID=<%#Eval("id") %>">
                                        <img width="270" height="189" alt="<%#Eval("title") %>" src="<%#GetPhoto(Eval("photo"))[0] %>"></a>
                                </div>
                                <h3><a target="_blank" href="details.aspx?productID=<%#Eval("id") %>" title="<%#Eval("id") %>">
                                    <span class="xtitle">【<%#Eval("category") %>】<%#Eval("hotplace") %></span><span class="short-title"><%#Eval("title") %></span></a></h3>
                                <p class="detail">
                                    <a rel="nofollow" class="buy" target="_blank" href="details.aspx?productID=<%#Eval("id") %>">去看看</a>
                                    <em class="price num">¥<%# GetDecimal(Eval("price"),1) %></em><br /><span class="bypast">门店价 <span class="num"><span>¥</span><%#GetDecimal( Eval("marketprice"),1) %></span></span></p>
                                <p class="total"><strong class="num"><%#Eval("ordercount") %></strong>人已抢购</p>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <div class="page-nav-wrapper">
                        <%--<div class="pager" align="center">--%>
                            <IscControl:Pager3 ID="Pager1" runat="server"  />
                        <%--</div>--%>
                    </div>
                </div>
            </div>
            <!-- bd end -->
        </div>
        <!-- bdw end -->
    </div>
</asp:Content>

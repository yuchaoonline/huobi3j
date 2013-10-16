<%@ Page Title="" Language="C#" MasterPageFile="~/MIndex.master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.GroupBuy.Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="base.css" rel="stylesheet" />
    <link href="deal.css" rel="stylesheet" />
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
        .buylink {
            -background: url(buylink.jpg) no-repeat !important;
        }
    </style>
    <script src="http://ditu.google.cn/maps?file=api&v=2&key=AIzaSyCjcgNJUDK6ty1JgsR67Usa8xUooJBmflU&sensor=false" type="text/javascript"></script>
    <script type="text/javascript" src="/map/js/markermanager_packed.js"></script>
    <script type="text/javascript" src="/js/isc.js"></script>
    <script type="text/javascript" src="/map/js/GetPosition.html.js"></script>
    <script>
        $(function () {
            $('body').addClass('pg-deal pg-deal-default');
            var locaVal = $('input[name=maplocation]').val();
            var locaVals = locaVal.split(",");
            if (locaVals.length > 2) {
                address = locaVals[2];
                $('#realaddr').html(address);
            }

            enableScrollWheelZoom = false;
            disableDragging = true;
            init(locaVals[0], locaVals[1]);
            $(window).scroll(function () {
                var top = $(document).scrollTop();
                var objTop = $('#deal-stuff').position().top;
                console.log(top < objTop);
                if (top >= objTop) {
                    $('#J-content-navbar').addClass('common-fixed');
                } else {
                    $('#J-content-navbar').removeClass('common-fixed');
                }
            })

            $('.buylink').click(function () {
                window.open($(this).attr('title'), '_blank');
                return false;
            });

            $('.buyover').click(function () {
                alert("活动已结束！");

                return false;
            })
        })

        function ShowSuccess() {
            var html = "订购成功。只需要用手机拍下即时比价券订单照片，到商家消费时，出示照片并显示出消费密码，就可以先消费再付款！<br />"
            + "流程：<br />"
            + "1. 在“即时比价”栏目挑选套餐并点击“抢购”按钮；<br />"
            + "2. 到个人后台“即时比价”，点击“我的订单”，对要消费的订单界面进行拍照（必须拍到消费密码）；<br />"
            + "3. 到商家消费时，出示照片，放大照片显示出消费密码；<br />"
            + "4. 享用套餐后结账。<br />";
            $('#diag_success').empty().html(html).dialog({
                title: '抢购结果',
                width: 750,
                height: 250,
                modal: true,
                buttons: {
                    '确定': function () {
                        $('#diag_success').dialog('close');
                        location.href = '/My/User/GroupBuy/';
                    }
                }
            });
        }
    </script>
    </asp:Content>
    <asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
        <asp:Repeater ID="rpResult" runat="server" OnItemCommand="rpResult_ItemCommand" OnItemDataBound="rpResult_ItemDataBound">
            <ItemTemplate>
                <div id="deal-default">
                    <div id="bdw" class="bdw">
                        <div id="bd" class="cf">
                            <div class="bread-nav">
                                <a href="default.aspx">返现首页</a>
                                <span>»</span><%#Eval("title") %></div>
                            <div id="content">
                                <div id="deal-intro" class="cf">
                                    <div class="deal-brand">
                                        【<%#Eval("category") %>】<h1 class="inline-block"><%#Eval("hotplace") %></h1>
                                        <h2 class="deal-title"><%#Eval("title") %></h2>
                                    </div>
                                    
                                    <div class="main">
                                        <div class="deal-discount">
                                            <span class="price"><span class="symbol-RMB">¥</span> <%#GetDecimal(Eval("price"),1) %></span>
                                            <span class="original">门店价
                                                <span class="discount-price">¥<%#GetDecimal(Eval("marketprice"),1) %></span><span class="discount-text"><%# GetSaleOff(Eval("marketprice"),Eval("price")) %></span></span></div>
                                        <div class="deal-info">
                                            <div class="deal-buy  deal-price-tag-open">
                                                <asp:LinkButton ID="btnOrder" runat="server" CommandName="order" CommandArgument='<%# Eval("id") %>' Visible="false">抢购</asp:LinkButton>
                                                <asp:LinkButton ID="btnBuyLink" runat="server" ToolTip='<%# Eval("buylink") %>' CssClass="buylink" Visible="false">即时比价</asp:LinkButton>
                                                <asp:LinkButton ID="btnOver" runat="server" CssClass="buyover" Visible="false">已结束</asp:LinkButton>
                                                <asp:Literal ID="litResult" runat="server"></asp:Literal>
                                            </div>
                                            <div class="deal-status">
                                                <p class="deal-status-count"><strong><%#Eval("ordercount") %></strong> 人已抢购</p>
                                                <p class="deal-status-time-left deal-on" id="deal-timeleft-7418009">剩余<span><strong><%# GetOverDay(Eval("passdate"),Eval("saleday")) %></strong>天以上</span></p>
                                            </div>
                                            <ul class="consumer-protection">
                                                <li class="protect-item protect-item--anytime">
                                                    <a href="#" title="支持 “先消费后付款”"><span class="icon protect-item__icon">&nbsp;</span>先消费后付款</a>
                                                </li>
                                                <li class="protect-item protect-item--expire">
                                                    <a href="#" title="支持 “团购折上折”"><span class="icon protect-item__icon">&nbsp;</span>团购折上折</a>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                    <div class="deal-buy-cover-img">
                                        <img alt="<%#Eval("category") %>" width="462" height="280" src="<%#Eval("photo") %>">
                                    </div>
                                </div>
                                <div id="J-content-navbar" class="content-navbar">
                                    <ul class="cf">
                                        <li class="left-corner"></li>
                                        <li><a class="tab-item" href="#anchor-detail">本单详情</a></li>
                                        <li><a class="tab-item" href="#anchor-remind">温馨提示</a></li>
                                        <li><a class="tab-item" href="#anchor-intro">产品介绍</a></li>
                                        <li><a class="tab-item" href="#business-info">商家介绍</a></li>
                                        <li><a class="tab-item" href="#anchor-address">商家地址</a></li>
                                        <li class="right-corner"></li>
                                    </ul>
                                </div>
                                <div id="deal-stuff">
                                    <div class="mainbox cf">
                                        <div class="main">
                                            <h2 class="content-title" id="anchor-detail">本单详情</h2>
                                            <div class="blk detail">
                                                <%#Eval("detail") %>
                                            </div>
                                            <h2 class="content-title" id="anchor-remind">温馨提示</h2>
                                            <div class="blk detail">
                                                <%#Eval("remind") %>
                                            </div>
                                            <h2 class="content-title" id="anchor-intro">产品介绍</h2>
                                            <div class="blk detail">
                                                <%#Eval("productintro") %>
                                            </div>
                                            <h2 class="content-title" id="business-info">商家介绍</h2>
                                            <div class="blk detail">
                                                <%#Eval("sellerintro") %>
                                            </div>
                                            <h2 class="content-title" id="anchor-address">商家地址</h2>
                                            <div id="side-business" class="cf blk detail">
                                                <div class="address-list cf">
                                                    <div class="left-content">
                                                        <div class="mapbody">
                                                            <input type="hidden" class="maplocation" name="maplocation" value="<%#Eval("maplocation") %>" />
                                                            <div id="map_canvas" style="width: 560px; height: 400px;"></div>
                                                        </div>
                                                    </div>
                                                    <div class="biz-wrapper biz-wrapper-nobottom">
                                                        <div class="all-biz cf">
                                                            <div class="biz-info biz-info--open biz-info--first biz-info--only" id="yui_3_8_0_1">
                                                                <div class="biz-item"><label class="title-label">商家名称：</label><%# Eval("corpname") %></div>
                                                                <div class="biz-item"><label class="title-label">商家地址：</label><span id="realaddr"></span></div>
                                                                <div class="biz-item"><label class="title-label">商家电话：</label><%# Eval("tel") %></div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="deal-buy-bottom">
                                            <span class="price num">¥<%#GetDecimal(Eval("price"),1) %></span>
                                            <asp:LinkButton ID="btnOrder2" runat="server" CommandName="order" CommandArgument='<%#Eval("id")%>' Visible="false">抢购</asp:LinkButton>
                                            <asp:LinkButton ID="btnBuyLink2" runat="server" ToolTip='<%# Eval("buylink") %>' CssClass="buylink" Visible="false">即时比价</asp:LinkButton>
                                            <asp:LinkButton ID="btnOver2" runat="server" CssClass="buyover" Visible="false">已结束</asp:LinkButton>
                                            <ul class="cf">
                                                <li>门店价<br>
                                                    <del class="num"><span>¥</span><%#GetDecimal(Eval("marketprice"),1) %></del></li>
                                                <li>折扣<br>
                                                    <span class="num"><%# GetSaleOff(Eval("marketprice"),Eval("price")) %></span></li>
                                                <li>已抢购<br>
                                                    <span class="num"><%#Eval("ordercount") %>人</span></li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div id="diag_success"></div>
</asp:Content>

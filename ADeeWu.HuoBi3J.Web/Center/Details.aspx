<%@ Page Title="" Language="C#" MasterPageFile="~/MIndex.master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Center.Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <%--<link href="/css/base.css" rel="stylesheet" />--%>
    <link href="/css/deal.css" rel="stylesheet" />
    <link href="/css/overlay.css" rel="stylesheet" />
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

        .STYLE6 {
            font-size: 36px;
            font-weight: bold;
            color: #000000;
        }

        .STYLE7 {
            font-size: 24px;
            font-family: "黑体";
            font-weight: bold;
            color: #777777;
        }

        .STYLE8 {
            font-family: "黑体";
        }

        .STYLE9 {
            font-family: Arial;
            font-size: 24px;
            font-weight: bold;
            color: #ff9801;
        }

        .STYLE10 {
            font-family: Arial;
            font-size: 60px;
            color: #ff9801;
            font-weight: bold;
        }
    </style>
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=D10a875567626012d06af2387efa088e"></script>
    <script type="text/javascript">
        $(function () {
            $('body').addClass('pg-deal pg-deal-default');

            $(window).scroll(function () {
                var top = $(document).scrollTop();
                var objTop = $('#deal-stuff').position().top;
                if (top >= objTop) {
                    $('#J-content-navbar').addClass('common-fixed');
                } else {
                    $('#J-content-navbar').removeClass('common-fixed');
                }
            })

            $('.add_fav').click(function () {
                var userid = $(this).attr('href');
                userid = userid.substring(1, userid.length);
                $.getJSON('/ajax/center.ashx', { method: 'addfav', userid: userid }, function (data) {
                    if (data && data.statue) {
                        alert('收藏成功！');
                    } else {
                        alert(data.msg);
                    }
                })

                return false;
            })

            var map = new BMap.Map("allmap");

            var initPoint = new BMap.Point(23.027705, 113.12843);
            var existVal = $('.maplocation').val();
            if (existVal != '') {
                var a = existVal.split("|");
                initPoint = new BMap.Point(a[1], a[0]);
            }

            map.disableDragging();
            map.centerAndZoom(initPoint, 18);
            map.addOverlay(new BMap.Marker(initPoint));

        })
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
    <asp:Repeater ID="rpResult" runat="server" OnItemDataBound="rpResult_ItemDataBound">
        <ItemTemplate>
            <div id="deal-default">
                <div id="bdw" class="bdw">
                    <div id="bd" class="cf">
                        <div class="bread-nav" style="margin-bottom: 10px;">
                            <a href="default.aspx">返现首页</a>
                            <span>»</span>
                            <a href="key4product.aspx?kid=<%# Eval("kid") %>"><%#Eval("kname") %></a>
                            <span>»</span>
                            <%# Eval("simpledesc") %>
                        </div>
                        <div id="content">
                            <div id="deal-intro" class="cf">
                                <div class="main">
                                    <span class="STYLE9">￥</span>
                                    <span class="STYLE10">8.00</span>
                                </div>
                                <div class="deal-brand" style="margin-bottom: 15px;">
                                    【<%#Eval("kname") %>】<span class="inline-block STYLE6"><%#Eval("simpledesc") %></span>
                                    <a href="#<%# Eval("createuserid") %>" style="float: right;" class="add_fav btn_blue">收藏</a>
                                    <br />
                                    <span class="inline-block STYLE7" style="padding-left: 15px;">商家名称：<%#Eval("companyname") %></span>
                                </div>
                            </div>
                            <div id="J-content-navbar" class="content-navbar">
                                <ul class="cf">
                                    <li class="left-corner"></li>
                                    <li><a class="tab-item" href="#anchor-detail">报价详情</a></li>
                                    <li><a class="tab-item" href="#business-info">商家介绍</a></li>
                                    <li><a class="tab-item" href="#anchor-address">商家地址</a></li>
                                    <li><a class="tab-item" href="#anchor-other">商家其他价格信息</a></li>
                                    <li class="right-corner"></li>
                                </ul>
                            </div>
                            <div id="deal-stuff">
                                <div class="mainbox cf">
                                    <div class="main">
                                        <h2 class="content-title" id="anchor-detail">报价详情</h2>
                                        <div class="blk detail">
                                            <%#Eval("Description") %>
                                        </div>
                                        <h2 class="content-title" id="business-info">商家介绍</h2>
                                        <div class="blk detail">
                                            <%#Eval("memo") %>
                                        </div>
                                        <h2 class="content-title" id="anchor-address">商家地址</h2>
                                        <div id="side-business" class="cf blk detail">
                                            <div class="address-list cf">
                                                <div class="left-content">
                                                    <div class="mapbody">
                                                        <input type="hidden" class="maplocation" value="<%#Eval("PositionX") %>|<%#Eval("PositionY") %>" />
                                                        <div id="allmap" style="width: 555px; height: 400px;"></div>
                                                    </div>
                                                </div>
                                                <div class="biz-wrapper biz-wrapper-nobottom">
                                                    <div class="all-biz cf">
                                                        <div class="biz-info biz-info--open biz-info--first biz-info--only" id="yui_3_8_0_1">
                                                            <div class="biz-item">
                                                                <label class="title-label">商家名称：</label><%# Eval("companyname") %>
                                                            </div>
                                                            <div class="biz-item">
                                                                <label class="title-label">商家地址：</label><%# Eval("companyaddress") %>
                                                            </div>
                                                            <div class="biz-item">
                                                                <label class="title-label">商家电话：</label><%# Eval("phone") %>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <h2 class="content-title" id="anchor-other">商家其他价格信息</h2>
                                        <div class="blk detail">
                                            <div id="searchResult">
                                                <asp:Repeater ID="rpOtherPrice" runat="server">
                                                    <HeaderTemplate>
                                                        <table id="rentP_list1" width="100%" class="table_list" cellpadding="0" cellspacing="0">
                                                            <thead>
                                                                <tr height="30px" class="black70">
                                                                    <td width="20%" class="arc_title">价格</td>
                                                                    <td width="30%">简单描述</td>
                                                                    <td width="17%">关键字</td>
                                                                    <td width="17%">所在商圈</td>
                                                                    <td width="16%">查看</td>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr height="40px" onmouseover="this.className='jobMenu_hover'" onmouseout="this.className=''" class="">
                                                            <td class="arc_title"><%# GetDecimal(Eval("price"),2) %></td>
                                                            <td><%# Eval("simpledesc") %></td>
                                                            <td><a href="key4product.aspx?kid=<%# Eval("kid") %>"><%# Eval("kname") %></a></td>
                                                            <td><%# ADeeWu.HuoBi3J.Web.Class.Helper.GetBusinessCircle(Eval("bid"),Eval("bname")) %></td>
                                                            <td><a href="Details.aspx?id=<%# Eval("id") %>" class="btn_blue" target="_blank">查看</a></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        </tbody>
                                                        </table>
                                                    </FooterTemplate>
                                                </asp:Repeater>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>

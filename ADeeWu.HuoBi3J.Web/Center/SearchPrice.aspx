<%@ Page Language="C#" Title="" MasterPageFile="~/MIndex.master" AutoEventWireup="true" CodeBehind="SearchPrice.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Center.SearchPrice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    货比三家 - 货比三家 - 搜索价格
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
    <style type="text/css">
        #l-map {
            margin-right: 300px;
            height: 550px;
            width: 650px;
        }

        #result {
            width: 290px;
            position: absolute;
            top: 10px;
            right: 0px;
            font-size: 12px;
            height: 550px;
            overflow-y: auto;
            overflow-x: hidden;
        }

        #searchResult th {
            background-color: #508acb;
            color: #fff;
            height: 24px;
        }

        #searchResult tr:hover {
            cursor: pointer;
            background-color: #eee;
        }

        .pagination {
            margin: 10px 0;
        }

            .pagination ul {
                display: inline-block;
                *display: inline;
                margin-bottom: 0;
                margin-left: 0;
                -webkit-border-radius: 4px;
                -moz-border-radius: 4px;
                border-radius: 4px;
                *zoom: 1;
                -webkit-box-shadow: 0 1px 2px rgba(0, 0, 0, 0.05);
                -moz-box-shadow: 0 1px 2px rgba(0, 0, 0, 0.05);
                box-shadow: 0 1px 2px rgba(0, 0, 0, 0.05);
            }

                .pagination ul > li {
                    display: inline;
                }

                    .pagination ul > li > a,
                    .pagination ul > li > span {
                        float: left;
                        padding: 4px 12px;
                        line-height: 20px;
                        text-decoration: none;
                        background-color: #ffffff;
                        border: 1px solid #dddddd;
                        border-left-width: 0;
                    }

                        .pagination ul > li > a:hover,
                        .pagination ul > li > a:focus,
                        .pagination ul > .active > a,
                        .pagination ul > .active > span {
                            background-color: #f5f5f5;
                        }

                .pagination ul > .active > a,
                .pagination ul > .active > span {
                    color: #999999;
                    cursor: default;
                }

                .pagination ul > .disabled > span,
                .pagination ul > .disabled > a,
                .pagination ul > .disabled > a:hover,
                .pagination ul > .disabled > a:focus {
                    color: #999999;
                    cursor: default;
                    background-color: transparent;
                }

                .pagination ul > li:first-child > a,
                .pagination ul > li:first-child > span {
                    border-left-width: 1px;
                    -webkit-border-bottom-left-radius: 4px;
                    border-bottom-left-radius: 4px;
                    -webkit-border-top-left-radius: 4px;
                    border-top-left-radius: 4px;
                    -moz-border-radius-bottomleft: 4px;
                    -moz-border-radius-topleft: 4px;
                }

                .pagination ul > li:last-child > a,
                .pagination ul > li:last-child > span {
                    -webkit-border-top-right-radius: 4px;
                    border-top-right-radius: 4px;
                    -webkit-border-bottom-right-radius: 4px;
                    border-bottom-right-radius: 4px;
                    -moz-border-radius-topright: 4px;
                    -moz-border-radius-bottomright: 4px;
                }

        .pagination-centered {
            text-align: center;
        }

        .pagination-right {
            text-align: right;
        }

        .pagination-large ul > li > a,
        .pagination-large ul > li > span {
            padding: 11px 19px;
            font-size: 17.5px;
        }

        .pagination-large ul > li:first-child > a,
        .pagination-large ul > li:first-child > span {
            -webkit-border-bottom-left-radius: 6px;
            border-bottom-left-radius: 6px;
            -webkit-border-top-left-radius: 6px;
            border-top-left-radius: 6px;
            -moz-border-radius-bottomleft: 6px;
            -moz-border-radius-topleft: 6px;
        }

        .pagination-large ul > li:last-child > a,
        .pagination-large ul > li:last-child > span {
            -webkit-border-top-right-radius: 6px;
            border-top-right-radius: 6px;
            -webkit-border-bottom-right-radius: 6px;
            border-bottom-right-radius: 6px;
            -moz-border-radius-topright: 6px;
            -moz-border-radius-bottomright: 6px;
        }

        .pagination-mini ul > li:first-child > a,
        .pagination-small ul > li:first-child > a,
        .pagination-mini ul > li:first-child > span,
        .pagination-small ul > li:first-child > span {
            -webkit-border-bottom-left-radius: 3px;
            border-bottom-left-radius: 3px;
            -webkit-border-top-left-radius: 3px;
            border-top-left-radius: 3px;
            -moz-border-radius-bottomleft: 3px;
            -moz-border-radius-topleft: 3px;
        }

        .pagination-mini ul > li:last-child > a,
        .pagination-small ul > li:last-child > a,
        .pagination-mini ul > li:last-child > span,
        .pagination-small ul > li:last-child > span {
            -webkit-border-top-right-radius: 3px;
            border-top-right-radius: 3px;
            -webkit-border-bottom-right-radius: 3px;
            border-bottom-right-radius: 3px;
            -moz-border-radius-topright: 3px;
            -moz-border-radius-bottomright: 3px;
        }

        .pagination-small ul > li > a,
        .pagination-small ul > li > span {
            padding: 2px 10px;
            font-size: 11.9px;
        }

        .pagination-mini ul > li > a,
        .pagination-mini ul > li > span {
            padding: 0 6px;
            font-size: 10.5px;
        }

        .pager {
            margin: 20px 0;
            text-align: center;
            list-style: none;
            *zoom: 1;
        }

            .pager:before,
            .pager:after {
                display: table;
                line-height: 0;
                content: "";
            }

            .pager:after {
                clear: both;
            }

            .pager li {
                display: inline;
            }

                .pager li > a,
                .pager li > span {
                    display: inline-block;
                    padding: 5px 14px;
                    background-color: #fff;
                    border: 1px solid #ddd;
                    -webkit-border-radius: 15px;
                    -moz-border-radius: 15px;
                    border-radius: 15px;
                }

                    .pager li > a:hover,
                    .pager li > a:focus {
                        text-decoration: none;
                        background-color: #f5f5f5;
                    }

            .pager .next > a,
            .pager .next > span {
                float: right;
            }

            .pager .previous > a,
            .pager .previous > span {
                float: left;
            }

            .pager .disabled > a,
            .pager .disabled > a:hover,
            .pager .disabled > a:focus,
            .pager .disabled > span {
                color: #999999;
                cursor: default;
                background-color: #fff;
            }
    </style>
    <script type="text/javascript" src="/JS/jquery.pager.js"></script>
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=xgLsN99uIaoe9vmqb5wGbt7F"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
    <div id="l-map"></div>
    <div id="result">
        <table id="searchResult"></table>
        <div id="mapPager" class="pagination text-center"></div>
    </div>

    <script type="text/javascript">
        var map = new BMap.Map("l-map");
        var points = [];
        map.centerAndZoom('<%=ADeeWu.HuoBi3J.Web.Class.AccountHelper.City%>', 14);
        map.enableScrollWheelZoom();
        map.addControl(new BMap.NavigationControl());
        var customLayer;
        function addCustomLayer(keyword) {
            if (customLayer) {
                map.removeTileLayer(customLayer);
            }
            customLayer = new BMap.CustomLayer({
                geotableId: <%=ADee.Project.LBS.Common.ConfigHelper.GeoProductTableID%>,
                q: keyword,
                //tags: keyword,
                //filter: ''
            });
            map.addTileLayer(customLayer);
            customLayer.addEventListener('hotspotclick', function (e) {
                showInfo(e.content);
            });
        }

        function searchAction(keyword, page) {
            page = page || 1;
            var filter = [];

            var url = "http://api.map.baidu.com/geosearch/v3/local?callback=?";
            $.getJSON(url, {
                'q': keyword,
                //'tags': keyword,
                'page_index': page - 1,
                //'page_size': 10,
                'filter': filter.join('|'),
                'sortby': 'Price:1',
                //'region': '<%=ADeeWu.HuoBi3J.Web.Class.AccountHelper.City%>',
                'geotable_id': <%=ADee.Project.LBS.Common.ConfigHelper.GeoProductTableID%>,
                'ak': 'xgLsN99uIaoe9vmqb5wGbt7F'
            }, function (e) {
                renderMap(keyword ,e, page);
            });

            addCustomLayer(keyword);
        }

        function renderMap(keyword, res, page) {
            var content = res.contents;
            $('#searchResult').html('');
            map.clearOverlays();
            points.length = 0;

            if (content.length == 0) {
                $('#searchResult').append($('<p style="border-top:1px solid #DDDDDD;padding-top:10px;text-align:center;text-align:center;font-size:18px;" class="text-warning">抱歉，没有找到您想要的信息，请重新查询</p>'));
                return;
            }

            $('#searchResult').append($('<tr><th colspan="2">搜索结果</th></tr>'));
            $.each(content, function (i, item) {
                var point = new BMap.Point(item.location[0], item.location[1]),
                    marker = new BMap.Marker(point);
                points.push(point);
                var tr = $("<tr><td width='90%'><a style='color: blue;' target='_blank' href='Details.aspx?id=" + item.uid + "'>" + item.title + "<a/><br />关键字：<a href='key4product.aspx?kid=" + item.KID + "' target='_blank' style='color: blue;'>" + item.KName + "</a><br />商家：<a href='SaleMan4Product.aspx?userid=" + item.CreateUserID + "' target='_blank' style='color: blue;'>" + item.CompanyName + "</a><br />地址：" + item.address + "<br />电话： " + item.Phone + "</td><td width='10%'><span style='color:red;'>￥" + item.Price + "<br/></span></td></tr>").click(function () {
                    showInfo(item);
                });
                $('#searchResult').append(tr);;
                marker.addEventListener('click', function () {
                    showInfo(item);
                });
                map.addOverlay(marker);
            })

            var pagecount = Math.ceil(res.total / 10);
            InitPager(keyword, page, pagecount);

            map.setViewport(points);
        }

        function InitPager(keyword, page, pagecount) {
            $('#mapPager').pager({
                pagenumber: page,
                pagecount: pagecount,
                showcount: 3,
                buttonClickCallback: function (pageclickednumber) {
                    //InitPager(page, pagecount);
                    searchAction(keyword, pageclickednumber);
                }
            })
        }

        function showInfo(item) {
            var content = "<table>" +
                        "<tr><td>关键字：</td><td><a href='key4product.aspx?kid=" + item.KID + "' target='_blank' style='color: blue;'>" + item.KName + "</a></td>" +
                        "<tr><td>商家：</td><td><a href='SaleMan4Product.aspx?userid=" + item.CreateUserID + "' target='_blank' style='color: blue;'>" + item.CompanyName + "</a></td>" +
                        "<tr><td>价格：</td><td><font color='red'>￥" + item.Price + "</font></td>" +
						"<tr><td>地址：</td><td>" + item.address + "</td>" +
                        "<tr><td>电话：</td><td>" + item.Phone + "</td>" +
						"</table>"
            var infoWindow = new BMap.InfoWindow(content, {
                width: 400,
                //height: 60,
                title: '<a href="Details.aspx?id=' + item.uid + '" target="_blank"  style="color: blue;"/>' + item.title + '</a>',
                enableMessage: false,
                enableAutoPan: true
            });
            var point = new BMap.Point(item.location[0], item.location[1]);
            map.openInfoWindow(infoWindow, point);
        }

        searchAction('<%=Request["Keyword"]%>');
    </script>
</asp:Content>

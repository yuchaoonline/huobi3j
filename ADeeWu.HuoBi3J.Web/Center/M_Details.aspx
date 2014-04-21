<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="M_Details.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Center.M_Details" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="ADeeWuControl" %>

<!DOCTYPE html>
<html>
<head>
    <title>报价详情 - 货比三家</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <link href="/css/bootstrap.min.css" rel="stylesheet">
    <link href="/CSS/bootstrap-theme.min.css" rel="stylesheet" />
    <style type="text/css">
        body {
            padding-top: 70px;
        }
        .panel-body img{
            max-width: 80%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-default navbar-fixed-top" role="navigation">
            <div class="navbar-header">
                <h4><span style="color: #428bca;">货比<span style="color: #f0ad4e">三</span>家</span><small>——身边价格，一目了然</small></h4>
            </div>
        </nav>
        <div class="container">
            <asp:Repeater ID="rpProduct" runat="server" OnItemDataBound="rpProduct_ItemDataBound">
                <ItemTemplate>
                    <div class="panel panel-primary">
                        <div class="panel-heading">报价</div>
                        <div class="panel-body" style="font-weight: bold; font-size: 1.2em;"><span style="font-size: 2em;background-color: #f0ad4e;" class="badge label-warning"><%# GetDecimal(Eval("price"),2) %></span>【<%# Eval("kname") %>】<%# Eval("title") %></div>                     
                    </div>

                    <div class="panel panel-primary">
                        <div class="panel-heading">报价详情</div>
                        <div class="panel-body"><%#Decode(Eval("Description")) %></div>
                    </div>

                    <div class="panel panel-primary">
                        <div class="panel-heading">商家介绍</div>
                        <div class="panel-body"><%#Decode(Eval("SalemanMemo")) %></div>
                    </div>

                    <div class="panel panel-primary">
                        <a href="#" class="list-group-item active">商家地址</a>
                        <p class="list-group-item">商家名称：<%# Eval("companyname") %></p>
                        <p class="list-group-item">商家地址：<%# Eval("address") %></p>
                        <p class="list-group-item">商家电话：<%# Eval("phone") %></p>
                    </div>

                    <div class="panel panel-primary">
                        <div class="panel-heading">商家其他价格信息</div>
                        <table class="table">
                            <tr>
                                <th>价格</th>
                                <th>简单描述</th>
                                <th>关键字</th>
                            </tr>
                            <asp:Repeater ID="rpOtherPrice" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><a href="M_Details.aspx?id=<%# Eval("uid") %>"><%# GetDecimal(Eval("price"),2) %></a></td>
                                        <td><a href="M_Details.aspx?id=<%# Eval("uid") %>"><%# Eval("title") %></a></td>
                                        <td><%# Eval("kname") %></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                            <tr>
                                <td colspan="3">
                                    <ADeeWuControl:Pager3 ID="Pager1" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

        <script src="/js/jquery.js"></script>
        <script src="/js/bootstrap.min.js"></script>
    </form>
</body>
</html>


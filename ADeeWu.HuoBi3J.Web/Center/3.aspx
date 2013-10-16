<%@ Page Title="" Language="C#" MasterPageFile="~/MIndex.master" AutoEventWireup="true" CodeBehind="3.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Center._3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        ul.dd {
            font-size: 14px;
        }

        ul.dd li {
            margin-top: 25px;
        }

        ul.dd li a {
            color: #0066cc;
        }

        ul.dd li img {
            margin: 10px 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
    <h2>用户领取现金赠送流程</h2>
    <ul class="dd">
        <li>
            1. 网站上进行询价。具体操作请看： <a href="http://www.ADeeWu.HuoBi3J.com/center/1.aspx">http://www.ADeeWu.HuoBi3J.com/center/1.aspx</a>
        </li>
        <li>
            2. 到有赠送券商家处取得现金赠送券。
        </li>
        <li>
            3. 点击进入后台控制面板页面，点击“现金赠送券兑换”申请。网址：<a href="http://www.ADeeWu.HuoBi3J.com/My/User/CashTickets/Application.aspx">http://www.ADeeWu.HuoBi3J.com/My/User/CashTickets/Application.aspx</a>
            <br />
            <img src="3.3.png" />
        </li>
        <li>
            4. 后台点击“申请转账”，联系客服人员取出。网址：<a href="http://www.ADeeWu.HuoBi3J.com/My/User/TransferApplications/Application.aspx">http://www.ADeeWu.HuoBi3J.com/My/User/TransferApplications/Application.aspx</a>
            <br />
            <img src="3.4.png" />
        </li>
    </ul>
</asp:Content>

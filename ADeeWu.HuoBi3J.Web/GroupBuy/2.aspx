<%@ Page Title="" Language="C#" MasterPageFile="~/MIndex.master" AutoEventWireup="true" CodeBehind="2.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.GroupBuy._2" %>

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
    <h2>即时比价使用流程</h2>
    <ul class="dd">
        <li>
            1. 注册成为网站个人会员。
        </li>
        <li>
            2. 在“即时比价”栏目下的分类里点击“比价优惠”。网址：<a href="http://www.ADeeWu.HuoBi3J.com/groupbuy/default.aspx?category=%E6%AF%94%E4%BB%B7%E4%BC%98%E6%83%A0">http://www.ADeeWu.HuoBi3J.com/groupbuy/default.aspx?category=%E6%AF%94%E4%BB%B7%E4%BC%98%E6%83%A0</a><br />
            <img src="2.2.png" />
        </li>
        <li>
            3. 点击“即时比价”。<br />
            <img src="2.3.png" />
        </li>
        <li>
            4. 进入询价页面，输入询价内容，按提交键。<br />
            <img src="2.4.png" />
        </li>
        <li>
            5. 点击进入后台控制面板页面，等待商家回复。商家回复后，页面右上角和“我的提问”均有数字回复提示。<br />
            <img src="2.5.png" />
        </li>
        <li>
            6. 点击数字回复提示，进入查看信息页面，可以看到商家回复内容。<br />
            <img src="2.6.png" />
        </li>
        <li>
            7. 点击回复人查看回复人信息。<br />
            <img src="2.7.png" />
        </li>
    </ul>
</asp:Content>


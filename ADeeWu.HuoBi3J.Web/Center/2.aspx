<%@ Page Title="" Language="C#" MasterPageFile="~/MIndex.master" AutoEventWireup="true" CodeBehind="2.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Center._2" %>

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
    <h2>商家报价使用流程</h2>
    <ul class="dd">
        <li>1. 打开注册页面，注册成为网站个人会员。网址：<a href="http://www.ADeeWu.HuoBi3J.com/Register.aspx">http://www.ADeeWu.HuoBi3J.com/Register.aspx</a><br />
            <span class="orange">举例</span>：个人注册账号“fsmingpian”。<br />
            <img src="images/2.1.jpg" />
        </li>
        <li>2. 后台点击进入“申请关注关键字”页面申请开通服务。网址：<a href="http://www.ADeeWu.HuoBi3J.com/My/User/Center/RegSaleMan.aspx">http://www.ADeeWu.HuoBi3J.com/My/User/Center/RegSaleMan.aspx</a> 申请时联系客服人员开通，客服QQ：1959831331。<br />
            <img src="images/2.2.jpg" />
        </li>
        <li>3. 重新登录，点击进入“货比三家”页面，在搜索框输入要申请的产品或服务。网址：<a href="http://www.ADeeWu.HuoBi3J.com/center/">http://www.ADeeWu.HuoBi3J.com/center/</a>
            <br />
            <span class="orange">举例</span>：会员fsmingpian想开通印名片报价服务，可以输入“印名片”，按搜索键。<br />
            <img src="images/2.3.jpg" />
        </li>
        <li>4. 从搜索结果点击进入询价提问页面，点击“关注”，并确认。网址：<a href="http://www.ADeeWu.HuoBi3J.com/center/QuestionList.aspx?kid=44837">http://www.ADeeWu.HuoBi3J.com/center/QuestionList.aspx?kid=44837</a>
            <br />
            <img src="images/2.4.jpg" />
        </li>
        <li>5. 点击进入后台控制面板页面，等待商家回复。商家回复后，页面在右上角和“我收到的提问”均有回复提示。网址：<a href="http://www.ADeeWu.HuoBi3J.com/My/User/">http://www.ADeeWu.HuoBi3J.com/My/User/</a>
            <br />
            <img src="images/2.5.jpg" />
        </li>
        <li>6. 点击数字回复提示，进入查看信息页面，在输入框输入内容，回复给消费者。<br />
            <img src="images/2.6.jpg" />
        </li>
    </ul>
</asp:Content>

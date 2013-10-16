<%@ Page Title="" Language="C#" MasterPageFile="~/MIndex.master" AutoEventWireup="true" CodeBehind="1.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Center._1" %>

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
    <h2>消费者即时获得商家报价流程</h2>
    <ul class="dd">
        <li>1. 打开注册页面，注册成为网站个人会员。网址：<a href="http://www.ADeeWu.HuoBi3J.com/Register.aspx">http://www.ADeeWu.HuoBi3J.com/Register.aspx</a><br />
            <span class="orange">举例</span>：个人注册账号“allsels”。<br />
            <img src="images/1.jpg" />
        </li>
        <li>2. 点击进入“即时报价”页面，在搜索框输入要搜索的产品或服务。网址：<a href="http://www.ADeeWu.HuoBi3J.com/center ">http://www.ADeeWu.HuoBi3J.com/center/</a><br />
            <span class="orange">举例</span>：会员allsels想印名片，可以输入“印名片”，按确认键。<br />
            <img src="images/2.jpg" />
        </li>
        <li>3. 从搜索结果点击进入询价页面，输入询价内容，按提交键。
网址：<a href="http://www.ADeeWu.HuoBi3J.com/center/QuestionList.aspx?kid=44837">http://www.ADeeWu.HuoBi3J.com/center/QuestionList.aspx?kid=44837</a><br />
            <span class="orange">举例</span>：会员allsels在输入框输入“300克铜版纸，彩色双面过膜，5盒名片多少钱？”<br />
            <img src="images/3.jpg" />
        </li>
        <li>4. 点击进入后台控制面板页面，等待商家回复。商家回复后，页面右上角和“我的提问”均有数字回复提示。
网址：<a href="http://www.ADeeWu.HuoBi3J.com/My/User/">http://www.ADeeWu.HuoBi3J.com/My/User/</a><br />
            <img src="images/4.jpg" />
        </li>
        <li>5. 点击数字回复提示，进入查看信息页面，可以看到商家回复内容。<br />
            <img src="images/5.jpg" />
        </li>
        <li>6. 点击回复人查看回复人信息。<br />
            <img src="images/6.jpg" /></li>
    </ul>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/MIndex.master" AutoEventWireup="true" CodeBehind="1.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.GroupBuy._1" %>

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
    <h2>先消费后结账团购使用流程</h2>
    <ul class="dd">
        <li>
            1. 注册成为网站个人会员。
        </li>
        <li>
            2. 在“即时比价”栏目挑选套餐并点击“抢购”按钮。<br />
            <img src="1_2.png" />
        </li>
        <li>
            3. 到个人后台“即时比价”，点击“我的订单”，对要消费的订单界面进行拍照（必须拍到消费密码）。<br />
            <img src="1_3.png" />
        </li>
        <li>
            4. 到商家消费时，出示照片，放大照片显示出消费密码，告知商家套餐内容。
        </li>
        <li>
            5. 享用套餐后以折扣价格结账。
        </li>
    </ul>
</asp:Content>

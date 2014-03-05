<%@ Page Language="C#" Title="" MasterPageFile="~/MIndex.master" AutoEventWireup="true" CodeBehind="BusinessCircle.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Center.BusinessCircle" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="ADeeWuControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    货比三家 - 商圈内容
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="/css/deal.css" rel="stylesheet" />
    <link href="/css/overlay.css" rel="stylesheet" />
    <link href="/CSS/forum_common.css" rel="stylesheet" type="text/css" />
    <link href="/CSS/forum_forumdisplay.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jquery.watermark.js"></script>
    <script type="text/javascript" src="/js/user.js"></script>

    <style>
        #Main {
            position: relative;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
    <span class="center"><a href="Default.aspx" title="搜索">搜索</a></span>>>
    <span class="bname">
        <asp:Literal ID="litBName" runat="server"></asp:Literal></span>

    <div id="deal-intro" class="cf">
        <div class="deal-brand" style="margin-bottom: 15px;">
            <asp:Literal ID="litBName2" runat="server"></asp:Literal>
        </div>
    </div>

    <table id="rentP_list" class="table_list font14" cellpadding="0" cellspacing="0">
        <thead>
            <tr height="30px" class="black70 fb font12">
                <td class="arc_title" width="610px">关键字</td>
                <td width="140px ">商家数</td>
                <td width="100px">添加时间</td>
                <td width="100px">详情</td>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rpResult" runat="server">
                <ItemTemplate>
                    <tr height="40px" onmouseover="this.className='jobMenu_hover'" onmouseout="this.className=''" class="">
                        <td class="arc_title"><%# Eval("KName") %></td>
                        <td><%# Eval("SalemanCount") %></td>
                        <td><%# Eval("KCreateTime")%></td>
                        <td><a class="xst question btn_blue" href="Key.aspx?kid=<%# Eval("KID") %>" title="<%# Eval("KName") %>">详情</a></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>

    <div class="pager" align="center">
        <ADeeWuControl:Pager3 ID="Pager1" runat="server" />
    </div>
</asp:Content>

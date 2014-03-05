<%@ Page Title="" Language="C#" MasterPageFile="~/MIndex.master" AutoEventWireup="true" CodeBehind="Key.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Center.Key" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="ADeeWuControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    货比三家 - 关键字内容
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="/css/deal.css" rel="stylesheet" />
    <link href="/css/overlay.css" rel="stylesheet" />
    <link href="/CSS/forum_common.css" rel="stylesheet" type="text/css" />
    <link href="/CSS/forum_forumdisplay.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jquery.watermark.js"></script>
    <script type="text/javascript" src="/js/user.js"></script>
    <script type="text/javascript">
        $(function () {
            $('.newKey').btnLogin({ title: '添加关键字' });
            $('[name=keyName]').watermark('输入关键字');

            $('#btnSubmit').click(function () {
                var parent = $(this).parent();
                var keyName = parent.find('input[name=keyName]').val();
                if (keyName == '') {
                    alert("关键字名称不能为空！");
                    return false;
                }

                $.getJSON('/ajax/center.ashx', { method: 'AddKey', name: keyName }, function (data) {
                    if (data.statue) {
                        parent.hide();
                        location.href = '<%= Request.RawUrl %>';
                    } else {
                        if (data.msg)
                            alert(data.msg);
                        else
                            parent.append("<font color='red'>提交错误，请重试！</font>");
                    }
                })

                return false;
            })
        })
    </script>
    <style>
        #Main {
            position: relative;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
    <span class="center"><a href="Default.aspx" title="搜索">搜索</a></span>>>
    <span class="bname">
        <asp:Literal ID="litKName2" runat="server"></asp:Literal></span>

    <div id="center_list">
        <div class="centerP_body">
            <div class="body_content font14 black70">
            </div>
            <p class="mt10">
                <button class="newKey btn_blue89">添加关键字</button>
                <div class="PostKey" style="display: none;">
                    <input type="text" name="keyName" value="" />
                    <button id="btnSubmit" class="button">提交</button>
                </div>
            </p>
        </div>
        <div class="centerP_head"></div>
    </div>

    <div id="deal-intro" class="cf">
        <div class="deal-brand" style="margin-bottom: 15px;">
            <asp:Literal ID="litKName" runat="server"></asp:Literal>
        </div>
    </div>

    <table id="rentP_list" class="table_list font14" cellpadding="0" cellspacing="0">
        <thead>
            <tr height="30px" class="black70 fb font12">
                <td class="arc_title" width="730px">商圈</td>
                <td width="100px">添加时间</td>
                <td width="100px">详情</td>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rpResult" runat="server">
                <ItemTemplate>
                    <tr height="40px" onmouseover="this.className='jobMenu_hover'" onmouseout="this.className=''" class="">
                        <td class="arc_title"><%# Eval("BName") %></td>
                        <td><%# Eval("BCreateTime") %></td>
                        <td><a class="xst question btn_blue" href="BusinessCircle.aspx?kid=<%# Eval("BID") %>" title="<%# Eval("BName") %>">详情</a></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>

    <div class="pager" align="center">
        <ADeeWuControl:Pager3 ID="Pager1" runat="server" />
    </div>
</asp:Content>

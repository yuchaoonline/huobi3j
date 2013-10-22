<%@ Page Title="" Language="C#" MasterPageFile="~/MIndex.master" AutoEventWireup="true" CodeBehind="TicketSearch.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Center.TicketSearch" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="ADeeWuControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="/js/jquery.watermark.js"></script>
    <script type="text/javascript" src="/js/user.js"></script>
    <script>
        $(function () {
            var val = $('.keyword').val();
            if (val == '')
                val = '输入搜索关键字';
            $('.keyword').val('');
            $('.keyword').watermark(val);

            $('.attentionCount').each(function () {
                var uid = $(this).parents('#recruit_list').find('[name=uid]').val();
                var $this = $(this);
                $.getJSON('/ajax/center.ashx', { method: 'GetBusinessCircleCount', uid: uid }, function (data) {
                    if (data != null) {
                        $this.html('所在商圈数（' + data.count + '）');
                    }
                })
            }).css('cursor', 'pointer');

            $('.btn_search').click(function () {
                var newVal = $(".keyword").val();
                if (newVal == '')
                    newVal = val;
                if (newVal == '输入搜索关键字')
                    newVal = '';
                var url = "<%=HttpContext.Current.Request.FilePath %>?keyword=" + newVal;
                location.href = url;
                return false;
            });

            $('.no-record').hide();

            $('.result img').ReduceImage();
        })
    </script>
    <style>
        <!--
        .STYLE1 {
            font-size: 14px;
            color: #000000;
            font-weight: bold;
        }

        .intro a {
            text-decoration: underline;
        }

        .list li.conn {
            height: 40px;
            line-height: 40px;
            font-size: 16px;
        }
        -->
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
    <div>
        <img src="/images/centerbiaoti.png" width="950px" alt="全民营销——即时通讯营销平台">
    </div>

    <div id="center">
        <div class="centerP_body">
            <div class="body_content">
                <p class="mt10">
                    <span>有赠送券商家搜索： 
                        <input type="text" id="keyword" name="keyword" class="text keyword" value="<%=Request["keyword"] %>" />
                        <input type="button" class="btn_blue btn_search" value="搜 索">
                    </span>
                </p>
            </div>
        </div>
    </div>
    <div id="searchResult">
        <asp:Repeater ID="rpResult" runat="server">
            <ItemTemplate>
                <div id="recruit_list">
                    <div class="frame zoom">
                        <div class="info1 l zoom">
                            <input type="hidden" name="uid" value="<%# Eval("userid") %>" />
                            <a href="CorpBusinessCircle.aspx?uid=<%# Eval("UserID") %>" target="_blank"><span class="STYLE1 result"><%# Eval("corpname") %></span></a>
                            <span class="db intro">
                                <%# Eval("intro") %>
                                <br />
                                <%# ADeeWu.HuoBi3J.Web.Class.Helper.GetLocation(Eval("areaid"), Eval("area"), Eval("cityid"), Eval("city"), Eval("provinceid"), Eval("province"), "-") %>
                                <label>
                                    <div align="right"><span class="attentionCount">所在商圈数：（1）</span></div>
                                </label>
                            </span>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <div class="pager" align="center">
        <ADeeWuControl:Pager3 ID="Pager1" runat="server" />
    </div>

    <ul class="list">
        <asp:Repeater ID="rpHotKeys" runat="server">
            <HeaderTemplate>
                <li class="zoom">
                    <label class="bb">可获赠券的热门关键字</label>
                </li>
            </HeaderTemplate>
            <ItemTemplate>
                <li class="conn">
                    <a href="<%# Eval("Link") %>" target="_blank" class="orange"><%# Eval("Name") %></a>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/MIndex.master" AutoEventWireup="true" CodeBehind="SearchKey.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Center.SearchKey" %>

<%@ Register Src="~/Controls/ucNav.ascx" TagPrefix="uc1" TagName="ucNav" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="ADeeWuControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    货比三家 - 货比三家 - 搜索价格
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="/js/jquery.watermark.js"></script>
    <script type="text/javascript" src="/js/user.js"></script>
    <script type="text/javascript">
        $(function () {
            $('.currentSelect').removeClass('currentSelect');
            $('#btnPageSearchKey').parent().addClass('currentSelect');

            var val = $('.txtKeyword').val();
            if (val == '')
                val = '输入搜索关键字';
            $('.txtKeyword').val('');
            $('.txtKeyword').watermark(val);

            $('.btn_search').click(function () {
                var newVal = $(".txtKeyword").val();
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

            $('#txtKeyword').enter($('.btn_search'));
        })
    </script>
    <style>
        <!--
        .STYLE1 {
            font-size: 16px;
            color: #323232;
            /*font-weight: bold;*/
        }

        .intro a {
            text-decoration: underline;
        }

        .list li.conn {
            height: 30px;
            line-height: 30px;
            font-size: 14px;
        }

        .body_right {
            float: left;
            margin-left: 67px;
        }

            .body_right li a {
                font-size: 12px;
                color: #0066cc;
            }
        -->
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
    <div class="cl"></div>

    <div id="searchResult">
        <asp:Repeater ID="rpQuestionIndex" runat="server">
            <ItemTemplate>
                <div id="recruit_list">
                    <div class="frame zoom">
                        <div class="info1 l zoom">
                            <span class="STYLE1 result"><%# GetTitle(Eval("Title")) %></span>
                            <span class="db intro">
                                <%# ADeeWu.HuoBi3J.Web.Class.Helper.GetLocation(Eval("aid"), Eval("aname"), Eval("cid"), Eval("cname"), Eval("pid"), Eval("pname"), "-") %>>>
                                <%# ADeeWu.HuoBi3J.Web.Class.Helper.GetBusinessCircle(Eval("bid"),Eval("bname")) %>>>
						        <%# ADeeWu.HuoBi3J.Web.Class.Helper.GetKey(Eval("kid"),Eval("kname")) %>
                                <label>
                                    <div align="right">回复数（<%# Eval("AnswerCount") %>）</div>
                                </label>
                            </span>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

        <asp:Repeater ID="rpResult" runat="server">
            <HeaderTemplate>
                <table id="rentP_list" class="table_list font14" cellpadding="0" cellspacing="0">
                    <thead>
                        <tr height="30px" class="black70 fb font12">
                            <td style="width: 465px;">关键字</td>
                            <td style="width: 200px;">商家数</td>
                            <td style="width: 200px;">商品数</td>
                            <td style="width: 80px;">详情</td>
                        </tr>
                    </thead>
            </HeaderTemplate>
            <ItemTemplate>
                <tbody>
                    <tr height="40px" onmouseover="this.className='jobMenu_hover'" onmouseout="this.className=''" class="">
                        <td class="arc_title"><%# Eval("KName") %></td>
                        <td><%# Eval("SaleManCount") %></td>
                        <td><%# Eval("PriceCount") %></td>
                        <td><a href="key4product.aspx?kid=<%# Eval("KID") %>" title="<%# Eval("KName") %>" target="_blank" class="btn_blue showinfo">详情</td>
                    </tr>
                </tbody>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            <div id="window"></div>
            </FooterTemplate>
        </asp:Repeater>
    </div>

    <div class="pager" align="center">
        <ADeeWuControl:Pager3 ID="Pager1" runat="server" />
    </div>

    <div id="noresult">
        <p>想添加关键字，<a href="Add.aspx?kname=<%=Request["keyword"] %>" class="blue24D">点击这里</a></p>
    </div>

    <br />
    <br />
    <br />
    <asp:Repeater ID="rpDefaultCenter" runat="server">
        <HeaderTemplate>
            <h3>推荐关键字列表</h3>
        </HeaderTemplate>
        <ItemTemplate>
            <div id="recruit_list">
                <div class="frame zoom">
                    <div class="info1 l zoom">
                        <%# Eval("KName") %>
                        <div align="right">
                            <a href="MoveCircle.aspx?kid=<%# Eval("kid") %>" class="btn_blue">指定商圈</a>
                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <div id="attentionDialog"></div>
</asp:Content>

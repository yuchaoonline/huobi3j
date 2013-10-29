<%@ Page Language="C#" Title="" MasterPageFile="~/MIndex.master" AutoEventWireup="true" CodeBehind="Key4Product.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Center.Key4Product" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="ADeeWuControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    价格列表 - 即时报价
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="/CSS/forum_common.css" rel="stylesheet" type="text/css" />
    <link href="/CSS/forum_forumdisplay.css" rel="stylesheet" type="text/css" />
    <link href="/CSS/base.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {
            $('title').text($('#kname').text() + ' - 价格列表 - 即时报价');
            
            $('.attr-type').each(function (index, item) {
                selectValue(item.children, '<%=Request["selectType"]%>');
            });
            $('.attr-price').each(function (index, item) {
                selectValue(item.children, '<%=Request["selectPrice"]%>');
            });
            $('.attr-size').each(function (index, item) {
                selectValue(item.children, '<%=Request["selectSize"]%>');
            });

            function selectValue(list,selectVal) {
                $.each(list, function (index, item) {
                    if ($(item).text() == selectVal) {
                        $(item).addClass('current');
                    }
                })
            }

            $('.arc_title img').ReduceImage();
            
            $('.item a1').click(function () {
                if ($(this).text() != '' && $(this).text() != '无')
                $.cookie($(this).attr('class'), $(this).text());

                location.href = "key4product.aspx?kid=<%=kid%>&selectType=" + $.cookie('selectType') + "&selectSize=" + $.cookie('selectSize') + "&selectPrice=" + $.cookie('selectPrice');
            })
        })
    </script>
    <style type="text/css">
        .dline a {
            text-decoration: underline;
        }
        .aaa a{
            display: inline-block !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
    <div id="filter">
        <div class="filter-sortbar-outer-box">
            <div class="filter-section-wrapper">
                <div class="filter-label-list filter-section category-filter-wrapper first-filter">
                    <div class="label has-icon"><i></i>搜索：</div>
                    <ul class="inline-block-list">
                        <li class="item current">
                            <asp:TextBox runat="server" ID="txtSearch" CssClass="searchText"></asp:TextBox>
                            <asp:Button runat="server" ID="btnSearch" CssClass="btn_blue" Text="搜索" OnClick="btnSearch_Click" />(公司地址、公司名称、简单描述)
                            <a style="display: inline-block;line-height: 24px;text-align: center;padding: 3px 5px;height: 24px;background-color: orange;margin-left: 115px;" href="questionlist.aspx?kid=<%=kid%>">发布信息找低价</a>
                        </li>
                    </ul>
                </div>
                <div class="filter-label-list filter-section category-filter-wrapper">
                    <div class="label has-icon"><i></i>关键字：</div>
                    <ul class="inline-block-list">
                        <li class="item">
                            <asp:Repeater ID="rpKey" runat="server">
                                <ItemTemplate>
                                    <div class="black70 aaa">
                                            <span style="font-weight: bold; font-size: 14px; margin-right: 100px;" id="kname"><%# Eval("KName") %></span>
                                            <span>所属商圈：<%# ADeeWu.HuoBi3J.Web.Class.Helper.GetBusinessCircle(Eval("bid"),Eval("bname")) %></span><span style="margin-left: 10px;">所属地区：<%# ADeeWu.HuoBi3J.Web.Class.Helper.GetLocation(Eval("aid"),Eval("aname"),Eval("cid"),Eval("cname"),Eval("pid"),Eval("pname")," - ") %></span></div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </li>
                    </ul>
                </div>
                <div class="filter-label-list filter-section category-filter-wrapper">
                    <div class="label has-icon"><i></i>类型：</div>
                    <ul class="inline-block-list attr-type">
                        <asp:Literal runat="server" ID="litType"></asp:Literal>
                    </ul>
                </div>
                <div class="filter-label-list filter-section category-filter-wrapper">
                    <div class="label has-icon"><i></i>价格：</div>
                    <ul class="inline-block-list attr-price">
                        <asp:Literal runat="server" ID="litPrice"></asp:Literal>
                    </ul>
                </div>
                <div class="filter-label-list filter-section category-filter-wrapper">
                    <div class="label has-icon"><i></i>其他：</div>
                    <ul class="inline-block-list attr-size">
                        <asp:Literal runat="server" ID="litSize"></asp:Literal>
                    </ul>
                </div>
            </div>
        </div>
    </div>

    <div class="cl"></div>

    <asp:Repeater ID="rpProduct" runat="server">
        <HeaderTemplate>
            <table id="rentP_list" class="table_list font14" cellpadding="0" cellspacing="0">
                <thead>
                    <tr height="30px" class="black70 fb font12">
                        <td style="width: 80px;">价格</td>                        
                        <td style="width: 200px;">简单描述</td>
                        <td style="width: 205px;">选择</td>
                        <td style="width: 190px;">公司</td>
                        <td style="width: 190px;">地址</td>
                        <td style="width: 80px;">详情</td>
                    </tr>
                </thead>
        </HeaderTemplate>
        <ItemTemplate>
            <tbody>
                <tr height="40px" onmouseover="this.className='jobMenu_hover'" onmouseout="this.className=''" class="">
                    <td class="arc_title"><%# GetMoney(Eval("[Price]")) %></td>
                    <td><%# Eval("[simpledesc]") %></td>
                    <td><%# Eval("[selectattribute]") %></td>
                    <td><%# Eval("[companyname]") %></td>
                    <td><%# Eval("[companyaddress]")%></td>
                    <td><a href="details.aspx?id=<%# Eval("[ID]") %>" class="btn_blue showinfo" title="详情">详情</a></td>
                </tr>
            </tbody>
        </ItemTemplate>
        <FooterTemplate>
            </table>
            <div id="window"></div>
        </FooterTemplate>
    </asp:Repeater>

    <ADeeWuControl:Pager3 ID="Pager1" runat="server" />
</asp:Content>

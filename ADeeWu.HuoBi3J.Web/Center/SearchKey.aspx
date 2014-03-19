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
        <asp:Repeater ID="rpResult" runat="server">
            <HeaderTemplate>
                <table id="rentP_list" class="table_list font14" cellpadding="0" cellspacing="0">
                    <thead>
                        <tr height="30px" class="black70 fb font12" style="text-align: left;">
                            <td style="width: 866px;">关键字</td>
                            <td style="width: 80px;">详情</td>
                        </tr>
                    </thead>
            </HeaderTemplate>
            <ItemTemplate>
                <tbody>
                    <tr height="40px" onmouseover="this.className='jobMenu_hover'" onmouseout="this.className=''" class="">
                        <td class="arc_title"><%# Eval("Name") %></td>
                        <td><a href="key4product.aspx?kid=<%# Eval("KID") %>" title="<%# Eval("Name") %>" target="_blank" class="btn_blue showinfo">详情</td>
                    </tr>
                </tbody>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>

    <div class="pager" align="center">
        <ADeeWuControl:Pager3 ID="Pager1" runat="server" />
    </div>

    <div id="noresult">
        <p>想添加关键字，<a href="Add.aspx?kname=<%=Request["keyword"] %>" class="blue24D">点击这里</a></p>
    </div>
</asp:Content>

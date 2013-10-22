<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="CustomerBenefit.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.CorpAgent.CustomerBenefit" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="ADeeWuControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    个人控制面板 - 我的营销伙伴
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .Columns {
            margin: 0px;
            padding: 0px;
        }

            .Columns li {
                list-style: none;
                text-align: left;
            }

        .Columns-LoginName {
            width: 120px;
        }

        .Columns-UIN {
            width: 80px;
        }

        .Columns-UserType {
            width: 80px;
        }

        .Columns-CorpName {
            width: 150px;
        }

        .Columns-Location {
            width: 120px;
        }

        .Columns-RegDate {
            width: 100px;
        }

        .dataRow {
            margin-top: 20px;
        }

            .dataRow li {
                list-style: none;
                height: 22px;
                line-height: 22px;
            }

                .dataRow li.break {
                    height: 0px;
                    line-height: 22px;
                    font-size: 0px;
                }

        .dataRow-loginName {
            width: 120px;
        }

        .dataRow-uin {
            width: 80px;
        }

        .dataRow-userType {
            width: 80px;
        }

        .dataRow-corpName {
            width: 150px;
        }

        .dataRow-location {
            width: 120px;
        }

        .dataRow-regDate {
            width: 100px;
        }

        .dataRow-sub {
            width: 60px;
        }

        .subRows {
            border: 1px dashed #e1e1e1;
            padding: 2px;
            margint-top: 5px;
        }


        #MainContent {
            position: relative;
        }

        .ShowLayer {
            position: absolute;
            left: 0px;
            top: 0px;
            min-height: 400px;
            _height: 400px;
            width: 100%;
            border: 2px solid #d1d1d1;
            padding: 10px;
            background: #fff;
            display: none;
        }

        .ShowLayer-Data em {
            cursor: pointer;
            font-style: normal;
        }

        .ShowLayer-Close {
            text-align: right;
            cursor: pointer;
        }

        .ShowLayer-Lv5-Lv6 {
            position: absolute;
            left: 10px;
            top: 10px;
            min-height: 250px;
            _height: 250px;
            width: 90%;
            border: 2px solid #d1d1d1;
            padding: 10px;
            background: #fff;
            display: none;
        }

        .ShowLayer-Lv5-Lv6-Close {
            text-align: right;
            cursor: pointer;
        }

        .ShowLayer-Lv5-Lv6-Data em {
            font-style: normal;
        }

        .ShowLayer-AgentName {
        }

        .ShowLayer dl {
            margin: 0px;
            padding: 10px;
            clear: both;
        }

        .ShowLayer dt {
            margin: 0px;
            padding: 0px;
            float: left;
            width: 60px;
            min-height: 20px;
            _height: 20px;
        }

        .ShowLayer dd {
            margin: 0px;
            margin-left: 15px;
            padding: 0px;
            float: left;
            width: 500px;
            min-height: 20px;
            _height: 20px;
            border-bottom: 1px solid #e1e1e1;
        }
    </style>

    <script type="text/javascript">
        $(document).ready(function () {
            $('.dataRow-sub a').click(function () {
                var target = $(this),
                agentUserId = target.attr('agentUserId');
                $.post(
                    'CustomerAjax.aspx',
                    { AgentUserId: agentUserId },
                    function (data) {
                        $('.ShowLayer').show();
                        $('.ShowLayer-Data').html(data);

                    }
                );
                return false;
            });

            $('.ShowLayer-Close').click(function () {
                $('.ShowLayer').hide();
                return false;
            });

            $('.ShowLayer-Lv5-Lv6-Close').click(function () {
                $('.ShowLayer-Lv5-Lv6').hide();
                return false;
            });
        });

        function ShowLv5_Lv6(agentUserId) {
            $.post(
                    'CustomerAjax.aspx',
                    { AgentUserId: agentUserId, getlv5lv6: true },
                    function (data) {
                        $('.ShowLayer,.ShowLayer-Lv5-Lv6').show();
                        $('.ShowLayer-Lv5-Lv6-Data').html(data);
                    }
                );
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <span class="spl"></span><span class="curPos">我的营销代理客户</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <table id="resultList" class="gridView">
        <asp:Repeater ID="rpDataList" runat="server">
            <HeaderTemplate>
                <tr>
                    <th>用户名</th>
                    <th>UIN</th>
                    <th>添加时间</th>
                    <th>操作</th>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("CustomerLoginName")%></td>
                    <td><%# Eval("CustomerUIN")%></td>
                    <td><%# Eval("CreateTime") %></td>
                    <td>
                        <a href="CustomerKeyword.aspx?id=<%# Eval("CustomerUserID") %>" title="精准关键字">精准关键字</a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <div class="pager">
        <ADeeWuControl:Pager ID="Pager1" runat="server" />
    </div>
</asp:Content>

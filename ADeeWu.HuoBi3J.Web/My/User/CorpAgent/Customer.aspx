<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Customer.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.CorpAgent.Customer" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    个人控制面板 - 我的营销代理客户
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

    <div class="ShowLayer">

        <div class="ShowLayer-Close">关闭</div>
        <div class="ShowLayer-Data">
        </div>
        <div class="ShowLayer-Lv5-Lv6">
            <div class="ShowLayer-Lv5-Lv6-Close">关闭</div>
            <div class="ShowLayer-Lv5-Lv6-Data"></div>
        </div>


    </div>

    <ul class="Columns">
        <li class="Columns-LoginName fl">客户账号</li>
        <li class="Columns-UIN fl">客户UIN</li>
        <li class="Columns-UserType fl">用户类型</li>
        <li class="Columns-CorpName fl">公司名称</li>
        <li class="Columns-Location fl">所属地区</li>
        <li class="Columns-RegDate fl">注册日期</li>
        <li class="break"></li>
    </ul>


    <asp:Repeater ID="rpDataList" runat="server" OnItemDataBound="rpDataList_ItemDataBound">
        <ItemTemplate>

            <asp:TextBox ID="txtCustomerUserId" runat="server" Visible="false" Text='<%#Eval("CustomerUserID") %>'></asp:TextBox>

            <ul class="dataRow">

                <li class="dataRow-loginName fl">
                    <%#Eval("CustomerLoginName")%>
                </li>

                <li class="dataRow-uin fl">
                    <%#Eval("CustomerUIN")%>
                </li>

                <li class="dataRow-userType fl">
                    <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                              Eval("CustomerUserType").ToString(),
                new string[,]{
                    {"0","个人用户"},
                    {"1","企业用户"},
                    {"2","商家代表"}
                }               
                )
                    %>
                </li>

                <li class="dataRow-corpName fl">
                    <%#Eval("CorpName")%>
                </li>

                <li class="dataRow-location fl">
                    <%#Eval("Province") %> <%#Eval("City") %> <%#Eval("Area") %>
                </li>

                <li class="dataRow-regDate fl">
                    <%#Eval("CreateTime","{0:d}")%>
                </li>

                <li class="dataRow-sub fl">线下用户↓
                </li>

                <li class="break"></li>
            </ul>

            <asp:Repeater ID="rpSub" runat="server">
                <HeaderTemplate>
                    <div class="subRows">
                </HeaderTemplate>
                <FooterTemplate></div></FooterTemplate>
                <ItemTemplate>


                    <ul class="dataRow">

                        <li class="dataRow-loginName fl">
                            <%#Eval("CustomerLoginName")%>
                        </li>

                        <li class="dataRow-uin fl">
                            <%#Eval("CustomerUIN")%>
                        </li>

                        <li class="dataRow-userType fl">
                            <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                                  Eval("CustomerUserType").ToString(),
                    new string[,]{
                        {"0","个人用户"},
                        {"1","企业用户"},
                        {"2","商家代表"}
                    }               
                    )
                            %>
                        </li>

                        <li class="dataRow-corpName fl">
                            <%#Eval("CorpName")%>
                        </li>

                        <li class="dataRow-location fl">
                            <%#Eval("Province") %> <%#Eval("City") %> <%#Eval("Area") %>
                        </li>

                        <li class="dataRow-regDate fl">
                            <%#Eval("CreateTime","{0:d}")%>
                        </li>

                        <li class="dataRow-sub fl">
                            <a href="javascript:void(0);" agentuserid="<%#Eval("CustomerUserID") %>">线下用户</a>
                        </li>

                        <li class="break"></li>
                    </ul>

                </ItemTemplate>
            </asp:Repeater>


        </ItemTemplate>
    </asp:Repeater>




    <div class="pager">
        <IscControl:Pager ID="Pager1" runat="server" />
    </div>




</asp:Content>

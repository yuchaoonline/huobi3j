<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="MyAnswerList.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Center.MyAnswerList" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="ADeeWuControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    ȫ��Ӫ�� - ���˹������� - �ҵ������б�
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="/CSS/forum_common.css" rel="stylesheet" type="text/css" />
    <link href="/CSS/forum_forumdisplay.css" rel="stylesheet" type="text/css" />
    <script>
        $(function () {
            $('.question img').ReduceImage();
        })
    </script>
    <style>
        .answer_tr {
            background: #DDD;
        }

        .answers {
            text-indent: 4em;
        }

        .answerName {
            float: left;
        }

        .answerTime {
            float: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <div class="mn">
        <div class="tl bm bmw" id="threadlist">
            <!--����_Start-->
            <div class="th">
                <table cellspacing="0" cellpadding="0">
                    <tbody>
                        <tr>
                            <td class="common">����
                            </td>
                            <td class="by2">��������
                            </td>
                            <td class="by2">������Ȧ
                            </td>
                            <td class="by2">�����ؼ���
                            </td>
                            <td class="by2">����ʱ��
                            </td>
                            <td class="by2">�ظ�
                            </td>
                            <td class="by2">�鿴
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <!--����_End-->
            <!--�����б�_Start-->
            <div class="bm_c">
                <table cellspacing="0" cellpadding="0" summary="forum_2">
                    <tbody>
                        <asp:Repeater ID="rpAnswers" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td class="common">
                                        <a class="xst question" href="/center/question.aspx?qid=<%# Eval("QID") %>"><%# GetTitle(Eval("Title")) %></a>
                                    </td>
                                    <td class="by2">
                                        <%# ADeeWu.HuoBi3J.Web.Class.Helper.GetLocation(Eval("aid"), Eval("aname"), Eval("cid"), Eval("cname"), Eval("pid"), Eval("pname"), "-") %>
                                    </td>
                                    <td class="by2">
                                        <%# ADeeWu.HuoBi3J.Web.Class.Helper.GetBusinessCircle(Eval("bid"), Eval("BName"))%>
                                    </td>
                                    <td class="by2">
                                        <%# ADeeWu.HuoBi3J.Web.Class.Helper.GetKey(Eval("kid"), Eval("kName"))%>
                                    </td>
                                    <td class="by2">
                                        <em>
                                            <%# Eval("CreateTime")%></em>
                                    </td>
                                    <td class="by2">
                                        <em class="xi2">
                                            <%# GetReplyStatue(Eval("IsReply")) %></em>
                                    </td>
                                    <td class="by2">
                                        <%# GetReadStatue(Eval("IsRead")) %>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
            <!--�����б�_End-->
        </div>
    </div>
    <div class="pager" align="center">
        <ADeeWuControl:Pager ID="Pager1" runat="server" />
    </div>
</asp:Content>

<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="MyAttentionList.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Center.MyKeyList" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="ADeeWuControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    ȫ��Ӫ�� - ���˹������� - �ҵĹؼ����б�
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="/CSS/forum_common.css" rel="stylesheet" type="text/css" />
    <link href="/CSS/forum_forumdisplay.css" rel="stylesheet" type="text/css" />
    <script>
        $(function () {
            $('#btnSearch').click(function () {
                var url = $(this).attr('href') + "?keyword=" + $('#txtKeyword').val();
                $(this).attr('href', url);
                return true;
            })
        })
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <a href="/My/User/Center/MyQuestionList.aspx">��������</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <table class="searchTable">
        <tr>
            <td class="key">�ؼ��֣�</td>
            <td class="input">
                <input type="text" id="txtKeyword" />
                <a href="SearchKey.aspx" title="����" id="btnSearch" class="btn_blue">����</a>
            </td>
            <td>
                <span style="color: blue;">�Ѿ��ͳ���ң�<font color="#ff9933"><asp:Literal ID="litCoin" runat="server"></asp:Literal></font>��</span>
            </td>
        </tr>
    </table>
    <div class="mn">
        <div class="tl bm bmw" id="threadlist">
            <!--����_Start-->
            <div class="th">
                <table cellspacing="0" cellpadding="0">
                    <tbody>
                        <tr>
                            <th class="by2">�ؼ���
                            </th>
                            <th class="common">��������
                            </th>
                            <th class="by2">������Ȧ
                            </th>
                            <th class="num">������
                            </th>
                            <th class="by2">��עʱ��
                            </th>
                            <th class="common">����
                            </th>
                        </tr>
                    </tbody>
                </table>
            </div>
            <!--����_End-->
            <!--�����б�_Start-->
            <div class="bm_c">
                <table cellspacing="0" cellpadding="0" summary="forum_2">
                    <tbody>
                        <asp:Repeater ID="rpQuestions" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td class="by2">
                                        <a class="xst question" href="/Center/key4product.aspx?kid=<%# Eval("KID") %>" title="<%# Eval("KName") %>"><%# Eval("KName") %></a>
                                    </td>
                                    <td class="common">
                                        <%# ADeeWu.HuoBi3J.Web.Class.Helper.GetLocation(Eval("aid"), Eval("aname"), Eval("cid"), Eval("cname"), Eval("pid"), Eval("pname"), "-") %>
                                    </td>
                                    <td class="by2">
                                        <a href="/Center/businesscircle.aspx?bid=<%# Eval("bid") %>" title="<%# Eval("BName") %>"><%# Eval("BName") %></a>
                                    </td>
                                    <td class="num">
                                        <em class="xi2">
                                            <%# Eval("QuestionCount") %></em>
                                    </td>
                                    <td class="by2">
                                        <em>
                                            <%# Eval("CreateTime")%></em>
                                    </td>
                                    <td class="common">
                                        <%# IsGoOn(Eval("IsGoOn"), Eval("kid"))%>
                                        <a href="PriceList4Key.aspx?kid=<%# Eval("kid") %>" title="����۸�" class="btn_blue">����۸�</a>
                                        <a href="AddPrice4Key.aspx?kid=<%# Eval("kid") %>" title="��Ӽ۸�" class="btn_blue">��Ӽ۸�</a>
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

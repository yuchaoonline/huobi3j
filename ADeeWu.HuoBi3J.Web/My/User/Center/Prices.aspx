<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Prices.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Center.Prices" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="ADeeWuControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    �������� - ���˹������� - �ҵĹؼ����б�
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="/CSS/forum_common.css" rel="stylesheet" type="text/css" />
    <link href="/CSS/forum_forumdisplay.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <a href="/My/User/Center/MyQuestionList.aspx">��������</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <div class="box">
        <div class="box_head1">
            <label class="fb font14 black70">������Ϣ</label>
        </div>
        <div class="box_body">
            <span style="color: blue;">�ֻ�ɨ���ά�������<font color="#ff9933"><asp:Literal ID="litQRCount" runat="server"></asp:Literal></font> �Σ��Ѿ��ͳ���ң�<font color="#ff9933"><asp:Literal ID="litCoin" runat="server"></asp:Literal></font>��</span>
            <a href="AddPrice.aspx" title="��Ӽ۸�" class="btn_blue" style="float: right;">��Ӽ۸�</a>
        </div>
    </div>

    <div class="mn">
        <div class="tl bm bmw" id="threadlist">
            <div class="th">
                <table cellspacing="0" cellpadding="0">
                    <tbody>
                        <tr>
                            <td class="num">�۸�
                            </td>
                            <td class="common">������
                            </td>
                            <%--<td class="common">ѡ������
                            </td>--%>
                            <td class="num">�����
                            </td>
                            <td class="common">����
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="bm_c">
                <table cellspacing="0" cellpadding="0" summary="forum_2">
                    <tbody>
                        <asp:Repeater ID="rpQuestions" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td class="num">
                                        <a href="/Center/details.aspx?id=<%# Eval("id") %>" title="�鿴"><%# GetMoney(Eval("price")) %></a>
                                    </td>
                                    <td class="common">
                                        <%# Eval("title")%>
                                    </td>
                                    <%--<td class="common">
                                           ���ͣ�<%# Eval("selecttype")%>;�۸�<%# Eval("selectprice")%>;������<%# Eval("selectsize")%>
                                    </td>--%>
                                    <td class="num">
                                        <a href="PriceCount4Key.aspx?id=<%# Eval("id") %>"><%# GetCount(Eval("id")) %></a>
                                    </td>
                                    <td class="common">
                                        <a href="EditPrice.aspx?id=<%# Eval("id") %>" title="�޸�" class="btn_blue">�޸�</a>
                                        <a href="Prices.aspx?method=delete&id=<%# Eval("id") %>" title="ɾ��" class="btn_blue">ɾ��</a>
                                        <a href="SearchKey.aspx?id=<%# Eval("id") %>" title="ָ���ؼ���" class="btn_blue">�ؼ���</a>
                                        <%--<a href="AddBusinessCircleToPrice.aspx?id=<%# Eval("id") %>" title="ָ����Ȧ" class="btn_blue">��Ȧ</a>--%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
    </div>

    <div class="pager" align="center">
        <ADeeWuControl:Pager ID="Pager1" runat="server" />
    </div>
</asp:Content>

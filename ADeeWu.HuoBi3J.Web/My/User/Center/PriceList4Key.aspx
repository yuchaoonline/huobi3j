<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="PriceList4Key.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Center.PriceList4Key" %>

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
    <a href="AddPrice4Key.aspx?kid=<%=Request["kid"] %>" title="��Ӽ۸�" class="btn_blue">��Ӽ۸�</a>
    <div class="mn">
        <div class="tl bm bmw" id="threadlist">
            <div class="th">
                <table cellspacing="0" cellpadding="0">
                    <tbody>
                        <tr>
                            <td class="common">�۸�
                            </td>
                            <td class="common">������
                            </td>
                            <td class="common">ѡ������
                            </td>
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
                                    <td class="common">
                                        <a href="/Center/details.aspx?id=<%# Eval("id") %>" title="�鿴"><%# GetMoney(Eval("price")) %></a>
                                    </td>
                                    <td class="common">
                                            <%# Eval("simpledesc")%>
                                    </td>
                                    <td class="common">
                                           ���ͣ�<%# Eval("selecttype")%>;�۸�<%# Eval("selectprice")%>;������<%# Eval("selectsize")%>
                                    </td>
                                    <td class="num">
                                            <a href="PriceCount4Key.aspx?id=<%# Eval("id") %>"><%# Eval("ClickCount") %></a>
                                    </td>
                                    <td class="common">
                                        <a href="EditPrice4Key.aspx?id=<%# Eval("id") %>" title="�޸�" class="btn_blue">�޸�</a>
                                        <a href="PriceList4Key.aspx?method=delete&id=<%# Eval("id") %>&kid=<%# Eval("kid") %>" title="ɾ��" class="btn_blue">ɾ��</a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>

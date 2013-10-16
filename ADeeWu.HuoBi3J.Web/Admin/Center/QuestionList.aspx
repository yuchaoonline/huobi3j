<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="QuestionList.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.Center.QuestionList"  %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
�ޱ����ĵ�
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<link type="text/css" href="/JS/Jquery/theme/start/jquery-ui-1.8.23.custom.css" rel="stylesheet" />
<script src="/JS/jquery.js" type="text/javascript"></script>
<script src="/JS/Jquery/jquery-ui-1.8.23.custom.min.js" type="text/javascript"></script>
<script src="/JS/common.js" type="text/javascript"></script>
<script>
    $(function(){
        $('.question img').ReduceImage();
    })
</script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>��ʱ���۹���</span> &gt; �����б�
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <table class="searchTable">
        <tr>
            <td><a href="QuestionIndexList.aspx">��ҳ�����б�</a></td>
        </tr>
    </table>

    <table id="resultList" class="gridView" width="100%">
        <asp:Repeater ID="rpResultList" runat="server">
            <HeaderTemplate>
                <tr>
                    <th>ID</th>
                    <th>����</th>
                    <th>��������</th>
                    <th>������Ȧ</th>
                    <th>�����ؼ���</th>
                    <th>����</th>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("qid") %></td>
                    <td class="question"><%# Eval("Title") %></td>
                    <td><%# ADeeWu.HuoBi3J.Web.Class.Helper.GetLocation(Eval("aid"),Eval("aname"),Eval("cid"),Eval("cname"),Eval("pid"),Eval("pname")," - ") %></td>
                    <td><%# ADeeWu.HuoBi3J.Web.Class.Helper.GetBusinessCircle(Eval("bid"),Eval("bname"))%></td>
                    <td><%# ADeeWu.HuoBi3J.Web.Class.Helper.GetKey(Eval("kid"),Eval("kname"))%></td>
                    <td>
                        <a href="QuestionIndexList.aspx?qid=<%# Eval("qid") %>" title="������ҳ��ʾ">��ҳ��ʾ</a>|
                        <a href="/center/Question2.aspx?qid=<%# Eval("qid") %>&kid=<%# Eval("kid") %>" target="_blank">����</a></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>

    <div class="pager">
        <IscControl:Pager ID="Pager1" runat="server" />
    </div>
    <div id="attentionDialog"></div>
</asp:Content>


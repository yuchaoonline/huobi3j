<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="Result.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.CP_Keyword_Search.Result"  %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="CashTicketControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
Admin - Corps - List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
.searchTable .key{ width:auto; }
.searchTable .input{ width:auto; }
</style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>�̼��ƹ�</span> &gt; �ؼ��������������� | <a href="Refresh.aspx">���»�����</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <table id="resultList" class="dataGrid">
        <asp:Repeater ID="rpResultList" runat="server">
            <HeaderTemplate>
                <tr>
                    <th>����</th>
                    <th>����</th>
                    <th>����</th>
                    <th>�����</th>
                    <th>����</th>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#Eval("Title") %></td>
                    <td><%#Eval("Content") %></td>
                    <td><a href="<%#ADeeWu.HuoBi3J.Libary.WebUtility.FormatURL(Eval("Link")) %>" title="����鿴"><%#ADeeWu.HuoBi3J.Libary.WebUtility.FormatURL(Eval("Link"))%></a></td>
                    <td><%#Eval("Count") %></td>
                    <td>
                        <a href="DelResult.aspx?id=<%#Eval("id")%>&keywordid=<%# id %>" onclick="return confirm('ȷ��Ҫɾ���ü�¼��?ͬʱ��ɾ���йظü�¼��ͳ�ƣ�');" title="ɾ��">ɾ��</a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
	<div class="pager">
        <IscControl:Pager ID="Pager1" runat="server"  />
    </div>
</asp:Content>


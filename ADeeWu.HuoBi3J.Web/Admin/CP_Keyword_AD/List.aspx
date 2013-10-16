<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="List.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.CP_Keyword_AD.List"  %>

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
<input type="hidden" name="page"  value="1" />
<table id="resultList" class="dataGrid">
        <asp:Repeater ID="rpADList" runat="server">
            <HeaderTemplate>
                <tr>
                    <th>����</th>
                    <th>����</th>
                    <th>����</th>
                    <th>�����û�</th>
                    <th>���</th>
                    <th>����</th>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#ADeeWu.HuoBi3J.Libary.Utility.SubString(Eval("Name"),20,"...") %></td>
                    <td><%#ADeeWu.HuoBi3J.Libary.Utility.SubString(Eval("Content"),20,"...") %></td>
                    <td><a href="<%#ADeeWu.HuoBi3J.Libary.WebUtility.FormatURL(Eval("Link")) %>" title="����鿴"><%#ADeeWu.HuoBi3J.Libary.WebUtility.FormatURL(Eval("Link"))%></a></td>
                    <td><%#GetUserName(Eval("UserID")) %></td>
                    <td><%#Convert.ToBoolean(Eval("IsPass"))?"ͨ��":"<font color='red'>δͨ��</font>" %></td>
                    <td>
                        <a href="Edit.aspx?id=<%#Eval("id")%>" title="�༭">�༭</a>
                        <%--<a href="AuctionLog.aspx?id=<%#Eval("id")%>" title="���ۼ�¼">���ۼ�¼</a>--%>
                        <a href="ADClickLog.aspx?id=<%#Eval("id")%>&name=<%# HttpUtility.UrlEncode(Eval("Name").ToString()) %>" title="�����¼">�����¼</a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
<table width="100%" class="dataGrid_Footer">
    <tr>
        <td class="pagerBox">
            <CashTicketControl:Pager ID="Pager1" runat="server"  />
        </td>
    </tr>
</table>
</asp:Content>


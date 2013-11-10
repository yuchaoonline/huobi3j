<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="InformList.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.Center.InformList"  %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="ADeeWuControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
�ޱ����ĵ�
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>�������ҹ���</span> &gt; �ٱ�����
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <table id="resultList" class="gridView" width="100%">
        <asp:Repeater ID="rpResultList" runat="server">
            <HeaderTemplate>
                <tr>
                    <th>ID</th>
                    <th>�ٱ�����</th>
                    <th>�ٱ�����</th>
                    <th>�ٱ�ʱ��</th>
                    <th>����</th>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("ID") %></td>
                    <td><%# this.GetContent(Eval("contentid"),Eval("informtype"))%></td>
                    <td><%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(Eval("informtype").ToString(),new string[][]{new string[]{"0","��Ȧ"},new string[]{"1","�ؼ���"},new string[]{"2","����"},new string[]{"3","�ظ�����"}})%></td>
                    <td><%# Eval("CreateTime") %></td>
                    <td><a href="ProcessInform.aspx?id=<%#Eval("ID") %>">ͨ��</a></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>

    <div class="pager">
        <ADeeWuControl:Pager ID="Pager1" runat="server" />
    </div>
</asp:Content>


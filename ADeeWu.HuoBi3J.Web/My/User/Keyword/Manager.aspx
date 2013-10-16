<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Manager.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Keyword.Manager" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    ȫ��Ӫ�� - ���˹������� - ��׼����
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <asp:HiddenField ID="hfKeywordID" runat="server" />
    <table class="formTable gridView">
        <tr>
            <th colspan="2">����������
            </th>
        </tr>
        <tr>
            <td class="tdLeft">���⣺</td>
            <td class="tdRight">
                <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                <span class="require">*</span></td>
        </tr>
        <tr>
            <td class="tdLeft">������</td>
            <td class="tdRight">
                <asp:TextBox ID="txtContent" runat="server"></asp:TextBox>
                <span class="require">*</span></td>
        </tr>
        <tr>
            <td class="tdLeft">���ӣ�</td>
            <td class="tdRight">
                <asp:TextBox ID="txtLink" runat="server"></asp:TextBox>
                <span class="require">*</span></td>
        </tr>
        <tr>
            <td class="tdLeft"></td>
            <td class="tdRight">
                <asp:Button ID="btnSubmit" runat="server" Text="���" OnClick="btnSubmit_Click" />
            </td>
        </tr>
    </table>

    <table id="resultList" class="gridView">
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
                    <td><%# ADeeWu.HuoBi3J.Libary.Utility.SubString(Eval("Title"),20,"...") %></td>
                    <td><%# ADeeWu.HuoBi3J.Libary.Utility.SubString(Eval("Content"),20,"...") %></td>
                    <td><a href="<%#ADeeWu.HuoBi3J.Libary.WebUtility.FormatURL(Eval("Link")) %>" title="����鿴"><%#ADeeWu.HuoBi3J.Libary.WebUtility.FormatURL(Eval("Link"))%></a></td>
                    <td><%#Eval("Count") %></td>
                    <td>
                        <a href="DelResult.aspx?id=<%#Eval("id")%>" onclick="return confirm('ȷ��Ҫɾ���ü�¼��?ͬʱ��ɾ���йظü�¼��ͳ�ƣ�');" title="ɾ��">ɾ��</a>
                        <a href="EditResult.aspx?id=<%#Eval("id")%>" title="ɾ��">�༭</a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <div class="pager">
        <IscControl:Pager ID="Pager1" runat="server" />
    </div>
</asp:Content>


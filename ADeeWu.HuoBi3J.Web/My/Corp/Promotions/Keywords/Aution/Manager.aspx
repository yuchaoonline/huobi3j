<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Manager.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.Promotions.Keywords.Aution.Manager" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
�̼ҿ������ - ��׼�������۹���
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">��</span><a href="Default.aspx">�ؼ��־��۹���</a>  <span class="spl">��</span><span class="curPos">���۹���</span>
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <table id="resultList" class="gridView">
        <asp:Repeater ID="rpADList" runat="server">
            <HeaderTemplate>
                <tr>
                    <th>��׼�ؼ���</th>
                    <th>�������</th>
                    <th>�����۸�</th>
                    <th>�����ܽ��</th>
                    <th>ÿ�컨��</th>
                    <th>�Ƿ�ֹͣ</th>
                    <th>����</th>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#Eval("keyword") %></td>
                    <td><%# ADeeWu.HuoBi3J.Libary.Utility.SubString(Eval("name"), 20, "...") %></td>
                    <td><%#Eval("clickprice") %></td>
                    <td><%#Eval("totalprice") %></td>
                    <td><%#Eval("totalpriceday") %></td>
                    <td><%# ADeeWu.HuoBi3J.Libary.Utility.GetBool(Eval("ispause"),true)?"��":"��" %></td>
                    <td>
                        <a href="pause.aspx?id=<%#Eval("id")%>" title="����Ͷ��">Ͷ�ſ���</a>
                        <a href="daycost.aspx?id=<%#Eval("id")%>" title="ÿ�շ���">ÿ�շ���</a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>

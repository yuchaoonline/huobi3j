<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="ADLog.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.Promotions.Keywords.AD.ADLog" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
�̼ҿ������ - ��׼����������
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">��</span><a href="Default.aspx">������ù���</a>  <span class="spl">��</span><span class="curPos">����¼</span>
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <table id="resultList" class="gridView">
        <asp:Repeater ID="rpADList" runat="server">
            <HeaderTemplate>
                <tr>
                    <th>��׼�ؼ���</th>
                    <th>ӵ����</th>
                    <th>����۸�</th>
                    <th>���IP</th>
                    <th>���ʱ��</th>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#Eval("keyword") %></td>
                    <td><%#Eval("loginname") %></td>
                    <td><%#Eval("clickprice") %></td>
                    <td><%#Eval("clickip") %></td>
                    <td><%#Eval("createtime") %></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>

<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.Promotions.Keywords.Aution.Default" %>
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
    <table class="formTable gridView">
        <tr>
            <th colspan="2">
                �����ؼ���
            </th>
        </tr>
        <tr>
	        <td class="tdLeft">��׼�ؼ��֣�</td>
	        <td class="tdRight"><asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
	        <td class="tdLeft"></td>
	        <td class="tdRight">
	            <asp:Button ID="btnSubmit" runat="server" Text="����" onclick="btnSubmit_Click" />
	        </td>
        </tr>
    </table>

    <table id="resultList" class="gridView">
        <asp:Repeater ID="rpADList" runat="server">
            <HeaderTemplate>
                <tr>
                    <th>ӵ����</th>
                    <th>��׼�ؼ���</th>
                    <th>���ʱ��</th>
                    <th>����</th>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#GetUsername(Eval("UserID"))%></td>
                    <td><%#Eval("Keyword") %></td>
                    <td><%#Eval("CreateTime") %></td>
                    <td>
                        <a href="Aution.aspx?id=<%#Eval("id")%>&keyword=<%#Eval("Keyword") %>" title="����">����</a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <div class="pager">
        <IscControl:Pager ID="Pager1" runat="server"  />
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>

<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Aution.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.Promotions.Keywords.Aution.Aution" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
�̼ҿ������ - ��׼�������۹���
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<style>
.red
{
    color: Red;
}
#ddlADList
{
    width: 200px;
}
</style>
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">��</span><a href="Default.aspx">�ؼ��־��۹���</a>  <span class="spl">��</span><span class="curPos">��������</span> 
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <table class="formTable gridView">
        <tr>
            <th colspan="2">
                �����ؼ���
            </th>
        </tr>
        <tr>
	        <td class="tdLeft">��ǰ���۹ؼ��֣�</td>
	        <td class="tdRight"><% =ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestStr("keyword", "")%></td>
        </tr>
        <tr>
	        <td class="tdLeft">Ͷ�Ź�棺</td>
	        <td class="tdRight"><asp:DropDownList runat="server" ID="ddlADList"></asp:DropDownList></td>
        </tr>
        <tr>
	        <td class="tdLeft">�����۸�</td>
	        <td class="tdRight"><asp:TextBox ID="txtClickPrice" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
	        <td class="tdLeft">�ܽ�</td>
	        <td class="tdRight"><asp:TextBox ID="txtTotalPrice" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
	        <td class="tdLeft">ÿ�����ѽ�</td>
	        <td class="tdRight"><asp:TextBox ID="txtCostPriceDay" runat="server"></asp:TextBox></td>
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
                    <th>����</th>
                    <th>���</th>
                    <th>�����۸�</th>
                    <th>�����ܽ��</th>
                    <th>ÿ�����ѽ��</th>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr <%# IsOwnAuction(Eval("UserID")) %>>
                    <td><%# GetIndex() %></td>
                    <td><%# ADeeWu.HuoBi3J.Libary.Utility.SubString(GetADName(Eval("Keyword_AD_ID")),30,"...") %></td>
                    <td><%# Eval("ClickPrice") %></td>
                    <td><%# Eval("TotalPrice") %></td>
                    <td><%# Eval("TotalPriceDay")%></td>
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

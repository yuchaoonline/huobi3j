<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.Promotions.Keywords.AD.Default" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
�̼ҿ������ - ��׼����������
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">��</span><a href="Default.aspx">������ù���</a>  <span class="spl">��</span><span class="curPos">��ӹ��</span>
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
	<table class="formTable gridView">
    <tr>
        <th colspan="2">
            ��ӹ��
        </th>
    </tr>
    <tr>
	    <td class="tdLeft">���⣺</td>
	    <td class="tdRight"><asp:TextBox ID="txtName" runat="server"></asp:TextBox> <span class="require">*</span></td>
    </tr>
    <tr>
	    <td class="tdLeft">������</td>
	    <td class="tdRight"><asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Rows="4"></asp:TextBox> <span class="require">*</span></td>
    </tr>
    <tr>
	    <td class="tdLeft">���ӣ�</td>
	    <td class="tdRight"><asp:TextBox ID="txtLink" runat="server"></asp:TextBox> <span class="require">*</span></td>
    </tr>
    <tr>
	    <td class="tdLeft"></td>
	    <td class="tdRight">
	      <asp:Button ID="btnSubmit" runat="server" Text="���" onclick="btnSubmit_Click" />
	    </td>
    </tr>
</table>

    <table id="resultList" class="gridView">
        <asp:Repeater ID="rpADList" runat="server">
            <HeaderTemplate>
                <tr>
                    <th>����</th>
                    <th>����</th>
                    <th>����</th>
                    <th>���</th>
                    <th>����</th>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# ADeeWu.HuoBi3J.Libary.Utility.SubString(Eval("Name"),10,"...") %></td>
                    <td><%# ADeeWu.HuoBi3J.Libary.Utility.SubString(Eval("Content"), 10, "...")%></td>
                    <td><a href="<%#ADeeWu.HuoBi3J.Libary.WebUtility.FormatURL(Eval("Link")) %>" title="����鿴"><%#ADeeWu.HuoBi3J.Libary.WebUtility.FormatURL(Eval("Link"))%></a></td>
                    <td><%#Convert.ToBoolean(Eval("IsPass"))?"ͨ��":"<font color='red'>δͨ��</font>" %></td>
                    <td>
                        <a href="Del.aspx?id=<%#Eval("id")%>" onclick="return confirm('ȷ��Ҫɾ���ü�¼��?ͬʱ��ɾ���йظü�¼��ͳ�ƣ�');" title="ɾ��">ɾ��</a>
                        <a href="Edit.aspx?id=<%#Eval("id")%>" title="�༭">�༭</a>
                        <a href="../Aution/AuctionLog.aspx?id=<%#Eval("id")%>" title="���ۼ�¼">���ۼ�¼</a>
                        <a href="../Aution/manager.aspx?id=<%#Eval("id")%>" title="���۹���">���۹���</a>
                        <a href="../AD/ADLog.aspx?id=<%#Eval("id")%>" title="���Ѽ�¼">���Ѽ�¼</a>
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

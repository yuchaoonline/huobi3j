<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="ServiceApplication.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.CashTickets.ServiceApplication" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
�̼ҿ������ - �ֽ����ͷ������뿪ͨ
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">��</span><a href="/My/Corp/CashTickets/">�ֽ�ȯ�б�</a><span class="spl">��</span><span class="curPos">�������뿪ͨ</span>
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

<table border="0" cellspacing="0" cellpadding="0" class="formTable">
  <tr>
    <td class="tdLeft">�̼����ƣ�</td>
    <td class="tdRight">
        <asp:Literal ID="liteCorpName" runat="server"></asp:Literal>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">������ҵ��</td>
    <td class="tdRight">
        <asp:Literal ID="liteIndustry" runat="server"></asp:Literal>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">����������</td>
    <td class="tdRight">
        <asp:Literal ID="liteLocation" runat="server"></asp:Literal>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">������</td>
    <td class="tdRight">
        <asp:TextBox ID="txtContract" runat="server" Width="321px" Height="158px" 
            TextMode="MultiLine"></asp:TextBox><span class="require">*</span><span class="tips">����д�ֽ����ͷ�����Ʒ�������</span>
        <asp:RequiredFieldValidator ID="rfvContract" runat="server" Display="Dynamic" ErrorMessage="����д!" ControlToValidate="txtContract"></asp:RequiredFieldValidator>
    </td>
  </tr>
  <%--<tr>
    <td class="tdLeft">�����ٷֱȣ�</td>
    <td class="tdRight">
        <asp:TextBox ID="txtOfferPercent" runat="server" Width="50px"></asp:TextBox><span class="require">*</span><span class="tips">����д�ֽ���񷵻ظ������̵���ɰٷֱ�</span>
        <asp:RequiredFieldValidator ID="rfvOfferPercent" runat="server" Display="Dynamic" ErrorMessage="����д!" ControlToValidate="txtOfferPercent"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator
            ID="revOfferPercent" runat="server" ValidationExpression="\d+" Display="Dynamic" ControlToValidate="txtOfferPercent" ErrorMessage="����д��ȷ!"></asp:RegularExpressionValidator>
    </td>
  </tr>--%>
  <tr>
    <td class="tdLeft">�������ڣ�</td>
    <td class="tdRight"><%=DateTime.Now.ToShortDateString() %></td>
  </tr>
  <tr>
    <td class="tdLeft">&nbsp;</td>
    <td class="tdRight">
    	<asp:Button id="btnSubmit" runat="server" Text="���뿪ͨ" onclick="btnSubmit_Click"></asp:Button>
    </td>
  </tr>
</table>


</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>




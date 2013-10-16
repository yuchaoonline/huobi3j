<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="Edit.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.CashTicketApplications.Edit"  %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
Admin - CashTicketApplications - Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>�ֽ�ȯ���ֹ���</span> &gt; <a href="List.aspx">�����б�</a> &gt; �޸�
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

<table border="0" cellspacing="0" cellpadding="0" class="formTable">
  <tr>
    <td class="tdLeft">�����û�:</td>
    <td class="tdRight">
        <asp:Literal ID="litUserName" runat="server"></asp:Literal>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">�ֽ�ȯ���к�:</td>
    <td class="tdRight"><asp:Literal ID="litCashTicketSerialNum" runat="server"></asp:Literal></td>
  </tr>
  <tr>
    <td class="tdLeft">�ֽ�ȯ��֤��:</td>
    <td class="tdRight"><asp:Literal ID="litCashTicketValidCode" runat="server"></asp:Literal></td>
  </tr>
   <tr>
    <td class="tdLeft">��������:</td>
    <td class="tdRight"><asp:Literal ID="litCostDate" runat="server" ></asp:Literal></td>
  </tr>
  <tr>
    <td class="tdLeft">�����������:</td>
    <td class="tdRight"><asp:Literal ID="litCreateTime" runat="server" ></asp:Literal></td>
  </tr>
  <tr>
    <td class="tdLeft">�޸�����:</td>
    <td class="tdRight"><asp:Literal ID="litModifyTime" runat="server" ></asp:Literal></td>
  </tr>
  
  <tr>
    <td class="tdLeft">�����̼�:</td>
    <td class="tdRight"><asp:Literal ID="litCorpName" runat="server"></asp:Literal></td>
  </tr>
  <tr>
    <td class="tdLeft">��ɰٷֱ�:</td>
    <td class="tdRight"><asp:Literal ID="litOfferPercent" runat="server"></asp:Literal></td>
  </tr>
  <tr>
    <td class="tdLeft">��Ӧ�ֽ�ȯ:</td>
    <td class="tdRight">
       <asp:HyperLink ID="hrefViewCashTicket" runat="server">�鿴</asp:HyperLink>
    </td>
  </tr>
  
  <tr>
    <td class="tdLeft">�������(��λԪ):</td>
    <td class="tdRight"> 
        <asp:TextBox ID="txtReturnMoney" runat="server" CssClass="txtNum"></asp:TextBox> <span class="tips">����ʵ�������д,��������Ӧ��÷����Ľ��,�����Ժ�ͳ��</span>
    </td>
  </tr>
  
  <tr>
    <td class="tdLeft">������Ʒ�����:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtSummary" runat="server" Height="100px" TextMode="MultiLine" 
                Width="280px"></asp:TextBox>
    </td>
  </tr>
  
  <tr>
    <td class="tdLeft">��ע:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine" CssClass="txtNotes"></asp:TextBox> <span class="tips">����д�����Ϣ��ע���Ա</span>
    </td>
  </tr>
  
  <tr>
    <td class="tdLeft">״̬:</td>
    <td class="tdRight">
        <asp:DropDownList ID="ddlCheckState" runat="server">
            <asp:ListItem Value="0">�����</asp:ListItem>
            <asp:ListItem Value="1">ͨ�����</asp:ListItem>
            <asp:ListItem Value="2">��Ч</asp:ListItem>
            <asp:ListItem Value="3">����</asp:ListItem>
        </asp:DropDownList> <span class="require">*</span>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">�Զ���ֵ:</td>
    <td class="tdRight">
    <asp:CheckBox ID="chkDoVirtualTransfer" runat="server" Text="ѡ���ѡ��,ϵͳ�Զ�ִ�������ʺų�ֵ" />
    </td>
  </tr>
  <tr>
    <td class="tdLeft">&nbsp;</td>
    <td class="tdRight">
       <asp:Button ID="btnSubmit" runat="server" Text="�ύ" OnClick="btnSubmit_OnClick" /> <span class="strewColor">ͨ����˺���ҪΪ�û�Ա��ֵ����ɱ��δ���</span>
    </td>
  </tr>
</table>





</asp:Content>


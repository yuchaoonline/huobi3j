<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="Add.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.Job_Callings.Add"  %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
Admin - Market_Categories - Add
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>ְλ��ҵ�������</span> &gt; ��� | <a href="List.aspx">�����б�</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

<table border="0" cellspacing="0" cellpadding="0" class="formTable">
  <tr>
    <td class="tdLeft">��������:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtName" runat="server" CssClass="txtBox"></asp:TextBox><span class="require">*</span>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">����:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtSequence" runat="server" CssClass="txtNum" ></asp:TextBox><span class="require">*</span><span class="tips">������������Խǰ����Խǰ</span>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">����ļ�¼��:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtItemCount" runat="server" CssClass="txtNum" Text="0" ></asp:TextBox><span class="tips">����ǰ̨��ʾ���ڸ÷���ļ�¼��</span>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">��������:</td>
    <td class="tdRight">
       <IscControl:SyncSelector ID="syncSelectorJobCallings" runat="server" 
                DataSourceURL="<%$Resources:SyncSelector,JobCallings_DataSourceURL %>"
                DataSourceName="<%$Resources:SyncSelector,JobCallings_DataSourceName %>" 
                ClientPostNames="<%$Resources:SyncSelector,JobCallings_ClientPostNames %>"
                RefreshClientData="true"
                />
    </td>
  </tr>
  <tr>
    <td class="tdLeft">&nbsp;</td>
    <td class="tdRight">
        <asp:Button ID="btnSubmit" runat="server" Text="�ύ" OnClick="btnSubmit_OnClick" />
    </td>
  </tr>
</table>


</asp:Content>


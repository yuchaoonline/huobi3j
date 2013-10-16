<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="Edit.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.Corps.Edit"  %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
Admin - Corps - Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>�̼ҹ���</span> &gt; <a href="List.aspx">�̼��б�</a> &gt; �޸� | <a href="Add.aspx">���</a> 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

<table border="0" cellspacing="0" cellpadding="0" class="formTable">
  <tr>
    <td class="tdLeft">�̼�����:</td>
    <td class="tdRight">
       <asp:TextBox ID="txtName" runat="server" CssClass="txtBox" ></asp:TextBox> <span class="require">*</span>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">��ϵ��:</td>
    <td class="tdRight">
       <asp:TextBox ID="txtLinkMan" runat="server" CssClass="txtBox" ></asp:TextBox> <span class="require">*</span>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">��ϵ�绰:</td>
    <td class="tdRight">
       <asp:TextBox ID="txtTel" runat="server" CssClass="txtBox" ></asp:TextBox> <span class="require">*</span>
    </td>
  </tr>
   <tr>
    <td class="tdLeft">��Ӫ��ҵ:</td>
    <td class="tdRight">
        <IscControl:SyncSelector ID="syncSelectorCalling" runat="server" 
				DataSourceURL="<%$Resources:SyncSelector,Calling_DataSourceURL %>" 
				DataSourceName="<%$Resources:SyncSelector,Calling_DataSourceName %>" 
				ClientPostNames="<%$Resources:SyncSelector,Calling_ClientPostNames %>"
				RefreshClientData="true"
				/>
        <span class="require">*</span>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">��������:</td>
    <td class="tdRight">
       <IscControl:SyncSelector ID="syncSelectorLocation" runat="server" 
                DataSourceURL="<%$Resources:SyncSelector,Location_DataSourceURL %>" 
                DataSourceName="<%$Resources:SyncSelector,Location_DataSourceName %>" 
                ClientPostNames="<%$Resources:SyncSelector,Location_ClientPostNames %>"
                RefreshClientData="true"
                />
        <span class="strewColor">*</span>
    </td>
  </tr>
  
  <tr>
    <td class="tdLeft">��ַ:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtAddress" runat="server" CssClass="txtAddress" ></asp:TextBox><span class="require">
        *</span> 
    </td>
  </tr>
  <tr>
    <td class="tdLeft">��˾���:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtIntro" runat="server" TextMode="MultiLine" Rows="20" Columns="80"></asp:TextBox>
    <span class="require">*</span>
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
        </asp:DropDownList>
    </td>
  </tr>
   <tr>
    <td class="tdLeft">ҵ��Ա��:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtAdminUsers" runat="server"></asp:TextBox>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">����UIN:</td>
    <td class="tdRight">
        <asp:Literal ID="LitUpUIN" runat="server"></asp:Literal>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">¼��ʱ��:</td>
    <td class="tdRight">
        <asp:Literal ID="litCrateTime" runat="server"></asp:Literal>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">�޸�ʱ��:</td>
    <td class="tdRight">
        <asp:Literal ID="litModifyTime" runat="server"></asp:Literal>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">&nbsp;</td>
    <td class="tdRight">
        <asp:Button ID="btnSubmit" runat="server" Text="�ύ" OnClick="btnSubmit_OnClick" /> 
    </td>
  </tr>
</table>
<%--�̼ҷ���ͨ:<a href="../CT_PartnerCorps/Add.aspx?corpID=<%=corpID %>">��ͨ�ֽ�ȯ����</a>--%>


</asp:Content>


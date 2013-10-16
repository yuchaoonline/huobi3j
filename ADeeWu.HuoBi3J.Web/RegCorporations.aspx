<%@ Page Language="C#" Title="" MasterPageFile="~/MIndex.master"  AutoEventWireup="true" CodeBehind="RegCorporations.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.RegCorporations" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
ȫ��Ӫ���� - �û�ע��
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="/js/isc.js"></script>
<script type="text/javascript">
$(document).ready(function(){
	$('#hrefShowPosition').click(function(){
		var addr = $('#<%=this.txtAddress.ClientID%>').val();
		addr = $.trim(addr);
		if(addr.length>0){
			isc.cookie.set('getposition_addr',addr,new isc.DateTime().addDays(1).currentDate(),null,ADeeWu.HuoBi3J.domain,false);
		}
	});
});
</script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
<!--____________________________begin�̼�ע����Ϣ����____________________________________-->
<table  border="0" align="center" cellpadding="0" cellspacing="0" style="width:75%">

     <tr>
    <td class="tdLeft">&nbsp;</td>
    <td class="tdRight">
        �̼�ע��</td>
  </tr>

     <tr>
    <td class="tdLeft">�̼����ƣ�</td>
    <td class="tdRight">
       <asp:TextBox ID="txtName" runat="server" CssClass="txtBox" ></asp:TextBox> <span class="require">*</span>    </td>
  </tr>
  <tr>
    <td class="tdLeft">��ϵ�ˣ�</td>
    <td class="tdRight">
       <asp:TextBox ID="txtLinkMan" runat="server" CssClass="txtBox" ></asp:TextBox> <span class="require">*</span>    </td>
  </tr>
  <tr>
    <td class="tdLeft">��˾�绰��</td>
    <td class="tdRight">
       <asp:TextBox ID="txtTel" runat="server" CssClass="txtBox" ></asp:TextBox> <span class="require">*</span>    </td>
  </tr>
   <tr>
    <td class="tdLeft">��Ӫ��ҵ��</td>
    <td class="tdRight">
        <IscControl:SyncSelector ID="syncSelectorCalling" runat="server" 
        DataSourceURL="<%$Resources:SyncSelector,Calling_DataSourceURL %>" 
        DataSourceName="<%$Resources:SyncSelector,Calling_DataSourceName %>" 
        ClientPostNames="<%$Resources:SyncSelector,Calling_ClientPostNames %>"
        />&nbsp;<span class="require">*</span>    </td>
  </tr>
  <tr>
    <td class="tdLeft">����������</td>
    <td class="tdRight">
        <IscControl:SyncSelector ID="syncSelectorLocation" runat="server" 
        DataSourceURL="<%$Resources:SyncSelector,Location_DataSourceURL %>" 
        DataSourceName="<%$Resources:SyncSelector,Location_DataSourceName %>" 
        ClientPostNames="<%$Resources:SyncSelector,Location_ClientPostNames %>"
        />
        &nbsp;<span class="require">*</span>    </td>
  </tr>
  <tr>
    <td class="tdLeft">��˾���ʣ�</td>
    <td class="tdRight">
        <asp:DropDownList ID="ddlProperty" runat="server">
            <asp:ListItem Value="���廧">���廧</asp:ListItem>
            <asp:ListItem Value="˽Ӫ��ҵ">˽Ӫ��ҵ</asp:ListItem>
            <asp:ListItem Value="������ҵ">������ҵ</asp:ListItem>
            <asp:ListItem Value="�������ι�˾">�������ι�˾</asp:ListItem>
            <asp:ListItem Value="�ɷ����޹�˾">�ɷ����޹�˾</asp:ListItem>
            <asp:ListItem Value="����">����</asp:ListItem>
        </asp:DropDownList>    </td>
  </tr>
  <tr>
    <td class="tdLeft">��˾��ģ��</td>
    <td class="tdRight">
        <asp:DropDownList ID="ddlEmployees" runat="server">
            <asp:ListItem Value="����50��">����50��</asp:ListItem>
            <asp:ListItem Value="50-149��">50-149��</asp:ListItem>
            <asp:ListItem Value="150-499��">150-499��</asp:ListItem>
            <asp:ListItem Value="500-999��">500-999��</asp:ListItem>
            <asp:ListItem Value="1000������">1000������</asp:ListItem>
        </asp:DropDownList>    </td>
  </tr>
  <tr>
    <td class="tdLeft">��ַ��</td>
    <td class="tdRight">
        <asp:TextBox ID="txtAddress" runat="server" CssClass="txtAddress" ></asp:TextBox>&nbsp;<span class="require">*</span> <a href="/map/getposition.html" target="_blank" id="hrefShowPosition">�鿴����</a>	
    </td>
  </tr>
  <tr>
    <td class="tdLeft">�������꣺</td>
    <td class="tdRight">
	<div class="tips">������������/��˾�����꣬�ø������ܹ�׼ȷ������������Ϣ<br />
	������ <strong style="color:#000;">��ַ</strong> �����Ҳ� <strong style="color:#000;">�鿴����</strong> ѡ������λ��<br />
	�ֱ��γ�ȡ����ȸ��Ƶ������ı�����:</div>
	</td>
  </tr>
  <tr>
    <td class="tdLeft">&nbsp;</td>
    <td class="tdRight">γ�� - <asp:TextBox ID="txtLat" runat="server" Width="200px" /></td>
  </tr>
  <tr>
    <td class="tdLeft">&nbsp;</td>
    <td class="tdRight">���� - <asp:TextBox ID="txtLng" runat="server" Width="200px" /></td>
  </tr>
  <tr>
    <td class="tdLeft">&nbsp;</td>
    <td class="tdRight">&nbsp;</td>
  </tr>
  <tr>
    <td class="tdLeft">��˾��飺</td>
    <td class="tdRight">
        <asp:TextBox ID="txtIntro" runat="server" TextMode="MultiLine" Rows="10" Columns="80" CssClass="txtNotes"></asp:TextBox>
    <span class="require">*</span>
    </td>
  </tr>
  
  
  <tr>
    <td class="tdLeft">�顡֤���룺</td>
    <td class="tdRight"><asp:TextBox ID="txtValidCode" runat="server" width="50" TabIndex="3"></asp:TextBox> <img src="ValidateCode.aspx" /></td>
  </tr>
  <tr>
    <td class="tdLeft">&nbsp;</td>
    <td class="tdRight">
        <asp:Button ID="btnSubmit" runat="server" Text="�ύ" onclick="btnSubmit_OnClick" /></td>
  </tr>
</table>
</asp:Content>
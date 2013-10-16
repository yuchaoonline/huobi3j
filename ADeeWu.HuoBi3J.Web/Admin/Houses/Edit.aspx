<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="Edit.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.Houses.Edit"  ValidateRequest="false" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
Admin - Corps - Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>���߳������</span> &gt; ��Դ��Ϣ�б� &gt; �޸� 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

 <table border="0" cellpadding="0" cellspacing="0" width="95%">
      <tr >
        <td  class="tdLeft" style="width:12%">��Ϣ���⣺</td>
        <td class="tdRight">
          <input type="text" class="txtAddress" id="txtTitle" runat="server"/><span 
              class="require">*</span></td>
      </tr>  
      <tr >
        <td class="tdLeft">�������ʣ�</td>
		<td class="tdRight">
            <asp:RadioButton ID="radProperityByChuZu" GroupName="properity" runat="server" Text="����" Checked="true" />
            <asp:RadioButton ID="radRevert" GroupName="properity" runat="server" Text="ת��"  />
        </td>
      </tr>  
     <tr >
        <td class="tdLeft" style="width:10%">������������</td>
        <td class="tdRight">
        
        <IscControl:SyncSelector ID="syncSelectorLocation" runat="server" 
        DataSourceURL="<%$Resources:SyncSelector,Location_DataSourceURL %>" 
        DataSourceName="<%$Resources:SyncSelector,Location_DataSourceName %>" 
        ClientPostNames="<%$Resources:SyncSelector,Location_ClientPostNames %>"
        RefreshClientData="true"
        />
        
        </td>
      </tr> 
      <tr >
        <td class="tdLeft">���ݵ�ַ��</td>
		<td class="tdRight">
		<input type="text" id="txtAddrees" runat="server" class="txtAddress" /><span class="require">*</span>
		</td>
      </tr> 
      <tr >
        <td class="tdLeft">����·�ߣ�</td>
		<td class="tdRight">
		<input type="text" id="txtBusline" runat=server  class="txtAddress" />
		</td>
      </tr>  
      <tr >
        <td class="tdLeft">�������ͣ�</td>
		<td class="tdRight">
               <asp:DropDownList ID="ddlHouseType" runat="server">
                    <asp:ListItem Value="0">סլ</asp:ListItem>
                    <asp:ListItem Value="1">����</asp:ListItem>
                    <asp:ListItem Value="2">д��¥</asp:ListItem>
                    <asp:ListItem Value="3">����</asp:ListItem>     
                    <asp:ListItem Value="4">����</asp:ListItem>                  
                </asp:DropDownList>
                </td>
      </tr> 
      <tr >
        <td class="tdLeft">���ݽṹ��</td>
        <td class="tdRight">
		<asp:DropDownList ID="ddlHousestrcts" runat="server">
                    <asp:ListItem Value="0">����</asp:ListItem>
                    <asp:ListItem Value="1">һ��һ��</asp:ListItem>
                    <asp:ListItem Value="2">����һ��</asp:ListItem>
                    <asp:ListItem Value="3">���Ҷ���</asp:ListItem>     
                    <asp:ListItem Value="4">����һ��</asp:ListItem>  
                    <asp:ListItem Value="5">����һ��</asp:ListItem>     
                    <asp:ListItem Value="6">���Ҷ���</asp:ListItem>  
                    <asp:ListItem Value="7">�����ṹ</asp:ListItem>                  
        </asp:DropDownList>
        </td>
      </tr>  
      <tr>
        <td class="tdLeft">���������</td>
		<td class="tdRight"><input type="text" onkeyup="value=value.replace(/[^\d]/g,'') " onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" id="txtMap" runat=server  class="txtAddress"  style="width:40px" />ƽ���� <span class="require">*</span>
		</td>
      </tr> 
      <tr>
        <td class="tdLeft">���ݼ۸�</td>
		<td class="tdRight"><input type="text" id="txtPrice" onkeyup="value=value.replace(/[^\d]/g,'') " onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" runat=server class="txtAddress"  style="width:40px" />/��<span 
              class="require">*</span></td>
      </tr>  
      <tr >
        <td class="tdLeft">�������꣺</td>
		<td class="tdRight">���ȣ�<input type="text" id="txtLat" 
                                runat="server" class="txtAddress"  style="width:40px" /> γ�ȣ�<input 
                                type="text" id="txtLng" 
                                runat="server" class="txtAddress"  style="width:40px" />
		</td>
      </tr>  
      <tr >
        <td class="tdLeft">��Ϣ����ʱ��</td>
        <td class="tdRight">
		<IscControl:DateTimeSelector ID="txtExpire" runat="server"></IscControl:DateTimeSelector>
            <span class="require">*</span></td>
      </tr>
	  <tr>
	  <td class="tdLeft">���ʴ�����</td>
      <td class="tdRight">
            <asp:Label ID="lblVisitCount" runat="server" Text="0��"></asp:Label>
			</td>
	  </tr>
      <tr >
        <td class="tdLeft">����˵����</td>
        <td class="tdRight">
          <table style="width:100%">
            <tr>
             <td><FCKeditorV2:FCKeditor ID="txtDesc" ToolbarSet="Basic" runat="server" Width="100%" Height="200" LinkBrowserURL="false"></FCKeditorV2:FCKeditor>
             </td>
             <td>
             <span class="require">*</span>
             </td>
            </tr>
            
          </table>
        </td>
      </tr>
      <tr>
        <td class="tdLeft" style="width:10%">���״̬��</td><td>
               &nbsp;<asp:RadioButton ID="radstate"  GroupName="state" runat="server" Checked=true Text="���޸�״̬" />
               <asp:RadioButton ID="cbochecktrue" GroupName="state" runat="server" Text="ͨ��" />
               &nbsp;<asp:RadioButton ID="cbocheckfalse" GroupName="state"  runat="server" Text="��ͨ��" />
               &nbsp;<asp:RadioButton ID="cboStateEnd"  GroupName="state" runat="server" Text="���Ϊ����" />
        </td>
      </tr>
       <tr>
			 <td colspan="2">
			 <hr/>
			 </td>
		</tr>
		<tr   >
		 	<td colspan="2">����÷�Դ��Ϣ��ר�˸��𣬲�����ø��˻�˾�����е���ϵ��ʽ������д��������</td>
		</tr>
         <tr>
             <td class="tdLeft">��ϵ��������</td>
             <td class="tdRight">
               <input type="text" runat="server" name="txtLinkName" id="txtLinkName" />
             </td>
         </tr>
         <tr>
              <td class="tdLeft">��ϵ�˵绰��</td>
			  <td class="tdRight">
                <input type="text" runat="server" name="txtLinkPhone" id="txtLinkPhone" />
              </td>
         </tr>
         <tr>
              <td class="tdLeft">��ϵ���ʼ���</td>
			  <td class="tdRight">
                <input type="text" runat="server" name="txtLinkEmail" id="txtLinkEmail" />
              </td>
           </tr>
      <tr >
        <td class="tdLeft"></td>
		<td class="tdRight">
              <asp:Button ID="btnSubmit" runat="server" Text="����"  onclick="btnSubmit_Click"/>
        </td>
      </tr>  
       <tr >
      <td colspan="2">&nbsp;</td>
      </tr>
  </table>
 


</asp:Content>


<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="Edit.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.Jobs.Edit"  %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
�ޱ����ĵ�
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>���߳���</span> &gt; <a href="List.aspx">�б�</a> &gt; �޸�
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    
    <div>
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
           <tr  >
               <td class="tdLeft" style="width:16%">��˾���ƣ�</td>
               <td colspan="2">
                   <asp:Label ID="lblCorpName" runat="server"></asp:Label>
               </td>
           </tr>  
           <tr  >
               <td class="tdLeft" style="width:16%">ְλ���ƣ�</td>
               <td colspan="2"><input name="jobName" type="text"   id="jobName" size="38" runat="server"/>
                <span class="require">*</span></td>
           </tr>  
           <tr>
              <td align="left" valign="middle">��������</td>
              <td colspan="2">
                     <IscControl:SyncSelector ID="syncSelectorLocation" runat="server" DataSourceURL="/js/data/Location.js" DataSourceName="aryLocation" ClientPostNames="province,city,area" /><span class="require">*</span></td>
           </tr>
           <tr   >
              <td>�����ַ��</td>
              <td colspan="2"><input name="jobAddress" type="text"  id="jobAddress" size="38" runat="server"/>
                <span class="require">*</span></td>
           </tr>
           
           <tr>
              <td>ְλ���ࣺ</td>
              <td colspan="2">
              <IscControl:SyncSelector ID="syncSelectorJobCategory" runat="server" 
                DataSourceURL="<%$Resources:SyncSelector,JobCategories_DataSourceURL %>" 
                DataSourceName="<%$Resources:SyncSelector,JobCategories_DataSourceName %>" 
                ClientPostNames="<%$Resources:SyncSelector,JobCategories_ClientPostNames %>"
                />
              <span class="require">*</span></td>
           </tr>
           <tr   >
              <td>�Ա�Ҫ��</td>
              <td colspan="2">
			  <label>
			  <select name="jobSex" id="jobSex" runat=server>
			    <option value="0">����</option>
			    <option value="1">��</option>
			    <option value="2">Ů</option>
			    </select>
			  </label></td>
           </tr>
           
           <tr>
              <td valign="top">ѧ��Ҫ��</td>
              <td colspan="2">
              <select name="jobEducation" id="Education" runat="server">
                <option value="0">Сѧ</option>
                <option value="1">����</option>
                <option value="2">����</option>
                <option value="3">�м�</option>
                <option value="4">��ר</option>
                <option value="5" selected="selected">��ר</option>
                <option value="6">����</option>
                <option value="7">MBA</option>
                <option value="8">˶ʿ</option>
                <option value="9">��ʿ</option>
                <option value="10">����</option>
              </select>              </td>
           </tr>
           <tr   >
              <td valign="top">�������飺</td>
              <td colspan="2"><select name="jobExp" id="jobExp" runat="server">
                <option value="0">�ڶ�ѧ��</option>
                <option value="1">Ӧ���ҵ��</option>
                 <option value="2">��������</option>
                 <option value="3">��������</option>
                 <option value="4">��������</option>
                 <option value="5">��������</option>
                  <option value="6">ʮ������</option>
                  <option value="7">����</option>
              </select>                <span class="require">*</span></td>
              </tr>
            
           <tr>
             <td valign="top">������ʽ��</td>
             <td>
            <select id="workType" name='workType'  runat="server">
                <option value='0' >ȫְ</option>
                <option value='1' >��ְ</option>
                <option value='2'>ȫְ/��ְ�Կ�</option>
			</select>
            </td>
             <td>&nbsp;</td>
           </tr>
           <tr>
             <td valign="top">�� н��</td>
             <td><label>
               <input name="MonthlyPay" runat="server"  onkeyup="value=value.replace(/[^\d]/g,'') " onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" type="text" id="MonthlyPay" size="10" /> 
                 Ԫ</label></td>
             <td>&nbsp;</td>
           </tr>
           <tr>
             <td valign="top">��Ƹ������</td>
             <td><input name="JobCount" runat="server"  onkeyup="value=value.replace(/[^\d]/g,'') " onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" type="text" id="JobCount" size="10"  />��</td>
             <td>&nbsp;</td>
           </tr>
            <tr>
             <td valign="top">����Ҫ��</td>
             <td><input name="txtAgeArea" type="text"  id="txtAgeArea" size="38" 
                     runat="server"/>�磺19��-23��</td>
             <td>&nbsp;</td>
           </tr>
           <tr>
         <td valign="top">ְλ������</td>
             <td><textarea id="jobSumny" name="jobSumny" runat=server cols="75"  rows="5">�������ְλ�ļ�Ҫ���ݣ�</textarea>
              </td>
             <td> <span class="require">*</span></td>
           </tr>
           <tr>
             <td valign="top">ְλ��ϸ��</td>
             <td><textarea id="jobDesc" name="jobDesc" runat=server  cols="75"  rows="5">�������ְλ����ϸ������</textarea>
               </td>
             <td><span class="require">*</span></td>
           </tr>
           <tr>
              <td>��ֹʱ�䣺</td>
              <td colspan="2">
                  <IscControl:DateTimeSelector ID="DateTimeSelector1" runat="server"></IscControl:DateTimeSelector>               </td>
           </tr>
           <tr  >
        <td class="tdLeft" style="width:10%">���״̬��</td><td>
               &nbsp;<asp:RadioButton ID="radstate"  GroupName="state" runat="server" Checked=true Text="���޸�״̬" />
               <asp:RadioButton ID="cbochecktrue" GroupName="state" runat="server" Text="ͨ��" />
               &nbsp;<asp:RadioButton ID="cbocheckfalse" GroupName="state"  runat="server" Text="��ͨ��" />
               &nbsp;<asp:RadioButton ID="cboStateEnd"  GroupName="state" runat="server" Text="���Ϊ����" />

        </td>
      </tr>  
           <tr   >
              <td>&nbsp;</td><td colspan="2">&nbsp;</td>
           </tr>
           <tr   >
             <td colspan="3">
             <hr/>
             </td>
             </tr>
            <tr   >
             <td colspan="3">�����ְλ��ר�˸�����Ƹ��������ù�˾�����е���ϵ��ʽ������д��������</td>
             </tr>
            <tr   >
             <td>��ϵ��������</td>
             <td colspan="2"><label>
               <input type="text" runat="server" name="LinkName" id="LinkName" />
             </label></td>
           </tr>
           <tr   >
              <td>��ϵ�˵绰��</td><td colspan="2"><label>
                <input type="text" runat="server" name="LinkPhone" id="LinkPhone" />
              </label></td>
           </tr>
           <tr>
              <td>��ϵ���ʼ���</td><td colspan="2">
                <input type="text" runat="server" name="LinkEmail" id="LinkEmail" />
              </td>
           </tr>
           <tr>
              <td>&nbsp;</td><td colspan="2">
               <asp:Button ID="btnSave" runat="server" Text="����" onclick="btnSave_Click" />
               </td>
           </tr>
           <tr   >
              <td>&nbsp;</td><td colspan="2">&nbsp;
               </td>
           </tr>
           
  </table>
    </div>
    
</asp:Content>


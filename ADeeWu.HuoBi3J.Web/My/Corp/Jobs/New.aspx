<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="New.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.Jobs.New" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
�̼ҿ������ - ������Ƹְλ��Ϣ
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">��</span><a href="/My/Corp/Jobs/">��Ƹ����</a><span class="spl">��</span><span class="curPos">����ְλ��Ϣ</span>
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
     
   <table border="0" cellpadding="0" cellspacing="0">
           <tr >
               <td class="tdLeft">ְλ���ƣ�</td>
               <td class="tdRight"><input name="jobName" type="text"   id="jobName" size="38" runat="server"/>
                <span class="require">*</span></td>
           </tr>  
           <tr>
              <td class="tdLeft">��������</td>
              <td class="tdRight">
                      <IscControl:SyncSelector ID="syncSelectorLocation" runat="server" 
                        DataSourceURL="<%$Resources:SyncSelector,Location_DataSourceURL %>" 
                        DataSourceName="<%$Resources:SyncSelector,Location_DataSourceName %>" 
                        ClientPostNames="<%$Resources:SyncSelector,Location_ClientPostNames %>"
                        />
                <span class="require">*</span></td>
           </tr>
           <%--<tr   >
              <td class="tdLeft">�����ַ��</td>
              <td colspan="2" class="tdRight"><input name="jobAddress" type="text"  id="jobAddress" size="38" runat="server"/>
                <span class="require">*</span></td>
           </tr>--%>
           
           <tr>
              <td class="tdLeft">ְλ���ࣺ</td>
              <td class="tdRight">
              <IscControl:SyncSelector ID="syncSelectorJobCategory" runat="server" 
			  	DataSourceURL="<%$Resources:SyncSelector,JobCategories_DataSourceURL %>" 
                DataSourceName="<%$Resources:SyncSelector,JobCategories_DataSourceName %>" 
                ClientPostNames="<%$Resources:SyncSelector,JobCategories_ClientPostNames %>"
              />
              <span class="require">*</span>
              </td>
           </tr>
		   <tr>
              <td class="tdLeft">��ҵ���ࣺ</td>
              <td class="tdRight">
              <IscControl:SyncSelector ID="syncSelectorCalling" runat="server" 
 				DataSourceURL="<%$Resources:SyncSelector,JobCallings_DataSourceURL %>"
                DataSourceName="<%$Resources:SyncSelector,JobCallings_DataSourceName %>" 
                ClientPostNames="<%$Resources:SyncSelector,JobCallings_ClientPostNames %>"        
			  />
              <span class="require">*</span>
              </td>
           </tr>
           <tr>
              <td class="tdLeft">�Ա�Ҫ��</td>
              <td class="tdRight">
			 
			  <select name="jobSex" id="jobSex" runat=server>
			    <option value="0">����</option>
			    <option value="1">��</option>
			    <option value="2">Ů</option>
			    </select>
			  </td>
           </tr>
           
           <tr>
              <td class="tdLeft">ѧ��Ҫ��</td>
              <td class="tdRight">
              <asp:DropDownList ID="ddlEducation" runat="server">
                  <asp:ListItem Selected="True" Value="0">����</asp:ListItem>
                  <asp:ListItem Value="1">��������</asp:ListItem>
                  <asp:ListItem Value="2">��������</asp:ListItem>
                  <asp:ListItem Value="3">��ר����</asp:ListItem>
                  <asp:ListItem Value="4">��ѧ����</asp:ListItem>
                  <asp:ListItem Value="5">��������</asp:ListItem>
              
              </asp:DropDownList>
              
            </td>
           </tr>
           <tr>
              <td class="tdLeft">�������飺</td>
              <td class="tdRight">
               <asp:DropDownList ID="ddlExp" runat="server">
                   <asp:ListItem Selected="True" Value="0">����</asp:ListItem>
                   <asp:ListItem Value="1">һ������</asp:ListItem>
                   <asp:ListItem Value="2">��������</asp:ListItem>
                   <asp:ListItem Value="3">��������</asp:ListItem>
                   <asp:ListItem Value="4">��������</asp:ListItem>
               
               </asp:DropDownList>
               <span class="require">*</span></td>
           </tr>
           <tr>
             <td class="tdLeft">������ʽ��</td>
             <td class="tdRight">
            <select id="workType" name='workType'  runat="server">
                <option value='0' >ȫְ</option>
                <option value='1' >��ְ</option>
                <option value='2'>ȫְ/��ְ�Կ�</option>
			</select>
            </td>
             <td class="tdRight">&nbsp;</td>
           </tr>
           <tr>
             <td class="tdLeft">�¡���н��</td>
             <td class="tdRight">
               <input name="MonthlyPay" runat="server"  onkeyup="value=value.replace(/[^\d]/g,'') " onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" type="text" id="MonthlyPay" size="10" /> 
                Ԫ
				<span class="require">*</span><span class="tips">����0��ʾ����</span>
				</td>
             <td class="tdRight">&nbsp;</td>
           </tr>
           <tr>
             <td class="tdLeft">��Ƹ������</td>
             <td class="tdRight"><input name="JobCount" runat="server"  onkeyup="value=value.replace(/[^\d]/g,'') " onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" type="text" id="JobCount" size="10"  />��
             <span class="require">*</span><span class="tips">����0��ʾ "����" </span>
             </td>
             <td class="tdRight">&nbsp;</td>
           </tr>
           <tr>
             <td class="tdLeft">����Ҫ��</td>
             <td class="tdRight"><input name="txtAgeArea" type="text"  id="txtAgeArea" width="20" runat="server"/>�磺19��-23��</td>
             <td class="tdRight">&nbsp;</td>
           </tr>
           <%--<tr>
             <td valign="top">ְλ������</td>
             <td><textarea id="jobSumny" runat="server" name="jobSumny"  cols="75"  rows="5">�������ְλ�ļ�Ҫ���ݣ�</textarea>
              </td>
             <td> <span class="require">*</span></td>
           </tr>--%>
           <tr>
             <td class="tdLeft">ְλ��ϸ��</td>
             <td class="tdRight"><textarea id="jobDesc" name="jobDesc" runat="server" class="txtNotes"  cols="60"  rows="15">�������ְλ����ϸ������</textarea>
               <span class="require">*</span>               
			 </td>
             <td class="tdRight">&nbsp;</td>
           </tr>
           <tr>
              <td class="tdLeft">��ֹʱ�䣺</td>
              <td class="tdRight">
                <IscControl:DateTimeSelector ID="DateTimeSelector1" runat="server"></IscControl:DateTimeSelector>  <span class="require">*</span>             </td>
           </tr>
            <tr>
             <td class="tdLeft">�� ϵ �ˣ�</td>
             <td class="tdRight">
               <input type="text" runat="server" name="LinkName" id="LinkName" />
            </td>
           </tr>
           <tr>
              <td class="tdLeft">��ϵ�绰��</td>
              <td class="tdRight">
                <input type="text" runat="server" name="LinkPhone" id="LinkPhone" />
              </td>
           </tr>
           <tr>
              <td class="tdLeft">��ϵ�ʼ���</td>
              <td class="tdRight">
                <input type="text" runat="server" name="LinkEmail" id="LinkEmail" />
              </td>
           </tr>
           <tr>
              <td>&nbsp;</td><td colspan="2">&nbsp;
               </td>
           </tr>
           <tr   >
              <td>&nbsp;</td><td colspan="2"><asp:Button ID="btnSave" runat="server" Text="����" OnClick="btnSave_Click" /></td>
           </tr>
  </table>
     
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>




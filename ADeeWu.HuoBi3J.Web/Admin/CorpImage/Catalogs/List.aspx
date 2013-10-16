<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.CorpImage.Catalogs.List" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>
<%-- --%>

<html><!-- InstanceBegin template="/Templates/Admin_Default.dwt.aspx" codeOutsideHTMLIsLocked="false" -->
<!-- InstanceBeginEditable name="doctitle" -->
<title>Admin - Corps - List</title>
<!-- InstanceEndEditable -->
<!-- InstanceBeginEditable name="head" -->
<!-- InstanceEndEditable -->
<!-- InstanceBeginEditable name="SitePosition" -->
<span>��ҵ������</span> &gt; �б�
<!-- InstanceEndEditable -->
<!-- InstanceBeginEditable name="Content" -->
<input type="hidden" name="page"  value="1" />
<table class="searchTable">
    <tr>
    <td class="key" style="width:80px"> ���⣺</td>
    <td><asp:TextBox ID="txtTitle" runat="server" Width="120px" /></td> 
    <td class="key" style="width:80px">�̼����ƣ�</td>
    <td><asp:TextBox ID="txtCorpID" runat="server" Width="120px" /></td> 
        <td class="key">״̬:</td>
        <td class="input">
        <select name="state" runat="server" id="state">
          <option value="-1">ȫ��</option>
          <option value="0">�����</option>
          <option value="1">�����</option>
          <option value="2">��Ч</option>
          <option value="3">�ѹ���</option>
        </select></td>
        <td class="key"><input name="submit" type="submit" value="����" /></td>
    </tr>
   <%-- <tr>
      <td class="key">��ҵ:</td>
      <td class="input">
      <IscControl:SyncSelector ID="syncSelectorCalling" runat="server" DataSourceURL="/js/data/calling.js" DataSourceName="aryCalling" ClientPostNames="calling" />
	  </td>
      <td class="key">����:</td>
      <td class="input">
	  	<IscControl:SyncSelector ID="syncSelectorLocation" runat="server" DataSourceURL="/js/data/Location.js" DataSourceName="aryLocation" ClientPostNames="province,city,area" />
	  </td>      
    </tr>--%>
</table>


<asp:GridView ID="gvData" runat="server" CssClass="dataGrid" SkinID="gridviewSkin" AutoGenerateColumns="false" ShowFooter="false" BorderStyle="None"  ShowHeader="true">
<Columns>
   
    <asp:TemplateField   HeaderText="���">     
          <ItemTemplate>
           <%# Eval("ID")%>
          </ItemTemplate>
    </asp:TemplateField>
    
     <asp:TemplateField HeaderText="����">
        <ItemTemplate>
            <%# Eval("Title")  %>
        </ItemTemplate>
    </asp:TemplateField>
    
    <asp:TemplateField HeaderText="�̼�����">
        <ItemTemplate>
         <a herf="../Edit.aspx?id=<%#Eval("CorpID") %>"><%#Eval("CorpName") %></a>       
         </ItemTemplate>
    </asp:TemplateField>
        
    <asp:TemplateField HeaderText="�Ƽ�">
        <ItemTemplate>
           <%# ((bool)Eval("IsRecommend")) ? "��" : "��"%>
        </ItemTemplate>
    </asp:TemplateField>
     <asp:TemplateField HeaderText="����">
        <ItemTemplate>             
            <%# ((bool)Eval("IsHidden")) ? "��" : "��"%>
        </ItemTemplate>
    </asp:TemplateField>
    
    <asp:BoundField HeaderText="����ʱ��"  DataField="CreateTime" />   
    <asp:TemplateField HeaderText="����" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option"> <ItemTemplate>
                    <a href='CatalogPhotos/List.aspx?catalogsid=<%#Eval("ID") %>'>�鿴|</a>  
                    
                    <a href='Edit.aspx?id=<%#Eval("ID") %>&corpid=<%#Eval("corpID") %>',>�޸�|</a>  
                    <a href='Del.aspx?id=<%#Eval("ID") %>&corpid=<%#Eval("corpID") %>' dir="ltr" onclick="return confirm('��ȷ��Ҫɾ��������Ϣ��')">
                    ɾ��</a>
                </ItemTemplate>
                </asp:TemplateField>
    
</Columns>
</asp:GridView>



<table width="100%" class="dataGrid_Footer">
    <tr>
        <td class="options">
         <!-- <a href="#" onclick="setCheckGroup('<% = gvData.ClientID %>',true); void(0);">ȫѡ</a> <a href="#" onclick="resverSelect('<% = gvData.ClientID %>'); void(0);">��ѡ</a> -->
        </td>
        <td class="pagerBox">
            <IscControl:Pager ID="Pager1" runat="server"  />
        </td>
    </tr>
</table>




<!-- InstanceEndEditable -->
<!-- InstanceEnd --></html>


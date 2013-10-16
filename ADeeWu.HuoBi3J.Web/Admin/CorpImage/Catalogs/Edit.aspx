<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.CorpImage.Catalogs.Edit" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%-- --%>

<html><!-- InstanceBegin template="/Templates/Admin_Default.dwt.aspx" codeOutsideHTMLIsLocked="false" -->
<!-- InstanceBeginEditable name="doctitle" -->
<title>Admin - CorpImage - Albums - Edit</title>
<!-- InstanceEndEditable -->
<!-- InstanceBeginEditable name="head" -->

<!-- InstanceEndEditable -->
<!-- InstanceBeginEditable name="SitePosition" -->
<span>��ҵ������</span> &gt; <a href="List.aspx">�б�</a> &gt; �޸�
<!-- InstanceEndEditable -->
<!-- InstanceBeginEditable name="Content" -->

<table border="0" cellspacing="0" cellpadding="0" class="formTable">

  <tr>
    <td class="tdLeft">������:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtAlbumsName" runat="server" CssClass="txtBox" ></asp:TextBox>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">�̼�����:</td>
    <td class="tdRight">
       <asp:TextBox ID="txtCorpName" runat="server" CssClass="txtBox" ></asp:TextBox> 
    </td>
  </tr>
   <tr>
    <td class="tdLeft">����ʱ��:</td>
    <td class="tdRight">
        <IscControl:DateTimeSelector ID="txtCreateTime" runat="server"></IscControl:DateTimeSelector>
    </td>
  </tr>
   <tr>
    <td class="tdLeft">��&nbsp;&nbsp;&nbsp; ��:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtSequence" runat="server" CssClass="txtBox"></asp:TextBox>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">�Ƿ�����:</td>
    <td class="tdRight">
        <asp:CheckBox ID="IsHidden" runat="server" Text="��" />
    </td>
  </tr>
  <tr>
    <td class="tdLeft">�Ƿ��Ƽ�:</td>
    <td class="tdRight">
        <asp:CheckBox ID="IsRecommend" runat="server" Text="��" />
    </td>
  </tr>
  <tr >        
		<td class="tdLeft">
              <asp:Button ID="btnSubmit" runat="server" Text="���滭��"  
                    onclick="btnSubmit_Click"/>
        </td>
        <td class="tdRight"> <a href="javascript:history.back();">����</a>
        </td>
  </tr>
</table>
<%--�̼ҷ���ͨ:<a href="../CT_PartnerCorps/Add.aspx?corpID=<%=corpID %>">��ͨ�ֽ�ȯ����</a>--%>


<!-- InstanceEndEditable -->
<!-- InstanceEnd --></html>

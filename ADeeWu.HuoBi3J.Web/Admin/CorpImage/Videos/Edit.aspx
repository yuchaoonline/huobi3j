<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Edit.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.CorpImage.Videos.Edit"  %>


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
<span>��ҵͼƬ����</span> &gt; <a href="List.aspx">�б�</a> &gt; �޸�
<!-- InstanceEndEditable -->
<!-- InstanceBeginEditable name="Content" -->

<table border="0" cellspacing="0" cellpadding="0" class="formTable">
  <tr>
    <td class="tdLeft">�Ӿ�����:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtVideosName" runat="server" CssClass="txtBox"></asp:TextBox>
    </td>
  </tr>
   <tr>
    <td class="tdLeft">�̼�����:</td>
    <td class="tdRight">
       <asp:Literal ID="liteCorpName" runat="server"></asp:Literal>
    </td>
  </tr>
  
   <tr>
    <td class="tdLeft">����ʱ��:</td>
    <td class="tdRight">
        <asp:Literal ID="liteCreateTime" runat="server"></asp:Literal>
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
 
      <tr>
    <td class="tdLeft">��Ƶ��ַ:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtURL" runat="server" CssClass="txtBox" Width="500"></asp:TextBox>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">��&nbsp;&nbsp;&nbsp; ��:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtSummary" runat="server" Rows="4" Columns="50" CssClass="txtNotes"/>
    </td>
  </tr>  
   <tr >        
		<td class="tdLeft">
              <asp:Button ID="btnSubmit" runat="server" Text="�޸�ͼƬ"  
                    onclick="btnSubmit_Click"/>
        </td>
        <td class="tdRight"><a href="javascript:history.back();">����</a>
        </td>
      </tr> 
</table>
<%--�̼ҷ���ͨ:<a href="../CT_PartnerCorps/Add.aspx?corpID=<%=corpID %>">��ͨ�ֽ�ȯ����</a>--%>


<!-- InstanceEndEditable -->
<!-- InstanceEnd --></html>


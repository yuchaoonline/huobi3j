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
<span>企业相册管理</span> &gt; <a href="List.aspx">列表</a> &gt; 修改
<!-- InstanceEndEditable -->
<!-- InstanceBeginEditable name="Content" -->

<table border="0" cellspacing="0" cellpadding="0" class="formTable">

  <tr>
    <td class="tdLeft">相册标题:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtAlbumsName" runat="server" CssClass="txtBox" ></asp:TextBox>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">商家名称:</td>
    <td class="tdRight">
       <asp:TextBox ID="txtCorpName" runat="server" CssClass="txtBox" ></asp:TextBox> 
    </td>
  </tr>
   <tr>
    <td class="tdLeft">创建时间:</td>
    <td class="tdRight">
        <IscControl:DateTimeSelector ID="txtCreateTime" runat="server"></IscControl:DateTimeSelector>
    </td>
  </tr>
   <tr>
    <td class="tdLeft">排&nbsp;&nbsp;&nbsp; 序:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtSequence" runat="server" CssClass="txtBox"></asp:TextBox>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">是否隐藏:</td>
    <td class="tdRight">
        <asp:CheckBox ID="IsHidden" runat="server" Text="是" />
    </td>
  </tr>
  <tr>
    <td class="tdLeft">是否推荐:</td>
    <td class="tdRight">
        <asp:CheckBox ID="IsRecommend" runat="server" Text="是" />
    </td>
  </tr>
  <tr >        
		<td class="tdLeft">
              <asp:Button ID="btnSubmit" runat="server" Text="保存画册"  
                    onclick="btnSubmit_Click"/>
        </td>
        <td class="tdRight"> <a href="javascript:history.back();">返回</a>
        </td>
  </tr>
</table>
<%--商家服务开通:<a href="../CT_PartnerCorps/Add.aspx?corpID=<%=corpID %>">开通现金券服务</a>--%>


<!-- InstanceEndEditable -->
<!-- InstanceEnd --></html>

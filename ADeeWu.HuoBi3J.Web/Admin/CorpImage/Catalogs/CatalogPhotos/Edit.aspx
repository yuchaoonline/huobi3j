<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Edit.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.CorpImage.Catalogs.CatalogPhotos.Edit"  %>

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
<span>企业图片管理</span> &gt; <a href="List.aspx">列表</a> &gt; 修改
<!-- InstanceEndEditable -->
<!-- InstanceBeginEditable name="Content" -->

<table border="0" cellspacing="0" cellpadding="0" class="formTable">
  <tr>
    <td class="tdLeft">图片标题:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtPhotosName" runat="server" CssClass="txtBox"></asp:TextBox>
    </td>
  </tr>
   <tr>
    <td class="tdLeft">商家名称:</td>
    <td class="tdRight">
       <asp:TextBox ID="txtCorpName" runat="server" CssClass="txtBox" ></asp:TextBox> 
    </td>
  </tr>
  <tr>
    <td class="tdLeft">所属画册:</td>
    <td class="tdRight">
        <asp:DropDownList ID="ddlCatalogsName" runat="server" CssClass="txtBox"></asp:DropDownList>
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
 <tr>
    <td class="tdLeft">是否为封面:</td>
    <td class="tdRight">
        <asp:CheckBox ID="IsFace" runat="server" Text="是" />
    </td>
  </tr> 
      <tr>
    <td class="tdLeft">图片链接:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtURL" runat="server" CssClass="txtBox"></asp:TextBox>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">描&nbsp;&nbsp;&nbsp; 述:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtSummary" runat="server" CssClass="txtBox"/>
    </td>
  </tr>  

  <tr>
    <td class="tdLeft">备&nbsp;&nbsp;&nbsp; 注:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtContent" runat="server" CssClass="txtBox"></asp:TextBox>
    </td>
  </tr>
   <tr >        
		<td class="tdLeft">
              <asp:Button ID="btnSubmit" runat="server" Text="修改图片"  
                    onclick="btnSubmit_Click"/>
        </td>
        <td class="tdRight"><a href="javascript:history.back();">返回</a>
        </td>
      </tr> 
</table>
<%--商家服务开通:<a href="../CT_PartnerCorps/Add.aspx?corpID=<%=corpID %>">开通现金券服务</a>--%>


<!-- InstanceEndEditable -->
<!-- InstanceEnd --></html>

<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="Edit.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.CorpImage.Albums.Edit"  %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
Admin - CorpImage - Albums - Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>企业相册管理</span> &gt; <a href="List.aspx">列表</a> &gt; 修改
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

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
              <asp:Button ID="btnSubmit" runat="server" Text="保存相册"  
                    onclick="btnSubmit_Click"/>
        </td>
        <td class="tdRight"> <a href="javascript:history.back();">返回</a>
        </td>
  </tr>
</table>
<%--商家服务开通:<a href="../CT_PartnerCorps/Add.aspx?corpID=<%=corpID %>">开通现金券服务</a>--%>


</asp:Content>


<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="New.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.CorpImage.Catalogs.CatalogPhotos.New" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
ȫ��Ӫ�� - �̼ҹ�������
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
  <a href="/My/Corp/">�ҵ��̼ҷ���</a> &gt;   
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

<table border="0" cellspacing="0" cellpadding="0" class="formTable">
  <tr>
    <td class="tdLeft">ͼƬ����:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtCatalogPhotosName" runat="server" CssClass="txtBox"></asp:TextBox>
    </td>
  </tr> 
  <tr>
    <td class="tdLeft">��������:</td>
    <td class="tdRight">
        <asp:DropDownList ID="ddlCatalogsName" runat="server" CssClass="txtBox"></asp:DropDownList>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">�ϴ�ͼƬ:</td>
    <td class="tdRight">
        <IscControl:FileUploadEx ID="FileUploadEx1" runat="server" AllowFileExt="gif|jpg|jpeg" AllowFileSize="4096000"  />&nbsp;
    <div class="tips">
            �ϴ��ļ����ͱ���Ϊ<%=FileUploadEx1.AllowFileExt %>,�ļ���С<%=FileUploadEx1.AllowFileSize %>�ֽ�
    </div> 
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
  
  
  <tr>
    <td class="tdLeft">�Ƿ�Ϊ����:</td>
    <td class="tdRight">
        <asp:CheckBox ID="IsFace" runat="server" Text="��" />
    </td>
  </tr> 
   
  <tr>
    <td class="tdLeft">����:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtSummary" runat="server" CssClass="txtBox"/>
    </td>
  </tr>
  
  <tr>
    <td class="tdLeft">��ע:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtContent" runat="server" CssClass="txtBox"></asp:TextBox>
    </td>
  </tr>
  
   <tr >        
		<td class="tdLeft">
              <asp:Button ID="btnSubmit" runat="server" Text="����ͼƬ"  onclick="btnSubmit_Click"/>
        </td>
        <td class="tdRight">
            <a href="javascript:history.back();">����</a>
        </td>
      </tr> 
</table>


</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>




<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Edit.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.CorpImage.Catalogs.CatalogPhotos.Edit" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>




<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
ȫ��Ӫ���� - �ҵ��ʻ�
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
  <a href="/My/Corp/">�ҵ��̼ҷ���</a> &gt;<a href=../Phtots/Default.aspx>���߳���</a> &gt;�޸ĳ�����Ϣ
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
     
  <table border="0" cellspacing="0" cellpadding="0" class="formTable">
  <tr>
    <td class="tdLeft">ͼƬ����:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtPhotosName" runat="server" CssClass="txtBox"></asp:TextBox>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">�������:</td>
    <td class="tdRight">
        <asp:DropDownList ID="ddlCatalogsName" runat="server" CssClass="txtBox"></asp:DropDownList>
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
    <td class="tdLeft">ͼƬ����:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtURL" runat="server" CssClass="txtBox"></asp:TextBox>
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
              <asp:Button ID="btnSubmit" runat="server" Text="����ͼƬ"  
                    onclick="btnSubmit_Click"/>
        </td>
        <td class="tdRight"><a href="javascript:history.back();">����</a>
        </td>
      </tr>  
</table>
   
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>


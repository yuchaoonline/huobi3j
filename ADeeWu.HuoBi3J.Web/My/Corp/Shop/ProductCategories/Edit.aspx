<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Edit.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.ProductCategories.Edit" %>
<%@ Register assembly="ADeeWu.HuoBi3J.WebUI" namespace="ADeeWu.HuoBi3J.WebUI" tagprefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
�̼ҿ������ - �༭���̲�Ʒ����
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">��</span><a href="/My/Corp/Shop/">����Ӫ��</a><span class="spl">��</span><a href="/My/Corp/Shop/ProductCategories/">���̲�Ʒ����</a><span class="spl">��</span><span class="curPos">�޸�</span>
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
     
<table class="formTable">
    <tr>
        <td class="tdLeft">
           �������ࣺ
        </td>
        <td class="tdRight">
            <asp:DropDownList ID="ddlCategory" runat="server">
            </asp:DropDownList>
        
            
        </td>
    </tr>
    <tr>
        <td class="tdLeft">
           �������ƣ�
        </td>
        <td class="tdRight">
            <asp:TextBox ID="txtName" runat="server" CssClass="txtBox"></asp:TextBox><span class="require">*</span>
        </td>
    </tr>
    <%--<tr>
        <td class="tdLeft">
           ����ͼƬ��
        </td>
        <td class="tdRight">
            <IscControl:FileUploadEx ID="fileImgUrl" runat="server" AllowFileSize="512000" AllowFileExt="jpg|jpeg|gif|png|bmp" /><span class="require">*</span>
        </td>
    </tr>--%>
    <tr>
        <td class="tdLeft">
           �������أ�
        </td>
        <td class="tdRight">
            <asp:CheckBox ID="chkIsHidden" runat="server" Text="��" />
        </td>
    </tr>
    <tr>
        <td class="tdLeft">
           �š�����
        </td>
        <td class="tdRight">
            <asp:TextBox ID="txtSequence" runat="server" CssClass="txtNum"></asp:TextBox><span class="tips">��ֵԽС����Խǰ</span>
        </td>
    </tr>
    <tr>
        <td class="tdLeft">
           
        </td>
        <td class="tdRight">
            <asp:Button ID="btnSubmit" runat="server" Text="�޸ķ���" 
                onclick="btnSubmit_Click"  />
        </td>
    </tr>
</table>
   
  
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>




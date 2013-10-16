<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.Shop.Default" %>
<%@ Register assembly="ADeeWu.HuoBi3J.WebUI" namespace="ADeeWu.HuoBi3J.WebUI" tagprefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
�̼ҿ������ - ����Ӫ�� - ���̻�������
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">��</span><span class="curPos">���̻�������</span> 
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">   
   
<asp:PlaceHolder ID="ph01" runat="server">
   
<table border="0" cellspacing="0" cellpadding="0" class="formTable">
  <tr>
    <td class="tdLeft">�������ƣ�</td>
    <td class="tdRight">
        <asp:TextBox ID="txtShopName" runat="server" CssClass="txtBox" Width="300px" ReadOnly="true"></asp:TextBox>
    </td>
  </tr>
  <%--<tr>
    <td class="tdLeft">����Logo��</td>
    <td class="tdRight">
        <asp:Label ID="liteShopLogo" runat="server"></asp:Label>
        <img src="<%=this.liteShopLogo %>" onload="isc.util.zoomImg(this,250,250)" />
        <div><IscControl:FileUploadEx ID="fileLogo" runat="server"  AllowFileSize="512000" AllowFileExt="jpg|jpeg|gif|png|bmp" /></div>
    </td>
  </tr>--%>
  <tr>
    <td class="tdLeft">��ϵ��ʽ��</td>
    <td class="tdRight">
        <asp:TextBox ID="txtContact" runat="server" CssClass="txtNotes" TextMode="MultiLine"  Columns="30" Rows="3"></asp:TextBox>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">�ۺ����</td>
    <td class="tdRight">
        <asp:TextBox ID="txtAfterSaleService" runat="server" CssClass="txtNotes" TextMode="MultiLine" Columns="60" Rows="3"></asp:TextBox>
        <div class="tips">�����ݽ�����������̵������ط���ÿһ����Ʒ�������������</div>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">���̲�Ʒ���ࣺ</td>
    <td class="tdRight">
       ��ǰ����� <asp:Label ID="liteNumOfCategories" runat="server" ForeColor="Red"></asp:Label> ���� [ <a href="ProductCategories/">�༭���̷���</a> ]
       <div class="tips">ͨ�������Զ�����࣬�������߽������������Ժ��ܹ����շ���������Ʒ</div>
    </td>
  </tr>
<%--  <tr>
    <td class="tdLeft">�ͻ���ʽ��</td>
    <td class="tdRight">
       <asp:CheckBox ID="chkDeilveryType01" runat="server" Text="�������ȡ��" />
       <asp:CheckBox ID="chkDeilveryType02" runat="server" Text="ƽ��" /> 
       <asp:CheckBox ID="chkDeilveryType03" runat="server" Text="���" /> 
       <asp:CheckBox ID="chkDeilveryType04" runat="server" Text="EMS" /> 
    </td>
  </tr>--%>
  <tr>
    <td class="tdLeft">������ַ��</td>
    <td class="tdRight">
        <asp:TextBox ID="txtAgentShopAddress" runat="server" Width="400px" CssClass="txtAddress"></asp:TextBox>
    </td>
  </tr>
  <tr>
    <td class="tdLeft"></td>
    <td class="tdRight">
        <asp:Button ID="btnSubmit" runat="server" Text="�޸�" 
            onclick="btnSubmit_Click"  />
    </td>
  </tr>
</table>

</asp:PlaceHolder>

<asp:PlaceHolder ID="ph02" runat="server">
<asp:Label ID="lblTips" runat="server" ForeColor="Red"></asp:Label>
<table border="0" cellspacing="0" cellpadding="0" class="formTable">
  <tr>
    <td class="tdLeft">�������ƣ�</td>
    <td class="tdRight">
        <asp:TextBox ID="txtShopName_2" runat="server" CssClass="txtBox" Width="300px" ReadOnly="true"></asp:TextBox>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">��ϵ��ʽ��</td>
    <td class="tdRight">
        <asp:TextBox ID="txtContact_2" runat="server" CssClass="txtNotes" TextMode="MultiLine" Columns="30" Rows="3"></asp:TextBox>
        <div class="tips">�����ݽ�����������̵������ط�����</div>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">�ۺ����</td>
    <td class="tdRight">
        <asp:TextBox ID="txtAfterSaleService_2" runat="server" CssClass="txtNotes" TextMode="MultiLine" Columns="60" Rows="3"></asp:TextBox>
        <div class="tips">�����ݽ�����������̵������ط���ÿһ����Ʒ�������������</div>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">�ͻ���ʽ��</td>
    <td class="tdRight">
       <asp:CheckBox ID="chkDeilveryType01_2" runat="server" Text="�������ȡ��" />
       <asp:CheckBox ID="chkDeilveryType02_2" runat="server" Text="ƽ��" /> 
       <asp:CheckBox ID="chkDeilveryType03_2" runat="server" Text="���" /> 
       <asp:CheckBox ID="chkDeilveryType04_2" runat="server" Text="EMS" /> 
    </td>
  </tr>
  <tr>
    <td class="tdLeft">������ַ��</td>
    <td class="tdRight">
        <asp:TextBox ID="txtAgentShopAddress_2" runat="server" Width="400px" CssClass="txtAddress"></asp:TextBox>
    </td>
  </tr>
  <tr>
    <td class="tdLeft"></td>
    <td class="tdRight">
        <asp:Button ID="btnSubmit_2" runat="server" Text="�޸�" 
            onclick="btnSubmit_Click_2"  />
    </td>
  </tr>
</table>
</asp:PlaceHolder>



   
   
   
  
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>




<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="View.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.Shop.Vouchers.View" %>
<%@ Register assembly="ADeeWu.HuoBi3J.WebUI" namespace="ADeeWu.HuoBi3J.WebUI" tagprefix="IscControl" %>




<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
�̼ҿ������ - �鿴����ƾ֤
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">��</span><a href="/My/Corp/Shop/">����Ӫ��</a><span class="spl">��</span><a href="/My/Corp/Shop/Vouchers/">����ƾ֤</a><span class="spl">��</span><span class="curPos">�鿴</span>  
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
     
 
<table class="formTable">
    
    <tr>
        <td class="tdLeft">
          �ꡡ���⣺
        </td>
        <td class="tdRight">
            <asp:Label ID="lblTitle" runat="server" CssClass="txtBox" />
        </td>
    </tr>
    <tr>
        <td class="tdLeft">
          ������UIN��
        </td>
        <td class="tdRight">
            <asp:Label ID="lblBuyerUIN" runat="server" CssClass="txtBox" />
        </td>
    </tr>
    <tr>
        <td class="tdLeft">
          �������ʺţ�
        </td>
        <td class="tdRight">
            <asp:Label ID="lblBuyerLoginName" runat="server" CssClass="txtBox" />
        </td>
    </tr>
     <tr>
        <td class="tdLeft">
          �������ǳƣ�
        </td>
        <td class="tdRight">
            <asp:Label ID="lblBuyerName" runat="server" CssClass="txtBox" />
        </td>
    </tr>
    <tr>
        <td class="tdLeft">
          ����ʱ�䣺
        </td>
        <td class="tdRight">
            <asp:Label ID="lblCreateTime" runat="server" CssClass="txtBox" />
        </td>
    </tr>
    <tr>
        <td class="tdLeft">
            �ڡ����ݣ�
        </td>
        <td class="tdRight">
            <asp:Label ID="lblContent" runat="server" CssClass="txtBox" />
        </td>
    </tr>
    <tr>
        <td class="tdLeft">
           
        </td>
        <td class="tdRight">
            <a href="javascript:history.back();void(0);">����</a>
        </td>
    </tr>
    
</table>
   
   
   
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>




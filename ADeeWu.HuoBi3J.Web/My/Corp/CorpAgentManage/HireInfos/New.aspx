<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="New.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.CorpAgentManage.HireInfos.New" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
�̼ҿ������ - �����̼Ҵ�����Ƹ��Ϣ
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">��</span><a href="/My/Corp/CorpAgentManage/HireInfos/">����Ӫ��רԱ</a><span class="spl">��</span><span class="curPos">������Ϣ</span>  
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

<div align="center">
<strong>ע:��<span class="require">*</span> ��ʾ������</strong>
</div>

    
<table border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td class="tdLeft">��&nbsp;&nbsp;&nbsp;&nbsp;�⣺</td>
    <td class="tdRight" width="600">
        <asp:TextBox ID="txtTitle" runat="server" CssClass="txtBox" Width="300px"></asp:TextBox><span class="require">*</span><span class="tips">��������ƸӪ��������Ϣ����</span>
    </td>
  </tr>
  
  <tr>
    <td class="tdLeft">��&nbsp;&nbsp;&nbsp;&nbsp;�ݣ�</td>
    <td class="tdRight">
       <asp:TextBox ID="txtContent" runat="server" CssClass="txtNotes" TextMode="MultiLine" Rows="10" Columns="60"></asp:TextBox><br />
        <span class="require">*</span><span class="tips">��������ƸӪ��������Ϣ��ϸ����</span>
    </td>
  </tr>
  
  <tr>
    <td class="tdLeft"></td>
    <td class="tdRight">
        <asp:Button ID="btnSubmit" runat="server" Text="�ύ" onclick="btnSubmit_Click" />
    </td>
  </tr>
  </table>



</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>




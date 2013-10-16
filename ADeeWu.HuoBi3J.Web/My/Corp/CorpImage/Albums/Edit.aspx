<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Edit.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.CorpImage.Albums.Edit" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
商家控制面板 - 修改企业相册
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">　</span><a href="/My/Corp/CorpImage/Albums/">企业相册</a><span class="spl">　</span><span class="curPos">修改相册</span> 
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
     
   <table border="0" cellspacing="0" cellpadding="0" class="formTable">
  <tr>
    <td class="tdLeft">相册标题:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtAlbumsName" runat="server" CssClass="txtBox"></asp:TextBox>
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
   
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>




<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Edit.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.CorpImage.Albums.Photos.Edit" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
商家控制面板 - 编辑企业相册图片
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">　</span><a href="/My/Corp/CorpImage/Albums/">企业相册</a><span class="spl">　</span><a href="/My/Corp/CorpImage/Albums/Photos/">企业相册图片</a><span class="spl">　</span><span class="curPos">编辑图片</span>
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
     
    <table border="0" cellspacing="0" cellpadding="0" class="formTable">
  <tr>
    <td class="tdLeft">图片标题:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtPhotosName" runat="server" CssClass="txtBox"></asp:TextBox>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">所属相册:</td>
    <td class="tdRight">
        <asp:DropDownList ID="ddlAlbumsName" runat="server" CssClass="txtBox"></asp:DropDownList>
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
  <tr>
    <td class="tdLeft">创建时间::</td>
    <td class="tdRight">
        <asp:Literal ID="liteCreateTime" runat="server"></asp:Literal>
    </td>
  </tr>
   <tr >        
		<td class="tdLeft">
              <asp:Button ID="btnSubmit" runat="server" Text="发布图片"  
                    onclick="btnSubmit_Click"/>
        </td>
        <td class="tdRight"><a href="javascript:history.back();">返回</a>
        </td>
      </tr>  
</table>
   
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>




<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Edit.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.CorpAgentManage.HireInfos.Edit" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
商家控制面板 - 修改商家代表招聘信息
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">　</span><a href="/My/Corp/CorpAgentManage/Users/">商家代表管理</a><span class="spl">　</span> <a href="/My/Corp/CorpAgentManage/HireInfos/">招聘信息管理</a><span class="spl">　</span><span class="curPos">修改信息</span>
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

<table border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td class="tdLeft">标&nbsp;&nbsp;&nbsp;&nbsp;题：</td>
    <td class="tdRight" width="600">
        <asp:TextBox ID="txtTitle" runat="server" CssClass="txtBox" Width="300px"></asp:TextBox><span class="require">*</span><span class="tips">请输入招聘营销代理信息标题</span>
    </td>
  </tr>
  
  <tr>
    <td class="tdLeft">内&nbsp;&nbsp;&nbsp;&nbsp;容：</td>
    <td class="tdRight">
       <asp:TextBox ID="txtContent" runat="server" CssClass="txtNotes" TextMode="MultiLine" Rows="10" Columns="60"></asp:TextBox><br />
        <span class="require">*</span><span class="tips">请输入招聘营销代理信息详细内容</span>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">发布时间：</td>
    <td class="tdRight">
       <asp:Literal ID="liteCreateTime" runat="server"></asp:Literal>
    </td>
  </tr>
   <tr>
    <td class="tdLeft">修改时间：</td>
    <td class="tdRight">
       <asp:Literal ID="liteModifyTime" runat="server"></asp:Literal>
    </td>
  </tr>
  <tr>
    <td class="tdLeft"></td>
    <td class="tdRight">
        <asp:Button ID="btnSubmit" runat="server" Text="提交" onclick="btnSubmit_Click" />
    </td>
  </tr>
  </table>


</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>




<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="New.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.CorpAgentManage.Roles.New" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
商家控制面板 - 添加商家代表角色
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="/JS/CheckBoxUtil.js"></script>
<script type="text/javascript">
function CancelCheckBox(jq)
{
   jq.get(0).checked = false;
}
</script>
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">　</span><a href="/My/Corp/CorpAgentManage/Users/">商家代表管理</a><span class="spl">　</span><a href="/My/Corp/CorpAgentManage/Roles/">角色管理</a><span class="spl">　</span><span class="curPos">添加</span>
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">


<table border="0" cellspacing="0" cellpadding="0" class="formTable">
  <tr>
    <td class="tdLeft">角色名称:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtRoleName" runat="server" CssClass="txtBox"></asp:TextBox>
    </td>
  </tr>
   <tr>
    <td class="tdLeft">描述:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtDescription" runat="server" CssClass="txtBox"></asp:TextBox>
    </td>
  </tr>
</table>
<br />
访问权限设置:
<asp:GridView ID="gvData" runat="server" CssClass="gridView" SkinID="userGridViewSkin"  AutoGenerateColumns="false" ShowFooter="false" BorderStyle="None"  ShowHeader="true">
<Columns>
    <asp:TemplateField HeaderStyle-CssClass="col_id"  ItemStyle-CssClass="col_id" HeaderText="行号">
        <ItemTemplate>
            <%#Container.DataItemIndex + 1%>
        </ItemTemplate>
    </asp:TemplateField>
    
    <asp:BoundField HeaderText="功能名称" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" DataField="Name"  />
    <asp:BoundField HeaderText="描述" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" DataField="Description"  />
    <asp:TemplateField HeaderStyle-CssClass="col_option"  ItemStyle-CssClass="col_option" HeaderText="授权">
        <ItemTemplate>
            <input type="checkbox" name="alowFunctionID" value="<%#Eval("ID") %>" onclick="CancelCheckBox($(this).next('[@type=checkbox]'));"/>允许 <input type="checkbox" name="denyFunctionID" value="<%#Eval("ID") %>" onclick="CancelCheckBox($(this).prev('[@type=checkbox]'));" />拒绝
        </ItemTemplate>    
    </asp:TemplateField>
</Columns>
</asp:GridView>


<table width="100%" class="dataGrid_Footer">
    <tr>
        <td class="pagerBox">
            <asp:Button ID="btnSubmit" runat="server" Text="提交" OnClick="btnSubmit_OnClick" />
        </td>
        <td class="options">
           <a href="#" onclick="setCheckGroup('alowFunctionID',true); setCheckGroup('denyFunctionID',false);  return false;">全选允许</a> | <a href="#" onclick="setCheckGroup('denyFunctionID',false); setCheckGroup('alowFunctionID',false);return false;">取消所有</a>
        </td>
    </tr>
</table>




</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>




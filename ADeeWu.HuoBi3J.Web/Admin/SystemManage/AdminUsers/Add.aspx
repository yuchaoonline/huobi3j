<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="Add.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.SystemManage.AdminUsers.Add"  %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
Admin - SystemManage - AdminUsers - Add
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<script src="../../../js/jquery.js" type="text/javascript"></script>
<script type="text/javascript">
function CancelCheckBox(jq)
{
   jq.get(0).checked = false;
}
</script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>后台帐号管理</span> &gt; <a href="List.aspx">用户列表</a> &gt; 添加
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

<table border="0" cellspacing="0" cellpadding="0" class="formTable">
  <tr>
    <td class="tdLeft">帐号:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtLoginName" runat="server" CssClass="txtBox"></asp:TextBox>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">姓名:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtName" runat="server" CssClass="txtBox"></asp:TextBox>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">备注:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine" CssClass="txtNotes"></asp:TextBox>
        <span class="tips">可填写联系方式</span>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">所属角色:</td>
    <td class="tdRight" align="left">
       <asp:CheckBoxList ID="checkBoxListRoles" RepeatDirection="Vertical" RepeatLayout="Flow" runat="server" RepeatColumns="8"></asp:CheckBoxList>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">密码:</td>
    <td class="tdRight"><asp:TextBox ID="txtLoginPwd" runat="server" CssClass="txtBox" TextMode="Password"></asp:TextBox></td>
  </tr>
  <tr>
    <td class="tdLeft">密码确认:</td>
    <td class="tdRight"><asp:TextBox ID="txtLoginPwd2" runat="server" CssClass="txtBox" TextMode="Password"></asp:TextBox></td>
  </tr>
</table>

<br />
访问权限设置,用户权限设置将会覆盖所属的角色所拥有的权限:
<asp:GridView ID="gvData" runat="server" CssClass="dataGrid" SkinID="gridviewSkin" AutoGenerateColumns="false" ShowFooter="false" BorderStyle="None"  ShowHeader="true">
<Columns>
    <asp:TemplateField HeaderStyle-CssClass="col_id"  ItemStyle-CssClass="col_id" HeaderText="ID">
        <ItemTemplate>
            <!-- <input type="checkbox" name="id" value="<%#Eval("ID") %>" />--> <%#Eval("ID") %>
        </ItemTemplate>    
    </asp:TemplateField>
    
    <asp:BoundField HeaderText="页面名称" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" DataField="PageName" />
    <asp:BoundField HeaderText="描述" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" DataField="Description"  />
    <asp:BoundField HeaderText="URL" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" DataField="URL"  />
    <asp:TemplateField HeaderStyle-CssClass="col_option"  ItemStyle-CssClass="col_option" HeaderText="操作">
        <ItemTemplate>
            <input type="checkbox" name="alowPageID" value="<%#Eval("ID") %>" onclick="CancelCheckBox($(this).next('[@type=checkbox]'));"/>允许 <input type="checkbox" name="denyPageID" value="<%#Eval("ID") %>" onclick="CancelCheckBox($(this).prev('[@type=checkbox]'));" />拒绝
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
           <a href="#" onclick="setCheckGroup('alowPageID',true); setCheckGroup('denyPageID',false);  return false;">全选允许</a> | <a href="#" onclick="setCheckGroup('denyPageID',false); setCheckGroup('alowPageID',false);return false;">取消所有</a>
        </td>
    </tr>
</table>


</asp:Content>


<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="Add.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.Job_Callings.Add"  %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
Admin - Market_Categories - Add
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>职位行业分类管理</span> &gt; 添加 | <a href="List.aspx">分类列表</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

<table border="0" cellspacing="0" cellpadding="0" class="formTable">
  <tr>
    <td class="tdLeft">分类名称:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtName" runat="server" CssClass="txtBox"></asp:TextBox><span class="require">*</span>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">排序:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtSequence" runat="server" CssClass="txtNum" ></asp:TextBox><span class="require">*</span><span class="tips">分类排序，数字越前排序越前</span>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">分类的记录数:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtItemCount" runat="server" CssClass="txtNum" Text="0" ></asp:TextBox><span class="tips">用于前台显示属于该分类的记录数</span>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">所属分类:</td>
    <td class="tdRight">
       <IscControl:SyncSelector ID="syncSelectorJobCallings" runat="server" 
                DataSourceURL="<%$Resources:SyncSelector,JobCallings_DataSourceURL %>"
                DataSourceName="<%$Resources:SyncSelector,JobCallings_DataSourceName %>" 
                ClientPostNames="<%$Resources:SyncSelector,JobCallings_ClientPostNames %>"
                RefreshClientData="true"
                />
    </td>
  </tr>
  <tr>
    <td class="tdLeft">&nbsp;</td>
    <td class="tdRight">
        <asp:Button ID="btnSubmit" runat="server" Text="提交" OnClick="btnSubmit_OnClick" />
    </td>
  </tr>
</table>


</asp:Content>


<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="Edit.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.Corps.Edit"  %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
Admin - Corps - Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>商家管理</span> &gt; <a href="List.aspx">商家列表</a> &gt; 修改 | <a href="Add.aspx">添加</a> 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

<table border="0" cellspacing="0" cellpadding="0" class="formTable">
  <tr>
    <td class="tdLeft">商家名称:</td>
    <td class="tdRight">
       <asp:TextBox ID="txtName" runat="server" CssClass="txtBox" ></asp:TextBox> <span class="require">*</span>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">联系人:</td>
    <td class="tdRight">
       <asp:TextBox ID="txtLinkMan" runat="server" CssClass="txtBox" ></asp:TextBox> <span class="require">*</span>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">联系电话:</td>
    <td class="tdRight">
       <asp:TextBox ID="txtTel" runat="server" CssClass="txtBox" ></asp:TextBox> <span class="require">*</span>
    </td>
  </tr>
   <tr>
    <td class="tdLeft">经营行业:</td>
    <td class="tdRight">
        <IscControl:SyncSelector ID="syncSelectorCalling" runat="server" 
				DataSourceURL="<%$Resources:SyncSelector,Calling_DataSourceURL %>" 
				DataSourceName="<%$Resources:SyncSelector,Calling_DataSourceName %>" 
				ClientPostNames="<%$Resources:SyncSelector,Calling_ClientPostNames %>"
				RefreshClientData="true"
				/>
        <span class="require">*</span>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">所属地区:</td>
    <td class="tdRight">
       <IscControl:SyncSelector ID="syncSelectorLocation" runat="server" 
                DataSourceURL="<%$Resources:SyncSelector,Location_DataSourceURL %>" 
                DataSourceName="<%$Resources:SyncSelector,Location_DataSourceName %>" 
                ClientPostNames="<%$Resources:SyncSelector,Location_ClientPostNames %>"
                RefreshClientData="true"
                />
        <span class="strewColor">*</span>
    </td>
  </tr>
  
  <tr>
    <td class="tdLeft">地址:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtAddress" runat="server" CssClass="txtAddress" ></asp:TextBox><span class="require">
        *</span> 
    </td>
  </tr>
  <tr>
    <td class="tdLeft">公司简介:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtIntro" runat="server" TextMode="MultiLine" Rows="20" Columns="80"></asp:TextBox>
    <span class="require">*</span>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">状态:</td>
    <td class="tdRight">
        <asp:DropDownList ID="ddlCheckState" runat="server">
            <asp:ListItem Value="0">待审核</asp:ListItem>
            <asp:ListItem Value="1">通过审核</asp:ListItem>
            <asp:ListItem Value="2">无效</asp:ListItem>
            <asp:ListItem Value="3">过期</asp:ListItem>
        </asp:DropDownList>
    </td>
  </tr>
   <tr>
    <td class="tdLeft">业务员绑定:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtAdminUsers" runat="server"></asp:TextBox>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">上线UIN:</td>
    <td class="tdRight">
        <asp:Literal ID="LitUpUIN" runat="server"></asp:Literal>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">录入时间:</td>
    <td class="tdRight">
        <asp:Literal ID="litCrateTime" runat="server"></asp:Literal>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">修改时间:</td>
    <td class="tdRight">
        <asp:Literal ID="litModifyTime" runat="server"></asp:Literal>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">&nbsp;</td>
    <td class="tdRight">
        <asp:Button ID="btnSubmit" runat="server" Text="提交" OnClick="btnSubmit_OnClick" /> 
    </td>
  </tr>
</table>
<%--商家服务开通:<a href="../CT_PartnerCorps/Add.aspx?corpID=<%=corpID %>">开通现金券服务</a>--%>


</asp:Content>


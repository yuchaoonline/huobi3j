<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="Edit.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.CorpAgent.Applications.Edit"  %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
Admin - CorpAgent - Applications - Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>营销代理商申请简历</span> &gt; <a href="List.aspx">列表</a> &gt; 修改
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

<table class="formTable">
        <tr>
            <td class="tdLeft">
            真实姓名：
            </td>
            <td class="tdRight">
                <asp:TextBox ID="txtRealName" runat="server" CssClass="txtUserName"></asp:TextBox> <span class="require">*</span>
                <asp:RequiredFieldValidator ID="rfvTxtRealName" ControlToValidate="txtRealName" runat="server" ErrorMessage="请填写！" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">
            性&nbsp;&nbsp;&nbsp;&nbsp;别：
            </td>
            <td class="tdRight">
               <asp:DropDownList ID="ddlSex" runat="server">
                    <asp:ListItem Text="请选择" Value="" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="男" Value="男"></asp:ListItem>
                    <asp:ListItem Text="女" Value="女"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">
            出生日期：
            </td>
            <td class="tdRight">
                <IscControl:DateTimeSelector ID="txtBirthday" runat="server" CssClass="txtDate"></IscControl:DateTimeSelector> <span class="require">*</span>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">
            所在地区：
            </td>
            <td class="tdRight">
                <IscControl:SyncSelector ID="syncSelectorLocation" runat="server" 
                DataSourceURL="<%$Resources:SyncSelector,Location_DataSourceURL %>" 
                DataSourceName="<%$Resources:SyncSelector,Location_DataSourceName %>" 
                ClientPostNames="<%$Resources:SyncSelector,Location_ClientPostNames %>"
                /> <span class="require">*</span>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">
            具体地址：
            </td>
            <td class="tdRight">
                <asp:TextBox ID="txtAddress" runat="server" CssClass="txtAddress"></asp:TextBox> <span class="require">*</span>
                <asp:RequiredFieldValidator ID="rfvTxtAddress" ControlToValidate="txtAddress" runat="server" ErrorMessage="请填写！" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">
            邮政编码：
            </td>
            <td class="tdRight">
                <asp:TextBox ID="txtZipCode" runat="server" CssClass="txtZipCode"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">
            学&nbsp;&nbsp;&nbsp;&nbsp;历：
            </td>
            <td class="tdRight">
                <IscControl:SyncSelector ID="syncSelectorEducation" runat="server" 
                DataSourceURL="<%$Resources:SyncSelector,Education_DataSourceURL %>" 
                DataSourceName="<%$Resources:SyncSelector,Education_DataSourceName %>" 
                ClientPostNames="<%$Resources:SyncSelector,Education_ClientPostNames %>"
                /> <span class="require">*</span>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">
            工作经验：
            </td>
            <td class="tdRight">
                <IscControl:SyncSelector ID="syncSelectorWorkExp" runat="server" 
                DataSourceURL="<%$Resources:SyncSelector,WorkExp_DataSourceURL %>" 
                DataSourceName="<%$Resources:SyncSelector,WorkExp_DataSourceName %>" 
                ClientPostNames="<%$Resources:SyncSelector,WorkExp_ClientPostNames %>"
                /> <span class="require">*</span>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">
            毕业学校：
            </td>
            <td class="tdRight">
                <asp:TextBox ID="txtSchool" runat="server" CssClass="txtAddress"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">
            专&nbsp;&nbsp;&nbsp;&nbsp;业：
            </td>
            <td class="tdRight">
                <asp:TextBox ID="txtSpeciality" runat="server" CssClass="txtBox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">
            技&nbsp;&nbsp;&nbsp;&nbsp;能：
            </td>
            <td class="tdRight">
                <asp:TextBox ID="txtSkill" runat="server" TextMode="MultiLine" CssClass="txtNotes"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">备&nbsp;&nbsp;&nbsp;&nbsp;注：</td>
            <td class="tdRight">
            <asp:TextBox ID="txtNote" runat="server" TextMode="MultiLine" CssClass="txtNotes"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">申请时间：</td>
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
            <td class="tdLeft">审&nbsp;&nbsp;&nbsp;&nbsp;核：</td>
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
            <td class="tdLeft"></td>
            <td class="tdRight">
                <asp:Button ID="btnSubmit" runat="server" Text="修改" 
                    onclick="btnSubmit_Click" />
            </td>
        </tr>
    </table>


</asp:Content>


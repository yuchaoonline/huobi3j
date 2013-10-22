<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="Edit.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.CorpAgent.UserInCorps.Edit"  %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="ADeeWuControl" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
Admin - CorpAgent - UserInCorps - Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>商家邀请代理商</span> &gt; <a href="List.aspx">列表</a> &gt; 修改
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

<table class="formTable">
        <tr>
            <td class="tdLeft">
            代理商名称：
            </td>
            <td class="tdRight">
                <asp:Literal ID="liteCorpAgentName" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">
            代理商通讯号码：
            </td>
            <td class="tdRight">
                <asp:Literal ID="liteCorpAgentUIN" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">
            商家名称：
            </td>
            <td class="tdRight">
                <asp:Literal ID="liteCorpName" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">
            商家通讯号码：
            </td>
            <td class="tdRight">
                <asp:Literal ID="liteCorpUIN" runat="server"></asp:Literal>
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


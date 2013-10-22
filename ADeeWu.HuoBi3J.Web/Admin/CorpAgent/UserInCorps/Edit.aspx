<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="Edit.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.CorpAgent.UserInCorps.Edit"  %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="ADeeWuControl" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
Admin - CorpAgent - UserInCorps - Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>�̼����������</span> &gt; <a href="List.aspx">�б�</a> &gt; �޸�
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

<table class="formTable">
        <tr>
            <td class="tdLeft">
            ���������ƣ�
            </td>
            <td class="tdRight">
                <asp:Literal ID="liteCorpAgentName" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">
            ������ͨѶ���룺
            </td>
            <td class="tdRight">
                <asp:Literal ID="liteCorpAgentUIN" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">
            �̼����ƣ�
            </td>
            <td class="tdRight">
                <asp:Literal ID="liteCorpName" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">
            �̼�ͨѶ���룺
            </td>
            <td class="tdRight">
                <asp:Literal ID="liteCorpUIN" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">����ʱ�䣺</td>
            <td class="tdRight">
                <asp:Literal ID="liteCreateTime" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">�޸�ʱ�䣺</td>
            <td class="tdRight">
                <asp:Literal ID="liteModifyTime" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">��&nbsp;&nbsp;&nbsp;&nbsp;�ˣ�</td>
            <td class="tdRight">
                <asp:DropDownList ID="ddlCheckState" runat="server">
                    <asp:ListItem Value="0">�����</asp:ListItem>
                    <asp:ListItem Value="1">ͨ�����</asp:ListItem>
                    <asp:ListItem Value="2">��Ч</asp:ListItem>
                    <asp:ListItem Value="3">����</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
         <tr>
            <td class="tdLeft"></td>
            <td class="tdRight">
                <asp:Button ID="btnSubmit" runat="server" Text="�޸�" 
                    onclick="btnSubmit_Click" />
            </td>
        </tr>
    </table>


</asp:Content>


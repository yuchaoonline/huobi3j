<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="Edit.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.WebIM.UINS.Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    无标题文档
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <div>
        <table border="0" cellspacing="0" cellpadding="0" class="formTable">
            <tr>
                <td class="tdLeft">UIN号码:</td>
                <td class="tdRight">
                    <asp:TextBox ID="txtUIN" runat="server" CssClass="txtBox" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdLeft">排序:</td>
                <td class="tdRight">
                    <asp:TextBox ID="txtSequence" runat="server" CssClass="txtBox"></asp:TextBox></td>
            </tr>

            <tr>
                <td class="tdLeft">是否推荐:</td>
                <td class="tdRight">
                    <asp:CheckBox ID="cboReCommend" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="tdLeft">是否已使用:</td>
                <td class="tdRight">
                    <asp:Label ID="lblIsUsed" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tdLeft">生成时间:</td>
                <td class="tdRight">
                    <asp:Label ID="lblCreateTime" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tdLeft">&nbsp;</td>
                <td class="tdRight">
                    <asp:Button ID="btnSubmit" runat="server" Text="保存" OnClick="btnSubmit_OnClick" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>


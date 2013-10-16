<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="New.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Keyword.New" %>




<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    全民营销 - 个人管理中心 - 精准搜索
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <table class="formTable">
        <tr>
            <td class="tdLeft">关键字:</td>
            <td class="tdRight">
                <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
                <span class="require">*</span>
                <asp:RequiredFieldValidator ID="rfvKeyword" runat="server" ErrorMessage="关键字不能为空!" ControlToValidate="txtKeyword"></asp:RequiredFieldValidator><br />
                <span class="tips">(请填写单个关键字,长度不超出10个字符)</span>
                <div id="TopKeywordCoins"></div>
            </td>
        </tr>

        <tr>
            <td class="tdLeft"></td>
            <td class="tdRight">
                <asp:Button ID="btnSubmit" runat="server" Text="设定" OnClick="btnSubmit_Click" />
            </td>
        </tr>
    </table>
</asp:Content>


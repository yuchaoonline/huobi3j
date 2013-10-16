<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MAdmin.Master" AutoEventWireup="true" CodeBehind="New.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.FreeAdmission.New" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <table border="0" cellspacing="0" cellpadding="0" class="formTable">
        <tr>
            <td class="tdLeft">序列号:</td>
            <td class="tdRight">
                <asp:TextBox ID="txtSeqNO" runat="server" CssClass="txtBox"></asp:TextBox><span class="require">*</span>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">密码:</td>
            <td class="tdRight">
                <asp:TextBox ID="txtSeqPwd" runat="server" CssClass="txtBox"></asp:TextBox><span class="require">*</span>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">期限:</td>
            <td class="tdRight">
                <asp:TextBox ID="txtStartDate" runat="server" CssClass="txtNum"></asp:TextBox>
                -
                <asp:TextBox ID="txtEndDate" runat="server" CssClass="txtNum"></asp:TextBox>
                <span class="require">*</span>日期格式：2013-1-1
            </td>
        </tr>
        <tr>
            <td class="tdLeft">金额:</td>
            <td class="tdRight">
                <asp:TextBox ID="txtMoney" runat="server" CssClass="txtBox"></asp:TextBox><span class="require">*</span>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">总申请次数:</td>
            <td class="tdRight">
                <asp:TextBox ID="txtTotalCount" runat="server" CssClass="txtBox"></asp:TextBox><span class="require">*</span>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">&nbsp;</td>
            <td class="tdRight">
                <asp:Button ID="btnSubmit" runat="server" Text="生成" OnClick="btnSubmit_OnClick" />
            </td>
        </tr>
    </table>
</asp:Content>

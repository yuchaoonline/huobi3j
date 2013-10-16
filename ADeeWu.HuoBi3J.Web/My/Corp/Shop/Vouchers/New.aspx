<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="New.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.Shop.Vouchers.New" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    商家控制面板 - 添加电子凭证
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <span class="spl"></span><a href="/My/Corp/Shop/">在线营销</a><span class="spl">　</span><a href="/My/Corp/Shop/Vouchers/">电子凭证</a><span class="spl">　</span><span class="curPos">添加</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

    <table border="0" cellspacing="0" cellpadding="0" class="formTable">
        <tr>
            <td class="tdLeft">标&nbsp;&nbsp;&nbsp;题：</td>
            <td class="tdRight">
                <asp:TextBox ID="txtVouchersTitle" runat="server" CssClass="txtBox" Width="400px"></asp:TextBox><span class="require">*</span><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtVouchersTitle" ErrorMessage="请填写凭证标题！"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">用户UIN：</td>
            <td class="tdRight">
                <asp:TextBox ID="txtUserNo" runat="server" CssClass="txtBox" Width="80px"></asp:TextBox><span class="require">*</span><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUserNo" ErrorMessage="请填写消费者通讯号码！"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">详细描述：</td>
            <td class="tdRight">
                <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" CssClass="txtNotes" Columns="50" Rows="4"></asp:TextBox>

            </td>
        </tr>

        <tr>
            <td class="tdLeft"></td>
            <td class="tdRight">
                <asp:Button ID="btnSubmit" runat="server" Text="提交"
                    OnClick="btnSubmit_Click" />

            </td>
        </tr>
    </table>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">
</asp:Content>




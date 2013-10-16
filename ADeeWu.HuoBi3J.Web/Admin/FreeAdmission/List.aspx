<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MAdmin.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.FreeAdmission.List" %>
<%@ Register assembly="ADeeWu.HuoBi3J.WebUI" namespace="ADeeWu.HuoBi3J.WebUI" tagprefix="IscControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <asp:GridView Width="100%" ID="gvData" runat="server" CssClass="gridView" SkinID="userGridViewSkin" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField HeaderText="ID" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" DataField="ID">
                <HeaderStyle CssClass="col_title"></HeaderStyle>
                <ItemStyle CssClass="col_title"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="SeqNo" HeaderText="序列号" />
            <asp:BoundField DataField="SeqPwd" HeaderText="密码" />
            <asp:TemplateField HeaderStyle-CssClass="col_id" ItemStyle-CssClass="col_id" HeaderText="限期">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("StartDate") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbStartDate" runat="server" Text='<%# Bind("StartDate") %>'></asp:Label>
                    -<asp:Label ID="lbEndDate" runat="server" Text='<%# Bind("EndDate") %>'></asp:Label>
                </ItemTemplate>

<HeaderStyle CssClass="col_id"></HeaderStyle>

<ItemStyle CssClass="col_id"></ItemStyle>
            </asp:TemplateField>
            <asp:BoundField DataField="Money" HeaderText="金额（元）" />
            <asp:BoundField DataField="TotalCount" HeaderText="总数" />
            <asp:BoundField DataField="UserApplyCount" HeaderText="申请数" />
        </Columns>
    </asp:GridView>
    <table width="100%" class="dataGrid_Footer" style="margin-top: -5px;">
        <tr>
            <td class="options">&nbsp;
        
            </td>
            <td class="pagerBox">
                <isccontrol:pager id="Pager1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>

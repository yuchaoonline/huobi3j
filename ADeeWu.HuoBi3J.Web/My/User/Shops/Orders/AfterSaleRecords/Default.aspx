<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Shops.Orders.AfterSaleRecords.Default" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    个人控制面板 - 售后服务记录
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <span class="spl"></span><span class="curPos">售后服务记录</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

    <table class="searchTable">
        <tr>
            <td class="key" style="width: 80px">订单号：
            </td>
            <td>
                <asp:TextBox ID="txtOrderCode" runat="server" Width="120px" />

            </td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" Text="搜索" OnClick="btnSubmit_Click" />
            </td>
        </tr>
    </table>

    <asp:GridView ID="gvData" runat="server" CssClass="gridView" SkinID="userGridViewSkin" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="OrderCode" HeaderText="订单号" />
            <asp:BoundField DataField="ProductName" HeaderText="产品名称" />
            <asp:BoundField DataField="CreateTime" HeaderText="发布日期" />
            <%--<asp:BoundField DataField="ModifyTime" HeaderText="更新日期" />--%>
            <asp:TemplateField HeaderText="处理结果">
                <ItemTemplate>
                    <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
    Eval("ReSult").ToString(),
    new string[][]{
        new string[]{"0","无处理"},
        new string[]{"1","退货"},
        new string[]{"2","换货"},
        new string[]{"3","维修"}
    }               
    )
                    %>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <div class="pager">
        <IscControl:Pager ID="Pager1" runat="server" />
    </div>

</asp:Content>

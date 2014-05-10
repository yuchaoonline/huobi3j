<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Coins.Default" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="CashTicketControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    个人控制面板 - 虚拟金币历史记录
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <span class="spl"></span><span class="curPos">虚拟金币历史记录</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <table class="searchTable">
        <tr>
            <td class="key">筛选：</td>
            <td class="input">
                <asp:DropDownList ID="ddlState" runat="server">
                    <asp:ListItem Value="-1" Selected="True">全部</asp:ListItem>
                    <asp:ListItem Value="0">增加</asp:ListItem>
                    <asp:ListItem Value="1">扣除</asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="btnSubmit" runat="server" Text="搜索" OnClick="btnSubmit_Click" />
                <span style="color: red;">当前1个金币可兑换0.1元钱，满10元可通过支付宝等方式取出，详情请联系客服QQ：1959831331</span>
            </td>
        </tr>
    </table>

    <asp:GridView ID="gvData" runat="server" CssClass="gridView" SkinID="userGridViewSkin" AutoGenerateColumns="false" ShowFooter="false" ShowHeader="true">
        <Columns>
            <asp:TemplateField HeaderStyle-CssClass="col_id" ItemStyle-CssClass="col_id" HeaderText="行号">
                <ItemTemplate>
                    <%# (this.pageSize * (this.pageIndex - 1)) + Container.DataItemIndex + 1%>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField HeaderText="增加(个)" HeaderStyle-CssClass="col_money" ItemStyle-CssClass="col_money" DataField="InCoin" DataFormatString="{0:0}" />
            <asp:BoundField HeaderText="扣除(个)" HeaderStyle-CssClass="col_money" ItemStyle-CssClass="col_money" DataField="OutCoin" DataFormatString="{0:0}" />
            <asp:BoundField HeaderText="剩余(个)" HeaderStyle-CssClass="col_account" ItemStyle-CssClass="col_account" DataField="Remain" DataFormatString="{0:0}" />
            <asp:BoundField HeaderText="备注" HeaderStyle-CssClass="col_notes" ItemStyle-CssClass="col_notes" DataField="Notes" HtmlEncode="false" />
            <asp:BoundField HeaderText="时间" HeaderStyle-CssClass="col_datetime" ItemStyle-CssClass="col_datetime" DataField="CreateTime" />
            <%-- <asp:TemplateField HeaderText="操作" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option">
        <ItemTemplate>
            <a href="Edit.aspx?id=<%#Eval("ID") %>">修改</a> | <a href="Del.aspx?id=<%#Eval("ID") %>">删除</a>
        </ItemTemplate>
    </asp:TemplateField>--%>
        </Columns>
    </asp:GridView>


    <div class="pager">
        <CashTicketControl:Pager ID="Pager1" runat="server" />
    </div>

</asp:Content>




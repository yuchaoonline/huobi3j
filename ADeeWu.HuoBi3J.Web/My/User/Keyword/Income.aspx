<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Income.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Keyword.Income" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    全民营销 - 个人管理中心 - 精准搜索
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <asp:HiddenField ID="hfKeywordID" runat="server" />
    <table id="resultList" class="gridView">
        <asp:Repeater ID="rpResultList" runat="server">
            <HeaderTemplate>
                <tr>
                    <th>关键字</th>
                    <th>广告</th>
                    <th>价格</th>
                    <th>收益</th>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# keyword %></td>
                    <td><%# ADeeWu.HuoBi3J.Libary.Utility.SubString(GetADName(Eval("adid")), 40, "...")%></td>
                    <td><%# Eval("ClickPrice") %></td>
                    <td><%# (ADeeWu.HuoBi3J.Libary.Utility.GetDecimal(Eval("ClickPrice"),0) * 0.3m) %></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <div class="pager">
        <IscControl:Pager ID="Pager1" runat="server" />
    </div>
</asp:Content>


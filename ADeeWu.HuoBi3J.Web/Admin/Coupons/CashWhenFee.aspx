<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MAdmin.Master" AutoEventWireup="true" CodeBehind="CashWhenFee.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.Coupons.CashWhenFee" %>

<%@ Import Namespace="ADeeWu.HuoBi3J.Libary" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="ADeeWuControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <table class="searchTable">
        <tr>
            <td><a href="CashWhenFeeLog.aspx">统计数据</a></td>
        </tr>
    </table>
    <table class="gridView" width="100%">
        <asp:Repeater ID="rpResult" runat="server">
            <HeaderTemplate>
                <tr>
                    <th>消费金额</th>
                    <th>抵扣金额</th>
                    <th>商家</th>
                    <th>用户</th>
                    <th>有效期</th>
                    <th>券数/已使用</th>
                    <th>操作时间</th>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <tr>
                        <td>
                            <%# Eval("fee").GetDecimal().ToString("0.00") %>
                        </td>
                        <td>
                            <%# Eval("money").GetDecimal().ToString("0.00") %>
                        </td>
                        <td>
                            <%# Eval("companyname") %>
                        </td>
                        <td>
                            <%# Eval("username") %>
                        </td>
                        <td>
                            <%# Eval("startdate").GetDateTime().ToString("yyyy/MM/dd")%> - <%#Eval("enddate").GetDateTime().ToString("yyyy/MM/dd") %>
                        </td>
                        <td>
                            <%# Eval("count") %>/<%# Eval("usecount") %>
                        </td>
                        <td>
                            <%# Eval("createtime").GetDateTime().ToString("yyyy/MM/dd hh:mm") %>
                        </td>
                    </tr>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <div class="pager">
        <ADeeWuControl:Pager ID="Pager1" runat="server" />
    </div>
</asp:Content>

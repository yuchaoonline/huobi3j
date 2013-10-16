<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="DeFault.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.SupplyDemand.DeFault" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="CashTicketControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    现金券赠送网 - 我的帐户 - 竞投报价 - 招标信息管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <a href="/Account/Default.aspx">我的帐户首页</a> &gt; 竞投报价 &gt; 招标信息管理  
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

    <div>
        <table class="searchTable">
            <tr>
                <td>标题：</td>
                <td width="100px">
                    <asp:TextBox ID="title" runat="server"></asp:TextBox></td>
                <td>发布时间：</td>
                <td>
                    <CashTicketControl:DateTimeSelector ID="beginTime" runat="server"></CashTicketControl:DateTimeSelector>
                    至<CashTicketControl:DateTimeSelector ID="endTime" runat="server"></CashTicketControl:DateTimeSelector><asp:Button ID="btnquery" runat="server" Text="查询" />
                </td>
            </tr>
        </table>
        <asp:GridView Width="100%" ID="gvData" runat="server" CssClass="gridView" SkinID="userGridViewSkin" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" HeaderText="标题">
                    <ItemTemplate>
                        <%#Eval("Title")%>
                    </ItemTemplate>
                    <HeaderStyle CssClass="col_title"></HeaderStyle>
                    <ItemStyle CssClass="col_title"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-CssClass="col_datetime" ItemStyle-CssClass="col_datetime" HeaderText="发布时间">
                    <ItemTemplate>
                        <%#Eval("CreateTime","{0:yyyy-MM-dd}")%>
                    </ItemTemplate>
                    <HeaderStyle CssClass="col_datetime"></HeaderStyle>
                    <ItemStyle CssClass="col_datetime"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-CssClass="col_datetime" ItemStyle-CssClass="col_datetime" HeaderText="刷新时间" Visible="false">
                    <ItemTemplate>
                        <%#Eval("RefreshTime","{0:yyyy-MM-dd}")%>
                    </ItemTemplate>
                    <HeaderStyle CssClass="col_datetime"></HeaderStyle>
                    <ItemStyle CssClass="col_datetime"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-CssClass="col_datetime" ItemStyle-CssClass="col_datetime" HeaderText="过期时间">
                    <ItemTemplate>
                        <%#Eval("EndTime","{0:yyyy-MM-dd}")%>
                    </ItemTemplate>
                    <HeaderStyle CssClass="col_datetime"></HeaderStyle>
                    <ItemStyle CssClass="col_datetime"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="状态">
                    <ItemTemplate>
                        <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                Eval("CheckState").ToString(),
                new string[][]{
                    new string[]{"0","待审核"},
                    new string[]{"1","已审核"},
                    new string[]{"2","无效"},
                    new string[]{"3","过期"}
                }               
                )
                        %>
                    </ItemTemplate>
                    <HeaderStyle CssClass="col_state" />
                    <ItemStyle CssClass="col_state" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="招标状态">
                    <ItemTemplate>
                        <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                   Eval("Status").ToString(),
                   new string[][]{
                    new string[]{"0","未完成招标"},
                    new string[]{"1","已完成招标"}
                   }               
                   )
                        %>
                    </ItemTemplate>
                    <HeaderStyle CssClass="col_state" />
                    <ItemStyle CssClass="col_state" />
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option" HeaderText="操作">
                    <ItemTemplate>
                        <a href='Show.aspx?id=<%# Eval("ID") %>'>查看投标信息</a> <a style='display: <%# Eval("Status").ToString()=="1"?"none":"inline"%>' href='Edit.aspx?id=<%# Eval("ID") %>'>修改</a>&nbsp;<a href='Del.aspx?id=<%# Eval("ID") %>' onclick='return confirm("您确认要删除这条信息吗？")'>删除</a>
                    </ItemTemplate>
                    <HeaderStyle CssClass="col_id"></HeaderStyle>
                    <ItemStyle CssClass="col_id"></ItemStyle>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
        <div class="pager" style="text-align: center">
            <CashTicketControl:Pager ID="Pager1" runat="server" />
        </div>
    </div>

</asp:Content>




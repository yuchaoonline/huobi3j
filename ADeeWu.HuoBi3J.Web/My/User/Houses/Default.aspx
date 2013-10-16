<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Houses.Default" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    个人控制面板 - 在线出租管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <span class="spl"></span><span class="curPos">在线出租管理</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

    <table class="searchTable">
        <tr>
            <td class="key" style="width: 50px">标题：</td>
            <td>
                <asp:TextBox ID="txtTitle" runat="server" Width="120px"></asp:TextBox>
            </td>
            <td style="width: 60px">房屋结构：</td>
            <td>
                <asp:DropDownList ID="ddlhousestrcts" runat="server">
                    <asp:ListItem Value="-1">全部</asp:ListItem>
                    <asp:ListItem Value="0">单间</asp:ListItem>
                    <asp:ListItem Value="1">一室一厅</asp:ListItem>
                    <asp:ListItem Value="2">二室一厅</asp:ListItem>
                    <asp:ListItem Value="3">二室二厅</asp:ListItem>
                    <asp:ListItem Value="4">三室一厅</asp:ListItem>
                    <asp:ListItem Value="5">四室一厅</asp:ListItem>
                    <asp:ListItem Value="6">四室二厅</asp:ListItem>
                    <asp:ListItem Value="7">其他结构</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>发布时间：</td>
            <td>&nbsp;<IscControl:DateTimeSelector ID="txtBeginTime" Width="90px" runat="server"></IscControl:DateTimeSelector>
                至<IscControl:DateTimeSelector ID="txtEndTime" runat="server" Width="90px"></IscControl:DateTimeSelector>
                &nbsp;<asp:Button ID="btnSubmit" runat="server" Text="搜索" OnClick="btnSubmit_Click" />
            </td>
        </tr>
    </table>
    <div style="text-align: center">
        <asp:GridView ID="gvData" runat="server" CssClass="gridView" SkinID="userGridViewSkin" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderStyle-CssClass="col_id" ItemStyle-CssClass="col_id" HeaderText="编号">
                    <ItemTemplate>
                        <%--<input type="checkbox" name="id" value="<%#Eval("homeCode") %>" />--%> <a href="/Houses/View.aspx?id=<%#Eval("ID")%>" target="_blank"><%#Eval("homeCode") %></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <%-- <asp:BoundField HeaderText="房屋结构" HeaderStyle-CssClass="col_account" ItemStyle-CssClass="col_account" DataField="HouseStructText" >
                 <HeaderStyle CssClass="col_account"></HeaderStyle>
                 <ItemStyle CssClass="col_account"></ItemStyle>
                 </asp:BoundField>--%>
                <asp:TemplateField HeaderText="标题" HeaderStyle-CssClass="col_datetime" ItemStyle-CssClass="col_datetime">
                    <ItemTemplate>
                        <a href="/Houses/View.aspx?id=<%# Eval("ID") %>" target="_blank"><%# Eval("Title") %></a>
                    </ItemTemplate>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="房屋性质">
                    <ItemTemplate>
                        <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                                                Eval("Properity").ToString(),
                                "其它",
                                new string[][]{
                                    new string[]{"0","出租"},
                                    new string[]{"1","转让"}
                                }               
                                )
                        %>
                    </ItemTemplate>

                </asp:TemplateField>
                <%--<asp:BoundField HeaderText="房屋面积" HeaderStyle-CssClass="col_notes" ItemStyle-CssClass="col_notes"  DataField="AreaSize" >
                </asp:BoundField>--%>
                <asp:BoundField HeaderText="月租" HeaderStyle-CssClass="col_money"
                    ItemStyle-CssClass="col_money" DataField="Price" Visible="False"></asp:BoundField>
                <asp:BoundField DataField="CreateTime" HeaderText="发布时间" />
                <%-- <asp:TemplateField HeaderText="状态">
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
                </asp:TemplateField>--%>
                <asp:BoundField DataField="VisitCount" HeaderText="访问次数" />
                <asp:TemplateField HeaderText="操作" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option">
                    <ItemTemplate>
                        <a href="Edit.aspx?id=<%#Eval("ID") %>" style='display: <%# Eval("CheckState").ToString()=="4"?"none":"inline"%>'>修改|</a>
                        <a href="Del.aspx?id=<%#Eval("homeCode") %>" dir="ltr" onclick="return confirm('您确认要删除这条信息吗？')">删除</a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>


    <div class="pager">
        <IscControl:Pager ID="Pager1" runat="server" />
    </div>
</asp:Content>

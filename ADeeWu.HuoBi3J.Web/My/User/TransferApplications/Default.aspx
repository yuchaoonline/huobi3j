<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.TransferApplications.Default" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    个人控制面板 -　我的转帐申请历史记录
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <span class="spl"></span><span class="curPos">我的转帐申请历史记录</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <table class="searchTable">
        <tr>
            <td class="key">状态筛选：</td>
            <td class="input">
                <asp:DropDownList ID="ddlState" runat="server">
                    <asp:ListItem Value="-1" Selected="True">全部</asp:ListItem>
                    <asp:ListItem Value="0">待审核</asp:ListItem>
                    <asp:ListItem Value="1">已审核</asp:ListItem>
                    <asp:ListItem Value="2">无效</asp:ListItem>
                    <asp:ListItem Value="3">已过期</asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="btnSubmit" runat="server" Text="搜索" OnClick="btnSubmit_Click" />
            </td>
        </tr>
    </table>

    <asp:GridView ID="gvData" runat="server" CssClass="gridView" SkinID="userGridViewSkin" AutoGenerateColumns="false" ShowFooter="false" ShowHeader="true">
        <Columns>
            <asp:TemplateField HeaderStyle-CssClass="col_id" ItemStyle-CssClass="col_id" HeaderText="ID">
                <ItemTemplate>
                    <%--<input type="checkbox" name="id" value="<%#Eval("ID") %>" />--%> <%#Eval("ID") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="申请转帐" HeaderStyle-CssClass="col_money" ItemStyle-CssClass="col_money" DataField="TransferMoney" />
            <asp:BoundField HeaderText="转帐支付宝" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" DataField="AlipayAccount" />
            <asp:TemplateField HeaderStyle-CssClass="col_state" ItemStyle-CssClass="col_state" HeaderText="状态">
                <ItemTemplate>
                    <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                Eval("CheckState").ToString(),
                new string[][]{
                    new string[]{"0","待审核"},
                    new string[]{"1","<span style='color:#FF0000;'>已审核</span>"},
                    new string[]{"2","无效"},
                    new string[]{"3","过期"}
                }               
                )
                    %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="备注" HeaderStyle-CssClass="col_notes" ItemStyle-CssClass="col_notes" DataField="Notes" />
            <asp:BoundField HeaderText="申请时间" HeaderStyle-CssClass="col_datetime" ItemStyle-CssClass="col_datetime" DataField="CreateTime" />
            <asp:BoundField HeaderText="修改时间" HeaderStyle-CssClass="col_datetime" ItemStyle-CssClass="col_datetime" DataField="ModifyTime" />
            <%--<asp:TemplateField HeaderText="操作" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option">
        <ItemTemplate>
            <a href="Edit.aspx?id=<%#Eval("ID") %>">修改</a> | <a href="View.aspx?id=<%#Eval("ID") %>">查看</a>
        </ItemTemplate>
    </asp:TemplateField>--%>
        </Columns>
    </asp:GridView>


    <div class="pager">
        <IscControl:Pager ID="Pager1" runat="server" />
    </div>


</asp:Content>




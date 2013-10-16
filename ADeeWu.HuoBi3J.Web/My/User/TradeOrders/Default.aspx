<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.TradeOrders.Default" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    个人控制面板 -　我的充值订单
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <span class="spl"></span><span class="curPos">我的充值订单</span> | <a href="Order.aspx">在线充值</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <table class="searchTable">
        <tr>
            <td class="key">订单号：</td>
            <td class="input">
                <asp:TextBox ID="txtOrderCode" runat="server"></asp:TextBox>
            </td>
            <td class="key">订单状态：</td>
            <td class="input">
                <asp:DropDownList ID="ddlOrderState" runat="server">
                    <asp:ListItem Value="-1" Text="全部"></asp:ListItem>
                    <asp:ListItem Value="0" Text="未付款"></asp:ListItem>
                    <asp:ListItem Value="1" Text="处理中"></asp:ListItem>
                    <asp:ListItem Value="2" Text="已完成"></asp:ListItem>
                    <asp:ListItem Value="3" Text="无效"></asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="btnSubmit" runat="server" Text="搜索" OnClick="btnSubmit_Click" />
            </td>
        </tr>
    </table>



    <asp:GridView ID="gvData" runat="server" CssClass="gridView" SkinID="userGridViewSkin" AutoGenerateColumns="false" ShowFooter="false" ShowHeader="true">
        <Columns>
            <asp:TemplateField HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" HeaderText="订单号">
                <ItemTemplate>
                    <%#Eval("OrderCode") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="充值金额" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title">
                <ItemTemplate>
                    <%#Eval("TotalFee","{0:0.00}元")%>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField HeaderText="下单时间" HeaderStyle-CssClass="col_datetime" ItemStyle-CssClass="col_datetime" DataField="CreateTime" />
            <asp:TemplateField HeaderText="当前状态" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option">
                <ItemTemplate>
                    <%#ADeeWu.HuoBi3J.Libary.WebUtility.Switch( Eval("OrderState").ToString(),
               new string[,]{
                   {"0",string.Format("<a href=\"PayNow.aspx?order={0}\" target=\"_blank\">立即付款</a>",Eval("OrderCode"))},
                   {"1","处理中"},
                   {"2","完成"},
                   {"3","无效"}
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




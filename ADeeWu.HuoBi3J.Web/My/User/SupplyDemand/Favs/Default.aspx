<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.SupplyDemand.Favs.Default" %>


<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="CashTicketControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    现金券赠送网 - 我的帐户 -竞投报价 - 我收藏的投标信息
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <!-- 这里放样式,js 代码-->
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#txtbegintime").dynDateTime(); //defaults
            jQuery("#txtendtime").dynDateTime();
        });
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <a href="/Account/Default.aspx">我的帐户首页</a>  &gt; 竞价投标 &gt; 我收藏的投标信息   
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <div>
        <table class="searchTable">
            <tr>
                <td class="key" style="width: 50px">标签：</td>
                <td>
                    <asp:TextBox ID="note" runat="server" Width="120px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>收藏时间：</td>
                <td>&nbsp;
                <CashTicketControl:DateTimeSelector ID="beginTime" Width="90px" runat="server"></CashTicketControl:DateTimeSelector>
                    至<CashTicketControl:DateTimeSelector ID="endTime" runat="server" Width="90px"></CashTicketControl:DateTimeSelector>
                    &nbsp;<input name="submit" type="submit" value="搜索" /></td>
            </tr>
        </table>


        <asp:GridView Width="100%" ID="gvData" runat="server" CssClass="gridView" SkinID="userGridViewSkin" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderStyle-CssClass="col_id" ItemStyle-CssClass="col_id" HeaderText="收藏时间">
                    <ItemTemplate>
                        <%#Eval("CreateTime")%>
                    </ItemTemplate>
                    <HeaderStyle CssClass="col_id"></HeaderStyle>
                    <ItemStyle CssClass="col_id"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="标签">
                    <ItemTemplate>
                        <a href='../../../../SupplyDemand/View.aspx?id=<%# Eval("SID") %>'><%# Eval("Notes")%></a>
                    </ItemTemplate>
                    <HeaderStyle CssClass="col_money" />
                    <ItemStyle CssClass="col_datetime" />
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-CssClass="col_id" ItemStyle-CssClass="col_id" HeaderText="状态">
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
                    <HeaderStyle CssClass="col_id"></HeaderStyle>
                    <ItemStyle CssClass="col_id"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderStyle-CssClass="col_id" ItemStyle-CssClass="col_id" HeaderText="发布时间">
                    <ItemTemplate>
                        <%#Eval("CreateTime")%>
                    </ItemTemplate>
                    <HeaderStyle CssClass="col_id"></HeaderStyle>
                    <ItemStyle CssClass="col_id"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-CssClass="col_id" ItemStyle-CssClass="col_id" HeaderText="刷新时间">
                    <ItemTemplate>
                        <%#Eval("RefreshTime","{0:yyyy-MM-dd}")%>
                    </ItemTemplate>
                    <HeaderStyle CssClass="col_id"></HeaderStyle>
                    <ItemStyle CssClass="col_id"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-CssClass="col_id" ItemStyle-CssClass="col_id" HeaderText="过期时间">
                    <ItemTemplate>
                        <%#Eval("EndTime","{0:yyyy-MM-dd}")%>
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

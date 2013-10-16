<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.SupplyDemand.Bidders.Default" %>


<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="CashTicketControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    现金券赠送网 - 我的帐户 -竞投报价 - 我参与的招标信息
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
    <a href="/Account/Default.aspx">我的帐户首页</a>  &gt; 竞投报价 &gt; 我参与的招标信息   
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
                <asp:TemplateField HeaderStyle-CssClass="col_id" ItemStyle-CssClass="col_id" HeaderText="发标时间">
                    <ItemTemplate>
                        <%#Eval("CreateTime")%>
                    </ItemTemplate>
                    <HeaderStyle CssClass="col_id"></HeaderStyle>
                    <ItemStyle CssClass="col_id"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="标题">
                    <ItemTemplate>
                        <a href='../../../../SupplyDemand/View.aspx?id=<%# Eval("ID") %>'><%# Eval("Title")%></a>
                    </ItemTemplate>
                    <HeaderStyle CssClass="col_money" />
                    <ItemStyle CssClass="col_datetime" />
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-CssClass="col_id" ItemStyle-CssClass="col_id" HeaderText="状态">
                    <ItemTemplate>
                        <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                              Eval("Status").ToString(),
                new string[][]{
                    new string[]{"0","未中标"},
                    new string[]{"1","已中标"}
                }               
                )
                        %>
                    </ItemTemplate>
                    <HeaderStyle CssClass="col_id"></HeaderStyle>
                    <ItemStyle CssClass="col_id"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderStyle-CssClass="col_id" ItemStyle-CssClass="col_id" HeaderText="投标时间">
                    <ItemTemplate>
                        <%#Eval("SD_BiddersCreateTime")%>
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
                <asp:TemplateField HeaderStyle-CssClass="col_id" ItemStyle-CssClass="col_id" HeaderText="操作">
                    <ItemTemplate>
                        <a style='display: <%# Eval("Status").ToString()=="0"?"inline":"none" %>' href='Edit.aspx?id=<%# Eval("SD_BiddersID") %>'>修改</a>
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

<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="List.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.WebIM.UINS.List" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="CashTicketControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    无标题文档
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

    <div>
        <input type="hidden" name="page" value="1" />
        <table class="searchTable">
            <tr>

                <td class="input">账号:
            <input type="text" name="uin" id="uin" runat="server" class="txtBox" />
                    生成时间:<CashTicketControl:DateTimeSelector ID="time" runat="server"></CashTicketControl:DateTimeSelector>
                    至
                    <CashTicketControl:DateTimeSelector ID="time2" runat="server"></CashTicketControl:DateTimeSelector><input type="submit" value="搜索" />
                    &nbsp;</td>


            </tr>
        </table>

        <div style="text-align: left">
            <asp:GridView ID="gvData" runat="server" CssClass="dataGrid" SkinID="gridviewSkin"
                AutoGenerateColumns="False" BorderStyle="None">
                <Columns>
                    <asp:TemplateField HeaderStyle-CssClass="col_id" ItemStyle-CssClass="col_id" HeaderText="ID">
                        <ItemTemplate>
                            <input type="checkbox" name="id" value="<%#Eval("ID") %>" />
                            <%#Eval("ID") %>
                        </ItemTemplate>

                        <HeaderStyle CssClass="col_id"></HeaderStyle>

                        <ItemStyle CssClass="col_id"></ItemStyle>
                    </asp:TemplateField>
                    <asp:HyperLinkField HeaderText="UIN号码" HeaderStyle-CssClass="col_title"
                        ItemStyle-CssClass="col_title" DataNavigateUrlFields="ID"
                        DataNavigateUrlFormatString="Edit.aspx?id={0}" DataTextField="UIN">
                        <HeaderStyle CssClass="col_title"></HeaderStyle>

                        <ItemStyle CssClass="col_title"></ItemStyle>
                    </asp:HyperLinkField>
                    <asp:TemplateField HeaderText="是否已使用">
                        <ItemTemplate>
                            <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                Eval("HasUsed").ToString(),
                new string[][]{
                    new string[]{"False","未使用"},
                    new string[]{"True","已使用"},
                }               
                )
                            %>
                        </ItemTemplate>
                        <HeaderStyle CssClass="col_state" />
                        <ItemStyle CssClass="col_state" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="是否推荐">
                        <ItemTemplate>
                            <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                Eval("IsRecommend").ToString(),
                new string[][]{
                    new string[]{"False","不推荐"},
                    new string[]{"True","推荐"},
                }               
                )
                            %>
                        </ItemTemplate>
                        <HeaderStyle CssClass="col_state" />
                        <ItemStyle CssClass="col_state" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="排序">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Sequence") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle CssClass="col_state" />
                        <ItemStyle CssClass="col_state" />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="生成时间" HeaderStyle-CssClass="col_datetime" ItemStyle-CssClass="col_datetime" DataField="CreateTime" HtmlEncode="true" DataFormatString="{0:d}" />
                    <asp:TemplateField HeaderText="操作" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option">
                        <ItemTemplate>
                            <a href="Edit.aspx?id=<%#Eval("ID") %>">修改</a> <%--| <a href="Del.aspx?id=<%#Eval("ID") %>">删除</a>--%>
                        </ItemTemplate>

                        <HeaderStyle CssClass="col_option"></HeaderStyle>

                        <ItemStyle CssClass="col_option"></ItemStyle>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>


        <table width="100%" class="dataGrid_Footer">
            <tr>
                <td class="options">
                    <!-- <a href="#" onclick="setCheckGroup('<% = gvData.ClientID %>',true); void(0);">全选</a> <a href="#" onclick="resverSelect('<% = gvData.ClientID %>'); void(0);">反选</a> -->
                </td>
                <td class="pagerBox">
                    <CashTicketControl:Pager ID="Pager1" runat="server" />
                </td>
            </tr>
        </table>

    </div>

</asp:Content>


<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="List.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.WebIM.UINS.List" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="CashTicketControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    �ޱ����ĵ�
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

                <td class="input">�˺�:
            <input type="text" name="uin" id="uin" runat="server" class="txtBox" />
                    ����ʱ��:<CashTicketControl:DateTimeSelector ID="time" runat="server"></CashTicketControl:DateTimeSelector>
                    ��
                    <CashTicketControl:DateTimeSelector ID="time2" runat="server"></CashTicketControl:DateTimeSelector><input type="submit" value="����" />
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
                    <asp:HyperLinkField HeaderText="UIN����" HeaderStyle-CssClass="col_title"
                        ItemStyle-CssClass="col_title" DataNavigateUrlFields="ID"
                        DataNavigateUrlFormatString="Edit.aspx?id={0}" DataTextField="UIN">
                        <HeaderStyle CssClass="col_title"></HeaderStyle>

                        <ItemStyle CssClass="col_title"></ItemStyle>
                    </asp:HyperLinkField>
                    <asp:TemplateField HeaderText="�Ƿ���ʹ��">
                        <ItemTemplate>
                            <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                Eval("HasUsed").ToString(),
                new string[][]{
                    new string[]{"False","δʹ��"},
                    new string[]{"True","��ʹ��"},
                }               
                )
                            %>
                        </ItemTemplate>
                        <HeaderStyle CssClass="col_state" />
                        <ItemStyle CssClass="col_state" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="�Ƿ��Ƽ�">
                        <ItemTemplate>
                            <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                Eval("IsRecommend").ToString(),
                new string[][]{
                    new string[]{"False","���Ƽ�"},
                    new string[]{"True","�Ƽ�"},
                }               
                )
                            %>
                        </ItemTemplate>
                        <HeaderStyle CssClass="col_state" />
                        <ItemStyle CssClass="col_state" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="����">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Sequence") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle CssClass="col_state" />
                        <ItemStyle CssClass="col_state" />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="����ʱ��" HeaderStyle-CssClass="col_datetime" ItemStyle-CssClass="col_datetime" DataField="CreateTime" HtmlEncode="true" DataFormatString="{0:d}" />
                    <asp:TemplateField HeaderText="����" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option">
                        <ItemTemplate>
                            <a href="Edit.aspx?id=<%#Eval("ID") %>">�޸�</a> <%--| <a href="Del.aspx?id=<%#Eval("ID") %>">ɾ��</a>--%>
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
                    <!-- <a href="#" onclick="setCheckGroup('<% = gvData.ClientID %>',true); void(0);">ȫѡ</a> <a href="#" onclick="resverSelect('<% = gvData.ClientID %>'); void(0);">��ѡ</a> -->
                </td>
                <td class="pagerBox">
                    <CashTicketControl:Pager ID="Pager1" runat="server" />
                </td>
            </tr>
        </table>

    </div>

</asp:Content>


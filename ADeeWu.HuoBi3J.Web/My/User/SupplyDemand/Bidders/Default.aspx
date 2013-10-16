<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.SupplyDemand.Bidders.Default" %>


<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="CashTicketControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    �ֽ�ȯ������ - �ҵ��ʻ� -��Ͷ���� - �Ҳ�����б���Ϣ
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <!-- �������ʽ,js ����-->
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#txtbegintime").dynDateTime(); //defaults
            jQuery("#txtendtime").dynDateTime();
        });
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <a href="/Account/Default.aspx">�ҵ��ʻ���ҳ</a>  &gt; ��Ͷ���� &gt; �Ҳ�����б���Ϣ   
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <div>
        <table class="searchTable">
            <tr>
                <td class="key" style="width: 50px">��ǩ��</td>
                <td>
                    <asp:TextBox ID="note" runat="server" Width="120px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>�ղ�ʱ�䣺</td>
                <td>&nbsp;
                <CashTicketControl:DateTimeSelector ID="beginTime" Width="90px" runat="server"></CashTicketControl:DateTimeSelector>
                    ��<CashTicketControl:DateTimeSelector ID="endTime" runat="server" Width="90px"></CashTicketControl:DateTimeSelector>
                    &nbsp;<input name="submit" type="submit" value="����" /></td>
            </tr>
        </table>


        <asp:GridView Width="100%" ID="gvData" runat="server" CssClass="gridView" SkinID="userGridViewSkin" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderStyle-CssClass="col_id" ItemStyle-CssClass="col_id" HeaderText="����ʱ��">
                    <ItemTemplate>
                        <%#Eval("CreateTime")%>
                    </ItemTemplate>
                    <HeaderStyle CssClass="col_id"></HeaderStyle>
                    <ItemStyle CssClass="col_id"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="����">
                    <ItemTemplate>
                        <a href='../../../../SupplyDemand/View.aspx?id=<%# Eval("ID") %>'><%# Eval("Title")%></a>
                    </ItemTemplate>
                    <HeaderStyle CssClass="col_money" />
                    <ItemStyle CssClass="col_datetime" />
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-CssClass="col_id" ItemStyle-CssClass="col_id" HeaderText="״̬">
                    <ItemTemplate>
                        <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                              Eval("Status").ToString(),
                new string[][]{
                    new string[]{"0","δ�б�"},
                    new string[]{"1","���б�"}
                }               
                )
                        %>
                    </ItemTemplate>
                    <HeaderStyle CssClass="col_id"></HeaderStyle>
                    <ItemStyle CssClass="col_id"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderStyle-CssClass="col_id" ItemStyle-CssClass="col_id" HeaderText="Ͷ��ʱ��">
                    <ItemTemplate>
                        <%#Eval("SD_BiddersCreateTime")%>
                    </ItemTemplate>
                    <HeaderStyle CssClass="col_id"></HeaderStyle>
                    <ItemStyle CssClass="col_id"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-CssClass="col_id" ItemStyle-CssClass="col_id" HeaderText="����ʱ��">
                    <ItemTemplate>
                        <%#Eval("EndTime","{0:yyyy-MM-dd}")%>
                    </ItemTemplate>
                    <HeaderStyle CssClass="col_id"></HeaderStyle>
                    <ItemStyle CssClass="col_id"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-CssClass="col_id" ItemStyle-CssClass="col_id" HeaderText="����">
                    <ItemTemplate>
                        <a style='display: <%# Eval("Status").ToString()=="0"?"inline":"none" %>' href='Edit.aspx?id=<%# Eval("SD_BiddersID") %>'>�޸�</a>
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

<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="DeFault.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.SupplyDemand.DeFault" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="CashTicketControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    �ֽ�ȯ������ - �ҵ��ʻ� - ��Ͷ���� - �б���Ϣ����
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <a href="/Account/Default.aspx">�ҵ��ʻ���ҳ</a> &gt; ��Ͷ���� &gt; �б���Ϣ����  
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

    <div>
        <table class="searchTable">
            <tr>
                <td>���⣺</td>
                <td width="100px">
                    <asp:TextBox ID="title" runat="server"></asp:TextBox></td>
                <td>����ʱ�䣺</td>
                <td>
                    <CashTicketControl:DateTimeSelector ID="beginTime" runat="server"></CashTicketControl:DateTimeSelector>
                    ��<CashTicketControl:DateTimeSelector ID="endTime" runat="server"></CashTicketControl:DateTimeSelector><asp:Button ID="btnquery" runat="server" Text="��ѯ" />
                </td>
            </tr>
        </table>
        <asp:GridView Width="100%" ID="gvData" runat="server" CssClass="gridView" SkinID="userGridViewSkin" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" HeaderText="����">
                    <ItemTemplate>
                        <%#Eval("Title")%>
                    </ItemTemplate>
                    <HeaderStyle CssClass="col_title"></HeaderStyle>
                    <ItemStyle CssClass="col_title"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-CssClass="col_datetime" ItemStyle-CssClass="col_datetime" HeaderText="����ʱ��">
                    <ItemTemplate>
                        <%#Eval("CreateTime","{0:yyyy-MM-dd}")%>
                    </ItemTemplate>
                    <HeaderStyle CssClass="col_datetime"></HeaderStyle>
                    <ItemStyle CssClass="col_datetime"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-CssClass="col_datetime" ItemStyle-CssClass="col_datetime" HeaderText="ˢ��ʱ��" Visible="false">
                    <ItemTemplate>
                        <%#Eval("RefreshTime","{0:yyyy-MM-dd}")%>
                    </ItemTemplate>
                    <HeaderStyle CssClass="col_datetime"></HeaderStyle>
                    <ItemStyle CssClass="col_datetime"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-CssClass="col_datetime" ItemStyle-CssClass="col_datetime" HeaderText="����ʱ��">
                    <ItemTemplate>
                        <%#Eval("EndTime","{0:yyyy-MM-dd}")%>
                    </ItemTemplate>
                    <HeaderStyle CssClass="col_datetime"></HeaderStyle>
                    <ItemStyle CssClass="col_datetime"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="״̬">
                    <ItemTemplate>
                        <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                Eval("CheckState").ToString(),
                new string[][]{
                    new string[]{"0","�����"},
                    new string[]{"1","�����"},
                    new string[]{"2","��Ч"},
                    new string[]{"3","����"}
                }               
                )
                        %>
                    </ItemTemplate>
                    <HeaderStyle CssClass="col_state" />
                    <ItemStyle CssClass="col_state" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="�б�״̬">
                    <ItemTemplate>
                        <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                   Eval("Status").ToString(),
                   new string[][]{
                    new string[]{"0","δ����б�"},
                    new string[]{"1","������б�"}
                   }               
                   )
                        %>
                    </ItemTemplate>
                    <HeaderStyle CssClass="col_state" />
                    <ItemStyle CssClass="col_state" />
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option" HeaderText="����">
                    <ItemTemplate>
                        <a href='Show.aspx?id=<%# Eval("ID") %>'>�鿴Ͷ����Ϣ</a> <a style='display: <%# Eval("Status").ToString()=="1"?"none":"inline"%>' href='Edit.aspx?id=<%# Eval("ID") %>'>�޸�</a>&nbsp;<a href='Del.aspx?id=<%# Eval("ID") %>' onclick='return confirm("��ȷ��Ҫɾ��������Ϣ��")'>ɾ��</a>
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




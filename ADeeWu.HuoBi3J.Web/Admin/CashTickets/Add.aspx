<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="Add.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.CashTickets.Add" %>




<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Admin - CashTickets - Add
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
            <span>�ֽ�ȯ����</span> &gt; <a href="List.aspx">�б�</a> &gt; ϵͳ����
            </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

        <table border="0" cellspacing="0" cellpadding="0" class="formTable">
            <%--<tr>
    <td class="tdLeft">�̼�:</td>
    <td class="tdRight">
        <asp:DropDownList ID="ddlCorp" runat="server">
        </asp:DropDownList> <span class="require">*</span>
    </td>
  </tr>--%>
            <tr>
                <td class="tdLeft">��ˮ������ǰ׺:</td>
                <td class="tdRight">
                    <asp:TextBox ID="txtPrefix" runat="server" CssClass="txtBox"></asp:TextBox>
                    <span class="require">*</span>
                    ��:����CashTicket,������CashTicket00001,<span class="strewColor">CashTicket</span>00002</td>
            </tr>
            <tr>
                <td class="tdLeft">��ˮ�ź������ɳ���:</td>
                <td class="tdRight">
                    <asp:TextBox ID="txtNumLength" runat="server" CssClass="txtBox"></asp:TextBox>
                    <span class="require">*</span>
                    ����ˮ��ǰ׺��ĳ���,��:����ֵ5������CashTicket<span class="strewColor">00001</span>
                </td>
            </tr>
            <tr>
                <td class="tdLeft">��ˮ�ź�����ʼ��:</td>
                <td class="tdRight">
                    <asp:TextBox ID="txtStartNum" runat="server" CssClass="txtBox"></asp:TextBox>
                    <span class="require">*</span>
                    ��ˮ�ſ�ʼ���ɵĺ���,��:����ֵ5,�����CashTicket0000<span class="strewColor">5</span>��ʼ���ɵ�CashTicket00030
                </td>
            </tr>
            <tr>
                <td class="tdLeft">��������:</td>
                <td class="tdRight">
                    <asp:TextBox ID="txtQuantity" runat="server" CssClass="txtNum"></asp:TextBox>
                    <span class="require">*</span>
                </td>
            </tr>
            <tr>
                <td class="tdLeft">���:</td>
                <td class="tdRight">
                    <asp:TextBox ID="txtMoney" runat="server" CssClass="txtNum"></asp:TextBox>
                    <span class="require">*</span>
                </td>
            </tr>
            <%--<tr>
    <td class="tdLeft">Ĭ��״̬:</td>
    <td class="tdRight">
        <asp:DropDownList ID="ddlCheckState" runat="server">
            <asp:ListItem Value="0">�����</asp:ListItem>
            <asp:ListItem Value="1">ͨ�����</asp:ListItem>
            <asp:ListItem Value="2">��Ч</asp:ListItem>
            <asp:ListItem Value="3">����</asp:ListItem>
        </asp:DropDownList>
    </td>
  </tr>--%>
            <tr>
                <td class="tdLeft">&nbsp;</td>
                <td class="tdRight">
                    <asp:Button ID="btnSubmit" runat="server" Text="�ύ" OnClick="btnSubmit_OnClick" />
                </td>
            </tr>
        </table>

        <asp:GridView ID="gvData" runat="server" CssClass="dataGrid" SkinID="gridviewSkin" AutoGenerateColumns="False" BorderStyle="None">
            <Columns>
                <asp:TemplateField HeaderStyle-CssClass="col_id" ItemStyle-CssClass="col_id" HeaderText="ID">
                    <ItemTemplate>
                        <input type="checkbox" name="<% = gvData.ClientID %>" value="<%#Eval("ID") %>" />
                        <%#Eval("ID")%>
                    </ItemTemplate>

<HeaderStyle CssClass="col_id"></HeaderStyle>

<ItemStyle CssClass="col_id"></ItemStyle>
                </asp:TemplateField>

                <asp:HyperLinkField HeaderText="�ֽ�ȯ���к�" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" DataNavigateUrlFields="id" DataNavigateUrlFormatString="Edit.aspx?id={0}" DataTextField="SerialNum" >
<HeaderStyle CssClass="col_title"></HeaderStyle>

<ItemStyle CssClass="col_title"></ItemStyle>
                </asp:HyperLinkField>
                <asp:BoundField HeaderText="�ֽ�ȯ��֤��" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" DataField="ValidCode" >
<HeaderStyle CssClass="col_title"></HeaderStyle>

<ItemStyle CssClass="col_title"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Money" HeaderText="���" />
                <asp:BoundField HeaderText="����ʱ��" HeaderStyle-CssClass="col_datetime" ItemStyle-CssClass="col_datetime" DataField="CreateTime" HtmlEncode="true" DataFormatString="{0:d}" >

<HeaderStyle CssClass="col_datetime"></HeaderStyle>

<ItemStyle CssClass="col_datetime"></ItemStyle>
                </asp:BoundField>

                <asp:TemplateField HeaderStyle-CssClass="col_state" ItemStyle-CssClass="col_state" HeaderText="״̬">
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

<HeaderStyle CssClass="col_state"></HeaderStyle>

<ItemStyle CssClass="col_state"></ItemStyle>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>


        </asp:Content>


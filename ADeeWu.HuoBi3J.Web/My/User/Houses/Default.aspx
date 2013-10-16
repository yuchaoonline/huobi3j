<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Houses.Default" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    ���˿������ - ���߳������
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <span class="spl"></span><span class="curPos">���߳������</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

    <table class="searchTable">
        <tr>
            <td class="key" style="width: 50px">���⣺</td>
            <td>
                <asp:TextBox ID="txtTitle" runat="server" Width="120px"></asp:TextBox>
            </td>
            <td style="width: 60px">���ݽṹ��</td>
            <td>
                <asp:DropDownList ID="ddlhousestrcts" runat="server">
                    <asp:ListItem Value="-1">ȫ��</asp:ListItem>
                    <asp:ListItem Value="0">����</asp:ListItem>
                    <asp:ListItem Value="1">һ��һ��</asp:ListItem>
                    <asp:ListItem Value="2">����һ��</asp:ListItem>
                    <asp:ListItem Value="3">���Ҷ���</asp:ListItem>
                    <asp:ListItem Value="4">����һ��</asp:ListItem>
                    <asp:ListItem Value="5">����һ��</asp:ListItem>
                    <asp:ListItem Value="6">���Ҷ���</asp:ListItem>
                    <asp:ListItem Value="7">�����ṹ</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>����ʱ�䣺</td>
            <td>&nbsp;<IscControl:DateTimeSelector ID="txtBeginTime" Width="90px" runat="server"></IscControl:DateTimeSelector>
                ��<IscControl:DateTimeSelector ID="txtEndTime" runat="server" Width="90px"></IscControl:DateTimeSelector>
                &nbsp;<asp:Button ID="btnSubmit" runat="server" Text="����" OnClick="btnSubmit_Click" />
            </td>
        </tr>
    </table>
    <div style="text-align: center">
        <asp:GridView ID="gvData" runat="server" CssClass="gridView" SkinID="userGridViewSkin" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderStyle-CssClass="col_id" ItemStyle-CssClass="col_id" HeaderText="���">
                    <ItemTemplate>
                        <%--<input type="checkbox" name="id" value="<%#Eval("homeCode") %>" />--%> <a href="/Houses/View.aspx?id=<%#Eval("ID")%>" target="_blank"><%#Eval("homeCode") %></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <%-- <asp:BoundField HeaderText="���ݽṹ" HeaderStyle-CssClass="col_account" ItemStyle-CssClass="col_account" DataField="HouseStructText" >
                 <HeaderStyle CssClass="col_account"></HeaderStyle>
                 <ItemStyle CssClass="col_account"></ItemStyle>
                 </asp:BoundField>--%>
                <asp:TemplateField HeaderText="����" HeaderStyle-CssClass="col_datetime" ItemStyle-CssClass="col_datetime">
                    <ItemTemplate>
                        <a href="/Houses/View.aspx?id=<%# Eval("ID") %>" target="_blank"><%# Eval("Title") %></a>
                    </ItemTemplate>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="��������">
                    <ItemTemplate>
                        <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                                                Eval("Properity").ToString(),
                                "����",
                                new string[][]{
                                    new string[]{"0","����"},
                                    new string[]{"1","ת��"}
                                }               
                                )
                        %>
                    </ItemTemplate>

                </asp:TemplateField>
                <%--<asp:BoundField HeaderText="�������" HeaderStyle-CssClass="col_notes" ItemStyle-CssClass="col_notes"  DataField="AreaSize" >
                </asp:BoundField>--%>
                <asp:BoundField HeaderText="����" HeaderStyle-CssClass="col_money"
                    ItemStyle-CssClass="col_money" DataField="Price" Visible="False"></asp:BoundField>
                <asp:BoundField DataField="CreateTime" HeaderText="����ʱ��" />
                <%-- <asp:TemplateField HeaderText="״̬">
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
                </asp:TemplateField>--%>
                <asp:BoundField DataField="VisitCount" HeaderText="���ʴ���" />
                <asp:TemplateField HeaderText="����" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option">
                    <ItemTemplate>
                        <a href="Edit.aspx?id=<%#Eval("ID") %>" style='display: <%# Eval("CheckState").ToString()=="4"?"none":"inline"%>'>�޸�|</a>
                        <a href="Del.aspx?id=<%#Eval("homeCode") %>" dir="ltr" onclick="return confirm('��ȷ��Ҫɾ��������Ϣ��')">ɾ��</a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>


    <div class="pager">
        <IscControl:Pager ID="Pager1" runat="server" />
    </div>
</asp:Content>

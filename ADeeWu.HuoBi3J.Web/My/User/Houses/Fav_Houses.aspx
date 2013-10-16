<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Fav_Houses.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Houses.Fav_Houses" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    ���˿������ - ��Դ������Ϣ�ղؼ�
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <span class="spl"></span><span class="curPos">��Դ������Ϣ�ղؼ�</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">



    <asp:GridView Width="100%" ID="gvData" runat="server" CssClass="gridView" SkinID="userGridViewSkin" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField HeaderStyle-CssClass="col_id" ItemStyle-CssClass="col_id" HeaderText="���">
                <ItemTemplate>
                    <a href="/Houses/View.aspx?id=<%#Eval("HouseID")%>" target="_blank"><%#Eval("homeCode") %></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="����" HeaderStyle-CssClass="col_money" ItemStyle-CssClass="col_datetime" DataField="Title"></asp:BoundField>
            <asp:BoundField HeaderText="�Y��" HeaderStyle-CssClass="col_notes" ItemStyle-CssClass="col_notes" DataField="HouseStructText"></asp:BoundField>

            <asp:TemplateField HeaderText="����" HeaderStyle-CssClass="col_money" ItemStyle-CssClass="col_money">
                <ItemTemplate>
                    <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                Eval("HouseType").ToString(),
                new string[][]{
                    new string[]{"0","סլ"},
                    new string[]{"1","����"},
                    new string[]{"2","д��¥"},
                    new string[]{"3","����"}
                }               
                )
                    %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="��������" HeaderStyle-CssClass="col_money" ItemStyle-CssClass="col_money">
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


            <asp:BoundField DataField="EndTime" HeaderText="��ֹ����" HtmlEncode="true" DataFormatString="{0:yyyy-MM-dd}" />
        </Columns>
    </asp:GridView>
    <table width="100%" class="dataGrid_Footer" style="margin-top: -5px;">
        <tr>
            <td class="options">
                <!-- <a href="#" onclick="setCheckGroup('<% = gvData.ClientID %>',true); void(0);">ȫѡ</a> <a href="#" onclick="resverSelect('<% = gvData.ClientID %>'); void(0);">��ѡ</a> -->
            </td>
            <td class="pagerBox">
                <IscControl:Pager ID="Pager1" runat="server" />
            </td>
        </tr>
    </table>






</asp:Content>



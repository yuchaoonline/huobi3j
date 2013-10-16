<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Favs.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Marketing.Favs" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>




<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    �ֽ�ȯ������ - �ҵ��ʻ� -��Ͷ���� - ���ղص�Ͷ����Ϣ
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <a href="/Account/Default.aspx">�ҵ��ʻ���ҳ</a>  &gt; ����Ӫ�� &gt; �ղؼ�   
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <div>
        <table class="searchTable">
            <tr>
                <td class="key" style="width: 50px">��ǩ��</td>
                <td>
                    <asp:TextBox ID="txtNote" runat="server" Width="120px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>�ղ�ʱ�䣺</td>
                <td>&nbsp;
                <IscControl:DateTimeSelector ID="txtBeginTime" Width="90px" runat="server"></IscControl:DateTimeSelector>
                    ��<IscControl:DateTimeSelector ID="txtEndTime" runat="server" Width="90px"></IscControl:DateTimeSelector>
                    &nbsp;<asp:Button ID="btnSubmit" runat="server" Text="����" OnClick="btnSubmit_Click" />

                </td>
            </tr>
        </table>


        <asp:GridView Width="100%" ID="gvData" runat="server" CssClass="gridView" SkinID="userGridViewSkin" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderStyle-CssClass="col_datetime" ItemStyle-CssClass="col_datetime" HeaderText="�ղ�ʱ��">
                    <ItemTemplate>
                        <%#Eval("FavTime")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="��ǩ">
                    <ItemTemplate>
                        <a href='../../../../Marketing/View.aspx?id=<%# Eval("MID") %>'><%# Eval("Notes")%></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-CssClass="col_datetime" ItemStyle-CssClass="col_datetime" HeaderText="����ʱ��">
                    <ItemTemplate>
                        <%#Eval("CreateTime")%>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <div class="pager" style="text-align: center">
            <IscControl:Pager ID="Pager1" runat="server" ShowTextOnError="û�в�ѯ���ղ���Ϣ��" />
        </div>

    </div>
</asp:Content>

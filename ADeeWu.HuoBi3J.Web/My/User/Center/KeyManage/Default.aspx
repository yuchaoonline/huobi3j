<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Center.KeyManage.Default" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="ADeeWuControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    �������� - ���˹������� - ��׼����
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <asp:GridView ID="gvData" runat="server" CssClass="gridView" SkinID="userGridViewSkin"
        AutoGenerateColumns="False" EnableModelValidation="True">
        <Columns>
            <asp:TemplateField HeaderText="�ؼ���">
                <ItemTemplate>
                    <%# ADeeWu.HuoBi3J.Web.Class.Helper.GetKey(Eval("kid"), Eval("kname")) %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Price" HeaderText="��Ǯ(Ԫ)" />
            <asp:BoundField DataField="CreatTime" HeaderText="���ʱ��" />
            <asp:TemplateField HeaderText="����">
                <ItemTemplate>
                    <a href="Refresh.aspx?id=<%#Eval("kid")%>">ˢ��</a>|
                                    <a href="RefreshLog.aspx?id=<%#Eval("kid")%>&keyword=<%# Eval("kname") %>">ˢ�¼�¼</a>
                    <a href="Income.aspx?id=<%#Eval("kid")%>&keyword=<%# Eval("kname") %>">����</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div class="pager">
        <ADeeWuControl:Pager ID="Pager1" runat="server" />
    </div>

</asp:Content>


<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Keyword.Default" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    ȫ��Ӫ�� - ���˹������� - ��׼����
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

    <asp:GridView ID="gvData" runat="server" CssClass="gridView" SkinID="userGridViewSkin"
        AutoGenerateColumns="False" EnableModelValidation="True">
        <Columns>
            <asp:BoundField DataField="Keyword" HeaderText="�ؼ���" />
            <asp:BoundField DataField="CreateTime" HeaderText="���ʱ��" />
            <asp:TemplateField HeaderText="�Ƿ�����">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server"
                        Text='<%# IsHidden(Eval("IsHidden")) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="����">
                <ItemTemplate>
                    <a href="Edit.aspx?id=<%#Eval("id")%>">�޸�</a>
                    | <a href="Del.aspx?id=<%#Eval("id")%>" onclick="return confirm('ȷ��Ҫɾ���ü�¼��?');">ɾ��</a>
                    | <a href="Manager.aspx?id=<%#Eval("id")%>">����</a>
                    | <a href="Refresh.aspx?id=<%#Eval("id")%>">ˢ��</a>
                    | <a href="RefreshLog.aspx?id=<%#Eval("id")%>&keyword=<%#Eval("Keyword") %>">ˢ�¼�¼</a>
                    | <a href="Sale.aspx?id=<%#Eval("id")%>">ת��</a>
                    | <a href="Income.aspx?id=<%#Eval("id")%>&keyword=<%#Eval("keyword") %>">����</a>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>


    <div class="pager">
        <IscControl:Pager ID="Pager1" runat="server" />
    </div>

</asp:Content>


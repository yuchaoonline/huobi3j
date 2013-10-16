<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Keyword.Default" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    全民营销 - 个人管理中心 - 精准搜索
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

    <asp:GridView ID="gvData" runat="server" CssClass="gridView" SkinID="userGridViewSkin"
        AutoGenerateColumns="False" EnableModelValidation="True">
        <Columns>
            <asp:BoundField DataField="Keyword" HeaderText="关键字" />
            <asp:BoundField DataField="CreateTime" HeaderText="添加时间" />
            <asp:TemplateField HeaderText="是否屏蔽">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server"
                        Text='<%# IsHidden(Eval("IsHidden")) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <ItemTemplate>
                    <a href="Edit.aspx?id=<%#Eval("id")%>">修改</a>
                    | <a href="Del.aspx?id=<%#Eval("id")%>" onclick="return confirm('确认要删除该记录吗?');">删除</a>
                    | <a href="Manager.aspx?id=<%#Eval("id")%>">管理</a>
                    | <a href="Refresh.aspx?id=<%#Eval("id")%>">刷新</a>
                    | <a href="RefreshLog.aspx?id=<%#Eval("id")%>&keyword=<%#Eval("Keyword") %>">刷新记录</a>
                    | <a href="Sale.aspx?id=<%#Eval("id")%>">转让</a>
                    | <a href="Income.aspx?id=<%#Eval("id")%>&keyword=<%#Eval("keyword") %>">收益</a>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>


    <div class="pager">
        <IscControl:Pager ID="Pager1" runat="server" />
    </div>

</asp:Content>


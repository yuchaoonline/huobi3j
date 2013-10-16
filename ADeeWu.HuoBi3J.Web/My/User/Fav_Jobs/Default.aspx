<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Fav_Jobs.Default" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>




<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    个人控制面板 - 职位收藏夹
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <span class="spl"></span><span class="curPos">职位收藏夹</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

    <table class="searchTable">
        <tr>
            <td class="key" style="width: 50px">标签：</td>
            <td>
                <asp:TextBox ID="txtNote" runat="server" Width="120px"></asp:TextBox>
            </td>
            <td>&nbsp;
            </td>
            <td>收藏时间：</td>
            <td>&nbsp;
			<IscControl:DateTimeSelector ID="txtBeginTime" Width="90px" runat="server"></IscControl:DateTimeSelector>
                至<IscControl:DateTimeSelector ID="txtEndTime" runat="server" Width="90px"></IscControl:DateTimeSelector>
                &nbsp;<asp:Button ID="btnSubmit" runat="server" Text="搜索" OnClick="btnSubmit_Click" />

            </td>
        </tr>
    </table>


    <asp:GridView Width="100%" ID="gvData" runat="server" CssClass="gridView" SkinID="userGridViewSkin" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField HeaderStyle-CssClass="col_id" ItemStyle-CssClass="col_id" HeaderText="收藏时间">
                <ItemTemplate>
                    <%#Eval("CreateTime")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="标签">
                <ItemTemplate>
                    <a href='/Jobs/View.aspx?id=<%# Eval("JobID") %>' target="_blank"><%# Eval("Notes")%></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" HeaderText="职位名称">
                <ItemTemplate>
                    <a href='/Jobs/View.aspx?id=<%# Eval("JobID") %>'><%#Eval("Title")%></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-CssClass="col_datetime" ItemStyle-CssClass="col_datetime" HeaderText="发布日期">
                <ItemTemplate>
                    <%#Eval("JobCreateTime","{0:yyyy-MM-dd}")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-CssClass="col_datetime" ItemStyle-CssClass="col_datetime" HeaderText="截止日期">
                <ItemTemplate>
                    <%#Eval("EndTime","{0:yyyy-MM-dd}")%>
                </ItemTemplate>
            </asp:TemplateField>


        </Columns>
    </asp:GridView>
    <div class="pager">
        <IscControl:Pager ID="Pager1" runat="server" />
    </div>


</asp:Content>

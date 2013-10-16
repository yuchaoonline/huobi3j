<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.CorpAgentManage.Roles.Default" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
商家控制面板 - 商家代表角色管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">　</span><a href="/My/Corp/CorpAgentManage/Users/">商家代表管理</a><span class="spl">　</span><span class="curPos">角色管理</span>   
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

<asp:GridView ID="gvData" runat="server" CssClass="gridView" SkinID="userGridViewSkin" AutoGenerateColumns="false" ShowFooter="false" BorderStyle="None"  ShowHeader="true">
<Columns>
    <%--<asp:TemplateField HeaderStyle-CssClass="col_id"  ItemStyle-CssClass="col_id" HeaderText="ID">
        <ItemTemplate>
            <input type="checkbox" name="id" value="<%#Eval("ID") %>" /> <%#Eval("ID") %>
        </ItemTemplate>    
    </asp:TemplateField>--%>
    
    <asp:HyperLinkField HeaderText="角色名称" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" DataNavigateUrlFields="id" DataNavigateUrlFormatString="Edit.aspx?id={0}" DataTextField="RoleName" />
    <asp:BoundField HeaderText="描述" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" DataField="Description" />
    <asp:TemplateField HeaderText="用户数量" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option">
        <ItemTemplate>
            <%#
               NumOfUsersInRole((long)Eval("ID"), this.LoginUser.CorpID) 
                 %>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="操作" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option">
        <ItemTemplate>
            <a href="Edit.aspx?id=<%#Eval("ID") %>">修改</a> | <a href="Del.aspx?id=<%#Eval("ID") %>" onclick="return confirm('确认要删除该记录吗?一旦删除无法恢复');">删除</a>
        </ItemTemplate>
    </asp:TemplateField>
    
</Columns>
</asp:GridView>

 <IscControl:Pager ID="Pager1" runat="server"  />

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>




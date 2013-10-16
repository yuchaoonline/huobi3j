<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="ADLog.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.Promotions.Keywords.AD.ADLog" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
商家控制面板 - 精准搜索广告管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">　</span><a href="Default.aspx">广告设置管理</a>  <span class="spl">　</span><span class="curPos">广告记录</span>
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <table id="resultList" class="gridView">
        <asp:Repeater ID="rpADList" runat="server">
            <HeaderTemplate>
                <tr>
                    <th>精准关键字</th>
                    <th>拥有者</th>
                    <th>点击价格</th>
                    <th>点击IP</th>
                    <th>点击时间</th>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#Eval("keyword") %></td>
                    <td><%#Eval("loginname") %></td>
                    <td><%#Eval("clickprice") %></td>
                    <td><%#Eval("clickip") %></td>
                    <td><%#Eval("createtime") %></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>

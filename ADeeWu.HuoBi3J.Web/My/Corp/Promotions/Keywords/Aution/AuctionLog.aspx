<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="AuctionLog.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.Promotions.Keywords.Aution.AuctionLog" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
商家控制面板 - 精准搜索竞价管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">　</span><a href="Default.aspx">关键字竞价管理</a>  <span class="spl">　</span><span class="curPos">竞价记录</span>
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <table id="resultList" class="gridView">
        <asp:Repeater ID="rpADList" runat="server">
            <HeaderTemplate>
                <tr>
                    <th>广告名称</th>
                    <th>精准关键字</th>
                    <th>竞价时间</th>
                    <th>单击价格</th>
                    <th>花费</th>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# ADeeWu.HuoBi3J.Libary.Utility.SubString(Eval("name"),20,"...") %></td>
                    <td><%#Eval("Keyword") %></td>
                    <td><%#Eval("CreateTime") %></td>
                    <td><%#Eval("clickprice") %></td>
                    <td><%#Eval("costmoney") %></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>

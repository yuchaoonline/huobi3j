<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Manager.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.Promotions.Keywords.Aution.Manager" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
商家控制面板 - 精准搜索竞价管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">　</span><a href="Default.aspx">关键字竞价管理</a>  <span class="spl">　</span><span class="curPos">竞价管理</span>
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <table id="resultList" class="gridView">
        <asp:Repeater ID="rpADList" runat="server">
            <HeaderTemplate>
                <tr>
                    <th>精准关键字</th>
                    <th>广告名称</th>
                    <th>单击价格</th>
                    <th>竞价总金额</th>
                    <th>每天花费</th>
                    <th>是否停止</th>
                    <th>操作</th>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#Eval("keyword") %></td>
                    <td><%# ADeeWu.HuoBi3J.Libary.Utility.SubString(Eval("name"), 20, "...") %></td>
                    <td><%#Eval("clickprice") %></td>
                    <td><%#Eval("totalprice") %></td>
                    <td><%#Eval("totalpriceday") %></td>
                    <td><%# ADeeWu.HuoBi3J.Libary.Utility.GetBool(Eval("ispause"),true)?"是":"否" %></td>
                    <td>
                        <a href="pause.aspx?id=<%#Eval("id")%>" title="开启投放">投放开关</a>
                        <a href="daycost.aspx?id=<%#Eval("id")%>" title="每日费用">每日费用</a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>

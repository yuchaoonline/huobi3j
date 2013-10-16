<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.Promotions.Keywords.Aution.Default" %>
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
    <table class="formTable gridView">
        <tr>
            <th colspan="2">
                搜索关键字
            </th>
        </tr>
        <tr>
	        <td class="tdLeft">精准关键字：</td>
	        <td class="tdRight"><asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
	        <td class="tdLeft"></td>
	        <td class="tdRight">
	            <asp:Button ID="btnSubmit" runat="server" Text="搜索" onclick="btnSubmit_Click" />
	        </td>
        </tr>
    </table>

    <table id="resultList" class="gridView">
        <asp:Repeater ID="rpADList" runat="server">
            <HeaderTemplate>
                <tr>
                    <th>拥有者</th>
                    <th>精准关键字</th>
                    <th>添加时间</th>
                    <th>操作</th>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#GetUsername(Eval("UserID"))%></td>
                    <td><%#Eval("Keyword") %></td>
                    <td><%#Eval("CreateTime") %></td>
                    <td>
                        <a href="Aution.aspx?id=<%#Eval("id")%>&keyword=<%#Eval("Keyword") %>" title="竞价">竞价</a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <div class="pager">
        <IscControl:Pager ID="Pager1" runat="server"  />
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>

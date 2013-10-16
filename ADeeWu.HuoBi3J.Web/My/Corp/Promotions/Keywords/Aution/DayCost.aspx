<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="DayCost.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.Promotions.Keywords.Aution.DayCost" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
商家控制面板 - 精准搜索竞价管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">　</span><a href="Default.aspx">关键字竞价管理</a>  <span class="spl">　</span><span class="curPos">每日消费设置</span>
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <table class="formTable gridView">
        <tr>
            <th colspan="2">
                修改每日消费
                <asp:HiddenField ID="hfID" runat="server" />
            </th>
        </tr>
        <tr>
	        <td class="tdLeft">当前余额：</td>
	        <td class="tdRight"><asp:Label ID="lbTotalPrice" runat="server"></asp:Label></td>
        </tr>
        <tr>
	        <td class="tdLeft">每日限价：</td>
	        <td class="tdRight"><asp:TextBox ID="txtTotalPriceDay" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
	        <td class="tdLeft"></td>
	        <td class="tdRight">
	            <asp:Button ID="btnSubmit" runat="server" Text="修改" onclick="btnSubmit_Click" />
	        </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>

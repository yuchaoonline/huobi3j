<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="ServiceApplication.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.CashTickets.ServiceApplication" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
商家控制面板 - 现金赠送服务申请开通
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">　</span><a href="/My/Corp/CashTickets/">现金券列表</a><span class="spl">　</span><span class="curPos">服务申请开通</span>
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

<table border="0" cellspacing="0" cellpadding="0" class="formTable">
  <tr>
    <td class="tdLeft">商家名称：</td>
    <td class="tdRight">
        <asp:Literal ID="liteCorpName" runat="server"></asp:Literal>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">所属行业：</td>
    <td class="tdRight">
        <asp:Literal ID="liteIndustry" runat="server"></asp:Literal>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">所属地区：</td>
    <td class="tdRight">
        <asp:Literal ID="liteLocation" runat="server"></asp:Literal>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">描述：</td>
    <td class="tdRight">
        <asp:TextBox ID="txtContract" runat="server" Width="321px" Height="158px" 
            TextMode="MultiLine"></asp:TextBox><span class="require">*</span><span class="tips">请填写现金赠送发布商品情况描述</span>
        <asp:RequiredFieldValidator ID="rfvContract" runat="server" Display="Dynamic" ErrorMessage="请填写!" ControlToValidate="txtContract"></asp:RequiredFieldValidator>
    </td>
  </tr>
  <%--<tr>
    <td class="tdLeft">返还百分比：</td>
    <td class="tdRight">
        <asp:TextBox ID="txtOfferPercent" runat="server" Width="50px"></asp:TextBox><span class="require">*</span><span class="tips">请填写现金服务返回给服务商的提成百分比</span>
        <asp:RequiredFieldValidator ID="rfvOfferPercent" runat="server" Display="Dynamic" ErrorMessage="请填写!" ControlToValidate="txtOfferPercent"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator
            ID="revOfferPercent" runat="server" ValidationExpression="\d+" Display="Dynamic" ControlToValidate="txtOfferPercent" ErrorMessage="请填写正确!"></asp:RegularExpressionValidator>
    </td>
  </tr>--%>
  <tr>
    <td class="tdLeft">申请日期：</td>
    <td class="tdRight"><%=DateTime.Now.ToShortDateString() %></td>
  </tr>
  <tr>
    <td class="tdLeft">&nbsp;</td>
    <td class="tdRight">
    	<asp:Button id="btnSubmit" runat="server" Text="申请开通" onclick="btnSubmit_Click"></asp:Button>
    </td>
  </tr>
</table>


</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>




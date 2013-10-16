<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="ListByAdmin.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.CashTicketApplications.ListByAdmin"  %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="CashTicketControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
Admin - CashTicketApplications - List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>业务统计</span> &gt; 现金券兑现统计
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
<input type="hidden" name="page"  value="1" />
<table class="searchTable">
    <tr>
        <td class="key">业务员:</td>
        <td class="input">
           <select id="adminid" runat="server">
           </select>        </td>
        <td class="key">商家名称:</td>
        <td align="left" valign="middle" class="input">
         <input type="text" name="corpName" class="txtBox" id="corpName" runat="server" />
        </td>
		<td class="key">申请兑现日期:</td>
        <td align="left" valign="middle">
         从 <CashTicketControl:DateTimeSelector ID="txtStartDate" CssClass="txtDate" runat="server"></CashTicketControl:DateTimeSelector> 到 <CashTicketControl:DateTimeSelector ID="txtEndDate" runat="server" CssClass="txtDate"></CashTicketControl:DateTimeSelector>
        </td>
        <td class="key">状态:</td>
        <td class="input"><select name="state" runat="server" id="state">
          <option value="-1">全部</option>
          <option value="0">待审核</option>
          <option value="1">已审核</option>
          <option value="2">无效</option>
          <option value="3">已过期</option>
        </select>
        </td>
        <td class="key"><input name="submit" type="submit" value="搜索" /></td>
      <td class="input">&nbsp;</td>
    </tr>
</table>



<asp:GridView ID="gvData" runat="server" CssClass="dataGrid" SkinID="gridviewSkin" AutoGenerateColumns="False" BorderStyle="None">
<Columns>
    <asp:TemplateField HeaderStyle-CssClass="col_id"  ItemStyle-CssClass="col_id" HeaderText="ID">
        <ItemTemplate>
            <input type="checkbox" name="<% = gvData.ClientID %>" value="<%#Eval("ID") %>" /> <%#Eval("ID") %>
        </ItemTemplate>    

<HeaderStyle CssClass="col_id"></HeaderStyle>

<ItemStyle CssClass="col_id"></ItemStyle>
    </asp:TemplateField>
    
    <asp:BoundField HeaderText="业务员" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" DataField="AdminUserName" >
<HeaderStyle CssClass="col_title"></HeaderStyle>

<ItemStyle CssClass="col_title"></ItemStyle>
    </asp:BoundField>
    <asp:BoundField HeaderText="现金券序号" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" DataField="SerialNum" >
<HeaderStyle CssClass="col_title"></HeaderStyle>

<ItemStyle CssClass="col_title"></ItemStyle>
    </asp:BoundField>
    <asp:BoundField HeaderText="所属商家" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" DataField="RealCorpName" >
    
<HeaderStyle CssClass="col_title"></HeaderStyle>

<ItemStyle CssClass="col_title"></ItemStyle>
    </asp:BoundField>
    <asp:BoundField HeaderText="提成百分比" HeaderStyle-CssClass="col_number" ItemStyle-CssClass="col_number" DataField="OfferPercent" DataFormatString="{0}%" >
<HeaderStyle CssClass="col_number"></HeaderStyle>

<ItemStyle CssClass="col_number"></ItemStyle>
    </asp:BoundField>
     <asp:TemplateField HeaderStyle-CssClass="col_money"  ItemStyle-CssClass="col_money" HeaderText="提成小计">
        <ItemTemplate>
        <%#string.Format("{0:N}",Eval("Commission"))%>
        </ItemTemplate>

<HeaderStyle CssClass="col_money"></HeaderStyle>

<ItemStyle CssClass="col_money"></ItemStyle>
    </asp:TemplateField>
    <asp:BoundField HeaderText="返回金额" HeaderStyle-CssClass="col_money" ItemStyle-CssClass="col_money" DataField="ReturnMoney" >
   
<HeaderStyle CssClass="col_money"></HeaderStyle>

<ItemStyle CssClass="col_money"></ItemStyle>
    </asp:BoundField>
   
    <asp:BoundField HeaderText="消费日期" HeaderStyle-CssClass="col_datetime" ItemStyle-CssClass="col_datetime" DataField="CostDate" HtmlEncode="true" DataFormatString="{0:d}" >
<HeaderStyle CssClass="col_datetime"></HeaderStyle>

<ItemStyle CssClass="col_datetime"></ItemStyle>
    </asp:BoundField>
    <asp:BoundField HeaderText="申请日期" HeaderStyle-CssClass="col_datetime" ItemStyle-CssClass="col_datetime" DataField="CreateTime" HtmlEncode="true" DataFormatString="{0:d}" >
<HeaderStyle CssClass="col_datetime"></HeaderStyle>

<ItemStyle CssClass="col_datetime"></ItemStyle>
    </asp:BoundField>
    <asp:TemplateField HeaderStyle-CssClass="col_state"  ItemStyle-CssClass="col_state" HeaderText="状态">
        <ItemTemplate>
            <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                Eval("CheckState").ToString(),
                new string[][]{
                    new string[]{"0","<span style='color:#ff0000;'>待审核</span>"},
                    new string[]{"1","已审核"},
                    new string[]{"2","无效"},
                    new string[]{"3","过期"}
                }               
                )
            %>
        </ItemTemplate>    

<HeaderStyle CssClass="col_state"></HeaderStyle>

<ItemStyle CssClass="col_state"></ItemStyle>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="操作" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option">
        <ItemTemplate>
            <a href="Edit.aspx?id=<%#Eval("ID") %>">修改</a>
        </ItemTemplate>

<HeaderStyle CssClass="col_option"></HeaderStyle>

<ItemStyle CssClass="col_option"></ItemStyle>
    </asp:TemplateField>
</Columns>
</asp:GridView>


<table width="100%" class="dataGrid_Footer">
    <tr>
        <td class="options">
        <strong>总共记录</strong>:<span class="strewColor"><asp:Literal ID="litTotalRecord" runat="server"></asp:Literal></span>
        </td>
        <td class="pagerBox">
            <CashTicketControl:Pager ID="Pager1" runat="server"  />
        </td>
    </tr>
</table>


<table width="100%" class="dataGrid_Footer">
    <tr>
        <td class="options">
        <strong>统计</strong>
        </td>
        <td class="pagerBox">
        总共消费金额:<span class="strewColor"><asp:Literal ID="litTotalCostMoney" runat="server"></asp:Literal></span>元&nbsp;&nbsp;
        总共返回金额:<span class="strewColor"><asp:Literal ID="litTotalReturnMoney" runat="server"></asp:Literal></span>元&nbsp;&nbsp;
        总共提成金额:<span class="strewColor"><asp:Literal ID="litTotalCommission" runat="server"></asp:Literal></span>元
        </td>
    </tr>
</table>

 




</asp:Content>


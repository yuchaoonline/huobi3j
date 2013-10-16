<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="ListByAdmin.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.CashTicketApplications.ListByAdmin"  %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="CashTicketControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
Admin - CashTicketApplications - List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>ҵ��ͳ��</span> &gt; �ֽ�ȯ����ͳ��
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
<input type="hidden" name="page"  value="1" />
<table class="searchTable">
    <tr>
        <td class="key">ҵ��Ա:</td>
        <td class="input">
           <select id="adminid" runat="server">
           </select>        </td>
        <td class="key">�̼�����:</td>
        <td align="left" valign="middle" class="input">
         <input type="text" name="corpName" class="txtBox" id="corpName" runat="server" />
        </td>
		<td class="key">�����������:</td>
        <td align="left" valign="middle">
         �� <CashTicketControl:DateTimeSelector ID="txtStartDate" CssClass="txtDate" runat="server"></CashTicketControl:DateTimeSelector> �� <CashTicketControl:DateTimeSelector ID="txtEndDate" runat="server" CssClass="txtDate"></CashTicketControl:DateTimeSelector>
        </td>
        <td class="key">״̬:</td>
        <td class="input"><select name="state" runat="server" id="state">
          <option value="-1">ȫ��</option>
          <option value="0">�����</option>
          <option value="1">�����</option>
          <option value="2">��Ч</option>
          <option value="3">�ѹ���</option>
        </select>
        </td>
        <td class="key"><input name="submit" type="submit" value="����" /></td>
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
    
    <asp:BoundField HeaderText="ҵ��Ա" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" DataField="AdminUserName" >
<HeaderStyle CssClass="col_title"></HeaderStyle>

<ItemStyle CssClass="col_title"></ItemStyle>
    </asp:BoundField>
    <asp:BoundField HeaderText="�ֽ�ȯ���" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" DataField="SerialNum" >
<HeaderStyle CssClass="col_title"></HeaderStyle>

<ItemStyle CssClass="col_title"></ItemStyle>
    </asp:BoundField>
    <asp:BoundField HeaderText="�����̼�" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" DataField="RealCorpName" >
    
<HeaderStyle CssClass="col_title"></HeaderStyle>

<ItemStyle CssClass="col_title"></ItemStyle>
    </asp:BoundField>
    <asp:BoundField HeaderText="��ɰٷֱ�" HeaderStyle-CssClass="col_number" ItemStyle-CssClass="col_number" DataField="OfferPercent" DataFormatString="{0}%" >
<HeaderStyle CssClass="col_number"></HeaderStyle>

<ItemStyle CssClass="col_number"></ItemStyle>
    </asp:BoundField>
     <asp:TemplateField HeaderStyle-CssClass="col_money"  ItemStyle-CssClass="col_money" HeaderText="���С��">
        <ItemTemplate>
        <%#string.Format("{0:N}",Eval("Commission"))%>
        </ItemTemplate>

<HeaderStyle CssClass="col_money"></HeaderStyle>

<ItemStyle CssClass="col_money"></ItemStyle>
    </asp:TemplateField>
    <asp:BoundField HeaderText="���ؽ��" HeaderStyle-CssClass="col_money" ItemStyle-CssClass="col_money" DataField="ReturnMoney" >
   
<HeaderStyle CssClass="col_money"></HeaderStyle>

<ItemStyle CssClass="col_money"></ItemStyle>
    </asp:BoundField>
   
    <asp:BoundField HeaderText="��������" HeaderStyle-CssClass="col_datetime" ItemStyle-CssClass="col_datetime" DataField="CostDate" HtmlEncode="true" DataFormatString="{0:d}" >
<HeaderStyle CssClass="col_datetime"></HeaderStyle>

<ItemStyle CssClass="col_datetime"></ItemStyle>
    </asp:BoundField>
    <asp:BoundField HeaderText="��������" HeaderStyle-CssClass="col_datetime" ItemStyle-CssClass="col_datetime" DataField="CreateTime" HtmlEncode="true" DataFormatString="{0:d}" >
<HeaderStyle CssClass="col_datetime"></HeaderStyle>

<ItemStyle CssClass="col_datetime"></ItemStyle>
    </asp:BoundField>
    <asp:TemplateField HeaderStyle-CssClass="col_state"  ItemStyle-CssClass="col_state" HeaderText="״̬">
        <ItemTemplate>
            <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                Eval("CheckState").ToString(),
                new string[][]{
                    new string[]{"0","<span style='color:#ff0000;'>�����</span>"},
                    new string[]{"1","�����"},
                    new string[]{"2","��Ч"},
                    new string[]{"3","����"}
                }               
                )
            %>
        </ItemTemplate>    

<HeaderStyle CssClass="col_state"></HeaderStyle>

<ItemStyle CssClass="col_state"></ItemStyle>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="����" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option">
        <ItemTemplate>
            <a href="Edit.aspx?id=<%#Eval("ID") %>">�޸�</a>
        </ItemTemplate>

<HeaderStyle CssClass="col_option"></HeaderStyle>

<ItemStyle CssClass="col_option"></ItemStyle>
    </asp:TemplateField>
</Columns>
</asp:GridView>


<table width="100%" class="dataGrid_Footer">
    <tr>
        <td class="options">
        <strong>�ܹ���¼</strong>:<span class="strewColor"><asp:Literal ID="litTotalRecord" runat="server"></asp:Literal></span>
        </td>
        <td class="pagerBox">
            <CashTicketControl:Pager ID="Pager1" runat="server"  />
        </td>
    </tr>
</table>


<table width="100%" class="dataGrid_Footer">
    <tr>
        <td class="options">
        <strong>ͳ��</strong>
        </td>
        <td class="pagerBox">
        �ܹ����ѽ��:<span class="strewColor"><asp:Literal ID="litTotalCostMoney" runat="server"></asp:Literal></span>Ԫ&nbsp;&nbsp;
        �ܹ����ؽ��:<span class="strewColor"><asp:Literal ID="litTotalReturnMoney" runat="server"></asp:Literal></span>Ԫ&nbsp;&nbsp;
        �ܹ���ɽ��:<span class="strewColor"><asp:Literal ID="litTotalCommission" runat="server"></asp:Literal></span>Ԫ
        </td>
    </tr>
</table>

 




</asp:Content>


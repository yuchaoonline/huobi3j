<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="List.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.CP_KeywordIndex.List"  %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="CashTicketControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
Admin - Corps - List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
.searchTable .key{ width:auto; }
.searchTable .input{ width:auto; }
</style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>�̼��ƹ�</span> &gt; �ؼ��������������� | <a href="Refresh.aspx">���»�����</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
<input type="hidden" name="page"  value="1" />
<table class="searchTable">
    <tr>
        <td width="16%" class="key">�̼�����:</td>
        <td class="input">
            <asp:TextBox ID="txtCorp" runat="server" class="txtBox"></asp:TextBox>        </td>
        <td width="11%" class="key">�ؼ���:</td>
        <td width="11%" class="key"><asp:TextBox CssClass="input" ID="txtKeywords" runat="server" class="txtBox"></asp:TextBox>        </td>
        <td width="11%" class="key">&nbsp;</td>
        <td width="20%" class="input">
      </td>
        <td width="14%" class="key">&nbsp;</td>
    </tr>
    <tr>
      <td class="key">�ƹ����</td>
      <td class="input">
          <asp:TextBox ID="txtTitle" runat="server" class="txtBox"></asp:TextBox>	  </td>
      <td class="key">��������:</td>
      <td class="key"><span class="input">
        <asp:DropDownList id="ddlHidden" runat="server">
          <asp:ListItem Selected="True" Value="-1" Text="ȫ��"></asp:ListItem>
          <asp:ListItem Value="0" Text="��"></asp:ListItem>
          <asp:ListItem Value="1" Text="��"></asp:ListItem>
        </asp:DropDownList>
      </span></td>
      <td class="key">��������:</td>
      <td class="input"><asp:DropDownList id="ddlIsRankIndex" runat="server">
        <asp:ListItem Selected="True" Value="-1" Text="ȫ��"></asp:ListItem>
        <asp:ListItem Value="0" Text="��"></asp:ListItem>
        <asp:ListItem Value="1" Text="��"></asp:ListItem>
      </asp:DropDownList></td>
      <td class="key"><input name="submit" type="submit" value="����" /></td>
    </tr>
</table>


<asp:GridView ID="gvData" runat="server" CssClass="dataGrid" SkinID="gridviewSkin" AutoGenerateColumns="false" ShowFooter="false" BorderStyle="None"  ShowHeader="true">
<Columns>
    <asp:TemplateField HeaderStyle-CssClass="col_id"  ItemStyle-CssClass="col_id" HeaderText="ID">
        <ItemTemplate>
            <input type="checkbox" name="<% = gvData.ClientID %>" value="<%#Eval("ID") %>" /> <%#Eval("ID") %>
        </ItemTemplate>    
    </asp:TemplateField>
 	<asp:TemplateField HeaderStyle-CssClass="col_title"  ItemStyle-CssClass="col_title" HeaderText="�ؼ���">
        <ItemTemplate>
            <%#Eval("Keyword") %>
        </ItemTemplate>    
    </asp:TemplateField>

    <asp:BoundField HeaderText="�ƹ����" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" DataField="Title" />    
	
    <asp:BoundField HeaderText="�̼�����" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" DataField="CorpName" />    	
    <asp:BoundField HeaderText="����ʱ��" HeaderStyle-CssClass="col_datetime"  ItemStyle-CssClass="col_datetime" DataField="CreateTime" />
    <asp:BoundField HeaderText="����" HeaderStyle-CssClass="col_money"  ItemStyle-CssClass="col_money" DataField="Sequence"  />
	 <asp:TemplateField HeaderStyle-CssClass="col_state"  ItemStyle-CssClass="col_state" HeaderText="�ƹ����">
        <ItemTemplate>
           <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                Eval("PromotionCheckState").ToString(),
                new string[][]{
                    new string[]{"0","�����"},
                    new string[]{"1","�����"},
                    new string[]{"2","��Ч"},
                    new string[]{"3","����"}
                }               
                )
            %>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderStyle-CssClass="col_state"  ItemStyle-CssClass="col_state" HeaderText="��������">
        <ItemTemplate>
            <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                Eval("KeywordIsHidden").ToString(),
                new string[][]{
                    new string[]{"False","��"},
                    new string[]{"True","��"},
                }               
                )
            %>
        </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField HeaderStyle-CssClass="col_state"  ItemStyle-CssClass="col_state" HeaderText="��������">
        <ItemTemplate>
            <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                Eval("IsRankIndex").ToString(),
                new string[][]{
                    new string[]{"False","��"},
                    new string[]{"True","<span style='color:red'>��</span>"},
                }               
                )
            %>
        </ItemTemplate>
    </asp:TemplateField>
    <%--<asp:TemplateField HeaderText="����" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option">
        <ItemTemplate>
            <a href="Edit.aspx?id=<%#Eval("ID") %>">�޸�</a>
        </ItemTemplate>
    </asp:TemplateField>--%>
</Columns>
</asp:GridView>


<table width="100%" class="dataGrid_Footer">
    <tr>
        <td class="options">
         <!-- <a href="#" onclick="setCheckGroup('<% = gvData.ClientID %>',true); void(0);">ȫѡ</a> <a href="#" onclick="resverSelect('<% = gvData.ClientID %>'); void(0);">��ѡ</a> -->
        </td>
        <td class="pagerBox">
            <CashTicketControl:Pager ID="Pager1" runat="server"  />
        </td>
    </tr>
</table>




</asp:Content>


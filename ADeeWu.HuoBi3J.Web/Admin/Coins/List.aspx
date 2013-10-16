<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="List.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.Coins.List"  %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="CashTicketControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
Admin - Users - List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>��Ա���ҹ���</span> &gt; ��ϸ��¼ | <a href="Add.aspx">��ӻ���</a> | <a href="Sub.aspx">�۳�����</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

<table class="searchTable">
    <tr>
        <td class="key">��Ա�ʺ�:</td>
        <td class="input">
            <asp:TextBox ID="txtLoginName" runat="server" CssClass="txtBox"></asp:TextBox>
        </td>
        <td class="key">ɸѡ:</td>
        <td class="input">
            <asp:DropDownList ID="ddlFilter" runat="server">
                <asp:ListItem Text="ȫ��" Value="-1" Selected="True"></asp:ListItem>
                <asp:ListItem Text="��ӻ���" Value="0"></asp:ListItem>
                <asp:ListItem Text="�۳�����" Value="1"></asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="����" onclick="btnSearch_Click" />
        </td>
    </tr>
</table>

<asp:GridView ID="gvData" runat="server" CssClass="dataGrid" SkinID="gridviewSkin" AutoGenerateColumns="false" ShowFooter="false" BorderStyle="None"  ShowHeader="true">
<Columns>
    <asp:TemplateField HeaderStyle-CssClass="col_id"  ItemStyle-CssClass="col_id" HeaderText="ID">
        <ItemTemplate>
            <input type="checkbox" name="id" value="<%#Eval("ID") %>" /> <%#Eval("ID") %>
        </ItemTemplate>     
    </asp:TemplateField>
    
    <asp:HyperLinkField HeaderText="��Ա�ʺ�" HeaderStyle-CssClass="col_account" ItemStyle-CssClass="col_account" DataNavigateUrlFields="UserID" DataNavigateUrlFormatString="../Users/Edit.aspx?id={0}" DataTextField="LoginName" />
    <asp:BoundField HeaderText="��ӻ���" HeaderStyle-CssClass="col_money" ItemStyle-CssClass="col_money" DataField="InCoin" />
    <asp:BoundField HeaderText="�۳�����" HeaderStyle-CssClass="col_money" ItemStyle-CssClass="col_money" DataField="OutCoin" />
    <asp:BoundField HeaderText="ʣ�����" HeaderStyle-CssClass="col_account" ItemStyle-CssClass="col_account" DataField="Remain" />
    <asp:BoundField HeaderText="��ע" HeaderStyle-CssClass="col_notes" ItemStyle-CssClass="col_notes"  DataField="Notes" />
    <asp:BoundField HeaderText="ʱ��" HeaderStyle-CssClass="col_datetime"  ItemStyle-CssClass="col_datetime" DataField="CreateTime"  />
   <%-- <asp:TemplateField HeaderText="����" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option">
        <ItemTemplate>
            <a href="Edit.aspx?id=<%#Eval("ID") %>">�޸�</a> | <a href="Del.aspx?id=<%#Eval("ID") %>">ɾ��</a>
        </ItemTemplate>
    </asp:TemplateField>--%>
    
</Columns>
</asp:GridView>


<table width="100%" class="dataGrid_Footer">
    <tr>
        <td class="options">
         <%--<a href="#" onclick="setCheckGroup('id',true); return false;">ȫѡ</a> <a href="#" onclick="resverSelect('id'); return false;">��ѡ</a>--%>
        </td>
        <td class="pagerBox">
            <CashTicketControl:Pager ID="Pager1" runat="server"  />
        </td>
    </tr>
</table>




</asp:Content>


<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="List.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.Users.List"  %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="CashTicketControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
Admin - Users - List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>ע���û�����</span> &gt; �û��б�
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
<input type="hidden" name="page"  value="1" />
<table class="searchTable">
    <tr>
        <td class="key">UIN:</td>
        <td class="input">
            <input type="text" name="uin" id="uin" runat="server" class="txtBox" /> 
        </td>
        <td class="key">�ʺ�:</td>
        <td class="input">
            <input type="text" name="loginName" id="loginName" runat="server" class="txtBox" /> 
        </td>
        <td class="key">����:</td>
        <td class="input">
            <input type="text" name="name" id="name" runat="server" class="txtBox" />
        </td>
        <td><input type="submit" value="����" /></td>
    </tr>
</table>

<asp:GridView ID="gvData" runat="server" CssClass="dataGrid" SkinID="gridviewSkin" AutoGenerateColumns="false" ShowFooter="false" BorderStyle="None"  ShowHeader="true">
<Columns>
    <asp:TemplateField HeaderStyle-CssClass="col_id"  ItemStyle-CssClass="col_id" HeaderText="ID">
        <ItemTemplate>
            <input type="checkbox" name="id" value="<%#Eval("ID") %>" /> <%#Eval("ID") %>
        </ItemTemplate>    
    </asp:TemplateField>
    <asp:BoundField HeaderText="UIN" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" DataField="UIN" />
    <asp:HyperLinkField HeaderText="�ʺ�" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" DataNavigateUrlFields="id" DataNavigateUrlFormatString="Edit.aspx?id={0}" DataTextField="LoginName" />
    <asp:HyperLinkField HeaderText="����" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" DataNavigateUrlFields="id" DataNavigateUrlFormatString="Edit.aspx?id={0}" DataTextField="Name" />
    
    <asp:BoundField HeaderText="Email" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" DataField="Email" />
    <asp:BoundField HeaderText="��һ�ε�½" HeaderStyle-CssClass="col_datetime" ItemStyle-CssClass="col_datetime" DataField="LastLogin" HtmlEncode="true" DataFormatString="{0:d}" />
    <asp:BoundField HeaderText="ע��ʱ��" HeaderStyle-CssClass="col_datetime"  ItemStyle-CssClass="col_datetime" DataField="RegTime" HtmlEncode="true" DataFormatString="{0:d}" />
    <asp:BoundField HeaderText="��½����" HeaderStyle-CssClass="col_number"  ItemStyle-CssClass="col_number" DataField="LoginTimes"  />
    <asp:TemplateField HeaderText="����" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option">
        <ItemTemplate>
            <a href="Edit.aspx?id=<%#Eval("ID") %>">�޸�</a> <%--| <a href="Del.aspx?id=<%#Eval("ID") %>">ɾ��</a>--%>
        </ItemTemplate>
    </asp:TemplateField>
    
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


<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="List.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.CorpAgent.UserInCorps.List"  %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
Admin - CorpAgent - UserInCorps - List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
.searchTable .key{ width:auto; }
.searchTable .input{ width:auto; }
</style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>�̼����������</span> &gt; �б�
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
<input type="hidden" name="page"  value="1" />
<table class="searchTable">
    <tr>
        <td class="key">����������:</td>
        <td class="input">
            <asp:TextBox ID="txtCorpAgentRealName" runat="server" CssClass="txtBox"></asp:TextBox>
        </td>
        <td class="key">�̼�����:</td>
        <td class="input">
            <asp:TextBox ID="txtCorpName" runat="server" CssClass="txtBox"></asp:TextBox>
        </td>
        <td class="key">״̬:</td>
        <td class="input">
        <asp:DropDownList ID="ddlCheckState" runat="server">
            <asp:ListItem Value="-1" Selected="True">ȫ��</asp:ListItem>
            <asp:ListItem Value="0">�����</asp:ListItem>
            <asp:ListItem Value="1">ͨ�����</asp:ListItem>
            <asp:ListItem Value="2">��Ч</asp:ListItem>
            <asp:ListItem Value="3">����</asp:ListItem>
        </asp:DropDownList>
        </td>
        <td class="key">&nbsp;</td>
        <td class="input">
            <asp:Button ID="btnSubmit" runat="server" Text="����" onclick="btnSubmit_Click" />
        </td>
    </tr>
</table>


<asp:GridView ID="gvData" runat="server" CssClass="dataGrid" SkinID="gridviewSkin" AutoGenerateColumns="false" ShowFooter="false" BorderStyle="None"  ShowHeader="true">
<Columns>
    <asp:TemplateField HeaderStyle-CssClass="col_id"  ItemStyle-CssClass="col_id" HeaderText="ID">
        <ItemTemplate>
            <%--<input type="checkbox" name="<% = gvData.ClientID %>" value="<%#Eval("ID") %>" />--%> <%#Eval("ID") %>
        </ItemTemplate>    
    </asp:TemplateField>     
    <asp:TemplateField HeaderText="������ͨѶ����">
    <ItemTemplate>
        <a href="../Applications/Edit.aspx?userid=<%#Eval("UserID") %>"><%#Eval("CorpAgentUIN")%></a>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:BoundField HeaderText="����������" DataField="CorpAgentLoginName"  HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" />
    <asp:BoundField HeaderText="�̼�����" DataField="CorpName"  HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" />
    <asp:BoundField HeaderText="�̼�ͨѶ����" DataField="CorpUIN" />
   
	
    <asp:BoundField HeaderText="����ʱ��" HeaderStyle-CssClass="col_datetime"  ItemStyle-CssClass="col_datetime" DataField="CreateTime" HtmlEncode="true" DataFormatString="{0:d}" />
    <asp:TemplateField HeaderStyle-CssClass="col_state"  ItemStyle-CssClass="col_state" HeaderText="״̬">
        <ItemTemplate>
            <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                Eval("CheckState").ToString(),
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
    <asp:TemplateField HeaderText="����" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option">
        <ItemTemplate>
            <a href="Edit.aspx?id=<%#Eval("ID") %>">�޸�</a>
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
            <IscControl:Pager ID="Pager1" runat="server"  />
        </td>
    </tr>
</table>




</asp:Content>


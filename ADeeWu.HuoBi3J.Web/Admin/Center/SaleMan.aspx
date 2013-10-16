<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="SaleMan.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.Center.SaleMan"  %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
�ޱ����ĵ�
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>��ʱ���۹���</span> &gt; ҵ��Ա�б�
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
<input type="hidden" name="page"  value="1" />
<table class="searchTable">
    <tr>
        <td class="key">�û�����:</td>
        <td class="input"><input type="text" name="LoginName" class="LoginName" id="LoginName" runat="server" /></td>
        <td class="key">״̬:</td>
        <td class="input"><select name="state" runat="server" id="state">
          <option value="-1">ȫ��</option>
          <option value="0">�����</option>
          <option value="1">�����</option>
          <option value="2">��Ч</option>
          <option value="3">�ѹ���</option>
        </select></td>
        <td class="key"><input name="submit" type="submit" value="����" /></td>
    </tr>
</table>


<asp:GridView ID="gvData" runat="server" CssClass="dataGrid" 
    SkinID="gridviewSkin" AutoGenerateColumns="False" BorderStyle="None" 
    EnableModelValidation="True">
<Columns>
    <asp:TemplateField HeaderStyle-CssClass="col_id"  ItemStyle-CssClass="col_id" HeaderText="ID">
        <ItemTemplate>
            <input type="checkbox" name="<% = gvData.ClientID %>" value="<%#Eval("ID") %>" /> <%#Eval("ID") %>
        </ItemTemplate>    

<HeaderStyle CssClass="col_id"></HeaderStyle>

<ItemStyle CssClass="col_id"></ItemStyle>
    </asp:TemplateField>
     <asp:HyperLinkField HeaderText="�û�����" HeaderStyle-CssClass="col_title" 
        ItemStyle-CssClass="col_title" DataNavigateUrlFields="id" 
        DataNavigateUrlFormatString="Edit.aspx?id={0}" DataTextField="LoginName" >    
<HeaderStyle CssClass="col_title"></HeaderStyle>

<ItemStyle CssClass="col_title"></ItemStyle>
    </asp:HyperLinkField>
	
    <asp:BoundField HeaderText="����ʱ��" HeaderStyle-CssClass="col_datetime"  
        ItemStyle-CssClass="col_datetime" DataField="CreateTime" HtmlEncode="true" 
        DataFormatString="{0:d}" >
<HeaderStyle CssClass="col_datetime"></HeaderStyle>

<ItemStyle CssClass="col_datetime"></ItemStyle>
    </asp:BoundField>
    <asp:BoundField DataField="ModifyTime" DataFormatString="{0:d}" 
        HeaderText="�޸�ʱ��" />
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
         <!-- <a href="#" onclick="setCheckGroup('<% = gvData.ClientID %>',true); void(0);">ȫѡ</a> <a href="#" onclick="resverSelect('<% = gvData.ClientID %>'); void(0);">��ѡ</a> -->
        </td>
        <td class="pagerBox">
            <IscControl:Pager ID="Pager1" runat="server"  />
        </td>
    </tr>
</table>
</asp:Content>


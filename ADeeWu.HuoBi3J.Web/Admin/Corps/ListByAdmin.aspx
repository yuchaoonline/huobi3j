<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="ListByAdmin.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.Corps.ListByAdmin"  %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
Admin - Corps - List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>ҵ��ͳ��</span> &gt; �̼�ͳ��
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
<table class="searchTable">
    <tr>
        <td class="key">ҵ��Ա:</td>
        <td class="input">
            <asp:DropDownList ID="ddlAdminUser" runat="server">
            </asp:DropDownList> 
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
    </tr>
    <tr>
      <td class="key">��ҵ:</td>
      <td class="input">
	  	
	  	<IscControl:SyncSelector ID="syncSelectorCalling" runat="server" 
        DataSourceURL="<%$Resources:SyncSelector,Calling_DataSourceURL %>" 
        DataSourceName="<%$Resources:SyncSelector,Calling_DataSourceName %>" 
        ClientPostNames="<%$Resources:SyncSelector,Calling_ClientPostNames %>"
        />
	  	
      </td>
      <td class="key">����:</td>
      <td class="input">
	  	 <IscControl:SyncSelector ID="syncSelectorLocation" runat="server" 
        DataSourceURL="<%$Resources:SyncSelector,Location_DataSourceURL %>" 
        DataSourceName="<%$Resources:SyncSelector,Location_DataSourceName %>" 
        ClientPostNames="<%$Resources:SyncSelector,Location_ClientPostNames %>"
        />
	  	 
	  </td>
      <td class="key">
          <asp:Button ID="btnSubmit" runat="server" Text="����" onclick="btnSubmit_Click" />
      </td>
      <td class="input">&nbsp;</td>
    </tr>
</table>


<asp:GridView ID="gvData" runat="server" CssClass="dataGrid" SkinID="gridviewSkin" AutoGenerateColumns="false" ShowFooter="false" BorderStyle="None"  ShowHeader="true">
<Columns>
    <asp:TemplateField HeaderStyle-CssClass="col_id"  ItemStyle-CssClass="col_id" HeaderText="ID">
        <ItemTemplate>
            <input type="checkbox" name="<% = gvData.ClientID %>" value="<%#Eval("ID") %>" /> <%#Eval("ID") %>
        </ItemTemplate>    
    </asp:TemplateField>
    
    <asp:BoundField HeaderText="�̼�����" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" DataField="CorpName" />
    <asp:TemplateField HeaderText="�û�" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title">
        <ItemTemplate>
            <a href="../Users/Edit.aspx?id=<%#Eval("UserID") %>"><%#ADeeWu.HuoBi3J.Libary.Utility.GetStr(Eval("UIN"), Eval("LoginName"), "", true)%></a>
        </ItemTemplate>    
    </asp:TemplateField>
    
    <asp:BoundField HeaderText="��ҵ" HeaderStyle-CssClass="col_calling" ItemStyle-CssClass="col_calling" DataField="Calling" />
    <asp:TemplateField HeaderStyle-CssClass="col_location"  ItemStyle-CssClass="col_location" HeaderText="��������">
        <ItemTemplate>
            <%#string.Format("{0} {1} {2}", Eval("Province"),Eval("City"),Eval("Area")) %>
        </ItemTemplate>    
    </asp:TemplateField>
    <asp:BoundField HeaderText="ע��ʱ��" HeaderStyle-CssClass="col_datetime"  ItemStyle-CssClass="col_datetime" DataField="CreateTime" HtmlEncode="true" DataFormatString="{0:d}" />
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
    <asp:TemplateField HeaderStyle-CssClass="col_option"  ItemStyle-CssClass="col_option" HeaderText="����">
        <ItemTemplate>
            <a href="Edit.aspx?id=<%#Eval("id") %>">�޸�</a>
        </ItemTemplate>    
    </asp:TemplateField>
</Columns>
</asp:GridView>


<table width="100%" class="dataGrid_Footer">
    <tr>
        <td class="options">
            �̼�����:<asp:Literal ID="litNumOfCorps" runat="server"></asp:Literal>
        </td>
        <td class="pagerBox">
           <IscControl:Pager ID="Pager1" runat="server"  />
        </td>
    </tr>
</table>




</asp:Content>


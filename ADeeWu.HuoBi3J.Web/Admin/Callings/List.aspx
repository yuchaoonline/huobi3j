<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="List.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.Callings.List" %>
<%@ Register assembly="ADeeWu.HuoBi3J.WebUI" namespace="ADeeWu.HuoBi3J.WebUI" tagprefix="IscControl" %>




<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
Ӫ������ - �������
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>��ҵ�������</span> &gt; �����б� | <a href="Add.aspx">���</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    
    <div>
     <input name="page" type="hidden" value="1" />
    <table class="searchTable">
        <tr>
            <td class="key" style="width:80px">
                ���⣺            </td>
            <td class="input">
                <asp:TextBox ID="txtTitle" runat="server" Width="100px"></asp:TextBox>
            </td>
            <td class="key">
                ���أ�            
			</td>
            <td class="input">
                <asp:DropDownList ID="ddlIsHidden" runat="server">
                    <asp:ListItem Value="-1">ȫ��</asp:ListItem>
                    <asp:ListItem Value="0">��</asp:ListItem>
                    <asp:ListItem Value="1">��</asp:ListItem>  
                </asp:DropDownList>            
		    </td>
        </tr>
        <tr>
          <td class="key" style="width:80px">�������ࣺ
          </td>
          <td class="input">
		  	 <IscControl:SyncSelector ID="syncSelectorCalling" runat="server" 
        DataSourceURL="<%$Resources:SyncSelector,Calling_DataSourceURL %>" 
        DataSourceName="<%$Resources:SyncSelector,Calling_DataSourceName %>" 
        ClientPostNames="<%$Resources:SyncSelector,Calling_ClientPostNames %>"
                RefreshClientData="true"
                />
		  </td>
          <td class="key">�Ƽ���</td>
          <td class="input">
          <asp:DropDownList ID="ddlIsRecommend" runat="server">
                    <asp:ListItem Value="-1">ȫ��</asp:ListItem>
                    <asp:ListItem Value="0">��</asp:ListItem>
                    <asp:ListItem Value="1">��</asp:ListItem>  
                </asp:DropDownList> 
              <asp:Button ID="btnSubmit" runat="server" Text="����" onclick="btnSubmit_Click" />
          </td>
        </tr>
    </table>
    
     
<asp:GridView Width="100%" ID="gvData" runat="server"  CssClass="gridView" SkinID="userGridViewSkin" AutoGenerateColumns="False">
<Columns>
    <asp:BoundField HeaderText="����" HeaderStyle-CssClass="col_title"  ItemStyle-CssClass="col_title" DataField="name" />
   
   <asp:TemplateField HeaderText="����ʱ��" HeaderStyle-CssClass="col_datetime" ItemStyle-CssClass="col_datetime">
        <ItemTemplate>
            <%# Eval("CreateTime")%> 
        </ItemTemplate>
    </asp:TemplateField>
   <asp:TemplateField HeaderText="����޸�ʱ��" HeaderStyle-CssClass="col_datetime" ItemStyle-CssClass="col_datetime">
        <ItemTemplate>
            <%# Eval("ModifyTime")%>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:BoundField HeaderText="����" DataField="Sequence" />
    <asp:BoundField HeaderText="���" DataField="Depth" />
    <asp:TemplateField HeaderText="����">
        <ItemTemplate>
            <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                Eval("IsHidden").ToString().ToLower(),
                new string[][]{
                    new string[]{"true","��"},
                    new string[]{"false","��"}
                }               
                )
            %>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="�Ƽ�">
        <ItemTemplate>
            <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                Eval("IsRecommend").ToString().ToLower(),
                new string[][]{
                    new string[]{"true","��"},
                    new string[]{"false","��"}
                }               
                )
            %>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="����" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option"> 
        <ItemTemplate>
          <a href="Edit.aspx?id=<%#Eval("ID") %>">�޸�</a>
         <!--<a onclick="return confirm('��ȷ��Ҫɾ��������Ϣ��')" href="Del.aspx?id=<%#Eval("ID") %>">ɾ��</a>-->
        </ItemTemplate>
    </asp:TemplateField>
</Columns>
</asp:GridView>
<table width="100%" class="dataGrid_Footer" style="margin-top:-5px;">
    <tr>
        <td class="options">&nbsp;
        
        </td>
        <td class="pagerBox">
            <IscControl:Pager ID="Pager1" runat="server"  />
        </td>
    </tr>
</table>
    
    
    
    </div>
     
</asp:Content>


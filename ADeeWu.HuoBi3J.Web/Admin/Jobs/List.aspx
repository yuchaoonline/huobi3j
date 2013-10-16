<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="List.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.Jobs.List"  %>
<%@ Register assembly="ADeeWu.HuoBi3J.WebUI" namespace="ADeeWu.HuoBi3J.WebUI" tagprefix="CashTicketControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
�ޱ����ĵ�
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" type="text/css" href="../skins/css/main.css">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>���߳���</span> &gt; <a href="List.aspx">�б�</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    
    <div>
     <input name="page" type="hidden" value="1" />
    <table class="searchTable">
        <tr>
            <td class="key" style="width:80px">
                ְλ���ƣ�
            </td>
            <td>
                <asp:TextBox ID="jobName" runat="server" Width="100px"></asp:TextBox>
            </td>
            <td class="key">
                ״̬��
            </td>
            <td>
                <asp:DropDownList ID="ddlCheckState" runat="server">
                    <asp:ListItem Value="-1">ȫ��</asp:ListItem>
                    <asp:ListItem Value="0">�����</asp:ListItem>
                    <asp:ListItem Value="1">�����</asp:ListItem>
                    <asp:ListItem Value="2">ʧЧ</asp:ListItem>
                    <asp:ListItem Value="3">����</asp:ListItem>     
                </asp:DropDownList>
            </td>
            <td >
                ����ʱ�䣺
            </td>
            <td>
		        <CashTicketControl:DateTimeSelector ID="beginTimeSelector" Width="90px"  runat="server"></CashTicketControl:DateTimeSelector>
		        ��
                <CashTicketControl:DateTimeSelector ID="endTimeSelector" Width="90px" runat="server"></CashTicketControl:DateTimeSelector>
                  <input name="submit" type="submit" value="����" />
               </td>
        </tr>
    </table>
    
    <!--��˾���� ְλ����  ְҵ����  ��������  ��������  ӦƸ -->
<asp:GridView Width="100%" ID="gvData" runat="server"  CssClass="gridView" SkinID="userGridViewSkin" AutoGenerateColumns="False">
<Columns>
    <asp:BoundField HeaderText="��˾����" HeaderStyle-CssClass="col_title"  ItemStyle-CssClass="col_title" DataField="CorpName"  >
    </asp:BoundField>
    <asp:BoundField HeaderText="ְλ����" HeaderStyle-CssClass="col_title"  ItemStyle-CssClass="col_title" DataField="Title"  >
    </asp:BoundField>
   <asp:BoundField HeaderText="ְҵ����" HeaderStyle-CssClass="col_calling" ItemStyle-CssClass="col_calling"  DataField="CategoryName" ></asp:BoundField>
   
   <asp:TemplateField HeaderText="��������" HeaderStyle-CssClass="col_location" ItemStyle-CssClass="col_location">
        <ItemTemplate>
            <%# Eval("CityName") %>-<%# Eval("AreaName") %>
        </ItemTemplate>
    </asp:TemplateField>
   <asp:TemplateField HeaderText="����ʱ��" HeaderStyle-CssClass="col_money" ItemStyle-CssClass="col_money">
        <ItemTemplate>
            <%# Eval("CreateTime","{0:yyyy-MM-dd}")%>
        </ItemTemplate>
    </asp:TemplateField>
  <%--  
   <asp:TemplateField HeaderText="���ˢ��ʱ��" HeaderStyle-CssClass="col_notes" ItemStyle-CssClass="col_notes">
        <ItemTemplate>
            <%# Eval("RefreshTime")%>
        </ItemTemplate>
   </asp:TemplateField>
    --%>
    <asp:TemplateField HeaderText="״̬">
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
            <CashTicketControl:Pager ID="Pager1" runat="server"  />
        </td>
    </tr>
</table>
    
    
    
    </div>
     
</asp:Content>


<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="List.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.Houses.List" ValidateRequest="false" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="CashTicketControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
Admin - SystemManage - AdminUsers - List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<script src="../../JS/jquery.js" type="text/javascript"></script>
<script src="../../JS/DateTimeSelector/jquery.dynDateTime.js" type="text/javascript"></script>
<script src="../../JS/DateTimeSelector/lang/calendar-zh.js" type="text/javascript"></script>
<link href="../../JS/DateTimeSelector/css/calendar-blue.css" rel="stylesheet" type="text/css" />
<style type="text/css">
    #txtbegintime
    {
        width: 103px;
    }
    #txtendtime
    {
        width: 100px;
    }
</style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>��̨���߳������</span> &gt; �鿴������Ϣ
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

 <input type="hidden" name="page"  value="1" />
<table class="searchTable">
    <tr>
        <td class="key" style="width:50px">���⣺</td>
        <td>        
            <asp:TextBox ID="txtTitle" runat="server" Width="120px"></asp:TextBox>
        </td>
        <td  style="width:60px">        
            ���ݽṹ��
        </td>
        <td >        
         <asp:DropDownList ID="ddlhousestrcts" runat="server">
                    <asp:ListItem Value="-1">ȫ��</asp:ListItem>
                    <asp:ListItem Value="0">����</asp:ListItem>
                    <asp:ListItem Value="1">һ��һ��</asp:ListItem>
                    <asp:ListItem Value="2">����һ��</asp:ListItem>
                    <asp:ListItem Value="3">���Ҷ���</asp:ListItem>     
                    <asp:ListItem Value="4">����һ��</asp:ListItem>  
                    <asp:ListItem Value="5">����һ��</asp:ListItem>     
                    <asp:ListItem Value="6">���Ҷ���</asp:ListItem>  
                    <asp:ListItem Value="7">�����ṹ</asp:ListItem>                  
        </asp:DropDownList>
        </td>
        <td>        
            ����ʱ�䣺
        </td>
        <td >        
              <script type="text/javascript">
					jQuery(document).ready(function() {
						jQuery("#txtbegintime").dynDateTime(); //defaults
						jQuery("#txtendtime").dynDateTime(); 
					});
		 </script>
		 &nbsp;<input type="text" id="txtbegintime" runat="server" readonly=readonly /> 
            ��<input type="text" id="txtendtime" runat="server" readonly=readonly />
        </td>
    </tr>
    <tr>
        <td class="key" style="width:50px">״̬��</td>
        <td>        
            <asp:DropDownList ID="ddlstate" runat="server">
                <asp:ListItem Value="-1">ȫ��</asp:ListItem>
                <asp:ListItem Value="0">�����</asp:ListItem>
                <asp:ListItem Value="1">�����</asp:ListItem>
                <asp:ListItem Value="2">��Ч</asp:ListItem>
                <asp:ListItem Value="3">����</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td  style="width:60px">        
              <asp:Button ID="btnQuery" runat="server" Text="����" onclick="btnQuery_Click" />
        </td>
        <td >&nbsp;        
            </td>
        <td>&nbsp;        
            </td>
        <td >&nbsp;        
              </td>
    </tr>
    </table>
<asp:GridView Width="100%" ID="gvData" runat="server"  CssClass="gridView" SkinID="userGridViewSkin" AutoGenerateColumns="False">
<Columns>
    <asp:TemplateField HeaderStyle-CssClass="col_id"  ItemStyle-CssClass="col_id" HeaderText="���">
        <ItemTemplate>
        <%--<input type="checkbox" name="id" value="<%#Eval("homeCode") %>" />--%> <%#Eval("homeCode") %></ItemTemplate>     
    </asp:TemplateField>
    <asp:BoundField HeaderText="����" HeaderStyle-CssClass="col_title"  ItemStyle-CssClass="col_title" DataField="Title" />
   <asp:BoundField HeaderText="���ݽY��" HeaderStyle-CssClass="col_notes" ItemStyle-CssClass="col_notes"  DataField="HouseStructText" />
   
   <asp:TemplateField HeaderText="��������" HeaderStyle-CssClass="col_money" ItemStyle-CssClass="col_money">
        <ItemTemplate>
            <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                Eval("HouseType").ToString(),
                new string[][]{
                    new string[]{"0","סլ"},
                    new string[]{"1","����"},
                    new string[]{"2","д��¥"},
                    new string[]{"3","����"}
                }               
                )
            %>
        </ItemTemplate>
    </asp:TemplateField>
   <asp:TemplateField HeaderText="��������" HeaderStyle-CssClass="col_money" ItemStyle-CssClass="col_money">
        <ItemTemplate>
            <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                Eval("Properity").ToString(),
                            "����",
                new string[][]{
                    new string[]{"0","����"},
                    new string[]{"1","ת��"},
                    new string[]{"2","����"}
                }         
                )
            %>
            
        </ItemTemplate>
    </asp:TemplateField>
    
   
   <asp:TemplateField HeaderText="�������" HeaderStyle-CssClass="col_notes" ItemStyle-CssClass="col_notes">
        <ItemTemplate>
            <%#Eval("AreaSize") %> m<sup>2</sup>
        </ItemTemplate>
   </asp:TemplateField>
    
    <asp:BoundField HeaderText="����" HeaderStyle-CssClass="col_money"  
        ItemStyle-CssClass="col_money" DataField="Price" Visible="False" >
    </asp:BoundField>
    <asp:BoundField DataField="CreateTime"  HeaderText="����ʱ��" />
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
          <a href="Edit.aspx?id=<%#Eval("id") %>">�޸�</a>
        </ItemTemplate>
    </asp:TemplateField>
</Columns>
</asp:GridView>
<table width="100%" class="dataGrid_Footer" style="margin-top:-5px;">
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


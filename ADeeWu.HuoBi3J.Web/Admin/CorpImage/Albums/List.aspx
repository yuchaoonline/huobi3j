<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="List.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.CorpImage.Albums.List"  %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
Admin - Corps - List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>��ҵ������</span> &gt; �б�
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
<input type="hidden" name="page"  value="1" />
<table class="searchTable">
    <tr>
    <td class="key" style="width:80px"> ���⣺</td>
    <td><asp:TextBox ID="txtTitle" runat="server" Width="120px" /></td> 
    <td class="key" style="width:80px">�̼����ƣ�</td>
    <td><asp:TextBox ID="txtCorpID" runat="server" Width="120px" /></td> 
        <td class="key">
            <asp:Button ID="btnSubmit" runat="server" Text="����" 
                onclick="btnSubmit_Click" />
        </td>
    </tr>
</table>


<asp:GridView ID="gvData" runat="server" CssClass="dataGrid" SkinID="gridviewSkin" AutoGenerateColumns="false" ShowFooter="false" BorderStyle="None"  ShowHeader="true">
<Columns>
   
    <asp:TemplateField   HeaderText="���">     
          <ItemTemplate>
           <%# Eval("ID")%>
          </ItemTemplate>
    </asp:TemplateField>
    
     <asp:TemplateField HeaderText="����">
        <ItemTemplate>
            <%# Eval("Title")  %>
        </ItemTemplate>
    </asp:TemplateField>
    
    <asp:TemplateField HeaderText="�̼�����">
        <ItemTemplate>
         <a herf="../Edit.aspx?id=<%#Eval("CorpID") %>"><%#Eval("CorpName") %></a>       
         </ItemTemplate>
    </asp:TemplateField>
        
    <asp:TemplateField HeaderText="�Ƽ�">
        <ItemTemplate>
           <%# ((bool)Eval("IsRecommend")) ? "��" : "��"%>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="����">
        <ItemTemplate>             
            <%# ((bool)Eval("IsHidden")) ? "��" : "��"%>
        </ItemTemplate>
    </asp:TemplateField>
         
    
    <asp:BoundField HeaderText="����ʱ��"  DataField="CreateTime" />   
    <asp:TemplateField HeaderText="����" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option"> <ItemTemplate>
                    <a href='photos/List.aspx?albumid=<%#Eval("id") %>'>�鿴|</a>  
                    
                    <a href='Edit.aspx?id=<%#Eval("ID") %>&corpID=<%#Eval("corpID") %>',>�޸�|</a>  
                    <a href='Del.aspx?id=<%#Eval("ID") %>&corpID=<%#Eval("corpID") %>' dir="ltr" onclick="return confirm('��ȷ��Ҫɾ��������Ϣ��')">
                    ɾ��</a>
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


<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.Shop.Vouchers.Default" %>
<%@ Register assembly="ADeeWu.HuoBi3J.WebUI" namespace="ADeeWu.HuoBi3J.WebUI" tagprefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
�̼ҿ������ - ����ƾ֤
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<script src="/JS/isc.js" type="text/javascript"></script>
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">��</span><a href="/My/Corp/Shop/">����Ӫ��</a><span class="spl">��</span><span class="curPos">����ƾ֤</span>  
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">   
   

<table class="searchTable">
    <tr>       
         <td class="key" style="width:70px">
                ������UIN��
         </td>
         <td>
                <asp:TextBox ID="txtBuyerUIN" runat="server" Width="120px" />
                <asp:Button ID="btnSubmit" runat="server" Text="����" onclick="btnSubmit_Click" /> 
                <a href="New.aspx">��ӵ���ƾ֤</a>
         </td>
          
        </tr>
</table>    


<asp:GridView ID="gvData" runat="server" CssClass="gridView" 
        SkinID="userGridViewSkin" AutoGenerateColumns="False">
<Columns>
     
  
    <asp:TemplateField HeaderText="����" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" ItemStyle-Width="400px">
        <ItemTemplate>
           <%# Eval("Title")%>
        </ItemTemplate>
    </asp:TemplateField>
   <asp:TemplateField HeaderText="������UIN" ItemStyle-Width="80px">
        <ItemTemplate>
           <%# Eval("BuyerUIN")%>
        </ItemTemplate>
    </asp:TemplateField>
     <asp:TemplateField HeaderText="�������ʺ�" ItemStyle-Width="80px">
        <ItemTemplate>
           <%# Eval("BuyerLoginName")%>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="�������ǳ�" ItemStyle-Width="120px">
        <ItemTemplate>
           <%# Eval("BuyerName")%>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="ʱ��" HeaderStyle-CssClass="col_datetime" ItemStyle-CssClass="col_datetime" ItemStyle-Width="200px">
        <ItemTemplate>
           <%# Eval("CreateTime")%>
        </ItemTemplate>
    </asp:TemplateField>
    
    <asp:TemplateField HeaderText="�鿴" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option"> 
	<ItemTemplate>                    
                    
             <a href='View.aspx?id=<%#Eval("ID") %>'>�鿴��ϸ</a> 
                                      
    </ItemTemplate>
    </asp:TemplateField>
    
</Columns>
</asp:GridView>


<div class="pager">
    <IscControl:Pager ID="Pager1" runat="server"  />
</div>
   
   
   
  
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>




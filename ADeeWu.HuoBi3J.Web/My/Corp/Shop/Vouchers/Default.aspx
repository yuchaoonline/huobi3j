<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.Shop.Vouchers.Default" %>
<%@ Register assembly="ADeeWu.HuoBi3J.WebUI" namespace="ADeeWu.HuoBi3J.WebUI" tagprefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
商家控制面板 - 电子凭证
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<script src="/JS/isc.js" type="text/javascript"></script>
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">　</span><a href="/My/Corp/Shop/">在线营销</a><span class="spl">　</span><span class="curPos">电子凭证</span>  
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">   
   

<table class="searchTable">
    <tr>       
         <td class="key" style="width:70px">
                消费者UIN：
         </td>
         <td>
                <asp:TextBox ID="txtBuyerUIN" runat="server" Width="120px" />
                <asp:Button ID="btnSubmit" runat="server" Text="搜索" onclick="btnSubmit_Click" /> 
                <a href="New.aspx">添加电子凭证</a>
         </td>
          
        </tr>
</table>    


<asp:GridView ID="gvData" runat="server" CssClass="gridView" 
        SkinID="userGridViewSkin" AutoGenerateColumns="False">
<Columns>
     
  
    <asp:TemplateField HeaderText="标题" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" ItemStyle-Width="400px">
        <ItemTemplate>
           <%# Eval("Title")%>
        </ItemTemplate>
    </asp:TemplateField>
   <asp:TemplateField HeaderText="消费者UIN" ItemStyle-Width="80px">
        <ItemTemplate>
           <%# Eval("BuyerUIN")%>
        </ItemTemplate>
    </asp:TemplateField>
     <asp:TemplateField HeaderText="消费者帐号" ItemStyle-Width="80px">
        <ItemTemplate>
           <%# Eval("BuyerLoginName")%>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="消费者昵称" ItemStyle-Width="120px">
        <ItemTemplate>
           <%# Eval("BuyerName")%>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="时间" HeaderStyle-CssClass="col_datetime" ItemStyle-CssClass="col_datetime" ItemStyle-Width="200px">
        <ItemTemplate>
           <%# Eval("CreateTime")%>
        </ItemTemplate>
    </asp:TemplateField>
    
    <asp:TemplateField HeaderText="查看" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option"> 
	<ItemTemplate>                    
                    
             <a href='View.aspx?id=<%#Eval("ID") %>'>查看明细</a> 
                                      
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




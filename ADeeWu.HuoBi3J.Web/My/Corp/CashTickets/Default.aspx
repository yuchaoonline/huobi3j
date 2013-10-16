<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.CashTickets.Default" %>
<%@ Register assembly="ADeeWu.HuoBi3J.WebUI" namespace="ADeeWu.HuoBi3J.WebUI" tagprefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
商家控制面板 - 现金券列表
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">　</span><span class="curPos">现金券列表</span>
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

<table class="searchTable">
    <tr>       
         <td class="key">
                序列号：
         </td>
         <td class="input">
            <asp:TextBox ID="txtName" runat="server" Width="120px" /> 
         </td>
         <td class="key">
            筛选：
         </td>
         <td class="input">
         <asp:DropDownList ID="ddlFilter" runat="server">
            <asp:ListItem Value="-1">全部</asp:ListItem>
            <asp:ListItem Value="0">没有使用的现金券</asp:ListItem>
            <asp:ListItem Value="1">已使用的现金券</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="btnSubmit" runat="server" Text="搜索" onclick="btnSubmit_Click" /> 
         </td>
        </tr>
</table>    


<asp:GridView ID="gvData" runat="server" CssClass="gridView" 
        SkinID="userGridViewSkin" AutoGenerateColumns="False">
<Columns>
     
     
    
    <asp:TemplateField HeaderText="现金券序列号" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title">
        <ItemTemplate>
           <%# Eval("SerialNum")%>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="金额" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title">
        <ItemTemplate>
           <%# Eval("Money")%>
        </ItemTemplate>
    </asp:TemplateField>
  
    <asp:TemplateField HeaderText="使用情况" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title">
        <ItemTemplate>
           <%# Eval("AppCheckState").ToString() == "1" ? 
               string.Format("<span>消费日期:{0}</span> <span>消费金额:{1:0.00}元</span>",Eval("AppCostDate","{0:yyyy年MM月dd日}"),Eval("Money"))
                          : 
                          "否"
                                     %>
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




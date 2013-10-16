<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.CashTickets.Default" %>
<%@ Register assembly="ADeeWu.HuoBi3J.WebUI" namespace="ADeeWu.HuoBi3J.WebUI" tagprefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
�̼ҿ������ - �ֽ�ȯ�б�
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">��</span><span class="curPos">�ֽ�ȯ�б�</span>
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

<table class="searchTable">
    <tr>       
         <td class="key">
                ���кţ�
         </td>
         <td class="input">
            <asp:TextBox ID="txtName" runat="server" Width="120px" /> 
         </td>
         <td class="key">
            ɸѡ��
         </td>
         <td class="input">
         <asp:DropDownList ID="ddlFilter" runat="server">
            <asp:ListItem Value="-1">ȫ��</asp:ListItem>
            <asp:ListItem Value="0">û��ʹ�õ��ֽ�ȯ</asp:ListItem>
            <asp:ListItem Value="1">��ʹ�õ��ֽ�ȯ</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="btnSubmit" runat="server" Text="����" onclick="btnSubmit_Click" /> 
         </td>
        </tr>
</table>    


<asp:GridView ID="gvData" runat="server" CssClass="gridView" 
        SkinID="userGridViewSkin" AutoGenerateColumns="False">
<Columns>
     
     
    
    <asp:TemplateField HeaderText="�ֽ�ȯ���к�" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title">
        <ItemTemplate>
           <%# Eval("SerialNum")%>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="���" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title">
        <ItemTemplate>
           <%# Eval("Money")%>
        </ItemTemplate>
    </asp:TemplateField>
  
    <asp:TemplateField HeaderText="ʹ�����" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title">
        <ItemTemplate>
           <%# Eval("AppCheckState").ToString() == "1" ? 
               string.Format("<span>��������:{0}</span> <span>���ѽ��:{1:0.00}Ԫ</span>",Eval("AppCostDate","{0:yyyy��MM��dd��}"),Eval("Money"))
                          : 
                          "��"
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




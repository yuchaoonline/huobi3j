<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="Add.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.WebIM.UINS.Add"  %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
Admin - WebIM - UINS - Add
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>ͨѶ�������</span> &gt; <a href="List.aspx"> �б� </a> &gt; ϵͳ����
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <div>
    <table border="0" cellspacing="0" cellpadding="0" class="formTable">
  <tr>
    <td class="tdLeft">ͨѶ������ʼ����:</td>
    <td class="tdRight"><asp:TextBox ID="txtStartNum" runat="server" CssClass="txtBox" ></asp:TextBox> <span class="require">
        * ͨѶ���뿪ʼ���ɵĺ���,��:����ֵ10000 </span>
        </td>
        </tr>
  <tr>
    <td class="tdLeft">��������:</td>
    <td class="tdRight"><asp:TextBox ID="txtNumLength" runat="server" CssClass="txtNum" ></asp:TextBox> <span class="require">*
        ͨѶ����������������:����50������10000��ʼ���ɵ�10050</span> </td>
  </tr>
   
  <tr style="display:none">
    <td class="tdLeft">Ĭ��״̬:</td><td><asp:DropDownList ID="ddlState" runat="server">
            <asp:ListItem Value="0">δʹ��</asp:ListItem>
            <asp:ListItem Value="1">��ʹ��</asp:ListItem>
        </asp:DropDownList>
         Ĭ��״ͨѶ����������������:����50������10000��ʼ���ɵ�10050
     </td>
  </tr>
  <tr>
    <td class="tdLeft">&nbsp;</td>
    <td class="tdRight">
     <asp:Button ID="btnSubmit" runat="server" Text="�ύ" onclick="btnSubmit_Click" />
    </td>        
  </tr>
</table>
<asp:GridView ID="gvData" runat="server" CssClass="dataGrid" SkinID="gridviewSkin" AutoGenerateColumns="false" ShowFooter="false" BorderStyle="None"  ShowHeader="true">
<Columns>
    <asp:TemplateField HeaderStyle-CssClass="col_id"  ItemStyle-CssClass="col_id" HeaderText="ID">
        <ItemTemplate>
            <input type="checkbox" name="<% = gvData.ClientID %>" value="<%#Eval("ID") %>" /> <%#Eval("ID")%>
        </ItemTemplate>    
    </asp:TemplateField>
    <asp:HyperLinkField HeaderText="�ֽ�ȯ���к�" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" DataNavigateUrlFields="id" DataNavigateUrlFormatString="Edit.aspx?id={0}" DataTextField="UIN" />
    <asp:BoundField HeaderText="����ʱ��" HeaderStyle-CssClass="col_datetime"  ItemStyle-CssClass="col_datetime" DataField="CreateTime" HtmlEncode="true" DataFormatString="{0:d}" />
    
</Columns>
</asp:GridView>
 </div>
</asp:Content>


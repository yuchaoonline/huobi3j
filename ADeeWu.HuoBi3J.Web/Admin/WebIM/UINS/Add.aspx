<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="Add.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.WebIM.UINS.Add"  %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
Admin - WebIM - UINS - Add
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>通讯号码管理</span> &gt; <a href="List.aspx"> 列表 </a> &gt; 系统生成
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <div>
    <table border="0" cellspacing="0" cellpadding="0" class="formTable">
  <tr>
    <td class="tdLeft">通讯号码起始号码:</td>
    <td class="tdRight"><asp:TextBox ID="txtStartNum" runat="server" CssClass="txtBox" ></asp:TextBox> <span class="require">
        * 通讯号码开始生成的号码,例:输入值10000 </span>
        </td>
        </tr>
  <tr>
    <td class="tdLeft">生成数量:</td>
    <td class="tdRight"><asp:TextBox ID="txtNumLength" runat="server" CssClass="txtNum" ></asp:TextBox> <span class="require">*
        通讯号码生成数量，例:输入50，将从10000开始生成到10050</span> </td>
  </tr>
   
  <tr style="display:none">
    <td class="tdLeft">默认状态:</td><td><asp:DropDownList ID="ddlState" runat="server">
            <asp:ListItem Value="0">未使用</asp:ListItem>
            <asp:ListItem Value="1">已使用</asp:ListItem>
        </asp:DropDownList>
         默认状通讯号码生成数量，例:输入50，将从10000开始生成到10050
     </td>
  </tr>
  <tr>
    <td class="tdLeft">&nbsp;</td>
    <td class="tdRight">
     <asp:Button ID="btnSubmit" runat="server" Text="提交" onclick="btnSubmit_Click" />
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
    <asp:HyperLinkField HeaderText="现金券序列号" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" DataNavigateUrlFields="id" DataNavigateUrlFormatString="Edit.aspx?id={0}" DataTextField="UIN" />
    <asp:BoundField HeaderText="生成时间" HeaderStyle-CssClass="col_datetime"  ItemStyle-CssClass="col_datetime" DataField="CreateTime" HtmlEncode="true" DataFormatString="{0:d}" />
    
</Columns>
</asp:GridView>
 </div>
</asp:Content>


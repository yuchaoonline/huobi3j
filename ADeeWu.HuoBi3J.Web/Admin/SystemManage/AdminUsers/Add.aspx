<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="Add.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.SystemManage.AdminUsers.Add"  %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
Admin - SystemManage - AdminUsers - Add
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<script src="../../../js/jquery.js" type="text/javascript"></script>
<script type="text/javascript">
function CancelCheckBox(jq)
{
   jq.get(0).checked = false;
}
</script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>��̨�ʺŹ���</span> &gt; <a href="List.aspx">�û��б�</a> &gt; ���
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

<table border="0" cellspacing="0" cellpadding="0" class="formTable">
  <tr>
    <td class="tdLeft">�ʺ�:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtLoginName" runat="server" CssClass="txtBox"></asp:TextBox>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">����:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtName" runat="server" CssClass="txtBox"></asp:TextBox>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">��ע:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine" CssClass="txtNotes"></asp:TextBox>
        <span class="tips">����д��ϵ��ʽ</span>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">������ɫ:</td>
    <td class="tdRight" align="left">
       <asp:CheckBoxList ID="checkBoxListRoles" RepeatDirection="Vertical" RepeatLayout="Flow" runat="server" RepeatColumns="8"></asp:CheckBoxList>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">����:</td>
    <td class="tdRight"><asp:TextBox ID="txtLoginPwd" runat="server" CssClass="txtBox" TextMode="Password"></asp:TextBox></td>
  </tr>
  <tr>
    <td class="tdLeft">����ȷ��:</td>
    <td class="tdRight"><asp:TextBox ID="txtLoginPwd2" runat="server" CssClass="txtBox" TextMode="Password"></asp:TextBox></td>
  </tr>
</table>

<br />
����Ȩ������,�û�Ȩ�����ý��Ḳ�������Ľ�ɫ��ӵ�е�Ȩ��:
<asp:GridView ID="gvData" runat="server" CssClass="dataGrid" SkinID="gridviewSkin" AutoGenerateColumns="false" ShowFooter="false" BorderStyle="None"  ShowHeader="true">
<Columns>
    <asp:TemplateField HeaderStyle-CssClass="col_id"  ItemStyle-CssClass="col_id" HeaderText="ID">
        <ItemTemplate>
            <!-- <input type="checkbox" name="id" value="<%#Eval("ID") %>" />--> <%#Eval("ID") %>
        </ItemTemplate>    
    </asp:TemplateField>
    
    <asp:BoundField HeaderText="ҳ������" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" DataField="PageName" />
    <asp:BoundField HeaderText="����" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" DataField="Description"  />
    <asp:BoundField HeaderText="URL" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" DataField="URL"  />
    <asp:TemplateField HeaderStyle-CssClass="col_option"  ItemStyle-CssClass="col_option" HeaderText="����">
        <ItemTemplate>
            <input type="checkbox" name="alowPageID" value="<%#Eval("ID") %>" onclick="CancelCheckBox($(this).next('[@type=checkbox]'));"/>���� <input type="checkbox" name="denyPageID" value="<%#Eval("ID") %>" onclick="CancelCheckBox($(this).prev('[@type=checkbox]'));" />�ܾ�
        </ItemTemplate>    
    </asp:TemplateField>
</Columns>
</asp:GridView>

<table width="100%" class="dataGrid_Footer">
    <tr>
        
        <td class="pagerBox">
            <asp:Button ID="btnSubmit" runat="server" Text="�ύ" OnClick="btnSubmit_OnClick" />
        </td>
        <td class="options">
           <a href="#" onclick="setCheckGroup('alowPageID',true); setCheckGroup('denyPageID',false);  return false;">ȫѡ����</a> | <a href="#" onclick="setCheckGroup('denyPageID',false); setCheckGroup('alowPageID',false);return false;">ȡ������</a>
        </td>
    </tr>
</table>


</asp:Content>


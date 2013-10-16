<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Edit.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.CorpAgentManage.Users.Edit" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
�̼ҿ������ - �޸��̼Ҵ�����Ϣ
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    function setChangePwd(toggle) {
        if (true) {
            $('#hrefCancel').show(); 
            $('#hrefChange').hide();
            $('#divChangePwd').show();
            $('#<%=chkChangePwd.ClientID %>').get(0).checked = true; 
        } else {
            $('#hrefCancel').hide();
            $('#hrefChange').show();
            $('#divChangePwd').hide();
            $('#<%=chkChangePwd.ClientID %>').get(0).checked = false; 
        }
    }
</script>
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">��</span><a href="/My/Corp/CorpAgentManage/Users/">�̼Ҵ������</a><span class="spl">��</span><span class="curPos">�޸�</span>   
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

<table border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td class="tdLeft">��ɫ���䣺</td>
    <td class="tdRight">
        <asp:DropDownList ID="ddlRoles" runat="server">
        </asp:DropDownList>
    </td>
  </tr>
   <tr>
    <td class="tdLeft">���������</td>
    <td class="tdRight">
        <IscControl:SyncSelector ID="syncSelectorLocation" runat="server" 
        DataSourceURL="<%$Resources:SyncSelector,Location_DataSourceURL %>" 
        DataSourceName="<%$Resources:SyncSelector,Location_DataSourceName %>" 
        ClientPostNames="<%$Resources:SyncSelector,Location_ClientPostNames %>"
        /> <span class="tips">��ָ�����ʺ�����Ͻ�ĵ���</span>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">ͨѶ���룺</td>
    <td class="tdRight">
		<asp:Literal ID="liteUIN" runat="server"></asp:Literal>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">��&nbsp;&nbsp;&nbsp;&nbsp;�ţ�</td>
    <td class="tdRight">
        <asp:TextBox ID="txtLoginName" runat="server"></asp:TextBox><asp:Literal ID="liteLoginName" runat="server"></asp:Literal>
 	</td>
  </tr>
  <tr>
    <td class="tdLeft">Email��</td>
    <td class="tdRight">
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><asp:Literal ID="liteEmail" runat="server"></asp:Literal>
        <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="����д��ȷ��Email��ַ"></asp:RegularExpressionValidator>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">��&nbsp;&nbsp;&nbsp;&nbsp;�룺</td>
    <td class="tdRight">
            <span style="display:none">
                <asp:CheckBox ID="chkChangePwd" runat="server" />
            </span>
            [ <a href="javascript:setChangePwd(true); void(0);" id="hrefChange">�޸�</a> 
            <a href="javascript:setChangePwd(false); void(0);" style="display:none;" id="hrefCancel">ȡ��</a> ]
            <div id="divChangePwd" style="display:none;">
            <asp:TextBox ID="txtLoginPwd" runat="server" TextMode="Password"></asp:TextBox><span class="require">*</span><span class="tips">������������!</span><br />
            <asp:TextBox ID="txtLoginPwd2" runat="server" TextMode="Password"></asp:TextBox><span class="require">*</span><span class="tips">��������������!</span>
            </div>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">��&nbsp;&nbsp;&nbsp;&nbsp;����</td>
    <td class="tdRight">
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
  </tr>
  <tr>
    <td class="tdLeft">Tel��</td>
    <td class="tdRight">
        <asp:TextBox ID="txtTel" runat="server"></asp:TextBox>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">���״̬��</td>
    <td class="tdRight">
        <asp:DropDownList ID="ddlCheckState" runat="server">
            <asp:ListItem Value="0">�����</asp:ListItem>
            <asp:ListItem Value="1">ͨ�����</asp:ListItem>
            <asp:ListItem Value="2">��Ч</asp:ListItem>
            <asp:ListItem Value="3">����</asp:ListItem>
        </asp:DropDownList>
    </td>
  </tr>
  <tr>
    <td class="tdLeft"></td>
    <td class="tdRight">
        <asp:Button ID="btnSubmit" runat="server" Text="�ύ" onclick="btnSubmit_Click" />
    </td>
  </tr>
  </table>


</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>




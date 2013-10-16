<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="New.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.CorpAgentManage.Users.New" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
�̼ҿ������ - ����̼Ҵ����ʺ�
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
	function UINSelector_OnLoad(o)
	{
	    o.onSelected = function(keyValue) {
	        alert(keyValue.uin);
	        document.getElementById("<%=this.txtUIN.ClientID %>").value = keyValue.uin;
	    };
	}
</script>
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">��</span><a href="/My/Corp/CorpAgentManage/Users/">�̼Ҵ������</a><span class="spl">��</span><span class="curPos">ע���ʺ�</span>   
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
<span style="display:none;"><asp:TextBox ID="txtUIN" runat="server"></asp:TextBox></span>

<div class="tips" align="center">
��ע���û���ʹ��ͨѶ���롢�ʺŻ�Email��½ϵͳ
</div>
<div align="center">
<strong>ע:��<span class="require">*</span> ��ʾ������</strong>
</div>

    
<table border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td class="tdLeft">ѡ��ͨѶ���룺</td>
    <td class="tdRight">
        <asp:RadioButton ID="radAuto" runat="server"  Text="ϵͳ�Զ�����" GroupName="number" Checked="true" onclick="javascript:$('#iframeSelectUIN').hide();"/>
        <asp:RadioButton ID="radSelMySelf" runat="server"  Text="���Լ�ѡ����"  GroupName="number"  onclick="javascript:$('#iframeSelectUIN').show().attr('src','/selectUIN.aspx');"/>
		<span class="require">*</span>
		<div>
			 <iframe src="" width="100%" height="200px" frameborder="0" scrolling="no" id="iframeSelectUIN" style="display:none;"></iframe>
		</div>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">��&nbsp;&nbsp;&nbsp;&nbsp;�ţ�</td>
    <td class="tdRight">
        <asp:TextBox ID="txtLoginName" runat="server"></asp:TextBox>
		<span class="tips">�ʺ��ɴ�Сд��ĸ�����ֻ��»�����ɣ����Ȳ�������6���ַ������Ҳ��ܴ���12���ַ�</span>
		<br />
		ע��:�ʺŲ���ȫ������		
 	</td>
  </tr>
  <tr>
    <td class="tdLeft">Email��</td>
    <td class="tdRight">
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="����д��ȷ��Email��ַ"></asp:RegularExpressionValidator><span class="tips">��������ʱ����ϵͳ�����µ����뵽ָ���������ȡ������</span>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">��&nbsp;&nbsp;&nbsp;&nbsp;�룺</td>
    <td class="tdRight"><asp:TextBox ID="txtLoginPwd" runat="server" TextMode="Password"></asp:TextBox><span class="require">*</span></td>
    </tr>
  <tr>
    <td class="tdLeft">����ȷ�ϣ�</td>
    <td class="tdRight"><asp:TextBox ID="txtLoginPwd2" runat="server" TextMode="Password"></asp:TextBox><span class="require">*</span></td>
  </tr>
  <tr>
    <td class="tdLeft">��&nbsp;&nbsp;&nbsp;&nbsp;����</td>
    <td class="tdRight">
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
  </tr>
  <tr>
    <td class="tdLeft">Tel��</td>
    <td class="tdRight">
        <asp:TextBox ID="txtTel" runat="server"></asp:TextBox><span class="tips">��д������ϵ�绰�ɷ������Ǽ�ʱΪ������</span>
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
    <td class="tdLeft"></td>
    <td class="tdRight">
        <asp:Button ID="btnSubmit" runat="server" Text="�ύ" onclick="btnSubmit_Click" />
    </td>
  </tr>
  </table>



</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>




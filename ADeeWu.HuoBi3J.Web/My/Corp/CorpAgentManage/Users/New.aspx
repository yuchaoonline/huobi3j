<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="New.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.CorpAgentManage.Users.New" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
商家控制面板 - 添加商家代表帐号
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
<span class="spl">　</span><a href="/My/Corp/CorpAgentManage/Users/">商家代表管理</a><span class="spl">　</span><span class="curPos">注册帐号</span>   
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
<span style="display:none;"><asp:TextBox ID="txtUIN" runat="server"></asp:TextBox></span>

<div class="tips" align="center">
新注册用户可使用通讯号码、帐号或Email登陆系统
</div>
<div align="center">
<strong>注:带<span class="require">*</span> 表示必填项</strong>
</div>

    
<table border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td class="tdLeft">选择通讯号码：</td>
    <td class="tdRight">
        <asp:RadioButton ID="radAuto" runat="server"  Text="系统自动分配" GroupName="number" Checked="true" onclick="javascript:$('#iframeSelectUIN').hide();"/>
        <asp:RadioButton ID="radSelMySelf" runat="server"  Text="我自己选号码"  GroupName="number"  onclick="javascript:$('#iframeSelectUIN').show().attr('src','/selectUIN.aspx');"/>
		<span class="require">*</span>
		<div>
			 <iframe src="" width="100%" height="200px" frameborder="0" scrolling="no" id="iframeSelectUIN" style="display:none;"></iframe>
		</div>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">帐&nbsp;&nbsp;&nbsp;&nbsp;号：</td>
    <td class="tdRight">
        <asp:TextBox ID="txtLoginName" runat="server"></asp:TextBox>
		<span class="tips">帐号由大小写字母、数字或下划线组成，长度不能少于6个字符长度且不能大于12个字符</span>
		<br />
		注意:帐号不能全是数字		
 	</td>
  </tr>
  <tr>
    <td class="tdLeft">Email：</td>
    <td class="tdRight">
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="请填写正确的Email地址"></asp:RegularExpressionValidator><span class="tips">忘记密码时可由系统发送新的密码到指定的邮箱而取回密码</span>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">密&nbsp;&nbsp;&nbsp;&nbsp;码：</td>
    <td class="tdRight"><asp:TextBox ID="txtLoginPwd" runat="server" TextMode="Password"></asp:TextBox><span class="require">*</span></td>
    </tr>
  <tr>
    <td class="tdLeft">密码确认：</td>
    <td class="tdRight"><asp:TextBox ID="txtLoginPwd2" runat="server" TextMode="Password"></asp:TextBox><span class="require">*</span></td>
  </tr>
  <tr>
    <td class="tdLeft">姓&nbsp;&nbsp;&nbsp;&nbsp;名：</td>
    <td class="tdRight">
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
  </tr>
  <tr>
    <td class="tdLeft">Tel：</td>
    <td class="tdRight">
        <asp:TextBox ID="txtTel" runat="server"></asp:TextBox><span class="tips">填写您的联系电话可方便我们及时为您服务</span>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">代理地区：</td>
    <td class="tdRight">
        <IscControl:SyncSelector ID="syncSelectorLocation" runat="server" 
        DataSourceURL="<%$Resources:SyncSelector,Location_DataSourceURL %>" 
        DataSourceName="<%$Resources:SyncSelector,Location_DataSourceName %>" 
        ClientPostNames="<%$Resources:SyncSelector,Location_ClientPostNames %>"
        /> <span class="tips">请指定该帐号所管辖的地区</span>
    </td>
  </tr>
  
  <tr>
    <td class="tdLeft"></td>
    <td class="tdRight">
        <asp:Button ID="btnSubmit" runat="server" Text="提交" onclick="btnSubmit_Click" />
    </td>
  </tr>
  </table>



</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>




<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>登陆 -- Power by Email:sam65718@hotmail.com</title>
	<style type="text/css">
		
	.formTable{ border-collapse:collapse; }
	.formTable td{ border:1px solid #ccc; }
	
	</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
	  <table width="100%" height="600" border="0" cellpadding="0" cellspacing="0">
        <tr>
          <td align="center" valign="middle">
		  
		  <table width="500" border="0" cellpadding="5" cellspacing="0" class="formTable">
            <tr>
              <td height="40" colspan="2" ><strong>用户登陆</strong></td>
            </tr>
            <tr>
              <td width="83" align="left" valign="middle">帐号:</td>
              <td width="417" align="left" valign="middle">
                  <asp:TextBox ID="txtLoginName" runat="server" Text="admin"></asp:TextBox>
                                </td>
            </tr>
            <tr>
              <td align="left" valign="middle">密码:</td>
              <td align="left" valign="middle">
                  <asp:TextBox ID="txtPwd" runat="server" TextMode="Password">888888</asp:TextBox>
                                </td>
            </tr>
            <tr>
              <td align="left" valign="middle">验证码:</td>
              <td align="left" valign="middle">
                  <asp:TextBox ID="txtValidCode" runat="server" Width="53px"></asp:TextBox> <img src="../ValidateCode.aspx" />
              </td>
            </tr>
            <tr>
              <td align="left" valign="middle">&nbsp;</td>
              <td align="left" valign="middle">
                  <asp:Button ID="btnSubmit" runat="server" Text="登陆" onclick="btnSubmit_Click" />
                </td>
            </tr>
          </table>
		  
		  </td>
        </tr>
      </table>
    </div>
    </form>
</body>
</html>

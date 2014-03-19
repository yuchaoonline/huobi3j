<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserControlPanel.ascx.cs"
    Inherits="ADeeWu.HuoBi3J.Web.Controls.UserControlPanel" %>
<%
    ADeeWu.HuoBi3J.Web.Class.UserSession loginSession = ADeeWu.HuoBi3J.Web.Class.UserSession.GetSession();
%>

<div style="float: right;">
    <div style="height: 44px; line-height: 44px; text-align: center;">
        <a href="/">首页</a>
        <%if (loginSession == null)
          { %>
        <a href="/Login.aspx">会员登陆</a>/<a href="/Register.aspx">注册</a>
        <%}
          else 
          {  %>
        <%=ADeeWu.HuoBi3J.Libary.Utility.GetStr(loginSession.Email, loginSession.LoginName, loginSession.UIN, true)%>,您好!
        <a href="/My/User/">我的后台</a>
        <a href="/Logout.aspx">退出</a>
        <%} %>
    </div>
</div>

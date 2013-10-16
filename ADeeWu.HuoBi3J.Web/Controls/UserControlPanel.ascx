<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserControlPanel.ascx.cs"
    Inherits="ADeeWu.HuoBi3J.Web.Controls.UserControlPanel" %>
<%
        ADeeWu.HuoBi3J.Web.Class.UserSession loginSession = ADeeWu.HuoBi3J.Web.Class.UserSession.GetSession();
%>
<script type="text/javascript" src="/JS/jquery.timers-1.2.js"></script>
<%if (loginSession != null)
  {%>
<script type="text/javascript">
    $(function () {
        var count = 1;
        GetAttentionCount();
        $('body').everyTime('30s', 'AttentionCount', function () {
            GetAttentionCount();
        });

        function GetAttentionCount() {
            $.ajaxSetup({ cache: false });
            $.getJSON('/ajax/center.ashx?t='+new Date().toTimeString(), { method: 'getattentioncount' }, function (data) {
                if (data.statue) {
                    $('#attentionCount').html('<span style="color: red;">(' + data.count + ')</span>');

                    if (data.issaleman) {
                        $('#attentionCount').attr('href', '/My/User/Center/MyAnswerList.aspx');
                        $('#salemanAttentionCount').html('<span style="color: red;">(' + data.count + ')</span>');
                    }
                    else {
                        $('#attentionCount').attr('href', '/My/User/Center/MyQuestionList.aspx');
                        $('#questionAttentionCount').html('<span style="color: red;">(' + data.count + ')</span>');
                    }
                } else {
                    $('#questionAttentionCount').html('<span style="color: red;"></span>');
                    $('#salemanAttentionCount').html('<span style="color: red;"></span>');
                }
            })
        }
    })
</script>
<%}%>

<span class="UserControlPanel">
    <%if (loginSession == null)
      { %>
    <a href="/">首页</a> <a href="/Login.aspx">会员登陆</a>/<a href="/Register.aspx">注册</a>
    <%--<img src="/images/Cart.gif" /><a href="/Shop/Carts/">购物车</a>--%>
    <%}
      else if ((loginSession as ADeeWu.HuoBi3J.Web.Class.CorpSession) != null && (loginSession as ADeeWu.HuoBi3J.Web.Class.CorpSession).CorpCheckState == ADeeWu.HuoBi3J.Web.Class.UserSessionCheckState.Audited)
      {  %>
    <%=ADeeWu.HuoBi3J.Libary.Utility.GetStr(loginSession.Email, loginSession.LoginName, loginSession.UIN, true)%>,您好!
    <a id="attentionCount" href="#"></a>
    <a href="/">首页</a> <a href="/My/Corp/">我的后台</a>
    <%--<img src="/images/Cart.gif" /><a href="/Shop/Carts/">购物车</a>--%>
    <a href="/Logout.aspx">退出</a>
    <%}
      else
      {  %>
    <%=ADeeWu.HuoBi3J.Libary.Utility.GetStr(loginSession.Email, loginSession.LoginName, loginSession.UIN, true)%>,您好!
    <a id="attentionCount" href="#"></a>
    <a href="/">首页</a> <a href="/My/User/">我的后台</a>
    <%--<img src="/images/Cart.gif" /><a href="/Shop/Carts/">购物车</a>--%>
    <%--<a href="/My/User/GroupBuy/" style="color: red;" title="我的订单">我的订单</a>--%>
    <a href="/Logout.aspx">退出</a>
    <%} %>
</span>
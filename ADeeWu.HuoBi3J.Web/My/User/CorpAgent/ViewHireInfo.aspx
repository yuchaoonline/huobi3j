<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="ViewHireInfo.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.CorpAgent.ViewHireInfo" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="ADeeWuControls" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    个人控制面板 - 查看营销商招聘信息
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="/JS/webim/load.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <span class="spl"></span><a href="/My/User/CorpAgent/SearchHireInfo.aspx">搜索营销商家</a><span class="spl">　</span><span class="curPos">查看营销商招聘信息</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

    <div class="data-Title">
        <%=this.drData["Title"]%>
    </div>
    <div class="data-Sub">
        <%=this.drData["CorpName"]%> | 浏览:<%=this.drData["VisitCount"]%>次 | 发布时间:<%=this.drData["CreateTime"]%> | <a href="javascript:void(0);" webim="true" uin="<%=this.drData["UIN"] %>" nickname="<%=HttpUtility.HtmlAttributeEncode(this.drData["IM_NickName"].ToString()) %>" signtext="<%=HttpUtility.HtmlAttributeEncode(this.drData["IM_SignText"].ToString()) %>" usericon="<%=HttpUtility.HtmlAttributeEncode(this.drData["IM_HeadPic"].ToString()) %>">
            <img src="<%= ADeeWu.HuoBi3J.Web.GlobalParameter.GetWebIMStateURL( this.drData["UIN"].ToString() )%>" border="0" /></a>
    </div>

    <div class="data-Content">
        <%=this.drData["Content"]%>
    </div>




</asp:Content>

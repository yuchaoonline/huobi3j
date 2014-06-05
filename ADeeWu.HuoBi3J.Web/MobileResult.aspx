<%@ Page Title="" Language="C#" MasterPageFile="~/MMobileIndex.Master" AutoEventWireup="true" CodeBehind="MobileResult.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.MobileResult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <div class="list-group">
        <a href="#" class="list-group-item active">提示信息</a>
        <a href="#" class="list-group-item">
            <div class="alert alert-info"><%=HttpUtility.UrlDecode(Request["msg"]) %></div>
        </a>
    </div>

    <button type="button" id="btnConfirm" class="btn btn-primary btn-block btn-lg">确认</button>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="script" runat="server">
    <script type="text/javascript">
        $(function () {
                $('#btnConfirm').click(function () {
                    location.href = '<%=HttpUtility.UrlDecode(Request["url"])%>';
                    return false;
                })
            })
        </script>
</asp:Content>

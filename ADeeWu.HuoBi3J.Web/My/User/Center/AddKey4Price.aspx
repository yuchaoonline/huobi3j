<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="AddKey4Price.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Center.AddKey4Price" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    货比三家 - 添加价格
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="/CSS/forum_common.css" rel="stylesheet" type="text/css" />
    <link href="/CSS/forum_forumdisplay.css" rel="stylesheet" type="text/css" />
    <link href="/CSS/base.css" rel="stylesheet" />
    <script src="/ueditor/ueditor.config.js" type="text/javascript"></script>
    <script src="/ueditor/ueditor.all.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $('.arc_title img').ReduceImage();

            var editor = UE.getEditor('editor');
            $('#btnSubmit').click(function () {
                var selecttype = $('#ddlType');
                var selectprice = $('#ddlPrice');
                var selectsize = $('#ddlSize');

                if (!selecttype.val()) {
                    alert('请选择类型!');
                    return false;
                }
                if (!selectprice.val()) {
                    alert('请选择价格!');
                    return false;
                }
                if (!confirm($('#alertmsg').text())) return false;
                $.post(location.href, {
                    method: 'post',
                    selecttype: selecttype.find("option:selected").text(),
                    selectprice: selectprice.find("option:selected").text(),
                    selectsize: selectsize.find("option:selected").text(),
                    selecttypeid: selecttype.val(),
                    selectpriceid: selectprice.val(),
                    selectsizeid: selectsize.val(),
                }, function (data) {
                    var result = JSON.parse(data);
                    if (result.statue) {
                        alert('添加成功！');
                        location.href = "prices.aspx";
                        return false;
                    } else {
                        alert(result.msg);
                        return false;
                    }
                })
                return false;
            })
        })
    </script>
    <style type="text/css">
        .dline a {
            text-decoration: underline;
        }
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="siteposition" runat="server">
    货比三家 - 添加价格
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
    <span id="alertmsg" style="display: none;"><asp:Literal ID="litmsg" runat="server"></asp:Literal></span>
    <table class="formTable">
        <tr>
            <td class="tdLeft">简单描述：
            </td>
            <td class="tdRight" style="width: 650px">
                <asp:Literal ID="litTitle" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">价格：
            </td>
            <td class="tdRight" style="width: 650px">
                <asp:Literal ID="litPrice" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">关键字：
            </td>
            <td class="tdRight" style="width: 650px">
                <asp:Literal ID="litKey" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">属性：
            </td>
            <td class="tdRight" style="width: 650px">
                类型：<asp:DropDownList ID="ddlType" runat="server" ClientIDMode="Static"></asp:DropDownList>
                价格：<asp:DropDownList ID="ddlPrice" runat="server" ClientIDMode="Static"></asp:DropDownList>
                其他：<asp:DropDownList ID="ddlSize" runat="server" ClientIDMode="Static"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="tdLeft"></td>
            <td class="tdRight">
                <input type="button" value="绑定" class="btn_blue" id="btnSubmit" />
            </td>
        </tr>
    </table>
</asp:Content>

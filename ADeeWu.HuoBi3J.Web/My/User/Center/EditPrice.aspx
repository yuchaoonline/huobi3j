<%@ Page Title="" Language="C#" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="EditPrice.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Center.EditPrice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
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
                var price = $('input[name="txtPrice"]');
                var simpledesc = $('input[name=txtSimple]');
                var oldsimpledesc = $('input[name=txtOldSimple]');
                var tags = $('input[name=tags]');
                var content = editor.getContent();

                if (!price.val()) {
                    alert('价格不能为空！');
                    return false;
                }
                if (!simpledesc.val()) {
                    alert('简单描述不能为空！');
                    return false;
                }
                if (simpledesc.val().length > 30) {
                    alert('简单描述长度不能超过10！');
                    return false;
                }

                if (!editor.hasContents()) {
                    alert('提问内容不能为空！');
                    return false;
                }

                $.post(location.href, {
                    method: 'post',
                    price: price.val(),
                    simpledesc: simpledesc.val(),
                    oldsimpledesc: oldsimpledesc.val(),
                    tags: tags.val(),
                    description: content,
                }, function (data) {
                    var result = JSON.parse(data);
                    if (result.statue) {
                        alert('修改成功！');
                        location.href = location.href;
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
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    货比三家 - 编辑价格
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <table class="formTable">
        <tr>
            <td class="tdLeft">价格：
            </td>
            <td class="tdRight" style="width: 650px">
                <input type="text" name="txtPrice" value="<%= product.Price %>" />
            </td>
        </tr>
        <tr>
            <td class="tdLeft">简单描述：
            </td>
            <td class="tdRight">
                <input type="text" name="txtSimple"  value="<%= product.title %>"/>（30字以内）
                <input type="hidden" name="txtOldSimple"  value="<%= product.title %>"/>
                <input type="hidden" name="txtTags"  value="<%= product.tags %>"/>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">详情描述：
            </td>
            <td class="tdRight">
                <script type="text/plain" id="editor" name="txtDesc" style="width: 650px; height: 200px"> <%= HttpUtility.HtmlDecode(product.Description) %></script>
            </td>
        </tr>
        <tr>
            <td class="tdLeft"></td>
            <td class="tdRight">
                <input type="button" value="添加" class="btn_blue" id="btnSubmit" />
            </td>
        </tr>
    </table>
</asp:Content>

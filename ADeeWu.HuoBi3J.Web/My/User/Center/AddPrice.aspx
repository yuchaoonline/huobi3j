<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="AddPrice.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Center.AddPrice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    �������� - ��Ӽ۸�
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="/CSS/forum_common.css" rel="stylesheet" type="text/css" />
    <link href="/CSS/forum_forumdisplay.css" rel="stylesheet" type="text/css" />
    <link href="/CSS/base.css" rel="stylesheet" />
    <script src="/ueditor/ueditor.config.js" type="text/javascript"></script>
    <script src="/ueditor/ueditor.all.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            var editor = UE.getEditor('editor');
            $('#btnSubmit').click(function () {
                var price = $('input[name="txtPrice"]');
                var simpledesc = $('input[name=txtSimple]');
                var content = editor.getContent();

                if (!price.val()) {
                    alert('�۸���Ϊ�գ�');
                    return false;
                }
                if (!simpledesc.val()) {
                    alert('����������Ϊ�գ�');
                    return false;
                }
                if (simpledesc.val().length > 30) {
                    alert('���������Ȳ��ܳ���10��');
                    return false;
                }
                                
                if (!editor.hasContents()) {
                    alert('�������ݲ���Ϊ�գ�');
                    return false;
                }

                $.post(location.href, {
                    method: 'post',
                    price: price.val(),
                    simpledesc: simpledesc.val(),
                    description: content
                }, function (data) {
                    var result = JSON.parse(data);
                    if (result.statue) {
                        alert('��ӳɹ���');
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
    �������� - ��Ӽ۸�
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
    <table class="formTable">
        <tr>
            <td class="tdLeft">�۸�
            </td>
            <td class="tdRight" style="width: 650px">
                <input type="text" name="txtPrice" />
            </td>
        </tr>
        <tr>
            <td class="tdLeft">��������
            </td>
            <td class="tdRight">
                <input type="text" name="txtSimple" />��30�����ڣ�
            </td>
        </tr>
        <tr>
            <td class="tdLeft">����������
            </td>
            <td class="tdRight">
                <script type="text/plain" id="editor" name="txtDesc" style="width: 650px; height: 200px"></script>
            </td>
        </tr>
        <tr>
            <td class="tdLeft"></td>
            <td class="tdRight">
                <input type="button" value="���" class="btn_blue" id="btnSubmit" />
            </td>
        </tr>
    </table>
</asp:Content>

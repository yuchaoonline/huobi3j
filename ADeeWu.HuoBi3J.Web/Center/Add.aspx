<%@ Page Language="C#" Title="" MasterPageFile="~/MIndex.master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Center.Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    货比三家 - 添加
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="/CSS/forum_common.css" rel="stylesheet" type="text/css" />
    <link href="/CSS/forum_forumdisplay.css" rel="stylesheet" type="text/css" />
    <link href="/CSS/base.css" rel="stylesheet" />
    <script type="text/javascript" src="/js/jquery.watermark.js"></script>
    <script type="text/javascript" src="/js/user.js"></script>
    <script type="text/javascript">
        $(function () {
            $('[name=KName]').watermark('输入关键字');

            $('#btnSubmit').click(function () {
                var kName = $('input[name=KName]').val();
                if (kName == '') {
                    alert("关键字不能为空！");
                    return false;
                }

                $.getJSON('/ajax/center.ashx', { method: 'AddKey', name: kName }, function (data) {
                    if (data.statue) {
                        alert("添加成功！");
                        location.href = '/center/add.aspx';
                    } else {
                        if (data.msg)
                            alert(data.msg);
                        else
                            alert("提交错误，请重试！");
                    }
                })

                return false;
            })
        })
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
    <div id="filter">
        <div class="filter-sortbar-outer-box">
            <div class="filter-section-wrapper">
                <div class="filter-label-list filter-section category-filter-wrapper  first-filter">
                    <div class="label has-icon"><i></i>关键字：</div>
                    <ul class="inline-block-list attr-type">
                        <li>
                            <input type="text" name="KName" value="<%=Request["kname"] %>" />
                            <input type="button" id="btnSubmit" value="添加" class="btn_blue" /></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

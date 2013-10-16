<%@ Page Language="C#" Title="" MasterPageFile="~/MIndex.master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="Key4Add.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Center.Key4Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    全民广告 - 添加价格
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="/CSS/forum_common.css" rel="stylesheet" type="text/css" />
    <link href="/CSS/forum_forumdisplay.css" rel="stylesheet" type="text/css" />
    <link href="../GroupBuy/base.css" rel="stylesheet" />
    <script src="/kindeditor/kindeditor.js" type="text/javascript"></script>
    <script type="text/javascript">
        KE.show({
            id: 'txtDesc',
            imageUploadJson: '/kindeditor/upload_json.ashx',
            fileManagerJson: '/kindeditor/file_manager_json.ashx',
            resizeMode: 1,
            allowPreviewEmoticons: true,
            allowUpload: true,
            items: ['fontname', 'fontsize', '|', 'textcolor', 'bgcolor', 'bold', 'italic', 'underline', 'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist', 'insertunorderedlist', '|', 'emoticons', 'image', 'link']
        });


        $(function () {
            $('.arc_title img').ReduceImage();

            $('.selectType,.selectSize,.selectPrice').click(function () {
                var $this = $(this);
                if ($this.hasClass('selectType')) {
                    $('.select-type').html('类型：'+$this.html());
                }
                if ($this.hasClass('selectSize')) {
                    $('.select-size').html('尺寸：'+$this.html());
                }
                if ($this.hasClass('selectPrice')) {
                    $('.select-price').html('价格：'+$this.html());
                }

                return false;
            })

            $('#btnSubmit').click(function () {
                var selecttype = $('.select-type');
                var selectprice = $('.select-price');
                var selectsize = $('.select-size');
                var price = $('input[name="txtPrice"]');
                var simpledesc = $('input[name=txtSimple]');
                var content = KE.html('txtDesc');

                if (!selecttype.html()) {
                    alert('请选择类型!');
                    return false;
                }
                if (!selectsize.html()) {
                    alert('请选择尺寸!');
                    return false;
                }
                if (!selectprice.html()) {
                    alert('请选择价格!');
                    return false;
                }
                var selectValue = selecttype.html() + ';' + selectsize.html() + ';' + selectprice.html();
                if (!price.val()) {
                    alert('价格不能为空！');
                    return false;
                }
                if (!simpledesc.val()) {
                    alert('简单描述不能为空！');
                    return false;
                }
                if (simpledesc.val().length > 10) {
                    alert('简单描述长度不能超过10！');
                    return false;
                }
                                
                if (KE.isEmpty('txtDesc')) {
                    alert('提问内容不能为空！');
                    return false;
                }

                $.post(location.href, { method: 'post', selectattribute: selectValue, price: price.val(), simpledesc: simpledesc.val(), description: content }, function (data) {
                    var result = JSON.parse(data);
                    if (result.statue) {
                        alert('添加成功！');
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
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
    <div id="center_list">
        <div class="centerP_body">
            <asp:Repeater ID="rpKey" runat="server">
                <ItemTemplate>
                    <div class="body_content font14 black70">
                        <p>
                            <span>关键字名称：<label class="fb black32 "><%# Eval("KName") %></label></span></p>
                        <p class="mt10">
                            <span>所属商圈：
                                <label class="black32 dline"><%# ADeeWu.HuoBi3J.Web.Class.Helper.GetBusinessCircle(Eval("bid"),Eval("bname")) %></label>
                            </span>
                            <span class="gjbj1">所属地区：<label class="black32"><%# ADeeWu.HuoBi3J.Web.Class.Helper.GetLocation(Eval("aid"),Eval("aname"),Eval("cid"),Eval("cname"),Eval("pid"),Eval("pname")," - ") %></label></span></p>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>

    <div id="filter">
        <div class="filter-sortbar-outer-box">
            <div class="filter-section-wrapper">
                <div class="filter-label-list filter-section category-filter-wrapper first-filter">
                    <div class="label has-icon"><i></i>类型：</div>
                    <ul class="inline-block-list">
                        <asp:Literal runat="server" ID="litType"></asp:Literal>
                    </ul>
                </div>
                <div class="filter-label-list filter-section category-filter-wrapper">
                    <div class="label has-icon"><i></i>尺寸：</div>
                    <ul class="inline-block-list">
                        <asp:Literal runat="server" ID="litSize"></asp:Literal>
                    </ul>
                </div>
                <div class="filter-label-list filter-section category-filter-wrapper">
                    <div class="label has-icon"><i></i>价格：</div>
                    <ul class="inline-block-list">
                        <asp:Literal runat="server" ID="litPrice"></asp:Literal>
                    </ul>
                </div>
                <div class="filter-label-list filter-section category-filter-wrapper">
                    <div class="label has-icon"><i></i>选择：</div>
                    <ul class="inline-block-list">
                        <li class="item"><span class="select-type"></span></li>
                        <li class="item"><span class="select-size"></span></li>
                        <li class="item"><span class="select-price"></span></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>

    <div class="cl"></div>

    <table class="formTable">
        <tr>
            <td class="tdLeft">价格：
            </td>
            <td class="tdRight" style="width: 853px">
                <input type="text" name="txtPrice" />
            </td>
        </tr>
        <tr>
            <td class="tdLeft">商品简单描述：
            </td>
            <td class="tdRight">
                <input type="text" name="txtSimple" />（10字以内）
            </td>
        </tr>
        <tr>
            <td class="tdLeft">商品详情描述：
            </td>
            <td class="tdRight">
                <%--<asp:TextBox ID="txtDesc" runat="server"></asp:TextBox>--%>
                <textarea cols="100" rows="8" name="txtDesc" id="txtDesc" style="width: 800px; height: 34px;visibility:hidden;"></textarea>
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

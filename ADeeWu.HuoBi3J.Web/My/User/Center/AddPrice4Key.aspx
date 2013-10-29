<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="AddPrice4Key.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Center.AddPrice4Key" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    ��ʱ���� - ���Ӽ۸�
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

            $('.selectType,.selectSize,.selectPrice').click(function () {
                var $this = $(this);
                if ($this.hasClass('selectType')) {
                    $('.select-type').html('���ͣ�'+$this.html());
                }
                if ($this.hasClass('selectSize')) {
                    $('.select-size').html('������'+$this.html());
                }
                if ($this.hasClass('selectPrice')) {
                    $('.select-price').html('�۸�'+$this.html());
                }

                return false;
            })

            var editor = UE.getEditor('editor');
            $('#btnSubmit').click(function () {
                var selecttype = $('.select-type');
                var selectprice = $('.select-price');
                var selectsize = $('.select-size');
                var price = $('input[name="txtPrice"]');
                var simpledesc = $('input[name=txtSimple]');
                var content = editor.getContent();

                if (!selecttype.html()) {
                    alert('��ѡ������!');
                    return false;
                }
                if (!selectprice.html()) {
                    alert('��ѡ��۸�!');
                    return false;
                }
                var selectValue = selecttype.html() + ';' + selectprice.html() + ';' + selectsize.html();
                if (!price.val()) {
                    alert('�۸���Ϊ�գ�');
                    return false;
                }
                if (!simpledesc.val()) {
                    alert('����������Ϊ�գ�');
                    return false;
                }
                if (simpledesc.val().length > 10) {
                    alert('���������Ȳ��ܳ���10��');
                    return false;
                }
                                
                if (!editor.hasContents()) {
                    alert('�������ݲ���Ϊ�գ�');
                    return false;
                }

                $.post(location.href, { method: 'post', selectattribute: selectValue, price: price.val(), simpledesc: simpledesc.val(), description: content }, function (data) {
                    var result = JSON.parse(data);
                    if (result.statue) {
                        alert('���ӳɹ���');
                        location.href = "pricelist4key.aspx?kid=<%= Request["kid"] %>";
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
    ��ʱ���� - ���Ӽ۸�
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
    <div id="center_list">
        <div class="centerP_body">
            <asp:Repeater ID="rpKey" runat="server">
                <ItemTemplate>
                    <div class="body_content font14 black70">
                        <p>
                            <span>�ؼ������ƣ�<label class="fb black32 "><%# Eval("KName") %></label></span></p>
                        <p class="mt10">
                            <span>������Ȧ��
                                <label class="black32 dline"><%# ADeeWu.HuoBi3J.Web.Class.Helper.GetBusinessCircle(Eval("bid"),Eval("bname")) %></label>
                            </span>
                            <span class="gjbj1">����������<label class="black32"><%# ADeeWu.HuoBi3J.Web.Class.Helper.GetLocation(Eval("aid"),Eval("aname"),Eval("cid"),Eval("cname"),Eval("pid"),Eval("pname")," - ") %></label></span></p>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>

    <div id="filter">
        <div class="filter-sortbar-outer-box">
            <div class="filter-section-wrapper">
                <div class="filter-label-list filter-section category-filter-wrapper first-filter">
                    <div class="label has-icon"><i></i>���ͣ�</div>
                    <ul class="inline-block-list">
                        <asp:Literal runat="server" ID="litType"></asp:Literal>
                    </ul>
                </div>
                <div class="filter-label-list filter-section category-filter-wrapper">
                    <div class="label has-icon"><i></i>�۸�</div>
                    <ul class="inline-block-list">
                        <asp:Literal runat="server" ID="litPrice"></asp:Literal>
                    </ul>
                </div>
                <div class="filter-label-list filter-section category-filter-wrapper">
                    <div class="label has-icon"><i></i>������</div>
                    <ul class="inline-block-list">
                        <asp:Literal runat="server" ID="litSize"></asp:Literal>
                    </ul>
                </div>
                <div class="filter-label-list filter-section category-filter-wrapper">
                    <div class="label has-icon"><i></i>ѡ��</div>
                    <ul class="inline-block-list">
                        <li class="item"><span class="select-type"></span></li>                        
                        <li class="item"><span class="select-price"></span></li>
                        <li class="item"><span class="select-size"></span></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>

    <div class="cl"></div>

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
                <input type="text" name="txtSimple" />��10�����ڣ�
            </td>
        </tr>
        <tr>
            <td class="tdLeft">����������
            </td>
            <td class="tdRight">
                <%--<asp:TextBox ID="txtDesc" runat="server"></asp:TextBox>--%>
                <script type="text/plain" id="editor" name="txtDesc" style="width: 650px; height: 200px"></script>
                <%--<textarea cols="100" rows="8" name="txtDesc" id="txtDesc" style="width: 800px; height: 34px;visibility:hidden;"></textarea>--%>
            </td>
        </tr>
        <tr>
            <td class="tdLeft"></td>
            <td class="tdRight">
                <input type="button" value="����" class="btn_blue" id="btnSubmit" />
            </td>
        </tr>
    </table>
</asp:Content>
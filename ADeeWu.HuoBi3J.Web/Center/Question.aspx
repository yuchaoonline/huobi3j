<%@ Page Language="C#" Title="" MasterPageFile="~/MIndex.master" AutoEventWireup="true" CodeBehind="Question.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Center.Question" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    ȫ���� - �����б� - �ظ�����
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="/CSS/forum_common.css" rel="stylesheet" type="text/css" />
    <link href="/CSS/forum_forumdisplay.css" rel="stylesheet" type="text/css" />
    <link type="text/css" rel="stylesheet" href="/js/rightbox/css/lightbox.min.css" />
    <script type="text/javascript" src="/js/jquery.watermark.js"></script>
    <script type="text/javascript" src="/js/user.js"></script>
    <script src="/ueditor/ueditor.config.js" type="text/javascript"></script>
    <script src="/ueditor/ueditor.all.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="/js/rightbox/lib/jquery.ui.rlightbox.min.js"></script>
    <script>
        $(function () {
            var editor = UE.getEditor('editor');
            $(".lb_flowers").rlightbox();
            $('.saleman').click(function () {
                var uid = $(this).attr('refid');
                var data = $.GetSaleMan({ uid: uid });
                var win = $('#window');
                win.find('.name').text(data.name);
                win.find('.qq').text(data.qq);
                win.find('.phone').text(data.phone);
                win.find('.job').text(data.job);
                win.find('.companyname').text(data.companyname);
                win.find('.companyaddress').text(data.companyaddress);
                win.find('.memo').text(data.memo);
                win.dialog();
            }).css('cursor', 'pointer').each(function (i) {
                var uid = $(this).attr('refid');
                var $this = $(this);
                $.getJSON('/ajax/center.ashx', { method: 'hasticket', uid: uid }, function (data) {
                    if (data.statue) {
                        $this.parent().find('.ticket').show();
                    }
                })
            });
            $('#btnSubmit').click(function () {
                if (!$.IsLogin()) {
                    alert("���¼��");
                    location.href = '/Login.aspx?url=' + document.location.href;
                    return false;
                }
                var parent = $(this).parent();
                var qid = parent.find('input[name=qid]:hidden').val();
                var uid = parent.find('input[name=uid]:hidden').val();
                var content = editor.getContent();
                if (editor.hasContents()) {
                    alert('�ظ����ݲ���Ϊ�գ�');
                    return false;
                }

                $.getJSON('/ajax/center.ashx', { method: 'addanswer', qid: qid, uid: uid, content: content }, function (data) {
                    if (data.statue) {
                        parent.hide();
                        location.href = '<%= Request.RawUrl %>';
                } else {
                    parent.append("<font color='red'>�ύ���������ԣ�</font>");
                }
            })

            return false;
        })

        $('.saleman1 img').ReduceImage();
        $('#title img,.body_content img').ReduceImage();
    })
    </script>
    <style>
        .ticket {
            background: #f00;
            width: 24px;
            height: 24px;
            color: #fff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
    <input type="hidden" name="inform" value="<%=UserID %>" kid="<%= KID %>" />

    <div id="center_list">
        <asp:Repeater ID="rpQuestions" runat="server">
            <ItemTemplate>
                <div class="centerP_body">
                    <div class="body_content font14 black70">
                        <p>�������ݣ�<%# GetTitle(Eval("Title")) %></p>
                        <p class="mt10">
                            <span>�����ˣ�<label class="black32"><%# Eval("LoginName") %></label></span>
                            <span>�����ؼ��֣�<label class="black32"><%# ADeeWu.HuoBi3J.Web.Class.Helper.GetKey(Eval("kid"),Eval("kname")) %></label></span>
                        </p>
                        <p class="mt10">
                            <span>������Ȧ��<label class="black32"><%# ADeeWu.HuoBi3J.Web.Class.Helper.GetBusinessCircle(Eval("bid"),Eval("bname")) %></label></span>
                            <span>��������<label class="black32"><%# ADeeWu.HuoBi3J.Web.Class.Helper.GetLocation(Eval("aid"),Eval("aname"),Eval("cid"),Eval("cname"),Eval("pid"),Eval("pname")," - ") %></label></span>
                        </p>
                    </div>
                </div>
                <div class="centerP_head">
                </div>
            </ItemTemplate>
        </asp:Repeater>

        <asp:Repeater ID="rpProduct" runat="server">
            <ItemTemplate>
                <div class="centerP_body">
                    <div class="body_content font14 black70">
                        <p>
                            <span>��Ʒ���ƣ�<label class="black32"><%# Eval("Name") %></label></span><span>��Ʒ���ݣ�<label class="black32"><%# Eval("Content") %></label></span><span>��Ʒ���ࣺ<label class="black32"><%# bindCategory(Eval("categoryid")) %></label></span>
                        </p>
                        <p class="mt10">
                            <span>���ʱ�䣺<label class="black32"><%# Eval("createtime") %></label></span><span>��ƷͼƬ��<a href="<%# Eval("picture") %>" title="<%# Eval("name") %>" class="lb_flowers"><img src="<%# Eval("picture") %>" id="productIMG" alt="��ƷͼƬ" height="40px" /></a></span>
                        </p>
                    </div>
                </div>
                <div class="centerP_head">
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <%
        if (this.UserID > 0)
        {
            if (ADeeWu.HuoBi3J.Web.Class.SaleManSession.IsSaleMan)
            {
    %>
    <div id="postdiv" runat="server">
        <h3>�ظ�����</h3>
        <div id="PostQustion">
            <input type="hidden" name="qid" value="<%= Request["qid"] %>" />
            <input type="hidden" name="uid" value="<%= ADeeWu.HuoBi3J.Web.Class.SaleManSession.SaleMan.UserID %>" />
            <script type="text/plain" id="editor" name="content" style="width: 800px; height: 200px;"></script>
            <br />
            <button id="btnSubmit" class="btn_blue">
                �ظ�</button>
        </div>
    </div>
    <%}
        }
        else
        { %>
    <div id="loginBar">
        <a href="/login.aspx?url=<%= Request.Url %>" id="btnLogin" title="���¼" class="button">���¼</a>
    </div>
    <%} %>

    <table id="rentP_list" class="table_list font14" cellpadding="0" cellspacing="0">
        <thead>
            <tr height="30px" class="black70 fb font12">
                <td class="arc_title" width="745px">�ظ�����</td>
                <td width="140px ">�ظ���</td>
                <td width="100px">�ظ�ʱ��</td>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rpAnswers" runat="server">
                <ItemTemplate>
                    <tr height="40px" onmouseover="this.className='jobMenu_hover'" onmouseout="this.className=''" class="">
                        <td class="arc_title">
                            <a href="#" class="btn_blue inform" contentid="<%# Eval("id") %>" typeid="3" title="�ٱ�">�ٱ�</a>
                            <div class="saleman1" refid="<%# Eval("uid") %>"><%# Eval("Content") %></div>
                        </td>
                        <td><em class="saleman" refid="<%# Eval("uid") %>"><%# Eval("LoginName") %></em><span class="ticket" style="display: none;">��ȯ</span></td>
                        <td><%# Eval("CreateTime")%></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>

    <div class="pager" align="center">
        <IscControl:Pager3 ID="Pager1" runat="server" />
    </div>

    <div id="window" style="display: none;">
        <div class="item">
            <div class="itemTitle">
                �ظ�����Ϣ
            </div>
            <table class="formTable">
                <tr>
                    <td class="tdLeft">�ظ��ˣ�
                    </td>
                    <td class="tdRight">
                        <strong style="color: #FF9933;"><em class="name"></em></strong>
                    </td>
                </tr>
                <tr>
                    <td class="tdLeft">QQ��
                    </td>
                    <td class="tdRight">
                        <strong style="color: #FF9933;"><em class="qq"></em></strong>
                    </td>
                </tr>
                <tr>
                    <td class="tdLeft">��ϵ�绰��
                    </td>
                    <td class="tdRight">
                        <strong style="color: #FF9933;"><em class="phone"></em></strong>
                    </td>
                </tr>
                <tr>
                    <td class="tdLeft">ְλ��
                    </td>
                    <td class="tdRight">
                        <strong style="color: #FF9933;"><em class="job"></em></strong>
                    </td>
                </tr>
                <tr>
                    <td class="tdLeft">��˾���ƣ�
                    </td>
                    <td class="tdRight">
                        <strong style="color: #FF9933;"><em class="companyname"></em></strong>
                    </td>
                </tr>
                <tr>
                    <td class="tdLeft">��˾��ַ��
                    </td>
                    <td class="tdRight">
                        <strong style="color: #FF9933;"><em class="companyaddress"></em></strong>
                    </td>
                </tr>
                <tr>
                    <td class="tdLeft">��ע��
                    </td>
                    <td class="tdRight">
                        <strong style="color: #FF9933;"><em class="memo"></em></strong>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="attentionDialog"></div>
</asp:Content>

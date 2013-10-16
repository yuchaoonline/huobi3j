<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="Question.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.Center.Question"  %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
无标题文档
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<link href="/CSS/forum_common.css" rel="stylesheet" type="text/css" />
<link href="/CSS/forum_forumdisplay.css" rel="stylesheet" type="text/css" />
<link type="text/css" rel="stylesheet" href="/js/rightbox/css/ui-lightness/jquery-ui-1.8.16.custom.css" />
<link type="text/css" rel="stylesheet" href="/js/rightbox/css/lightbox.min.css" />
<script type="text/javascript" src="/js/jquery.watermark.js" ></script>
<script type="text/javascript" src="/js/user.js" ></script>
<script src="/kindeditor/kindeditor.js" type="text/javascript"></script>
<script type="text/javascript" src="/js/rightbox/lib/jquery.ui.core.min.js"></script>
<script type="text/javascript" src="/js/rightbox/lib/jquery.ui.widget.min.js"></script>
<script type="text/javascript" src="/js/rightbox/lib/jquery.ui.rlightbox.min.js"></script>
<script>
    KE.show({
        id: 'content',
        imageUploadJson: '/kindeditor/upload_json.ashx',
        fileManagerJson: '/kindeditor/file_manager_json.ashx',
        resizeMode: 1,
        allowPreviewEmoticons: true,
        allowUpload: true,
        items: ['fontname', 'fontsize', '|', 'textcolor', 'bgcolor', 'bold', 'italic', 'underline', 'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist', 'insertunorderedlist', '|', 'emoticons', 'image', 'link']
    });
    $(function () {
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
        }).css('cursor', 'pointer');
        $('#btnSubmit').click(function () {
            if (!$.IsLogin()) {
                alert("请登录！");
                location.href = '/Login.aspx?url=' + document.location.href;
                return false;
            }
            var parent = $(this).parent();
            var qid = parent.find('input[name=qid]:hidden').val();
            var uid = parent.find('input[name=uid]:hidden').val();
            var content = KE.html('content');
            if (KE.isEmpty('content')) {
                alert('回复内容不能为空！');
                return false;
            }

            $.getJSON('/ajax/center.ashx', { method: 'addanswer', qid: qid, uid: uid, content: content }, function (data) {
                if (data.statue) {
                    parent.hide();
                    location.href = '<%= Request.RawUrl %>';
                } else {
                    parent.append("<font color='red'>提交错误，请重试！</font>");
                }
            })

            return false;
        })

        $('#productIMG').click(function () {
            var html = "<img src='" + $(this).attr('src') + "' />"
            $('#winpic').html('').html("").html(html).dialog({ modal: true });
        })
    })
</script>
<style>
    .answer_tr
    {
        background: #DDD;
    }
    .answers
    {
        text-indent: 4em;
    }
    .answerName
    {
        float: left;
    }
    .answerTime
    {
        float:right;
    }
    #PostQustion
    {
        margin-top: 10px;
    }
    #content
    {
        width: 100%;
        height: 150px;
    }
    #Main
    {
        position: relative;
    }
</style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>即时报价管理</span> &gt; 提问详情
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <input type="hidden" name="inform" value="<%=this.LoginUser.UserID %>" kid="<%= kid %>" />
    <div class="item">
        <div class="itemTitle">
            提问信息
        </div>
        <table class="formTable">
            <asp:Repeater ID="rpQuestions" runat="server">
                <ItemTemplate>
                    <tr>
                        <td class="tdLeft">
                            提问标题：
                        </td>
                        <td class="tdRight">
                            <strong style="color: #FF9933;">
                                <%# Eval("Title") %></strong>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdLeft">
                            提问人：
                        </td>
                        <td class="tdRight">
                            <strong style="color: #FF9933;">
                                <%# Eval("LoginName") %></strong>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdLeft">
                            所属关键字：
                        </td>
                        <td class="tdRight">
                            <strong style="color: #FF9933;">
                                <%# ADeeWu.HuoBi3J.Web.Class.Helper.GetKey(Eval("kid"),Eval("kname")) %></strong>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdLeft">
                            所属商圈：
                        </td>
                        <td class="tdRight">
                            <strong style="color: #FF9933;">
                                <%# ADeeWu.HuoBi3J.Web.Class.Helper.GetBusinessCircle(Eval("bid"),Eval("bname")) %></strong>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdLeft">
                            所属区域：
                        </td>
                        <td class="tdRight">
                            <strong style="color: #FF9933;">
                                <%# ADeeWu.HuoBi3J.Web.Class.Helper.GetLocation(Eval("aid"),Eval("aname"),Eval("cid"),Eval("cname"),Eval("pid"),Eval("pname")," - ") %></strong>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdLeft">
                            添加时间：
                        </td>
                        <td class="tdRight">
                            <strong style="color: #FF9933;">
                                <%# Eval("createtime") %></strong>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    <div class="item" style="position: absolute; top: 20px; right: 100px;">
        <div class="itemTitle">
            相关商品
        </div>
        <table class="formTable">
            <asp:Repeater ID="rpProduct" runat="server">
                <ItemTemplate>
                    <tr>
                        <td class="tdLeft">
                            商品名称：
                        </td>
                        <td class="tdRight">
                            <strong style="color: #FF9933;">
                                <%# Eval("Name") %></strong>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdLeft">
                            商品内容：
                        </td>
                        <td class="tdRight">
                            <strong style="color: #FF9933;">
                                <%# Eval("Content") %></strong>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdLeft">
                            商品分类：
                        </td>
                        <td class="tdRight">
                            <strong style="color: #FF9933;">
                                <%# bindCategory(Eval("categoryid")) %></strong>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdLeft">
                            添加时间：
                        </td>
                        <td class="tdRight">
                            <strong style="color: #FF9933;">
                                <%# Eval("createtime") %></strong>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdLeft">
                            商品图片：
                        </td>
                        <td class="tdRight">
                                <a href="<%# Eval("picture") %>" title="<%# Eval("name") %>" class="lb_flowers"><img src="<%# Eval("picture") %>" id="productIMG" alt="商品图片" height="40px"/></a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    <div class="mn">
        <div class="tl bm bmw" id="threadlist">
            <!--列名_Start-->
            <div class="th">
                <table cellspacing="0" cellpadding="0">
                    <tbody>
                        <tr>
                            <td class="common">
                                回复内容
                            </td>
                            <td class="num">
                                回复人
                            </td>
                            <td class="num">
                                回复时间
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <!--列名_End-->
            <!--帖子列表_Start-->
            <div class="bm_c">
                <table cellspacing="0" cellpadding="0" summary="forum_2">
                    <tbody>
                        <asp:Repeater ID="rpAnswers" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td class="common">
                                        <a href="#" class="button inform" contentid="<%# Eval("id") %>" typeid="3" title="举报">举报</a>
                                        <%# Eval("Content") %>
                                    </td>
                                    <td class="num">
                                        <em class="saleman" refid="<%# Eval("uid") %>"><%# Eval("LoginName") %></em>
                                    </td>
                                    <td class="num">
                                        <em><%# Eval("CreateTime")%></em>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
            <!--帖子列表_End-->
        </div>
    </div>
    <div class="pager" align="center">
        <IscControl:Pager ID="Pager1" runat="server"  />
    </div>
    <br />
    <%
        if(this.LoginUser!=null){
    %>
    <div id="postdiv" runat="server">
        <h3>
            回复提问</h3>
        <div id="PostQustion">
            <input type="hidden" name="qid" value="<%= Request["qid"] %>" />
            <input type="hidden" name="uid" value="<%= this.LoginUser.UserID %>" />
            <textarea name="content" id="content"></textarea>
            <br />
            <button id="btnSubmit" class="button">
                回复</button>
        </div>
    </div>
    <%
      }else{ %>
    <div id="loginBar">
        <a href="/admin/login.aspx" id="btnLogin" title="请登录" class="button">
            请登录</a>
    </div>
    <%} %>
    
    <div id="window" style="display: none;">
        <div class="item">
            <div class="itemTitle">
                即时业务员信息
            </div>
            <table class="formTable">
                <tr>
                    <td class="tdLeft">
                        业务员名称：
                    </td>
                    <td class="tdRight">
                        <strong style="color: #FF9933;"><em class="name"></em></strong>
                    </td>
                </tr>
                <tr>
                    <td class="tdLeft">
                        QQ：
                    </td>
                    <td class="tdRight">
                        <strong style="color: #FF9933;"><em class="qq"></em></strong>
                    </td>
                </tr>
                <tr>
                    <td class="tdLeft">
                        联系电话：
                    </td>
                    <td class="tdRight">
                        <strong style="color: #FF9933;"><em class="phone"></em></strong>
                    </td>
                </tr>
                <tr>
                    <td class="tdLeft">
                        职位：
                    </td>
                    <td class="tdRight">
                        <strong style="color: #FF9933;"><em class="job"></em></strong>
                    </td>
                </tr>
                <tr>
                    <td class="tdLeft">
                        公司名称：
                    </td>
                    <td class="tdRight">
                        <strong style="color: #FF9933;"><em class="companyname"></em></strong>
                    </td>
                </tr>
                <tr>
                    <td class="tdLeft">
                        公司地址：
                    </td>
                    <td class="tdRight">
                        <strong style="color: #FF9933;"><em class="companyaddress"></em></strong>
                    </td>
                </tr>
                <tr>
                    <td class="tdLeft">
                        备注：
                    </td>
                    <td class="tdRight">
                        <strong style="color: #FF9933;"><em class="memo"></em></strong>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>


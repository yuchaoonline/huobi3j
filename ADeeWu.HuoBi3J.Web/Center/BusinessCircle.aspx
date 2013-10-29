<%@ Page Language="C#" Title="" MasterPageFile="~/MIndex.master"  AutoEventWireup="true" CodeBehind="BusinessCircle.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Center.BusinessCircle" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="ADeeWuControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
即时报价 - 商圈内容
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<link href="/CSS/forum_common.css" rel="stylesheet" type="text/css" />
<link href="/CSS/forum_forumdisplay.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="/js/jquery.watermark.js" ></script>
<script type="text/javascript" src="/js/user.js" ></script>
<script type="text/javascript">
    $(function () {
        $('.newKey').btnLogin({ title: '添加关键字' });
        $('[name=keyName]').watermark('输入关键字');

        $('#btnSubmit').click(function () {
            var parent = $(this).parent();
            var bid = parent.find('input[name=bid]:hidden').val();
            var keyName = parent.find('input[name=keyName]').val();
            if (keyName == '') {
                alert("关键字名称不能为空！");
                return false;
            }

            $.getJSON('/ajax/center.ashx', { method: 'AddKey', bid: bid, name: keyName }, function (data) {
                if (data.statue) {
                    parent.hide();
                    location.href = '<%= Request.RawUrl %>';
                } else {
                    if (data.msg)
                        alert(data.msg);
                    else
                        parent.append("<font color='red'>提交错误，请重试！</font>");
                }
            })

            return false;
        })
    })
</script>
<style>
#Main
    {
        position: relative;
    }
</style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
    <span class="center"><a href="Default.aspx" title="搜索">搜索</a></span>>>
    <span class="location"><asp:Literal ID="litLocation" runat="server"></asp:Literal></span>>>
    <span class="bname"><asp:Literal ID="litBName" runat="server"></asp:Literal></span>
    
    <div id="center_list">
        <div class="centerP_body">
            <div class="body_content font14 black70">
                <p>
                    <span class="fb black32">贡献人信息</span>
                </p>
                <asp:Repeater ID="rpInfo" runat="server">
                    <ItemTemplate>
                        <p class="mt10">
                            <span>贡献人：<label><%# Eval("Name") %></label></span><span>QQ：<label><%# Eval("QQ") %></label></span><span>联系方式：<label><%# Eval("Phone") %></label></span></p>
                        <p class="mt10">
                            <span>公司名称：<label><%# Eval("companyname") %></label></span><span>公司地址：<label><%# Eval("companyaddress") %></label></span><span>简介：<label><%# Eval("memo") %></label></span></p>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <p class="mt10">
                    <button class="newKey btn_blue89">添加关键字</button>
                    <div class="PostKey" style="display: none;">
                        <input type="hidden" name="bid" value="<%= Request["bid"] %>" />
                        <input type="text" name="keyName" value="" />
                        <button id="btnSubmit" class="button">提交</button>
                    </div>
                </p>
        </div>
        <div class="centerP_head"></div>
    </div>

    <table id="rentP_list" class="table_list font14" cellpadding="0" cellspacing="0">
        <thead>
            <tr height="30px" class="black70 fb font12">
                <td class="arc_title" width="710px">关键字</td>
                <td width="140px ">提问数</td>
                <td width="100px">添加时间</td>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rpResult" runat="server">
                <ItemTemplate>
                    <tr height="40px" onmouseover="this.className='jobMenu_hover'" onmouseout="this.className=''" class="">
                        <td class="arc_title">
                            <%if(IsDefaultBussinessCircle){ %>
                            <a href="MoveCircle.aspx?kid=<%# Eval("KID") %>" class="btn_blue" style="color: #fff; font-size: 12px;" title="指定商圈">指定商圈</a>
                            <%} %>
                            <a class="xst question" href="key4product.aspx?kid=<%# Eval("KID") %>" title="<%# Eval("KName") %>"><%# Eval("KName") %></a>
                        </td>
                        <td><%# Eval("QuestionCount") %></td>
                        <td><%# Eval("KCreateTime")%></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>

    <div class="pager" align="center">
        <ADeeWuControl:Pager ID="Pager1" runat="server"  />
    </div>
</asp:Content>
<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="RegSaleMan.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Center.RegSaleMan" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="ADeeWuControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    货比三家 - 个人管理中心 - 申请开通报价比价服务
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="/CSS/forum_common.css" rel="stylesheet" type="text/css" />
    <link href="/CSS/forum_forumdisplay.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=D10a875567626012d06af2387efa088e"></script>
    <script src="/ueditor/ueditor.config.js" type="text/javascript"></script>
    <script src="/ueditor/ueditor.all.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            var editor = UE.getEditor('editor');
            $('#<%=btnSubmit.ClientID%>').click(function () {
                $('#<%=txtMemo.ClientID%>').val(editor.getContent());
                return true;
            })

            var map = new BMap.Map("allmap");
            map.enableScrollWheelZoom();    //启用滚轮放大缩小，默认禁用
            map.enableContinuousZoom();    //启用地图惯性拖拽，默认禁用
            
            var initPoint = new BMap.Point(23.027705, 113.12843);
            var existVal = $('#<%=hfPosition.ClientID%>').val();
            if (existVal != '') {
                var a = existVal.split("|");
                initPoint = new BMap.Point(a[1], a[0]);
                map.centerAndZoom(initPoint, 18);
            } else {
                map.centerAndZoom("<% =ADeeWu.HuoBi3J.Web.Class.AccountHelper.City%>", 14);
            }
            var marker = new BMap.Marker(initPoint);
            map.addOverlay(marker);
            marker.enableDragging();
            marker.addEventListener('dragend', function (type, target, pixel, point) {
                updatePosition(type.point);
            });
            
            $('.btnPositionSearch').click(function () {
                var address = $('#<%=txtCompanyAddress.ClientID%>').val();
                $.getJSON("/ajax/center.ashx", { method: 'getlocationpoint', address: address }, function (data) {
                    if (data.status == 0 && data.result && data.result.location && data.result.location.lng) {
                        var point = new BMap.Point(data.result.location.lng, data.result.location.lat);
                        marker.setPosition(point);
                        updatePosition(point);
                    } else {
                        alert('查无此找到结果')
                    }
                })

                return false;
            })

            function updatePosition(point) {
                map.centerAndZoom(point, 18);
                $('#<%=hfPosition.ClientID%>').val(point.lat + '|' + point.lng);
            }
        })
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <a href="/My/User/Center/MyQuestionList.aspx">货比三家</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <div align="center">
        <strong>注:带<span class="require">*</span> 表示必填项</strong><br />
        <strong>申请开通报价比价服务时，请确保你的账户余额大于50元，否则无法通过审核</strong><br />
        <br />
        <asp:Label ID="labTips" runat="server" Text="" ForeColor="#FF0000"></asp:Label>
    </div>
    <table class="formTable">
        <tr>
            <td class="tdLeft">联系人：
            </td>
            <td class="tdRight">
                <asp:TextBox ID="txtName" runat="server" CssClass="txtName"></asp:TextBox>
                <span class="require">*</span><span class="tips">请填写联系人</span>
                <asp:RequiredFieldValidator ID="rfvTxtName" ControlToValidate="txtName" runat="server"
                    ErrorMessage="请填写！" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">联系方式：
            </td>
            <td class="tdRight">
                <asp:TextBox ID="txtPhone" runat="server" CssClass="txtPhone"></asp:TextBox>
                <span class="tips">请填写您的联系方式，只能填数字</span>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">QQ：
            </td>
            <td class="tdRight">
                <asp:TextBox ID="txtQQ" runat="server" CssClass="txtQQ"></asp:TextBox>
                <span class="tips">请填写您的QQ</span>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">职位：
            </td>
            <td class="tdRight">
                <asp:TextBox ID="txtJob" runat="server" CssClass="txtJob"></asp:TextBox>
                <span class="tips">请填写您的职位</span>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">公司名称：
            </td>
            <td class="tdRight">
                <asp:TextBox ID="txtCompanyName" runat="server" CssClass="txtCompanyName"></asp:TextBox>
                <span class="require">*</span><span class="tips">请填写您的公司名称</span>
                <asp:RequiredFieldValidator ID="rfvCompanyName" ControlToValidate="txtCompanyName" runat="server"
                    ErrorMessage="请填写！" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">公司地址：
            </td>
            <td class="tdRight">
                <asp:TextBox ID="txtCompanyAddress" runat="server" CssClass="txtCompanyAddress"></asp:TextBox>
                <span class="require">*</span><span class="tips">请填写您的公司地址</span>
                <button class="btn_blue btnPositionSearch">搜索</button>
                <asp:RequiredFieldValidator ID="rfvCompanyAddress" ControlToValidate="txtCompanyAddress" runat="server"
                    ErrorMessage="请填写！" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">地图坐标：
            </td>
            <td class="tdRight">
                <asp:HiddenField ID="hfPosition" runat="server" />
                <div id="allmap" style="width: 650px; height: 400px;"></div>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">备注：
            </td>
            <td class="tdRight">
                <asp:HiddenField ID="txtMemo" runat="server" />
                <script type="text/plain" id="editor" name="txtDesc" style="width: 650px; height: 34px">
                    <asp:Literal ID="litMemo" runat="server"></asp:Literal>
                </script>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">二维码：
            </td>
            <td class="tdRight">
                <asp:Literal ID="litQR" runat="server"></asp:Literal>
            </td>
        </tr>
        <asp:PlaceHolder ID="phCheckState" runat="server">
            <tr>
                <td class="tdLeft">当前状态：
                </td>
                <td class="tdRight">
                    <asp:Literal ID="liteCheckState" runat="server"></asp:Literal>
                </td>
            </tr>
        </asp:PlaceHolder>
        <tr>
            <td class="tdLeft"></td>
            <td class="tdRight">
                <asp:Button ID="btnSubmit" runat="server" Text="提交申请" OnClick="btnSubmit_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

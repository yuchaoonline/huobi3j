<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="RegSaleMan.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Center.RegSaleMan" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    全民营销 - 个人管理中心 - 我的关键字列表
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="/CSS/forum_common.css" rel="stylesheet" type="text/css" />
    <link href="/CSS/forum_forumdisplay.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <a href="/My/User/Center/MyQuestionList.aspx">即时报价</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <div align="center">
        <strong>注:带<span class="require">*</span> 表示必填项</strong><br />
        <strong>申请关注关键字服务时，请确保你的账户余额大于50元，否则无法通过审核</strong><br />
        <br />
        <asp:Label ID="labTips" runat="server" Text="" ForeColor="#FF0000"></asp:Label>
    </div>
    <table class="formTable">
        <tr>
            <td class="tdLeft">名称：
            </td>
            <td class="tdRight">
                <asp:TextBox ID="txtName" runat="server" CssClass="txtName"></asp:TextBox>
                <span class="require">*</span><span class="tips">请填写名称</span>
                <asp:RequiredFieldValidator ID="rfvTxtName" ControlToValidate="txtName" runat="server"
                    ErrorMessage="请填写！" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">联系方式：
            </td>
            <td class="tdRight">
                <asp:TextBox ID="txtPhone" runat="server" CssClass="txtPhone"></asp:TextBox>
                <span class="tips">请填写您的联系方式</span>
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
                <asp:RequiredFieldValidator ID="rfvCompanyAddress" ControlToValidate="txtCompanyAddress" runat="server"
                    ErrorMessage="请填写！" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">地图坐标：
            </td>
            <td class="tdRight">纬度 -
                <asp:TextBox ID="txtPositionX" runat="server" /><br />
                经度 -
                <asp:TextBox ID="txtPositionY" runat="server" /><br />
                <a href="/Map/?lat=<%=this.txtPositionX.Text%>&lng=<%=this.txtPositionY.Text%>&title=<%=HttpUtility.HtmlEncode(this.txtName.Text)%>&summary=<%=HttpUtility.HtmlEncode(this.txtCompanyAddress.Text)%>" target="_blank">查看当前地图位置</a> | <a href="/Map/GetPosition.html" target="_blank">获取地图坐标</a>(在地图上定位后，把对应的纬度、经度数值粘帖到文本框中)
            </td>
        </tr>
        <tr>
            <td class="tdLeft">备注：
            </td>
            <td class="tdRight">
                <asp:TextBox ID="txtMemo" runat="server" CssClass="txtMemo" TextMode="MultiLine"></asp:TextBox>
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

<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="New.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Houses.New" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    个人控制面板 - 发布在线出租信息
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <span class="spl"></span><a href="/My/User/Houses/">在线出租管理</a><span class="spl">　</span><span class="curPos">发布出租信息</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <table class="formTable">
        <tr>
            <td class="tdLeft">信息标题：</td>
            <td class="tdRight">
                <input type="text" class="txtAddress" id="txtTitle" runat="server" /><span
                    class="require">*</span></td>
        </tr>
        <tr>
            <td class="tdLeft">房屋性质：</td>
            <td class="tdRight">
                <asp:RadioButton ID="radProperity01" GroupName="properity" runat="server" Text="出租" Checked="true" />
                <asp:RadioButton ID="radProperity02" GroupName="properity" runat="server" Text="求租" />
                <asp:RadioButton ID="radProperity03" GroupName="properity" runat="server" Text="合租" />
            </td>
        </tr>
        <tr>
            <td class="tdLeft">房屋所在区域：</td>
            <td class="tdRight">
                <IscControl:SyncSelector ID="syncSelectorLocation" runat="server"
                    DataSourceURL="<%$Resources:SyncSelector,Location_DataSourceURL %>"
                    DataSourceName="<%$Resources:SyncSelector,Location_DataSourceName %>"
                    ClientPostNames="<%$Resources:SyncSelector,Location_ClientPostNames %>" />
            </td>
        </tr>
        <tr>
            <td class="tdLeft">房屋地址：</td>
            <td class="tdRight">
                <input type="text" id="txtAddress" runat="server" class="txtAddress" /><span class="require">*</span>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">公交路线：</td>
            <td class="tdRight">
                <input type="text" id="txtBusline" runat="server" class="txtAddress" />
            </td>
        </tr>
        <tr>
            <td class="tdLeft">房屋类型：</td>
            <td class="tdRight">
                <asp:DropDownList ID="ddlHouseType" runat="server">
                    <asp:ListItem Value="-1" Selected="True">请选择</asp:ListItem>
                    <asp:ListItem Value="0">住宅</asp:ListItem>
                    <asp:ListItem Value="1">商铺</asp:ListItem>
                    <asp:ListItem Value="2">写字楼</asp:ListItem>
                    <asp:ListItem Value="3">工厂</asp:ListItem>
                    <asp:ListItem Value="4">其他</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">房屋结构：</td>
            <td class="tdRight">
                <asp:DropDownList ID="ddlHousestrcts" runat="server">
                    <asp:ListItem Value="-1" Selected="True">请选择</asp:ListItem>
                    <asp:ListItem Value="0">单间</asp:ListItem>
                    <asp:ListItem Value="1">一室一厅</asp:ListItem>
                    <asp:ListItem Value="2">二室一厅</asp:ListItem>
                    <asp:ListItem Value="3">二室二厅</asp:ListItem>
                    <asp:ListItem Value="4">三室一厅</asp:ListItem>
                    <asp:ListItem Value="5">四室一厅</asp:ListItem>
                    <asp:ListItem Value="6">四室二厅</asp:ListItem>
                    <asp:ListItem Value="7">其他结构</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">房屋面积：</td>
            <td class="tdRight">
                <input type="text" onkeyup="value=value.replace(/[^\d]/g,'') " onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" id="txtMap" runat="server" class="txtAddress" style="width: 40px" />平方米 <span class="require">*</span>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">房屋价格：</td>
            <td class="tdRight">
                <input type="text" id="txtPrice" onkeyup="value=value.replace(/[^\d]/g,'') " onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" runat="server" class="txtAddress" style="width: 40px" />/月<span
                    class="require">*</span></td>
        </tr>
        <tr>
            <td class="tdLeft">房屋坐标：</td>
            <td class="tdRight">经度：<input type="text" id="txtLat"
                runat="server" class="txtAddress" style="width: 40px" />
                纬度：<input
                    type="text" id="txtLng"
                    runat="server" class="txtAddress" style="width: 40px" />
            </td>
        </tr>
        <tr>
            <td class="tdLeft">信息过期时：</td>
            <td class="tdRight">
                <IscControl:DateTimeSelector ID="txtExpire" runat="server"></IscControl:DateTimeSelector>
                <span class="require">*</span></td>
        </tr>
        <tr>
            <td class="tdLeft">其他说明：</td>
            <td class="tdRight">
                <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Columns="50" Rows="8"></asp:TextBox><span class="require">*</span>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan="2">如果该房源信息由专人负责，不想采用个人或公司资料中的联系方式，请填写以下三项</td>
        </tr>
        <tr>
            <td class="tdLeft">联系人姓名：</td>
            <td class="tdRight">
                <input type="text" runat="server" name="txtLinkName" id="LinkName" />
            </td>
        </tr>
        <tr>
            <td class="tdLeft">联系人电话：</td>
            <td class="tdRight">
                <input type="text" runat="server" name="txtLinkPhone" id="LinkPhone" />
            </td>
        </tr>
        <tr>
            <td class="tdLeft">联系人邮件：</td>
            <td class="tdRight">
                <input type="text" runat="server" name="txtLinkEmail" id="LinkEmail" />
            </td>
        </tr>
        <tr>
            <td class="tdLeft"></td>
            <td class="tdRight">
                <asp:Button ID="btnSubmit" runat="server" Text="发布" OnClick="btnSubmit_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
    </table>


</asp:Content>



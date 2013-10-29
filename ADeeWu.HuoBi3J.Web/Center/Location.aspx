<%@ Page Language="C#" Title="" MasterPageFile="~/MIndex.master"  AutoEventWireup="true" CodeBehind="Location.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Center.Location" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="ADeeWuControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
即时报价 - 区域内容
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<link href="/CSS/forum_common.css" rel="stylesheet" type="text/css" />
<link href="/CSS/forum_forumdisplay.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="/js/jquery.watermark.js" ></script>
<script type="text/javascript" src="/js/user.js" ></script>
<script>
    $(function () {
        $('.newKey').click(function () {
            if ($.IsLogin()) {
                location.href = "/center/add.aspx";
                return false;
            } else {
                location.href = '/Login.aspx?url=' + document.location.href;
                return false;
            }
        })
    })
</script>
<style>
    .font12 a {
        font-size: 12px;
    }
</style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
    <span class="center"><a href="Default.aspx" title="搜索">搜索</a></span>>>
    <span class="location"><asp:Literal ID="litLocation" runat="server"></asp:Literal></span>
    <br />
    输入商圈：<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
    <asp:Button ID="btnSearch" runat="server" Text="搜索商圈" CssClass="btn_blue89" onclick="btnSearch_Click" />
    <a href="#" title="发表提问" class="newKey btn_blue89">添加商圈</a>
    <div class="PostKey" style="display: none;">
        <input type="hidden" name="aid" />
        <ADeeWuControl:SyncSelector ID="syncSelectorLocation" runat="server" DataSourceURL="<%$Resources:SyncSelector,Location_DataSourceURL %>"
                    DataSourceName="<%$Resources:SyncSelector,Location_DataSourceName %>" ClientPostNames="<%$Resources:SyncSelector,Location_ClientPostNames %>"
                    InitClientDependency="true" />
        <input type="text" name="BName" />
        <button id="btnSubmit" class="button">提交</button>
    </div>

    <table id="rentP_list" class="table_list font14" cellpadding="0" cellspacing="0">
        <thead>
            <tr height="30px" class="black70 fb font12">
                <td class="arc_title" width="700px">商圈名称</td>
                <td width="185px ">所属区域</td>
                <td width="100px">创建时间</td>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rpResult" runat="server">
                <ItemTemplate>
                    <tr height="40px" onmouseover="this.className='jobMenu_hover'" onmouseout="this.className=''" class="">
                        <td class="arc_title">
                            <a href="BusinessCircle.aspx?bid=<%# Eval("BID") %>" title="<%# Eval("BName") %>" ><%# Eval("BName")%></a>
                        </td>
                        <td><span class="font12"><%# ADeeWu.HuoBi3J.Web.Class.Helper.GetLocation(Eval("AreaID"), Eval("Area"), Eval("CityID"), Eval("City"), Eval("ProvinceID"), Eval("Province"), " - ") %></span></td>
                        <td><%# Eval("CreateTime")%></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>

    <div class="pager" align="center">
        <ADeeWuControl:Pager ID="Pager1" runat="server"  />
    </div>
</asp:Content>
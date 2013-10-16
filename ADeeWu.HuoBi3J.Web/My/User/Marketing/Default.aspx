<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Marketing.Default" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    现金券赠送网 - 我的帐户 - 在线营销 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <a href="/Account/Default.aspx">我的帐户首页</a> &gt;在线营销&gt;编辑在线营销信息
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

    <div>
        <table width="100%" border="0" cellspacing="1" cellpadding="5">
            <tr>
                <td valign="top" width="100px">标题：</td>
                <td valign="top">
                    <asp:TextBox ID="txtTitle" runat="server" Width="50%" CssClass="txtBox"></asp:TextBox>
                    <span class="require">*</span></td>
                <td valign="top">&nbsp;
                </td>
            </tr>
            <tr>
                <td valign="top">所属分类:</td>
                <td valign="top" colspan="2">
                    <IscControl:SyncSelector ID="syncSelectorMarketCategories" runat="server"
                        DataSourceURL="<%$Resources:SyncSelector,MarketCategories_DataSourceURL %>"
                        DataSourceName="<%$Resources:SyncSelector,MarketCategories_DataSourceName %>"
                        ClientPostNames="<%$Resources:SyncSelector,MarketCategories_ClientPostNames %>" />
                </td>
            </tr>
            <tr>
                <td valign="top">经营方式:</td>
                <td valign="top" colspan="2">
                    <asp:DropDownList ID="ddlBusinessType" runat="server">
                        <asp:ListItem Value="0">网络销售</asp:ListItem>
                        <asp:ListItem Value="1">实体店铺</asp:ListItem>
                        <asp:ListItem Value="2">网络+实体店铺</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr id="tr_createtime" runat="server">
                <td valign="top">发布时间：</td>
                <td valign="top" colspan="2">
                    <asp:Label ID="lblCreateTime" runat="server"></asp:Label>
                </td>
            </tr>
            <tr id="tr_updatatime" runat="server">
                <td valign="top">最后修改时间：</td>
                <td valign="top" colspan="2">
                    <asp:Label ID="lblUpdateTime" runat="server"></asp:Label>
                </td>
            </tr>
            <tr id="tr_creftime" runat="server">
                <td valign="top">最后刷新时间：</td>
                <td valign="top" colspan="2">

                    <asp:Label ID="lblReTime" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td valign="top">简述：</td>
                <td valign="top">
                    <asp:TextBox ID="txtSummary" runat="server" TextMode="MultiLine" Width="100%"
                        Height="72px"></asp:TextBox>
                </td>
                <td valign="bottom" width="5px">
                    <span class="require">*</span></td>
            </tr>
            <tr>
                <td valign="top">详细：</td>
                <td valign="top">
                    <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Width="100%"
                        Height="200"></asp:TextBox>

                </td>
                <td valign="bottom" width="5px">
                    <span class="require">*</span></td>
            </tr>
            <tr>
                <td>&nbsp;
                </td>
                <td colspan="2">
                    <asp:Button ID="btnOK" runat="server" Text="保存" OnClick="btnOK_Click" />

                </td>
            </tr>
        </table>
    </div>

</asp:Content>




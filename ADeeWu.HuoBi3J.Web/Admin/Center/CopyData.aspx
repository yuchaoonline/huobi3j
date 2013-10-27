<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="CopyData.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.Center.CopyData" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    复制数据
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
            <span>即时报价管理</span> &gt; 复制数据
            </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
        <div class="item">
            <div class="itemTitle">
                指定商圈
            </div>
            <table class="formTable">
                <tr>
                    <td class="tdLeft">复制全局数据：
                    </td>
                    <td class="tdRight">
                        <asp:Button ID="btnCopy" runat="server" Text="复制全局数据" OnClick="btnCopy_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="tdLeft">所属区域：</td>
                    <td class="tdRight">
                        <IscControl:SyncSelector
                            ID="syncSelectorLocation" runat="server"
                            DataSourceURL="<%$Resources:SyncSelector,Location_DataSourceURL %>"
                            DataSourceName="<%$Resources:SyncSelector,Location_DataSourceName %>"
                            ClientPostNames="<%$Resources:SyncSelector,Location_ClientPostNames %>"
                            InitClientDependency="true" />
                    </td>
                </tr>
                <tr>
                    <td class="tdLeft">商圈名称：
                    </td>
                    <td class="tdRight">
                        <asp:TextBox ID="txtBName" runat="server"></asp:TextBox>
                        <asp:Button ID="btnAdd" runat="server" CssClass="btn_blue" Text="搜索" OnClick="btnAdd_Click" />
                        <a href="Add.aspx" class="btn_blue" target="_blank">添加商圈</a>
                    </td>
                </tr>
            </table>
            <div class="itemTitle">商圈列表</div>
            <table id="rentP_list" class="table_list font14" cellpadding="0" cellspacing="0" width="100%">
                <thead>
                    <tr height="30px" class="black70 fb font12">
                        <td class="arc_title" width="545px">商圈名称</td>
                        <td width="200px ">地区</td>
                        <td width="140px ">操作</td>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpResult" runat="server" OnItemCommand="rpResult_ItemCommand">
                        <ItemTemplate>
                            <tr height="40px" onmouseover="this.className='jobMenu_hover'" onmouseout="this.className=''" class="">
                                <td class="arc_title"><%# Eval("BName") %></td>
                                <td><span class="font12"><%# ADeeWu.HuoBi3J.Web.Class.Helper.GetLocation(Eval("areaid"), Eval("area"), Eval("cityid"), Eval("city"), Eval("provinceid"), Eval("province"), "-") %></span></td>
                                <td>
                                    <asp:Button ID="btnCopy2" runat="server" Text="复制" CommandArgument='<%# Eval("bid") %>' CommandName="copy" /></td
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
        </asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/MIndex.master" AutoEventWireup="true" CodeBehind="MoveCircle.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Center.MoveCircle" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
    <div class="item">
        <div class="itemTitle">
            指定商圈
        </div>
        <table class="formTable">
            <tr>
                <td class="tdLeft">关键字名称：
                </td>
                <td class="tdRight">
                    <asp:Literal ID="litKeyName" runat="server"></asp:Literal>
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
        <table id="rentP_list" class="table_list font14" cellpadding="0" cellspacing="0">
        <thead>
            <tr height="30px" class="black70 fb font12">
                <td class="arc_title" width="545px">商圈名称</td>
                <td width="200px ">地区</td>
                <td width="140px ">操作</td>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rpResult" runat="server">
                <ItemTemplate>
                    <tr height="40px" onmouseover="this.className='jobMenu_hover'" onmouseout="this.className=''" class="">
                        <td class="arc_title"><%# Eval("BName") %></td>
                        <td><span class="font12"><%# ADeeWu.HuoBi3J.Web.Class.Helper.GetLocation(Eval("areaid"), Eval("area"), Eval("cityid"), Eval("city"), Eval("provinceid"), Eval("province"), "-") %></span></td>
                        <td><a href="MoveCircle.aspx?kid=<%# kid %>&bid=<%# Eval("bid") %>" class="btn_blue">指定</a></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
    </div>
</asp:Content>

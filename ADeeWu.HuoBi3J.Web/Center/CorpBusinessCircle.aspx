<%@ Page Title="" Language="C#" MasterPageFile="~/MIndex.master" AutoEventWireup="true" CodeBehind="CorpBusinessCircle.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Center.CorpBusinessCircle" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
    <div id="center_list">
        <div class="centerP_body">
            <div class="body_content font14 black70">
                <p>
                    <span><label class="orange"><asp:Literal runat="server" ID="litCorpName"></asp:Literal> </label>商家所在商圈列表</span>
                </p>
            </div>
        </div>
        <div class="centerP_head"></div>
    </div>
    <table id="rentP_list" class="table_list font14" cellpadding="0" cellspacing="0">
        <thead>
            <tr height="30px" class="black70 fb font12">
                <td class="arc_title" width="785px">商圈</td>
                <td width="100px">添加时间</td>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rpResult" runat="server">
                <ItemTemplate>
                    <tr height="40px" onmouseover="this.className='jobMenu_hover'" onmouseout="this.className=''" class="">
                        <td class="arc_title">
                            <a class="xst question" target="_blank" href="CorpKeys.aspx?uid=<%=Request["uid"] %>&bid=<%# Eval("bid") %>"><%# Eval("BName") %></a>
                        </td>
                        <td><%# Eval("CreateTime")%></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>

    <div class="pager" align="center">
        <IscControl:Pager ID="Pager1" runat="server"  />
    </div>
</asp:Content>

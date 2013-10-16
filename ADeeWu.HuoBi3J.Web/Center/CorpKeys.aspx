<%@ Page Title="" Language="C#" MasterPageFile="~/MIndex.master" AutoEventWireup="true" CodeBehind="CorpKeys.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Center.CorpKeys" %>
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
                    <span><label class="orange"><asp:Literal runat="server" ID="litCorpName"></asp:Literal> </label>商家关注关键字列表</span>
                </p>
            </div>
        </div>
        <div class="centerP_head"></div>
    </div>
    <table id="rentP_list" class="table_list font14" cellpadding="0" cellspacing="0">
        <thead>
            <tr height="30px" class="black70 fb font12">
                <td class="arc_title" width="645px">关键字</td>
                <td width="140px ">提问数</td>
                <td width="100px">添加时间</td>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rpResult" runat="server">
                <ItemTemplate>
                    <tr height="40px" onmouseover="this.className='jobMenu_hover'" onmouseout="this.className=''" class="">
                        <td class="arc_title">
                            <a class="xst question" target="_blank" href="QuestionList.aspx?kid=<%# Eval("KID") %>" title="<%# Eval("KName") %>"><%# Eval("KName") %></a>
                        </td>
                        <td><%# Eval("QuestionCount") %></td>
                        <td><%# Eval("KCreateTime")%></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
    <div class="pager" align="center">
        <IscControl:Pager3 ID="Pager1" runat="server"  />
    </div>
</asp:Content>

<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="SearchHireInfo.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.CorpAgent.SearchHireInfo" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="ADeeWuControl" %>




<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    个人控制面板 - 搜索营销商家
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .HireInfoList {
            margin: 0px;
            padding: 0px;
        }

            .HireInfoList dt {
                margin: 0px;
                padding: 0px;
                margin-bottom: 10px;
            }

                .HireInfoList dt a {
                    font-size: 14px;
                    font-weight: bold;
                }

            .HireInfoList dd {
                margin: 0px;
                padding: 0px;
                margin-bottom: 10px;
                padding-bottom: 5px;
                border-bottom: 1px dashed #ccc;
            }

        .HireInfoList-Summary {
            margin-bottom: 10px;
        }

        .HireInfoList-Other {
            color: #666;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <span class="spl"></span><span class="curPos">搜索营销商家</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

    <table class="searchTable">
        <tr>
            <td class="key" style="width: 50px">公司名称：</td>
            <td>
                <asp:TextBox ID="txtCorpName" runat="server" Width="120px"></asp:TextBox>
            </td>
            <td style="width: 60px">地&nbsp;&nbsp;&nbsp;&nbsp;区：</td>
            <td>
                <ADeeWuControl:SyncSelector ID="syncSelectorLocation" runat="server"
                    DataSourceURL="<%$Resources:SyncSelector,Location_DataSourceURL %>"
                    DataSourceName="<%$Resources:SyncSelector,Location_DataSourceName %>"
                    ClientPostNames="<%$Resources:SyncSelector,Location_ClientPostNames %>" />
            </td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" Text="搜索" OnClick="btnSubmit_Click" />
            </td>
        </tr>
    </table>

    <dl class="HireInfoList">
        <asp:Repeater ID="rpData" runat="server">
            <ItemTemplate>
                <dt>
                    <a href="ViewHireInfo.aspx?id=<%# Eval("ID") %>"><%# Eval("Title") %></a>
                </dt>
                <dd>
                    <div class="HireInfoList-Summary">
                        <%#ADeeWu.HuoBi3J.Libary.Utility.SubString(Eval("Content"), 50, "...")%>
                    </div>
                    <div class="HireInfoList-Other">
                        <strong><%#Eval("CorpName") %></strong> | <%# string.Join("-",new string[]{ Eval("Province").ToString(),Eval("City").ToString(),Eval("Area").ToString()})%> | <a href="ViewHireInfo.aspx?id=<%#Eval("ID") %>">查看详细</a>
                    </div>
                </dd>


            </ItemTemplate>
        </asp:Repeater>
    </dl>


    <ADeeWuControl:Pager ID="Pager1" runat="server" />




</asp:Content>

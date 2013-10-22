<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="SearchHireInfo.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.CorpAgent.SearchHireInfo" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="ADeeWuControl" %>




<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    ���˿������ - ����Ӫ���̼�
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
    <span class="spl"></span><span class="curPos">����Ӫ���̼�</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

    <table class="searchTable">
        <tr>
            <td class="key" style="width: 50px">��˾���ƣ�</td>
            <td>
                <asp:TextBox ID="txtCorpName" runat="server" Width="120px"></asp:TextBox>
            </td>
            <td style="width: 60px">��&nbsp;&nbsp;&nbsp;&nbsp;����</td>
            <td>
                <ADeeWuControl:SyncSelector ID="syncSelectorLocation" runat="server"
                    DataSourceURL="<%$Resources:SyncSelector,Location_DataSourceURL %>"
                    DataSourceName="<%$Resources:SyncSelector,Location_DataSourceName %>"
                    ClientPostNames="<%$Resources:SyncSelector,Location_ClientPostNames %>" />
            </td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" Text="����" OnClick="btnSubmit_Click" />
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
                        <strong><%#Eval("CorpName") %></strong> | <%# string.Join("-",new string[]{ Eval("Province").ToString(),Eval("City").ToString(),Eval("Area").ToString()})%> | <a href="ViewHireInfo.aspx?id=<%#Eval("ID") %>">�鿴��ϸ</a>
                    </div>
                </dd>


            </ItemTemplate>
        </asp:Repeater>
    </dl>


    <ADeeWuControl:Pager ID="Pager1" runat="server" />




</asp:Content>

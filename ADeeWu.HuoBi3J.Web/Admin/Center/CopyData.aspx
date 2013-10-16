<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="CopyData.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.Center.CopyData" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    ��������
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
            <span>��ʱ���۹���</span> &gt; ��������
            </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
        <div class="item">
            <div class="itemTitle">
                ָ����Ȧ
            </div>
            <table class="formTable">
                <tr>
                    <td class="tdLeft">����ȫ�����ݣ�
                    </td>
                    <td class="tdRight">
                        <asp:Button ID="btnCopy" runat="server" Text="����ȫ������" OnClick="btnCopy_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="tdLeft">��������</td>
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
                    <td class="tdLeft">��Ȧ���ƣ�
                    </td>
                    <td class="tdRight">
                        <asp:TextBox ID="txtBName" runat="server"></asp:TextBox>
                        <asp:Button ID="btnAdd" runat="server" CssClass="btn_blue" Text="����" OnClick="btnAdd_Click" />
                        <a href="Add.aspx" class="btn_blue" target="_blank">�����Ȧ</a>
                    </td>
                </tr>
            </table>
            <div class="itemTitle">��Ȧ�б�</div>
            <table id="rentP_list" class="table_list font14" cellpadding="0" cellspacing="0" width="100%">
                <thead>
                    <tr height="30px" class="black70 fb font12">
                        <td class="arc_title" width="545px">��Ȧ����</td>
                        <td width="200px ">����</td>
                        <td width="140px ">����</td>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpResult" runat="server" OnItemCommand="rpResult_ItemCommand">
                        <ItemTemplate>
                            <tr height="40px" onmouseover="this.className='jobMenu_hover'" onmouseout="this.className=''" class="">
                                <td class="arc_title"><%# Eval("BName") %></td>
                                <td><span class="font12"><%# ADeeWu.HuoBi3J.Web.Class.Helper.GetLocation(Eval("areaid"), Eval("area"), Eval("cityid"), Eval("city"), Eval("provinceid"), Eval("province"), "-") %></span></td>
                                <td>
                                    <asp:Button ID="btnCopy2" runat="server" Text="����" CommandArgument='<%# Eval("bid") %>' CommandName="copy" /></td
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
        </asp:Content>


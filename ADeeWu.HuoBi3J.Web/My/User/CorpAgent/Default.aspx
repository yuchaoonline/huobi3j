<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.CorpAgent.Default" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="ADeeWuControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    ���˿������ - Ӫ�������� - ����Ӫ��רԱ
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <span class="spl"></span><span class="curPos">Ӫ��רԱ(�ύ����)</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

    <div align="center">
        <strong>ע:��<span class="require">*</span> ��ʾ������</strong><br />
        <br />
        <asp:Label ID="labTips" runat="server" Text="" ForeColor="#FF0000"></asp:Label>
    </div>

    <table class="formTable">
        <tr>
            <td class="tdLeft">��ʵ������
            </td>
            <td class="tdRight">
                <asp:TextBox ID="txtRealName" runat="server" CssClass="txtUserName"></asp:TextBox>
                <span class="require">*</span><span class="tips">����д������ʵ����</span>
                <asp:RequiredFieldValidator ID="rfvTxtRealName" ControlToValidate="txtRealName" runat="server" ErrorMessage="����д��" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">�ԡ�����
            </td>
            <td class="tdRight">
                <asp:DropDownList ID="ddlSex" runat="server">
                    <asp:ListItem Text="��ѡ��" Value="" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="��" Value="��"></asp:ListItem>
                    <asp:ListItem Text="Ů" Value="Ů"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">�������ڣ�
            </td>
            <td class="tdRight">
                <ADeeWuControl:DateTimeSelector ID="txtBirthday" runat="server" CssClass="txtDate"></ADeeWuControl:DateTimeSelector>
                <span class="require">*</span><span class="tips">����д���ĳ�������</span>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">���ڵ�����
            </td>
            <td class="tdRight">
                <ADeeWuControl:SyncSelector ID="syncSelectorLocation" runat="server"
                    DataSourceURL="<%$Resources:SyncSelector,Location_DataSourceURL %>"
                    DataSourceName="<%$Resources:SyncSelector,Location_DataSourceName %>"
                    ClientPostNames="<%$Resources:SyncSelector,Location_ClientPostNames %>" />
                <span class="require">*</span> <span class="tips">��ѡ�������ڵĵ���</span>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">�����ַ��
            </td>
            <td class="tdRight">
                <asp:TextBox ID="txtAddress" runat="server" CssClass="txtAddress"></asp:TextBox>
                <span class="require">*</span><span class="tips">����д�����ڵĵ�ַ</span>
                <asp:RequiredFieldValidator ID="rfvTxtAddress" ControlToValidate="txtAddress" runat="server" ErrorMessage="����д��" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">�������룺
            </td>
            <td class="tdRight">
                <asp:TextBox ID="txtZipCode" runat="server" CssClass="txtZipCode"></asp:TextBox>
                <span class="tips">���������ڵص���������</span>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">ѧ��������
            </td>
            <td class="tdRight">
                <ADeeWuControl:SyncSelector ID="syncSelectorEducation" runat="server"
                    DataSourceURL="<%$Resources:SyncSelector,Education_DataSourceURL %>"
                    DataSourceName="<%$Resources:SyncSelector,Education_DataSourceName %>"
                    ClientPostNames="<%$Resources:SyncSelector,Education_ClientPostNames %>" />
                <span class="require">*</span>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">�������飺
            </td>
            <td class="tdRight">
                <ADeeWuControl:SyncSelector ID="syncSelectorWorkExp" runat="server"
                    DataSourceURL="<%$Resources:SyncSelector,WorkExp_DataSourceURL %>"
                    DataSourceName="<%$Resources:SyncSelector,WorkExp_DataSourceName %>"
                    ClientPostNames="<%$Resources:SyncSelector,WorkExp_ClientPostNames %>" />
                <span class="require">*</span>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">��ҵѧУ��
            </td>
            <td class="tdRight">
                <asp:TextBox ID="txtSchool" runat="server" CssClass="txtAddress"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">ר����ҵ��
            </td>
            <td class="tdRight">
                <asp:TextBox ID="txtSpeciality" runat="server" CssClass="txtBox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">�������ܣ�
            </td>
            <td class="tdRight">
                <asp:TextBox ID="txtSkill" runat="server" TextMode="MultiLine" CssClass="txtNotes" Columns="50" Rows="5"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">������ע��</td>
            <td class="tdRight">
                <asp:TextBox ID="txtNote" runat="server" TextMode="MultiLine" CssClass="txtNotes" Columns="50" Rows="5"></asp:TextBox>
                <span class="tips">���������д������ʱ��Σ����̼Ҹ����ҵ�����
                </span>
            </td>
        </tr>
        <asp:PlaceHolder ID="phIsHidden" runat="server">
            <tr>
                <td class="tdLeft">�������أ�</td>
                <td class="tdRight">
                    <asp:CheckBox ID="chkSetHidden" runat="server" Text="��" AutoPostBack="true"
                        OnCheckedChanged="chkSetHidden_CheckedChanged" />
                    <span class="tips">��ѡ�������������ļ��������̼Ҳ��������������ļ���</span>
                </td>

            </tr>
            <tr>
                <td class="tdLeft">�ƹ����ӣ�</td>
                <td class="tdRight">
                    <span id="PromotionLink">
                        <asp:TextBox ID="txtPromotionLink" runat="server" ReadOnly="true" Width="400px"></asp:TextBox>
                    </span><%--<a href="javascript:if( isc.util.copyToClipboard($('#txtPromotionLink').val()) ) alert('���ӵ�ַ�Ѹ��Ƶ�ճ������'); void(0);">����</a>--%>
                    <div class="tips">�̼�ͨ�������ӽ���ע���ʺ��Ժ󣬸��̼�������Ϊ����ҵ��ͻ���</div>
                </td>
            </tr>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phCheckState" runat="server">
            <tr>
                <td class="tdLeft">��ǰ״̬��</td>
                <td class="tdRight">
                    <asp:Literal ID="liteCheckState" runat="server"></asp:Literal>
                </td>
            </tr>
        </asp:PlaceHolder>
        <tr>
            <td class="tdLeft"></td>
            <td class="tdRight">
                <asp:Button ID="btnSubmit" runat="server" Text="�ύ����"
                    OnClick="btnSubmit_Click" />
            </td>
        </tr>
    </table>





</asp:Content>

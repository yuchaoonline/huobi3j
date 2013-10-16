<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="Edit.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.CorpAgent.Applications.Edit"  %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
Admin - CorpAgent - Applications - Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>Ӫ���������������</span> &gt; <a href="List.aspx">�б�</a> &gt; �޸�
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

<table class="formTable">
        <tr>
            <td class="tdLeft">
            ��ʵ������
            </td>
            <td class="tdRight">
                <asp:TextBox ID="txtRealName" runat="server" CssClass="txtUserName"></asp:TextBox> <span class="require">*</span>
                <asp:RequiredFieldValidator ID="rfvTxtRealName" ControlToValidate="txtRealName" runat="server" ErrorMessage="����д��" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">
            ��&nbsp;&nbsp;&nbsp;&nbsp;��
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
            <td class="tdLeft">
            �������ڣ�
            </td>
            <td class="tdRight">
                <IscControl:DateTimeSelector ID="txtBirthday" runat="server" CssClass="txtDate"></IscControl:DateTimeSelector> <span class="require">*</span>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">
            ���ڵ�����
            </td>
            <td class="tdRight">
                <IscControl:SyncSelector ID="syncSelectorLocation" runat="server" 
                DataSourceURL="<%$Resources:SyncSelector,Location_DataSourceURL %>" 
                DataSourceName="<%$Resources:SyncSelector,Location_DataSourceName %>" 
                ClientPostNames="<%$Resources:SyncSelector,Location_ClientPostNames %>"
                /> <span class="require">*</span>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">
            �����ַ��
            </td>
            <td class="tdRight">
                <asp:TextBox ID="txtAddress" runat="server" CssClass="txtAddress"></asp:TextBox> <span class="require">*</span>
                <asp:RequiredFieldValidator ID="rfvTxtAddress" ControlToValidate="txtAddress" runat="server" ErrorMessage="����д��" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">
            �������룺
            </td>
            <td class="tdRight">
                <asp:TextBox ID="txtZipCode" runat="server" CssClass="txtZipCode"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">
            ѧ&nbsp;&nbsp;&nbsp;&nbsp;����
            </td>
            <td class="tdRight">
                <IscControl:SyncSelector ID="syncSelectorEducation" runat="server" 
                DataSourceURL="<%$Resources:SyncSelector,Education_DataSourceURL %>" 
                DataSourceName="<%$Resources:SyncSelector,Education_DataSourceName %>" 
                ClientPostNames="<%$Resources:SyncSelector,Education_ClientPostNames %>"
                /> <span class="require">*</span>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">
            �������飺
            </td>
            <td class="tdRight">
                <IscControl:SyncSelector ID="syncSelectorWorkExp" runat="server" 
                DataSourceURL="<%$Resources:SyncSelector,WorkExp_DataSourceURL %>" 
                DataSourceName="<%$Resources:SyncSelector,WorkExp_DataSourceName %>" 
                ClientPostNames="<%$Resources:SyncSelector,WorkExp_ClientPostNames %>"
                /> <span class="require">*</span>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">
            ��ҵѧУ��
            </td>
            <td class="tdRight">
                <asp:TextBox ID="txtSchool" runat="server" CssClass="txtAddress"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">
            ר&nbsp;&nbsp;&nbsp;&nbsp;ҵ��
            </td>
            <td class="tdRight">
                <asp:TextBox ID="txtSpeciality" runat="server" CssClass="txtBox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">
            ��&nbsp;&nbsp;&nbsp;&nbsp;�ܣ�
            </td>
            <td class="tdRight">
                <asp:TextBox ID="txtSkill" runat="server" TextMode="MultiLine" CssClass="txtNotes"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">��&nbsp;&nbsp;&nbsp;&nbsp;ע��</td>
            <td class="tdRight">
            <asp:TextBox ID="txtNote" runat="server" TextMode="MultiLine" CssClass="txtNotes"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">����ʱ�䣺</td>
            <td class="tdRight">
                <asp:Literal ID="liteCreateTime" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">�޸�ʱ�䣺</td>
            <td class="tdRight">
                <asp:Literal ID="liteModifyTime" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">��&nbsp;&nbsp;&nbsp;&nbsp;�ˣ�</td>
            <td class="tdRight">
                <asp:DropDownList ID="ddlCheckState" runat="server">
                    <asp:ListItem Value="0">�����</asp:ListItem>
                    <asp:ListItem Value="1">ͨ�����</asp:ListItem>
                    <asp:ListItem Value="2">��Ч</asp:ListItem>
                    <asp:ListItem Value="3">����</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
         <tr>
            <td class="tdLeft"></td>
            <td class="tdRight">
                <asp:Button ID="btnSubmit" runat="server" Text="�޸�" 
                    onclick="btnSubmit_Click" />
            </td>
        </tr>
    </table>


</asp:Content>


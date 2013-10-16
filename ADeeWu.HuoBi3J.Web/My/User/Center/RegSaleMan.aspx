<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="RegSaleMan.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Center.RegSaleMan" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    ȫ��Ӫ�� - ���˹������� - �ҵĹؼ����б�
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="/CSS/forum_common.css" rel="stylesheet" type="text/css" />
    <link href="/CSS/forum_forumdisplay.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <a href="/My/User/Center/MyQuestionList.aspx">��ʱ����</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <div align="center">
        <strong>ע:��<span class="require">*</span> ��ʾ������</strong><br />
        <strong>�����ע�ؼ��ַ���ʱ����ȷ������˻�������50Ԫ�������޷�ͨ�����</strong><br />
        <br />
        <asp:Label ID="labTips" runat="server" Text="" ForeColor="#FF0000"></asp:Label>
    </div>
    <table class="formTable">
        <tr>
            <td class="tdLeft">���ƣ�
            </td>
            <td class="tdRight">
                <asp:TextBox ID="txtName" runat="server" CssClass="txtName"></asp:TextBox>
                <span class="require">*</span><span class="tips">����д����</span>
                <asp:RequiredFieldValidator ID="rfvTxtName" ControlToValidate="txtName" runat="server"
                    ErrorMessage="����д��" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">��ϵ��ʽ��
            </td>
            <td class="tdRight">
                <asp:TextBox ID="txtPhone" runat="server" CssClass="txtPhone"></asp:TextBox>
                <span class="tips">����д������ϵ��ʽ</span>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">QQ��
            </td>
            <td class="tdRight">
                <asp:TextBox ID="txtQQ" runat="server" CssClass="txtQQ"></asp:TextBox>
                <span class="tips">����д����QQ</span>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">ְλ��
            </td>
            <td class="tdRight">
                <asp:TextBox ID="txtJob" runat="server" CssClass="txtJob"></asp:TextBox>
                <span class="tips">����д����ְλ</span>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">��˾���ƣ�
            </td>
            <td class="tdRight">
                <asp:TextBox ID="txtCompanyName" runat="server" CssClass="txtCompanyName"></asp:TextBox>
                <span class="require">*</span><span class="tips">����д���Ĺ�˾����</span>
                <asp:RequiredFieldValidator ID="rfvCompanyName" ControlToValidate="txtCompanyName" runat="server"
                    ErrorMessage="����д��" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">��˾��ַ��
            </td>
            <td class="tdRight">
                <asp:TextBox ID="txtCompanyAddress" runat="server" CssClass="txtCompanyAddress"></asp:TextBox>
                <span class="require">*</span><span class="tips">����д���Ĺ�˾��ַ</span>
                <asp:RequiredFieldValidator ID="rfvCompanyAddress" ControlToValidate="txtCompanyAddress" runat="server"
                    ErrorMessage="����д��" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">��ͼ���꣺
            </td>
            <td class="tdRight">γ�� -
                <asp:TextBox ID="txtPositionX" runat="server" /><br />
                ���� -
                <asp:TextBox ID="txtPositionY" runat="server" /><br />
                <a href="/Map/?lat=<%=this.txtPositionX.Text%>&lng=<%=this.txtPositionY.Text%>&title=<%=HttpUtility.HtmlEncode(this.txtName.Text)%>&summary=<%=HttpUtility.HtmlEncode(this.txtCompanyAddress.Text)%>" target="_blank">�鿴��ǰ��ͼλ��</a> | <a href="/Map/GetPosition.html" target="_blank">��ȡ��ͼ����</a>(�ڵ�ͼ�϶�λ�󣬰Ѷ�Ӧ��γ�ȡ�������ֵճ�����ı�����)
            </td>
        </tr>
        <tr>
            <td class="tdLeft">��ע��
            </td>
            <td class="tdRight">
                <asp:TextBox ID="txtMemo" runat="server" CssClass="txtMemo" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <asp:PlaceHolder ID="phCheckState" runat="server">
            <tr>
                <td class="tdLeft">��ǰ״̬��
                </td>
                <td class="tdRight">
                    <asp:Literal ID="liteCheckState" runat="server"></asp:Literal>
                </td>
            </tr>
        </asp:PlaceHolder>
        <tr>
            <td class="tdLeft"></td>
            <td class="tdRight">
                <asp:Button ID="btnSubmit" runat="server" Text="�ύ����" OnClick="btnSubmit_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

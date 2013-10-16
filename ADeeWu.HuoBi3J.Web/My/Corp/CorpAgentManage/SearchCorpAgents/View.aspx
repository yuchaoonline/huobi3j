<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="View.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.CorpAgentManage.SearchCorpAgents.View" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControls" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
�̼ҿ������ - �鿴�����̼���
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">��</span><a href="/My/Corp/CorpAgentManage/SearchCorpAgents/">���Ҵ�����</a><span class="spl">��</span><span class="curPos">�鿴�����̼���</span>
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <asp:HiddenField ID="hfUserID" runat="server" />
<table class="formTable">
        <tr>
            <td class="tdLeft">
            ��ʵ������
            </td>
            <td class="tdRight">
                <asp:Literal ID="liteRealName" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">
            ��&nbsp;&nbsp;&nbsp;&nbsp;��
            </td>
            <td class="tdRight">
                 <asp:Literal ID="liteSex" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">
            �������ڣ�
            </td>
            <td class="tdRight">
                <asp:Literal ID="liteBirthday" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">
            ���ڵ�����
            </td>
            <td class="tdRight">
               <asp:Literal ID="liteLocation" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">
            �����ַ��
            </td>
            <td class="tdRight">
               <asp:Literal ID="liteAddress" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">
            �������룺
            </td>
            <td class="tdRight">
                <asp:Literal ID="liteZipCode" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">
            ѧ&nbsp;&nbsp;&nbsp;&nbsp;����
            </td>
            <td class="tdRight">
               <asp:Literal ID="liteEducation" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">
            �������飺
            </td>
            <td class="tdRight">
                <asp:Literal ID="liteWorkExp" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">
            ��ҵѧУ��
            </td>
            <td class="tdRight">
                <asp:Literal ID="liteSchool" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">
            ר&nbsp;&nbsp;&nbsp;&nbsp;ҵ��
            </td>
            <td class="tdRight">
                <asp:Literal ID="liteSpeciality" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">
            ��&nbsp;&nbsp;&nbsp;&nbsp;�ܣ�
            </td>
            <td class="tdRight">
                <asp:Literal ID="liteSkill" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">��&nbsp;&nbsp;&nbsp;&nbsp;ע��</td>
            <td class="tdRight">
            <asp:Literal ID="liteNote" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">����ʱ�䣺</td>
            <td class="tdRight">
            <asp:Literal ID="liteCreateTime" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="tdLeft"></td>
            <td class="tdRight">
                <asp:PlaceHolder ID="ph01" runat="server">
                <asp:Button ID="btnSubmit" runat="server" Text="����" onclick="btnSubmit_Click" /> <span class="strew">���ύ���벢��ͨ����˺�˫����ϵ���ղŻ�ȷ��������(�̼�������Ӫ��������)</span>
                </asp:PlaceHolder>
                <asp:PlaceHolder ID="ph02" runat="server">
                <span class="strew">���û��ѳ�Ϊ����ҵ/��˾��Ӫ��������</span>
                </asp:PlaceHolder>
            </td>
        </tr>
    </table>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>


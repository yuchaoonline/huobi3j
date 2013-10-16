<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.TradeOrders.Order" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    ���˿������ - ���߳�ֵ
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <span class="spl"></span><a href="/My/User/TradeOrders/">�ҵĳ�ֵ����</a><span class="spl">��</span><span class="curPos">���߳�ֵ</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <asp:PlaceHolder ID="phForm" runat="server">
        <table class="formTable">
            <tr>
                <td class="tdLeft"></td>
                <td class="tdRight">���߳�ֵ��������ͨ��֧��������֧��,֧���ɹ��������ʻ��ｫ�õ���Ӧ�Ľ��
                </td>
            </tr>
            <tr>
                <td class="tdLeft">��ֵ��</td>
                <td class="tdRight">
                    <asp:TextBox ID="txtMoney" runat="server" Width="60px"></asp:TextBox>
                    Ԫ<span class="require">*</span><span class="tips">����������������</span>
                    <asp:RequiredFieldValidator ID="rfvMoney" runat="server" ErrorMessage="�������ֵ���" ControlToValidate="txtMoney" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revMoney" runat="server" ErrorMessage="����д���������" ControlToValidate="txtMoney" Display="Dynamic" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="tdLeft"></td>
                <td class="tdRight">
                    <asp:Button ID="btnSubmit" runat="server" Text="�¶���"
                        OnClick="btnSubmit_Click" />
                </td>
            </tr>
        </table>
    </asp:PlaceHolder>

    <asp:PlaceHolder ID="phResult" runat="server" Visible="false">
        <div style="font-size: 16px; font-weight: bold;">
            �����ɹ������Ķ�����Ϊ��<span style="color: Red;"><asp:Literal ID="liteOrderCode" runat="server"></asp:Literal></span>
        </div>
        <div style="margin-top: 5px;">
            ����֧�� <span style="color: Red; font-weight: bold;">
                <asp:Literal ID="liteTotalFee" runat="server"></asp:Literal></span> Ԫ
            <a href="PayNow.aspx?order=<%=this.liteOrderCode.Text %>">����֧��</a>
        </div>
    </asp:PlaceHolder>

</asp:Content>



<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Default" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="ADeeWuControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    ���˿������ - ��������
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .item {
            margin-bottom: 20px;
        }

        .itemTitle {
            font-weight: bold;
            border-bottom: 1px dotted #ccc;
            margin-bottom: 10px;
            height: 24px;
            line-height: 24px;
        }

            .itemTitle span {
                float: right;
                font-weight: normal;
            }
    </style>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <span class="spl"></span><span class="curPos">��������</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <%if (this.entUser != null)
      { %>

    <div class="box">
        <div class="box_head1">
            <label class="fb font14 black70">������Ϣ</label>
        </div>
        <div class="box_body">
            <table>
                <tbody>
                    <tr height="35px">
                        <td class="tr">��½�ʺţ�</td>
                        <td class="font14 black4B"><%=this.entUser.LoginName %></td>
                    </tr>
                    <tr height="35px">
                        <td class="tr">�ܡ����룺</td>
                        <td class="font14 black4B"><a href="Password.aspx">�޸�</a></td>
                    </tr>
                    <tr height="35px">
                        <td class="tr">�û����ƣ�</td>
                        <td class="font14 black4B">
                            <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr height="35px">
                        <td class="tr">ȫ��ͨѶUIN��</td>
                        <td class="font14 black4B"><%=this.entUser.UIN %></td>
                    </tr>
                    <tr height="35px">
                        <td class="tr">�û����ͣ�</td>
                        <td class="font14 black4B">
                            <%= ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                        this.entUser.UserType.ToString(),
						"",
                        new string[][]{
                            new string[]{"0","�����û�(��ͨ�û�)"},
                            new string[]{"1","��ҵ�û�(�̼�)"},
                            new string[]{"2","�̼Ҵ���(����Ӫ��������)"}
                        }               
                        )
                            %></td>
                    </tr>
                    <tr height="35px">
                        <td class="tr">�û�״̬��</td>
                        <td class="font14 black4B">
                            <%= ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                        this.entUser.CheckState.ToString(),
						"",
                        new string[][]{
                            new string[]{"0","δͨ�����"},
                            new string[]{"1","����ʹ����"},
                            new string[]{"2","�û��ʺ���Ч"},
							new string[]{"3","�û��ʺ��ѹ���"}
                        }               
                        )
                            %>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>

    <div class="box">
        <div class="box_head1">
            <label class="fb font14 black70">��ϵ��ʽ</label>
        </div>
        <div class="box_body">
            <table>
                <tbody>
                    <tr height="35px">
                        <td class="tr">��ϵ�绰��</td>
                        <td class="font14 black4B">
                            <asp:TextBox ID="txtTel" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr height="35px">
                        <td class="tr">E-mail��</td>
                        <td class="font14 black4B">
                            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr height="35px">
                        <td class="tr">����������</td>
                        <td class="font14 black4B">
                            <ADeeWuControl:SyncSelector ID="syncSelectorLocation" runat="server"
                                DataSourceURL="<%$Resources:SyncSelector,Location_DataSourceURL %>"
                                DataSourceName="<%$Resources:SyncSelector,Location_DataSourceName %>"
                                ClientPostNames="<%$Resources:SyncSelector,Location_ClientPostNames %>" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>

    <div class="box">
        <div class="box_head1">
            <label class="fb font14 black70">�ʻ���Ϣ</label>
        </div>
        <div class="box_body">
            <table>
                <tbody>
                    <tr height="35px">
                        <td class="tr">�ʻ���</td>
                        <td class="font14 black4B"><%=string.Format("{0:0.00}",this.entUser.Money) %>Ԫ | <a href="VMoney/">��ʷ��¼</a></td>
                    </tr>
                    <tr height="35px">
                        <td class="tr">�������ң�</td>
                        <td class="font14 black4B"><%=this.entUser.Coins %>�� | <a href="Coins/">��ʷ��¼</a></td>
                    </tr>
                    <tr height="35px">
                        <td class="tr">�������֣�</td>
                        <td class="font14 black4B">
                            <%=this.entUser.Points %>
                        </td>
                    </tr>
                    <tr height="35px">
                        <td class="tr">֧�����ʺţ�</td>
                        <td class="font14 black4B">
                            <asp:TextBox ID="txtAlipayAccount" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>

    <div class="box">
        <div class="box_head1">
            <label class="fb font14 black70">ע��/��½��Ϣ</label>
        </div>
        <div class="box_body">
            <table>
                <tbody>
                    <tr height="35px">
                        <td class="tr">ע��ʱ�䣺</td>
                        <td class="font14 black4B"><%=this.entUser.RegTime %></td>
                    </tr>
                    <tr height="35px">
                        <td class="tr">�ϴε�½��</td>
                        <td class="font14 black4B"><%=this.entUser.LastLogin %></td>
                    </tr>
                    <tr height="35px">
                        <td class="tr">��½������</td>
                        <td class="font14 black4B">
                            <%=this.entUser.LoginTimes %>��
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>

    <div align="center">
        <asp:Button ID="btnSubmit" runat="server" Text="�޸�����" OnClick="btnSubmit_Click" />
    </div>

    <%} %>
</asp:Content>




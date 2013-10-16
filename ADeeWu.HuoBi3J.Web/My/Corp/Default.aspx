<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.Default" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    �̼ҿ������ - ��������
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <span class="spl"></span><span class="curPos">��������</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

    <%if (this.entCorp != null)
      { %>

    <div class="box">
        <div class="box_head1">
            <label class="fb font14 black70">��̬��Ϣ</label>
        </div>
        <div class="box_body">
            <table>
                <tbody>
                    <%if (this.LoginUser.IsCashTicketPartner)
                      {%>
                    <tr height="35px">
                        <td class="tr">�ֽ�����ȯ��</td>
                        <td class="font14 black4B">
                            <label class="orange ">
                                <asp:Literal ID="liteNumOfCashTickets" runat="server"></asp:Literal></label>
                            ��</td>
                    </tr>
                    <%}%>
                    <%if (this.LoginUser.IsPromotionCorp)
                      {%>
                    <tr height="35px">
                        <td class="tr">�̼��ƹ㣺</td>
                        <td class="font14 black4B">������
                            <label class="orange">
                                <asp:Literal ID="liteNumOfPromotionKeys" runat="server"></asp:Literal></label>
                            ���ؼ���</td>
                    </tr>
                    <%}%>
                    <tr height="35px">
                        <td class="tr">������Ƹ��</td>
                        <td class="font14 black4B">�ѷ���
                            <label class="orange">
                                <asp:Literal ID="liteNumOfJobs" runat="server"></asp:Literal></label>
                            ��ְλ</td>
                    </tr>
                    <tr height="35px">
                        <td class="tr">����Ӫ����</td>
                        <td class="font14 black4B">�ѷ���
                            <label class="orange">
                                <asp:Literal ID="liteNumOfProducts" runat="server"></asp:Literal></label>
                            ����Ʒ���ͻ�������<label class="orange"><asp:Literal ID="liteOrders" runat="server"></asp:Literal></label>
                            ��</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>

    <div class="box">
        <div class="box_head1">
            <label class="fb font14 black70">��ҵ��Ϣ</label>
        </div>
        <div class="box_body">
            <table>
                <tbody>
                    <tr height="35px">
                        <td class="tr black70" width="77px">��˾���ƣ�</td>
                        <td class="font14 black4B">
                            <asp:TextBox ID="txtCorpName" runat="server" CssClass="txtBox" Width="300" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr height="35px">
                        <td class="tr black70" width="77px">�С���ҵ��</td>
                        <td class="font14 black4B">
                            <IscControl:SyncSelector ID="syncSelectorCalling" runat="server"
                                DataSourceURL="<%$Resources:SyncSelector,Calling_DataSourceURL %>"
                                DataSourceName="<%$Resources:SyncSelector,Calling_DataSourceName %>"
                                ClientPostNames="<%$Resources:SyncSelector,Calling_ClientPostNames %>" />
                        </td>
                    </tr>
                    <tr height="35px">
                        <td class="tr black70" width="77px">�ԡ����ʣ�</td>
                        <td class="font14 black4B">
                            <asp:DropDownList ID="ddlProperty" runat="server">
                                <asp:ListItem Value="���廧">���廧</asp:ListItem>
                                <asp:ListItem Value="˽Ӫ��ҵ">˽Ӫ��ҵ</asp:ListItem>
                                <asp:ListItem Value="������ҵ">������ҵ</asp:ListItem>
                                <asp:ListItem Value="�������ι�˾">�������ι�˾</asp:ListItem>
                                <asp:ListItem Value="�ɷ����޹�˾">�ɷ����޹�˾</asp:ListItem>
                                <asp:ListItem Value="����">����</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr height="35px">
                        <td class="tr black70" width="77px">�桡��ģ��</td>
                        <td class="font14 black4B">
                            <asp:DropDownList ID="ddlEmployees" runat="server">
                                <asp:ListItem Value="����50��">����50��</asp:ListItem>
                                <asp:ListItem Value="50-149��">50-149��</asp:ListItem>
                                <asp:ListItem Value="150-499��">150-499��</asp:ListItem>
                                <asp:ListItem Value="500-999��">500-999��</asp:ListItem>
                                <asp:ListItem Value="1000������">1000������</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr height="35px">
                        <td class="tr black70" width="77px">�� �� �ˣ�</td>
                        <td class="font14 black4B">
                            <asp:TextBox ID="txtLinkMan" runat="server" CssClass="txtBox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr height="35px">
                        <td class="tr black70" width="77px">��ϵ�绰��</td>
                        <td class="font14 black4B">
                            <asp:TextBox ID="txtTel" runat="server" CssClass="txtBox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr height="35px">
                        <td class="tr black70" width="77px">����������</td>
                        <td class="font14 black4B">
                            <IscControl:SyncSelector ID="syncSelectorLocation" runat="server"
                                DataSourceURL="<%$Resources:SyncSelector,Location_DataSourceURL %>"
                                DataSourceName="<%$Resources:SyncSelector,Location_DataSourceName %>"
                                ClientPostNames="<%$Resources:SyncSelector,Location_ClientPostNames %>" />
                        </td>
                    </tr>
                    <tr height="35px">
                        <td class="tr black70" width="77px">��˾��ַ��</td>
                        <td class="font14 black4B">
                            <asp:TextBox ID="txtAddress" runat="server" Width="300" CssClass="txtAddress"></asp:TextBox>
                        </td>
                    </tr>
                    <tr height="35px">
                        <td class="tr black70" width="77px">�������꣺</td>
                        <td class="font14 black4B">
                            <asp:TextBox ID="txtLat" runat="server" Width="200px" /><br />
                            ���� -
                    <asp:TextBox ID="txtLng" runat="server" Width="200px" /><br />
                            <a href="/Map/?lat=<%=this.txtLat.Text%>&lng=<%=this.txtLng.Text%>&title=<%=HttpUtility.HtmlEncode(this.txtCorpName.Text)%>&summary=<%=HttpUtility.HtmlEncode(this.txtAddress.Text)%>" target="_blank">�鿴��ǰ��ͼλ��</a> | <a href="/Map/GetPosition.html" target="_blank">��ȡ��ͼ����</a>(�ڵ�ͼ�϶�λ�󣬰Ѷ�Ӧ��γ�ȡ�������ֵճ�����ı�����)
                        </td>
                    </tr>
                    <tr height="35px">
                        <td class="tr black70" width="77px">��˾���ܣ�</td>
                        <td class="font14 black4B">
                            <asp:TextBox ID="txtIntro" runat="server" TextMode="MultiLine" Rows="20" Columns="70" CssClass="txtNotes"></asp:TextBox>
                        </td>
                    </tr>
                    <tr height="35px">
                        <td class="tr black70" width="77px">���״̬��</td>
                        <td class="font14 black4B">
                            <label class="orange font14">
                                <%= ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                    this.entCorp.CheckState.ToString(),
                    "",
                    new string[][]{
						new string[]{"0","δͨ�����"},
						new string[]{"1","�����"},
						new string[]{"2","��Ч"},
						new string[]{"3","�ѹ���"}
					}
                    )
                                %></label>
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
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">
</asp:Content>




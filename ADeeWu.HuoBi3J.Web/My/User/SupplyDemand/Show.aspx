<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.SupplyDemand.Show" EnableEventValidation="false" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="CashTicketControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    �ֽ�ȯ������ - �ҵ��ʻ�
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <a href="/Account/Default.aspx">�ҵ��ʻ���ҳ</a> &gt; ��Ͷ����  &gt; ����Ͷ����Ϣ
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

    <div>

        <table width="95%" border="0" cellspacing="0" cellpadding="0" align="center" style="background-color: #eeeeee; border: 1px solid green; margin-top: 5px">
            <tr>
                <td style="width: 0%">&nbsp;</td>
                <td width="35%" style="width: 17%">&nbsp;</td>
                <td width="65%" style="width: 70%;">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">&nbsp; ���⣺<asp:Literal ID="litTitle" runat="server"></asp:Literal>
                    &nbsp;����ʱ�䣺<asp:Literal ID="litCreateTime" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td
                    style="cursor: pointer; border-top: 1px solid #9DD89D; text-align: left" valign="top">&nbsp;
      ������</td>
                <td colspan="2"
                    style="cursor: pointer; border-top: 1px solid #9DD89D; text-align: left">
                    <asp:Literal ID="litSummary" runat="server"></asp:Literal>
                </td>
            </tr>

            <tr>
                <td
                    style="cursor: pointer; border-top: 1px solid #9DD89D; text-align: left" valign="top">&nbsp; ���ݣ�</td>
                <td colspan="2"
                    style="cursor: pointer; border-top: 1px solid #9DD89D; text-align: left">
                    <asp:Literal ID="litContent" runat="server"></asp:Literal>
                </td>
            </tr>

            <tr>
                <td colspan="3"
                    style="cursor: pointer; border-top: 1px solid #9DD89D; text-align: left">&nbsp; 
                </td>
            </tr>

            <tr>
                <td colspan="3"
                    style="cursor: pointer; border-top: 1px solid #9DD89D; text-align: center"></td>
            </tr>

            <tr id="Tr1">
                <td colspan="3" style="border-top: 1px solid #9DD89D">&nbsp; ������Ͷ����Ϣ��</td>
            </tr>
        </table>

        <asp:Repeater ID="rptData" runat="server" OnItemCommand="rptData_ItemCommand">
            <ItemTemplate>
                <table width="95%" border="0" cellspacing="0" cellpadding="0" align="center" style="background-color: #eeeeee; border: 1px solid green; margin-top: 5px">
                    <tr>
                        <td width="43%">&nbsp;&nbsp;Ͷ��ʱ�䣺<%# Eval("SD_BiddersModifyTime")%></td>
                        <td width="20%" style="width: 57%;">&nbsp;
               Ͷ���ˣ�<%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(Eval("CorpName").ToString().Trim(),
                           Eval("CorpName").ToString().Trim(),
                        new string[][]{
                            new string[]{"", Eval("Name").ToString().Trim()},
                        }               
                        )
               %>  &nbsp; &nbsp;
                    <asp:LinkButton ID="lbtnBidders" Visible='<%# Eval("Status").ToString()=="1"?false:true %>' runat="server" CommandName="Bidder" CommandArgument='<%# Eval("SD_BiddersID") %>'>����Ͷ����Ϣ��Ϊ�б���</asp:LinkButton>
                            <span><%# Eval("SD_BiddersStatus").ToString() == "1" ? "���б�" :"δ�б�"%></span>
                        </td>

                    </tr>
                    <tr>
                        <td colspan="2" style="cursor: pointer; border-top: 1px solid #9DD89D; text-align: left">&nbsp; Ͷ�����ݣ�</td>
                    </tr>

                    <tr>
                        <td colspan="2"
                            style="cursor: pointer; border-top: 1px solid #9DD89D; text-align: left">&nbsp;
              <%# Eval("SD_BiddersContent")%>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="2"
                            style="cursor: pointer; border-top: 1px solid #9DD89D; text-align: center"></td>
                    </tr>


                </table>
            </ItemTemplate>
        </asp:Repeater>

        <div class="pager" style="text-align: center">
            <CashTicketControl:Pager ID="Pager1" runat="server" ShowTextOnError="û�в�ѯ��Ͷ����Ϣ��" />
        </div>



    </div>

</asp:Content>




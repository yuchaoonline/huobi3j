<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.SupplyDemand.Show" EnableEventValidation="false" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="CashTicketControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    现金券赠送网 - 我的帐户
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <a href="/Account/Default.aspx">我的帐户首页</a> &gt; 竞投报价  &gt; 管理投标信息
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
                <td colspan="3">&nbsp; 标题：<asp:Literal ID="litTitle" runat="server"></asp:Literal>
                    &nbsp;发布时间：<asp:Literal ID="litCreateTime" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td
                    style="cursor: pointer; border-top: 1px solid #9DD89D; text-align: left" valign="top">&nbsp;
      简述：</td>
                <td colspan="2"
                    style="cursor: pointer; border-top: 1px solid #9DD89D; text-align: left">
                    <asp:Literal ID="litSummary" runat="server"></asp:Literal>
                </td>
            </tr>

            <tr>
                <td
                    style="cursor: pointer; border-top: 1px solid #9DD89D; text-align: left" valign="top">&nbsp; 内容：</td>
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
                <td colspan="3" style="border-top: 1px solid #9DD89D">&nbsp; 以下是投标信息：</td>
            </tr>
        </table>

        <asp:Repeater ID="rptData" runat="server" OnItemCommand="rptData_ItemCommand">
            <ItemTemplate>
                <table width="95%" border="0" cellspacing="0" cellpadding="0" align="center" style="background-color: #eeeeee; border: 1px solid green; margin-top: 5px">
                    <tr>
                        <td width="43%">&nbsp;&nbsp;投标时间：<%# Eval("SD_BiddersModifyTime")%></td>
                        <td width="20%" style="width: 57%;">&nbsp;
               投标人：<%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(Eval("CorpName").ToString().Trim(),
                           Eval("CorpName").ToString().Trim(),
                        new string[][]{
                            new string[]{"", Eval("Name").ToString().Trim()},
                        }               
                        )
               %>  &nbsp; &nbsp;
                    <asp:LinkButton ID="lbtnBidders" Visible='<%# Eval("Status").ToString()=="1"?false:true %>' runat="server" CommandName="Bidder" CommandArgument='<%# Eval("SD_BiddersID") %>'>将该投标信息设为中标项</asp:LinkButton>
                            <span><%# Eval("SD_BiddersStatus").ToString() == "1" ? "已中标" :"未中标"%></span>
                        </td>

                    </tr>
                    <tr>
                        <td colspan="2" style="cursor: pointer; border-top: 1px solid #9DD89D; text-align: left">&nbsp; 投标内容：</td>
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
            <CashTicketControl:Pager ID="Pager1" runat="server" ShowTextOnError="没有查询到投标信息！" />
        </div>



    </div>

</asp:Content>




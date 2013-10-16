<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="CustomerAjax.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.CorpAgent.CustomerAjax" %>

<asp:PlaceHolder ID="phResponse" runat="server">

    <div class="ShowLayer-AgentName">
        <asp:Literal ID="liteAgentName" runat="server"></asp:Literal>
        的线下用户:
    </div>

    <asp:Repeater ID="rpData" runat="server" OnItemDataBound="rpData_ItemDataBound">
        <ItemTemplate>
            <asp:Literal ID="liteCustomerUserID" runat="server" Text='<%#Eval("CustomerUserID") %>' Visible="false"></asp:Literal>
            <dl>
                <dt>
                    <%#ADeeWu.HuoBi3J.Libary.Utility.GetStr(true, "", Eval("CustomerUIN"), Eval("CustomerLoginName"))%>
                </dt>

                <dd>
                    <asp:Repeater ID="rpSub" runat="server">
                        <ItemTemplate>
                            <em <%#this.getClickFn((long)Eval("AgentUserID"))%>><%#ADeeWu.HuoBi3J.Libary.Utility.GetStr(true, "", Eval("CustomerUIN"), Eval("CustomerLoginName"))%></em>
                        </ItemTemplate>
                    </asp:Repeater>
                </dd>
            </dl>
        </ItemTemplate>
    </asp:Repeater>

</asp:PlaceHolder>

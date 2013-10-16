<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Shops.Orders.AfterSaleRecords.View" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    个人控制面板 - 查看售后服务记录
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <span class="spl"></span><a href="/My/User/Shops/Orders/AfterSaleRecords/">售后服务</a><span class="spl">　</span><span class="curPos">查看</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

    <table class="formTable">
        <tr>
            <td class="tdLeft">订 单 号:
            </td>
            <td class="tdRight">
                <asp:Label ID="lblOrderCode" runat="server" CssClass="txtBox" ReadOnly="true" />
            </td>
        </tr>
        <%--<tr>
	<td class="tdLeft">
		商家名称:
	</td>
	<td class="tdRight">
		<asp:Label ID="lblCorpID" runat="server" CssClass="txtBox" ReadOnly="true" />
	</td>
</tr>--%>
        <tr>
            <td class="tdLeft">产品名称:
            </td>
            <td class="tdRight">
                <asp:Label ID="lblProductName" runat="server" CssClass="txtBox" ReadOnly="true" />
            </td>
        </tr>

        <tr>
            <td class="tdLeft">日　　期:
            </td>
            <td class="tdRight">
                <IscControl:DateTimeSelector ID="txtCreatTime" runat="server"></IscControl:DateTimeSelector>
            </td>
        </tr>


        <tr>
            <td class="tdLeft">处理结果： 	</td>
            <td>&nbsp;<asp:Label ID="lblResult" runat="server" />
                <%--<asp:RadioButton ID="cboExit" GroupName="state" runat="server" Checked="true"
			Text="退货" />
		<asp:RadioButton ID="cboSwap" GroupName="state" runat="server" Text="换货" />
		&nbsp;<asp:RadioButton ID="cboRepail" GroupName="state" runat="server" Text="维修" />--%>
                <%--&nbsp;<asp:RadioButton ID="cboStateEnd" GroupName="state" runat="server" Text="完成" />--%>
            </td>
        </tr>

        <tr>
            <td class="tdLeft">备　　注:
            </td>
            <td class="tdRight">
                <asp:Label ID="lblNote" runat="server" CssClass="txtBox" />
            </td>
        </tr>
        <tr>
            <td class="tdLeft">
                <a href="javascript:histroy.back();">返回</a>
            </td>
            <td class="tdRight"></td>
        </tr>
    </table>

    <div class="pager">
        <IscControl:Pager ID="Pager1" runat="server" />
    </div>



</asp:Content>

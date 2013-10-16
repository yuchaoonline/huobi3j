<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Service.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.Service" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
商家控制面板 - 特色服务/经营范围
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">　</span><span class="curPos">特色服务/经营范围</span>
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
<table class="formTable">
	<tr>
        <td class="tdLeft">特色服务/经营范围：</td>
        <td class="tdRight">
			<asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Width="100%" 
                        Height="200" CssClass="txtNotes"></asp:TextBox><asp:RequiredFieldValidator ID="rfvContent"
                            runat="server" ErrorMessage="请填写内容！" ControlToValidate="txtContent" Display="Dynamic"></asp:RequiredFieldValidator><span class="require">
            *</span>
                            <div class="tips">
                                请填写贵公司的经营范围或特色服务。如有发现违法内容，立即停止使用！
                            </div>
		</td>
    </tr>
    <tr>
        <td class="tdLeft"></td>
        <td class="tdRight">
            <asp:Button ID="btnSubmit" runat="server" Text="提交" onclick="btnSubmit_Click" />
		</td>
    </tr>
</table>



</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>




<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="Edit.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.SupplyDemand.Edit"   ValidateRequest="false"%>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register assembly="ADeeWu.HuoBi3J.WebUI" namespace="ADeeWu.HuoBi3J.WebUI" tagprefix="CashTicketControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
无标题文档
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
&nbsp;</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>竞投报价</span> &gt; <a href="List.aspx">列表</a> &gt 修改
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    
    <div>
    <table width="100%" border="0" cellspacing="1" cellpadding="5">
			<tr>
                <td valign="top" width="100">标题：</td>
                <td valign="top" >
                    <asp:TextBox ID="txtTitle" runat="server" Width="50%" CssClass="txtBox"></asp:TextBox>
                    <span class="require">*</span></td>
                <td valign="top" >&nbsp;
                    </td>
            </tr>
             <tr>
                <td valign="top">推荐：</td>
                <td valign="top" colspan="2" >
                    
                    <asp:CheckBox ID="cboIsRecommend" runat="server" />
                </td>
            </tr>
            <tr>
                <td valign="top">隐藏：</td>
                <td valign="top" colspan="2" >
                    
                    <asp:CheckBox ID="cboIsHidden" runat="server" />
                </td>
            </tr>
              <tr>
                <td valign="top">审核状态：</td>
                <td valign="top" colspan="2" >
                    
                    <asp:RadioButton ID="radstate"  GroupName="state" runat="server" Checked=true Text="不修改状态" />
               <asp:RadioButton ID="cbochecktrue" GroupName="state" runat="server" Text="通过" />
                    &nbsp;<asp:RadioButton ID="cbocheckfalse" GroupName="state"  runat="server" Text="不通过" />
                    &nbsp;<asp:RadioButton ID="cboStateEnd"  GroupName="state" runat="server" Text="标记为过期" />

                </td>
            </tr>
              <tr>
			  <td valign="top">创建时间：</td>
			  <td valign="top" >
                  <asp:Literal ID="litCreateTime" runat="server"></asp:Literal>
              </td>
			  <td valign="top" >&nbsp;</td>
		    </tr>
            <tr>
			  <td valign="top">最后修改时间：</td>
			  <td valign="top" ><asp:Literal ID="litModifyTime" runat="server"></asp:Literal></td>
			  <td valign="top" >&nbsp;</td>
		    </tr>
			<tr>
			  <td valign="top">最后刷新时间：</td>
			  <td valign="top" ><asp:Literal ID="litRefreshTime" runat="server"></asp:Literal></td>
			  <td valign="top" >&nbsp;</td>
		    </tr>
			<tr>
                <td valign="top" width="100">截止时间：</td>
              <td valign="top" >
                    <CashTicketControl:DateTimeSelector ID="txtEndTime" runat="server"></CashTicketControl:DateTimeSelector><span class="require">
                    *</span>
             </td>
             <td valign="top" >&nbsp;</td>
            </tr>
             <tr>
			  <td valign="top">访问次数：</td>
			  <td valign="top" ><asp:Literal ID="litVisitCount" runat="server"></asp:Literal></td>
			  <td valign="top" >&nbsp;</td>
		    </tr>
		   
			<tr>
                <td valign="top">简述：</td>
                <td valign="top" >
                    <asp:TextBox ID="txtSummary" runat="server" TextMode="MultiLine" Width="99%" 
                        Height="72px"></asp:TextBox>
				</td>
                <td valign="bottom" width="5">
                    <span class="require">*</span></td>
            </tr>
			<tr>
                <td valign="top">详细：</td>
                <td valign="top" >
                    <FCKeditorV2:FCKeditor ID="txtContent" ToolbarSet="Basic" runat="server" Width="100%" Height="200" LinkBrowserURL="false"></FCKeditorV2:FCKeditor>
                    
				</td>
                <td valign="bottom"  width="3">
                    <span class="require">*</span></td>
            </tr>
            <tr>
                <td >&nbsp; &nbsp;
                    </td>
                <td colspan="2">
                     <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="保存" />
                      
                </td>
            </tr>
        </table>
    </div>
    
</asp:Content>


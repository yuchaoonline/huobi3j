<%@ Page Language="C#" Title="" MasterPageFile="~/MIndex.master"  AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Cashtickets.Default" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="ADeeWuControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
现金赠送
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<style type="text/css">

.AppForm{ background:url(../images/CashTicket_App.gif) no-repeat; width:907px; height:297px; margin:40px auto 0px; }
.FormSide{ float:left; width:450px; height:297px; color:#666; }
.FormSide input{ border:1px solid #7f9cba; }
.FormSide textarea{ border:1px solid #7f9cba; font-size:12px; }
.FormSide .tdLeft{ text-align:right; font-weight:bold; }
.FormSide a{ color:#296fb4; }
.FormSide-Wrap{ padding:20px; padding-top:50px; }

.TipsSide{ float:right; width:275px; height:297px; margin-top:30px; padding-right:30px; }

dt{ font-weight:bold;  line-height:24px; color:#cd361d; font-size:14px; margin-bottom:5px; }
dd{ text-indent:20px; line-height:24px; margin-bottom:10px; font-size:14x; color:#666; }
ol{ margin:0px;  padding:0px; }
ol li{ list-style-position:inside; margin:0px; padding:0px; text-indent:0px; margin-bottom:5px; line-height:100%; }
</style>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">

<div class="AppForm">
	
	<div class="FormSide">
		<div class="FormSide-Wrap">
		<table border="0" cellspacing="0" cellpadding="0" class="formtabl">
		  <tr>
			<td class="tdLeft">商家名称：</td>
			<td class="tdRight">
				<asp:TextBox ID="txtCorpName" runat="server"></asp:TextBox></td>
			</tr>
		  <tr>
			<td class="tdLeft">消费金额：</td>
			<td class="tdRight"><asp:TextBox ID="txtCostMoney" runat="server" CssClass="txtNum"></asp:TextBox><span class="tips">元</span><span class="require">*</span></td>
		  </tr>
		  <tr>
			<td class="tdLeft">消费金额确认：</td>
			<td class="tdRight"><asp:TextBox ID="txtCostMoney2" runat="server" CssClass="txtNum"></asp:TextBox><span class="require">* 请确认实际消费金额，提交后不能修改</span></td>
		  </tr>
			<tr>
			  <td class="tdLeft">消费日期：</td>
				<td class="tdRight">
				<ADeeWuControl:DateTimeSelector ID="txtCostDate" runat="server" CssClass="txtDate"></ADeeWuControl:DateTimeSelector><span class="require">*</span>
				</td>
		  </tr>
			<tr>
			  <td class="tdLeft">现金券序列号：</td>
			  <td class="tdRight"><asp:TextBox ID="txtCashTicketSerialNum" runat="server"></asp:TextBox><span class="require">*</span></td>
			</tr>
			<tr>
			  <td class="tdLeft">现金券验证码：</td>
			  <td class="tdRight"><asp:TextBox ID="txtCashTicketValidCode" runat="server"></asp:TextBox><span class="require">*</span></td>
			</tr>
			<tr>
			  <td class="tdLeft">具体商品及金额：</td>
			  <td class="tdRight">
			  <asp:TextBox ID="txtSummary" runat="server" Height="30px" TextMode="MultiLine" 
                Width="200px"></asp:TextBox><span class="require">*</span>
			  </td>
			</tr>
			
			<tr>
			<td class="tdLeft">&nbsp;</td>
			<td class="tdRight">
				<asp:Button ID="btnSubmit" runat="server" Text="提交" onclick="btnSubmit_Click"  />
				<asp:HyperLink ID="linkTips" runat="server" Text="当前还没有登陆会员帐号?" Visible="false" NavigateUrl="/Register.aspx"></asp:HyperLink>
			  </td>
		  </tr>
		</table>
		</div><!--class="FormSide-Wrap"-->
	</div>
	
	<div class="TipsSide">
		<dl>
			<dt>何为现金赠送</dt>
			<dd>现金赠送即顾客在全民营销网合作商家消费后获得全民营销收据上的序列号和密码，登陆全民营销网填写赠送序列号和密码等相关信息并获得现金赠送。</dd>
		</dl>
		
		<dl style="margin-left:40px; margin-top:20px;">
			<dt>现金赠送券使用流程</dt>
			<dd>
				<ol>
					<li>到全民营销网合作商家消费</li>
					<li>获得全民营销收据上的序列号和密码</li>
					<li>登陆www.ADeeWu.HuoBi3J.com</li>
					<li>申请现金赠送</li>
					<li>获得现金赠送</li>
				</ol>
			</dd>
		</dl>
	</div>
	
	<div class="break"></div>
	
</div>






</asp:Content>
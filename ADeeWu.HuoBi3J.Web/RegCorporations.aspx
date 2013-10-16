<%@ Page Language="C#" Title="" MasterPageFile="~/MIndex.master"  AutoEventWireup="true" CodeBehind="RegCorporations.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.RegCorporations" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
全民营销网 - 用户注册
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="/js/isc.js"></script>
<script type="text/javascript">
$(document).ready(function(){
	$('#hrefShowPosition').click(function(){
		var addr = $('#<%=this.txtAddress.ClientID%>').val();
		addr = $.trim(addr);
		if(addr.length>0){
			isc.cookie.set('getposition_addr',addr,new isc.DateTime().addDays(1).currentDate(),null,ADeeWu.HuoBi3J.domain,false);
		}
	});
});
</script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
<!--____________________________begin商家注册信息输入____________________________________-->
<table  border="0" align="center" cellpadding="0" cellspacing="0" style="width:75%">

     <tr>
    <td class="tdLeft">&nbsp;</td>
    <td class="tdRight">
        商家注册</td>
  </tr>

     <tr>
    <td class="tdLeft">商家名称：</td>
    <td class="tdRight">
       <asp:TextBox ID="txtName" runat="server" CssClass="txtBox" ></asp:TextBox> <span class="require">*</span>    </td>
  </tr>
  <tr>
    <td class="tdLeft">联系人：</td>
    <td class="tdRight">
       <asp:TextBox ID="txtLinkMan" runat="server" CssClass="txtBox" ></asp:TextBox> <span class="require">*</span>    </td>
  </tr>
  <tr>
    <td class="tdLeft">公司电话：</td>
    <td class="tdRight">
       <asp:TextBox ID="txtTel" runat="server" CssClass="txtBox" ></asp:TextBox> <span class="require">*</span>    </td>
  </tr>
   <tr>
    <td class="tdLeft">经营行业：</td>
    <td class="tdRight">
        <IscControl:SyncSelector ID="syncSelectorCalling" runat="server" 
        DataSourceURL="<%$Resources:SyncSelector,Calling_DataSourceURL %>" 
        DataSourceName="<%$Resources:SyncSelector,Calling_DataSourceName %>" 
        ClientPostNames="<%$Resources:SyncSelector,Calling_ClientPostNames %>"
        />&nbsp;<span class="require">*</span>    </td>
  </tr>
  <tr>
    <td class="tdLeft">所属地区：</td>
    <td class="tdRight">
        <IscControl:SyncSelector ID="syncSelectorLocation" runat="server" 
        DataSourceURL="<%$Resources:SyncSelector,Location_DataSourceURL %>" 
        DataSourceName="<%$Resources:SyncSelector,Location_DataSourceName %>" 
        ClientPostNames="<%$Resources:SyncSelector,Location_ClientPostNames %>"
        />
        &nbsp;<span class="require">*</span>    </td>
  </tr>
  <tr>
    <td class="tdLeft">公司性质：</td>
    <td class="tdRight">
        <asp:DropDownList ID="ddlProperty" runat="server">
            <asp:ListItem Value="个体户">个体户</asp:ListItem>
            <asp:ListItem Value="私营企业">私营企业</asp:ListItem>
            <asp:ListItem Value="国有企业">国有企业</asp:ListItem>
            <asp:ListItem Value="有限责任公司">有限责任公司</asp:ListItem>
            <asp:ListItem Value="股份有限公司">股份有限公司</asp:ListItem>
            <asp:ListItem Value="其它">其它</asp:ListItem>
        </asp:DropDownList>    </td>
  </tr>
  <tr>
    <td class="tdLeft">公司规模：</td>
    <td class="tdRight">
        <asp:DropDownList ID="ddlEmployees" runat="server">
            <asp:ListItem Value="少于50人">少于50人</asp:ListItem>
            <asp:ListItem Value="50-149人">50-149人</asp:ListItem>
            <asp:ListItem Value="150-499人">150-499人</asp:ListItem>
            <asp:ListItem Value="500-999人">500-999人</asp:ListItem>
            <asp:ListItem Value="1000人以上">1000人以上</asp:ListItem>
        </asp:DropDownList>    </td>
  </tr>
  <tr>
    <td class="tdLeft">地址：</td>
    <td class="tdRight">
        <asp:TextBox ID="txtAddress" runat="server" CssClass="txtAddress" ></asp:TextBox>&nbsp;<span class="require">*</span> <a href="/map/getposition.html" target="_blank" id="hrefShowPosition">查看坐标</a>	
    </td>
  </tr>
  <tr>
    <td class="tdLeft">世界坐标：</td>
    <td class="tdRight">
	<div class="tips">设置您的商铺/公司的坐标，让更多人能够准确地搜索到您信息<br />
	请输入 <strong style="color:#000;">地址</strong> 后点击右侧 <strong style="color:#000;">查看坐标</strong> 选择具体的位置<br />
	分别把纬度、经度复制到以下文本框里:</div>
	</td>
  </tr>
  <tr>
    <td class="tdLeft">&nbsp;</td>
    <td class="tdRight">纬度 - <asp:TextBox ID="txtLat" runat="server" Width="200px" /></td>
  </tr>
  <tr>
    <td class="tdLeft">&nbsp;</td>
    <td class="tdRight">经度 - <asp:TextBox ID="txtLng" runat="server" Width="200px" /></td>
  </tr>
  <tr>
    <td class="tdLeft">&nbsp;</td>
    <td class="tdRight">&nbsp;</td>
  </tr>
  <tr>
    <td class="tdLeft">公司简介：</td>
    <td class="tdRight">
        <asp:TextBox ID="txtIntro" runat="server" TextMode="MultiLine" Rows="10" Columns="80" CssClass="txtNotes"></asp:TextBox>
    <span class="require">*</span>
    </td>
  </tr>
  
  
  <tr>
    <td class="tdLeft">验　证　码：</td>
    <td class="tdRight"><asp:TextBox ID="txtValidCode" runat="server" width="50" TabIndex="3"></asp:TextBox> <img src="ValidateCode.aspx" /></td>
  </tr>
  <tr>
    <td class="tdLeft">&nbsp;</td>
    <td class="tdRight">
        <asp:Button ID="btnSubmit" runat="server" Text="提交" onclick="btnSubmit_OnClick" /></td>
  </tr>
</table>
</asp:Content>
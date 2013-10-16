<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="Edit.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.CashTicketApplications.Edit"  %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
Admin - CashTicketApplications - Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>现金券兑现管理</span> &gt; <a href="List.aspx">申请列表</a> &gt; 修改
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

<table border="0" cellspacing="0" cellpadding="0" class="formTable">
  <tr>
    <td class="tdLeft">申请用户:</td>
    <td class="tdRight">
        <asp:Literal ID="litUserName" runat="server"></asp:Literal>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">现金券序列号:</td>
    <td class="tdRight"><asp:Literal ID="litCashTicketSerialNum" runat="server"></asp:Literal></td>
  </tr>
  <tr>
    <td class="tdLeft">现金券验证码:</td>
    <td class="tdRight"><asp:Literal ID="litCashTicketValidCode" runat="server"></asp:Literal></td>
  </tr>
   <tr>
    <td class="tdLeft">消费日期:</td>
    <td class="tdRight"><asp:Literal ID="litCostDate" runat="server" ></asp:Literal></td>
  </tr>
  <tr>
    <td class="tdLeft">申请兑现日期:</td>
    <td class="tdRight"><asp:Literal ID="litCreateTime" runat="server" ></asp:Literal></td>
  </tr>
  <tr>
    <td class="tdLeft">修改日期:</td>
    <td class="tdRight"><asp:Literal ID="litModifyTime" runat="server" ></asp:Literal></td>
  </tr>
  
  <tr>
    <td class="tdLeft">所属商家:</td>
    <td class="tdRight"><asp:Literal ID="litCorpName" runat="server"></asp:Literal></td>
  </tr>
  <tr>
    <td class="tdLeft">提成百分比:</td>
    <td class="tdRight"><asp:Literal ID="litOfferPercent" runat="server"></asp:Literal></td>
  </tr>
  <tr>
    <td class="tdLeft">对应现金券:</td>
    <td class="tdRight">
       <asp:HyperLink ID="hrefViewCashTicket" runat="server">查看</asp:HyperLink>
    </td>
  </tr>
  
  <tr>
    <td class="tdLeft">返还金额(单位元):</td>
    <td class="tdRight"> 
        <asp:TextBox ID="txtReturnMoney" runat="server" CssClass="txtNum"></asp:TextBox> <span class="tips">根据实际情况填写,该消费者应获得返还的金额,方便以后统计</span>
    </td>
  </tr>
  
  <tr>
    <td class="tdLeft">具体商品及金额:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtSummary" runat="server" Height="100px" TextMode="MultiLine" 
                Width="280px"></asp:TextBox>
    </td>
  </tr>
  
  <tr>
    <td class="tdLeft">备注:</td>
    <td class="tdRight">
        <asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine" CssClass="txtNotes"></asp:TextBox> <span class="tips">可填写相关消息给注册会员</span>
    </td>
  </tr>
  
  <tr>
    <td class="tdLeft">状态:</td>
    <td class="tdRight">
        <asp:DropDownList ID="ddlCheckState" runat="server">
            <asp:ListItem Value="0">待审核</asp:ListItem>
            <asp:ListItem Value="1">通过审核</asp:ListItem>
            <asp:ListItem Value="2">无效</asp:ListItem>
            <asp:ListItem Value="3">过期</asp:ListItem>
        </asp:DropDownList> <span class="require">*</span>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">自动充值:</td>
    <td class="tdRight">
    <asp:CheckBox ID="chkDoVirtualTransfer" runat="server" Text="选择该选项,系统自动执行虚拟帐号充值" />
    </td>
  </tr>
  <tr>
    <td class="tdLeft">&nbsp;</td>
    <td class="tdRight">
       <asp:Button ID="btnSubmit" runat="server" Text="提交" OnClick="btnSubmit_OnClick" /> <span class="strewColor">通过审核后，需要为该会员充值，完成本次处理。</span>
    </td>
  </tr>
</table>





</asp:Content>


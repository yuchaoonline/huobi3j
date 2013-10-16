<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.Promotions.Keywords.AD.Default" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
商家控制面板 - 精准搜索广告管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">　</span><a href="Default.aspx">广告设置管理</a>  <span class="spl">　</span><span class="curPos">添加广告</span>
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
	<table class="formTable gridView">
    <tr>
        <th colspan="2">
            添加广告
        </th>
    </tr>
    <tr>
	    <td class="tdLeft">标题：</td>
	    <td class="tdRight"><asp:TextBox ID="txtName" runat="server"></asp:TextBox> <span class="require">*</span></td>
    </tr>
    <tr>
	    <td class="tdLeft">描述：</td>
	    <td class="tdRight"><asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Rows="4"></asp:TextBox> <span class="require">*</span></td>
    </tr>
    <tr>
	    <td class="tdLeft">链接：</td>
	    <td class="tdRight"><asp:TextBox ID="txtLink" runat="server"></asp:TextBox> <span class="require">*</span></td>
    </tr>
    <tr>
	    <td class="tdLeft"></td>
	    <td class="tdRight">
	      <asp:Button ID="btnSubmit" runat="server" Text="添加" onclick="btnSubmit_Click" />
	    </td>
    </tr>
</table>

    <table id="resultList" class="gridView">
        <asp:Repeater ID="rpADList" runat="server">
            <HeaderTemplate>
                <tr>
                    <th>标题</th>
                    <th>描述</th>
                    <th>链接</th>
                    <th>审核</th>
                    <th>操作</th>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# ADeeWu.HuoBi3J.Libary.Utility.SubString(Eval("Name"),10,"...") %></td>
                    <td><%# ADeeWu.HuoBi3J.Libary.Utility.SubString(Eval("Content"), 10, "...")%></td>
                    <td><a href="<%#ADeeWu.HuoBi3J.Libary.WebUtility.FormatURL(Eval("Link")) %>" title="点击查看"><%#ADeeWu.HuoBi3J.Libary.WebUtility.FormatURL(Eval("Link"))%></a></td>
                    <td><%#Convert.ToBoolean(Eval("IsPass"))?"通过":"<font color='red'>未通过</font>" %></td>
                    <td>
                        <a href="Del.aspx?id=<%#Eval("id")%>" onclick="return confirm('确认要删除该记录吗?同时将删除有关该记录的统计！');" title="删除">删除</a>
                        <a href="Edit.aspx?id=<%#Eval("id")%>" title="编辑">编辑</a>
                        <a href="../Aution/AuctionLog.aspx?id=<%#Eval("id")%>" title="竞价记录">竞价记录</a>
                        <a href="../Aution/manager.aspx?id=<%#Eval("id")%>" title="竞价管理">竞价管理</a>
                        <a href="../AD/ADLog.aspx?id=<%#Eval("id")%>" title="消费记录">消费记录</a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <div class="pager">
        <IscControl:Pager ID="Pager1" runat="server"  />
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>

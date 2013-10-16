<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.Promotions.Keywords.Default" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
商家控制面板 - 商家推广关键字管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">　</span><a href="../">官网搜索推广</a>  <span class="spl">　</span><span class="curPos">推广关键字</span> | <a href="New.aspx">添加关键字</a>
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
	
	<asp:GridView ID="gvData" runat="server" CssClass="gridView" SkinID="userGridViewSkin" AllowPaging="false" AllowSorting="false" ShowFooter="false" AutoGenerateColumns="false">
	<Columns>
	<asp:BoundField DataField="Keyword" HeaderText="关键字" />
	<asp:TemplateField HeaderText="最高竞价(货币)">
	<ItemTemplate>
	<%# GetTopCoins( Eval("Keyword").ToString() )%>
	</ItemTemplate>
	</asp:TemplateField>
	<asp:BoundField DataField="VisitCount" HeaderText="点击次数" />
	<asp:BoundField DataField="CreateTime" HeaderText="添加时间" />
	<asp:BoundField DataField="ModifyTime" HeaderText="修改时间" />
	<asp:TemplateField HeaderText="状态">
        <ItemTemplate>
            <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                Eval("CheckState").ToString(),
                new string[][]{
                    new string[]{"0","<span style='color:red;'>待审核</span>"},
                    new string[]{"1","已审核"},
                    new string[]{"2","无效"},
                    new string[]{"3","过期"}
                }               
                )
            %>
        </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField HeaderText="操作">
	<ItemTemplate>
		<a href="Edit.aspx?id=<%#Eval("id")%>">修改</a> | <a href="Del.aspx?id=<%#Eval("id")%>" onclick="return confirm('确认要删除该记录吗?');">删除</a>
	</ItemTemplate>
	</asp:TemplateField>
	
	</Columns>
	</asp:GridView>
	
	
	<div class="pager">
    <IscControl:Pager ID="Pager1" runat="server"  />
    </div>
	
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>

<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.CorpAgentManage.HireInfos.Default" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControls" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
商家控制面板 - 商家代表招聘信息管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">　</span><a href="/My/Corp/CorpAgentManage/HireInfos/">网络营销专员</a><span class="spl">　</span><span class="curPos">招聘信息管理</span> 
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

<asp:GridView ID="gvData" runat="server" CssClass="gridView" SkinID="userGridViewSkin" AutoGenerateColumns="false" ShowFooter="false" BorderStyle="None"  ShowHeader="true">
<Columns>
   <%--<asp:TemplateField HeaderStyle-CssClass="col_id"  ItemStyle-CssClass="col_id" HeaderText="ID">
        <ItemTemplate>
            <input type="checkbox" name="id" value="<%#Eval("ID") %>" /> <%#Eval("ID") %>
        </ItemTemplate>    
    </asp:TemplateField>--%>
    
    <asp:BoundField HeaderText="标题" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" DataField="Title" />
	<asp:BoundField HeaderText="点击次数" DataField="VisitCount" />
    <asp:BoundField HeaderText="发布时间" HeaderStyle-CssClass="col_datetime" ItemStyle-CssClass="col_datetime" DataField="CreateTIme" />
    <asp:TemplateField HeaderText="审核状态">
            <ItemTemplate>
                   <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                        Eval("CheckState").ToString(),
                        new string[][]{
                            new string[]{"0","<font color='red'>待审核</font>"},
                            new string[]{"1","已审核"},
                            new string[]{"2","无效"},
                            new string[]{"3","过期"}
                        }               
                        )
                    %>
            </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="操作" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option">
        <ItemTemplate>
            <a href="Edit.aspx?id=<%#Eval("ID") %>">修改</a> | <a href="Del.aspx?id=<%#Eval("ID") %>" onclick="return confirm('确认要删除该记录吗?一旦删除无法恢复');">删除</a>
        </ItemTemplate>
    </asp:TemplateField>
    
</Columns>
</asp:GridView>

<IscControls:Pager ID="Pager1" runat="server" />

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>


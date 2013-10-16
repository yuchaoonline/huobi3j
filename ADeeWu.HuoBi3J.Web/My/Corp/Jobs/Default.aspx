<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.Jobs.Default" %>
<%@ Register assembly="ADeeWu.HuoBi3J.WebUI" namespace="ADeeWu.HuoBi3J.WebUI" tagprefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
商家控制面板 - 招聘管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">　</span><span class="curPos">招聘管理</span>  
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
     
    <div>
    
    <table class="searchTable">
        <tr>
            <td class="key" style="width:80px">
                职位名称：
            </td>
            <td>
                <asp:TextBox ID="txtJobName" runat="server" Width="120px"></asp:TextBox>
            </td>
            <td >
                发布时间：
            </td>
            <td>
		        <IscControl:DateTimeSelector ID="txtBeginTime" runat="server"></IscControl:DateTimeSelector>
		        至
                <IscControl:DateTimeSelector ID="txtEndTime" runat="server"></IscControl:DateTimeSelector>
                  <input name="submit" type="submit" value="搜索" />
               </td>
        </tr>
    </table>
    
 
<asp:GridView Width="100%" ID="gvData" runat="server"  CssClass="gridView" SkinID="userGridViewSkin" AutoGenerateColumns="False">
<Columns>
    <asp:BoundField HeaderText="职位名称" HeaderStyle-CssClass="col_title"  ItemStyle-CssClass="col_title" DataField="Title"  >
    </asp:BoundField>
   <%--<asp:BoundField HeaderText="职位分类"  DataField="CategoryName" ></asp:BoundField>--%>
   
   <asp:TemplateField HeaderText="工作地区">
        <ItemTemplate>
            <%# Eval("City") %>-<%# Eval("Area") %>
        </ItemTemplate>
    </asp:TemplateField>
   <asp:TemplateField HeaderText="发布时间" HeaderStyle-CssClass="col_money" ItemStyle-CssClass="col_money">
        <ItemTemplate>
            <%# Eval("CreateTime","{0:yyyy-MM-dd}")%>
        </ItemTemplate>
    </asp:TemplateField>
  <%--  
   <asp:TemplateField HeaderText="最后刷新时间" HeaderStyle-CssClass="col_notes" ItemStyle-CssClass="col_notes">
        <ItemTemplate>
            <%# Eval("RefreshTime")%>
        </ItemTemplate>
   </asp:TemplateField>
    --%>
    <asp:BoundField DataField="VisitCount"  HeaderText="访问次数" />
    <%--<asp:TemplateField HeaderText="状态">
        <ItemTemplate>
            <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                Eval("CheckState").ToString(),
                new string[][]{
                    new string[]{"0","待审核"},
                    new string[]{"1","已审核"},
                    new string[]{"2","无效"},
                    new string[]{"3","过期"}
                }               
                )
            %>
        </ItemTemplate>
    </asp:TemplateField>--%>
    <asp:TemplateField HeaderText="操作" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option"> 
        <ItemTemplate>
          <a href="Edit.aspx?id=<%#Eval("ID") %>">修改</a>
          <a onclick="return confirm('您确认要删除这条信息吗？')" href="Del.aspx?id=<%#Eval("ID") %>">删除</a>
        </ItemTemplate>
    </asp:TemplateField>
</Columns>
</asp:GridView>
<div class="pager">
    <IscControl:Pager ID="Pager1" runat="server"  />
</div>
    </div>
  
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>




<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.CorpImage.Albums.Default" %>
<%@ Register assembly="ADeeWu.HuoBi3J.WebUI" namespace="ADeeWu.HuoBi3J.WebUI" tagprefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
商家控制面板 - 企业相册
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">　</span><span class="curPos">企业相册</span>  
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
     
   

<table class="searchTable">
    <tr>       
         <td class="key" style="width:70px">
                标题：</td>
            <td>
                <asp:TextBox ID="txtTitle" runat="server" Width="120px" />
                <asp:Button ID="btnSubmit" runat="server" Text="搜索" onclick="btnSubmit_Click" /> 
                <a href="New.aspx">新建相册</a>
            </td>
          
            <%--<td >
                发布时间：</td>
            <td>
		        &nbsp;<input id="txtBeginTime" runat="server" readonly="readonly" type="text"/> 至<input 
                    id="txtEndTime" runat="server" readonly="readonly" type="text"/>
                <input name="submit" type="submit" value="搜索" /></td>--%>
        </tr>
</table>    


<asp:GridView ID="gvData" runat="server" CssClass="gridView" 
        SkinID="userGridViewSkin" AutoGenerateColumns="False">
<Columns>
   
    <asp:TemplateField   HeaderText="编号">     
          <ItemTemplate>
           <%# Eval("ID")%>
          </ItemTemplate>
    </asp:TemplateField>
    
     <asp:TemplateField HeaderText="标题">
        <ItemTemplate>
            <%# Eval("Title")  %>
        </ItemTemplate>
    </asp:TemplateField>
    
    
    <asp:TemplateField HeaderText="推荐">
        <ItemTemplate>
           <%# ((bool)Eval("IsRecommend")) ? "是" : "否"%>
        </ItemTemplate>
    </asp:TemplateField>
     <asp:TemplateField HeaderText="隐藏">
        <ItemTemplate>             
            <%# ((bool)Eval("IsHidden")) ? "是" : "否"%>
        </ItemTemplate>
    </asp:TemplateField>
    
    <asp:BoundField HeaderText="发布时间"  DataField="CreateTime" />   
    <asp:TemplateField HeaderText="操作" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option"> <ItemTemplate>
                    <a href='photos/Default.aspx?id=<%#Eval("ID") %>'>查看|</a>  
                    
                    <a href='Edit.aspx?id=<%#Eval("ID") %>'>修改|</a>  
                    <a href="Del.aspx?id=<%#Eval("ID") %>" dir="ltr" onclick="return confirm('您确认要删除这条信息吗？')">
                    删除</a>
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




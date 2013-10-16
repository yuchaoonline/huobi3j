<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="List.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.SupplyDemand.List"  %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register assembly="ADeeWu.HuoBi3J.WebUI" namespace="ADeeWu.HuoBi3J.WebUI" tagprefix="CashTicketControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
无标题文档
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
&nbsp;</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>竞投报价</span> &gt; <a href="List.aspx">列表</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    
  <div>
    <table class="searchTable">
         <tr>
           <td>标题：</td>
           <td width="100px"><asp:TextBox ID="title" runat="server" ></asp:TextBox></td>
           <td>姓名：</td> 
           <td>
               <asp:TextBox ID="name" runat="server"></asp:TextBox>
           </td>
            
           <td>发布时间：</td> 
           
           <td>
               <CashTicketControl:DateTimeSelector ID="beginTime" runat="server"></CashTicketControl:DateTimeSelector>
               至<CashTicketControl:DateTimeSelector ID="endTime" runat="server"></CashTicketControl:DateTimeSelector>
           </td>
         </tr>
         <tr>
           <td>状态：</td>
           <td width="100px">
              <asp:DropDownList ID="ddlCheckState" runat="server">
                    <asp:ListItem Value="-1">全部</asp:ListItem>
                    <asp:ListItem Value="0">待审核</asp:ListItem>
                    <asp:ListItem Value="1">已审核</asp:ListItem>
                    <asp:ListItem Value="2">失效</asp:ListItem>
                    <asp:ListItem Value="3">过期</asp:ListItem>     
               </asp:DropDownList>
             </td>
           <td>用户类型：</td> 
           <td>
              <asp:DropDownList ID="ddlUserType" runat="server">
                    <asp:ListItem Value="-1">全部</asp:ListItem>
                    <asp:ListItem Value="0">个人用户</asp:ListItem>
                    <asp:ListItem Value="1">商家用户</asp:ListItem>
              </asp:DropDownList>
           </td>
           <td><asp:Button ID="btnquery" runat="server" Text="查询" />
             </td> 
           
           <td>&nbsp;
               </td>
         </tr>
      </table>
       <asp:GridView Width="100%" ID="gvData" runat="server"  CssClass="gridView" SkinID="userGridViewSkin" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField HeaderStyle-CssClass="col_title"  ItemStyle-CssClass="col_title" HeaderText="标题">
                <ItemTemplate>
                 <%#Eval("Title")%>
                </ItemTemplate>
                <HeaderStyle CssClass="col_title"></HeaderStyle>
                <ItemStyle CssClass="col_title"></ItemStyle>
            </asp:TemplateField>
             <asp:TemplateField HeaderStyle-CssClass="col_title"  ItemStyle-CssClass="col_title" HeaderText="姓名">
                <ItemTemplate>
                 <%#Eval("Name")%>
                </ItemTemplate>
                <HeaderStyle CssClass="col_title"></HeaderStyle>
                <ItemStyle CssClass="col_title"></ItemStyle>
            </asp:TemplateField>
             <asp:TemplateField HeaderStyle-CssClass="col_id"  ItemStyle-CssClass="col_id" HeaderText="发布时间">
                <ItemTemplate>
                 <%#Eval("CreateTime","{0:yyyy-MM-dd}")%>
                </ItemTemplate>
                <HeaderStyle CssClass="col_datetime"></HeaderStyle>
                <ItemStyle CssClass="col_datetime"></ItemStyle>
            </asp:TemplateField>
             <asp:TemplateField HeaderStyle-CssClass="col_id"  ItemStyle-CssClass="col_id" HeaderText="刷新时间">
                <ItemTemplate>
                 <%#Eval("RefreshTime","{0:yyyy-MM-dd}")%>
                </ItemTemplate>
                <HeaderStyle CssClass="col_datetime"></HeaderStyle>
                <ItemStyle CssClass="col_datetime"></ItemStyle>
            </asp:TemplateField>
             <asp:TemplateField HeaderStyle-CssClass="col_datetime"  ItemStyle-CssClass="col_datetime" HeaderText="过期时间">
                <ItemTemplate>
                 <%#Eval("EndTime","{0:yyyy-MM-dd}")%>
                </ItemTemplate>
                <HeaderStyle CssClass="col_datetime"></HeaderStyle>
                <ItemStyle CssClass="col_datetime"></ItemStyle>
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="状态">
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
                <HeaderStyle CssClass="col_state" />
                <ItemStyle CssClass="col_state" />
            </asp:TemplateField>
            
             <asp:TemplateField HeaderStyle-CssClass="col_option"  ItemStyle-CssClass="col_option" HeaderText="操作">
                <ItemTemplate>
                  <a href='Edit.aspx?id=<%# Eval("ID") %>'>修改</a> 
                </ItemTemplate>
                <HeaderStyle CssClass="col_id"></HeaderStyle>
                <ItemStyle CssClass="col_id"></ItemStyle>
            </asp:TemplateField>
            
        </Columns>
        </asp:GridView>
        <div class="pager">
            <CashTicketControl:Pager ID="Pager1" runat="server"  />
        </div>
    </div>
    
</asp:Content>


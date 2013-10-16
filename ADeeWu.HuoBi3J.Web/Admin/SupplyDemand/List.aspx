<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="List.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.SupplyDemand.List"  %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register assembly="ADeeWu.HuoBi3J.WebUI" namespace="ADeeWu.HuoBi3J.WebUI" tagprefix="CashTicketControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
�ޱ����ĵ�
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
&nbsp;</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>��Ͷ����</span> &gt; <a href="List.aspx">�б�</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    
  <div>
    <table class="searchTable">
         <tr>
           <td>���⣺</td>
           <td width="100px"><asp:TextBox ID="title" runat="server" ></asp:TextBox></td>
           <td>������</td> 
           <td>
               <asp:TextBox ID="name" runat="server"></asp:TextBox>
           </td>
            
           <td>����ʱ�䣺</td> 
           
           <td>
               <CashTicketControl:DateTimeSelector ID="beginTime" runat="server"></CashTicketControl:DateTimeSelector>
               ��<CashTicketControl:DateTimeSelector ID="endTime" runat="server"></CashTicketControl:DateTimeSelector>
           </td>
         </tr>
         <tr>
           <td>״̬��</td>
           <td width="100px">
              <asp:DropDownList ID="ddlCheckState" runat="server">
                    <asp:ListItem Value="-1">ȫ��</asp:ListItem>
                    <asp:ListItem Value="0">�����</asp:ListItem>
                    <asp:ListItem Value="1">�����</asp:ListItem>
                    <asp:ListItem Value="2">ʧЧ</asp:ListItem>
                    <asp:ListItem Value="3">����</asp:ListItem>     
               </asp:DropDownList>
             </td>
           <td>�û����ͣ�</td> 
           <td>
              <asp:DropDownList ID="ddlUserType" runat="server">
                    <asp:ListItem Value="-1">ȫ��</asp:ListItem>
                    <asp:ListItem Value="0">�����û�</asp:ListItem>
                    <asp:ListItem Value="1">�̼��û�</asp:ListItem>
              </asp:DropDownList>
           </td>
           <td><asp:Button ID="btnquery" runat="server" Text="��ѯ" />
             </td> 
           
           <td>&nbsp;
               </td>
         </tr>
      </table>
       <asp:GridView Width="100%" ID="gvData" runat="server"  CssClass="gridView" SkinID="userGridViewSkin" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField HeaderStyle-CssClass="col_title"  ItemStyle-CssClass="col_title" HeaderText="����">
                <ItemTemplate>
                 <%#Eval("Title")%>
                </ItemTemplate>
                <HeaderStyle CssClass="col_title"></HeaderStyle>
                <ItemStyle CssClass="col_title"></ItemStyle>
            </asp:TemplateField>
             <asp:TemplateField HeaderStyle-CssClass="col_title"  ItemStyle-CssClass="col_title" HeaderText="����">
                <ItemTemplate>
                 <%#Eval("Name")%>
                </ItemTemplate>
                <HeaderStyle CssClass="col_title"></HeaderStyle>
                <ItemStyle CssClass="col_title"></ItemStyle>
            </asp:TemplateField>
             <asp:TemplateField HeaderStyle-CssClass="col_id"  ItemStyle-CssClass="col_id" HeaderText="����ʱ��">
                <ItemTemplate>
                 <%#Eval("CreateTime","{0:yyyy-MM-dd}")%>
                </ItemTemplate>
                <HeaderStyle CssClass="col_datetime"></HeaderStyle>
                <ItemStyle CssClass="col_datetime"></ItemStyle>
            </asp:TemplateField>
             <asp:TemplateField HeaderStyle-CssClass="col_id"  ItemStyle-CssClass="col_id" HeaderText="ˢ��ʱ��">
                <ItemTemplate>
                 <%#Eval("RefreshTime","{0:yyyy-MM-dd}")%>
                </ItemTemplate>
                <HeaderStyle CssClass="col_datetime"></HeaderStyle>
                <ItemStyle CssClass="col_datetime"></ItemStyle>
            </asp:TemplateField>
             <asp:TemplateField HeaderStyle-CssClass="col_datetime"  ItemStyle-CssClass="col_datetime" HeaderText="����ʱ��">
                <ItemTemplate>
                 <%#Eval("EndTime","{0:yyyy-MM-dd}")%>
                </ItemTemplate>
                <HeaderStyle CssClass="col_datetime"></HeaderStyle>
                <ItemStyle CssClass="col_datetime"></ItemStyle>
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="״̬">
                <ItemTemplate>
                   <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                Eval("CheckState").ToString(),
                new string[][]{
                    new string[]{"0","�����"},
                    new string[]{"1","�����"},
                    new string[]{"2","��Ч"},
                    new string[]{"3","����"}
                }               
                )
            %>
                </ItemTemplate>
                <HeaderStyle CssClass="col_state" />
                <ItemStyle CssClass="col_state" />
            </asp:TemplateField>
            
             <asp:TemplateField HeaderStyle-CssClass="col_option"  ItemStyle-CssClass="col_option" HeaderText="����">
                <ItemTemplate>
                  <a href='Edit.aspx?id=<%# Eval("ID") %>'>�޸�</a> 
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


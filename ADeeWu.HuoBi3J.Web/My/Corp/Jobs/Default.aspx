<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.Jobs.Default" %>
<%@ Register assembly="ADeeWu.HuoBi3J.WebUI" namespace="ADeeWu.HuoBi3J.WebUI" tagprefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
�̼ҿ������ - ��Ƹ����
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">��</span><span class="curPos">��Ƹ����</span>  
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
     
    <div>
    
    <table class="searchTable">
        <tr>
            <td class="key" style="width:80px">
                ְλ���ƣ�
            </td>
            <td>
                <asp:TextBox ID="txtJobName" runat="server" Width="120px"></asp:TextBox>
            </td>
            <td >
                ����ʱ�䣺
            </td>
            <td>
		        <IscControl:DateTimeSelector ID="txtBeginTime" runat="server"></IscControl:DateTimeSelector>
		        ��
                <IscControl:DateTimeSelector ID="txtEndTime" runat="server"></IscControl:DateTimeSelector>
                  <input name="submit" type="submit" value="����" />
               </td>
        </tr>
    </table>
    
 
<asp:GridView Width="100%" ID="gvData" runat="server"  CssClass="gridView" SkinID="userGridViewSkin" AutoGenerateColumns="False">
<Columns>
    <asp:BoundField HeaderText="ְλ����" HeaderStyle-CssClass="col_title"  ItemStyle-CssClass="col_title" DataField="Title"  >
    </asp:BoundField>
   <%--<asp:BoundField HeaderText="ְλ����"  DataField="CategoryName" ></asp:BoundField>--%>
   
   <asp:TemplateField HeaderText="��������">
        <ItemTemplate>
            <%# Eval("City") %>-<%# Eval("Area") %>
        </ItemTemplate>
    </asp:TemplateField>
   <asp:TemplateField HeaderText="����ʱ��" HeaderStyle-CssClass="col_money" ItemStyle-CssClass="col_money">
        <ItemTemplate>
            <%# Eval("CreateTime","{0:yyyy-MM-dd}")%>
        </ItemTemplate>
    </asp:TemplateField>
  <%--  
   <asp:TemplateField HeaderText="���ˢ��ʱ��" HeaderStyle-CssClass="col_notes" ItemStyle-CssClass="col_notes">
        <ItemTemplate>
            <%# Eval("RefreshTime")%>
        </ItemTemplate>
   </asp:TemplateField>
    --%>
    <asp:BoundField DataField="VisitCount"  HeaderText="���ʴ���" />
    <%--<asp:TemplateField HeaderText="״̬">
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
    </asp:TemplateField>--%>
    <asp:TemplateField HeaderText="����" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option"> 
        <ItemTemplate>
          <a href="Edit.aspx?id=<%#Eval("ID") %>">�޸�</a>
          <a onclick="return confirm('��ȷ��Ҫɾ��������Ϣ��')" href="Del.aspx?id=<%#Eval("ID") %>">ɾ��</a>
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




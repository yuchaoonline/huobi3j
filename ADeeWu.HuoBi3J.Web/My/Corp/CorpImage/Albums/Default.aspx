<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.CorpImage.Albums.Default" %>
<%@ Register assembly="ADeeWu.HuoBi3J.WebUI" namespace="ADeeWu.HuoBi3J.WebUI" tagprefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
�̼ҿ������ - ��ҵ���
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">��</span><span class="curPos">��ҵ���</span>  
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
     
   

<table class="searchTable">
    <tr>       
         <td class="key" style="width:70px">
                ���⣺</td>
            <td>
                <asp:TextBox ID="txtTitle" runat="server" Width="120px" />
                <asp:Button ID="btnSubmit" runat="server" Text="����" onclick="btnSubmit_Click" /> 
                <a href="New.aspx">�½����</a>
            </td>
          
            <%--<td >
                ����ʱ�䣺</td>
            <td>
		        &nbsp;<input id="txtBeginTime" runat="server" readonly="readonly" type="text"/> ��<input 
                    id="txtEndTime" runat="server" readonly="readonly" type="text"/>
                <input name="submit" type="submit" value="����" /></td>--%>
        </tr>
</table>    


<asp:GridView ID="gvData" runat="server" CssClass="gridView" 
        SkinID="userGridViewSkin" AutoGenerateColumns="False">
<Columns>
   
    <asp:TemplateField   HeaderText="���">     
          <ItemTemplate>
           <%# Eval("ID")%>
          </ItemTemplate>
    </asp:TemplateField>
    
     <asp:TemplateField HeaderText="����">
        <ItemTemplate>
            <%# Eval("Title")  %>
        </ItemTemplate>
    </asp:TemplateField>
    
    
    <asp:TemplateField HeaderText="�Ƽ�">
        <ItemTemplate>
           <%# ((bool)Eval("IsRecommend")) ? "��" : "��"%>
        </ItemTemplate>
    </asp:TemplateField>
     <asp:TemplateField HeaderText="����">
        <ItemTemplate>             
            <%# ((bool)Eval("IsHidden")) ? "��" : "��"%>
        </ItemTemplate>
    </asp:TemplateField>
    
    <asp:BoundField HeaderText="����ʱ��"  DataField="CreateTime" />   
    <asp:TemplateField HeaderText="����" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option"> <ItemTemplate>
                    <a href='photos/Default.aspx?id=<%#Eval("ID") %>'>�鿴|</a>  
                    
                    <a href='Edit.aspx?id=<%#Eval("ID") %>'>�޸�|</a>  
                    <a href="Del.aspx?id=<%#Eval("ID") %>" dir="ltr" onclick="return confirm('��ȷ��Ҫɾ��������Ϣ��')">
                    ɾ��</a>
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




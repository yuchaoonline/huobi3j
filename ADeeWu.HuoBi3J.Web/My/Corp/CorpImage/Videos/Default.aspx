<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.CorpImage.Videos.Default" %>
<%@ Register assembly="ADeeWu.HuoBi3J.WebUI" namespace="ADeeWu.HuoBi3J.WebUI" tagprefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
�̼ҿ������ - ��ҵ��Ƶ
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">��</span><span class="curPos">��ҵ��Ƶ</span>  
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
     
   
<table class="searchTable">
     <tr>
           <td class="key" style="width:70px">
                ���⣺</td>
            <td>
                <asp:TextBox ID="txtTitle" runat="server" Width="120px" />
                <asp:Button ID="btnSubmit" runat="server" Text="����" onclick="btnSubmit_Click" /> <a href="New.aspx">�����Ƶ</a>
            </td>
        </tr>
    </table>
    <asp:GridView ID="gvData" runat="server" CssClass="gridView" 
            SkinID="userGridViewSkin" AutoGenerateColumns="False">
    <Columns>
               
        <asp:TemplateField HeaderText="����">
            <ItemTemplate>
                <%# Eval("Title") %>
            </ItemTemplate>
        </asp:TemplateField>
       
        <asp:TemplateField HeaderText="��Ƶ">
            <ItemTemplate>
				<img src="<%# Eval("PreviewURL")%>" onload="isc.util.zoomImg(this,120,120)" />
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
        
        <%--<asp:TemplateField HeaderText="����ʱ��">
           <ItemTemplate>
                <%# Eval("CreateTime")%>
            </ItemTemplate>            
        </asp:TemplateField>--%>
        
        
        <%--<asp:TemplateField HeaderText="���״̬">
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
                        <a href='Edit.aspx?id=<%#Eval("ID") %>'>�޸�|</a>  
                        <a href="Del.aspx?id=<%#Eval("ID") %>" dir="ltr" onclick="return confirm('��ȷ��Ҫɾ��������Ϣ��')">ɾ��</a>
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




<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.CorpImage.Catalogs.CatalogPhotos.Default" %>

 <%@ Register assembly="ADeeWu.HuoBi3J.WebUI" namespace="ADeeWu.HuoBi3J.WebUI" tagprefix="IscControl" %>
    
    
    
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    ȫ��Ӫ���� - �ҵ�ͼƬ
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
      <a href="/My/Corp/">�ҵ��̼ҷ���</a> &gt;����ְλ����   
      </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
         
       
    
    <table class="searchTable">
        <tr>
           <td class="key" style="width:70px">
                ���⣺</td>
            <td>
                <asp:TextBox ID="txtTitle" runat="server" Width="120px" />
                <asp:Button ID="btnSubmit" runat="server" Text="����" onclick="btnSubmit_Click" /> <a href="New.aspx">���ͼƬ</a>
            </td>
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
                <%# Eval("Title") %>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="��������">
        <ItemTemplate>
         <a herf="../Edit.aspx?id=<%#Eval("CatalogsID") %>"><%#Eval("CatalogsName")%></a>       
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
        <asp:TemplateField HeaderText="�Ƿ���Ϊ����">
            <ItemTemplate>
               <%# ADeeWu.HuoBi3J.Libary.Utility.GetLong(Eval("FaceID"), 0) == (long)Eval("ID") ? "��" : "��"%>
            </ItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="����ʱ��">
           <ItemTemplate>
                <%# Eval("CreateTime")%>
            </ItemTemplate>            
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="����">
            <ItemTemplate>
                <%# Eval("Summary")%>
            </ItemTemplate>   
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="���ʴ���">
            <ItemTemplate>
                <%# Eval("VisitCount")%>
            </ItemTemplate>   
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="���״̬">
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
         </asp:TemplateField>
         <asp:TemplateField HeaderText="ͼƬ">
            <ItemTemplate>
                <%# Eval("URL")%>
            </ItemTemplate>   
            </asp:TemplateField>
        <asp:TemplateField HeaderText="��ע">
            <ItemTemplate>
                <%# Eval("Content")%>
            </ItemTemplate>   
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="����" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option"> <ItemTemplate>                       
                        <a href='Edit.aspx?id=<%#Eval("ID") %>'>�޸�|</a>  
                        <a href="Del.aspx?id=<%#Eval("ID") %>" dir="ltr" onclick="return confirm('��ȷ��Ҫɾ��������Ϣ��')">ɾ��</a>
                    </ItemTemplate>

    <HeaderStyle CssClass="col_option"></HeaderStyle>

    <ItemStyle CssClass="col_option"></ItemStyle>
                    </asp:TemplateField>
        
    </Columns>
    </asp:GridView>


    <div class="pager">
        <IscControl:Pager ID="Pager1" runat="server"  />
    </div>
       
       
       
      
    </asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>





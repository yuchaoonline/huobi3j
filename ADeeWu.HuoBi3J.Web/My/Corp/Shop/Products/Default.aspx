<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.Shop.Products.Default" %>
<%@ Register assembly="ADeeWu.HuoBi3J.WebUI" namespace="ADeeWu.HuoBi3J.WebUI" tagprefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
�̼ҿ������ - ��Ʒ����
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">��</span><a href="/My/Corp/Shop/">����Ӫ��</a><span class="spl">��</span><span class="curPos">��Ʒ����</span> |  <a href="New.aspx">������Ʒ</a>
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server"> 
   

<table class="searchTable">
    <tr>       
            <td class="key" width="80">
                �ꡡ���⣺
            </td>
            <td class="input">
                <asp:TextBox ID="txtName" runat="server" Width="120px" />
            </td>
            <td class="key" width="120">
                ������Ʒ���ࣺ
            </td>
            <td class="input">
                <asp:DropDownList ID="ddlCPCategory" runat="server">
                </asp:DropDownList>
                 <asp:Button ID="btnSubmit" runat="server" Text="����" onclick="btnSubmit_Click" /> 
		    </td>
        </tr>
</table>    


<asp:GridView ID="gvData" runat="server" CssClass="gridView" 
        SkinID="userGridViewSkin" AutoGenerateColumns="False">
<Columns>
     
     
    <asp:TemplateField HeaderText="ͼƬ">
    <ItemTemplate>
                <a  href="/Shop/Products/View.aspx?id=<%#Eval("ID") %>" target="_blank">
                    <img src="<%#Eval("Picture0") %>" onload="isc.util.zoomImg(this,80,80)" border="0" />
                </a>
            </ItemTemplate>
    </asp:TemplateField>
    
    <asp:TemplateField HeaderText="����" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title">
        <ItemTemplate>
            <a  href="/Shop/Products/View.aspx?id=<%#Eval("ID") %>" title="<%#Eval("Name") %>" target="_blank">
           <%# ADeeWu.HuoBi3J.Libary.Utility.SubString(Eval("Name"), 20, "...")%>
           </a>
        </ItemTemplate>
    </asp:TemplateField>
  
    <asp:TemplateField HeaderText="��Ʒ����">
       <ItemTemplate>
        <%#Eval("CategoryName")%>
       </ItemTemplate>
    </asp:TemplateField>
                    
    <%--<asp:TemplateField HeaderText="�Ƽ�">
        <ItemTemplate>
           <%# ((bool)Eval("IsRecommend")) ? "��" : "��"%>
        </ItemTemplate>
    </asp:TemplateField>
     <asp:TemplateField HeaderText="����">
        <ItemTemplate>             
            <%# ((bool)Eval("IsHidden")) ? "��" : "��"%>
        </ItemTemplate>
    </asp:TemplateField>
    
    <asp:TemplateField HeaderText="�۸�">
        <ItemTemplate>             
             <%# Eval("Price","{0:c}")%>
        </ItemTemplate>
    </asp:TemplateField>
     
    --%>
     <asp:TemplateField HeaderText="���">
        <ItemTemplate>             
             <%# Eval("Stock")%>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="���۳�">
        <ItemTemplate>             
             <%# Eval("SaleOut")%>
        </ItemTemplate>
    </asp:TemplateField>
   
    <%--<asp:TemplateField HeaderText="����ʱ��">
        <ItemTemplate>             
            <%# Eval("CreateTime") %>
        </ItemTemplate>
    </asp:TemplateField>--%>
    
    <asp:TemplateField HeaderText="����" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option"> <ItemTemplate>
                   <%-- <a href='photos/Default.aspx?id=<%#Eval("ID") %>'>�鿴|</a>--%>  
                    
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




<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.ProductCategories.Default" %>
<%@ Register assembly="ADeeWu.HuoBi3J.WebUI" namespace="ADeeWu.HuoBi3J.WebUI" tagprefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
�̼ҿ������ - ���̲�Ʒ����
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">��</span><a href="/My/Corp/Shop/">����Ӫ��</a><span class="spl">��</span><span class="curPos">��Ʒ�Զ������</span>
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
     
   

    


<asp:GridView ID="gvData" runat="server" CssClass="gridView" 
        SkinID="userGridViewSkin" AutoGenerateColumns="False">
<Columns>
   
    
     <asp:TemplateField HeaderText="��������">
        <ItemTemplate>
            <%# "".PadLeft((int)Eval("Depth"), '��') + Eval("Name")%>
        </ItemTemplate>
    </asp:TemplateField>
    
    <asp:TemplateField HeaderText="��Ʒ����">
        <ItemTemplate>
            <%# this.countItems((long)Eval("ID"))%>
        </ItemTemplate>
    </asp:TemplateField>
    
    <%--<asp:TemplateField HeaderText="ͼƬ">
        <ItemTemplate>             
        <img src="<%#Eval("ImgUrl") %>" border="0" onload="isc.util.zoomImg(this,120,80);" />
        </ItemTemplate>
    </asp:TemplateField>--%>
    
    <asp:TemplateField HeaderText="����">
        <ItemTemplate>             
           <%#Eval("Sequence") %>
        </ItemTemplate>
    </asp:TemplateField>
    
    <asp:TemplateField HeaderText="����">
        <ItemTemplate>             
            <%# ((bool)Eval("IsHidden")) ? "��" : "��"%>
        </ItemTemplate>
    </asp:TemplateField>
    
    

    <asp:TemplateField HeaderText="����" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option" ItemStyle-Width="180px"> <ItemTemplate>
        <a href='../Products/?cid=<%#Eval("ID") %>'>�鿴�÷�����Ʒ</a> | <a href='Edit.aspx?id=<%#Eval("ID") %>'>�޸�</a> | <a href="Del.aspx?id=<%#Eval("ID") %>" onclick="return confirm('��ȷ��Ҫɾ��������Ϣ��')">ɾ��</a>
    </ItemTemplate>
    </asp:TemplateField>
    
</Columns>
</asp:GridView>



   
   
   
  
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>




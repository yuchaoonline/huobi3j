<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.Promotions.Keywords.Default" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
�̼ҿ������ - �̼��ƹ�ؼ��ֹ���
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">��</span><a href="../">���������ƹ�</a>  <span class="spl">��</span><span class="curPos">�ƹ�ؼ���</span> | <a href="New.aspx">��ӹؼ���</a>
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
	
	<asp:GridView ID="gvData" runat="server" CssClass="gridView" SkinID="userGridViewSkin" AllowPaging="false" AllowSorting="false" ShowFooter="false" AutoGenerateColumns="false">
	<Columns>
	<asp:BoundField DataField="Keyword" HeaderText="�ؼ���" />
	<asp:TemplateField HeaderText="��߾���(����)">
	<ItemTemplate>
	<%# GetTopCoins( Eval("Keyword").ToString() )%>
	</ItemTemplate>
	</asp:TemplateField>
	<asp:BoundField DataField="VisitCount" HeaderText="�������" />
	<asp:BoundField DataField="CreateTime" HeaderText="���ʱ��" />
	<asp:BoundField DataField="ModifyTime" HeaderText="�޸�ʱ��" />
	<asp:TemplateField HeaderText="״̬">
        <ItemTemplate>
            <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                Eval("CheckState").ToString(),
                new string[][]{
                    new string[]{"0","<span style='color:red;'>�����</span>"},
                    new string[]{"1","�����"},
                    new string[]{"2","��Ч"},
                    new string[]{"3","����"}
                }               
                )
            %>
        </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField HeaderText="����">
	<ItemTemplate>
		<a href="Edit.aspx?id=<%#Eval("id")%>">�޸�</a> | <a href="Del.aspx?id=<%#Eval("id")%>" onclick="return confirm('ȷ��Ҫɾ���ü�¼��?');">ɾ��</a>
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

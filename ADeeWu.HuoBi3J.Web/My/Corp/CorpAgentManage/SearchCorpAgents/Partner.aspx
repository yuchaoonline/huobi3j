<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Partner.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.CorpAgentManage.SearchCorpAgents.Partner" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControls" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
�̼ҿ������ - �ҵ�����Ӫ��רԱ
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">��</span><a href="/My/Corp/CorpAgentManage/HireInfos/">����Ӫ��רԱ</a><span class="spl">��</span><span class="curPos">�ҵ�����Ӫ��רԱ</span> | <a href=".">���Ҵ�����</a>
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

<asp:GridView ID="gvData" runat="server" CssClass="gridView" SkinID="userGridViewSkin" AutoGenerateColumns="false" ShowFooter="false" BorderStyle="None"  ShowHeader="true">
<Columns>
   
    <asp:BoundField HeaderText="��ʵ����" DataField="RealName" />
	<asp:BoundField HeaderText="ͨѶ����" DataField="UIN" />
	<asp:TemplateField HeaderText="��������">
            <ItemTemplate>
                   <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(Eval("WorkExp").ToString(), ADeeWu.HuoBi3J.Web.GlobalParameter.switch_WorkExp) %>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField HeaderText="����">
            <ItemTemplate>
                   <%#string.Format("{0} {1} {2}",Eval("ProvinceName"),Eval("CityName"),Eval("AreaName"))%>
            </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="����" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option">
        <ItemTemplate>
            <a href="View.aspx?id=<%#Eval("UserID") %>">�鿴��ϸ</a>
        </ItemTemplate>
    </asp:TemplateField>
    
</Columns>
</asp:GridView>
    <IscControls:Pager ID="Pager1" runat="server" />

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>


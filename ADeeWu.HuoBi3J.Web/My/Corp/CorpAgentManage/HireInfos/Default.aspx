<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.CorpAgentManage.HireInfos.Default" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControls" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
�̼ҿ������ - �̼Ҵ�����Ƹ��Ϣ����
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">��</span><a href="/My/Corp/CorpAgentManage/HireInfos/">����Ӫ��רԱ</a><span class="spl">��</span><span class="curPos">��Ƹ��Ϣ����</span> 
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

<asp:GridView ID="gvData" runat="server" CssClass="gridView" SkinID="userGridViewSkin" AutoGenerateColumns="false" ShowFooter="false" BorderStyle="None"  ShowHeader="true">
<Columns>
   <%--<asp:TemplateField HeaderStyle-CssClass="col_id"  ItemStyle-CssClass="col_id" HeaderText="ID">
        <ItemTemplate>
            <input type="checkbox" name="id" value="<%#Eval("ID") %>" /> <%#Eval("ID") %>
        </ItemTemplate>    
    </asp:TemplateField>--%>
    
    <asp:BoundField HeaderText="����" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" DataField="Title" />
	<asp:BoundField HeaderText="�������" DataField="VisitCount" />
    <asp:BoundField HeaderText="����ʱ��" HeaderStyle-CssClass="col_datetime" ItemStyle-CssClass="col_datetime" DataField="CreateTIme" />
    <asp:TemplateField HeaderText="���״̬">
            <ItemTemplate>
                   <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                        Eval("CheckState").ToString(),
                        new string[][]{
                            new string[]{"0","<font color='red'>�����</font>"},
                            new string[]{"1","�����"},
                            new string[]{"2","��Ч"},
                            new string[]{"3","����"}
                        }               
                        )
                    %>
            </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="����" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option">
        <ItemTemplate>
            <a href="Edit.aspx?id=<%#Eval("ID") %>">�޸�</a> | <a href="Del.aspx?id=<%#Eval("ID") %>" onclick="return confirm('ȷ��Ҫɾ���ü�¼��?һ��ɾ���޷��ָ�');">ɾ��</a>
        </ItemTemplate>
    </asp:TemplateField>
    
</Columns>
</asp:GridView>

<IscControls:Pager ID="Pager1" runat="server" />

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>


<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.CorpAgentManage.SearchCorpAgents.Default" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControls" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
商家控制面板 - 查找代理商
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">　</span><a href="/My/Corp/CorpAgentManage/HireInfos/">网络营销专员</a><span class="spl">　</span><span class="curPos">查找代理商</span>
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

   <table class="searchTable">
        <tr>
            <td class="key" style="width:350px">
                <IscControls:SyncSelector ID="syncSelectorLocation" runat="server" 
                DataSourceURL="<%$Resources:SyncSelector,Location_DataSourceURL %>" 
                DataSourceName="<%$Resources:SyncSelector,Location_DataSourceName %>" 
                ClientPostNames="<%$Resources:SyncSelector,Location_ClientPostNames %>"
                />
            </td>
            <td  class="input">
                <asp:Button ID="btnSearch" runat="server" Text="搜索" 
                    onclick="btnSearch_Click"  />
            </td>
        </tr>
    </table>

<asp:GridView ID="gvData" runat="server" CssClass="gridView" SkinID="userGridViewSkin" AutoGenerateColumns="false" ShowFooter="false" BorderStyle="None"  ShowHeader="true">
<Columns>
   
    <asp:BoundField HeaderText="真实名称" DataField="RealName" />
	<asp:BoundField HeaderText="通讯号码" DataField="UIN" />
	<asp:TemplateField HeaderText="工作经验">
            <ItemTemplate>
                   <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(Eval("WorkExp").ToString(), ADeeWu.HuoBi3J.Web.GlobalParameter.switch_WorkExp) %>
            </ItemTemplate>
    </asp:TemplateField>
	<asp:TemplateField HeaderText="地区">
            <ItemTemplate>
                   <%#string.Format("{0} {1} {2}",Eval("ProvinceName"),Eval("CityName"),Eval("AreaName"))%>
            </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="操作" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option">
        <ItemTemplate>
            <a href="View.aspx?id=<%#Eval("ID") %>">查看详细</a>
        </ItemTemplate>
    </asp:TemplateField>
    
</Columns>
</asp:GridView>
    <IscControls:Pager ID="Pager1" runat="server" />

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>


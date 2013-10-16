<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="SelectCategory.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.Shop.Products.SelectCategory" %>
<%@ Register assembly="ADeeWu.HuoBi3J.WebUI" namespace="ADeeWu.HuoBi3J.WebUI" tagprefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
�̼ҿ������ - ѡ�񷢲���Ʒ����
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
function <%=this.syncSelectorShopProductCategories.ClientOnRenederedCallback %>(e){

	$('#btnPublish').click(function(){
		var item = <%=this.syncSelectorShopProductCategories.ID%>.getSelectedItem();
		if(item==null){
			alert('��ѡ����Ʒ����!');
			return false;
		}
		
		if( item.depth<3 ){
		    alert('����ѡ���ļ�����!');
		    return false;
		}
		
		var form = $('#frmPublish');		
		form.find('#cid').val( item.key );
		form.get(0).submit();
		
		return false;
	});
}
</script>
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">��</span><a href="/My/Corp/Shop/">����Ӫ��</a><span class="spl">��</span><a href="/My/Corp/Shop/Products/">��Ʒ����</a><span class="spl">��</span><span class="curPos">ѡ�񷢲���Ʒ����</span>
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
   

    ��Ʒ���ࣺ<IscControl:SyncSelector ID="syncSelectorShopProductCategories" runat="server" 
        DataSourceURL="<%$Resources:SyncSelector,ShopProductCategories_DataSourceURL %>" 
        DataSourceName="<%$Resources:SyncSelector,ShopProductCategories_DataSourceName %>" 
        ClientPostNames="<%$Resources:SyncSelector,ShopProductCategories_ClientPostNames %>"
        /> <button id="btnPublish">���ڷ�����Ʒ</button>
  
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">
<form id="frmPublish" method="post" action="New.aspx">
	<input type="hidden" id="cid" name="cid" />
</form>
</asp:Content>




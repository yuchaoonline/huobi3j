<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="SelectCategory.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.Shop.Products.SelectCategory" %>
<%@ Register assembly="ADeeWu.HuoBi3J.WebUI" namespace="ADeeWu.HuoBi3J.WebUI" tagprefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
商家控制面板 - 选择发布商品分类
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
function <%=this.syncSelectorShopProductCategories.ClientOnRenederedCallback %>(e){

	$('#btnPublish').click(function(){
		var item = <%=this.syncSelectorShopProductCategories.ID%>.getSelectedItem();
		if(item==null){
			alert('请选择商品分类!');
			return false;
		}
		
		if( item.depth<3 ){
		    alert('至少选择四级分类!');
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
<span class="spl">　</span><a href="/My/Corp/Shop/">在线营销</a><span class="spl">　</span><a href="/My/Corp/Shop/Products/">商品管理</a><span class="spl">　</span><span class="curPos">选择发布商品分类</span>
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
   

    商品分类：<IscControl:SyncSelector ID="syncSelectorShopProductCategories" runat="server" 
        DataSourceURL="<%$Resources:SyncSelector,ShopProductCategories_DataSourceURL %>" 
        DataSourceName="<%$Resources:SyncSelector,ShopProductCategories_DataSourceName %>" 
        ClientPostNames="<%$Resources:SyncSelector,ShopProductCategories_ClientPostNames %>"
        /> <button id="btnPublish">现在发布产品</button>
  
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">
<form id="frmPublish" method="post" action="New.aspx">
	<input type="hidden" id="cid" name="cid" />
</form>
</asp:Content>




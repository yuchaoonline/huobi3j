<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="New.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.Shop.Products.New" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
商家控制面板 - 发布商品
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
.CustomCategory{ border:1px solid #ccc; padding:5px; height:200px; width:600px; overflow-y:scroll; overflow-x:hidden; }
.masterCategory{ margin-bottom:10px; }
.subCategory{ margin:0px; padding:0px; padding-left:20px; }
.subCategory li{ list-style:none; float:left; width:150px; overflow:hidden; }

#Attributes{ margin:0px; padding:0px; list-style:none; border:1px solid #ccc; padding:10px;  }
#Attributes li{ height:25px; margin-bottom:10px;  }
#Attributes .attrName{ display:block; width:100px; float:left; text-align:right; }
#Attributes .attrValue{ display:block; width:400px; float:left; margin-left:10px; }
#Attributes .require{ }
</style>
<script type="text/javascript" src="/js/isc.ui.js"></script>
<script type="text/javascript" src="/js/Jquery.json.js"></script>
<script type="text/javascript">
$(document).ready(function(){

	//渲染属性表单控件
	$('#Attributes li span[@attrId!=""]').each(function(){
		var t = $(this),
			attrId = parseInt( t.attr('attrId') ) || 0,
			valueType = parseInt( t.attr('valueType') ) || 0;
		
		switch(valueType){
			case 0:
				 var input = $('<input type="text" />').attr('attrId',attrId).appendTo(t);
				 input.attr('id','txt'+attrId);
			     break;
			case 1:
			     var sel = $('<select>').attr('attrId',attrId).attr('id','sel' + attrId );
				 t.find('li').each(function(){
				 	var li = $(this),
				 		option = $('<option>');
					option.val( li.attr('value') );
					option.html( li.html() );
					option.appendTo(sel);
				 });
				 sel.appendTo(t);
				 break;
			case 2:
				 break;
			case 3:
				 t.find('li').each(function(){
				 	var li = $(this),
						value = li.attr('value'),
						text = $.trim(li.html());
						
				 	var chk = $('<input type="checkbox" />').attr('attrId',attrId).attr('id','chk' + value ).attr('name','attr' + attrId).val(value);
					var label = $('<label></label>').html(text);
					chk.appendTo(t);
					label.appendTo(t);
				 });
			     
				 break;
		}
	});
	
	$('#frmWeb').submit(function(){
		
		var cancel = false;
		var attrData = [];
		
		//验证并获取数据
		$('#Attributes span[@attrId!=""]').each(function(){
			var target = $(this),
				valueType = parseInt( target.attr('valueType') ) || 0,
				attrId = parseInt(target.attr('attrId')) || 0,
				isRequire = eval(target.attr('isRequire')),
				attrName = target.attr('attrName'),
				value = '';//当前属性的值
			switch(valueType){
				case 0:
					 value = target.find(':text').val();
					 break;
				case 1:
					 value = target.find('select').val();
					 break;
				case 2:
					 break;
				case 3:
					 var values = [];
					 target.find(":checkbox").each(function(){
					 	if($(this).get(0).checked)
					 		values.push( $(this).val() );
					 });
					 value = values.join(',');
					 break;
			}
			
			if(isRequire && value.length==0){
			   alert(isc.util.format('请设置商品属性 {0} 的值' , attrName) );
			   cancel = true;
			   return false;
			}else{
				attrData.push({attrId:attrId,value:value});
			}
		});
		
		if(cancel==true) return false;
		
		$('#<%=hfAttributeData.ClientID%>').val( $.toJSON(attrData) );
		return true;
	});
});
</script>
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">　</span><a href="/My/Corp/Shop/">在线营销</a><span class="spl">　</span><a href="/My/Corp/Shop/Products/">商品管理</a><span class="spl">　</span><span class="curPos">发布商品</span>
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
 <asp:HiddenField ID="hfAttributeData" runat="server" />
 <table border="0" cellspacing="0" cellpadding="0" class="formTable">
  <tr>
    <td class="tdLeft">商品标题：</td>
    <td class="tdRight">
        <asp:TextBox ID="txtProductName" runat="server" CssClass="txtBox" Width="400px"></asp:TextBox><span class="require">*</span><asp:RequiredFieldValidator
            ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtProductName" ErrorMessage="请填写产品标题!"></asp:RequiredFieldValidator>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">商品图片：</td>
    <td class="tdRight">
        <IscControl:FileUploadEx ID="filePicture0" runat="server" AllowFileSize="512000" AllowFileExt="jpg|jpeg|gif|png|bmp" /><span class="require">*</span>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">商品分类：</td>
    <td class="tdRight">
        <asp:Literal id="liteProductCategory" runat="server" />
    </td>
  </tr>
  <tr>
    <td class="tdLeft">商品属性：</td>
    <td class="tdRight">
		<ul id="Attributes">
        <asp:Repeater ID="rpAttributes" runat="server">
		<ItemTemplate>
		<li>
			<label class="attrName"><%#Eval("Name")%><%#(bool)Eval("IsValueRequire") ? "<span class=\"require\">*</span>" : ""%>：</label>
			<span class="attrValue" attrName="<%#HttpUtility.HtmlAttributeEncode((string)Eval("Name"))%>" attrId="<%#Eval("id")%>" valueType="<%#Eval("ValueType")%>" isRequire="<%#Eval("IsValueRequire").ToString().ToLower()%>"><%#GetAttrOptions((long)Eval("ID"))%></span>
		</li>
		</ItemTemplate>
		</asp:Repeater>
		</ul>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">商铺商品分类：</td>
    <td class="tdRight">
        <div class="CustomCategory">
            <asp:Repeater ID="rpCPCategories" runat="server" 
                onitemdatabound="rpCPCategories_ItemDataBound">
            <ItemTemplate>
            <div class="masterCategory">
                <input type="checkbox" id="chkCategoryID" runat="server" value='<%#Eval("ID") %>' /> <%#Eval("Name")%>
                <asp:Repeater ID="rpCPCategories02" runat="server">
                    <HeaderTemplate><ul class="subCategory"></HeaderTemplate>
                    <FooterTemplate><li style="float:none; clear:both;"></li></ul></FooterTemplate>
                    <ItemTemplate>
                    <li><input type="checkbox" id="chkCategoryID" runat="server" value='<%#((System.Data.DataRow)Container.DataItem)["ID"]%>' /> <%#((System.Data.DataRow)Container.DataItem)["Name"]%></li>
                    </ItemTemplate>
                </asp:Repeater>
             </div>
            </ItemTemplate>
            </asp:Repeater>
        </div>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">赠送额度：</td>
    <td class="tdRight">
        <asp:RadioButton ID="rbtnPrice1" runat="server" GroupName="rbtnPrice" Checked="true" /> <asp:TextBox ID="txtPrice" runat="server" CssClass="txtNum" Width="60px"></asp:TextBox> 元 
        <asp:RegularExpressionValidator ID="revTxtPrice" runat="server"  ControlToValidate="txtPrice" ErrorMessage="请填写正确的价格！" Display="Dynamic" ValidationExpression="^\d+$"></asp:RegularExpressionValidator> 
            <asp:RadioButton ID="rbtnPrice2" runat="server" GroupName="rbtnPrice" /> 
            <asp:TextBox ID="txtReturnPrecent" runat="server" CssClass="txtNum" Width="60px"></asp:TextBox>百分比 
            <asp:RegularExpressionValidator ID="revTxtPrice2" runat="server"  ControlToValidate="txtReturnPrecent" ErrorMessage="请填写正确百分比！" Display="Dynamic" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">浮动价格：</td>
    <td class="tdRight">
        <asp:TextBox ID="txtFloatPrice" runat="server" Width="200px"></asp:TextBox>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">销售时间：</td>
    <td class="tdRight">
        <asp:TextBox ID="txtSaleTime" runat="server" Width="200px"></asp:TextBox>
        <span class="tips">请填写促销时间范围</span>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">销售地点：</td>
    <td class="tdRight">
        <asp:TextBox ID="txtSaleAddress" runat="server" Width="200px"></asp:TextBox>
       <span class="tips">请填写促销地点</span>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">是否签合同：</td>
    <td class="tdRight">
        <asp:CheckBox ID="chkHasContract" runat="server" />是
    </td>
  </tr>
   <tr>
    <td class="tdLeft">排　　序：</td>
    <td class="tdRight">
        <asp:TextBox ID="txtSequence" runat="server" CssClass="txtNum" Width="40px" Text="9999"></asp:TextBox>
        <asp:RegularExpressionValidator ID="revTxtSequence" runat="server" ControlToValidate="txtSequence" Display="Dynamic" ErrorMessage="请填写正确的排序！"></asp:RegularExpressionValidator>
        <span class="tips">数值越大商品越派在前</span>
        
    </td>
  </tr>
  <tr>
    <td class="tdLeft">所在地区：</td>
    <td class="tdRight">
        <IscControl:SyncSelector ID="syncSelectorLocation" runat="server" 
        DataSourceURL="<%$Resources:SyncSelector,Location_DataSourceURL %>" 
        DataSourceName="<%$Resources:SyncSelector,Location_DataSourceName %>" 
        ClientPostNames="<%$Resources:SyncSelector,Location_ClientPostNames %>"
        InitClientDependency ="false"
        /><span class="tips">请选择商品所在地区</span>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">是否隐藏：</td>
    <td class="tdRight">
        <asp:CheckBox ID="IsHidden" runat="server" Text="是" />
    </td>
  </tr>
  <tr>
    <td class="tdLeft">是否推荐：</td>
    <td class="tdRight">
        <asp:CheckBox ID="IsRecommend" runat="server" Text="是" />
    </td>
  </tr>
  <tr>
    <td class="tdLeft">库　　存：</td>
    <td class="tdRight">
        <asp:TextBox ID="txtStock" runat="server" CssClass="txtNum" Width="60px"></asp:TextBox>
        <asp:RegularExpressionValidator ID="revTxtStock" runat="server" ControlToValidate="txtStock" Display="Dynamic" ErrorMessage="请填写正确的库存！"></asp:RegularExpressionValidator>
    </td>
  </tr>
  <%--<tr>
    <td class="tdLeft">描　　述：</td>
    <td class="tdRight">
        <asp:TextBox ID="txtSummary" runat="server" CssClass="txtNotes" TextMode="MultiLine" Columns="20" Rows="3"></asp:TextBox>
        <span class="tips">这里可以填写吸引消费者的商品信息</span>
    </td>
  </tr>--%>
  <tr >
        <td class="tdLeft">详细描述：</td>
        <td class="tdRight">
          <FCKeditorV2:FCKeditor ID="txtContent" ToolbarSet="Basic" runat="server" Width="600px" Height="200px" LinkBrowserURL="false"></FCKeditorV2:FCKeditor>
            <%--<asp:RequiredFieldValidator ID="rfvTxtContent" runat="server" ControlToValidate="txtContent" Display="Dynamic" ErrorMessage="请填写商品详细描述！"></asp:RequiredFieldValidator>--%>
          <span class="require">*</span>
        </td>
  </tr> 
  
  <tr >        
		<td class="tdLeft">
              
        </td>
        <td class="tdRight">
            <asp:Button ID="btnSubmit" runat="server" Text="发布"  
                    onclick="btnSubmit_Click"/>
        
        </td>
      </tr> 
</table>
   
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>




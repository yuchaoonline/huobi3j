<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="New.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.Shop.Products.New" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
�̼ҿ������ - ������Ʒ
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

	//��Ⱦ���Ա��ؼ�
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
		
		//��֤����ȡ����
		$('#Attributes span[@attrId!=""]').each(function(){
			var target = $(this),
				valueType = parseInt( target.attr('valueType') ) || 0,
				attrId = parseInt(target.attr('attrId')) || 0,
				isRequire = eval(target.attr('isRequire')),
				attrName = target.attr('attrName'),
				value = '';//��ǰ���Ե�ֵ
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
			   alert(isc.util.format('��������Ʒ���� {0} ��ֵ' , attrName) );
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
<span class="spl">��</span><a href="/My/Corp/Shop/">����Ӫ��</a><span class="spl">��</span><a href="/My/Corp/Shop/Products/">��Ʒ����</a><span class="spl">��</span><span class="curPos">������Ʒ</span>
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
 <asp:HiddenField ID="hfAttributeData" runat="server" />
 <table border="0" cellspacing="0" cellpadding="0" class="formTable">
  <tr>
    <td class="tdLeft">��Ʒ���⣺</td>
    <td class="tdRight">
        <asp:TextBox ID="txtProductName" runat="server" CssClass="txtBox" Width="400px"></asp:TextBox><span class="require">*</span><asp:RequiredFieldValidator
            ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtProductName" ErrorMessage="����д��Ʒ����!"></asp:RequiredFieldValidator>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">��ƷͼƬ��</td>
    <td class="tdRight">
        <IscControl:FileUploadEx ID="filePicture0" runat="server" AllowFileSize="512000" AllowFileExt="jpg|jpeg|gif|png|bmp" /><span class="require">*</span>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">��Ʒ���ࣺ</td>
    <td class="tdRight">
        <asp:Literal id="liteProductCategory" runat="server" />
    </td>
  </tr>
  <tr>
    <td class="tdLeft">��Ʒ���ԣ�</td>
    <td class="tdRight">
		<ul id="Attributes">
        <asp:Repeater ID="rpAttributes" runat="server">
		<ItemTemplate>
		<li>
			<label class="attrName"><%#Eval("Name")%><%#(bool)Eval("IsValueRequire") ? "<span class=\"require\">*</span>" : ""%>��</label>
			<span class="attrValue" attrName="<%#HttpUtility.HtmlAttributeEncode((string)Eval("Name"))%>" attrId="<%#Eval("id")%>" valueType="<%#Eval("ValueType")%>" isRequire="<%#Eval("IsValueRequire").ToString().ToLower()%>"><%#GetAttrOptions((long)Eval("ID"))%></span>
		</li>
		</ItemTemplate>
		</asp:Repeater>
		</ul>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">������Ʒ���ࣺ</td>
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
    <td class="tdLeft">���Ͷ�ȣ�</td>
    <td class="tdRight">
        <asp:RadioButton ID="rbtnPrice1" runat="server" GroupName="rbtnPrice" Checked="true" /> <asp:TextBox ID="txtPrice" runat="server" CssClass="txtNum" Width="60px"></asp:TextBox> Ԫ 
        <asp:RegularExpressionValidator ID="revTxtPrice" runat="server"  ControlToValidate="txtPrice" ErrorMessage="����д��ȷ�ļ۸�" Display="Dynamic" ValidationExpression="^\d+$"></asp:RegularExpressionValidator> 
            <asp:RadioButton ID="rbtnPrice2" runat="server" GroupName="rbtnPrice" /> 
            <asp:TextBox ID="txtReturnPrecent" runat="server" CssClass="txtNum" Width="60px"></asp:TextBox>�ٷֱ� 
            <asp:RegularExpressionValidator ID="revTxtPrice2" runat="server"  ControlToValidate="txtReturnPrecent" ErrorMessage="����д��ȷ�ٷֱȣ�" Display="Dynamic" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">�����۸�</td>
    <td class="tdRight">
        <asp:TextBox ID="txtFloatPrice" runat="server" Width="200px"></asp:TextBox>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">����ʱ�䣺</td>
    <td class="tdRight">
        <asp:TextBox ID="txtSaleTime" runat="server" Width="200px"></asp:TextBox>
        <span class="tips">����д����ʱ�䷶Χ</span>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">���۵ص㣺</td>
    <td class="tdRight">
        <asp:TextBox ID="txtSaleAddress" runat="server" Width="200px"></asp:TextBox>
       <span class="tips">����д�����ص�</span>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">�Ƿ�ǩ��ͬ��</td>
    <td class="tdRight">
        <asp:CheckBox ID="chkHasContract" runat="server" />��
    </td>
  </tr>
   <tr>
    <td class="tdLeft">�š�����</td>
    <td class="tdRight">
        <asp:TextBox ID="txtSequence" runat="server" CssClass="txtNum" Width="40px" Text="9999"></asp:TextBox>
        <asp:RegularExpressionValidator ID="revTxtSequence" runat="server" ControlToValidate="txtSequence" Display="Dynamic" ErrorMessage="����д��ȷ������"></asp:RegularExpressionValidator>
        <span class="tips">��ֵԽ����ƷԽ����ǰ</span>
        
    </td>
  </tr>
  <tr>
    <td class="tdLeft">���ڵ�����</td>
    <td class="tdRight">
        <IscControl:SyncSelector ID="syncSelectorLocation" runat="server" 
        DataSourceURL="<%$Resources:SyncSelector,Location_DataSourceURL %>" 
        DataSourceName="<%$Resources:SyncSelector,Location_DataSourceName %>" 
        ClientPostNames="<%$Resources:SyncSelector,Location_ClientPostNames %>"
        InitClientDependency ="false"
        /><span class="tips">��ѡ����Ʒ���ڵ���</span>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">�Ƿ����أ�</td>
    <td class="tdRight">
        <asp:CheckBox ID="IsHidden" runat="server" Text="��" />
    </td>
  </tr>
  <tr>
    <td class="tdLeft">�Ƿ��Ƽ���</td>
    <td class="tdRight">
        <asp:CheckBox ID="IsRecommend" runat="server" Text="��" />
    </td>
  </tr>
  <tr>
    <td class="tdLeft">�⡡���棺</td>
    <td class="tdRight">
        <asp:TextBox ID="txtStock" runat="server" CssClass="txtNum" Width="60px"></asp:TextBox>
        <asp:RegularExpressionValidator ID="revTxtStock" runat="server" ControlToValidate="txtStock" Display="Dynamic" ErrorMessage="����д��ȷ�Ŀ�棡"></asp:RegularExpressionValidator>
    </td>
  </tr>
  <%--<tr>
    <td class="tdLeft">�衡������</td>
    <td class="tdRight">
        <asp:TextBox ID="txtSummary" runat="server" CssClass="txtNotes" TextMode="MultiLine" Columns="20" Rows="3"></asp:TextBox>
        <span class="tips">���������д���������ߵ���Ʒ��Ϣ</span>
    </td>
  </tr>--%>
  <tr >
        <td class="tdLeft">��ϸ������</td>
        <td class="tdRight">
          <FCKeditorV2:FCKeditor ID="txtContent" ToolbarSet="Basic" runat="server" Width="600px" Height="200px" LinkBrowserURL="false"></FCKeditorV2:FCKeditor>
            <%--<asp:RequiredFieldValidator ID="rfvTxtContent" runat="server" ControlToValidate="txtContent" Display="Dynamic" ErrorMessage="����д��Ʒ��ϸ������"></asp:RequiredFieldValidator>--%>
          <span class="require">*</span>
        </td>
  </tr> 
  
  <tr >        
		<td class="tdLeft">
              
        </td>
        <td class="tdRight">
            <asp:Button ID="btnSubmit" runat="server" Text="����"  
                    onclick="btnSubmit_Click"/>
        
        </td>
      </tr> 
</table>
   
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>




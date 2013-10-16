<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Edit.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.CorpImage.Videos.Edit" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
商家控制面板 - 修改企业视频
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    $(document).ready(function() {
        $('#TDSelectVideo :radio').click(function() {
            $('#TDSelectVideo :radio').next().next().find(':input').attr('disabled', 'disabled');
            $(this).next().next().find(':input').attr('disabled', '');
        }).eq(1).trigger('click')
    });
	
	$('form').submit(function(){
		$('#TDSelectVideo :radio').next().next().find(':input').attr('disabled', '');//避免input 值在服务端解释时丢失
	});
</script>

</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">　</span><a href="/My/Corp/CorpImage/Videos/">企业视频</a><span class="spl">　</span><span class="curPos">修改</span> 
      </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
       
   
   <table border="0" cellspacing="0" cellpadding="0" class="formTable">
  <tr>
    <td class="tdLeft">视频标题<span class="require">*</span>：</td>
    <td class="tdRight">
        <asp:TextBox ID="txtTitle" runat="server" CssClass="txtBox" Width="300"></asp:TextBox>
    </td>
  </tr>
   <tr>
    <td class="tdLeft">选择视频<span class="require">*</span>：</td>
    <td class="tdRight" id="TDSelectVideo">
    
        <div>
            <asp:RadioButton ID="rbtnUpload" runat="server" Text="上传视频" GroupName="selectVideo" />
			<span>
				 <IscControl:FileUploadEx ID="fileVideo" runat="server" AllowFileExt="flv" AllowFileSize="10485760" />
				 <div class="tips">
						上传文件类型：<%=fileVideo.AllowFileExt%>,文件大小限制：<%=(int)(fileVideo.AllowFileSize / 1024 / 1024)%>MB
				 </div>
			 </span>
         
        </div>
         <br />
        <div>
            <asp:RadioButton ID="rbtnExternalURL" runat="server" Text="网络视频" GroupName="selectVideo"  />
			<span>
            <asp:TextBox ID="txtExternalURL" runat="server" Text="http://" Width="500"></asp:TextBox>
            <div class="tips">
                请将网络上视频(FLV格式)的地址复制到文本框中
            </div>
			</span>
        
        </div>
     </td>
  </tr>
  <tr>
    <td class="tdLeft">预览图片<span class="require">*</span>：</td>
    <td class="tdRight">
        <IscControl:FileUploadEx ID="fileVideoPreview" runat="server" AllowFileExt="jpg|jpeg|gif|png" AllowFileSize="204800" /> 
				 <div class="tips">
						请上传视频预览图片,文件类型：<%=fileVideoPreview.AllowFileExt%>,文件大小：<%=(int)(fileVideoPreview.AllowFileSize / 1024)%>KB
				 </div>
				 <img src="<%=this.fileVideoPreview.DefaultValue%>" onload="isc.util.zoomImg(this,120,120)" />
    </td>
  </tr>
   <tr>
    <td class="tdLeft">排　　序：</td>
    <td class="tdRight">
        <asp:TextBox ID="txtSequence" runat="server" CssClass="txtBox"></asp:TextBox>
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
    <td class="tdLeft">描　　述：</td>
    <td class="tdRight">
        <asp:TextBox ID="txtSummary" runat="server" TextMode="MultiLine" Rows="4" Columns="50" CssClass="txtNotes"/>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">审　　核：</td>
    <td class="tdRight">
         <asp:Literal ID="liteCheckState" runat="server"></asp:Literal>
    </td>
  </tr>
  <tr>
        <td class="tdLeft">创建时间：</td>
        <td class="tdRight">
            <asp:Literal ID="liteCreateTime" runat="server"></asp:Literal>
        </td>
  </tr>
   <tr >        
		<td class="tdLeft">
              <asp:Button ID="Button1" runat="server" Text="修改"  
                    onclick="btnSubmit_Click"/>
        </td>
        <td class="tdRight">
            <a href="javascript:history.back();">返回</a>
        </td>
      </tr> 
</table>
       
   
       
    </asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>




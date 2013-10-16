<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Edit.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.CorpImage.Videos.Edit" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
�̼ҿ������ - �޸���ҵ��Ƶ
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
		$('#TDSelectVideo :radio').next().next().find(':input').attr('disabled', '');//����input ֵ�ڷ���˽���ʱ��ʧ
	});
</script>

</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">��</span><a href="/My/Corp/CorpImage/Videos/">��ҵ��Ƶ</a><span class="spl">��</span><span class="curPos">�޸�</span> 
      </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
       
   
   <table border="0" cellspacing="0" cellpadding="0" class="formTable">
  <tr>
    <td class="tdLeft">��Ƶ����<span class="require">*</span>��</td>
    <td class="tdRight">
        <asp:TextBox ID="txtTitle" runat="server" CssClass="txtBox" Width="300"></asp:TextBox>
    </td>
  </tr>
   <tr>
    <td class="tdLeft">ѡ����Ƶ<span class="require">*</span>��</td>
    <td class="tdRight" id="TDSelectVideo">
    
        <div>
            <asp:RadioButton ID="rbtnUpload" runat="server" Text="�ϴ���Ƶ" GroupName="selectVideo" />
			<span>
				 <IscControl:FileUploadEx ID="fileVideo" runat="server" AllowFileExt="flv" AllowFileSize="10485760" />
				 <div class="tips">
						�ϴ��ļ����ͣ�<%=fileVideo.AllowFileExt%>,�ļ���С���ƣ�<%=(int)(fileVideo.AllowFileSize / 1024 / 1024)%>MB
				 </div>
			 </span>
         
        </div>
         <br />
        <div>
            <asp:RadioButton ID="rbtnExternalURL" runat="server" Text="������Ƶ" GroupName="selectVideo"  />
			<span>
            <asp:TextBox ID="txtExternalURL" runat="server" Text="http://" Width="500"></asp:TextBox>
            <div class="tips">
                �뽫��������Ƶ(FLV��ʽ)�ĵ�ַ���Ƶ��ı�����
            </div>
			</span>
        
        </div>
     </td>
  </tr>
  <tr>
    <td class="tdLeft">Ԥ��ͼƬ<span class="require">*</span>��</td>
    <td class="tdRight">
        <IscControl:FileUploadEx ID="fileVideoPreview" runat="server" AllowFileExt="jpg|jpeg|gif|png" AllowFileSize="204800" /> 
				 <div class="tips">
						���ϴ���ƵԤ��ͼƬ,�ļ����ͣ�<%=fileVideoPreview.AllowFileExt%>,�ļ���С��<%=(int)(fileVideoPreview.AllowFileSize / 1024)%>KB
				 </div>
				 <img src="<%=this.fileVideoPreview.DefaultValue%>" onload="isc.util.zoomImg(this,120,120)" />
    </td>
  </tr>
   <tr>
    <td class="tdLeft">�š�����</td>
    <td class="tdRight">
        <asp:TextBox ID="txtSequence" runat="server" CssClass="txtBox"></asp:TextBox>
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
    <td class="tdLeft">�衡������</td>
    <td class="tdRight">
        <asp:TextBox ID="txtSummary" runat="server" TextMode="MultiLine" Rows="4" Columns="50" CssClass="txtNotes"/>
    </td>
  </tr>
  <tr>
    <td class="tdLeft">�󡡡��ˣ�</td>
    <td class="tdRight">
         <asp:Literal ID="liteCheckState" runat="server"></asp:Literal>
    </td>
  </tr>
  <tr>
        <td class="tdLeft">����ʱ�䣺</td>
        <td class="tdRight">
            <asp:Literal ID="liteCreateTime" runat="server"></asp:Literal>
        </td>
  </tr>
   <tr >        
		<td class="tdLeft">
              <asp:Button ID="Button1" runat="server" Text="�޸�"  
                    onclick="btnSubmit_Click"/>
        </td>
        <td class="tdRight">
            <a href="javascript:history.back();">����</a>
        </td>
      </tr> 
</table>
       
   
       
    </asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>




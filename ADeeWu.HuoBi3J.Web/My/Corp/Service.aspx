<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Service.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.Service" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
�̼ҿ������ - ��ɫ����/��Ӫ��Χ
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">��</span><span class="curPos">��ɫ����/��Ӫ��Χ</span>
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
<table class="formTable">
	<tr>
        <td class="tdLeft">��ɫ����/��Ӫ��Χ��</td>
        <td class="tdRight">
			<asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Width="100%" 
                        Height="200" CssClass="txtNotes"></asp:TextBox><asp:RequiredFieldValidator ID="rfvContent"
                            runat="server" ErrorMessage="����д���ݣ�" ControlToValidate="txtContent" Display="Dynamic"></asp:RequiredFieldValidator><span class="require">
            *</span>
                            <div class="tips">
                                ����д��˾�ľ�Ӫ��Χ����ɫ�������з���Υ�����ݣ�����ֹͣʹ�ã�
                            </div>
		</td>
    </tr>
    <tr>
        <td class="tdLeft"></td>
        <td class="tdRight">
            <asp:Button ID="btnSubmit" runat="server" Text="�ύ" onclick="btnSubmit_Click" />
		</td>
    </tr>
</table>



</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>




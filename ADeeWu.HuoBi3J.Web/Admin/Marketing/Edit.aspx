<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="Edit.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.Marketing.Edit" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="CashTicketControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
�ޱ����ĵ�
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>����Ӫ��</span> &gt; <a href="List.aspx">�б�</a> &gt; �޸�
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    
    <div>
     <table width="100%" border="0" cellspacing="1" cellpadding="5">
			<tr>
                <td valign="top" width="100px">���⣺</td>
                <td valign="top" >
                    <asp:TextBox ID="txtTitle" runat="server" Width="50%" CssClass="txtBox"></asp:TextBox>
                    <span class="require">*</span></td>
                <td valign="top" >&nbsp;
                    </td>
            </tr>
            <tr>
                <td valign="top">�������ࣺ</td>
                <td valign="top" colspan="2" >
                    
                    <asp:DropDownList ID="DropDownList1" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
              <tr>
                <td valign="top">��Ӫ��ʽ��</td>
                <td valign="top" colspan="2" >
                   <asp:DropDownList ID="ddlBusinessType" runat="server">
                        <asp:ListItem Value="0">��������</asp:ListItem>
                        <asp:ListItem Value="1">ʵ�����</asp:ListItem>
                        <asp:ListItem Value="2">����+ʵ�����</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
             
            <tr>
                <td valign="top">�Ƽ���</td>
                <td valign="top" colspan="2" >
                    
                    <asp:CheckBox ID="cboIsRecommend" runat="server" />
                </td>
            </tr>
            <tr>
                <td valign="top">���أ�</td>
                <td valign="top" colspan="2" >
                    
                    <asp:CheckBox ID="cboIsHidden" runat="server" />
                </td>
            </tr>
            <tr>
                <td valign="top">���ʴ�����</td>
                <td valign="top" colspan="2" >
                    
                    <asp:Label ID="lblVisteCount" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td valign="top">���״̬��</td>
                <td valign="top" colspan="2" >
                    
                    <asp:RadioButton ID="radstate"  GroupName="state" runat="server" Checked=true Text="���޸�״̬" />
               <asp:RadioButton ID="cbochecktrue" GroupName="state" runat="server" Text="ͨ��" />
                    &nbsp;<asp:RadioButton ID="cbocheckfalse" GroupName="state"  runat="server" Text="��ͨ��" />
                    &nbsp;<asp:RadioButton ID="cboStateEnd"  GroupName="state" runat="server" Text="���Ϊ����" />

                </td>
            </tr>
            <tr>
                <td valign="top">����ʱ�䣺</td>
                <td valign="top" colspan="2" >
                    
                    <asp:Label ID="lblCreateTime" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td valign="top">����޸�ʱ�䣺</td>
                <td valign="top" colspan="2" >
                    
                    <asp:Label ID="lblUpdateTime" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td valign="top">���ˢ��ʱ�䣺</td>
                <td valign="top" colspan="2" >
                    
                    <asp:Label ID="lblReTime" runat="server"></asp:Label>
                </td>
            </tr>
			<tr>
                <td valign="top">������</td>
                <td valign="top" >
                    <asp:TextBox ID="txtSummary" runat="server" TextMode="MultiLine" Width="100%" 
                        Height="72px"></asp:TextBox>
				</td>
                <td valign="bottom" width="5px">
                    <span class="require">*</span></td>
            </tr>
			<tr>
                <td valign="top">��ϸ��</td>
                <td valign="top" >
                    <FCKeditorV2:FCKeditor ID="txtContent" ToolbarSet="Basic" runat="server" Width="100%" Height="200" LinkBrowserURL="false"></FCKeditorV2:FCKeditor>
                    
				</td>
                <td valign="bottom"  width="5px">
                    <span class="require">*</span></td>
            </tr>
            <tr>
                <td >&nbsp;
                    </td>
                <td colspan="2">
                     <asp:Button ID="btnOK" runat="server" Text="����"  OnClick="btnOK_Click" />
                      
                </td>
            </tr>
        </table>
    </div>
    
</asp:Content>


    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
     
 

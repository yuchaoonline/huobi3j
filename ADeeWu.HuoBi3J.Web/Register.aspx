<%@ Page Language="C#" Title="" MasterPageFile="~/MIndex.master"  AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
ȫ��Ӫ���� - �û�ע��
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="/js/isc.js"></script>
<script type="text/javascript">
function UINSelector_OnLoad(o)
{
	o.onSelected = function(keyValue)
	{
		document.getElementById("<%=fhUIN.ClientID%>").value = keyValue.uin;
	};
}

function hideUIN() {
    $('#iframeSelectUIN').hide();
}

function showUIN() {
    $('#iframeSelectUIN').show().attr('src', 'selectUIN.aspx');
}

$(function() {
    if ($('#<%=radAuto.ClientID%>').get(0).checked) {
        hideUIN();
    } else if ($('#radSelMySelf').get(0).checked) {
        showUIN();
    }
});
	
</script>

<style type="text/css">
#Main{ color:#1e5ea7; }
#Main a{ color:#1e5ea7; }
.tdLeft{ text-align:right; vertical-align:middle; color:#000; font-size:13px; }
.input{ width:300px; height:24px; border:1px solid #1e5ea7; }
.BtnRegister{ border:none; background:url(images/btnRegister.gif) no-repeat; width:103px; height:32px; cursor:pointer; }
</style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
    <asp:HiddenField ID="fhUIN" runat="server" />
    
    <div id="regist">
        <p class="tip1 black4B font14 fb">��ע���û���ʹ��ͨѶ���롢�ʺŻ�Email��½ϵͳ</p>
        <ul class="fill_info">
            <li class="zoom">
                <span class="db l form_title font14">ѡ��ͨѶ���룺</span>
                <span class="db l" style="width: 450px;">
                    <asp:RadioButton ID="radAuto" runat="server" Text="ϵͳ�Զ�����" GroupName="number" Checked="true" onclick="hideUIN();" />
                    <asp:RadioButton ID="radSelMySelf" runat="server" Text="���Լ�ѡ����" GroupName="number" onclick="showUIN();" />
                    <label class="orange">*</label>
                    <div>
                        <iframe src="" width="100%" height="130px" frameborder="0" scrolling="no" id="iframeSelectUIN" style="display: none;"></iframe>
                    </div>
                </span>
            </li>
            <li class="zoom">
                <span class="db l form_title font14">�˺ţ�</span>
                <span class="db l">
                    <asp:TextBox ID="txtLoginName" runat="server" CssClass="input_text"></asp:TextBox><span class="require">
                    <label class="orange">*ע��:�˺Ų���ȫ������</label>
                    <p class="tip">�ʺ��ɴ�Сд��ĸ�����ֻ��»�����ɣ����Ȳ�������6���ַ������Ҳ��ܴ���12���ַ�</p>
                    <asp:RegularExpressionValidator ID="revLoginName" runat="server" ErrorMessage="�밴�ո�ʽ��д!" ControlToValidate="txtLoginName" ValidationExpression="^[\d\w_]{6,12}$" Display="Dynamic"></asp:RegularExpressionValidator>
                </span>
            </li>
            <li class="zoom">
                <span class="db l form_title font14">E-mail��</span>
                <span class="db l">
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="input_text"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="����д��ȷ��Email��ַ"></asp:RegularExpressionValidator>
                    <label class="orange">&nbsp;</label>
                    <p class="tip">��������ʱ����ϵͳ�����µ����뵽ָ���������ȡ������,Ҳ���Զ�����վ�����Ѷ</p>
                </span>
            </li>
            <li class="zoom">
                <span class="db l form_title font14">���룺</span>
                <span class="db l">
                    <asp:TextBox ID="txtLoginPwd" runat="server" TextMode="Password" CssClass="input_text"></asp:TextBox>
                    <label class="orange">*</label>
                </span>
            </li>
            <li class="zoom">
                <span class="db l form_title font14">����ȷ�ϣ�</span>
                <span class="db l">
                    <asp:TextBox ID="txtLoginPwd2" runat="server" TextMode="Password" CssClass="input_text"></asp:TextBox>
                    <label class="orange">*</label>
                </span>
            </li>
            <li class="zoom">
                <span class="db l form_title font14">������</span>
                <span class="db l">
                    <asp:TextBox ID="txtName" runat="server" CssClass="input_text"></asp:TextBox><label class="orange">&nbsp;</label>
                </span>
            </li>
            <li class="zoom">
                <span class="db l form_title font14">��ϵ�绰��</span>
                <span class="db l">
                    <asp:TextBox ID="txtTel" runat="server" CssClass="input_text"></asp:TextBox>
                    <label>��д������ϵ�绰�ɷ������Ǽ�ʱΪ������</label>
                </span>
            </li>
            <li class="zoom">
                <span class="db l form_title font14">��֤�룺</span>
                <asp:TextBox ID="txtValidCode" runat="server" Width="50px" CssClass="input_text"></asp:TextBox>
                <img src="ValidateCode.aspx" class="varify_code" width="75ox" height="21px" alt="��֤��" />
            </li>
            <li>
                <asp:Button ID="btnSubmit" runat="server" Text="ע��" OnClick="btnSubmit_Click" CssClass="btn_blue btn_regist" />
            </li>
            <li class="zoom">
                <span class="orange db l ">ע:�� * ��ʾ�����</span>
            </li>

        </ul>
    </div>
</asp:Content>
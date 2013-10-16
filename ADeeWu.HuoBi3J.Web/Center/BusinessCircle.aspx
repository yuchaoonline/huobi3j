<%@ Page Language="C#" Title="" MasterPageFile="~/MIndex.master"  AutoEventWireup="true" CodeBehind="BusinessCircle.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Center.BusinessCircle" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
ȫ���� - ��Ȧ����
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<link href="/CSS/forum_common.css" rel="stylesheet" type="text/css" />
<link href="/CSS/forum_forumdisplay.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="/js/jquery.watermark.js" ></script>
<script type="text/javascript" src="/js/user.js" ></script>
<script>
    $(function () {
        $('.newKey').btnLogin({ title: '��ӹؼ���' });
        $('[name=keyName]').watermark('����ؼ���');

        $('#btnSubmit').click(function () {
            var parent = $(this).parent();
            var bid = parent.find('input[name=bid]:hidden').val();
            var keyName = parent.find('input[name=keyName]').val();
            if (keyName == '') {
                alert("�ؼ������Ʋ���Ϊ�գ�");
                return false;
            }

            $.getJSON('/ajax/center.ashx', { method: 'AddKey', bid: bid, name: keyName }, function (data) {
                if (data.statue) {
                    parent.hide();
                    location.href = '<%= Request.RawUrl %>';
                } else {
                    if (data.msg)
                        alert(data.msg);
                    else
                        parent.append("<font color='red'>�ύ���������ԣ�</font>");
                }
            })

            return false;
        })

        $('.btnswitch').each(function (item, index) {
            var $this = $(this);
            if ($this.val()=='true') {
                $this.parent().find('.add').show();
                $this.parent().find('.attention').hide();
            }
        })
    })
</script>
<style>
#Main
    {
        position: relative;
    }
</style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
    <span class="center"><a href="Default.aspx" title="����">����</a></span>>>
    <span class="location"><asp:Literal ID="litLocation" runat="server"></asp:Literal></span>>>
    <span class="bname"><asp:Literal ID="litBName" runat="server"></asp:Literal></span>
    
    <div id="center_list">
        <div class="centerP_body">
            <div class="body_content font14 black70">
                <p>
                    <span class="fb black32">��������Ϣ</span>
                </p>
                <asp:Repeater ID="rpInfo" runat="server">
                    <ItemTemplate>
                        <p class="mt10">
                            <span>�����ˣ�<label><%# Eval("Name") %></label></span><span>QQ��<label><%# Eval("QQ") %></label></span><span>��ϵ��ʽ��<label><%# Eval("Phone") %></label></span></p>
                        <p class="mt10">
                            <span>��˾���ƣ�<label><%# Eval("companyname") %></label></span><span>��˾��ַ��<label><%# Eval("companyaddress") %></label></span><span>��飺<label><%# Eval("memo") %></label></span></p>
                        
                    </ItemTemplate>
                </asp:Repeater>
            </div>

            <p class="mt10">
                    <button class="newKey btn_blue89">��ӹؼ���</button>
                    <div class="PostKey" style="display: none;">
                        <input type="hidden" name="bid" value="<%= Request["bid"] %>" />
                        <input type="text" name="keyName" value="" />
                        <button id="btnSubmit" class="button">�ύ</button>
                    </div>
                </p>
        </div>
        <div class="centerP_head"></div>
    </div>

    <table id="rentP_list" class="table_list font14" cellpadding="0" cellspacing="0">
        <thead>
            <tr height="30px" class="black70 fb font12">
                <% if(ADeeWu.HuoBi3J.Web.Class.SaleManSession.IsSaleMan||IsDefaultBussinessCircle) {%>
                <td class="arc_title" width="545px">�ؼ���</td>
                <% }else{ %>
                <td class="arc_title" width="645px">�ؼ���</td>
                <% } %>
                <td width="140px ">������</td>
                <td width="100px">���ʱ��</td>
                <td width="200px">����</td>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rpResult" runat="server">
                <ItemTemplate>
                    <tr height="40px" onmouseover="this.className='jobMenu_hover'" onmouseout="this.className=''" class="">
                        <td class="arc_title">
                            <a class="xst question" href="key4product.aspx?kid=<%# Eval("KID") %>" title="<%# Eval("KName") %>"><%# Eval("KName") %></a>
                        </td>
                        <td><%# Eval("QuestionCount") %></td>
                        <td><%# Eval("KCreateTime")%></td>
                        <td>
                            <%
                                if (ADeeWu.HuoBi3J.Web.Class.SaleManSession.IsSaleMan)
                                {
                            %>
                            <input type="hidden" class="btnswitch" value="<%# IsAttention(Eval("kid")) %>" />
                            <a class="xst add btn_blue" style="color: #fff; font-size: 12px; display: none;" href="key4add.aspx?kid=<%# Eval("KID") %>" title="��Ӽ۸�">��Ӽ۸�</a>
                            <a class="xst attention btn_blue" style="color: #fff; font-size: 12px;" href="AttentionKey.aspx?kid=<%# Eval("KID") %>" title="��ע�ؼ���">��ע</a>
                            <% } %>
                            <%if(IsDefaultBussinessCircle){ %>
                            <a href="MoveCircle.aspx?kid=<%# Eval("KID") %>" class="btn_blue" style="color: #fff; font-size: 12px;" title="ָ����Ȧ">ָ����Ȧ</a>
                            <%} %>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>

    <div class="pager" align="center">
        <IscControl:Pager ID="Pager1" runat="server"  />
    </div>
</asp:Content>
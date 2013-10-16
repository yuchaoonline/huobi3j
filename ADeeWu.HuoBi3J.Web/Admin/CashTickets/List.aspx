<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="List.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.CashTickets.List"  %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="CashTicketControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
Admin - CashTickets - List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script src="/JS/jquery.js"></script>
    <script>
        $(function () {
            $('[name=checkall]:checkbox').change(function () {
                if ($(this).attr('checked') == 'checked')
                    $('[name=gvData]:checkbox').attr('checked', 'checked');
                else
                    $('[name=gvData]:checkbox').removeAttr('checked');
            })
            $('#btnPoint').click(function () {
                var selectCBs = $('[name=gvData]:checkbox:checked');
                if (selectCBs.length <= 0) {
                    alert('��ѡ��Ҫָ����ȯ��');
                    return false;
                }
                var selectValues = '';
                selectCBs.each(function (i) {
                    selectValues += ',' + $(this).val();
                })
                if (selectValues == '') return false;

                selectValues = selectValues.substring(1, selectValues.length);
                $.get('point.aspx', { selectValues: selectValues, corpid: $('#<%=ddlCorp.ClientID %>').val() }, function (data) {
                    if (data == 'ok') {
                        alert('����ɹ���');
                        location.href = '<%= Request.RawUrl%>';
                    } else {
                        alert(data);
                    }
                })
            })
        })
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>�ֽ�ȯ����</span> &gt; �ֽ�ȯ�б�  | <a href="Add.aspx">���(ϵͳ����)</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
<input type="hidden" name="page"  value="1" />
<table class="searchTable">
    <tr>
        <td class="key">�̼�����:</td>
        <td class="input">
            <input type="text" name="corp" class="txtBox" id="corp" runat="server" />
        </td>
        <td class="key">�ֽ�ȯ���к�:</td>
        <td class="input">
           <input type="text" name="serialNum" class="txtBox" id="serialNum" runat="server" />
        </td>
        <td class="key">״̬:</td>
        <td class="input">
            <select name="state" runat="server" id="state">
                <option value="-1">ȫ��</option>
                <option value="0">�����(δʹ��)</option>
                <option value="1">�����(��ʹ��)</option>
                <option value="2">��Ч</option>
                <option value="3">�ѹ���</option>
            </select>
        </td>
        <td>
             <input type="submit" value="����" />
        </td>
    </tr>
    <tr>
        <td>ָ��ʹ���̼ң���ָ�����ֽ�ȯ�����޸ģ���</td>
        <td colspan="5">
            <asp:DropDownList ID="ddlCorp" runat="server"></asp:DropDownList>
        </td>
        <td>
            <input type="button" value="ָ��" id="btnPoint" />
        </td>
    </tr>
</table>

<asp:GridView ID="gvData" runat="server" CssClass="dataGrid" SkinID="gridviewSkin" AutoGenerateColumns="False" BorderStyle="None">
<Columns>
    <asp:TemplateField HeaderStyle-CssClass="col_id"  ItemStyle-CssClass="col_id" HeaderText="ID">
        <HeaderTemplate>
            <input type="checkbox" name="checkall" />ȫѡ
        </HeaderTemplate>
        <ItemTemplate>
            <input type="checkbox" name="<% = gvData.ID %>" value="<%#Eval("ID") %>" /> <%#Eval("ID") %>
        </ItemTemplate>    

<HeaderStyle CssClass="col_id"></HeaderStyle>

<ItemStyle CssClass="col_id"></ItemStyle>
    </asp:TemplateField>
    <asp:BoundField HeaderText="�����̼�" HeaderStyle-CssClass="col_title"  ItemStyle-CssClass="col_title" DataField="CorpName" >
<HeaderStyle CssClass="col_title"></HeaderStyle>

<ItemStyle CssClass="col_title"></ItemStyle>
    </asp:BoundField>
    <asp:HyperLinkField HeaderText="�ֽ�ȯ���к�" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" DataNavigateUrlFields="id" DataNavigateUrlFormatString="Edit.aspx?id={0}" DataTextField="SerialNum" >
<HeaderStyle CssClass="col_title"></HeaderStyle>

<ItemStyle CssClass="col_title"></ItemStyle>
    </asp:HyperLinkField>
    <asp:BoundField HeaderText="�ֽ�ȯ��֤��" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" DataField="ValidCode"  >
    
<HeaderStyle CssClass="col_title"></HeaderStyle>

<ItemStyle CssClass="col_title"></ItemStyle>
    </asp:BoundField>
    
    <asp:BoundField DataField="Money" HeaderText="���" />
    
    <asp:BoundField HeaderText="����ʱ��" HeaderStyle-CssClass="col_datetime"  ItemStyle-CssClass="col_datetime" DataField="CreateTime" HtmlEncode="true" DataFormatString="{0:d}" >
<HeaderStyle CssClass="col_datetime"></HeaderStyle>

<ItemStyle CssClass="col_datetime"></ItemStyle>
    </asp:BoundField>
    <asp:TemplateField HeaderStyle-CssClass="col_state"  ItemStyle-CssClass="col_state" HeaderText="״̬">
        <ItemTemplate>
            <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                Eval("CheckState").ToString(),
                new string[][]{
                    new string[]{"0","�����(δʹ��)"},
                    new string[]{"1","�����(��ʹ��)"},
                    new string[]{"2","��Ч"},
                    new string[]{"3","����"}
                }               
                )
            %>
        </ItemTemplate>    

<HeaderStyle CssClass="col_state"></HeaderStyle>

<ItemStyle CssClass="col_state"></ItemStyle>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="����" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option">
        <ItemTemplate>
            <a href="Edit.aspx?id=<%#Eval("ID") %>">�޸�</a>
        </ItemTemplate>

<HeaderStyle CssClass="col_option"></HeaderStyle>

<ItemStyle CssClass="col_option"></ItemStyle>
    </asp:TemplateField>
    
</Columns>
</asp:GridView>


<table width="100%" class="dataGrid_Footer">
    <tr>
        <td class="options">
         <!-- <a href="#" onclick="setCheckGroup('<% = gvData.ClientID %>',true); void(0);">ȫѡ</a> <a href="#" onclick="resverSelect('<% = gvData.ClientID %>'); void(0);">��ѡ</a> -->
        </td>
        <td class="pagerBox">
            <CashTicketControl:Pager ID="Pager1" runat="server"  />
        </td>
    </tr>
</table>




</asp:Content>


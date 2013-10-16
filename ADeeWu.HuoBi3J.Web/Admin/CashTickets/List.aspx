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
                    alert('请选择要指定的券！');
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
                        alert('处理成功！');
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
<span>现金券管理</span> &gt; 现金券列表  | <a href="Add.aspx">添加(系统生成)</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
<input type="hidden" name="page"  value="1" />
<table class="searchTable">
    <tr>
        <td class="key">商家名称:</td>
        <td class="input">
            <input type="text" name="corp" class="txtBox" id="corp" runat="server" />
        </td>
        <td class="key">现金券序列号:</td>
        <td class="input">
           <input type="text" name="serialNum" class="txtBox" id="serialNum" runat="server" />
        </td>
        <td class="key">状态:</td>
        <td class="input">
            <select name="state" runat="server" id="state">
                <option value="-1">全部</option>
                <option value="0">待审核(未使用)</option>
                <option value="1">已审核(已使用)</option>
                <option value="2">无效</option>
                <option value="3">已过期</option>
            </select>
        </td>
        <td>
             <input type="submit" value="搜索" />
        </td>
    </tr>
    <tr>
        <td>指定使用商家（已指定的现金券不会修改）：</td>
        <td colspan="5">
            <asp:DropDownList ID="ddlCorp" runat="server"></asp:DropDownList>
        </td>
        <td>
            <input type="button" value="指定" id="btnPoint" />
        </td>
    </tr>
</table>

<asp:GridView ID="gvData" runat="server" CssClass="dataGrid" SkinID="gridviewSkin" AutoGenerateColumns="False" BorderStyle="None">
<Columns>
    <asp:TemplateField HeaderStyle-CssClass="col_id"  ItemStyle-CssClass="col_id" HeaderText="ID">
        <HeaderTemplate>
            <input type="checkbox" name="checkall" />全选
        </HeaderTemplate>
        <ItemTemplate>
            <input type="checkbox" name="<% = gvData.ID %>" value="<%#Eval("ID") %>" /> <%#Eval("ID") %>
        </ItemTemplate>    

<HeaderStyle CssClass="col_id"></HeaderStyle>

<ItemStyle CssClass="col_id"></ItemStyle>
    </asp:TemplateField>
    <asp:BoundField HeaderText="所属商家" HeaderStyle-CssClass="col_title"  ItemStyle-CssClass="col_title" DataField="CorpName" >
<HeaderStyle CssClass="col_title"></HeaderStyle>

<ItemStyle CssClass="col_title"></ItemStyle>
    </asp:BoundField>
    <asp:HyperLinkField HeaderText="现金券序列号" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" DataNavigateUrlFields="id" DataNavigateUrlFormatString="Edit.aspx?id={0}" DataTextField="SerialNum" >
<HeaderStyle CssClass="col_title"></HeaderStyle>

<ItemStyle CssClass="col_title"></ItemStyle>
    </asp:HyperLinkField>
    <asp:BoundField HeaderText="现金券验证码" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" DataField="ValidCode"  >
    
<HeaderStyle CssClass="col_title"></HeaderStyle>

<ItemStyle CssClass="col_title"></ItemStyle>
    </asp:BoundField>
    
    <asp:BoundField DataField="Money" HeaderText="金额" />
    
    <asp:BoundField HeaderText="生成时间" HeaderStyle-CssClass="col_datetime"  ItemStyle-CssClass="col_datetime" DataField="CreateTime" HtmlEncode="true" DataFormatString="{0:d}" >
<HeaderStyle CssClass="col_datetime"></HeaderStyle>

<ItemStyle CssClass="col_datetime"></ItemStyle>
    </asp:BoundField>
    <asp:TemplateField HeaderStyle-CssClass="col_state"  ItemStyle-CssClass="col_state" HeaderText="状态">
        <ItemTemplate>
            <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                Eval("CheckState").ToString(),
                new string[][]{
                    new string[]{"0","待审核(未使用)"},
                    new string[]{"1","已审核(已使用)"},
                    new string[]{"2","无效"},
                    new string[]{"3","过期"}
                }               
                )
            %>
        </ItemTemplate>    

<HeaderStyle CssClass="col_state"></HeaderStyle>

<ItemStyle CssClass="col_state"></ItemStyle>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="操作" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option">
        <ItemTemplate>
            <a href="Edit.aspx?id=<%#Eval("ID") %>">修改</a>
        </ItemTemplate>

<HeaderStyle CssClass="col_option"></HeaderStyle>

<ItemStyle CssClass="col_option"></ItemStyle>
    </asp:TemplateField>
    
</Columns>
</asp:GridView>


<table width="100%" class="dataGrid_Footer">
    <tr>
        <td class="options">
         <!-- <a href="#" onclick="setCheckGroup('<% = gvData.ClientID %>',true); void(0);">全选</a> <a href="#" onclick="resverSelect('<% = gvData.ClientID %>'); void(0);">反选</a> -->
        </td>
        <td class="pagerBox">
            <CashTicketControl:Pager ID="Pager1" runat="server"  />
        </td>
    </tr>
</table>




</asp:Content>


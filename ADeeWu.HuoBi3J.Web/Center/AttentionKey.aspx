<%@ Page Language="C#" Title="" MasterPageFile="~/MIndex.master"  AutoEventWireup="true" CodeBehind="AttentionKey.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Center.AttentionKey" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
ȫ���� - ��ʱ���� - ��ע�ؼ���
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="/js/jquery.watermark.js" ></script>
<script>
    $(function () {
        $('#btnSubmit').click(function () {
            var price = $('#price').text();
            if (!window.confirm('�Ƿ��ע�ùؼ��֣��㽫����' + price + '��Ǯ')) {
                return false;
            }
        })
    })
</script>
<style>
    .result li
    {
        display: block;
        list-style: none;
        background: #DDD;
        margin-bottom: 10px;
        padding: 10px;
    }
    .result li h3
    {
        padding: 5px;
        font-size: 14px;
        background: #EEE;
        margin-bottom: 5px;
    }
</style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
    <div class="item">
        <div class="itemTitle">
            �ؼ�����Ϣ
        </div>
        <table class="formTable">
            <asp:Repeater ID="rpKey" runat="server">
                <ItemTemplate>
                    <tr>
                        <td class="tdLeft">
                            �ؼ������ƣ�
                        </td>
                        <td class="tdRight">
                            <strong style="color: #FF9933;">
                                <%# Eval("KName") %></strong>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdLeft">
                            ������Ȧ��
                        </td>
                        <td class="tdRight">
                            <strong style="color: #FF9933;">
                                <%# ADeeWu.HuoBi3J.Web.Class.Helper.GetBusinessCircle(Eval("bid"),Eval("bname")) %></strong>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdLeft">
                            ��������
                        </td>
                        <td class="tdRight">
                            <strong style="color: #FF9933;">
                                <%# ADeeWu.HuoBi3J.Web.Class.Helper.GetLocation(Eval("aid"),Eval("aname"),Eval("cid"),Eval("cname"),Eval("pid"),Eval("pname")," - ") %></strong>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdLeft">
                            ���ʱ�䣺
                        </td>
                        <td class="tdRight">
                            <strong style="color: #FF9933;">
                                <%# Eval("kcreatetime") %></strong>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr>
                <td class="tdLeft">
                    ���ѽ�Ǯ��
                </td>
                <td class="tdRight">
                    <strong style="color: #FF9933;"><span id="price"><asp:Literal ID="litPrice" runat="server" Text=""></asp:Literal></span></strong>
                </td>
            </tr>
            <tr>
                <td class="tdLeft">

                </td>
                <td class="tdRight">
                    <asp:Button ID="btnSubmit" runat="server" Text="��ע" onclick="btnSubmit_Click" CssClass="btn_blue" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
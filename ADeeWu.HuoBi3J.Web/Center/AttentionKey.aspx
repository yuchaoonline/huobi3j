<%@ Page Language="C#" Title="" MasterPageFile="~/MIndex.master"  AutoEventWireup="true" CodeBehind="AttentionKey.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Center.AttentionKey" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
全民广告 - 即时报价 - 关注关键字
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="/js/jquery.watermark.js" ></script>
<script>
    $(function () {
        $('#btnSubmit').click(function () {
            var price = $('#price').text();
            if (!window.confirm('是否关注该关键字？你将花费' + price + '金钱')) {
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
            关键字信息
        </div>
        <table class="formTable">
            <asp:Repeater ID="rpKey" runat="server">
                <ItemTemplate>
                    <tr>
                        <td class="tdLeft">
                            关键字名称：
                        </td>
                        <td class="tdRight">
                            <strong style="color: #FF9933;">
                                <%# Eval("KName") %></strong>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdLeft">
                            所属商圈：
                        </td>
                        <td class="tdRight">
                            <strong style="color: #FF9933;">
                                <%# ADeeWu.HuoBi3J.Web.Class.Helper.GetBusinessCircle(Eval("bid"),Eval("bname")) %></strong>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdLeft">
                            所属区域：
                        </td>
                        <td class="tdRight">
                            <strong style="color: #FF9933;">
                                <%# ADeeWu.HuoBi3J.Web.Class.Helper.GetLocation(Eval("aid"),Eval("aname"),Eval("cid"),Eval("cname"),Eval("pid"),Eval("pname")," - ") %></strong>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdLeft">
                            添加时间：
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
                    花费金钱：
                </td>
                <td class="tdRight">
                    <strong style="color: #FF9933;"><span id="price"><asp:Literal ID="litPrice" runat="server" Text=""></asp:Literal></span></strong>
                </td>
            </tr>
            <tr>
                <td class="tdLeft">

                </td>
                <td class="tdRight">
                    <asp:Button ID="btnSubmit" runat="server" Text="关注" onclick="btnSubmit_Click" CssClass="btn_blue" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<%@ Page Language="C#" Title="" MasterPageFile="~/MIndex.master" AutoEventWireup="true" CodeBehind="Key4Product.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Center.Key4Product" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    ȫ���� - �۸��б�
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script src="../JS/jquery.cookie.js"></script>
    <link href="/CSS/forum_common.css" rel="stylesheet" type="text/css" />
    <link href="/CSS/forum_forumdisplay.css" rel="stylesheet" type="text/css" />
    <link href="../GroupBuy/base.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {
            $('.arc_title img').ReduceImage();

            $('.showinfo').click(function () {
                var $this = $(this);
                var win = $('#window');
                win.html($this.parent().find('div').html()).dialog({
                    title: '����',
                    width: 500,
                    modal: true
                });

                return false;
            });

            $('.item a1').click(function () {
                if ($(this).text() != '' && $(this).text() != '��')
                $.cookie($(this).attr('class'), $(this).text());

                location.href = "key4product.aspx?kid=<%=kid%>&selectType=" + $.cookie('selectType') + "&selectSize=" + $.cookie('selectSize') + "&selectPrice=" + $.cookie('selectPrice');
            })
        })
    </script>
    <style type="text/css">
        .dline a {
            text-decoration: underline;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
    <div id="center_list">
        <div class="centerP_body">
            <asp:Repeater ID="rpKey" runat="server">
                <ItemTemplate>
                    <div class="body_content font14 black70">
                        <p>
                            <span>�ؼ������ƣ�<label class="fb black32 "><%# Eval("KName") %></label></span></p>
                        <p class="mt10">
                            <span>������Ȧ��
                                <label class="black32 dline"><%# ADeeWu.HuoBi3J.Web.Class.Helper.GetBusinessCircle(Eval("bid"),Eval("bname")) %></label>
                            </span>
                            <span class="gjbj1">����������<label class="black32"><%# ADeeWu.HuoBi3J.Web.Class.Helper.GetLocation(Eval("aid"),Eval("aname"),Eval("cid"),Eval("cname"),Eval("pid"),Eval("pname")," - ") %></label></span></p>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="centerP_head"></div>
    </div>

    <div class="cl"></div>

    <div id="filter">
        <div class="filter-sortbar-outer-box">
            <div class="filter-section-wrapper">
                <div class="filter-label-list filter-section category-filter-wrapper first-filter">
                    <div class="label has-icon"><i></i>������</div>
                    <ul class="inline-block-list">
                        <li class="item current">
                            <asp:TextBox runat="server" ID="txtSearch" CssClass="searchText"></asp:TextBox>
                            <asp:Button runat="server" ID="btnSearch" CssClass="btn_blue" Text="����" OnClick="btnSearch_Click" />
                        </li>
                    </ul>
                </div>
                <div class="filter-label-list filter-section category-filter-wrapper">
                    <div class="label has-icon"><i></i>���ͣ�</div>
                    <ul class="inline-block-list">
                        <asp:Literal runat="server" ID="litType"></asp:Literal>
                    </ul>
                </div>
                <div class="filter-label-list filter-section category-filter-wrapper">
                    <div class="label has-icon"><i></i>�ߴ磺</div>
                    <ul class="inline-block-list">
                        <asp:Literal runat="server" ID="litSize"></asp:Literal>
                    </ul>
                </div>
                <div class="filter-label-list filter-section category-filter-wrapper">
                    <div class="label has-icon"><i></i>�۸�</div>
                    <ul class="inline-block-list">
                        <asp:Literal runat="server" ID="litPrice"></asp:Literal>
                    </ul>
                </div>
            </div>
        </div>
    </div>

    <div class="cl"></div>

    <asp:Repeater ID="rpProduct" runat="server">
        <HeaderTemplate>
            <table id="rentP_list" class="table_list font14" cellpadding="0" cellspacing="0">
                <thead>
                    <tr height="30px" class="black70 fb font12">
                        <td style="width: 80px;">�۸�</td>                        
                        <td style="width: 200px;">������</td>
                        <td style="width: 205px;">ѡ��</td>
                        <td style="width: 190px;">��˾</td>
                        <td style="width: 190px;">��ַ</td>
                        <td style="width: 80px;">����</td>
                    </tr>
                </thead>
        </HeaderTemplate>
        <ItemTemplate>
            <tbody>
                <tr height="40px" onmouseover="this.className='jobMenu_hover'" onmouseout="this.className=''" class="">
                    <td class="arc_title"><%# Eval("[Price]") %></td>
                    <td><%# Eval("[simpledesc]") %></td>
                    <td><%# Eval("[selectattribute]") %></td>
                    <td><%# Eval("[companyname]") %></td>
                    <td><%# Eval("[companyaddress]")%></td>
                    <td>
                        <a href="#" class="btn_blue showinfo" contentid="<%# Eval("[id]") %>" typeid="2" title="����">����</a>
                        <div style="display: none;"><%# Eval("[description]") %></div>
                    </td>
                </tr>
            </tbody>
        </ItemTemplate>
        <FooterTemplate>
            </table>
            <div id="window"></div>
        </FooterTemplate>
    </asp:Repeater>

    <IscControl:Pager3 ID="Pager1" runat="server" />
</asp:Content>
